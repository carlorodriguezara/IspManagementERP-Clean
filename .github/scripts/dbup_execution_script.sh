#!/usr/bin/env bash
set -euo pipefail

echo "===== dbup_execution_script.sh start ====="
echo "PWD: $(pwd)"
echo "Listing artifact_dbup top:"
ls -la ./artifact_dbup || true

# 1) Buscar si ya fue descomprimido por el job
DBUP_DLL=$(find ./artifact_dbup/unzipped -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
DBUP_DIR=""

# 2) Si no está, inspeccionar el zip para localizar la ruta dentro del zip
if [ -z "$DBUP_DLL" ] && [ -f ./artifact_dbup/dbup-publish.zip ]; then
  echo "Inspecting zip for dll path..."
  # intentamos listar rutas con unzip -Z1 (si está disponible) o con unzip -l
  if unzip -Z1 ./artifact_dbup/dbup-publish.zip >/dev/null 2>&1; then
    DBUP_DLL_PATH_IN_ZIP=$(unzip -Z1 ./artifact_dbup/dbup-publish.zip | grep "IspManagementERP.DbUp.dll" | head -n1 || true)
  else
    DBUP_DLL_PATH_IN_ZIP=$(unzip -l ./artifact_dbup/dbup-publish.zip | awk '{print $4}' | grep "IspManagementERP.DbUp.dll" | head -n1 || true)
  fi

  echo "DBUP_DLL_PATH_IN_ZIP='$DBUP_DLL_PATH_IN_ZIP'"

  if [ -n "$DBUP_DLL_PATH_IN_ZIP" ]; then
    DIR_IN_ZIP=$(dirname "$DBUP_DLL_PATH_IN_ZIP")
    echo "DIR_IN_ZIP='$DIR_IN_ZIP' (will extract this folder's contents)"

    mkdir -p ./artifact_dbup/unzipped_from_zip || true

    # 2a) intentamos extraer por patrón (mantiene carpetas)
    if [ "$DIR_IN_ZIP" = "." ] || [ -z "$DIR_IN_ZIP" ]; then
      echo "Extracting entire zip because DIR_IN_ZIP is '.' or empty"
      unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip || true
    else
      # Primera opción: usar unzip con patrón "DIR_IN_ZIP/*"
      echo "Trying unzip pattern extraction: unzip dbup-publish.zip \"$DIR_IN_ZIP/*\" -d ./artifact_dbup/unzipped_from_zip"
      if unzip -q ./artifact_dbup/dbup-publish.zip "$DIR_IN_ZIP/*" -d ./artifact_dbup/unzipped_from_zip 2>/dev/null; then
        echo "Pattern extraction succeeded"
      else
        echo "Pattern extraction failed — falling back to file-list extraction"
        # Creamos lista exacta de archivos que comienzan por DIR_IN_ZIP/
        if unzip -Z1 ./artifact_dbup/dbup-publish.zip >/dev/null 2>&1; then
          LIST=$(unzip -Z1 ./artifact_dbup/dbup-publish.zip | awk -v p="$DIR_IN_ZIP/" 'index($0,p)==1 {print}')
        else
          LIST=$(unzip -l ./artifact_dbup/dbup-publish.zip | awk '{print $4}' | awk -v p="$DIR_IN_ZIP/" 'index($0,p)==1 {print}')
        fi

        if [ -n "$LIST" ]; then
          echo "Files to extract (count $(echo "$LIST" | wc -l))"
          echo "$LIST" > /tmp/_dbup_files_to_extract.txt
          # unzip -@ lee nombres desde stdin y preserva la estructura
          unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip -@ < /tmp/_dbup_files_to_extract.txt || true
        else
          echo "No files matched the DIR_IN_ZIP prefix — as last resort extract whole zip"
          unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip || true
        fi
      fi
    fi

    DBUP_DLL=$(find ./artifact_dbup/unzipped_from_zip -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
    DBUP_DIR=$(dirname "$DBUP_DLL" || true)
  fi
fi

# 3) Si aún no lo encontramos, como último recurso extraer todo
if [ -z "$DBUP_DLL" ] && [ -f ./artifact_dbup/dbup-publish.zip ]; then
  echo "DLL still not found — extracting entire zip as last resort..."
  rm -rf ./artifact_dbup/unzipped_from_zip_full || true
  mkdir -p ./artifact_dbup/unzipped_from_zip_full
  unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip_full || true
  DBUP_DLL=$(find ./artifact_dbup/unzipped_from_zip_full -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
  DBUP_DIR=$(dirname "$DBUP_DLL" || true)
fi

# 4) Si no hay DLL -> error
if [ -z "$DBUP_DLL" ]; then
  echo "ERROR: DbUp DLL no encontrado en artifact_dbup; no se pueden ejecutar migraciones."
  echo "Listado artifact_dbup (primeros niveles):"
  find ./artifact_dbup -maxdepth 4 -type f -print || true
  exit 1
fi

echo "Found DbUp DLL at: $DBUP_DLL"
if [ -z "${DBUP_DIR:-}" ]; then
  DBUP_DIR=$(dirname "$DBUP_DLL")
fi
echo "Running from directory: $DBUP_DIR"
ls -la "$DBUP_DIR" || true

# 5) Ejecutar desde la carpeta
pushd "$DBUP_DIR" > /dev/null || true

if [ -f "./IspManagementERP.DbUp.runtimeconfig.json" ]; then
  echo "runtimeconfig.json encontrado - ejecutando dotnet ./IspManagementERP.DbUp.dll"
  dotnet ./IspManagementERP.DbUp.dll
  EXIT_CODE=$?
  popd > /dev/null || true
  echo "dotnet exit code: $EXIT_CODE"
  exit $EXIT_CODE
fi

if [ -x "./IspManagementERP.DbUp" ]; then
  echo "Ejecutable nativo encontrado; ejecutando ./IspManagementERP.DbUp"
  chmod +x ./IspManagementERP.DbUp || true
  ./IspManagementERP.DbUp
  EXIT_CODE=$?
  popd > /dev/null || true
  echo "native exe exit code: $EXIT_CODE"
  exit $EXIT_CODE
fi

echo "No runtimeconfig ni exe nativo; intentando dotnet con la DLL completa..."
dotnet "$DBUP_DLL"
EXIT_CODE=$?
popd > /dev/null || true
echo "dotnet fallback exit code: $EXIT_CODE"
exit $EXIT_CODE

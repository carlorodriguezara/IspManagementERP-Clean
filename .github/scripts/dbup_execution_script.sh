#!/usr/bin/env bash
set -euo pipefail

# 1) Buscar si ya fue descomprimido por el job
DBUP_DLL=$(find ./artifact_dbup/unzipped -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
DBUP_DIR=""

# 2) Si no está, inspeccionar el zip para localizar la ruta dentro del zip
if [ -z "$DBUP_DLL" ] && [ -f ./artifact_dbup/dbup-publish.zip ]; then
  # Obtener la primera ruta del dll dentro del zip (ej: publish/net7.0/publish/IspManagementERP.DbUp.dll)
  DBUP_DLL_PATH_IN_ZIP=$(unzip -l ./artifact_dbup/dbup-publish.zip | awk '{print $4}' | grep "IspManagementERP.DbUp.dll" | head -n1 || true)

  if [ -n "$DBUP_DLL_PATH_IN_ZIP" ]; then
    # EXTRAER LA CARPETA que contiene el DLL (no sólo el fichero)
    DIR_IN_ZIP=$(dirname "$DBUP_DLL_PATH_IN_ZIP")
    echo "Found DBUP DLL inside zip at: $DBUP_DLL_PATH_IN_ZIP"
    echo "Extracting whole folder inside zip: $DIR_IN_ZIP"
    mkdir -p ./artifact_dbup/unzipped_from_zip
    if [ "$DIR_IN_ZIP" = "." ] || [ -z "$DIR_IN_ZIP" ]; then
      unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip || true
    else
      # Extrae todos los archivos bajo la carpeta que contiene el dll
      unzip -q ./artifact_dbup/dbup-publish.zip "$DIR_IN_ZIP/*" -d ./artifact_dbup/unzipped_from_zip || true
    fi
    DBUP_DLL=$(find ./artifact_dbup/unzipped_from_zip -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
    DBUP_DIR=$(dirname "$DBUP_DLL" || true)
  fi
fi

# 3) Si aún no lo encontramos, como último recurso extraer todo
if [ -z "$DBUP_DLL" ] && [ -f ./artifact_dbup/dbup-publish.zip ]; then
  echo "No se encontró el DLL en rutas esperadas; descomprimiendo todo el zip como último recurso..."
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
  find ./artifact_dbup -maxdepth 3 -type f -print || true
  exit 1
fi

echo "Found DbUp DLL at: $DBUP_DLL"
# Asegurar DBUP_DIR tiene valor
if [ -z "${DBUP_DIR:-}" ]; then
  DBUP_DIR=$(dirname "$DBUP_DLL")
fi
echo "Running from directory: $DBUP_DIR"
ls -la "$DBUP_DIR" || true

# 5) Ejecutar desde la carpeta para que runtimeconfig.json / deps / libhost* estén presentes
pushd "$DBUP_DIR" > /dev/null || true

if [ -f "./IspManagementERP.DbUp.runtimeconfig.json" ]; then
  echo "runtimeconfig.json encontrado - ejecutando dotnet ./IspManagementERP.DbUp.dll"
  dotnet ./IspManagementERP.DbUp.dll
  EXIT_CODE=$?
  popd > /dev/null || true
  exit $EXIT_CODE
fi

# Si existe ejecutable nativo (self-contained) ejecútalo
if [ -x "./IspManagementERP.DbUp" ]; then
  echo "Ejecutable nativo encontrado; ejecutando ./IspManagementERP.DbUp"
  chmod +x ./IspManagementERP.DbUp || true
  ./IspManagementERP.DbUp
  EXIT_CODE=$?
  popd > /dev/null || true
  exit $EXIT_CODE
fi

# Fallback final: ejecutar dotnet con la ruta completa al dll (si runner tiene dotnet)
echo "No runtimeconfig.json ni exe nativo; intentando dotnet con la DLL completa..."
dotnet "$DBUP_DLL"
EXIT_CODE=$?
popd > /dev/null || true
exit $EXIT_CODE

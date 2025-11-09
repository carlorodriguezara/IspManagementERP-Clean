#!/usr/bin/env bash
set -euo pipefail

# Buscar primero en la carpeta ya descomprimida
DBUP_DLL=$(find ./artifact_dbup/unzipped -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)

# Si no está, inspeccionar el zip para localizar la ruta dentro del zip
if [ -z "$DBUP_DLL" ]; then
  if [ -f ./artifact_dbup/dbup-publish.zip ]; then
    DBUP_DLL_PATH_IN_ZIP=$(unzip -l ./artifact_dbup/dbup-publish.zip | awk '{print $4}' | grep "IspManagementERP.DbUp.dll" | head -n1 || true)
    if [ -n "$DBUP_DLL_PATH_IN_ZIP" ]; then
      DIR_IN_ZIP=$(dirname "$DBUP_DLL_PATH_IN_ZIP")
      echo "Found DBUP DLL inside zip at: $DBUP_DLL_PATH_IN_ZIP"
      echo "Extracting whole folder inside zip: $DIR_IN_ZIP"
      mkdir -p ./artifact_dbup/unzipped_from_zip
      if [ "$DIR_IN_ZIP" = "." ] || [ -z "$DIR_IN_ZIP" ]; then
        unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip || true
      else
        unzip -q ./artifact_dbup/dbup-publish.zip "$DIR_IN_ZIP/*" -d ./artifact_dbup/unzipped_from_zip || true
      fi
      DBUP_DLL=$(find ./artifact_dbup/unzipped_from_zip -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
    fi
  fi
fi

# Si aún no lo encontramos, descomprimir todo como último recurso
if [ -z "$DBUP_DLL" ]; then
  if [ -f ./artifact_dbup/dbup-publish.zip ]; then
    echo "Descomprimiendo todo el zip como último recurso..."
    rm -rf ./artifact_dbup/unzipped_from_zip_full || true
    mkdir -p ./artifact_dbup/unzipped_from_zip_full
    unzip -q ./artifact_dbup/dbup-publish.zip -d ./artifact_dbup/unzipped_from_zip_full || true
    DBUP_DLL=$(find ./artifact_dbup/unzipped_from_zip_full -type f -name "IspManagementERP.DbUp.dll" 2>/dev/null | head -n1 || true)
    EXTRA_EXTRACT_DIR=./artifact_dbup/unzipped_from_zip_full
  fi
fi

if [ -z "$DBUP_DLL" ]; then
  echo "ERROR: DbUp DLL no encontrado en artifact_dbup; no se pueden ejecutar migraciones."
  ls -la ./artifact_dbup || true
  exit 1
fi

DBUP_DIR=$(dirname "$DBUP_DLL")
echo "Found DbUp DLL at: $DBUP_DLL"
echo "Running from directory: $DBUP_DIR"
ls -la "$DBUP_DIR" || true

# Ejecutar desde la carpeta para que runtimeconfig/deps estén presentes
if [ -f "$DBUP_DIR/IspManagementERP.DbUp.runtimeconfig.json" ]; then
  echo "runtimeconfig.json encontrado - ejecutando dotnet desde el directorio..."
  pushd "$DBUP_DIR" > /dev/null || true
  dotnet ./IspManagementERP.DbUp.dll
  popd > /dev/null || true
else
  if [ -x "$DBUP_DIR/IspManagementERP.DbUp" ]; then
    echo "Ejecutable nativo encontrado; ejecutando..."
    chmod +x "$DBUP_DIR/IspManagementERP.DbUp" || true
    "$DBUP_DIR/IspManagementERP.DbUp"
  else
    echo "No runtimeconfig ni exe nativo; ejecutando dotnet con la ruta completa al dll..."
    dotnet "$DBUP_DLL"
  fi
fi

# CI/CD profesional con GitHub Actions para IspManagementERP

Este documento describe el flujo de integración y despliegue continuo (CI/CD) utilizado para publicar automáticamente la aplicación **IspManagementERP** en Azure App Service cada vez que se realiza un push a la rama `main`.

---

## Flujo resumido

1. **Desarrollador** realiza cambios en el código.
2. **Commit** y **push** a la rama principal (`main`).
3. **GitHub Actions** detecta el push y ejecuta el workflow de CI/CD.
4. El workflow:
    - Restaura dependencias.
    - Compila y publica el proyecto.
    - Despliega automáticamente a Azure App Service.
5. La aplicación queda disponible en producción en Azure.

---

## Estructura del workflow

El archivo de configuración del workflow se encuentra en:

```
.github/workflows/deploy-to-azure.yml
```

### Pasos clave:

- **actions/checkout:** Descarga el código fuente.
- **actions/setup-dotnet:** Instala el SDK de .NET necesario.
- **dotnet restore/build/publish:** Restaura, compila y publica el proyecto Server.
- **azure/webapps-deploy:** Despliega la aplicación publicada en Azure App Service usando el perfil de publicación seguro.

---

## Variables importantes

- `AZURE_WEBAPP_NAME`: Nombre del App Service en Azure.
- `DOTNET_VERSION`: Versión de .NET utilizada por el proyecto (ejemplo: 7.0.x).
- `AZUREAPPSERVICE_PUBLISHPROFILE`: Secreto seguro con el perfil de publicación exportado desde Azure.

---

## ¿Cómo agregar o actualizar el perfil de publicación?

1. En Azure Portal, ve a tu App Service > "Perfil de publicación" > "Descargar perfil".
2. En GitHub, ve a tu repo > Settings > Secrets and variables > Actions.
3. Crea o reemplaza el secreto `AZUREAPPSERVICE_PUBLISHPROFILE` pegando el contenido del archivo descargado.

---

## ¿Cómo modificar el workflow?

- Edita el archivo `.github/workflows/deploy-to-azure.yml`.
- Cambia el nombre de la app, versión de .NET, ruta del proyecto, etc., según requieras.

---

## ¿Cómo saber si el deploy fue exitoso?

- Ve a la pestaña **Actions** de tu repo en GitHub.
- Haz clic en el workflow ejecutado.
- Si todo está en verde, tu app se desplegó correctamente.
- Si hay errores, revisa los logs para detalles.

---

## Buenas prácticas

- Nunca subas secretos ni cadenas de conexión sensibles al repo.
- Mantén el archivo de workflow bajo control de versiones.
- Documenta cualquier ajuste a CI/CD en este archivo.

---
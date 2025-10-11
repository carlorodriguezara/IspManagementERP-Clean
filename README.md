# IspManagementERP

ERP profesional basado en Blazor WebAssembly Hosted (.NET 7) con autenticación OIDC y listo para CI/CD en Azure.

## Estructura de la solución

```
IspManagementERP/
│
├── IspManagementERP.Server/      # Backend API, lógica, datos, seguridad, migraciones
├── IspManagementERP.Client/      # Frontend Blazor WebAssembly
├── IspManagementERP.Shared/      # Modelos y DTOs compartidos
├── README.md                     # Documentación principal
└── .gitignore                    # Exclusiones para Git
```

## Tecnologías

- Blazor WebAssembly Hosted (.NET 7)
- ASP.NET Core
- IdentityServer (OIDC)
- Entity Framework Core
- Azure App Service + Azure SQL
- GitHub Actions (CI/CD)

## Primeros pasos

1. Abrir la solución en Visual Studio 2022.
2. Ejecutar el proyecto Server como principal.
3. Acceder a la app en https://localhost:xxxx/

## Autenticación

- Flujo OIDC listo para login, registro y administración de usuarios.
- Backend preparado para migraciones automáticas y deploy en Azure.

## Próximos pasos

- Migrar estructura profesional ERP.
- Versionar en GitHub.
- Configurar Azure y CI/CD.
-
## subir por primera vez a GITHUB
### Comandos
- git init
- git add .
- git commit -m "Initial commit: Blazor WASM Hosted (.NET 7) ERP solution with doc"
- git remote add origin https://github.com/carlorodriguezara/IspManagementERP.git
- git push -u origin main

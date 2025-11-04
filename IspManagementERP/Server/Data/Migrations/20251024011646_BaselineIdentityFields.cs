using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IspManagementERP.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaselineIdentityFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Migration baseline: no aplicar cambios porque ya los aplicamos manualmente.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ningún cambio a revertir.
        }
    }
}


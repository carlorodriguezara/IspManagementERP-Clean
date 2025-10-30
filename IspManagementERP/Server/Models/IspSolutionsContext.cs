using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IspManagementERP.Server.Models;

public partial class IspSolutionsContext : DbContext
{
    public IspSolutionsContext()
    {
    }

    public IspSolutionsContext(DbContextOptions<IspSolutionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afiliacionobrasocial> Afiliacionobrasocials { get; set; }
    // ... (mantener todos los DbSet tal como están)

    // NOTE: Removed hard-coded connection string to avoid leaking secrets.
    // When the context is created by DI, the options will be configured by Program.cs.
    // If someone instantiates this context without DI (design-time), we allow a safe fallback
    // using an environment variable ISP_DEFAULT_CONNECTION. We DO NOT include any hard-coded secrets.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conn = Environment.GetEnvironmentVariable("ISP_DEFAULT_CONNECTION");
            if (!string.IsNullOrWhiteSpace(conn))
            {
                optionsBuilder.UseSqlServer(conn);
            }
            // If ISP_DEFAULT_CONNECTION is not set, do nothing here to avoid accidental use of insecure credentials.
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // existing model configuration preserved (copiar todo lo que ya tenías)
        // ...
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebPerfilAcesso.Models;

namespace WebPerfilAcesso.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
        public DbSet<AcesoTipoUsuario> AcessosTiposUsuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

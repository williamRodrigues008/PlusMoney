using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace PlusMoney.API.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UsuarioId, ur.RoleId });
        }
    }
}

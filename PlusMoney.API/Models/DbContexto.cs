using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace PlusMoney.API.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Movimentacao> Movimentacao { get; set; }
    }
}

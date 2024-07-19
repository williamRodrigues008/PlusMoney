using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Services
{
    public class MovimentacaoService : IMovimentacao
    {
        private readonly DbContexto _contextoDb;

        public MovimentacaoService(DbContexto contextoDb)
        {
            _contextoDb = contextoDb;
        }

        public async Task<IEnumerable<Movimentacao>> ListarMovimentacao()
        {
            return _contextoDb.Movimentacao.ToList();
        }
    }
}

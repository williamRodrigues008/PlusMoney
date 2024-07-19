using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface IMovimentacao
    {
        public Task<IEnumerable<Movimentacao>> ListarMovimentacao();
    }
}

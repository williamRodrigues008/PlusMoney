using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface ILeituraMovimentacao
    {
        public Task<IEnumerable<Movimentacao>> ListarMovimentacao();
        public Task<IEnumerable<Movimentacao>> ListarMovimentacaoUsuario(string usuario);

    }
}

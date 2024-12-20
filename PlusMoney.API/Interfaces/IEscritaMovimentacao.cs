using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface IEscritaMovimentacao
    {
        string AdicionarMovimentacao(Movimentacao movimentacao);
    }
}

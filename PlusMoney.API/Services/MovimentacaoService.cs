using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Services
{
    public class MovimentacaoService : ILeituraEscritaMovimentacao
    {
        private readonly DbContexto _contextoDb;

        public MovimentacaoService(DbContexto contextoDb)
        {
            _contextoDb = contextoDb;
        }

        public string AdicionarMovimentacao(Movimentacao movimentacao)
        {
            if(movimentacao != null)
            {
                _contextoDb.Add(movimentacao);
                _contextoDb.SaveChanges();
                return "Sucesso ao adicionar nova movimentação!";

            }
            return "Ops, houve um erro na criação da nova movimentação";
        }

        public async Task<IEnumerable<Movimentacao>> ListarMovimentacao()
        {
            return _contextoDb.Movimentacao.ToList();
        }
    }
}

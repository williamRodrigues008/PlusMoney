using PlusMoney.API.Helpers;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Services
{
    public class UsuarioService : IUsuarioLeituraEscrita
    {
        private readonly DbContexto _contextoDb;

        public UsuarioService(DbContexto contextoDb)
        {
            _contextoDb = contextoDb;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosUsuario()
        {
            return _contextoDb.Usuario.ToList();
        }

        public Usuario BuscarUsuario(string tipoBusca, string valorBusca)
        {
            throw new NotImplementedException();
        }

        public string CriarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                _contextoDb.Add(usuario);
                if(_contextoDb.SaveChanges() >= 1 )
                    return "Sucesso ao adicionar nova movimentação!";
            }
            return "Ops, houve um erro na criação da nova movimentação";
        }

        public Usuario LoginUsuario(Login login)
        {
            login.Senha = login.Senha!.CriptografarSenha();
            return _contextoDb.Usuario.FirstOrDefault(u => u.NomeUsuario!.ToLower() == login.Usuario!.ToLower() && u.Senha == login.Senha)!;
        }

        public void RemoverUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}

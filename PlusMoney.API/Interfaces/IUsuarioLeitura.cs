using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface IUsuarioLeitura
    {
        Usuario LoginUsuario(Login login);
        Usuario BuscarUsuario(string tipoBusca, string valorBusca);
        Task<IEnumerable<Usuario>> BuscarTodosUsuario();

    }
}

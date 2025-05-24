using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface IUsuarioLeitura
    {
        Usuario BuscarUsuario(string nome);
        Task<IEnumerable<Usuario>> BuscarTodosUsuario();

    }
}

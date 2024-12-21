using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface IUsuarioEscrita
    {
        string CriarUsuario(Usuario usuario);
        void RemoverUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
    }
}

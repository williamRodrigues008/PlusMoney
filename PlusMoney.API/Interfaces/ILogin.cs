using PlusMoney.API.Models;

namespace PlusMoney.API.Interfaces
{
    public interface ILogin
    {
        Task<Usuario> RealizarLogin(Login login);
        Task RealizarLogout();
    }
}

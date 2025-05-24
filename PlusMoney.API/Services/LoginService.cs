using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PlusMoney.API.Helpers;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;
using System.Security.Claims;

namespace PlusMoney.API.Services
{
    public class LoginService : ILogin
    {
        private readonly DbContexto _contextoDb;
        private readonly IHttpContextAccessor _accessor;

        public LoginService(DbContexto contextoDb, IHttpContextAccessor accessor)
        {
            _contextoDb = contextoDb;
            _accessor = accessor;
        }

        public async Task<Usuario> RealizarLogin(Login login)
        {
            login.Senha = login.Senha!.CriptografarSenha();
            var usuario = _contextoDb.Usuario.FirstOrDefault(u => u.NomeUsuario!.ToLower() == login.Usuario!.ToLower() && u.Senha == login.Senha)!;
            var userRoles = _contextoDb.UserRoles.ToList();
            var roles = _contextoDb.Roles.ToList();
            var tses = roles.Where(r => userRoles.Any(u => u.RoleId == r.Id && usuario.Id == u.UsuarioId)).Select(rol => rol.Name).ToList();
            usuario.ListaRoles = tses;
            return usuario;
        }

        public Task RealizarLogout()
        {
            throw new NotImplementedException();
        }
    }
}

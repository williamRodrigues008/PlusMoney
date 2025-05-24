using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using PlusMoney.API.Models;
using System.Security.Claims;

namespace PlusMoney.API.Helpers
{
    public class AutenticarUsuario : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _claimsNull = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly IHttpContextAccessor _context;

        public AutenticarUsuario(IHttpContextAccessor context)
        {
            _context = context;
        }

        public async Task AtualizarEstadoAutenticacao(Usuario usuario)
        {
            ClaimsPrincipal principal = new();
            var role = usuario.Admin ? "admin" : "comum";
            List<Claim> acessos = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier, usuario.NomeUsuario!),
                    new Claim(ClaimTypes.Name, usuario.NomeCompleto!),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Authentication, "SessaoUsuario")
            };
            var identidade = new ClaimsIdentity(acessos, "SessaoUsuario");
            var usuarioPrincipal = new ClaimsPrincipal(new[] { identidade });
            await _context.HttpContext!.SignInAsync(usuarioPrincipal, new AuthenticationProperties() { });
            
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            return null; // await Task.FromResult(new AuthenticationState(principal));
        }
    }
}

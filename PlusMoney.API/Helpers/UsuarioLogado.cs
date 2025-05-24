using System.Security.Claims;

namespace PlusMoney.API.Helpers
{
    public class UsuarioLogado
    {
        private readonly IHttpContextAccessor _accessor;

        public UsuarioLogado(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string NomeUsuario => _accessor.HttpContext!.User.Identity!.Name!;
        public string NomeCompleto => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value!;
        public bool IsAutenticad => _accessor.HttpContext!.User.Identity!.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext!.User.Claims;
        }
    }
}

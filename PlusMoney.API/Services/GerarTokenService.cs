using Microsoft.IdentityModel.Tokens;
using PlusMoney.API.Helpers;
using PlusMoney.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PlusMoney.API.Services
{
    public static class GerarTokenService
    {
        public static string GerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("Nome", usuario.NomeCompleto!),
                new Claim("Usuario", usuario.NomeUsuario!),
                new Claim("Email", usuario.Email!),
                new Claim("Id", usuario.Id.ToString())
            };
            claims.AddRange(usuario.ListaRoles!.Select(role => new Claim(ClaimTypes.Role, role)));


            var expiracao = DateTime.Now.AddHours(8);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuracoes.Key));
            var dadosToken = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                    claims: claims,
                    expires: expiracao
                );

            return new JwtSecurityTokenHandler().WriteToken(dadosToken);
        }
    }
}

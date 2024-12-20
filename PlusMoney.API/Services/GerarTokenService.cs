using Microsoft.IdentityModel.Tokens;
using PlusMoney.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PlusMoney.API.Services
{
    public class GerarTokenService
    {
        public dynamic GerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("Nome", usuario.NomeCompleto!),
                new Claim("Usuario", usuario.NomeUsuario!),
                new Claim("Email", usuario.Email!),
                new Claim("Id", usuario.Id.ToString())
            };

            var expiracao = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-plus-money-access-application"));
            var dadosToken = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                    claims: claims,
                    expires: expiracao
                );

            var token = new JwtSecurityTokenHandler().WriteToken(dadosToken);

            return new
            {
                access_token = token,
                expires = expiracao
            };
        }
    }
}

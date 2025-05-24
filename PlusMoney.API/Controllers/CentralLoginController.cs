using Microsoft.AspNetCore.Mvc;
using PlusMoney.API.Models;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Services;

namespace PlusMoney.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CentralLoginController : Controller
    {
        private readonly ILogin _login;

        public CentralLoginController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> LoginAsync([FromBody]Login login)
        {
            var user = await _login.RealizarLogin(login);
            if (user == null)
                return NotFound(new { message = "Usuario e/ou senha incorretos." });

            var token = GerarTokenService.GerarToken(user);
            user.Senha = "senha oculta";
            return new
            {
                usuario = user,
                token = token
            };
        }
    }   
}

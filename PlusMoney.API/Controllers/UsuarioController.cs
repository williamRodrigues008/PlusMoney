using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlusMoney.API.Helpers;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;
using PlusMoney.API.Services;

namespace PlusMoney.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioLeituraEscrita _usuario;
        private readonly UsuarioLogado _logado;
        private readonly DbContexto _contextoDb;

        public UsuarioController(IUsuarioLeituraEscrita usuario, DbContexto contextoDb, UsuarioLogado logado)
        {
            _usuario = usuario;
            _contextoDb = contextoDb;
            _logado = logado;
        }

        [HttpGet("BuscarUsuarios")]
        [Authorize]
        public ActionResult BuscarUsuarios()
        {
            return Ok(_usuario.BuscarTodosUsuario());
        }


        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario([FromBody]Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.GerarCriptografia();
                return Ok(_usuario.CriarUsuario(usuario));
            }
            return BadRequest("Não foi possivel criar este usuário");
        }

        [HttpPost("Logar")]
        public IActionResult Logar([FromBody]Login login)
        {
            var usuario = _usuario.LoginUsuario(login);
            if (ModelState.IsValid)
            {
                if(usuario == null) return NotFound("Senha e/ou usuário incorretos, corrija e tente novamente");
                var token = new GerarTokenService().GerarToken(usuario);
                return Json(token);
            }
            return BadRequest("Falha na requisição do login");
        }
    }
}

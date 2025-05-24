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
        private readonly DbContexto _contextoDb;

        public UsuarioController(IUsuarioLeituraEscrita usuario, DbContexto contextoDb)
        {
            _usuario = usuario;
            _contextoDb = contextoDb;
        }

        [HttpGet("BuscarUsuarios")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuario.BuscarTodosUsuario();
            if (usuarios == null)
                return BadRequest("Ops! houve um erro na busca de usuários");
            return Json(usuarios);
        }

        [HttpPost]
        [Route("/BuscarUsuarioPorNome")]
        public IActionResult BuscarUsuarioPorNome(string nome) 
        {
            var usuarioEncontrado = _usuario.BuscarUsuario(nome);
            if (usuarioEncontrado == null) return NotFound(new Usuario());
            return Ok(usuarioEncontrado);
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
    }
}

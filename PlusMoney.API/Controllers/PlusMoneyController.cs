using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Controllers
{
    [Route("api/[controller]")]
    public class PlusMoneyController : Controller
    {
        private readonly DbContexto _contextoDb;
        private readonly ILeituraEscritaMovimentacao _Imovimentacao;

        public PlusMoneyController(DbContexto contextoDb, ILeituraEscritaMovimentacao imovimentacao)
        {
            _contextoDb = contextoDb;
            _Imovimentacao = imovimentacao;
        }

        [HttpGet("GetMovimentacao")]
        public async Task<IActionResult> Index()
        {
            var listaMovimentacao = _Imovimentacao.ListarMovimentacao();
            if (listaMovimentacao != null)
            {
                return Json(await listaMovimentacao);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AdicionarMovimentacao")]
        public IActionResult AdicionarMovimentacao([FromBody] Movimentacao movimentacao)
        {
            return Json(_Imovimentacao.AdicionarMovimentacao(movimentacao));
        }
    }
}

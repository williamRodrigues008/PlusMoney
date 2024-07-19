using Microsoft.AspNetCore.Mvc;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;

namespace PlusMoney.API.Controllers
{
    [Route("api/[controller]")]
    public class PlusMoneyController : Controller
    {
        private readonly DbContexto _contextoDb;
        private readonly IMovimentacao _Imovimentacao;

        public PlusMoneyController(DbContexto contextoDb, IMovimentacao imovimentacao)
        {
            _contextoDb = contextoDb;
            _Imovimentacao = imovimentacao;
        }

        [HttpGet("GetMovimentacao")]
        public async Task<IActionResult> Index()
        {
            return Json( await _Imovimentacao.ListarMovimentacao());
        }
    }
}

using Desafio_TargetSistemas.Models;
using Desafio_TargetSistemas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_TargetSistemas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        private readonly JurosService _jurosService;

        public JurosController(JurosService jurosService)
        {
            _jurosService = jurosService;
        }

        [HttpPost("calcular")]
        public IActionResult CalcularJuros([FromBody] CalculoJurosRequest request)
        {
            if (request.ValorOriginal <= 0)
            {
                return BadRequest(new { mensagem = "O valor original deve ser maior que zero." });
            }

            var resultado = _jurosService.CalcularJuros(request);
            return Ok(resultado);
        }
    }
}
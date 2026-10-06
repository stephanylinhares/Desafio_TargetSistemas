using Microsoft.AspNetCore.Mvc;

namespace Desafio_TargetSistemas.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    public class ComissoesController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalcularComissoes()
        {
            return Ok(new { mensagem = "O controller de comissões está funcionando!" });
        }
    }
}
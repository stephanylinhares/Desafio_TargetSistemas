using Desafio_TargetSistemas.Services;
using Microsoft.AspNetCore.Mvc;
using Desafio_TargetSistemas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_TargetSistemas.Controllers;

    [ApiController]
    [Route("api/[controller]")]

    public class ComissoesController : ControllerBase
    {
        private readonly ComissaoService _comissaoService;

        public ComissoesController(ComissaoService comissaoService)
        {
            _comissaoService = comissaoService;
        }

        [HttpGet]
        public IActionResult ObterComissoes()
        {
            var resultado = _comissaoService.CalcularComissoes();
            return Ok(resultado);
        }
    }
using Desafio_TargetSistemas.Models;
using Desafio_TargetSistemas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_TargetSistemas.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EstoqueController : ControllerBase
	{
		private readonly EstoqueService _estoqueService;

		public EstoqueController(EstoqueService estoqueService)
		{
			_estoqueService = estoqueService;
		}
		[HttpGet]
		public IActionResult ObterEstoque()
		{
			return Ok(_estoqueService.ObterEstoqueAtual());
		}

		[HttpPost("movimentar")]
		public IActionResult MovimentarEstoque([FromBody] MovimentacaoRequest request)
		{
			try
			{
				var resultado = _estoqueService.ProcessarMovimentacao(request);
				return Ok(resultado);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(new { mensagem = ex.Message });
			}
			catch (Exception ex)
			{
				return BadRequest(new { mensagem = ex.Message });
			}
		}
	}
}
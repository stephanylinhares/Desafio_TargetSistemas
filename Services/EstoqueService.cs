using System.Text.Json;
using Desafio_TargetSistemas.Models;

namespace Desafio_TargetSistemas.Services
{
	public class EstoqueService
	{
		private readonly List<Produto> _produtos = new();

		public EstoqueService()
		{
			string caminhoJson = Path.Combine(Directory.GetCurrentDirectory(), "Data", "estoque.json");

			if (File.Exists(caminhoJson))
			{
				string jsonString = File.ReadAllText(caminhoJson);
				var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var dados = JsonSerializer.Deserialize<EstoqueResponse>(jsonString, opcoes);

				if (dados?.Estoque != null)
				{
					_produtos = dados.Estoque;
				}
			}
		}

		public List<Produto> ObterEstoqueAtual() => _produtos;

		public MovimentacaoRealizadaDTO ProcessarMovimentacao(MovimentacaoRequest request)
		{
			var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == request.CodigoProduto);

			if (produto == null)
			{
				throw new KeyNotFoundException($"Produto com código {request.CodigoProduto} não encontrado.");
			}

			if (request.Quantidade <= 0)
			{
				throw new ArgumentException("A quantidade movimentada deve ser maior que zero.");
			}

			if (request.Tipo == TipoMovimentacao.Entrada)
			{
				produto.Estoque += request.Quantidade;
			}
			else if (request.Tipo == TipoMovimentacao.Saida)
			{
				if (produto.Estoque < request.Quantidade)
				{
					throw new InvalidOperationException($"Estoque insuficiente. Estoque atual: {produto.Estoque}, tentativa de saída: {request.Quantidade}");
				}

				produto.Estoque -= request.Quantidade;
			}

			return new MovimentacaoRealizadaDTO
			{
				IdMovimentacao = Guid.NewGuid().ToString(),
				CodigoProduto = produto.CodigoProduto,
				DescricaoProduto = produto.DescricaoProduto,
				DescricaoMovimentacao = request.Descricao,
				Tipo = request.Tipo,
				QuantidadeMovimentada = request.Quantidade,
				EstoqueFinal = produto.Estoque
			};
		}
	}
}
using System.Text.Json;
using Desafio_TargetSistemas.Models;

namespace Desafio_TargetSistemas.Services
{
    public class ComissaoService
    {
        private readonly string _caminhoJson;

        public ComissaoService()
        {
            _caminhoJson = Path.Combine(Directory.GetCurrentDirectory(), "Data", "vendas.json");
        }

        public List<RelatorioComissaoDTO> CalcularComissoes()
        {
            if (!File.Exists(_caminhoJson))
            {
                throw new FileNotFoundException("O ficheiro vendas.json não foi encontrado na pasta Data.");
            }
            string jsonString = File.ReadAllText(_caminhoJson);

            var opcoesJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dados = JsonSerializer.Deserialize<VendasResponse>(jsonString, opcoesJson);

            if (dados == null || dados.Vendas == null)
            {
                return new List<RelatorioComissaoDTO>();
            }

            var relatorio = dados.Vendas
                .GroupBy(v => v.Vendedor)
                .Select(grupo => new RelatorioComissaoDTO
                {
                    Vendedor = grupo.Key,
                    TotalVendas = Math.Round(grupo.Sum(v => v.Valor), 2),
                    TotalComissao = Math.Round(grupo.Sum(v => CalcularComissaoItem(v.Valor)), 2)
                })
                .ToList();

            return relatorio;
        }
        private decimal CalcularComissaoItem(decimal valorVenda)
        {
            if (valorVenda < 100.00m)
            {
                return 0.00m;
            }
            else if (valorVenda < 500.00m)
            {
                return valorVenda * 0.01m;
            }
            else
            {
                return valorVenda * 0.05m;
            }
        }
    }
}
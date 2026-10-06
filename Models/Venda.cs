namespace Desafio_TargetSistemas.Models
{
    public class Venda
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }

    public class VendasResponse
    {
        public List<Venda> Vendas { get; set; } = new();
    }

    public class RelatorioComissaoDTO
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendas { get; set; }
        public decimal TotalComissao { get; set; }
    }
}
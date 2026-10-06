namespace Desafio_TargetSistemas.Models
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int Estoque { get; set; }
    }

    public class EstoqueResponse
    {
        public List<Produto> Estoque { get; set; } = new();
    }

    public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }

    public class MovimentacaoRequest
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }

    public class MovimentacaoRealizadaDTO
    {
        public string IdMovimentacao { get; set; } = Guid.NewGuid().ToString();
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public string DescricaoMovimentacao { get; set; } = string.Empty;
        public TipoMovimentacao Tipo { get; set; }
        public int QuantidadeMovimentada { get; set; }
        public int EstoqueFinal { get; set; }
    }
}
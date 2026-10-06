namespace Desafio_TargetSistemas.Models
{
    public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }
    
    public class MovimentacaoRequest
    {
        public int CodigoProduto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public string Descricao { get; set; }   
        public int Quantidade { get; set; }
    }
    public class MovimentacaoResponse
    {
        public string Id { get; set; }
        public int CodigoProduto { get; set; }  
        public int QuantidadeFinal{ get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}

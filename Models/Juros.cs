namespace Desafio_TargetSistemas.Models
{
    public class CalculoJurosRequest
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
    }

    public class CalculoJurosResponseDTO
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCalculo { get; set; } = DateTime.Today;
        public int DiasAtraso { get; set; }
        public decimal PercentualJurosDia { get; set; } = 2.5m;
        public decimal ValorJuros { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public string MensagemStatus { get; set; } = string.Empty;
    }
}
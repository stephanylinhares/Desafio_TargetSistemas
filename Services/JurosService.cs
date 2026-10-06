using Desafio_TargetSistemas.Models;

namespace Desafio_TargetSistemas.Services
{
    public class JurosService
    {
        public CalculoJurosResponseDTO CalcularJuros(CalculoJurosRequest request)
        {
            DateTime dataAtual = DateTime.Today;
            DateTime dataVencimento = request.DataVencimento.Date;

            if (dataVencimento >= dataAtual)
            {
                return new CalculoJurosResponseDTO
                {
                    ValorOriginal = request.ValorOriginal,
                    DataVencimento = dataVencimento,
                    DataCalculo = dataAtual,
                    DiasAtraso = 0,
                    ValorJuros = 0.00m,
                    ValorTotalComJuros = request.ValorOriginal,
                    MensagemStatus = "O título está em dia. Nenhum juro foi aplicado."
                };
            }

            int diasAtraso = (dataAtual - dataVencimento).Days;

            decimal taxaDiaria = 0.025m;
            decimal valorJuros = request.ValorOriginal * taxaDiaria * diasAtraso;
            decimal valorTotal = request.ValorOriginal + valorJuros;

            return new CalculoJurosResponseDTO
            {
                ValorOriginal = request.ValorOriginal,
                DataVencimento = dataVencimento,
                DataCalculo = dataAtual,
                DiasAtraso = diasAtraso,
                ValorJuros = Math.Round(valorJuros, 2),
                ValorTotalComJuros = Math.Round(valorTotal, 2),
                MensagemStatus = $"Título em atraso há {diasAtraso} dia(s). Juros de 2,5% ao dia aplicados."
            };
        }
    }
}
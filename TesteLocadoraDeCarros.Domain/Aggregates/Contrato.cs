using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Contrato
    {
        public Guid Id { get; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; private set; }
        public decimal TaxaTotal { get; private set; }
        public int QuantidadeCarros { get; private set; }
        public Aluguel Aluguel { get; private set; }

        public Contrato(Guid id, DateTime dataInicio, DateTime dataFim, int quantidadeCarros)
        {
            if (dataInicio == DateTime.MinValue) throw new ArgumentException("A data de início é obrigatória");
            if (dataFim <= dataInicio) throw new ArgumentException("A data de fim deve ser maior que a data de início");
            if (quantidadeCarros <= 0) throw new ArgumentException("A quantidade de carros deve ser maior que zero.");

            Id = id;
            DataInicio = dataInicio;
            DataFim = dataFim;
            TaxaTotal = 0;
            QuantidadeCarros = quantidadeCarros;
        }

        public Contrato()
        {
            
        }

        public void AssociarAluguel(Aluguel aluguel)
        {
            if (aluguel == null) throw new ArgumentNullException(nameof(aluguel), "O aluguel não pode ser nulo.");
            Aluguel = aluguel;
        }

        public void CalcularTaxaTotal(ICollection<Carro> carros)
        {
            decimal total = 0;
            foreach (var carro in carros)
            {
                total = total + carro.TaxaDiaria;
            }
            TaxaTotal = total * QuantidadeCarros; // Exemplo básico
        }

        // Métodos para atualizar propriedades alteráveis
        public void AtualizarDataFim(DateTime dataFim)
        {
            if (dataFim <= DataInicio) throw new ArgumentException("A data de fim deve ser maior que a data de início");
            DataFim = dataFim;
        }

        public void AtualizarQuantidadeCarros(int quantidade)
        {
            if (quantidade <= 0) throw new ArgumentException("A quantidade de carros deve ser maior que zero");
            QuantidadeCarros = quantidade;
        }
    }
}

using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Validators.CarroValidators;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Carro
    {
        public Guid Id { get; set;  }
        public string Marca { get; set;  }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; } 
        public decimal TaxaDiaria { get; set; }
        public decimal TaxaAtraso { get; set; }
        public ICollection<Aluguel> Alugueis { get; set; }

        public Carro(Guid id, string marca, string modelo, int ano, bool disponivel, decimal taxaDiaria, decimal taxaAtraso)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Disponivel = disponivel;
            TaxaDiaria = taxaDiaria;
            TaxaAtraso = taxaAtraso;
            Alugueis = new List<Aluguel>();
        }

        public Carro()
        {        }
        public void Alugar() // Seta o status de Disponivel pra false
        {
            if (!Disponivel)
            {
                throw new InvalidOperationException("Este carro não está disponível para alugar");
            }
            Disponivel = false;
        }

        public void Devolver() // Seta o status de Disponível para true
        {
            Disponivel = true;
        }

        public void AdicionarAluguel(Aluguel aluguel)
        {
            if (aluguel == null) throw new ArgumentNullException(nameof(aluguel), "O aluguel não pode ser nulo.");
            Alugueis.Add(aluguel);
        }

    }
}

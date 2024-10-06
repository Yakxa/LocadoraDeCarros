using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Carro
    {
        public Guid Id { get; }
        public string Marca { get; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; } // Disponivel para aluguel ou não
        public decimal TaxaDiaria { get; set; }
        public decimal TaxaAtraso { get; set; }
        public ICollection<Aluguel> Alugueis { get; set; }

        public Carro(Guid id, string marca, string modelo, int ano, bool disponivel, decimal taxaDiaria, decimal taxaAtraso)
        {
            if (string.IsNullOrEmpty(marca)) throw new ArgumentException("Marca é obrigatória");
            if (string.IsNullOrEmpty(modelo)) throw new ArgumentException("Modelo é obrigatório");
            if (ano < 1886 || ano > DateTime.Now.Year) throw new ArgumentException("Ano inválido");
            if (taxaDiaria < 0) throw new ArgumentException("Taxa diária deve ser maior ou igual a zero");
            if (taxaAtraso < 0) throw new ArgumentException("Taxa de atraso deve ser maior ou igual a zero");

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

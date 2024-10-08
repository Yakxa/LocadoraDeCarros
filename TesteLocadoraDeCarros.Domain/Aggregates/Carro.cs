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
        private Carro()
        { }
        private readonly List<Aluguel> _alugueis = new List<Aluguel>();
        public Guid Id { get; private set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; }
        public decimal TaxaDiaria { get; set; }
        public decimal TaxaAtraso { get; set; }
        public IEnumerable<Aluguel> Alugueis { get { return _alugueis; } }

        // Método de fabricação do carro
        public static Carro CreateCarro(string marca, string modelo, int ano, decimal taxaDiaria, decimal taxaAtraso)
        {
            return new Carro
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Disponivel = true,
                TaxaDiaria = taxaDiaria,
                TaxaAtraso = taxaAtraso,
            };

        }



        // Métodos públicos
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
            if (Disponivel)
            {
                throw new InvalidOperationException("O carro já está disponível.");
            }
            Disponivel = true;
        }

        public void AdicionarAluguel(Aluguel aluguel)
        {
            if (aluguel == null) throw new ArgumentNullException(nameof(aluguel), "O aluguel não pode ser nulo.");
            _alugueis.Add(aluguel);
        }

        public void RemoveAluguel(Aluguel aluguel)
        {
            _alugueis.Remove(aluguel);
        }

        public bool VerificarDisponibilidade()
        {
            return Disponivel;
        }

        public void UpdateMarca(string novaMarca)
        {
            Marca = novaMarca;

        }

        public void UpdateModelo(string novoModelo)
        {
            Modelo = novoModelo;
        }

        public void UpdateAno(int ano)
        {
            Ano = ano;
        }

        public void UpdateTaxaDiaria(decimal novaTaxaD)
        {
            TaxaDiaria = novaTaxaD;
        }

        public void UpdateTaxaAtraso(decimal novaTaxaA)
        {
            TaxaAtraso = novaTaxaA;
        }
    }
}

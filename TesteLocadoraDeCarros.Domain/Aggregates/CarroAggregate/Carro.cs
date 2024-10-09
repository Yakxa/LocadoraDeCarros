using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;
using TesteLocadoraDeCarros.Domain.Validators.CarroValidators;

namespace TesteLocadoraDeCarros.Domain.Aggregates.CarroAggregate
{
    public class Carro
    {
        private Carro()
        { }
        private readonly List<CarroAluguel> _alugueis = new List<CarroAluguel>();
        public Guid Id { get; private set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public StatusCarro Status { get; set; }
        public decimal TaxaDiaria { get; set; }
        public decimal TaxaAtraso { get; set; }
        public IEnumerable<CarroAluguel> Alugueis { get { return _alugueis; } }

        // Método de fabricação do carro
        public static Carro CreateCarro(string marca, string modelo, int ano, decimal taxaDiaria, decimal taxaAtraso)
        {
            return new Carro
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Status = StatusCarro.Disponivel,
                TaxaDiaria = taxaDiaria,
                TaxaAtraso = taxaAtraso,
            };

        }



        // Métodos públicos
        public void Alugar(Guid userId, DateTime dataInicio, DateTime dataFim) // Seta o status de Disponivel pra false
        {
            if (Status != StatusCarro.Disponivel)
            {
                throw new InvalidOperationException("O carro não está disponível para aluguel.");
            }
            var aluguel = CarroAluguel.CriarAluguel(Id, userId, dataInicio, dataFim, TaxaDiaria);
            _alugueis.Add(aluguel);

            Status = StatusCarro.Alugado;
        }

        public void Devolver(Guid aluguelId)
        {
            if (Status != StatusCarro.Alugado)
            {
                throw new InvalidOperationException("O carro não está alugado.");
            }

            // Encontra o aluguel correspondente e marca como finalizado
            var aluguel = _alugueis.Find(a => a.AluguelId == aluguelId);
            if (aluguel == null)
            {
                throw new InvalidOperationException("Aluguel não encontrado.");
            }

            aluguel.MarcarComoFinalizado();

            // Atualiza o status do carro para "Disponível" após a devolução
            Status = StatusCarro.Disponivel;
        }

        public StatusCarro ObterStatusAtual()
        {
            return Status;
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

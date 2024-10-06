using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Enums;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Aluguel
    {
        public Guid Id { get; set; }
        public Guid ContratoId { get; set; }
        public Guid ClienteId { get; set; }
        public StatusAluguel Status {  get; set; }

        public Cliente Cliente { get; set; }
        public Contrato Contrato { get; set; }
        public ICollection<Carro> Carros { get; set; }

        public Aluguel(Guid id, Guid contratoId, Guid clienteId)
        {
            if (clienteId == Guid.Empty) throw new ArgumentException("O ID do cliente é obrigatório");
            if (contratoId == Guid.Empty) throw new ArgumentException("O ID do contrato é obrigatório");

            Id = id;
            ContratoId = contratoId;
            ClienteId = clienteId;
            Status = StatusAluguel.EmAndamento;
            Carros = new List<Carro>();
        }

        public Aluguel()
        {
            
        }

        public void AdicionarCarros(Carro carro)
        {
            if (!carro.Disponivel)
            {
                throw new InvalidOperationException("O carro não está disponível para aluguel.");
            }
            Carros.Add(carro);
            carro.AdicionarAluguel(this);
        }

        public void Finalizar()
        {
            Status = StatusAluguel.Finalizado;
        }

        public void Cancelar()
        {
            Status = StatusAluguel.Cancelado;
        }

    }
}

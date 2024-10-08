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
        private Aluguel()
        { }
        public Guid Id { get; set; }
        public StatusAluguel Status {  get; set; }

        public Cliente Cliente { get; set; }
        public Carro Carro { get; private set; }

        public static Aluguel CreateAluguel(Cliente cliente, Carro carro)
        {
            return new Aluguel
            {
                Cliente = cliente,
                Carro = carro,
                Status = StatusAluguel.EmAndamento
            };

        }

        public void Finalizar()
        {
            Status = StatusAluguel.Finalizado;
        }

        public void Cancelar()
        {
            Status = StatusAluguel.Cancelado;
        }

        public void UpdateAluguel(Guid? clienteId = null, Guid? carroId = null)
        {
            if (clienteId.HasValue)
            {
                ClienteId = clienteId.Value;
            }

            if (carroId.HasValue)
            {
                CarroId = carroId.Value;
            }
        }
    }
}

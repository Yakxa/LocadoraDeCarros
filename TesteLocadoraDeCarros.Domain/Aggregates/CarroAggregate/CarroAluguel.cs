using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Domain.Aggregates.CarroAggregate
{
    public class CarroAluguel
    {
        private CarroAluguel()
        {

        }
        public Guid AluguelId { get; private set; }
        public Guid CarroId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool AluguelFinalizado { get; private set; }

        public static CarroAluguel CriarAluguel(Guid carroId, Guid userProfileId, DateTime dataInicio, DateTime dataFim, decimal taxaDiaria)
        {
            var aluguel =  new CarroAluguel
            {
                CarroId = carroId,
                UserProfileId = userProfileId,
                DataInicio = dataInicio,
                DataFim = dataFim,
            };

            aluguel.ValorTotal = aluguel.CalcularValorTotal(taxaDiaria);
            return aluguel;
        }



        private decimal CalcularValorTotal(decimal taxaDiaria)
        {
            var diasAlugados = (DataFim - DataInicio).Days;
            return diasAlugados * taxaDiaria;
        }

        public void MarcarComoFinalizado()
        {
            if (AluguelFinalizado)
            {
                throw new InvalidOperationException("Este aluguel já está finalizado.");
            }

            AluguelFinalizado = true;
        }
    }
}

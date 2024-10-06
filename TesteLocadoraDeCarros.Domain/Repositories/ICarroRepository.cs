using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates;

namespace TesteLocadoraDeCarros.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetAllCarrosAsync();
        Task<Carro> GetCarroByIdAsync(Guid id);
        Task<IEnumerable<Carro>> GetCarrosDisponiveisAsync();
        Task<IEnumerable<Carro>> GetCarrosAlugadosAsync();
        Task AddCarroAsync(Carro carro);
        Task UpdateCarroAsync(Carro carro);
        Task DeleteCarroAsync(Guid id);
    }
}

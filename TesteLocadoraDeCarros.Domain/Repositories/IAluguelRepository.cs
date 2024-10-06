using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates;

namespace TesteLocadoraDeCarros.Domain.Repositories
{
    public interface IAluguelRepository
    {
        Task<IEnumerable<Aluguel>> GetAllAlugueisAsync();
        Task<Aluguel> GetAluguelByIdAsync(Guid id);
        Task AddAluguelAsync(Aluguel aluguel);
        Task UpdateAluguelAsync(Aluguel aluguel);
        Task DeleteAlugueAsync(Guid id);
    }
}

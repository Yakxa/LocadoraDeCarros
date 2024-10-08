using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteLocadoraDeCarros.Dal;
using TesteLocadoraDeCarros.Domain.Aggregates;
using TesteLocadoraDeCarros.Domain.Validators.CarroValidators;


namespace TesteLocadoraDeCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : Controller
    {
        private readonly DataContext _context;

        public CarroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAllCarrosAsync()
        {
            return await _context.Carros
                .ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Carro>> GetCarroById(Guid id)
        {
            return await _context.Carros.FindAsync(id);
        }

        [HttpGet]
        [Route("marca/{marca}")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarrosByMarcaAsync(string marca)
        {
            return await _context.Carros
                .Where(m => m.Marca == marca)
                .ToListAsync();
        }

        [HttpGet("disponiveis")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarrosDisponiveisAsync()
        {
            return await _context.Carros
                .Where(c => c.Disponivel)
                .ToListAsync();
        }

        [HttpGet("alugados")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarrosAlugadosAsync()
        {
            return await _context.Carros
                .Where(c => !c.Disponivel)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddCarroAsync([FromBody] Carro carro)
        {
            try
            {
                CarroValidator.ValidateCarro(carro);

                await _context.AddAsync(carro);
                await _context.SaveChangesAsync();

                return Ok(carro); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarro(Guid id, [FromBody] Carro carro)
        {
            carro.Id = id;
            try
            {
                CarroValidator.ValidateCarro(carro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }

            var carroExistente = await _context.Carros.FindAsync(id);
            if (carroExistente == null)
            {
                return NotFound("Carro não encontrado.");
            }

            // Atualiza as propriedades do carro existente
            carroExistente.Marca = carro.Marca;
            carroExistente.Modelo = carro.Modelo;
            carroExistente.Ano = carro.Ano;
            carroExistente.Disponivel = carro.Disponivel; 
            carroExistente.TaxaDiaria = carro.TaxaDiaria;
            carroExistente.TaxaAtraso = carro.TaxaAtraso;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarro(Guid id)
        {
            
            var carroExistente = await _context.Carros.FindAsync(id);
            if (carroExistente == null)
            {
                return NotFound(); 
            }

            
            _context.Carros.Remove(carroExistente);

            await _context.SaveChangesAsync();

            return NoContent(); 
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using TesteLocadoraDeCarros.Domain.Models;

namespace TesteLocadoraDeCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var carro = new Carro {
                Id = id,
                Marca = "Fiat",
                Modelo = "Uno", 
                Ano = 2005, 
                Disponivel = true };
            return Ok(carro);
        }

    }
}

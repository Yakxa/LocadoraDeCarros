using Microsoft.AspNetCore.Mvc;
using TesteLocadoraDeCarros.Domain.Aggregates;


namespace TesteLocadoraDeCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : Controller
    {
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var carro = new Carro
        //    {
        //        Id = id,
        //        Marca = null,
        //        Modelo = null,
        //        Ano = 2005,
        //        Disponivel = true,
        //        TaxaDiaria = 1.60M,
        //        TaxaAtraso = 3.90M
        //    };
        //    return Ok(carro);
        //}

    }
}
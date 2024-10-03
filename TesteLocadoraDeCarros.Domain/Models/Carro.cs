using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; } 
        public string Modelo { get; set; } 
        public int Ano { get; set; } 
        public bool Disponivel { get; set; } // Disponivel para aluguel ou não
    }
}

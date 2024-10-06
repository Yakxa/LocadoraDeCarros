using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Cliente
    {
        public Guid Id { get; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public ICollection<Aluguel> Alugueis { get; private set; }

        public Cliente(Guid id, string nome, string documento)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome é obrigatório");
            if (string.IsNullOrEmpty(documento)) throw new ArgumentException("Documento é obrigatório");

            Id = id;
            Nome = nome;
            Documento = documento;
            Alugueis = new List<Aluguel>();
        }

        public Cliente()
        {
            
        }

        public void AtualizarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome é obrigatório");
            Nome = nome;
        }

        public void AtualizarDocumento(string documento)
        { 
            if (string.IsNullOrEmpty(documento)) throw new ArgumentException("Documento é obrigatório");
            Documento = documento;
        }

        public void AdicionarAluguel(Aluguel aluguel)
        {
            Alugueis.Add(aluguel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Aggregates
{
    public class Cliente
    {
        private readonly List<Aluguel> _alugueis = new List<Aluguel>();
        private Cliente()
        {

        }
        public Guid Id { get; private set; }
        public string IdentityId { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Documento { get; private set; }
        public IEnumerable<Aluguel> Alugueis { get { return _alugueis; } }

        // Método de fabricação do cliente
        public static Cliente CreateCliente(string identityId, string nome, int idade, string documento)
        {
            return new Cliente
            {
                IdentityId = identityId,
                Nome = nome,
                Idade = idade,
                Documento = documento,
            };
            
        }



        // Métodos públicos
        public void AdicionarAluguel(Aluguel aluguel)
        {
            if (aluguel == null) throw new ArgumentNullException(nameof(aluguel), "O aluguel não pode ser nulo.");
            _alugueis.Add(aluguel);
        }

        public void RemoverAluguel(Aluguel aluguel)
        {
            _alugueis.Remove(aluguel);
        }

        public void UpdateIdade(int novaIdade)
        {
            Idade = novaIdade;
        }
        

        public void UpdateNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome é obrigatório");
            Nome = nome;
        }

        public void UpdateDocumento(string documento)
        { 
            if (string.IsNullOrEmpty(documento)) throw new ArgumentException("Documento é obrigatório");
            Documento = documento;
        }
    }
}

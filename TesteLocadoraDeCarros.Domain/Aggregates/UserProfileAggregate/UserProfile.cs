using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile()
        {

        }
        public Guid Id { get; private set; }
        public string IdentityId { get; private set; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }

        // Método de fabricação do cliente
        public static UserProfile CreateCliente(string identityId, string nome, string documento)
        {
            return new UserProfile
            {
                IdentityId = identityId,
                Nome = nome,
                Documento = documento,
            };

        }

        // Métodos públicos
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

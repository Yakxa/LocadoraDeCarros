using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates;

namespace TesteLocadoraDeCarros.Domain.Validators.CarroValidators
{
    public class CarroValidator : AbstractValidator<Carro>
    {
        // Criando o perfil e regras para validar a adição/atualização de um Carro
        public CarroValidator()
        {
            RuleFor(c => c.Marca).NotEmpty().NotNull().MinimumLength(4).WithMessage("A marca deve ter pelo menos 4 caracteres");
            RuleFor(c => c.Modelo).NotEmpty().NotNull().MinimumLength(2).WithMessage("O modelo deve ter pelo menos 3 caracteres");
            RuleFor(c => c.Ano).GreaterThanOrEqualTo(1886).WithMessage("O ano deve ser maior que 1886");
            
            // Regra de disponibilidade para QUANDO for atualizar o carro
            RuleFor(c => c.Disponivel)
                .Must((carro, disponibilidade) =>
                    disponibilidade == true || disponibilidade == false)
                .WithMessage("A disponibilidade deve ser true ou false ao atualizar.")
                .When(carro => carro.Id != Guid.Empty);

            RuleFor(c => c.TaxaDiaria).GreaterThan(0).WithMessage("A taxa diária deve ser maior que zero");
            RuleFor(c => c.TaxaAtraso).GreaterThan(0).WithMessage("A taxa de atraso deve ser maior que zero");
        }

        // Criando o método para validar o Carro e ser chamado em outros lugares
        public static void ValidateCarro(Carro carro)
        {
            var validator = new CarroValidator();
            var validationResult = validator.Validate(carro);

            if(!validationResult.IsValid)
            {
                
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));

                // Lança uma exceção genérica com a mensagem de erro.
                throw new Exception($"Erro de validação: {errorMessage}");
            }
        }
    }
}

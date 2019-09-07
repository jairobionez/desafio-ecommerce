using FluentValidation.Results;
using MediatR;

namespace DesafioEcommerce.Domain.Interfaces
{
    public interface ICommand
    {
        ValidationResult Valdiate();
    }
}
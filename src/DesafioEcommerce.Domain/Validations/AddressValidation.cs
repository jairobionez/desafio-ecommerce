using DesafioEcommerce.Domain.ValueObjects;
using FluentValidation;

namespace DesafioEcommerce.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {

        }
    }
}

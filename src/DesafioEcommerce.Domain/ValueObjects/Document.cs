using DesafioEcommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentTypeEnum type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        
        public EDocumentTypeEnum Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentTypeEnum.CNPJ && Number.Length == 14)
                return true;

            if (Type == EDocumentTypeEnum.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}

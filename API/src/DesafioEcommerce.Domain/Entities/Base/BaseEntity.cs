using DesafioEcommerce.Domain.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}

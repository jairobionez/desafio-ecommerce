using DesafioEcommerce.Domain.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Entities
{
    public abstract class BaseEntity : Notifiable
    {
        public int Id { get; set; }

        public void AddNotifications(List<ValidationFailure> errors)
        {
            if(HasNotifications())
                errors.ForEach(p =>
                {
                    AddNotification(p.PropertyName, p.ErrorMessage);
                });
        }
    }
}

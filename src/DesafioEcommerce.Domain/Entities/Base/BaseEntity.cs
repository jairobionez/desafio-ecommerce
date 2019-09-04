using DesafioEcommerce.Domain.Notifications;

namespace DesafioEcommerce.Domain.Entities
{
    public abstract class BaseEntity : Notifiable
    {
        public int Id { get; set; }
    }
}

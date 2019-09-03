using DesafioEcommerce.Domain.Notifications;
using System.Collections.Generic;

namespace DesafioEcommerce.Domain.Interfaces
{
    public interface INotifiable
    {
        List<Notification> GetNotifications();
        bool HasNotifications();
        void AddNotification(string property, string value);
        void AddNotifications(List<Notification> notifications);
    }
}

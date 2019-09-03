using DesafioEcommerce.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEcommerce.Domain.Notifications
{
    public class Notifiable : INotifiable
    {
        private List<Notification> _notifications;

        public Notifiable()
        {
            _notifications = new List<Notification>();
        }

        public virtual void AddNotification(string property, string value)
        {
            this._notifications.Add(new Notification(property, value));
        }

        public virtual void AddNotifications(List<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public virtual List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}

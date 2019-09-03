using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEcommerce.Application.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifiable _notifications;

        public BaseController(INotifiable notifications)
        {
            _notifications = notifications;
        }

        protected IEnumerable<Notification> Notifications => _notifications.GetNotifications();

        protected bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }

        protected IActionResult Response(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,                
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}

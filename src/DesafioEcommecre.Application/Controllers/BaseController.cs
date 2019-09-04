using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEcommerce.Application.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifiable _notifications;
        private readonly IUnitOfWork _uow;

        public BaseController(INotifiable notifications, IUnitOfWork uow)
        {
            _notifications = notifications;
            _uow = uow;
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

        protected IActionResult TransactionResponse(object result = null)
        {
            if (IsValid())
            {
                _uow.Commit();

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

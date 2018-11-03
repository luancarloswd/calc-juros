using CalcTest.Crosscutting.Interfaces;
using CalcTest.Crosscutting.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalcTest.API.Controllers.Base
{
    public abstract class ApiController : ControllerBase
    {
        private readonly IDomainNotificationManager _domainNotificationManager;

        protected ApiController(IDomainNotificationManager domainNotificationManager)
            => _domainNotificationManager = domainNotificationManager;

        protected IEnumerable<DomainNotification> Notifications => _domainNotificationManager.GetNotifications();

        protected bool IsValidOperation()
            => (!_domainNotificationManager.HasNotifications());

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                data = result,
                errors = _domainNotificationManager.GetNotifications()
            });
        }

        protected void NotifyModelStateErrors()
        {
            foreach (var ms in ModelState)
                foreach (var erro in ms.Value.Errors)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    NotifyError(ms.Key, erroMsg);
                }
        }

        protected void NotifyError(string code, string message)
            => _domainNotificationManager.Add(code, message);
    }
}

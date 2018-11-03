using CalcTest.Crosscutting.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalcTest.Crosscutting.Notifications
{
    public class DomainNotificationManager : IDomainNotificationManager
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationManager()
            => _notifications = new List<DomainNotification>();

        public virtual List<DomainNotification> GetNotifications()
            => _notifications;

        public virtual bool HasNotifications()
            => GetNotifications().Any();

        public void Dispose()
            => _notifications = new List<DomainNotification>();

        public void Add(string key, string value)
            => _notifications.Add(new DomainNotification(key, value));
    }
}

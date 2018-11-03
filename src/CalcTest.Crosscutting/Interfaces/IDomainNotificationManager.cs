using CalcTest.Crosscutting.Notifications;
using System;
using System.Collections.Generic;

namespace CalcTest.Crosscutting.Interfaces
{
    public interface IDomainNotificationManager : IDisposable
    {
        List<DomainNotification> GetNotifications();
        bool HasNotifications();
        void Add(string key, string value);
    }
}

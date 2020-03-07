using System;

namespace MediatorPattern
{
    /* 
     Act as a central hub for communication between different Colleagues.
     Notifies all Concrete Colleagues on the occurrence of an event
    */
    public class NetworkMediator : IMediator
    {
        public event EventHandler<ColleagueArgs> RegisterNotification = delegate { };
        public event EventHandler<ColleagueArgs> UnRegisterNotification = delegate { };

        public void Register(IColleague colleague)
        {
            RegisterNotification(this, new ColleagueArgs(colleague));
            RegisterNotification += colleague.ReceiveRegisterNotification;
            UnRegisterNotification += colleague.ReceiveUnRegisterNotification;
        }
        public void Unregister(IColleague colleague)
        {
            RegisterNotification -= colleague.ReceiveRegisterNotification;
            UnRegisterNotification -= colleague.ReceiveUnRegisterNotification;
            UnRegisterNotification(this, new ColleagueArgs(colleague));
        }
    }
}
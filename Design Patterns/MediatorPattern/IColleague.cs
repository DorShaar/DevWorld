namespace MediatorPattern
{
    public interface IColleague
    {
        string Name { get; }
        void ReceiveRegisterNotification(object sender, ColleagueArgs colleagueArgs);
        void ReceiveUnRegisterNotification(object sender, ColleagueArgs colleagueArgs);
    }
}
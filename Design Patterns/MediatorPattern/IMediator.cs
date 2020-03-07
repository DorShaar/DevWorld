namespace MediatorPattern
{
    public interface IMediator
    {
        void Register(IColleague colleague);
        void Unregister(IColleague colleague);
    }
}
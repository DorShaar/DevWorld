using System;

namespace MediatorPattern
{
    public class ColleagueArgs : EventArgs
    {
        public ColleagueArgs(IColleague colleague)
        {
            Colleague = colleague;
        }

        public IColleague Colleague { get; }
    }
}
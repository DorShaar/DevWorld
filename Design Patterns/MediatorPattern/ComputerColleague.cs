using System;

namespace MediatorPattern
{
    public class ComputerColleague : IColleague
    {
        public string Name { get; }

        public ComputerColleague(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Send further messages to this new Colleague from now onwards
        /// </summary>
        public void ReceiveRegisterNotification(object sender, ColleagueArgs colleagueArgs)
        {
            Console.WriteLine("New Computer register event with name:"
                + colleagueArgs.Colleague + ": received @" + this);
        }

        /// <summary>
        /// Do not send further messages to this Colleague from now onwards
        /// </summary>
        public void ReceiveUnRegisterNotification(object sender, ColleagueArgs colleagueArgs)
        {
            Console.WriteLine("Computer left unregister event with name:"
                + colleagueArgs.Colleague + ":received @" + this);
            
        }
    }
}
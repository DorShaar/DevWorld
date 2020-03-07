using System;

namespace MediatorPattern
{
    /*
     What Is Mediator Pattern?

     The Mediator pattern in C# enables objects to communicate, 
     without knowing each other’s identities. It also encapsulates a protocol 
     that objects can follow.

     You can think of a Mediator object as a kind of a coordinator;
     that handles traffic between appropriate parties based on its own logic.

    Mediator promotes loose coupling by keeping objects from referring to each 
    other explicitly, and it lets you vary their interaction independently.

    */

    /*
     You are maintaining a network of computers in Mesh topology.
     A mesh network is a network topology in which each node relays data for 
     the network. All mesh nodes cooperate in the distribution of data in the network.
     If a new computer is added or an existing computer is removed, 
     all other computers in that network should know about these two events.
    */

    public class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new NetworkMediator();
            ComputerColleague colleague1 = new ComputerColleague("Eagle");
            ComputerColleague colleague2 = new ComputerColleague("Ostrich");
            ComputerColleague colleague3 = new ComputerColleague("Penguin");
            mediator.Register(colleague1);
            mediator.Register(colleague2);
            mediator.Register(colleague3);
            mediator.Unregister(colleague1);
            Console.ReadLine();
        }
    }
}
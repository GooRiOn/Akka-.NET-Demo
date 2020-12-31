using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaDemo.Actors;

namespace AkkaDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var system = ActorSystem.Create("System");

            var printerActor = system.ActorOf<PrinterActor>("printer");
            
            var response = await printerActor.Ask("Hello world!");
            
            var response1 = await printerActor.Ask(new object());

            var genericActor = system.ActorOf<GenericActor>("GenericActor");
            
            // genericActor.Tell("test");
            // genericActor.Tell(2137);
            
            var root = system.ActorOf<RootActor>("RootActor");
            root.Tell("create_child");
            root.Tell("tell_child");
            root.Tell("tell_child");
            root.Tell("tell_child");
            root.Tell("tell_child");
            root.Tell("tell_child");

            Console.ReadLine();
        }
    }
}
using System;
using Akka.Actor;

namespace AkkaDemo.Actors
{
    public class GenericActor : ReceiveActor
    {
        public GenericActor()
        {
            Receive<string>(Console.WriteLine);
            Receive<int>(m => Console.WriteLine($"Got number: {m}"));
        }
    }
}
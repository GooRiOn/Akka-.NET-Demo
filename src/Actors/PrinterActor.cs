using System;
using Akka.Actor;

namespace AkkaDemo.Actors
{
    public class PrinterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message is not null and string)
            {
                Console.WriteLine(message);
                Sender.Tell(null);
                return;
            }
            
            Sender.Tell("nice");
        }

        public string GetPrintMessage()
            => "Hello!";
    }
}
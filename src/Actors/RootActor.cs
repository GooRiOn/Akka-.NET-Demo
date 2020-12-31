using System;
using Akka.Actor;

namespace AkkaDemo.Actors
{
    public class RootActor : UntypedActor
    {
        private IActorRef _child;
        
        protected override void OnReceive(object message)
        {
            if (message is "create_child")
            {
                _child = Context.ActorOf<ChildActor>(Guid.NewGuid().ToString());
                Console.WriteLine($"Created child actor: {_child.Path}");
            }
            else if (message is "tell_child")
            {
                _child.Tell(Guid.NewGuid().ToString());
            }
        }

        protected override SupervisorStrategy SupervisorStrategy()
            => new OneForOneStrategy(20, TimeSpan.FromMinutes(1), ex => ex switch
            {
                NullReferenceException => GetDirective(),
                _ => Directive.Stop
            });
        
        protected override void PreStart()
        {
            Console.WriteLine("Root started");
        }

        protected override void PostStop()
        {
            Console.WriteLine("Root stopped");
        }

        private static Directive GetDirective()
        {
            Console.WriteLine("Got directive");
            return Directive.Restart;
        }
    }
}
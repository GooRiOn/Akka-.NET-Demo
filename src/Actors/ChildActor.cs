using System;
using System.Collections.Generic;
using Akka.Actor;

namespace AkkaDemo.Actors
{
    public class ChildActor : UntypedActor
    {
        private int _counter = 1;
        private readonly List<string> _ids = new();
        
        protected override void OnReceive(object message)
        {
            _counter++;

            if (_counter % 3 is 0)
            {
                throw new NullReferenceException();
            }

            if (message is string id)
            {
                _ids.Add(id);
            }
        }

        protected override void PreStart()
        {
            Console.WriteLine("Child started");
        }

        protected override void PostStop()
        {
            Console.WriteLine("Child stopped");
        }
    }
}
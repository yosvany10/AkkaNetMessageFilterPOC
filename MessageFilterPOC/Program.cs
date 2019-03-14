using System;
using System.Collections.Generic;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using Shared.Actors;
using Shared.Messages;

namespace MessageFilterPOC
{
    class Program
    {
        static void Main(string[] args)
        {
			var config = ConfigurationFactory.ParseString(File.ReadAllText("MessageFilter.hocon"));
			var system = ActorSystem.Create("MessageFilterSystem", config);
			IActorRef BucketCeo = system.ActorOf(Props.Create<MessageBucketCEOActor>(), "BucketCEO");

			List<string> randoms = new List<string>();
			

			for (int i =0; i < 100; i++)
			{
				Random r = new Random();
				int rInt = r.Next(0, 3);
				randoms.Add(rInt.ToString());
			}

			Console.ReadLine();
			for (int i = 0; i < randoms.Count; i++)
			{
				
				BucketCeo.Tell(new StringMessage(randoms[i]));
			}


			Console.ReadLine();
			system.Terminate();
			system.WhenTerminated.Wait();
        }
    }
}

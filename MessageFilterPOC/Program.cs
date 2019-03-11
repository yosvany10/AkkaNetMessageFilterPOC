using System;
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

			IActorRef bucketRef = system.ActorOf(Props.Create<MessageBucketActor>().WithRouter(FromConfig.Instance), "bucket");

			string input;

			while (true)
			{
				input = Console.ReadLine();
				bucketRef.Tell(new StringMessage(input));
			}


			system.WhenTerminated.Wait();
        }
    }
}

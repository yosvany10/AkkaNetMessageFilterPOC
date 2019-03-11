using System;
using Akka.Actor;
using Akka.Configuration;
using System.IO;
using Shared.Actors;
using Shared.Messages;

namespace EmptyActorSystem
{
    public class EmptyServer
    {
		static void Main(string[] args)
		{
			var config = ConfigurationFactory.ParseString(File.ReadAllText("EmptyServer.hocon"));
			var system = ActorSystem.Create("MessageFilterSystem", config);
			
			system.WhenTerminated.Wait();
		}
    }
}

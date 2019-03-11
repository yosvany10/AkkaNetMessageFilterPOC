using Akka.Actor;
using Shared.Messages;
using System;
using System.Collections.Generic;

namespace Shared.Actors
{
	public class MessageBucketActor : ReceiveActor
	{

		private List<string> MyMessages { get; set; }

		public MessageBucketActor()
		{
			MyMessages = new List<string>();
			Receive<StringMessage>(message => {
				MyMessages.Add(message.MyMessage);
				Console.WriteLine("Received message");
			});
		}

		protected override void PreStart()
		{
			ColorConsole.PrintLine("Message Bucket Actor created!", ConsoleColor.Green);
		}
	}
}
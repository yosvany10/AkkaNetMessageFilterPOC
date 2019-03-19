using Akka.Actor;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Actors
{
    public class MessageBucketController : ReceiveActor
    {
		List<StringMessage> myMessages;

		public MessageBucketController()
		{
			myMessages = new List<StringMessage>();

			Receive<StringMessage>(message => HandleStringMessage(message));
		}

		private void HandleStringMessage(StringMessage message)
		{
			Console.WriteLine(message);
			myMessages.Add(message);
		}

		protected override void PreStart()
		{
			Console.WriteLine("Starting Controller");
		}
	}
}

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

			Become(AcceptingNew);
		}

		private void AcceptingNew()
		{
			Receive<CheckAvailable>(message => {
				Become(NotAcceptingNew);
				Sender.Tell(new AmAvailable(message.Key));
			});
		}

		private void NotAcceptingNew()
		{

			Receive<CheckAvailable>(message => {
				//Console.WriteLine("I am in use");
				Sender.Tell(new IAmInUseMessage());
			});

			Receive<StringMessage>(message => {
				Console.WriteLine(message);
				myMessages.Add(message);
			});

		}

		protected override void PreStart()
		{
			Console.WriteLine("Starting Controller");
		}
	}
}

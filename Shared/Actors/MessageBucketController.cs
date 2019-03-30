using Akka.Actor;
using Akka.Persistence;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Actors
{
    public class MessageBucketController : ReceivePersistentActor
    {
		List<StringMessage> myMessages;

		public override string PersistenceId => Self.Path.Parent.Name + "_" + Self.Path.Name;

		public MessageBucketController()
		{
			myMessages = new List<StringMessage>();
			Recover<StringMessage>(message => {
				Console.WriteLine("Recovering message: " + message);
				myMessages.Add(message);
			});
			Command<StringMessage>(message => Persist(message, mymessage => HandleStringMessage(mymessage)));
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

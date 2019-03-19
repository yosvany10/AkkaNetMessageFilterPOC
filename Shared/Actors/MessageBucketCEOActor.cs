using Akka.Actor;
using Akka.Routing;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Actors
{
    public class MessageBucketCEOActor: ReceiveActor
    {
		private IActorRef MyShard;

		public MessageBucketCEOActor(IActorRef PassedInShard)
		{
			MyShard = PassedInShard;
			Receive<StringMessage>(message => HandleStringMessage(message));
		}

		private void HandleStringMessage(StringMessage message)
		{
			MyShard.Tell(new StringMessageShardEnvelope(parseKey(message), message));
		}

		private string parseKey(StringMessage message)
		{
			return message.MyMessage.Split()[0];
		}
	}
}

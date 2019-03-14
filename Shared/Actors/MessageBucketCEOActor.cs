using Akka.Actor;
using Akka.Routing;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Actors
{
    public class MessageBucketCEOActor: ReceiveActor, IWithUnboundedStash
    {
		private IActorRef myRouter;
		public IStash Stash { get; set; }
		private bool ItemStashed = false;
		Dictionary<string, IActorRef> actorRefs;

		public MessageBucketCEOActor()
		{
			actorRefs = new Dictionary<string, IActorRef>();
			myRouter = Context.ActorOf(Props.Create<MessageBucketController>().WithRouter(FromConfig.Instance), "bucket");
			Become(Accepting);
		}

		private void Accepting()
		{
			Receive<StringMessage>(message => AcceptStringMessage(message));
		}

		private void AcceptStringMessage(StringMessage message)
		{
			string key = parseKey(message);
			if (!actorRefs.ContainsKey(key))
			{
				myRouter.Tell(new CheckAvailable(key));
				Become(WaitingForResponse);
				Stash.Stash();
				ItemStashed = true;
			} else
			{
				actorRefs[key].Tell(message);
			}

		}

		private void WaitingForResponse()
		{
			var startTime = DateTime.Now;
			var timeSpan = TimeSpan.FromSeconds(5);
			Receive<AmAvailable>(message =>
			{
				Become(Accepting);
				actorRefs[message.Key] = Sender;
				if (ItemStashed)
				{
					Stash.UnstashAll();
					ItemStashed = false;
				}
			});

			Receive<IAmInUseMessage>(message =>
			{
				Become(Accepting);
				if (ItemStashed)
				{
					Stash.UnstashAll();
					ItemStashed = false;
				}
			});

			Receive<StringMessage>(message => {
				Stash.Stash();
				ItemStashed = true;
			});
		}

		private string parseKey(StringMessage message)
		{
			return message.MyMessage.Split()[0];
		}
	}
}

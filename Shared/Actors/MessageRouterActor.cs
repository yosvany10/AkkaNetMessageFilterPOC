using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
	public class MessageRouterActor : ReceiveActor, IHandle<StringMessage>
	{

		public MessageRouterActor()
		{

		}

		protected override void PreStart()
		{
			ColorConsole.PrintLine("Router starting up", System.ConsoleColor.Green);
		}

		public void Handle(StringMessage message)
		{
			ColorConsole.PrintLine("Router received message", System.ConsoleColor.Blue);
		}
	}
}
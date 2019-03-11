using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
	public class StringMessage :IConsistentHashable
    {
		public string MyMessage { get; private set; }

		object IConsistentHashable.ConsistentHashKey => MyMessage.Split()[0];

		public StringMessage(string myMessage)
		{
			this.MyMessage = myMessage;
		}
	}
}

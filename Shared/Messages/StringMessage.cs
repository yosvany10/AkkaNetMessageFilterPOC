using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
	public class StringMessage
    {
		public string MyMessage { get; private set; }

		public StringMessage(string myMessage)
		{
			this.MyMessage = myMessage;
		}

		public override string ToString()
		{
			return MyMessage;
		}
	}
}

using Akka.Cluster.Sharding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
	public sealed class ShardStringMessageExtractor : IMessageExtractor
	{
		public string EntityId(object message)
		{
			return (message as StringMessageShardEnvelope)?.EntityId;
		}

		public string ShardId(object message)
		{
			return (message as StringMessageShardEnvelope)?.EntityId;
		}

		public object EntityMessage(object message)
		{
			return (message as StringMessageShardEnvelope)?.stringMessage;
		}
	}
}

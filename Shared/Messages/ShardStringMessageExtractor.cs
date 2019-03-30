using Akka.Cluster.Sharding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
	public sealed class ShardStringMessageExtractor : IMessageExtractor
	{

		// The EntityId and shardid code is the same here because my path is based on just the entityID
		// in other words one entity per shard
		public string EntityId(object message)
		{
			switch (message)
			{
				case StringMessageShardEnvelope e: return e.EntityId;
				case ShardRegion.StartEntity start: return start.EntityId;
			}
			return null;
		}

		public string ShardId(object message)
		{
			switch (message)
			{
				case StringMessageShardEnvelope e: return e.EntityId;
				case ShardRegion.StartEntity start: return start.EntityId;
			}
			return null;
		}

		public object EntityMessage(object message)
		{
			return (message as StringMessageShardEnvelope)?.stringMessage;
		}
	}
}

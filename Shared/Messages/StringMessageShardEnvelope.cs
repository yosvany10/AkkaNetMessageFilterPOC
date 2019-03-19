using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Messages
{
    public sealed class StringMessageShardEnvelope
    {
		// i'm gonna use the EntityId as the shardId aswell
		// this will make 1 entity per shard
		public string EntityId { get; private set; }
		public StringMessage stringMessage { get; private set; }

		public StringMessageShardEnvelope(string entityId, StringMessage stringMessage)
		{
			EntityId = entityId;
			this.stringMessage = stringMessage;
		}
	}
}

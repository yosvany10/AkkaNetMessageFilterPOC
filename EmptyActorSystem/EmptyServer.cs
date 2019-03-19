using System;
using Akka.Actor;
using Akka.Configuration;
using System.IO;
using Shared.Actors;
using Shared.Messages;
using Akka.Cluster.Sharding;

namespace EmptyActorSystem
{
    public class EmptyServer
    {
		static void Main(string[] args)
		{
			var config = ConfigurationFactory.ParseString(File.ReadAllText("EmptyServer.hocon"));
			var system = ActorSystem.Create("MessageFilterSystem", config);
			var shardRegion = ClusterSharding.Get(system).Start(
					typeName: "bucket",
					entityProps: Props.Create<MessageBucketController>(),
					settings: ClusterShardingSettings.Create(system),
					messageExtractor: new ShardStringMessageExtractor()
				);


			system.WhenTerminated.Wait();
		}
    }
}

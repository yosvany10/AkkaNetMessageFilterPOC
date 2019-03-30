using System;
using System.Collections.Generic;
using System.IO;
using Akka.Actor;
using Akka.Cluster.Sharding;
using Akka.Configuration;
using Akka.Routing;
using Shared.Actors;
using Shared.Messages;

namespace MessageFilterPOC
{
    class Program
    {
        static void Main(string[] args)
        {
			var config = ConfigurationFactory.ParseString(File.ReadAllText("MessageFilter.hocon"));
			var system = ActorSystem.Create("MessageFilterSystem", config);

			var shardRegion = ClusterSharding.Get(system).Start(
					typeName: "bucket",
					entityProps: Props.Create<MessageBucketController>(),
					settings: ClusterShardingSettings.Create(system),
					messageExtractor: new ShardStringMessageExtractor()
				);
			IActorRef BucketCeo = system.ActorOf(Props.Create<MessageBucketCEOActor>(shardRegion), "BucketCEO");

			List<string> randoms = new List<string>();
			List<string> randoms2 = new List<string>();

			for (int i =0; i < 100; i++)
			{
				Random r = new Random();
				int rInt = r.Next(0, 9);
				int r1Int = r.Next(0, 9);
				int r2Int = r.Next(0, 9);
				randoms.Add(string.Format("{0} {1} {2}", rInt.ToString(), r1Int.ToString(), r2Int.ToString()));
			}

			Console.ReadLine();
			for (int i = 0; i < randoms.Count; i++)
			{
				
				BucketCeo.Tell(new StringMessage(randoms[i]));
			}

			for (int i = 0; i < 100; i++)
			{
				Random r = new Random();
				int rInt = r.Next(10, 13);
				int r1Int = r.Next(10, 13);
				int r2Int = r.Next(10, 13);
				randoms2.Add(string.Format("{0} {1} {2}", rInt.ToString(), r1Int.ToString(), r2Int.ToString()));
			}
			Console.ReadLine();
			for (int i = 0; i < randoms2.Count; i++)
			{

				BucketCeo.Tell(new StringMessage(randoms2[i]));
			}
			Console.ReadLine();
			system.Terminate();
			system.WhenTerminated.Wait();
        }
    }
}

# AkkaNetMessageFilterPOC
Simple example of Akka.net sharding with a cluster.

This is a simple project that generates random messages and sorts them into shard entities based on the first number of the message.
Currently this uses only the EntityId to distribute the messages. This means that there is a one entity per shard relationship currently.
You can start up instances of the empty actor using the dotnet run command to see how the shards get distributed based on how many instances you have up.
You can also exit an instance to watch the shards rebalance and respawn the lost entities and shards after unreachable status is determined per the auto-down-unreachable-after config.

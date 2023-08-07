using StackExchange.Redis;

namespace RedisPubisher
{
    public static class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static readonly ConnectionMultiplexer _connection = ConnectionMultiplexer.Connect(RedisConnectionString);

        public static void Main()
        {
            var pubsub = _connection.GetSubscriber();

            var channel = new RedisChannel("test-channel", RedisChannel.PatternMode.Auto);

            pubsub.PublishAsync(channel, "This is a test message!!", CommandFlags.FireAndForget);
            Console.Write("Message Successfully sent to test-channel");
            Console.ReadLine();
        }
    }
}
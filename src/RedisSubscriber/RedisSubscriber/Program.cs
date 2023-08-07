using StackExchange.Redis;

namespace RedisPubisher
{
    public static class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private readonly static ConnectionMultiplexer _connection = ConnectionMultiplexer.Connect(RedisConnectionString);

        public static void Main()
        {
            Console.WriteLine("Listening test-channel");
            var pubsub = _connection.GetSubscriber();

            var channel = new RedisChannel("test-channel", RedisChannel.PatternMode.Auto);
            pubsub.Subscribe(channel, (channel, message) => Console.Write("Message received from test-channel : " + message));
            Console.ReadLine();
        }
    }
}
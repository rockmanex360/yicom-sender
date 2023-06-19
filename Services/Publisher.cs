using System.Text;
using RabbitMQ.Client;
using System.Text.Json;

namespace Sender.Services
{
    public class Publisher : IPublisher
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public Publisher()
        {
            _factory = new ConnectionFactory() 
            { 
                HostName = "localhost" 
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task Publish(CancellationToken cancellationToken)
        {
            try 
            {
                while(!cancellationToken.IsCancellationRequested)
                {
                    for(var i = 0; i < 20; i++)
                    {
                        var random = new Random();
                        var randNumber = random.Next(1, 10);

                        var messageObject = new Request
                        {
                            Message = "hello world",
                            TimeStamp = DateTime.UtcNow.ToString("O"),
                            Priority = randNumber
                        };
                        var message = JsonSerializer.Serialize(messageObject);
                        await PublishAsync(message, randNumber);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }
        private async Task PublishAsync(string message, int priority)
        {
            _channel.QueueDeclare( "message",false,false,false,null);

            var body = Encoding.UTF8.GetBytes(message);

            await Task.Run(() =>
            {
                _channel.BasicPublish(exchange: string.Empty,
                                    routingKey: "message",
                                    basicProperties: null,
                                    body: body);
            });
        }
    }
}
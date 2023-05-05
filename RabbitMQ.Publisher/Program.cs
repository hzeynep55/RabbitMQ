// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://hgiheins:k30j9gIcerohFeYDGwcPk6Z4jjjtgUwy@shrimp.rmq.cloudamqp.com/hgiheins");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

Enumerable.Range(1, 50).ToList().ForEach(x =>
{
    channel.QueueDeclare("Example", true, false, false);

    string message = "Hello";

    var messageBody = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(string.Empty, "Example", null, messageBody);
    Console.WriteLine($"Gönderilen Mesaj: {message}");

});


Console.ReadLine();
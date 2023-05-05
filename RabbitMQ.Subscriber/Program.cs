// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://hgiheins:k30j9gIcerohFeYDGwcPk6Z4jjjtgUwy@shrimp.rmq.cloudamqp.com/hgiheins");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

//channel.QueueDeclare("Example", true, false, false);

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("Example",false,consumer);

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{

    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine("Gelen mesaj: "+message);
    channel.BasicAck(e.DeliveryTag,false);


};
Console.ReadLine();

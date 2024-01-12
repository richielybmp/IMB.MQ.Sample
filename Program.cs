using IMB.MQ.Sample.Configuration;
using IMB.MQ.Sample.Integration;

string topicName = "DEV.QUEUE.1";

MqMessagePublisher mqMessagePublisher = new MqMessagePublisher(topicName);

QueueManagerConnection.Open();

Console.WriteLine("Mensagem: ");
string message = Console.ReadLine();


while (message != "-1")
{

    mqMessagePublisher.PublishMessageToTopic(message);
    message = Console.ReadLine();
}

QueueManagerConnection.Close();

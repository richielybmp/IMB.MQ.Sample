
using IBM.WMQ;
using IMB.MQ.Sample.Configuration;

namespace IMB.MQ.Sample.Integration
{

    public class MqMessagePublisher
    {

        private readonly string queueName;

        public MqMessagePublisher(string queueName)
        {
            this.queueName = queueName;
        }

        public void PublishMessageToTopic(string message)
        {
            int openOptions = MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_OUTPUT;

            var mqQMgr = QueueManagerConnection.Get();

            MQQueue mqQueue = mqQMgr.AccessQueue(queueName, openOptions);

            MQMessage mqMessage = new MQMessage();
            mqMessage.Format = MQC.MQFMT_STRING;
            mqMessage.WriteUTF(message);

            MQPutMessageOptions pmo = new MQPutMessageOptions();
            mqQueue.Put(mqMessage, pmo);

            mqQueue.Close();

            Console.WriteLine($"Message '{message}' published to topic: {queueName}");
        }
    }
}


/*
 * // Get the message back again

      // First define an IBM MQ message buffer to receive the message
      MQMessage retrievedMessage =new MQMessage();
      retrievedMessage.MessageId =hello_world.MessageId;

      // Set the get message options
      MQGetMessageOptions gmo =new MQGetMessageOptions(); //accept the defaults
                                                          //same as MQGMO_DEFAULT

      // Get the message off the queue
      system_default_local_queue.Get(retrievedMessage,gmo);

      // Prove we have the message by displaying the UTF message text
      String msgText = retrievedMessage.ReadUTF();
      Console.WriteLine("The message is: {0}", msgText);

      // Close the queue
      system_default_local_queue.Close();

      // Disconnect from the queue manager
      qMgr.Disconnect();
 */
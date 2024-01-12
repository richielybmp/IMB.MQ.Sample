
using IBM.WMQ;
using System.Collections;

namespace IMB.MQ.Sample.Configuration
{
    public class QueueManagerConnection
    {

        private QueueManagerConnection()
        {
        }

        private static MQQueueManager manager;
        private const string queueManagerName = "QMGR";


        public static MQQueueManager Get()
        {
            if (manager != null)
            {
                return manager;
            }

            Open();
            return manager;
        }

        public static void Open()
        {
            if (manager == null)
            {
                manager = new MQQueueManager(queueManagerName, GetProperties());
            }
        }

        public static void Close()
        {
            if (manager != null)
            {
                manager.Disconnect();
            }
        }

        private static Hashtable GetProperties()
        {
            var configurations = ConnectionConfiguration.Load();

            Hashtable props = new Hashtable();

            props.Add(MQC.HOST_NAME_PROPERTY, configurations.Hostname);
            props.Add(MQC.CONNECTION_NAME_PROPERTY, configurations.Hostname);
            props.Add(MQC.CHANNEL_PROPERTY, configurations.Channel);
            props.Add(MQC.PORT_PROPERTY, configurations.Port);
            props.Add(MQC.USER_ID_PROPERTY, configurations.UserId);
            props.Add(MQC.PASSWORD_PROPERTY, configurations.Password);

            Console.WriteLine(configurations);

            return props;
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
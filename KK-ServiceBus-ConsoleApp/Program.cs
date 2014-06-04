using System;
using Microsoft.ServiceBus;

using Microsoft.ServiceBus.Messaging;


namespace KK_ServiceBus_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            Console.WriteLine("Enter Service Bus Connection string:\n");
            connectionString = Console.ReadLine();
            var messageFactory = MessagingFactory.CreateFromConnectionString(connectionString);
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            const string QueueName = "ServiceBusQueueSample";

            if (namespaceManager == null)
            {
                Console.WriteLine("\nUnexpected Error: NamespaceManager is NULL");
                return;
            }

            if (namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.DeleteQueue(QueueName);
            }
            namespaceManager.CreateQueue(QueueName);
        }
    }
}

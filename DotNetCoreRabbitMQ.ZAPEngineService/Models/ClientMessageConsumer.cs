using DotNetCoreRabbitMQ.Message;
using EasyNetQ.AutoSubscribe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRabbitMQ.ZAPEngineService.Models {
    public class ClientMessageConsumer : IConsumeAsync<ClientMessage> {

        [AutoSubscriberConsumer(SubscriptionId = "ClientMessageService.ZapQuestion")]
        public Task ConsumeAsync(ClientMessage message) {
            // Your business logic code here
            // eg.Generate one ZAP question records into database and send to client
            // Sample console code
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("Consume one message from RabbitMQ : {0}, I will generate one ZAP question list to client", message.ClientName);
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}

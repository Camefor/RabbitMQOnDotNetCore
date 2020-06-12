using DotNetCoreRabbitMQ.Message;
using EasyNetQ.AutoSubscribe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRabbitMQ.NoticeService.Models {
    /// <summary>
    /// NoticeService：新增一个实现IConsume接口的Consumer类
    /// ClientMessage类的消费者
    /// </summary>
    public class ClientMessageConsumer : IConsumeAsync<ClientMessage> {
        [AutoSubscriberConsumer(SubscriptionId = "ClientMessageService.Notice")]
        public Task ConsumeAsync(ClientMessage message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Consume one message from RabbitMQ : {0},I will send one email to client.", message.ClientName);
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}

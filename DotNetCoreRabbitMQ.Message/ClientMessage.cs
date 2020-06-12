using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;

namespace DotNetCoreRabbitMQ.Message {
    /// <summary>
    /// 消息对象实体：通过标签声明队列名称
    /// </summary>
    [Queue("Oka.Client", ExchangeName = "Oka.Client")]
    public class ClientMessage {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        // N: Non-Smoker, S: Smoker
        public string SmokerCode { get; set; }
        // Bachelor, Master, Doctor
        public string Education { get; set; }
        public decimal YearIncome { get; set; }
    }
}

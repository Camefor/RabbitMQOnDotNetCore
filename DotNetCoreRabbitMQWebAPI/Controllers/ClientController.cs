using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreRabbitMQ.ClientService.Models;
using DotNetCoreRabbitMQ.ClientService.Services;
using DotNetCoreRabbitMQ.Message;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreRabbitMQ.ClientService.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IClientService clientService;
        private readonly IBus bus;

        public ClientController(IClientService _clientService, IBus _bus) {
            clientService = _clientService;
            bus = _bus;
        }

        [HttpGet("{id}")]
        public object Get(int id) {
            return clientService.GetClientById(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody]ClientDTO clientDto) {
            // Business Logic here...
            // eg.Add new client to your service databases via EF
            // Sample Publish
            ClientMessage message = new ClientMessage {
                ClientId = clientDto.Id.Value,
                ClientName = clientDto.Name,
                Sex = clientDto.Sex,
                Age = 29,
                SmokerCode = "N",
                Education = "Master",
                YearIncome = 100000
            };




            await bus.PublishAsync(message);
            var s = "Add Client Success! You will receive some letter later.";
            Console.WriteLine(s);
            return s;
        }
    }
}
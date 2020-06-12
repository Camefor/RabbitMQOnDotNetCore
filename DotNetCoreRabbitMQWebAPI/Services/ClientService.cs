using DotNetCoreRabbitMQ.ClientService.Models;
using DotNetCoreRabbitMQ.ClientService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRabbitMQ.ClientService.Services {
    public interface IClientService {
        Client GetClientById(int _id);
        Client UpdateClientInfo(Client client);
    }
    public class ClientService : IClientService {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }
        public Client GetClientById(int _id) {
            var model = _clientRepository.GetClientById(_id);
            return model;
        }

        public Client UpdateClientInfo(Client _person) {
            var model = GetClientById(_person.Id);
            model.Name = "Edison Chen";
            var newPerson = new Client() {
                Name = "Nichcolas Xie",
                Sex = "M"
            };
            // below is a simple transaction
            _clientRepository.Insert(newPerson, false);
            _clientRepository.Update(model);

            return newPerson;
        }
    }
}

using DotNetCoreRabbitMQ.ClientService.Models;
using DotNetCoreRabbitMQ.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRabbitMQ.ClientService.Repositories {
    public interface IClientRepository : IRepository<Client, ClientDbContext> {
        Client GetClientById(int _personId);
    }

    public class ClientRepository : RepositoryBase<Client, ClientDbContext>, IClientRepository {
        public ClientRepository(ClientDbContext context) : base(context) {
        }

        public Client GetClientById(int _personId) {
            var entity = DbContext.Clients.FirstOrDefault(p => p.Id == _personId);
            return entity;
        }
    }
}

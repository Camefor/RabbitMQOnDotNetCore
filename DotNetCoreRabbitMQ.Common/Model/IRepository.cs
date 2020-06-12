using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreRabbitMQ.Common {
    public interface IRepository<T, Context>
        where T : class
        where Context : DbContext {
      
        Context DbContext { get; }

      
        DbSet<T> Entities { get; }

      
        IQueryable<T> Table { get; }

      
        T GetById(object id);

        void Insert(T entity, bool isSave = true);

        void Update(T entity, bool isSave = true);

        void Delete(T entity, bool isSave = true);
    }
}

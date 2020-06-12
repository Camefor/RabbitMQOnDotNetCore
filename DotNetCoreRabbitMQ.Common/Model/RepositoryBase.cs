using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCoreRabbitMQ.Common {
    public class RepositoryBase<T, Context> : IRepository<T, Context>
        where T : class
        where Context : DbContext {

        private readonly Context _dbContext;
        public RepositoryBase(Context context) {
            _dbContext = context;
        }


        public Context DbContext => _dbContext;

        public DbSet<T> Entities => _dbContext.Set<T>();

        public IQueryable<T> Table => Entities;

        public void Delete(T entity, bool isSave = true) {
            Entities.Remove(entity);
            if (isSave) {
                _dbContext.SaveChanges();
            }
        }

        public T GetById(object id) => _dbContext.Set<T>().Find(id);

        public void Insert(T entity, bool isSave = true) {
            Entities.Add(entity);
            if (isSave) {
                _dbContext.SaveChanges();
            }
        }

        public void Update(T entity, bool isSave = true) {
            if (isSave) {
                _dbContext.SaveChanges();
            }
        }
    }
}

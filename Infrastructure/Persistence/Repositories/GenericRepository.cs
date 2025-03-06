using Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ConcurrentDictionary<int, T> storage = new();
        public void Add(int id,T entity)
        {
           
             storage.TryAdd(id, entity);
        }

        public void Delete(int id)
        {
            storage.TryRemove(id,out _);
        }

        public IEnumerable<T> GetAll()
        {
            return storage.Values;
        }

        public T GetById(int id)
        {
            return storage[id];
        }

        public void Update(int id, T entity)
        {
            storage[id] = entity;
        }
    }
}

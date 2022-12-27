using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context _c =new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = _c.Set<T>();
        }

        public void Delete(T t)
        {
            var deletedEntity = _c.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            _c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = _c.Entry(t);
            addedEntity.State = EntityState.Added;
            _c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); 
        }

        public void Update(T t)
        {
            var updatedEntity = _c.Entry(t);
            updatedEntity.State = EntityState.Modified;
            _c.SaveChanges();
        }
    }
}

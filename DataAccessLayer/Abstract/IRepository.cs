using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>
    {
        List<T> List();
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> List(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
    }
}

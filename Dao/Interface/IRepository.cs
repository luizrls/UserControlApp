using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Interface
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Remove(T entity);

        void Commit();
        void Dispose();
    }

}


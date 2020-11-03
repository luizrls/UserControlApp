using Dal.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Dal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Contexto Context;

        protected Repository(Contexto context)
        {
            Context = context;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);

            return entity;

        }

        public ICollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Remove(T entity)
        {
            Context.Set<T>().Remove(entity);

            return entity;
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        
    }
}

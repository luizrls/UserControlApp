using Dal.Interface;
using Dal.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biz
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _context;

        public UnitOfWork(Contexto context)
        {
            _context = context;
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            User = new UserRepository(_context);
        }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    
}

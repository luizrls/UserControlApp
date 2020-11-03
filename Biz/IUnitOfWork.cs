using Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biz
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
    }
}

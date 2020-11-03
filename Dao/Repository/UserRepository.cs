using Dal.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repository
{
    public class UserRepository : Repository<User>, IUserRepository { public UserRepository(Contexto context) : base(context) { } }

}

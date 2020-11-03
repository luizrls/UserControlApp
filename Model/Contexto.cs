using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Contexto : DbContext
    {
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}

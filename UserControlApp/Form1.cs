using Biz;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DbContextOptions<Contexto> options;
            var builder = new DbContextOptionsBuilder<Contexto>();
            builder.UseInMemoryDatabase("Contexto");
            options = builder.Options;


            using (var unitOfWork = new UnitOfWork(new Contexto(options)))
            {
               

                UserBiz biz = new UserBiz(unitOfWork);

                User u = new User()
                {
                    nome = "",
                    email = "AAA@AAA.com",
                    flgAtivo = true,
                    id = 0,
                    perfil = "Common",
                    senha = "1234"
                };

                biz.Insert(u);
                var count = biz.GetAll().Count();

            }
        }
    }
}

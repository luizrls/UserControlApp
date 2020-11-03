using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Model;
using Dal.Interface;
using Dal.Repository;
using System.Linq;
using Biz;

namespace UserControlAppTests
{
    public class UserTests
    {
        [Fact]
        public void DeveBuscarUmUsuario()
        {
            //Arrange
            using (var unitOfWork = getUnitOfWork())
            {


                UserBiz biz = new UserBiz(getUnitOfWork());

                User user = new User() {nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };

                biz.Insert(user);
                var count = biz.GetAll().Count();
                Assert.Equal(1, count);
            }


            //Act

            //Assert
        }

        [Fact]
        public void DeveCriarUmNovoUsuario()
        {
            UserBiz biz = new UserBiz(getUnitOfWork());

            User user = new User() { nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };

            biz.AddOrUpdate(user);
            var count = biz.GetAll().Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public void DeveVerificarDuplicados()
        {
            UserBiz biz = new UserBiz(getUnitOfWork());

            User user = new User() {nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };
            User user2 = new User() {nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };

            biz.AddOrUpdate(user);
            biz.AddOrUpdate(user2);
            var count = biz.GetAll().Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public void DeveEditarUmUsuario()
        {
            UserBiz biz = new UserBiz(getUnitOfWork());

            User user = new User() {nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };

            var saved = biz.AddOrUpdate(user);

            saved.nome = "User 2";

            biz.AddOrUpdate(saved);

            var searched = biz.GetById(saved.id);

            Assert.Equal("User 2", searched.nome);
        }

        [Fact]
        public void DeveExcluirUmUsuario()
        {
            UserBiz biz = new UserBiz(getUnitOfWork());
            
            User user = new User() {nome = "User 1", email = "email@email.com", senha = "1234", perfil = "Common", flgAtivo = true };
            
            var saved = biz.AddOrUpdate(user);
            
            biz.Delete(saved);
            
            var count = biz.GetAll().Count();
            
            Assert.Equal(0, count);
        }

        private UnitOfWork getUnitOfWork()
        {
            DbContextOptions<Contexto> options;
            var builder = new DbContextOptionsBuilder<Contexto>();
            builder.UseInMemoryDatabase("Contexto");
            options = builder.Options;

            return new UnitOfWork(new Contexto(options));
        }

    }
}

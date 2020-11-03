using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biz
{
    public class UserBiz
    {
        private UnitOfWork _unitOfWork;

        public UserBiz(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetById(int id)
        {
            try
            {
                return _unitOfWork.User.Find(x=> x.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public User GetByEmail(string email)
        {
            try
            {
                return _unitOfWork.User.Find(x => x.email == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public List<User> GetAll()
        {
            try
            {
                return _unitOfWork.User.GetAll().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User AddOrUpdate(User User)
        {
            try
            {
                if (User.id > 0 || GetByEmail(User.email) != null)
                    return Put(User);

                return Insert(User);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User Insert(User User)
        {
            try
            {

                User.id = _unitOfWork.User.GetAll().Count() + 1;

                var retorno = _unitOfWork.User.Add(User);
                _unitOfWork.User.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private User Put(User User)
        {
            try
            {
                var retorno = _unitOfWork.User.Update(User);
                _unitOfWork.User.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User Delete(User User)
        {
            try
            {
                var retorno = _unitOfWork.User.Remove(User);
                _unitOfWork.User.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}

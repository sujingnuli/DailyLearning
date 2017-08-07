using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webERP.Models;

namespace webERP.Bll
{
    public class UserBll:IBaseOper<User>
    {
        private DataContext db = new DataContext();
        public void Add(User user) {
            db.Users.Add(user);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
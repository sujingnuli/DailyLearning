using Entities;
using GJBCTest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GJBCTest.WebApi.Bll
{
    public class UserBll
    {
        private DataContext db = new DataContext();

        public UserInfo Add(UserInfo user) {
            db.UserInfos.Add(user);
            db.SaveChanges();
            return user;
        }

        public UserInfo Update(UserInfo user) {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return user;
        }

        public bool TryGet(int id, out UserInfo user) {
            UserInfo user2 = db.UserInfos.Find(id);
            if (user2 != null)
            {
                user = user2;
                return true;
            }
            else {
                user = null;
                return false;
            }
        }
        public void Delete(int id) {
            UserInfo user=db.UserInfos.Find(id);
            db.UserInfos.Remove(user);
            db.SaveChanges();
        }
        public IEnumerable<UserInfo> GetAll() {
            return db.UserInfos;
        }

        public UserInfo Get() {
            return db.UserInfos.FirstOrDefault();
        }
    }
}
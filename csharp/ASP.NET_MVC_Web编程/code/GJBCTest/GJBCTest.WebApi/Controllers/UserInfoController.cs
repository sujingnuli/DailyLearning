using Entities;
using GJBCTest.WebApi.Bll;
using GJBCTest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GJBCTest.WebApi.Controllers
{
    public class UserInfoController : ApiController
    {
        UserBll ubll = new UserBll();
        public UserInfo Get() {
            return ubll.Get();
        }
        public HttpResponseMessage Post(UserInfo userInfo) {
            userInfo=ubll.Add(userInfo);
            var response = Request.CreateResponse<UserInfo>(HttpStatusCode.Created, userInfo);
            response.Headers.Location=new Uri(Request.RequestUri,"/api/userinfo/"+userInfo.Id.ToString());
            return response;
        }

        public HttpResponseMessage Update(int id, UserInfo userInfo) {
            userInfo=ubll.Update(userInfo);
            var response = Request.CreateResponse<UserInfo>(HttpStatusCode.OK, userInfo);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/userInfo/" + userInfo.Id.ToString());
            return response;
        }

        public UserInfo Delete(int id) {
             UserInfo user;
             if (!ubll.TryGet(id, out user)) {
                 throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
             }
             ubll.Delete(id);
             return user;
        }
    }
}

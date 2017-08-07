using Entities;
using GJBCTest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GJBCTest.WebApi.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("name=MusicStoreDBContext")
        { 
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webERP.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("name=ERPDbContext")
        { 
            
        }
        public DbSet<User> Users { get; set; }
    }
}
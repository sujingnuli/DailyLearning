using Ebuy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    [Authorize]
    public class CategoryController:Controller
    {
        public ActionResult Details(string id) {
            var viewModel = new CategoriesViewModel();
            var sqlStr = "select * from Categories where id=" + id;
            var connStr = WebConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (var conn = new SqlConnection(connStr)) {
                var command = new SqlCommand(sqlStr, conn);
                command.Connection.Open();
                IDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    viewModel.Categories.Add(new Category { Id=reader[0], Name = reader[2].ToString() });
                }
            }
            return View(viewModel);
        }
      
    }
}
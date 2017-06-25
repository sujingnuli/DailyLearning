using Ebuy.Common.Entities;
using Ninject.Activation.Caching;
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
        public ActionResult Details(string Id) {
            var viewModel = new CategoriesViewModel();
            var sqlStr = "select * from Categories where id=" + Id;
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
        public ActionResult CategoriesAll() {
            var viewModel = new CategoriesViewModel();
            var sqlStr = "select * from categories";
            var connStr = WebConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (var conn = new SqlConnection(connStr)) {
                var command = new SqlCommand(sqlStr, conn);
                command.Connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    viewModel.Categories.Add(new Category { Id = reader[0], Name = reader[2].ToString() });
                }
            }
            return View("List",viewModel);
        }
        public ActionResult Categories() {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration=60)]
        public ActionResult CategoriesChildAction() {
            //ViewBag.Categories = Model.GetCategories();
            CategoriesViewModel cates = new CategoriesViewModel();
            var sqlStr = "select * from categories";
            var connStr = WebConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (var conn = new SqlConnection(connStr)) {
                var command = new SqlCommand(sqlStr, conn);
                command.Connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    cates.Categories.Add(new Category { Id = reader[0], Name = reader[2].ToString() });
                }
            }
            ViewBag.Categories = cates;
            return View("List");
            
        }
    }
}
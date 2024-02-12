using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class HizmetlerimizController : Controller
    {
        // GET: Hizmetlerimiz
        public ActionResult Index()
        {
            var dataContext = new PetaPoco.Database("sqlserverce");
            List<Category> CategoryList = dataContext.Query<Category>("Select * from Category where IsActive = 1 order by Name").ToList();

            return View(CategoryList);
        }

        public ActionResult Detay(int Id)
        {
            var dataContext = new PetaPoco.Database("sqlserverce");

            CategoryDetayVM vm = new CategoryDetayVM()
            {
                CategoryList = dataContext.Query<Category>("Select * from Category where IsActive = 1 order by Name").ToList(),
                Kategori = dataContext.Query<Category>("select * from Category where Id = @0", Id).FirstOrDefault() ?? new Category()
            };


            //CategoryDetayVM vm = new CategoryDetayVM()
            //{
            //    CategoryList = new List<Category>(),
            //    Kategori =new Category()
            //};

            return View(vm);
        }
    }
}
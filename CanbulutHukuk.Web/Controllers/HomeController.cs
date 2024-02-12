using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Article> BlogList = new List<Article>();
            try
            {
                var dataContext = new PetaPoco.Database("sqlserverce");

                //BlogList = dataContext.Query<Article>("Select top 3 Article.*,Category.Name as CategoryName  from Article inner join Category on Category.Id = Article.CategoryId where Article.IsActive = 1 order by Article.ReleaseDate desc").ToList();
            }
            catch (Exception ex)
            {
                ViewData["exception"] = ex;
            }

            HomeIndexVM vm = new HomeIndexVM() { BlogList = BlogList };

            return View(vm);
        }
    }
}
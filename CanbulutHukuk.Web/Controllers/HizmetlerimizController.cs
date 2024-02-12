using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class HizmetlerimizController : Controller
    {
        // GET: Hizmetlerimiz
        public ActionResult Index()
        {
            return View();
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

        public ActionResult AileHukuku()
        {
            return View();
        }

        public ActionResult BorclarHukuku()
        {
            return View();
        }

        public ActionResult CezaHukuku()
        {
            return View();
        }

        public ActionResult IcraIflasHukuku()
        {
            return View();
        }

        public ActionResult IdareHukuku()
        {
            return View();
        }

        public ActionResult IsHukuku()
        {
            return View();
        }

        public ActionResult MirasHukuku()
        {
            return View();
        }

        public ActionResult TasinmazHukuku()
        {
            return View();
        }

        public ActionResult TicaretHukuku()
        {
            return View();
        }

        public ActionResult TuketiciHukuku()
        {
            return View();
        }

        public ActionResult VergiHukuku()
        {
            return View();
        }
    }
}
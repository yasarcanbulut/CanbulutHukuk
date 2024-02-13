using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Search)
        {
            var dataContext = new PetaPoco.Database("sqlserverce");
            BlogIndexVm vm = new BlogIndexVm()
            {
                BlogList = dataContext.Query<Article>("Select Article.*,Category.Name as CategoryName  from Article inner join Category on Category.Id = Article.CategoryId where Article.IsActive = 1 order by Article.ReleaseDate desc").ToList(),
                LastBlogList = dataContext.Query<Article>("Select top 3 Article.*,Category.Name as CategoryName  from Article inner join Category on Category.Id = Article.CategoryId where Article.IsActive = 1 order by Article.ReleaseDate desc").ToList(),
                CategoryList = dataContext.Query<Category>("Select * from Category where IsActive = 1 order by Name").ToList(),
                TagList = dataContext.Query<Tags>("Select * from Tags where IsActive = 1 order by Name").ToList()
            };

            //BlogIndexVm vm = new BlogIndexVm()
            //{
            //    BlogList = new List<Article>(),
            //    LastBlogList = new List<Article>(),
            //    CategoryList = new List<Category>(),
            //    TagList = new List<Tags>()
            //};

            return View(vm);
        }

        public ActionResult Sayfa(int Id)
        {
            var dataContext = new PetaPoco.Database("sqlserverce");

            Article dbArticle = dataContext.Query<Article>("select Article.*,Category.Name as CategoryName from Article inner join Category on Category.Id = Article.CategoryId where Article.Id = @0", Id).FirstOrDefault();
            dbArticle.ReadCount += 1;

            dataContext.Save(dbArticle);

            BlogSayfaVM vm = new BlogSayfaVM()
            {
                LastBlogList = dataContext.Query<Article>("Select top 3 Article.*,Category.Name as CategoryName  from Article inner join Category on Category.Id = Article.CategoryId where Article.IsActive = 1 order by Article.ReleaseDate desc").ToList(),
                Post = dbArticle,
                CategoryList = dataContext.Query<Category>("Select * from Category where IsActive = 1 order by Name").ToList(),
                TagList = dataContext.Query<Tags>("Select * from Tags where IsActive = 1 order by Name").ToList()
            };

            //BlogSayfaVM vm = new BlogSayfaVM()
            //{
            //    LastBlogList = new List<Article>(),
            //    Post = new Article(),
            //    CategoryList = new List<Category>(),
            //    TagList = new List<Tags>()
            //};

            return View(vm);
        }

        public ActionResult covid19_salgini_karsisinda_isci_isveren_iliskisi()
        {
            return View();
        }

        public ActionResult tuketici_senedi_nasil_olmalidir()
        {
            return View();
        }

        public ActionResult gemi_adami_alacaklari_ihtiyati_haciz_ve_rehin()
        {
            return View();
        }

        public ActionResult ceza_kosulu()
        {
            return View();
        }

        public ActionResult borclunun_temeddudunde_sozlesmeden_donme()
        {
            return View();
        }

        public ActionResult bedelli_askerlikte_kidem_tazminati()
        {
            return View();
        }
    }
}
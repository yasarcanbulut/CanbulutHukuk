using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(int Category = -1, int Etiket = -1)
        {
            var dataContext = new PetaPoco.Database("sqlserverce");
            BlogIndexVm vm = new BlogIndexVm()
            {
                BlogList = dataContext.Query<Article>("Select Article.*,Category.Name as CategoryName from Article inner join Category on Category.Id = Article.CategoryId where Article.IsActive = 1 and (@0 = -1 or Article.CategoryId = @0) order by Article.ReleaseDate desc", Category).ToList(),
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
    }
}
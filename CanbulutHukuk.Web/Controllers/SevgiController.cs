using CanbulutHukuk.Web.Configuration;
using CanbulutHukuk.Web.Models.CHModels;
using CanbulutHukuk.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CanbulutHukuk.Web.Controllers
{
    public class SevgiController : Controller
    {
        public PetaPoco.Database dataContext;

        public SevgiController()
        {
            dataContext = new PetaPoco.Database("sqlserverce");
        }

        [EnsureUserLoggedIn]
        public ActionResult Index()
        {
            return View();
        }

        [EnsureUserLoggedIn]
        public ActionResult BlogList()
        {
            List<Article> BlogList = dataContext.Query<Article>("Select * from Article order by ReleaseDate desc").ToList();

            return View(BlogList);
        }

        [EnsureUserLoggedIn]
        public ActionResult PostEdit(int Id = 0)
        {
            PostEditVM vm = new PostEditVM()
            {
                Post = dataContext.Query<Article>("select * from Article where Id = @0", Id).FirstOrDefault() ?? new Article(),
                CategoryList = dataContext.Query<Category>("Select * from Category where IsActive = 1").ToList()
            };

            //PostEditVM vm = new PostEditVM()
            //{
            //    Post = new Article(),
            //    CategoryList = new List<Category>()
            //};

            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        [EnsureUserLoggedIn]
        public ActionResult PostEdit(Article VM, HttpPostedFileBase files)
        {
            try
            {
                if (files != null)
                {
                    string path = Server.MapPath("~/UploadImages/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = Guid.NewGuid() + "_" + files.FileName;
                    files.SaveAs(path + Path.GetFileName(fileName));

                    VM.Photo = fileName;
                }

                VM.Summary = VM.Summary.Length > 300 ? VM.Summary.Substring(0, 299) : VM.Summary;

                if (VM.IsActive && VM.ReleaseDate == null)
                {
                    VM.ReleaseDate = DateTime.Now;
                }

                Kullanici user = (Kullanici)Session["LoginUser"];
                VM.UserId =(int)user.Id;

                dataContext.Save(VM);

                TempData["Result"] = "Success";
            }
            catch (Exception)
            {
                TempData["Result"] = "Error";
            }

            return RedirectToAction("PostEdit", new { Id = VM.Id });
        }

        [EnsureUserLoggedIn]
        public ActionResult CategoryList()
        {
            List<Category> CategoryList = dataContext.Query<Category>("Select * from Category order by Isactive desc, Name").ToList();

            return View(CategoryList);
        }

        [EnsureUserLoggedIn]
        public ActionResult CategoryEdit(int Id = 0)
        {
            Category vm = dataContext.Query<Category>("select * from Category where Id = @0", Id).FirstOrDefault() ?? new Category();

            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        [EnsureUserLoggedIn]
        public ActionResult CategoryEdit(Category VM)
        {
            try
            {
                dataContext.Save(VM);

                TempData["Result"] = "Success";
            }
            catch (Exception)
            {
                TempData["Result"] = "Error";
            }

            return RedirectToAction("CategoryEdit", new { Id = VM.Id });
        }
        
        public ActionResult Login(string TcKimlikNo, string Password)
        {
            if (string.IsNullOrEmpty(TcKimlikNo ))
            {
                return View();
            }
            Kullanici user = dataContext.Query<Kullanici>("select * from Kullanici where TcKimlikNo = @0 and IsActive = 1", TcKimlikNo).FirstOrDefault();

            var pass = CalculateMD5Hash(Password);

            if (user == null || user.Password != pass)
            {
                TempData["Result"] = "Error";
                TempData["Message"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            Session["LoginUser"] = user;

            return RedirectToAction("Index");
        }

        public string CalculateMD5Hash(string input)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }

    }
}
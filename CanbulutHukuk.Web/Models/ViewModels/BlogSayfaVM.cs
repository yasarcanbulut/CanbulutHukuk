using CanbulutHukuk.Web.Models.CHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanbulutHukuk.Web.Models.ViewModels
{
    public class BlogSayfaVM
    {
        public Article Post { get; set; }
        public List<Article> LastBlogList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Tags> TagList { get; set; }
    }
}
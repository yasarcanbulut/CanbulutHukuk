using CanbulutHukuk.Web.Models.CHModels;
using System.Collections.Generic;

namespace CanbulutHukuk.Web.Models.ViewModels
{
    public class BlogIndexVm
    {
        public List<Article> BlogList { get; set; }
        public List<Article> LastBlogList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Tags> TagList { get; set; }
    }
}
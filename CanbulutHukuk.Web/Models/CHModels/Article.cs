using PetaPoco;
using System;

namespace CanbulutHukuk.Web.Models.CHModels
{
    [TableName("Article")]
    [PrimaryKey("Id")]
    public class Article :ModelBase
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int UserId { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int ReadCount { get; set; }
        public int LikeCount { get; set; }
        [ResultColumn]
        public string CategoryName { get; set; }
    }
}
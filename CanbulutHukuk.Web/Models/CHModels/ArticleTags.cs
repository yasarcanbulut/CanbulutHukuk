using PetaPoco;

namespace CanbulutHukuk.Web.Models.CHModels
{
    [TableName("ArticleTags")]
    [PrimaryKey("Id")]
    public class ArticleTags : ModelBase
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
    }
}
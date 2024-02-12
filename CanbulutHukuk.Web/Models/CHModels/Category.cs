using PetaPoco;

namespace CanbulutHukuk.Web.Models.CHModels
{
    [TableName("Category")]
    [PrimaryKey("Id")]
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
using PetaPoco;

namespace CanbulutHukuk.Web.Models.CHModels
{
    [TableName("Tags")]
    [PrimaryKey("Id")]
    public class Tags : ModelBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
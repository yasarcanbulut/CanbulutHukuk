using NPoco;
using System;

namespace CanbulutHukuk.Infrastructure.DataAccess.Models
{
    [TableName("dbo.Category")]
    [PrimaryKey("Id")]
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

using PetaPoco;

namespace CanbulutHukuk.Web.Models.CHModels
{
    [TableName("User")]
    [PrimaryKey("Id")]
    public class Kullanici : ModelBase
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TcKimlikNo { get; set; }
        public bool IsActive { get; set; }
    }
}
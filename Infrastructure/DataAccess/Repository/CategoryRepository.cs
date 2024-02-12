using NPoco;
using System.Collections.Generic;
using CanbulutHukuk.Infrastructure.DataAccess.Models;

namespace CanbulutHukuk.Infrastructure.DataAccess.Repository
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(IDatabase context) : base(context)
        {
        }

        public List<Category> GetCategoryList()
        {
            return ListBySql("select * FROM Category");
        }
    }
}

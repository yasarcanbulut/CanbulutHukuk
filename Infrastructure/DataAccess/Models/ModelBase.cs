using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanbulutHukuk.Infrastructure.DataAccess.Models
{
    public abstract class ModelBase
    {
        public ModelBase()
        {
            
        }

        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanbulutHukuk.Web.Models.CHModels
{
    public abstract class ModelBase
    {
        public ModelBase()
        {

        }

        public long Id { get; set; }
    }
}
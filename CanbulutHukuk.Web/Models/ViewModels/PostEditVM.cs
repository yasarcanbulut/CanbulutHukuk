﻿using CanbulutHukuk.Web.Models.CHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanbulutHukuk.Web.Models.ViewModels
{
    public class PostEditVM
    {
        public Article Post { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
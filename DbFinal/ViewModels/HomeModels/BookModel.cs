using DbFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DbFinal.ViewModels.HomeModels
{
    public class BookModel
    {

        public List<Author> authorList { get; set; }

        public List<Publication> publicationList { get; set; }

        public List<Category> categoryList { get; set; }
    }
}
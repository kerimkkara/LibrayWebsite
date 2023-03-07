using DbFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFinal.ViewModels.HomeModels
{
    public class LendModel
    {
        public List<Member> memberList { get; set; }

        public List<Book> BookList { get; set; }

    }
}
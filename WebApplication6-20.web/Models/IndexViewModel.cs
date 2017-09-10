using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6_20.data;

namespace WebApplication6_20.web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Family> Families { get; set; }
    }
}
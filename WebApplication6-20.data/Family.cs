using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication6_20.data
{
    public class Family
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public int? Kids { get; set; }
        public bool IsChasidush{ get; set; }
        public Type Type { get; set; }
    }
}

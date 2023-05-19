using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Country
    {
        public int country_id { get; set; }
        public string country_name { get; set; }
        public ICollection<Account> accounts { get; set; }
        public ICollection<City> cities { get; set; }
    }
}

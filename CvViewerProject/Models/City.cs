using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class City
    {
        public City()
        {
            country = new Country();
            accounts = new List<Account>();
        }
        public int city_id { get; set; }
        public string city_name { get; set; }
        [ForeignKey(nameof(country))]
        public int country_id { get; set; }
        public Country country { get; set; }
        public ICollection<Account> accounts { get; set; }
    }
}

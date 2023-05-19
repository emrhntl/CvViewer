using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Experience
    {
        public int experience_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        [ForeignKey(nameof(person))]
        public int person_id { get; set; }
        [ForeignKey(nameof(company))]
        public int company_id { get; set; }
        [ForeignKey(nameof(position))]
        public int position_id { get; set; }
        //pozisyon
        public Position position { get; set; }
        public Person person { get; set; }
        public Company company { get; set; }
    }
}

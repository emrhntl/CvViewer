using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class PersonEdu
    {
        [ForeignKey(nameof(person))]
        public int person_id { get; set; }
        [ForeignKey(nameof(education))]
        public int edu_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public Person person { get; set; }
        public Education education { get; set; }
    }
}

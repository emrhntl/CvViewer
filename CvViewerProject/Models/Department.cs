using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Department
    {
        public int department_id { get; set; }
        public string department_name { get; set; }
        public ICollection<Education> educations { get; set; }
        public ICollection<SchoolDepart> school_departs { get; set; }
    }
}

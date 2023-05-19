using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class SchoolDepart
    {
        [ForeignKey(nameof(school))]
        public int school_id { get; set; }
        [ForeignKey(nameof(department))]
        public int department_id { get; set; }
        public School school { get; set; }
        public Department department { get; set; }
    }
}

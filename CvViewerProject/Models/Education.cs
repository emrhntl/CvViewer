using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Education
    {
        public int edu_id { get; set; }
        [ForeignKey(nameof(school))]
        public int university_id { get; set; }
        [ForeignKey(nameof(department))]
        public int department_id { get; set; }
        public ICollection<PersonEdu> person_educations { get; set; }
        public School school { get; set; }
        public Department department { get; set; }
    }
}

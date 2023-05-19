using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms.VisualStyles;

#nullable disable

namespace Cv_Viewer.Models
{
    public partial class Person
    {
        public Person()
        {
            person_ability = new HashSet<PersonAbility>();
            person_educations = new HashSet<PersonEdu>();
            experiences = new HashSet<Experience>();
        }
        public int person_id { get; set; }
        public string name { get; set; }
        public string level { get; set; }
        public string school { get; set; }
        public ICollection<Experience> experiences { get; set; }
        public ICollection<PersonEdu> person_educations { get; set; }
        public ICollection<PersonAbility> person_ability { get; set; }

    }
}


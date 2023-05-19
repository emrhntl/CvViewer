using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class PersonAbility
    {
        [ForeignKey(nameof(person))]
        public int person_id { get; set; }
        [ForeignKey(nameof(ability))]
        public int ability_id { get; set; }
        public Ability ability { get; set; }
        public Person person { get; set; }
    }
}

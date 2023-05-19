using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Ability
    {
        public Ability()
        {
            person_abilities = new HashSet<PersonAbility>();
        }
        public int ability_id { get; set; }
        public string ability_name { get; set; }
        public ICollection<PersonAbility> person_abilities { get; set; }
    }
}

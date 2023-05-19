using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Position
    {
        public Position()
        {
            experiences = new HashSet<Experience>();
        }
        public int position_id { get; set; }
        public string position_name { get; set; }
        public ICollection<Experience> experiences { get; set; }
        public ICollection<CompanyPosition> companies { get; set; }
    }
}

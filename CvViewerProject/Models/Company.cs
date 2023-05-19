using System;
using System.Collections.Generic;

#nullable disable

namespace Cv_Viewer.Models
{
    public partial class Company
    {
        public Company()
        {
            experiences = new HashSet<Experience>();
            company_positions = new HashSet<CompanyPosition>();
        }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public ICollection<Experience> experiences { get; set; }
        public ICollection<CompanyPosition> company_positions { get; set; }
    }
}

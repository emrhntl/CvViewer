using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class CompanyPosition
    {
        public CompanyPosition()
        {
            position = new Position();
            company = new Company();
        }
        [ForeignKey(nameof(company))]
        public int company_id { get; set; }
        [ForeignKey(nameof(position))]
        public int position_id { get; set; }
        public Position position { get; set; }
        public Company company { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Viewer.Models
{
    public partial class Communication
    {
        [Key, ForeignKey(nameof(account))]
        public int communication_id { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string phone_number { get; set; }
        public string linked_in { get; set; }
        public Account account { get; set; }
    }
}

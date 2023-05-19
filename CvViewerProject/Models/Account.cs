using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.PerformanceData;

#nullable disable

namespace Cv_Viewer.Models
{
    public partial class Account
    {
        public Account()
        {
            country = new Country();
            city = new City();
        }
        public int account_id { get; set; }
        public string picture_path { get; set; }
        public string e_mail { get; set; }
        public string account_type { get; set; }
        public string password { get; set; }
        [ForeignKey(nameof(country))]
        public int country_id { get; set; }
        [ForeignKey(nameof(city))]
        public int city_id { get; set; }
        public Country country { get; set; }
        public City city { get; set; }
        public Communication communication { get; set; }
    }
}

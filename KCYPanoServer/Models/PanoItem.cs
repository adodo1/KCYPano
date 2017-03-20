using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KCYPano.Models
{
    public class PanoItem
    {
        [Key]
        public string uid { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public DateTime shottime { get; set; }
        public int heading { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string author { get; set; }
        public string remark { get; set; }
        public DateTime maketime { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KCYPano.Models
{
    public class TileItem
    {
        public string uid { get; set; }
        public string path { get; set; }
        public byte[] tile { get; set; }
    }
}
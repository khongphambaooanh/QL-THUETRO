using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTHUETRO_BAOOANH.Models
{
    public class Mail
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
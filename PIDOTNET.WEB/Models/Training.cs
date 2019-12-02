using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDOTNET.WEB.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Training
    {
        public int id { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime? endDate { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public int nbr_participants { get; set; }
        public DateTime? startDate { get; set; }
        


    }
}
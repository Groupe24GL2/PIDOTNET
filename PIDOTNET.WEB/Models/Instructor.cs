﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDOTNET.WEB.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Instructor
    {
        public int id { get; set; }
        public string email { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }

    }
}
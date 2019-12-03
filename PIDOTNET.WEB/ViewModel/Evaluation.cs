using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDOTNET.WEB.ViewModel
{
    public class Evaluation
    {




        public int id { get; set; } /// <summary>
        /// min id
        /// </summary>
        public string nameEvaluation { get; set; }
        public string typeEvaluation { get; set; }
        public float scoreEvaluation { get; set; }
        public Boolean etat { get; set; }



    }
}
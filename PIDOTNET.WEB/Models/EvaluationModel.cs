using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIDOTNET.WEB.Models
{
    public class EvaluationModel
    {

        public int id { get; set; }
        public string nameEvaluation { get; set; }
        public string typeEvaluation { get; set; }
        public float scoreEvaluation { get; set; }
        public Boolean etat { get; set; }
             
            
            
    }
    public class AddEvalViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string nameEvaluation { get; set; }

        [Required]
        [Display(Description = "description")]
        public string typeEvaluation { get; set; }

        [Required]
        [Display(Description = "score")]
        public float scoreEvaluation { get; set; }
        [Display(Description = "etat")]
        public Boolean etat { get; set; }



    }

}
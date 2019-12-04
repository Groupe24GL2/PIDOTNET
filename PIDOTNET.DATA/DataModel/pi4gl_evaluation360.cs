namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.[pi4gl.evaluation360]")]
    public partial class pi4gl_evaluation360
    {
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool etat { get; set; }

        [StringLength(255)]
        public string nameEvaluation { get; set; }

        public float? noteEvaluation { get; set; }

        [StringLength(255)]
        public string avisEvaluation { get; set; }
    }
}

namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.evaluation360")]
    public partial class evaluation360
    {
        [Key]
        public int id_eval { get; set; }

        [StringLength(30)]
        public string nom { get; set; }

        [StringLength(30)]
        public string description { get; set; }

        [StringLength(30)]
        public string avis { get; set; }

        public float? note { get; set; }
    }
}

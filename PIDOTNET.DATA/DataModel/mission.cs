namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.mission")]
    public partial class mission
    {
        public int id { get; set; }

        public DateTime? dateDeb { get; set; }

        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string place { get; set; }

        public int? repaymentMethod { get; set; }
    }
}

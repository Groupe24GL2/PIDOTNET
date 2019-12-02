namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.ficheevaluation")]
    public partial class ficheevaluation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEmployee { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEvaluation { get; set; }

        public float averageRate { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        [StringLength(255)]
        public string desription { get; set; }

        public int? noteCommunication { get; set; }

        public int? noteDeadlineRespect { get; set; }

        public int? noteInteraction { get; set; }

        public int? noteLeadership { get; set; }

        public int? noteOrganisation { get; set; }

        public int? noteRegularity { get; set; }

        public int? noteTeamWork { get; set; }

        public int? noteWorkQuality { get; set; }

        public virtual employee employee { get; set; }

        public virtual evaluation evaluation { get; set; }
    }
}

namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.task")]
    public partial class task
    {
        public int id { get; set; }

        public int idM { get; set; }

        public int? state { get; set; }

        [Column("task")]
        [StringLength(255)]
        public string task1 { get; set; }
    }
}

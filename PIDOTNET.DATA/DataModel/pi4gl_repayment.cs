namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.[pi4gl.repayment]")]
    public partial class pi4gl_repayment
    {
        public int id { get; set; }

        public int idEmp { get; set; }

        public int idMess { get; set; }

        public int money { get; set; }

        public int ribEmp { get; set; }
    }
}

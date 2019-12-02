namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.missionexpenses")]
    public partial class missionexpens
    {
        public int id { get; set; }

        public int accommodationFees { get; set; }

        public int ceiling { get; set; }

        public int idMission { get; set; }

        public int mealFees { get; set; }

        public int transportationCosts { get; set; }
    }
}

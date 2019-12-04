namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi4gl.[pi4gl.evaluation]")]
    public partial class pi4gl_evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pi4gl_evaluation()
        {
            pi4gl_ficheevaluation = new HashSet<pi4gl_ficheevaluation>();
        }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool etat { get; set; }

        [StringLength(255)]
        public string nameEvaluation { get; set; }

        public float scoreEvaluation { get; set; }

        [StringLength(255)]
        public string typeEvaluation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pi4gl_ficheevaluation> pi4gl_ficheevaluation { get; set; }
    }
}

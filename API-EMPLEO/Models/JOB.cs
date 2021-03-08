namespace API_EMPLEO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JOB")]
    public partial class JOB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOB()
        {
            APPLYJOB = new HashSet<APPLYJOB>();
        }

        public int jobId { get; set; }

        [Required]
        [StringLength(500)]
        public string title { get; set; }

        [Required]
        public string descriptionJob { get; set; }

        [Required]
        public string requirements { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateStart { get; set; }

        [Required]
        [StringLength(500)]
        public string companyName { get; set; }

        [Required]
        [StringLength(500)]
        public string companyAdress { get; set; }

        [Required]
        [StringLength(100)]
        public string schedule { get; set; }

        [StringLength(100)]
        public string contractJob { get; set; }

        [StringLength(100)]
        public string modality { get; set; }

        public string career { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPLYJOB> APPLYJOB { get; set; }
    }
}

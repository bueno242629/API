namespace API_EMPLEO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            APPLYJOB = new HashSet<APPLYJOB>();
            MAILBOX = new HashSet<MAILBOX>();
        }

        [Key]
        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userPass { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string lastName { get; set; }

        public byte[] cv { get; set; }

        [Required]
        [StringLength(3)]
        public string rol { get; set; }

        [StringLength(500)]
        public string career { get; set; }

        public string cvName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPLYJOB> APPLYJOB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAILBOX> MAILBOX { get; set; }
    }
}

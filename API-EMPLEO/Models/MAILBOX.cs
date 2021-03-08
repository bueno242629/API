namespace API_EMPLEO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAILBOX")]
    public partial class MAILBOX
    {
        [Key]
        public int mailId { get; set; }

        [Required]
        public string comment { get; set; }

        public int? userId { get; set; }

        public virtual USERS USERS { get; set; }
    }
}

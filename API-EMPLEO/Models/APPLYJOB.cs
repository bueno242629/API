namespace API_EMPLEO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APPLYJOB")]
    public partial class APPLYJOB
    {
        [Key]
        public int applyId { get; set; }

        public int? userId { get; set; }

        public int? jobId { get; set; }

        public virtual JOB JOB { get; set; }

        public virtual USERS USERS { get; set; }
    }
}

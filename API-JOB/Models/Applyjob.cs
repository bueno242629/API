using System;
using System.Collections.Generic;

namespace API_JOB.Models
{
    public partial class Applyjob
    {
        public int ApplyId { get; set; }
        public int? UserId { get; set; }
        public int? JobId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Users User { get; set; }
    }
}

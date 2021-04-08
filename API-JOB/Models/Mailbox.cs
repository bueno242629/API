using System;
using System.Collections.Generic;

namespace API_JOB.Models
{
    public partial class Mailbox
    {
        public int MailId { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public string dateStart { get; set; }
        public string name { get; set; }

        public virtual Users User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_JOB.Models
{
    public partial class Users
    {
        public Users()
        {
            Applyjob = new HashSet<Applyjob>();
            Mailbox = new HashSet<Mailbox>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] Cv { get; set; }
        public string CvName { get; set; }
        public string Rol { get; set; }
        public string Career { get; set; }

        public virtual ICollection<Applyjob> Applyjob { get; set; }
        public virtual ICollection<Mailbox> Mailbox { get; set; }
    }
}

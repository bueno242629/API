using System;
using System.Collections.Generic;

namespace API_JOB.Models
{
    public partial class Job
    {
        public Job()
        {
            Applyjob = new HashSet<Applyjob>();
        }

        public int JobId { get; set; }
        public string Title { get; set; }
        public string DescriptionJob { get; set; }
        public string Requirements { get; set; }
        public string DateStart { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string Schedule { get; set; }
        public string ContractJob { get; set; }
        public string Modality { get; set; }
        public string Career { get; set; }

        public virtual ICollection<Applyjob> Applyjob { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_JOB.Models
{
    public partial class Graduateplus
    {
        public int GradId { get; set; }
        public string Name { get; set; }
        public string DescriptionGrad { get; set; }
        public string Career { get; set; }
        public byte[] Photo { get; set; }
    }
}

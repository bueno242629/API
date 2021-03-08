namespace API_EMPLEO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GRADUATEPLUS
    {
        [Key]
        public int gradId { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        [Required]
        public string descriptionGrad { get; set; }

        [Required]
        [StringLength(500)]
        public string career { get; set; }

        public byte[] photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_EMPLEO.Models
{
    [Table("CAREERS")]
    public class CAREERS
    {
        [Key]
        public int careerId { get; set; }

        public string career { get; set; }

        public string area { get; set; }
    }
}
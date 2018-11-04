using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AxcelCapital.Models
{
    public class Query
    {
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [StringLength(11)]
        public string mobile { get; set; }
        [Required]
        [StringLength(100)]
        public string companyName{ get; set; }
        public string turnOver { get; set; }
        public string message { get; set; }
    }
}
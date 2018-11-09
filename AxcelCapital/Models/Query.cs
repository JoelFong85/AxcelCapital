using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AxcelCapital.Models
{
    public class Query
    {
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(20, ErrorMessage = "Maximum length 20 letters")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(20, ErrorMessage = "Maximum length 20 letters")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [StringLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        [StringLength(11, ErrorMessage = "Maximum length 11 characters")]
        [RegularExpression(@"(?<normal>(\+?65)?(8|9)[0-9]{7})|(?<mobile>(\+?65)?6[0-9]{7})", ErrorMessage = "Please enter a valid mobile number")]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Please enter your company name")]
        [StringLength(100)]
        public string companyName{ get; set; }

        public string turnOver { get; set; }

        public string message { get; set; }
    }
}
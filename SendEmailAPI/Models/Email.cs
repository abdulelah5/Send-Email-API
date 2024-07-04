using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SendEmailAPI.Models
{
    public class Email
    {
        [Required(ErrorMessage = "From is required")]
        public string From { get; set; }
        [Required(ErrorMessage = "To is required")]
        public string To { get; set; }
        [Required(ErrorMessage = "Message Body is required")]
        public string Body { get; set; }        
        public string Subject { get; set; }
    }
}
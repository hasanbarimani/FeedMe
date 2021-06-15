using FeedMe.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedMe.Models.Models
{
   public class FeedBack
    {
        public int Id { get; set; }
        [CustomRequired]
        public byte behavior { get; set; }
        [CustomRequired]
        public byte Transportation { get; set; }
        [CustomRequired]
        public byte Services { get; set; }
        [CustomRequired]
        public string WhyUS { get; set; }
        [Required(ErrorMessage = "you Have Forgotten Fill This!")]
        public byte HowKnow { get; set; }
        [Required(ErrorMessage = "you Have Forgotten Fill This!")]
        public bool Introduce { get; set; }
        [Required(ErrorMessage = "you Have Forgotten Fill This!")]
        public string Suggestions { get; set; }
        
    }
}

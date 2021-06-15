using FeedMe.Models.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedMe.Models.ViewModels
{
    public class CooperationViewModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }


        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".pdf" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile UploadFile { get; set; }

    }
}

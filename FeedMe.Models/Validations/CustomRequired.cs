using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedMe.Models.Validations
{
    public class CustomRequired : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            string errorType;
            if (value == null)
            {
                errorType = "required";
            }
           
            else
            {
                return ValidationResult.Success;
            }
            ErrorMessage = $"{validationContext.DisplayName}  field is {errorType}.";
            return new ValidationResult(ErrorMessage);
        }

    }

}

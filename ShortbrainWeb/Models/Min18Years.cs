using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortbrainWeb.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User) validationContext.ObjectInstance;
            if (user.MembershipTypeId == MembershipType.Unknown || user.MembershipTypeId == MembershipType.Begginer)
                return ValidationResult.Success;

            if(user.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - user.Birthdate.Value.Year;
            return (age >= 18 ) ? 
                ValidationResult.Success 
                : new ValidationResult("User must be at least 18 years old");
        }
    }
}
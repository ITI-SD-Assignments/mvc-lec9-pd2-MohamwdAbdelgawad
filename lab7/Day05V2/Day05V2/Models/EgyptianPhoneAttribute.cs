namespace Day05V2.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EgyptianPhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phone = value?.ToString();
            if (string.IsNullOrEmpty(phone)) return ValidationResult.Success;

            if (!phone.StartsWith("01") || phone.Length != 11)
                return new ValidationResult("Invalid Egyptian phone number");

            return ValidationResult.Success;
        }
    }
}
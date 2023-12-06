using System.ComponentModel.DataAnnotations;

namespace api.Infra.Utility
{
    public class ValidarIdadeAttr : ValidationAttribute
    {
        private readonly int _minimumAge;

        public ValidarIdadeAttr(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthdate)
            {
                var age = DateTime.Now.Year - birthdate.Year;
                if (birthdate > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if (age < _minimumAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

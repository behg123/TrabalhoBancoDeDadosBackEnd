using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model.Shared.Validation
{
    public class LoginValidationPattern
    {
    }

    /// <summary>
    /// This class is used as an Attribute in the LoginModel class.
    /// Class responsible for validating the password.
    /// </summary>
    public class passwordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                if (!(value is string valueAsString))
                {
                    return new ValidationResult(ErrorMessage = "Senha inválida");
                }

                if (valueAsString.Contains('\r') || valueAsString.Contains(' ') || valueAsString.Contains('\n'))
                {
                    return new ValidationResult(ErrorMessage = "Senha inválida");
                }

                string strPasswordModel = "^.*(?=.{8,})(?=.*[@#$%^&+=])(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).*$";
                if (!string.IsNullOrEmpty(valueAsString) && Regex.IsMatch(valueAsString, strPasswordModel))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage = "Senha inválida");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    /// <summary>
    /// This class is used as an Attribute in the LoginModel class.
    /// Class responsible for validating the name.
    /// </summary>
    public class nameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (!(value is string valueAsString))
            {
                return new ValidationResult(ErrorMessage = "Nome inválido, o nome deve ter entre 3 e 50 caracteres.");
            }

            if (valueAsString.Trim().Length < valueAsString.Length)
            {
                return new ValidationResult(ErrorMessage = "Nome inválido, o nome não deve conter espaços no início ou no fim.");
            }

            if (!string.IsNullOrEmpty((string)value) && (valueAsString.Trim().Length > 3 && valueAsString.Trim().Length < 50))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage = "Nome inválido, o nome deve ter entre 3 e 50 caracteres.");
        }
    }

}

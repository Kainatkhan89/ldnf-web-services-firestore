using System;
using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.Common.Enums;

namespace learndotnetfast_web_services.Common.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ValidColorAttribute : ValidationAttribute
    {
        public ValidColorAttribute()
        {
            ErrorMessage = "Invalid module color value";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string colorString = value as string;

            if (string.IsNullOrEmpty(colorString)) return false;

            // Try to parse the input string to the Enum
            return Enum.TryParse(colorString, out Color parsedColor);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.Common.Enums;

namespace learndotnetfast_web_services.Common.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ValidIconAttribute : ValidationAttribute
    {
        public ValidIconAttribute()
        {
            ErrorMessage = "Invalid module icon value";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string iconString = value as string;

            if (string.IsNullOrEmpty(iconString)) return false;

            // Try to parse the input string to the Enum
            return Enum.TryParse(iconString, out Icon parsedIcon);
        }
    }
}

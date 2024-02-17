using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubMembership.API
{
    public delegate bool DelValidateRequiredField(string fieldValue);
    public delegate bool DelValidateStringLength(string fieldValue, int minLength, int maxLength);
    public delegate bool DelValidateRegexPatternForField(string fieldValue, string regexPattern);
    public delegate bool DelValidateDateField(string fieldValue, out DateTime date);
    public delegate bool DelValidateFieldComparision(string fieldValue1, string fieldValue2);
    public class AllValidatorDelegates
    {
        private static DelValidateRequiredField delValidateRequiredField = null;
        private static DelValidateStringLength delValidateStringLength = null;
        private static DelValidateRegexPatternForField delValidateRegexPatternForField = null;
        private static DelValidateDateField delValidateDateField = null;
        private static DelValidateFieldComparision delValidateFieldComparision = null;

        public static DelValidateRequiredField DelValidateRequiredField
        {
            get
            {
                if(delValidateRequiredField is null)
                {
                    delValidateRequiredField = new DelValidateRequiredField(ValidateRequiredField);
                }
                return delValidateRequiredField;
            }
        }
        public static DelValidateStringLength DelValidateStringLength
        {
            get
            {
                if(delValidateStringLength is null)
                {
                    delValidateStringLength = new DelValidateStringLength(ValidateStringLength);
                }
                return delValidateStringLength;
            }
        }
        public static DelValidateRegexPatternForField DelValidateRegexPatternForField
        {
            get
            {
                if(delValidateRegexPatternForField is null)
                {
                    delValidateRegexPatternForField = new DelValidateRegexPatternForField(ValidateRegexPatternForField);
                }
                return delValidateRegexPatternForField;
            }
        }
        public static DelValidateDateField DelValidateDateField
        {
            get
            {
                if(delValidateDateField is null)
                {
                    delValidateDateField = new DelValidateDateField(ValidateDateField);
                }
                return delValidateDateField;
            }
        }
        public static DelValidateFieldComparision DelValidateFieldComparision
        {
            get
            {
                if(delValidateFieldComparision is null)
                {
                    delValidateFieldComparision = new DelValidateFieldComparision(ValidateFieldComparision);
                }
                return delValidateFieldComparision;
            }

        }

        public static bool ValidateRequiredField(string fieldValue)
        {
            return !string.IsNullOrEmpty(fieldValue);
        }
        public static bool ValidateStringLength(string fieldValue, int minLength, int maxLength)
        {
            string value = fieldValue.NullCheckTrim();
            return value.Length >= minLength && value.Length <= maxLength;
        }
        public static bool ValidateRegexPatternForField(string fieldValue, string regexPattern)
        {
            string value = fieldValue.NullCheckTrim();
            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(value);
        }
        public static bool ValidateDateField(string fieldValue, out DateTime date)
        {
            string value = fieldValue.NullCheckTrim();
            return DateTime.TryParse(value, out date);
        }
        public static bool ValidateFieldComparision(string fieldValue1, string fieldValue2)
        {
            string value1 = fieldValue1.NullCheckTrim();
            string value2 = fieldValue2.NullCheckTrim();
            return value1.Equals(value2);
        }
    }
}

using ClubMembership.API;
using ClubMembership.Console.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.FieldValidators
{
    public class UserRegistrationFieldValidator : IFieldValidator
    {
        private DelValidateRequiredField delValidateRequiredField;
        private DelValidateStringLength delValidateStringLength;
        private DelValidateRegexPatternForField delValidateRegexPatternField;
        private DelValidateDateField delValidateDateField;
        private DelValidateFieldComparision delValidateFieldComparision;

        private DelValidateField delValidateField;
        private string[] fieldArray;
        //override
        public DelValidateField DelValidateField
        {
            get
            {
                if(delValidateField is null)
                {
                    delValidateField = new DelValidateField(ValidateField);
                }
                return delValidateField;
            }
        }
        //override
        public string[] FieldArray
        {
            get
            {
                if(fieldArray is null)
                {
                    fieldArray = new string[Enum.GetNames<UserRegistrationField>().Length];
                }
                return fieldArray;
            }
        }

        public void InitializeDelegates()
        {
            this.delValidateRequiredField = AllValidatorDelegates.DelValidateRequiredField;
            this.delValidateStringLength = AllValidatorDelegates.DelValidateStringLength;
            this.delValidateRegexPatternField = AllValidatorDelegates.DelValidateRegexPatternForField;
            this.delValidateDateField = AllValidatorDelegates.DelValidateDateField;
            this.delValidateFieldComparision = AllValidatorDelegates.DelValidateFieldComparision;
        }

        public bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string errorMessage)
        {
            errorMessage = string.Empty;

            UserRegistrationField userRegistrationField = (UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case UserRegistrationField.EmailId:
                    break;
                default:
                    throw new InvalidDataException("The field doesn't exist");
            }

            return errorMessage.Equals(string.Empty);
        }
    }
}

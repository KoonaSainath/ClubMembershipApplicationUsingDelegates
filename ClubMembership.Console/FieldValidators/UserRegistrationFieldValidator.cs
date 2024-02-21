using ClubMembership.API;
using ClubMembership.Console.Constants;
using ClubMembership.Console.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.FieldValidators
{
    public class UserRegistrationFieldValidator : IFieldValidator
    {
        private const int NAME_MIN_LENGTH = 2;
        private const int NAME_MAX_LENGTH = 50;
        private DelValidateRequiredField delValidateRequiredField;
        private DelValidateStringLength delValidateStringLength;
        private DelValidateRegexPatternForField delValidateRegexPatternField;
        private DelValidateDateField delValidateDateField;
        private DelValidateFieldComparision delValidateFieldComparision;

        private DelValidateField delValidateField;
        private string[] fieldArray;
        private DelDoesEmailIdAlreadyExist delDoesEmailIdAlreadyExist;

        delegate bool DelDoesEmailIdAlreadyExist(string emailId);
        private IRegister register;
        public UserRegistrationFieldValidator(IRegister register)
        {
            this.register = register;
        }

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

            this.delDoesEmailIdAlreadyExist = new DelDoesEmailIdAlreadyExist(this.register.DoesEmailIdAlreadyExist);
        }

        public bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string errorMessage)
        {
            errorMessage = string.Empty;

            UserRegistrationField userRegistrationField = (UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case UserRegistrationField.EmailId:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    errorMessage = (errorMessage.IsEmpty() && !this.delValidateRegexPatternField(fieldValue, RegularExpressionPatternConstants.EmailIdRegexPattern)) ? $"Invalid email id for field: {Enum.GetName<UserRegistrationField>(userRegistrationField)}" : errorMessage;
                    errorMessage = (errorMessage.IsEmpty() && this.delDoesEmailIdAlreadyExist(fieldValue)) ? $"The entered email id is already registered with the cycling club membership!" : errorMessage;
                    break;
                case UserRegistrationField.Password:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    errorMessage = (errorMessage.IsEmpty() && !this.delValidateRegexPatternField(fieldValue, RegularExpressionPatternConstants.PasswordRegexPattern) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} must contain minimum 8 and maximum 15 alphanumeric and special characters" : errorMessage);
                    break;
                case UserRegistrationField.ConfirmedPassword:
                    errorMessage = !this.delValidateFieldComparision(fieldValue, fieldArray[(int)UserRegistrationField.Password]) ? "The passwords didn't match" : string.Empty;
                    break;
                case UserRegistrationField.FirstName:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    errorMessage = (errorMessage.IsEmpty() && !this.delValidateStringLength(fieldValue, NAME_MIN_LENGTH, NAME_MAX_LENGTH)) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} must contain minimum {NAME_MIN_LENGTH} characters and maximum {NAME_MAX_LENGTH} characters" : errorMessage;
                    break;
                case UserRegistrationField.LastName:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    errorMessage = (errorMessage.IsEmpty() && !this.delValidateStringLength(fieldValue, NAME_MIN_LENGTH, NAME_MAX_LENGTH)) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} must contain minimum {NAME_MIN_LENGTH} characters and maximum {NAME_MAX_LENGTH} characters" : errorMessage;
                    break;
                case UserRegistrationField.DateOfBirth:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    errorMessage = (errorMessage.IsEmpty() && !this.delValidateDateField(fieldValue, out DateTime dateTime)) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} must be in proper date format" : errorMessage;
                    break;
                case UserRegistrationField.PhoneNumber:
                case UserRegistrationField.AddressLine1:
                case UserRegistrationField.AddressLine2:
                case UserRegistrationField.City:
                case UserRegistrationField.PostalCode:
                    errorMessage = !this.delValidateRequiredField(fieldValue) ? $"The field: {Enum.GetName<UserRegistrationField>(userRegistrationField)} is required" : string.Empty;
                    break;
                default:
                    throw new InvalidDataException("The field doesn't exist");
            }

            return errorMessage.IsEmpty();
        }
    }
}

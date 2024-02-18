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

        public bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string errorMessage)
        {
            errorMessage = string.Empty;

            UserRegistrationField userRegistrationField = (UserRegistrationField)fieldIndex;


            return errorMessage.Equals(string.Empty);
        }
    }
}

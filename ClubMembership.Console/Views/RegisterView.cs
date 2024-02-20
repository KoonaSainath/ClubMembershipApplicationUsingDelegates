using ClubMembership.Console.Constants;
using ClubMembership.Console.Data;
using ClubMembership.Console.FieldValidators;
using ClubMembership.Console.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Views
{
    public class RegisterView : IView
    {
        public RegisterView(IFieldValidator fieldValidator)
        {
            this.FieldValidator = fieldValidator;
        }
        public IFieldValidator FieldValidator { get; set; }

        public void RunTheView()
        {
            this.FieldValidator.FieldArray[(int)UserRegistrationField.EmailId] = CollectValidatedFieldValue(UserRegistrationField.EmailId, "Please enter your email id: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.Password] = CollectValidatedFieldValue(UserRegistrationField.Password, "Please set password: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.ConfirmedPassword] = CollectValidatedFieldValue(UserRegistrationField.ConfirmedPassword, "Please re-enter your password to confirm: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.FirstName] = CollectValidatedFieldValue(UserRegistrationField.FirstName, "Please enter your first name: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.LastName] = CollectValidatedFieldValue(UserRegistrationField.LastName, "Please enter your last name: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.DateOfBirth] = CollectValidatedFieldValue(UserRegistrationField.DateOfBirth, "Please enter your date of birth in valid format: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.PhoneNumber] = CollectValidatedFieldValue(UserRegistrationField.PhoneNumber, "Please enter your phone number: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.AddressLine1] = CollectValidatedFieldValue(UserRegistrationField.AddressLine1, "Please enter your address line 1: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.AddressLine2] = CollectValidatedFieldValue(UserRegistrationField.AddressLine2, "Please enter your address line 2: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.City] = CollectValidatedFieldValue(UserRegistrationField.City, "Please enter your city name: ");
            this.FieldValidator.FieldArray[(int)UserRegistrationField.PostalCode] = CollectValidatedFieldValue(UserRegistrationField.PostalCode, "Please enter postal code: ");
            IRegister register = new Register();
            register.RegisterUser(this.FieldValidator.FieldArray);
            ConsoleThemes.SetTheme(ConsoleTheme.Success);
            ConsoleWriters.WriteToConsoleWithNewLine("User registration is successful!");
            ConsoleThemes.SetTheme(ConsoleTheme.Default);
            IView loginView = new LoginView();
            loginView.RunTheView();
        }

        private string CollectValidatedFieldValue(UserRegistrationField fieldIndex, string prompt)
        {
            string errorMessage = string.Empty;
            string value = string.Empty;
            bool isValid = false;
            do
            {
                ConsoleWriters.WriteToConsoleWithoutNewLine(prompt);
                value = System.Console.ReadLine();
                isValid = this.FieldValidator.DelValidateField((int)fieldIndex, value, this.FieldValidator.FieldArray, out errorMessage);
                if(isValid)
                {
                    ConsoleThemes.SetTheme(ConsoleTheme.Success);
                    ConsoleWriters.WriteToConsoleWithNewLine("Validated");
                    ConsoleThemes.SetTheme(ConsoleTheme.Default);
                }
                else
                {
                    ConsoleThemes.SetTheme(ConsoleTheme.Failure);
                    ConsoleWriters.WriteToConsoleWithNewLine(errorMessage);
                    ConsoleThemes.SetTheme(ConsoleTheme.Default);
                }
            } while (!isValid);
            return value;
        }
    }
}

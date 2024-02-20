using ClubMembership.Console.Data;
using ClubMembership.Console.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Views
{
    public static class ViewFactory
    {
        public static IView GetMainViewInstance()
        {
            IRegister register = new Register();
            IFieldValidator userRegistrationValidator = new UserRegistrationFieldValidator(register);
            userRegistrationValidator.InitializeDelegates();
            IView loginView = new LoginView();
            IView registerView = new RegisterView(userRegistrationValidator);
            IView mainView = new MainView(loginView, registerView);
            return mainView;
        }
    }
}

using ClubMembership.Console.Data;
using ClubMembership.Console.FieldValidators;
using ClubMembership.Console.HelperClasses;
using ClubMembership.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Views
{
    public class LoginView : IView
    {
        public IFieldValidator FieldValidator => null;

        public async Task RunTheView()
        {
            ConsoleWriters.ClearConsole();
            ConsoleWriters.WriteHeading();
            ConsoleWriters.WriteLogin();

            ConsoleWriters.WriteToConsoleWithoutNewLine("Please enter your email id: ");
            string emailId = System.Console.ReadLine();

            ConsoleWriters.WriteToConsoleWithoutNewLine("Please enter password: ");
            string password = System.Console.ReadLine();

            ILogin login = new Login();
            User user = login.GetUser(emailId, password);
            if(user != null)
            {
                IView welcomeScreenView = new WelcomeScreenView(user);
                await welcomeScreenView.RunTheView();
            }
            else
            {
                await ConsoleThemes.SetTheme(ConsoleTheme.Failure);
                ConsoleWriters.WriteToConsoleWithNewLine("The user with this email id and password doesn't exist");
                await ConsoleThemes.SetTheme(ConsoleTheme.Default);
                System.Console.ReadKey();
            }
        }
    }
}

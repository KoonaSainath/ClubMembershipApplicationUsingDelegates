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
    public class WelcomeScreenView : IView
    {
        private User user;
        public WelcomeScreenView(User user) 
        {
            this.user = user;
        }
        public IFieldValidator FieldValidator => null;

        public void RunTheView()
        {
            ConsoleWriters.ClearConsole();
            ConsoleWriters.WriteHeading();
            string welcomeMessage = $"Welcome {user.FirstName} {user.LastName}! You are a proud member of our cycling club membership!";
            ConsoleThemes.SetTheme(ConsoleTheme.Success);
            ConsoleWriters.WriteToConsoleWithNewLine(welcomeMessage);
            ConsoleThemes.SetTheme(ConsoleTheme.Default);
            System.Console.ReadKey();
        }
    }
}

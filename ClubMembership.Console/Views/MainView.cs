using ClubMembership.Console.FieldValidators;
using ClubMembership.Console.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Views
{
    public class MainView : IView
    {
        private IView loginView;
        private IView registerView;
        public MainView(IView loginView, IView registerView)
        {
            this.loginView = loginView;
            this.registerView = registerView;
        }
        public IFieldValidator FieldValidator => null;

        public void RunTheView()
        {
            ConsoleWriters.ClearConsole();
            ConsoleThemes.SetTheme(ConsoleTheme.Default);
            ConsoleWriters.WriteHeading();
            ConsoleWriters.WriteToConsoleWithNewLine("Press 'l' to login or 'r' to register");
            ConsoleKey consoleKey = System.Console.ReadKey().Key;
            if(consoleKey == ConsoleKey.L)
            {
                this.loginView.RunTheView();
            }
            else if(consoleKey == ConsoleKey.R)
            {
                this.registerView.RunTheView();
            }
            else
            {
                ConsoleWriters.WriteToConsoleWithNewLine("Invalid user input. Shutting down the application...");
                System.Console.ReadKey();
            }
        }
    }
}

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

        public async Task RunTheView()
        {
            ConsoleWriters.ClearConsole();
            await ConsoleThemes.SetTheme(ConsoleTheme.Default);
            ConsoleWriters.WriteHeading();
            ConsoleWriters.WriteToConsoleWithNewLine("Press 'l' to login or 'r' to register");
            ConsoleKey consoleKey = System.Console.ReadKey().Key;
            ConsoleWriters.WriteToConsoleWithNewLine(string.Empty);
            if(consoleKey == ConsoleKey.L)
            {
                await this.loginView.RunTheView();
            }
            else if(consoleKey == ConsoleKey.R)
            {
                await this.registerView.RunTheView();
            }
            else
            {
                ConsoleWriters.WriteToConsoleWithNewLine("Invalid user input. Shutting down the application...");
                System.Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.HelperClasses
{
    public static class ConsoleWriters
    {
        private static string heading;
        private static string register;
        private static string login;

        public static string Heading
        {
            get
            {
                heading = "Club membership registration";
                return $"{heading}{Environment.NewLine}{new string('-',heading.Length)}";
            }
        }
        public static string Registration
        {
            get
            {
                register = "Register";
                return $"{register}{Environment.NewLine}{new string('-',register.Length)}";
            }
        }
        public static string Login
        {
            get
            {
                login = "Login";
                return $"{login}{Environment.NewLine}{new string('-',login.Length)}";
            }
        }
        
        public static void WriteHeading()
        {
            System.Console.WriteLine(Heading);
            System.Console.WriteLine();
        }
        public static void WriteRegistration()
        {
            System.Console.WriteLine(Registration);
            System.Console.WriteLine();
        }
        public static void WriteLogin()
        {
            System.Console.WriteLine(Login);
            System.Console.WriteLine();
        }
        public static void ClearConsole()
        {
            System.Console.Clear();
        }
        public static void WriteToConsoleWithoutNewLine(string message)
        {
            System.Console.Write(message);
        }
        public static void WriteToConsoleWithNewLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}

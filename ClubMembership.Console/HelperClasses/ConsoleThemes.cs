using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.HelperClasses
{
    public enum ConsoleTheme
    {
        Success,
        Failure,
        Default
    }
    public static class ConsoleThemes
    {
        public static void SetTheme(ConsoleTheme theme)
        {
            switch (theme)
            {
                case ConsoleTheme.Success:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case ConsoleTheme.Failure:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.BackgroundColor = ConsoleColor.Red;
                    break;
                default:
                    System.Console.ResetColor();
                    break;
            }
        }
    }
}

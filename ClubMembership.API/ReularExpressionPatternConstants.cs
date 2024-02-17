using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.API
{
    public class ReularExpressionPatternConstants
    {
        //sample format: user@email.com
        public static string EmailIdRegexPattern = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";

        //8 to 15 alphanumeric special characters
        public static string PasswordRegexPattern = "^([a-zA-Z0-9@*#]{8,15})$";
    }
}

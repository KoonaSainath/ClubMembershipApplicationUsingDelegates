using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.API
{
    public static class ClubMembershipExtensionMethods
    {
        public static string NullCheckTrim(this string value)
        {
            string result = string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
            return result;
        }
        public static bool IsEmpty(this string value)
        {
            string result = value.NullCheckTrim();
            return string.IsNullOrEmpty(result);
        }
    }
}

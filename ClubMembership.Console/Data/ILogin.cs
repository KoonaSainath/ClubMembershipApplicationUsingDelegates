using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Data
{
    public interface ILogin
    {
        bool IsLoginSuccessful(string emailId, string password);
    }
}

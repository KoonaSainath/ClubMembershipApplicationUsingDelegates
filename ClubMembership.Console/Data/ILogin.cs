using ClubMembership.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Data
{
    public interface ILogin
    {
        User GetUser(string emailId, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Data
{
    public interface IRegister
    {
        void RegisterUser(string[] fields);
        bool DoesEmailIdAlreadyExist(string emailId);
    }
}

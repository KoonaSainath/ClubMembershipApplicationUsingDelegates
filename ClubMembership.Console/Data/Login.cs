using ClubMembership.API;
using ClubMembership.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Data
{
    public class Login : ILogin
    {
        public User GetUser(string emailId, string password)
        {
            User userFromDB = null;
            using (ClubMembershipDbContext dbContext = new ClubMembershipDbContext())
            {
                userFromDB = dbContext.Users.Where(user => user.EmailId.Trim().ToLower() == emailId.Trim().ToLower() 
                && user.Password == password).FirstOrDefault();
            }
            return userFromDB;
        }
    }
}

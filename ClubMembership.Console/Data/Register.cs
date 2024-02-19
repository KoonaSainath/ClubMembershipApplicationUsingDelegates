using ClubMembership.API;
using ClubMembership.Console.Constants;
using ClubMembership.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Data
{
    public class Register : IRegister
    {
        public bool DoesEmailIdAlreadyExist(string emailId)
        {
            bool exists;
            using (ClubMembershipDbContext dbContext = new ClubMembershipDbContext())
            {
                exists = dbContext.Users.Any(user => user.EmailId.GetLowerCaseString() == emailId.GetLowerCaseString());
            }
            return exists;
        }

        public void RegisterUser(string[] fields)
        {
            User user = new User()
            {
                EmailId = fields[(int)UserRegistrationField.EmailId],
                Password = fields[(int)UserRegistrationField.Password],
                ConfirmedPassword = fields[(int)UserRegistrationField.ConfirmedPassword],
                FirstName = fields[(int)UserRegistrationField.FirstName],
                LastName = fields[(int)UserRegistrationField.LastName],
                DateOfBirth = DateTime.Parse(fields[(int)UserRegistrationField.DateOfBirth]).ToString("yyyy-MM-dd"),
                PhoneNumber = fields[(int)UserRegistrationField.PhoneNumber],
                AddressLine1 = fields[(int)UserRegistrationField.AddressLine1],
                AddressLine2 = fields[(int)UserRegistrationField.AddressLine2],
                City = fields[(int)UserRegistrationField.City],
                PostalCode = fields[(int)UserRegistrationField.PostalCode]
            };
            using(ClubMembershipDbContext dbContext = new ClubMembershipDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }
    }
}

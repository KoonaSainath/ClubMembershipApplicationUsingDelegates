using ClubMembership.Console.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.Views
{
    public interface IView
    {
        IFieldValidator FieldValidator { get; }
        Task RunTheView();
    }
}

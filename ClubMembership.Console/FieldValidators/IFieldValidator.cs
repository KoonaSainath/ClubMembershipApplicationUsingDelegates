using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership.Console.FieldValidators
{
    public delegate bool DelValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string errorMessage);
    public interface IFieldValidator
    {
        DelValidateField DelValidateField { get; }
        string[] FieldArray { get; }
        void InitializeDelegates();
    }
}

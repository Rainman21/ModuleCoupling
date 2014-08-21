using System;
using System.ComponentModel;
namespace BasicCsharpClassLibrary
{
    public interface IEmployee
    {
        //automatic changes
        int Age { get; }
        EmployeeAgeType AgeType { get; }
        DateTime Birthday { get; }
        [Category("Status")]
        int DaysToBirthday { get; }
        Guid EmployeeID { get; }
        string FirstName { get; }
        bool IsValid { get; }
        string LastName { get; }

        //below this line are manual changes
        bool Create(string first, string last, DateTime birthday, out IEmployee employee);
    }

    public class EmployeeModule
    {
        public static IEmployee CreateEmployee(string firstname, string lastname, DateTime birthdate)
        {
            Employee3 employee = new Employee3(firstname, lastname, birthdate);
            return employee;
        }


    }
}

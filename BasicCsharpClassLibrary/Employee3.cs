using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BasicCsharpClassLibrary
{
    //Refactor - Extract interface
    /*
    [Browsable(bool)] – to show property or not
    [ReadOnly(bool)] – possibility to edit property
    [Category(string)] – groups of property
    [Description(string)] – property description. It is something like a hint.
    [DisplayName(string)] – display property
     * */
    public class Employee3 : IEmployee  //this means Employee3 must implement the IEmployee interface
    {
        private DateTime _birthday;

        //Demonstrate Refactor Encapsulate Field below
        public DateTime Birthday
        {
            get { return _birthday; }
            // set { _birthday = value; }
        }

        private Guid _employeeID;

        public Guid EmployeeID
        {
            get { return _employeeID; }
            //        set { _employeeID = value; }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            //        set { _firstName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            //       set { _lastName = value; }
        }
        private bool _isValid = false;

        public bool IsValid
        {
            get { return _isValid; }
            //        set { _isValid = value; }
        }

        //Look at some of the types in System
        // System.
        [Category("Status")]
        public EmployeeAgeType AgeType
        {
            get
            {
                //EmployeeAgeType returnValue = EmployeeAgeType.Invalid;
                //There is a performance problem here... anyone see it?
                //what is the problem with coding numbers below? how might we change it?
                if (Age < 16)
                {
                    //in state of mass, cannot hire below 16
                    return EmployeeAgeType.Invalid;
                }
                else if (Age < 18)
                {
                    return EmployeeAgeType.Minor;
                }
                else if (Age < 40)
                {
                    return EmployeeAgeType.Standard;
                }
                else if (Age < 58)
                {
                    return EmployeeAgeType.Protected;
                }
                else if (Age < 75)
                {
                    return EmployeeAgeType.RetirementOptional;
                }
                return EmployeeAgeType.RetirementMandatory;

            }
        }

        public int DaysToBirthday
        {
            get
            {
                DateTime CurrentDate = DateTime.Now;
                DateTime BirthDayDate = new DateTime(CurrentDate.Year, _birthday.Month, _birthday.Day);
                return (CurrentDate - BirthDayDate).Days;
            }
        }

        public int Age
        {
            get
            {
                DateTime CurrentDate = DateTime.Now;
                int years = CurrentDate.Year - _birthday.Year;
                if (DaysToBirthday > 0)
                    years--;

                return years;
            }
        }

        //create a new employee
        public Employee3(string firstName, string lastName, DateTime birthdate)
        {
            _isValid = true;
            _employeeID = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _birthday = birthdate;

            //Validate that the birthdate is correct)
            // refactored out to method AgeType
            if (AgeType != EmployeeAgeType.Invalid || AgeType != EmployeeAgeType.RetirementMandatory)
            {
                _isValid = false;

            }


        }

        
        //public bool CreateNewEmployee


        //comment this out - right click on interface and "Implement Interface"

        public bool Create(string first, string last, DateTime birthday, out IEmployee employee)
        {
            //Create the most recent and capable Employee object but return the interface

            employee = null;

            Employee3 employee3 = new Employee3(first, last, birthday);
            if (employee3.IsValid)
            {
                employee = (IEmployee)employee3;
                return true;
            }

            return false;
            //throw new NotImplementedException();

        }
    }
}

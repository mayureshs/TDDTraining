using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace AccountsPayable
{
    public class Employee : TaxEntity
    {
        private string _firstName;
        private string _lastName;
        private float _salary;
        private float _ytdGross;
        private float _ytdTax;
        const float TAXRATE = (7.65f / 100);
        
        public Employee(string fname, string lname, string taxId, float salary) : base(taxId)
        {
            FirstName = fname;
            LastName = lname;
            Salary = salary;
        }

        protected override string TaxIdRegex
        {
            get { return @"^\d\d\d-\d\d-\d\d\d\d$"; }
        }

        public virtual string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null && value.Matches(@"^[A-Za-z\-\'\s]{1,30}$"))
                    _firstName = value;
                else
                    throw new ArgumentException();
            }
        }

        public virtual string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != null && value.Matches(@"^[A-Za-z\-\'\s]{1,30}$"))
                    _lastName = value;
                else
                    throw new ArgumentException();
            }
        }

        public virtual string FullName
        {
            get { return string.Format("{0}, {1}", LastName, FirstName); }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^[A-Za-z\-\'\s\,]{1,60}$"))
                {
                    string[] parts = value.Split(',');
                    if (parts.Length != 2)
                    {
                        throw new ArgumentException();
                    }
                    LastName = parts[0].Trim();
                    FirstName = parts[1].Trim();
                }
                else
                    throw new ArgumentException();
            }
        }

        public virtual float Salary
        {
            get { return _salary; }
            set
            {
                if (value > 50 && value < 5000)
                    _salary = value;
                else
                    throw new ArgumentException();
            }
        }

        public virtual float YtdGross
        {
            get { return _ytdGross; }
        }

        public virtual float YtdTax
        {
            get { return _ytdTax; }
        }

        public override float Pay()
        {
            float tax = Salary*TAXRATE;
            _ytdTax += tax;
            _ytdGross += Salary;
            return Salary - tax;
        }
    }
}
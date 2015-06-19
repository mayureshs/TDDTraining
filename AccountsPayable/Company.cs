using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsPayable
{
    public class Company : TaxEntity
    {
        private List<TaxEntity> _emps = new List<TaxEntity>();
        private string _name;
        
        public String Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Matches(@"^[\w\s]{2,30}"))
                    _name = value;
                else
                    throw new ArgumentException();
            }
        }
        
        public Company(string name, string taxId) : base(taxId)
        {
            Name = name;
        }

        public List<TaxEntity> Employees
        {
            get { return _emps; }
            set { _emps = value; }
        }

        public override float Pay()
        {
            return _emps.Sum(e => e.Pay());
        }

        public void Hire(Employee employee)
        {
            _emps.Add(employee);
        }

        protected override string TaxIdRegex
        {
            get { return @"\d\d-\d{7}"; }
        }
    }
}
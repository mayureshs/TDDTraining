using System.Collections.Generic;
using System.Linq;

namespace AccountsPayable
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IApDataContext Context { get; set; }
        public Employee Get(string id)
        {
            return Context.Employees.Single(e => e.TaxId.Equals(id));
        }

        public IEnumerable<Employee> GetAll()
        {
            return Context.Employees.ToList();
        }

        public void Save(Employee entity)
        {
            var emp = Context.Employees.Single(e => e.TaxId.Equals(entity.TaxId));
            if (emp == null)
                Context.Employees.Add(entity);
        }

        public void Delete(Employee entity)
        {
            var emp = Context.Employees.Single(e => e.TaxId.Equals(entity.TaxId));
            if (emp != null)
                Context.Employees.Remove(emp);
        }

        public IEnumerable<Employee> GetEmployeesNamed(string lastname)
        {
            return Context.Employees.Where(e => e.LastName.Equals(lastname)).ToList();
        }

        public IEnumerable<Employee> GetEmployeesSalaryGreater(float minSalary)
        {
            return Context.Employees.Where(e => e.Salary > minSalary).ToList();
        }

        public IEnumerable<Employee> GetEmployeesSalaryLess(float maxSalary)
        {
            return Context.Employees.Where(e => e.Salary < maxSalary).ToList();
        }
    }
}
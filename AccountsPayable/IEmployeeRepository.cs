using System.Collections.Generic;

namespace AccountsPayable
{
    public interface IEmployeeRepository : IRepository<Employee, string>
    {
        IEnumerable<Employee> GetEmployeesNamed(string lastname);
        IEnumerable<Employee> GetEmployeesSalaryGreater(float minSalary);
        IEnumerable<Employee> GetEmployeesSalaryLess(float maxSalary);
         
    }
}
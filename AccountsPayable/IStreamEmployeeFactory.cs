using System.Collections.Generic;
using System.IO;

namespace AccountsPayable
{
    public interface IStreamEmployeeFactory
    {
        Stream Stream { get; set; }

        IEnumerable<Employee> ReadEmployees();
    }
}
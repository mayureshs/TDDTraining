using System.Collections.Generic;

namespace AccountsPayable
{
    public interface IApDataContext
    {
        ICollection<Employee> Employees { get; }
    }
}
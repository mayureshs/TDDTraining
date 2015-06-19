using System.Collections.Generic;
using System.IO;

namespace AccountsPayable
{
    public class StreamEmployeeFactory : IStreamEmployeeFactory
    {
        public Stream Stream { get; set; }

        public IEnumerable<Employee> ReadEmployees()
        {
            List<Employee> emps = new List<Employee>();
            StreamReader rdr = new StreamReader(Stream);
            string line = null;
            while (null != (line = rdr.ReadLine()))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    Employee e = new Employee(parts[1].Trim(),
                        parts[0].Trim(), parts[2].Trim(),
                        float.Parse(parts[3].Trim()));
                    emps.Add(e);
                }
            }
            return emps;
        }
    }
}
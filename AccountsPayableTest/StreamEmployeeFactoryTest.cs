using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountsPayableTest
{
    [TestClass]
    public class StreamEmployeeFactoryTest
    {
        private IStreamEmployeeFactory _sut;

        private const string TESTDATA = "Hill,Hank,123-45-6789,100\n" +
                                        "Hill,Peggy,222-33-4567,200\n" +
                                        "Hill,Bobby,111-22-4567,75";

        [TestInitialize]
        public void Setup()
        {
            _sut = new StreamEmployeeFactory();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(TESTDATA));
            _sut.Stream = ms;
        }

        [TestMethod]
        public void CanReadEmployees()
        {
            IEnumerable<Employee> emps = _sut.ReadEmployees();
            var list = emps as IList<Employee> ?? emps.ToList();
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual("Hank", list.First().FirstName);
            Assert.AreEqual("Bobby", list.Last().FirstName);

        }
    }
}

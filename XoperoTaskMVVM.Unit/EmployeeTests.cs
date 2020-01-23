using NUnit.Framework;
using System;
using XoperoTaskMVVM.Model;
using XoperoTaskMVVM.ViewModel;

namespace XoperoTaskMVVM.Unit
{
    public class EmployeeTests
    {
        [Test]
        public void Employee_TestDefaultConstructor()
        {
            var employee = new Employee();
            Assert.IsNotNull(employee);
        }
        [TestCase("Piotr", "Zdun")]
        [TestCase("321", "321")]
        [TestCase("ąśąśąś", "Czołg")]
        [TestCase("Jan", "Nowak")]
        public void Employee_TestOverloadedConstructor(string name, string surname)
        {
            var employee = new Employee(name, surname);
            Assert.IsNotNull(employee);
        }
        [Test]
        public void Employee_TestOverloadedConstructor_NullReference()
        {
            var employee = new Employee();
            Assert.Throws<NullReferenceException>(() => employee.ToString());
        }
        [Test]
        public void Employee_SalaryTest()
        {
            var employee = new Employee("Jan", "Nowak");
            var salary = 1500.00m;
            Assert.AreEqual(employee.Contract.Salary(), salary);
        }
        [Test]
        public void Employee_ToStringTest()
        {
            var employee = new Employee("Andrzej", "Nowak");
            var text = employee.ToString();
            Assert.AreEqual(text, employee.ToString());
        }
        [Test]
        public void Employee_ModifyContractTest_ThrowsArgumentNullException()
        {
            Employee employee = null;
            int selector = 0;
            Assert.Throws<NullReferenceException>(() => employee.ModifyContract(selector));
        }
        [Test]
        public void Employee_ModifyContractTest_Fulltime()
        {
            var employee = new Employee("John", "Connor");
            int selector = (int)EnumClass.ContractSelector.Fulltime;
            employee.ModifyContract(selector);
            Assert.AreEqual(employee.Contract.GetType().Name, "Fulltime");
        }
        [Test]
        public void Employee_ModifyContractTest_Internship()
        {
            var employee = new Employee("John", "Connor");
            int selector = (int)EnumClass.ContractSelector.Internship;
            employee.ModifyContract(selector);
            Assert.AreEqual(employee.Contract.GetType().Name, "Internship");
        }

    }
}

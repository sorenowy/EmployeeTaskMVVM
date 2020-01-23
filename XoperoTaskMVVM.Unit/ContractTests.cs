using System;
using NUnit.Framework;
using XoperoTaskMVVM.Model;

namespace XoperoTaskMVVM.Unit
{
    public class ContractTests
    {
        [Test]
        public void Contract_BaseConstructorTest_Internship()
        {
            var contract = new Internship();
            Assert.IsNotNull(contract);
        }
        [Test]
        public void Contract_BaseConstructorTest_Fulltime()
        {
            var contract = new Fulltime();
            Assert.IsNotNull(contract);
        }
        [Test]
        public void Contract_OverloadedConstructorTest_Internship()
        {
            var employee = new Employee();
            var contract = new Internship();
            Assert.IsNotNull(contract);
        }
        [Test]
        public void Contract_OverloadedConstructorTest_Fulltime()
        {
            var employee = new Employee();
            var contract = new Fulltime();
            Assert.IsNotNull(contract);
        }
        [Test]
        public void Contract_SalaryReturnTest_Internship()
        {
            var employee = new Employee();
            var contract = new Internship();
            var salary = 1500.00m;
            Assert.AreEqual(salary, contract.Salary());
        }
        [Test]
        public void Contract_SalaryReturnTest_Fulltime()
        {
            var employee = new Employee();
            var contract = new Fulltime();
            var salary = 3600.00m;
            Assert.AreEqual(salary, contract.Salary());
        }
        [Test]
        public void Contract_EmptyStrings_ArgumentNullException()
        {
            var employee = new Employee();
            Assert.Throws<NullReferenceException>(() => employee.ToString());
        }
    }
}

using System;
using NUnit.Framework;
using XoperoTaskMVVM.Model;
using XoperoTaskMVVM.ViewModel;
using Moq;

namespace XoperoTaskMVVM.Unit
{
    public class EmployeeViewModelTests
    {
        [Test]
        public void EmployeeViewModel_TestConstructor()
        {
            var employeeView = new EmployeeViewModel();
            Assert.IsNotNull(employeeView);
        }
        [Test]
        public void EmployeeViewModel_TestAddEmployee()
        {
            var employeeView = new EmployeeViewModel();
            employeeView.Employee.Name = "Jan";
            employeeView.Employee.Surname = "Kowalski";
            employeeView.AddEmployee();
            Assert.That(employeeView.Employees.Count == 1);
        }
        [Test]
        public void EmployeeViewModel_TestRemoveEmployee()
        {
            var index = 0;
            var employeeView = new EmployeeViewModel();
            employeeView.Employee.Name = "Jan";
            employeeView.Employee.Surname = "Kowalski";
            employeeView.AddEmployee();
            employeeView.Employees.RemoveAt(index);
            Assert.AreEqual(employeeView.Employees.Count, 0);
        }
        [Test]
        public void EmployeeViewModel_TestPropertyChanged_Called()
        {
            var employeeView = new EmployeeViewModel();
            bool wasCalled = false;
            employeeView.PropertyChanged += (sender, args) => wasCalled = true;
            employeeView.Employee = new Employee();
            Assert.IsTrue(wasCalled);
        }
        [Test]
        public void EmployeeViewModel_TestImagePath()
        {
            var employeeView = new EmployeeViewModel();
            Assert.AreEqual(employeeView.ImagePath, Environment.CurrentDirectory + @"\Image\Image.jpg");
        }
        [Test]
        public void EmployeeViewModel_CatchArgumentOutOfRange()
        {
            var employeeView = new EmployeeViewModel();
            employeeView.Employee.Name = "John";
            employeeView.Employee.Surname = "Wayne";
            employeeView.ComboboxIndex = (int)EnumClass.ContractSelector.Fulltime;
            employeeView.ListNumber = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => employeeView.EditEmployee());
        }
    }
}

using System;
using System.ComponentModel;
using XoperoTaskMVVM.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace XoperoTaskMVVM.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Employee> Employees { get; set; } // Obserwowalna kolekcja obiektów (Pracowników)
        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged("Employee");
                }
            }
        }
        public int ListNumber { get; set; } // Selektor wyboru z listy
        public int ComboboxIndex { get; set; } // Selektor wyboru enumeratora z comboboxa
        public MyCommand Add { get; set; }
        public MyCommand Remove { get; set; }
        public MyCommand Edit { get; set; }

        public string ImagePath // Scieżka zdjęcia Xopero ;)
        {
            get
            {
                return Environment.CurrentDirectory + @"\Image\Image.jpg";
            }
        }
        public EmployeeViewModel() // Konstruktor kreujący Model-Widoku
        {
            Employees = new ObservableCollection<Employee>(); //Inicjalizacja
            Employee = new Employee(); // Inicjalizacja klasy przez właściwość
            Add = new MyCommand(AddEmployee); // Dodanie komend przez implementację ICommand
            Remove = new MyCommand(RemoveEmployee);
            Edit = new MyCommand(EditEmployee);
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void AddEmployee()
        {
            try
            {
                var employee = new Employee(Employee.Name, Employee.Surname);
                Employees.Add(employee);
                if(ComboboxIndex == 1)
                {
                    employee.Contract = new Fulltime();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Musisz wpisać imię i nazwisko pracownika w celu dodania!.");
            }
        }
        public void RemoveEmployee()
        {
            try
            {
                Employees.RemoveAt(ListNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Musisz zaznaczyć pracownika w celu edycji");
            }
        }
        public void EditEmployee()
        {
            try
            {
                Employee.ModifyContract(ComboboxIndex);
                Employees.Insert(ListNumber, Employee);
                Employees.RemoveAt(ListNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Musisz zaznaczyć pracownika w celu edycji");
            }
        }
    }
}

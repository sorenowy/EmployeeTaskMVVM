using System;
using System.ComponentModel;
using XoperoTaskMVVM.ViewModel;

namespace XoperoTaskMVVM.Model
{
    public class Employee : INotifyPropertyChanged
    {

        /// <summary>
        /// Właściwości wraz z oddelegowanym eventem obserwującym zmiany parametrów
        /// </summary>
        private string _name;
        private string _surname;
        private Contract _contract;
        public event PropertyChangedEventHandler PropertyChanged; // Zdarzenie umożliwiające zmianę parametrów przez operowanie na warstwie ViewModel

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public Contract Contract
        {
            get
            {
                return _contract;
            }
            set
            {
                if(_contract != value)
                {
                    _contract = value;
                    OnPropertyChanged("Contract");
                }
            }
        }
        /// <summary>
        /// Domyślny konstruktor w celu inicjalizacji instancji klasy.
        /// </summary>
        public Employee()
        {
            _name = string.Empty;
            _surname = string.Empty;
        }
        public Employee(string name, string surname)
        {
            if(name != string.Empty|| surname!=string.Empty)
            {
                this._name = name;
                this._surname = surname;
                this._contract = new Internship();
            }
            else
            {
                throw new ArgumentException();
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private decimal ShowSalary() // Metoda zwracająca konkretne wynagrodzenie z danego kontraktu
        {
            return this._contract.Salary();
        }
        /// <summary>
        /// stati
        /// </summary>
        /// <param name="employee">obiekt pracownika</param>
        /// <param name="selector">selektor wyboru pracownika z listy enumeratora</param>
        public void ModifyContract(int selector)
        {
            if (this == null) // Kiedy nie zaznaczymy osoby na liście zwróci błąd
            {
                throw new NullReferenceException();
            }
            if (selector < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (selector == (int)EnumClass.ContractSelector.Fulltime)
            {
                this._contract = new Fulltime();
            }
            else if (selector == (int)EnumClass.ContractSelector.Internship)
            {
                this._contract = new Internship();
            }
        }
        public override string ToString() // Przeładowana metoda zwracająca wszystkie właściwości obiektu.
        {
            return string.Format("Employee Name: {0}, Surname: {1}, Employee status: {2} Salary: {3} PLN", this._name, this._surname, this._contract.GetType().Name, this.ShowSalary());
        }        
    }
}

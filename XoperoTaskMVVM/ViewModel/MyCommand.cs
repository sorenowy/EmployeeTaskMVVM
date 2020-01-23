using System;
using System.Windows.Input;

namespace XoperoTaskMVVM.ViewModel
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _execute; // Metoda wybrana przez użytkownika

        public MyCommand(Action executeMethod)
        {
            _execute = executeMethod;
        }
        public bool CanExecute(object parameter) // Zezwolenie na wykonanie metody
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(_execute != null) // Jeżeli został wywołany konstruktor, można wywołać metodę.
            {
                _execute();
            }
        }
    }
}

using System.Windows;
using XoperoTaskMVVM.ViewModel;

namespace XoperoTaskMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel(); //Przesłanie danych z ViewModel do Widoku.
        }
    }
}

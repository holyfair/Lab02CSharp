using KMALab02BlahovProgramingInCSharp.ViewModels;
using System.Windows;

namespace KMALab02BlahovProgramingInCSharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}

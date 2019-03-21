using KMALab02BlahovProgramingInCSharp.Tools.Navigation;
using KMALab02BlahovProgramingInCSharp.ViewModels;
using System.Windows.Controls;

namespace KMALab02BlahovProgramingInCSharp.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonsListView.xaml
    /// </summary>
    public partial class PersonsListView : UserControl, INavigatable
    {
        public PersonsListView()
        {
            InitializeComponent();
            DataContext = new PersonsListViewModel();
            this.myGrid.IsReadOnly = true;
        }
        
    }
}

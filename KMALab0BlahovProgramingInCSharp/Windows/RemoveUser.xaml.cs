using KMALab02BlahovProgramingInCSharp.Tools.Navigation;
using KMALab0BlahovProgramingInCSharp.ViewModels;
using System.Windows.Controls;

namespace KMALab02BlahovProgramingInCSharp.Windows
{
    public partial class RemoveUser : UserControl, INavigatable
    {
        public RemoveUser()
        {
            InitializeComponent();
            DataContext = new RemovePersonViewModel();
        }
    }
}

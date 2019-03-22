using KMALab02BlahovProgramingInCSharp.DataStorage;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using KMALab02BlahovProgramingInCSharp.Tools.Navigation;
using KMALab0BlahovProgramingInCSharp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace KMALab02BlahovProgramingInCSharp
{
    public partial class MainWindow : Window, IContentOwner
    {

        public MainWindow()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        public ContentControl ContentControl => _contentControl;

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}

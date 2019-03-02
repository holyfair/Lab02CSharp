using KMALab02BlahovProgramingInCSharp.Tools;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;

namespace KMALab02BlahovProgramingInCSharp.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel , ILoaderOwner
    {
        private bool _isControlEnabled = true;
        
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManeger.Instance.Initialize(this);
        }

    }
}

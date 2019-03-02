using KMALab02BlahovProgramingInCSharp.Models;
using KMALab02BlahovProgramingInCSharp.Tools;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using System;

namespace KMALab02BlahovProgramingInCSharp.ViewModels
{
    class OutputViewModel : BaseViewModel
    {
        private Person _mainPerson;
        public Action CloseAction { get; set; }
        private RelayCommand<object> _closeCommand;
        public OutputViewModel(Person person)
        {
            _mainPerson = person;
        }

        public Person MainPerson
        {
            get
            {
                return _mainPerson;
            }
            set
            {
                _mainPerson = value;
                OnPropertyChanged("MainPerson");
            }
        }        public RelayCommand<object> CloseCommand
        {
            get
            {
                   return _closeCommand = new RelayCommand<object>(param => Close());
            }
        }        private void Close()
        {
            CloseAction();
            LoaderManeger.Instance.HideLoader();
        }
    }
}


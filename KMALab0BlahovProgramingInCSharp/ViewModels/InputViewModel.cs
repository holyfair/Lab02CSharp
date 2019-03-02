using KMALab02BlahovProgramingInCSharp.Models;
using KMALab02BlahovProgramingInCSharp.Tools;
using KMALab02BlahovProgramingInCSharp.Windows;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace KMALab02BlahovProgramingInCSharp.ViewModels
{
    class InputViewModel : BaseViewModel
    {
        private Person _mainPerson;
        private RelayCommand<object> _proceed;
        private RelayCommand<object> _close;
        
        public InputViewModel()
        {
            _mainPerson = new Person();
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
        }

        public RelayCommand<object> Proceed
        {
            get
            {
                return _proceed ?? (_proceed = new RelayCommand<object>(
                           ProceedImplementation));
            }
        }

        private async void ProceedImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            Person person = new Person();
                await Task.Run(() => {
                        person = new Person(_mainPerson.Name, _mainPerson.Surname, _mainPerson.Email, _mainPerson.DateOfBirth);
                        if (person.IsBirthday)
                            MessageBox.Show("Happy birthday!!!");
                });
                OutputWindow outputWindow = new OutputWindow(person);
                outputWindow.ViewModel = "OutputWindow";
                outputWindow.Show();
        }

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _close ?? (_close = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }
    }
}

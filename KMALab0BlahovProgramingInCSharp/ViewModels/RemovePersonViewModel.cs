using KMALab02BlahovProgramingInCSharp.Models;
using KMALab02BlahovProgramingInCSharp.Tools;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using KMALab02BlahovProgramingInCSharp.Tools.Navigation;
using KMALab0BlahovProgramingInCSharp.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMALab0BlahovProgramingInCSharp.ViewModels
{
    internal class RemovePersonViewModel : BaseViewModel
    {
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        private String _email;
        private String _buttonName;

        public String ButtonName
        {
            get
            {
                return _buttonName;
            }
            set
            {
                _buttonName = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand = new RelayCommand<object>(param => ProceedImplementation());
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand = new RelayCommand<object>(param =>
                {
                    NavigationManager.Instance.Navigate(ViewType.Main);
                });
            }
        }

        public String Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private async void ProceedImplementation()
        {
            LoaderManeger.Instance.ShowLoader();
            Thread.Sleep(1000);
            try
            {
                if (!StationManager.DataStorage.PersonExists(Email))
                    throw new UserIsNotExistsException();

                if (ButtonName == "Remove")
                {
                    await Task.Run(() =>
                    {
                        StationManager.DataStorage.RemovePerson(StationManager.DataStorage.GetPersonByEmail(Email));
                        MessageBox.Show("Person was succesful deleted!");
                    });
                    NavigationManager.Instance.Navigate(ViewType.Main, true);
                }
                else if (ButtonName == "Edit")
                {
                    Person person = StationManager.DataStorage.GetPersonByEmail(Email);
                    NavigationManager.Instance.Navigate(ViewType.Input, person);
                }
                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            LoaderManeger.Instance.HideLoader();
        }
    }
}

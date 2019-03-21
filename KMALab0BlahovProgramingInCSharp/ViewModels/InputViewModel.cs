﻿using KMALab02BlahovProgramingInCSharp.Models;
using KMALab02BlahovProgramingInCSharp.Tools;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using KMALab02BlahovProgramingInCSharp.Tools.Navigation;
using KMALab0BlahovProgramingInCSharp.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMALab02BlahovProgramingInCSharp.ViewModels
{
    internal class InputViewModel : BaseViewModel
    {
        public Action CloseAction { get; set; }
        private RelayCommand<object> _closeCommand;
        private Person _mainPerson;
        private RelayCommand<object> _proceed;
        private String _buttonName;
        private Person _currentPerson;


        public InputViewModel()
        {
            _mainPerson = new Person();
        }


        private Person CurrentPerson { get => _currentPerson; set => _currentPerson = value; }

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

        public Person MainPerson
        {
            get
            {
                return _mainPerson;
            }
            set
            {
                _mainPerson = value;
                CurrentPerson = new Person(_mainPerson.Name, _mainPerson.Surname, _mainPerson.Email, _mainPerson.DateOfBirth);
                OnPropertyChanged("MainPerson");
            }
        }

        public RelayCommand<object> Proceed
        {
            get
            {
                return _proceed = new RelayCommand<object>(param => ProceedImplementation());
            }
        }

        private async void ProceedImplementation()
        {
            LoaderManeger.Instance.ShowLoader();
            Thread.Sleep(1000);
            Person person = new Person();
            try
            {
                await Task.Run(() =>
                {
                    if(ButtonName == "Create")
                    {
                        person = new Person(_mainPerson.Name, _mainPerson.Surname, _mainPerson.Email, _mainPerson.DateOfBirth);
                        if (StationManager.DataStorage.PersonExists(person.Email))
                            throw new UserExistsException();

                        if (person.IsBirthday)
                            MessageBox.Show("Happy birthday!!!");
                        StationManager.DataStorage.AddPerson(person);
                        MessageBox.Show("Person was succesful created!");
                    }
                    else if(ButtonName == "Edit")
                    {
                        person = new Person(_mainPerson.Name, _mainPerson.Surname, _mainPerson.Email, _mainPerson.DateOfBirth);
                        MessageBox.Show(person.Email);
                        MessageBox.Show(CurrentPerson.Email);
                        if (StationManager.DataStorage.PersonExists(person.Email) && !person.Email.Equals(CurrentPerson.Email))
                            throw new UserExistsException();

                        if (person.IsBirthday)
                            MessageBox.Show("Happy birthday!!!");
                        StationManager.DataStorage.RemovePerson(StationManager.DataStorage.GetPersonByEmail(CurrentPerson.Email));
                        StationManager.DataStorage.AddPerson(person);
                        MessageBox.Show("Person was succesful edited!");
                    }
                });
                NavigationManager.Instance.Navigate(ViewType.Main, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            LoaderManeger.Instance.HideLoader();
        }
       

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _closeCommand = new RelayCommand<object>(param => NavigationManager.Instance.Navigate(ViewType.Main));
            }
        }
    }
}

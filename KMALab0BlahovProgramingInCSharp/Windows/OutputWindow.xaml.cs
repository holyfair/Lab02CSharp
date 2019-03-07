using KMALab02BlahovProgramingInCSharp.Models;
using KMALab02BlahovProgramingInCSharp.Tools.Manegers;
using KMALab02BlahovProgramingInCSharp.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace KMALab02BlahovProgramingInCSharp.Windows
{
    /// <summary>
    /// Логика взаимодействия для OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        public string ViewModel { get; set; }

        public OutputWindow(Person person)
        {
            InitializeComponent();
            OutputViewModel model = new OutputViewModel(person);
            this.DataContext = model;
            if (model.CloseAction == null)
                model.CloseAction = new Action(() => this.Close());
            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            LoaderManeger.Instance.HideLoader();
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
    }
}

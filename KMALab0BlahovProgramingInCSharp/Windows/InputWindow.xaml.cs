﻿using KMALab02BlahovProgramingInCSharp.ViewModels;
using System.Windows.Controls;

namespace KMALab02BlahovProgramingInCSharp.Windows
{
    /// <summary>
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class InputWindow : UserControl
    {
        public InputWindow()
        {
            InitializeComponent();
            DataContext = new InputViewModel();

        }
    }
}

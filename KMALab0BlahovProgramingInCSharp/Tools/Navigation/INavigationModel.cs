using KMALab02BlahovProgramingInCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMALab02BlahovProgramingInCSharp.Tools.Navigation
{
    internal enum ViewType
    {
        Input,
        Main,
        Remove
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
        void Navigate(ViewType viewType, bool refresh);
        void Navigate(ViewType viewType, String buttonName);
        void Navigate(ViewType viewType, Person person);
    }
}

using System.ComponentModel;

namespace KMALab02BlahovProgramingInCSharp.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        bool IsControlEnabled { get; set; }
    }
}

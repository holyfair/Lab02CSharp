using System;

namespace KMALab0BlahovProgramingInCSharp.Exceptions
{
    class IllegalEmailException : Exception
    {
        public override string Message => "Email adress is not correct!";
    }
}

using System;

namespace KMALab0BlahovProgramingInCSharp.Exceptions
{
    class IsNotBirthException : Exception
    {
        public override string Message => "This man is not birth yet!";
    }
}

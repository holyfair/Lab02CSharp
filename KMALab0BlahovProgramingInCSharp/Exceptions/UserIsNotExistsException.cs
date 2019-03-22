using System;

namespace KMALab0BlahovProgramingInCSharp.Exceptions
{
    class UserIsNotExistsException : Exception
    {
        public override string Message => "User is not exist!";
    }
}

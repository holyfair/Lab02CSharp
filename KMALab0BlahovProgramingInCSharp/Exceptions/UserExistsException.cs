using System;

namespace KMALab0BlahovProgramingInCSharp.Exceptions
{
    class UserExistsException : Exception
    {
        public override string Message => "User is already exist!";
    }
}

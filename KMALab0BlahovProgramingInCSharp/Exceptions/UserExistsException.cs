﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMALab0BlahovProgramingInCSharp.Exceptions
{
    class UserExistsException : Exception
    {
        public override string Message => "User is already exist!";
    }
}

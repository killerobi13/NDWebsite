using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Exceptions
{
    public class LoginWrongCredentialsException : Exception
    {
        public LoginWrongCredentialsException()
        : base("Invalid credentials")
        {
        }

    }
}

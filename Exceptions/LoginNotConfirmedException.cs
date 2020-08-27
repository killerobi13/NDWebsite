using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Exceptions
{
    public class LoginNotConfirmedException : Exception
    {
        public LoginNotConfirmedException()
      : base("The account is not confirmed")
        {
        }

    }
}

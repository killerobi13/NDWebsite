using NewDawnWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Exceptions
{
    public class UsernameExistsException: Exception
    {
        public UsernameExistsException(IStringResource stringResource): base(stringResource.GetUsernameAlreadyExists())
        {
        }

    }
}

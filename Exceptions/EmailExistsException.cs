using NewDawnWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException(IStringResource stringResource)
       : base(stringResource.GetEmailAlreadyExists())
        {
        }

    }
}

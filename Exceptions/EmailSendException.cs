using NewDawnWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Exceptions
{
    public class EmailSendException: Exception
    {
        public EmailSendException(IStringResource stringResource)
    : base(stringResource.GetEmailSendException())
        {
        }

    }
}

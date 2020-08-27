using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Helpers
{
    public interface IStringResource
    {
        public int GetIndex();

        public string GetUsernameAlreadyExists();
        public string GetEmailAlreadyExists();

        public string GetInvalidRegistrationEmail();
        public string GetInvalidRegistrationUsername();
        public string GetInvalidRegistrationPassword();
        public string GetInvalidRegistrationPasswordConfirm();
       
        public string GetValidRegistrationEmail();
        public string GetValidRegistrationUsername();
        public string GetValidRegistrationPassword();
        public string GetValidRegistrationPasswordConfirm();

        public string GetEmailSendException();
        public string GetUserNotExistsException();

        public string GetUsername();
        public string GetPassword();
        public string GetPasswordConfirm();
        public string GetEmail();

        public string GetRegister();
        public string GetRegistration();


    }
}

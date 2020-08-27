using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Helpers
{
    public class EnglishStringResource : IStringResource
    {
        public int GetIndex()
        {
            return 0;
        }
        public string GetEmailAlreadyExists()
        {
            return "The email is already taken";
        }

        public string GetInvalidRegistrationEmail()
        {
            return "The email format is not valid";
        }

        public string GetInvalidRegistrationPassword()
        {
            return "The password has to contain between 8 and 20 characters and at least one number, one letter and one special symbol";
        }

        public string GetInvalidRegistrationPasswordConfirm()
        {
            return "The passwords do not match";
        }

        public string GetInvalidRegistrationUsername()
        {
            return "The username must contain between 8 and 20 alphanumeric characters";
        }

        public string GetUsernameAlreadyExists()
        {
            return "The username is already taken";
        }

        public string GetValidRegistrationEmail()
        {
            return "The email is valid";
        }

        public string GetValidRegistrationPassword()
        {
            return "The password is valid";
        }

        public string GetValidRegistrationPasswordConfirm()
        {
            return "Passwords match";
        }

        public string GetValidRegistrationUsername()
        {
            return "The username is valid";
        }

        public string GetEmailSendException()
        {
            return "The email could not be delivered";
        }

        public string GetUserNotExistsException()
        {
            return "The specified user does not exist";
        }

        public string GetUsername()
        {
            return "Username";
        }
        public string GetPassword()
        {
            return "Password";
        }
        public string GetPasswordConfirm()
        {
            return "Password (Confirm)";
        }

        public string GetEmail()
        {
            return "Email";
        }

        public string GetRegister()
        {
            return "Register";
        }

        public string GetRegistration()
        {
            return "Registration";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Helpers
{
    public class RomanianStringResource : IStringResource
    {
        public int GetIndex()
        {
            return 1;
        }
        public string GetEmailAlreadyExists()
        {
            return "Adresa de email deja există";
        }

        public string GetEmailSendException()
        {
            return "Email-ul nu a putut fi trimis";
        }

        public string GetInvalidRegistrationEmail()
        {
            return "Email-ul nu respecta formatul general.";
        }

        public string GetInvalidRegistrationPassword()
        {
            return "Parola trebuie să conțină între 8 și 20 de caractere: cel puțin o literă, o cifră și un caracter special";
        }

        public string GetInvalidRegistrationPasswordConfirm()
        {
            return "Parolele specificate nu sunt identice";
        }

        public string GetInvalidRegistrationUsername()
        {
            return "Numele de utilizator trebuie sa conțină între 8 si 20 de caractere alfanumerice";
        }

        public string GetUsernameAlreadyExists()
        {
            return "Numele de utilizator deja există";
        }

        public string GetValidRegistrationEmail()
        {
            return "Adresa de email este validă";
        }

        public string GetValidRegistrationPassword()
        {
            return "Parola este validă";
        }

        public string GetValidRegistrationPasswordConfirm()
        {
            return "Parola este confirmată";
        }

        public string GetValidRegistrationUsername()
        {
            return "Numele de utilizator este valid";
        }

        public string GetUserNotExistsException()
        {
            return "Utilizatorul specificat nu există";
        }

        public string GetUsername()
        {
            return "Nume de utilizator";
        }
        public string GetPassword()
        {
            return "Parolă";
        }
        public string GetPasswordConfirm()
        {
            return "Parolă (confirmare)";
        }

        public string GetEmail()
        {
            return "Email";
        }

        public string GetRegister()
        {
            return "Înregistrează";
        }

        public string GetRegistration()
        {
            return "Înregistrare";
        }
    }
}

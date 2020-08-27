using NewDawnWeb.Models;
using NewDawnWeb.Helpers;
using System.Linq;
using NewDawnWeb.Exceptions;
using System;
 
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace NewDawnWeb.Services
{
    public class UserService
    {
        private SqlDbContext sqlDbContext { get; set; }
        private EmailService emailService { get; set; }

        private SessionState sessionState { get; set; }

        private string websiteUrl;
        
        public UserService(SqlDbContext sqlDbContext,IConfiguration config, EmailService emailService, IHttpContextAccessor httpContextAccessor ,SessionState sessionState)
        {
            var useProdGame = config.GetValue<bool>("game_use_prod");
            if (useProdGame)
            {
                websiteUrl = config.GetValue<string>("production_base_url");
            }
            else
            {
                websiteUrl = config.GetValue<string>("test_base_url");
            }
            this.sqlDbContext = sqlDbContext;
            this.emailService = emailService;
            this.sessionState = sessionState;
        }
        ///<summary>
        /// Returns true if the username is found and the password hash (password+salt) matches
        ///</summary>
        /// <exception cref="Exceptions.UserNotExistsException">
        /// Thrown when the user to be authenticated does not exist
        /// </exception>
        public int LoginUser(string username, string password)   
        {
            User user;
            try
            {
                 user = sqlDbContext.Users.Single(u => u.Username == username);
            }
            catch
            {
                return -1;
            }
 
            if (user.IsConfirmed && user.PasswordHash == String.Concat(username.Substring(0, 5), password.MD5().ToLower()).MD5().ToLower())
            {
                if(user.GmLevel==1)
                    return 2;
                else
                    return 1;
            }
            else
            {
                return 0;
            }
        }
       
        public bool LoginUserGame(string username, string passwordHash)
        {
            User user;
            try
            {
                user = sqlDbContext.Users.Single(u => u.Username == username);
            }
            catch
            {
                return false;
            }
     
            if (user.IsConfirmed && user.PasswordHash == String.Concat(username.Substring(0, 5), passwordHash.ToLower()).MD5().ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RegisterUser(string username, string password, string email)
        {
            string newEmail = "";
            if(email.Contains("@gmail.com"))
            {
                newEmail = email.Replace("@gmail.com","");
                newEmail = newEmail.Replace(".", "");
                newEmail = newEmail.ToLower();
                newEmail = newEmail + "@gmail.com";
            }
            else
            {
                newEmail = email.ToLower();
            }

            if (sqlDbContext.Users.Any(t => t.Username == username)) throw new UsernameExistsException(sessionState.language);
            if (sqlDbContext.Users.Any(t => t.Email == newEmail)) throw new EmailExistsException(sessionState.language);



            var user = new Models.User();
            user.Coins = 0;
            user.Email = email;
            user.PasswordHash = String.Concat(username.Substring(0, 5), password.MD5().ToLower()).MD5().ToLower();
            user.Username = username;
            user.IsLoginBanned = false;
            user.GmLevel = 0;

            sqlDbContext.Users.Add(user);
            sqlDbContext.SaveChanges();

            SendConfirmationEmail(username);

        }

        public bool EmailExists(string email)
        {
            return sqlDbContext.Users.Any(t => t.Email == email);
        }

        public void SendConfirmationEmail(string username)
        {
            User user = sqlDbContext.Users.Single(u => u.Username == username);

          
            string confirmationToken  = Extensions.GenerateToken();
            user.ConfirmationToken = confirmationToken;

            sqlDbContext.SaveChangesAsync();
            emailService.SendAsync(user.Email, "[New Dawn 9D] Account confirmation", "Please access the following link to confirm your account : "+websiteUrl+"/AccountConfirmation?username="+username+"&token="+ confirmationToken + " .");

        }

        public void RequestCredentialsReset(string email)
        {
            User user = sqlDbContext.Users.Single(u => u.Email == email);
            string token = Extensions.GenerateToken();
            user.PassworResetExpire = DateTime.Now.AddMinutes(15);
            user.PasswordResetToken = token;
            sqlDbContext.SaveChangesAsync();
            emailService.SendAsync(user.Email, "[New Dawn 9D] Password Recovery", "Username : " +user.Username + "<br> Password reset link:  " + websiteUrl + "/CompletePasswordReset?username=" + user.Username+"&token=" + token + " .") ;

        }

        public bool ConfirmUser(string username, string token)
        {
            try
            {
                User user = sqlDbContext.Users.Single(u => u.Username == username);
                if (user.ConfirmationToken == token)
                {
                    user.IsConfirmed = true;
                    sqlDbContext.SaveChanges();
                    return true; 
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ResetPassword(string username, string token, string newPassword)
        {
            try
            {
             
                User user = sqlDbContext.Users.Single(u => u.Username == username);
             
                if (user.PasswordResetToken == token && DateTime.Now < user.PassworResetExpire)
                {

                    user.PasswordHash = String.Concat(username.Substring(0, 5), newPassword.MD5().ToLower()).MD5().ToLower();
                    sqlDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                   
                    return false;
                }
            }catch
            {
            
                throw new UsernameExistsException(sessionState.language);
            }
            
          
        }

 
    }
}

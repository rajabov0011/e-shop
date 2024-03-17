//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Brokers.Loggings;
using e_shop.Storages.CredentialStorageBroker;
using e_shop.Models;

namespace e_shop.Services.Login
{
    internal class LoginService : ILoginService
    {
        private readonly IFileStorageBroker fileStorageBroker;
        private readonly ILoggingBroker loggingBroker;

        public LoginService()
        {
            this.fileStorageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Credential AddCredential(Credential credential)
        {
            return credential is null
                ? AddAndLogInvalidCredential()
                : ValidateAndAddCredential(credential);
        }

        public void CheckCredentialLogin(Credential credential)
        {
            if (fileStorageBroker.CheckUserLogin(credential))
            {
                this.loggingBroker.LogSucces("Welcome to system e-shop!");
            }
            else
            {
                this.loggingBroker.LogError("You entered the wrong login or password, please try again!");
            }
        }

        private Credential ValidateAndAddCredential(Credential credential)
        {
            if (String.IsNullOrWhiteSpace(credential.UserName) || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("User details missing");

                return new Credential();
            }
            else if (fileStorageBroker.CheckUserLogin(credential))
            {
                this.loggingBroker.LogError("User already exists, use another username");

                return new Credential();
            }
            else
            {
                this.loggingBroker.LogSucces("You have succesfully registered!");

                return this.fileStorageBroker.AddCredential(credential);
            }
        }

        private Credential AddAndLogInvalidCredential()
        {
            this.loggingBroker.LogError("Credential is invalid");

            return new Credential();
        }
    }
}
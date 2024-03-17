//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Storages.CredentialStorageBroker
{
    internal class FileStorageBroker : IFileStorageBroker
    {
        private const string FilePath = "../../../Assets/Users.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }

        public Credential AddCredential(Credential credential)
        {
            string credentialLine = $"{credential.UserName}-{credential.Password}\n";
            File.AppendAllText(FilePath, credentialLine);
            return credential;
        }

        public Credential[] GetAllCredentials()
        {
            string[] credentialLines = File.ReadAllLines(FilePath);
            int credentialLength = credentialLines.Length;
            Credential[] credentials = new Credential[credentialLength];

            for (int iterator = 0; iterator < credentialLength; iterator++)
            {
                string credentialLine = credentialLines[iterator];
                string[] credentialProperties = credentialLine.Split("-");

                Credential credential = new Credential
                {
                    UserName = credentialProperties[0],
                    Password = credentialProperties[1]
                };

                credentials[iterator] = credential;
            }

            return credentials;
        }

        public bool CheckUserLogin(Credential credential)
        {
            foreach (Credential CredentialItem in GetAllCredentials())
            {
                if (credential.UserName == CredentialItem.UserName && credential.Password == CredentialItem.Password)
                {
                    return true;
                }
            }

            return false;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath);
            }
        }
    }
}
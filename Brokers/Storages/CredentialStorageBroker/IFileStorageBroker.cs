//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Storages.CredentialStorageBroker
{
    internal interface IFileStorageBroker
    {
        Credential AddCredential(Credential credential);
        Credential[] GetAllCredentials();
        bool CheckUserLogin(Credential credential);
    }
}
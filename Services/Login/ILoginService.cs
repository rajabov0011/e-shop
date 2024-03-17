//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Services.Login
{
    internal interface ILoginService
    {
        Credential AddCredential(Credential credential);
        void CheckCredentialLogin(Credential credential);
    }
}
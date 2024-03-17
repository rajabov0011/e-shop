//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace e_shop.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogSucces(string message);
        void LogError(String userMessage);
        void LogError(Exception exception);
    }
}
using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Interfaces
{
    public interface INetworkable
    {
        bool UpdateIPAddress(string ipAddress);

        bool UpdateMACAddress(string macAddress);

        string GetIPAddress();

        string GetMACAddress();
    }
}


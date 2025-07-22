using System.Net;

namespace AzureRemoteDesktopStatus
{
    public static class Constants
    {
        public static string CredentialFile => @".\azureauth.json";
        public static string VirtualMachineName => "PCW";
        public static string ResourceGroupName => "PinicolaWorkstation";
        public static string HostName => "pinicolaworkstation.francecentral.cloudapp.azure.com";
        public static int RdpPort => 3389;
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace AzureRemoteDesktopStatus
{
    public class AzureHelper
    {
        public static async Task<string> Refresh()
        {
            var vm = await GetVirtualMachine();
            return vm.PowerState.Value;
        }

        private static async Task<IVirtualMachine> GetVirtualMachine()
        {
            var credentials = SdkContext.AzureCredentialsFactory
                .FromFile(
                    @"C:\Users\vincent\source\repos\AzureRemoteDesktopStatus\AzureRemoteDesktopStatus\azureauth.json");

            var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithDefaultSubscription();

            var vm = await azure.VirtualMachines.GetByResourceGroupAsync("PinicolaWorkstation",
                "PCW"); // TODO remove hard coded part
            return vm;
        }

        public static async Task Deallocate()
        {
            var vm = await GetVirtualMachine();
            await vm.DeallocateAsync();
        }

        public static async Task Start()
        {
            var vm = await GetVirtualMachine();
            await vm.StartAsync();
        }
    }
}
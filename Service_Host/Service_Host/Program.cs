using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Service_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost accountServiceHost = new ServiceHost(typeof(BackendService.AccountService)))
            using (ServiceHost contactServiceHost = new ServiceHost(typeof(BackendService.ContactService)))
            using (ServiceHost groupServiceHost = new ServiceHost(typeof(BackendService.GroupService)))
            {
                accountServiceHost.Open();
                Console.WriteLine("Account Service Hosted...");

                contactServiceHost.Open();
                Console.WriteLine("Contact Service Hosted...");

                groupServiceHost.Open();
                Console.WriteLine("Group Service Hosted...");

                Console.ReadLine();
            }
        }
    }
}

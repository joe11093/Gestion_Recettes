using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HebergementService
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClientBase<IServiceRecettes>.CacheSettings = CacheSettings.AlwaysOn;
            // Host the service within this EXE console application.
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service)))
            {
                try
                {
                    // Open the ServiceHost to start listening for messages.
                    serviceHost.Open();

                    // The service can now be accessed.
                    Console.WriteLine("--> Le service <Recettes> est prêt.");
                    Console.WriteLine("Appuyez sur <ENTER> pour terminer le service.");
                    Console.ReadLine();

                    // Close the ServiceHost.
                    serviceHost.Abort();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}

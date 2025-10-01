using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary2;
using System.ServiceModel;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service1)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("WCF Service is running...");
                    Console.WriteLine("Press ENTER to exit.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine(ex.InnerException?.Message);
                }
            }
        }
    }
}

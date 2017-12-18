using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using Unity;
using UnityLog4NetExtension.Log4Net;

namespace UnityLog4NetExtension.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlConfigurator.Configure();
                var container = new UnityContainer();
                container.RegisterType<MyClass>();
                container.AddNewExtension<Log4NetExtension>();

                var myClass = container.Resolve<MyClass>();
                myClass.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();
                }
            }
        }
    }
}

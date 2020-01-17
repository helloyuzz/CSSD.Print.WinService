using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSD.Print.WinService.Installer {
    class Program {
        static void Main(string[] args) {
            IDictionary dictionary = new Hashtable();

            string type = "";
            if(args.Length > 0) {
                type = args[0];
            }
            Console.WriteLine("");

            try {
                // Set the commandline argument array for 'logfile'.
                string[] commandLineOptions = new string[1] { "/LogFile=example.log" };

                // Create an object of the 'AssemblyInstaller' class.
                AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller("CSSD.Print.WinService.exe",commandLineOptions);

                myAssemblyInstaller.UseNewContext = true;

                // Install the 'MyAssembly' assembly.
                if(type.Equals("u")) {
                    myAssemblyInstaller.Uninstall(dictionary);
                } else {
                    myAssemblyInstaller.Install(dictionary);
                }

                // Commit the 'MyAssembly' assembly.
                myAssemblyInstaller.Commit(dictionary);
            } catch(ArgumentException arguExc) {
                Console.WriteLine(arguExc.ToString());
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

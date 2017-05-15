using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range.AccountGen
{
    class Program
    {
        /// <summary>
        /// Accept amount to gen, gen 10 as default
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
            if(!isValid)
            {
                Console.WriteLine("Press enter to terminate...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=============== Range User Account Generation Tool ==================");
            Console.WriteLine("\\-------------------------------------------------------------------/");
            
            var personGenerator = new PersonNameGenerator();
            int success = 0;
          
            using (var context = new PrincipalContext(ContextType.Domain, options.DomainDNSName, options.ContainerPath))
            {
                for (int i = 0; i < options.NumberToCreate; i++)
                {
                    var ssn = EfficientlyLazy.IdentityGenerator.Generator.GenerateSSN();

                    var first = personGenerator.GenerateRandomFirstName();
                    var last = personGenerator.GenerateRandomLastName();
                    var username = $"{first}.{last}";
                    using (var user = new UserPrincipal(context)
                    {
                        //UserPrincipalName = username,
                        Description = "System User",
                        GivenName = first,
                        Surname = last,
                        SamAccountName = username,
                        DisplayName = $"{last}, {first}",
                        EmployeeId = ssn,
                        Enabled = true
                    })
                    {
                        try
                        {
                            Console.WriteLine($"==>Creating User {first} {last} ({username}).");
                            user.SetPassword(options.Password);
                            user.Save();
                            success += 1;
                        }
                        catch(Exception ex)
                        {
                            var defaultColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"==> !! {ex.ToString()}");
                            Console.ForegroundColor = defaultColor;
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Operation Completed! Generated {success} accounts. Failed for {options.NumberToCreate-success} accounts.");
        }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range.AccountGen
{
    class Options
    {
        [Option('d', "domainDNS", Required = true, HelpText = "DomainDNS Name eg bob.local")]
        public string DomainDNSName { get; set; }

        [Option('c', "containerPath", Required =true, HelpText ="The Path of the OU to create in.")]
        public string ContainerPath { get; set; }

        [Option('n', "number", Required = true, HelpText = "Number of accounts to generatee")]
        public int NumberToCreate { get; set; }

        [Option('p', "password", Required =true, HelpText ="Password to set for user accounts generated.")]
        public string Password { get; set; }

    }
}

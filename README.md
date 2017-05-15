# Range.AccountGen (Range AD Account Generation Utility)

This tool allows us to generate pseudo-random Active Directory users for the enclave. The tool randomly selects a first and last name, and assigns some other property metadata to the ad objects.

Finally, a password is set. Our workstation configuration leverages this to randomly assign an account to each node simulating real user logons.

Usage is simple, `-d yourdns.yourdomain -c ou=SomeOU,dc=yourdns,dc=yourdomain -n 10 -p "*Password*"`.

Command Line Options:
---
  -d, --domainDNS        Required. DomainDNS Name eg bob.local

  -c, --containerPath    Required. The Path of the OU to create in.

  -n, --number           Required. Number of accounts to generatee

  -p, --password         Required. Password to set for user accounts generated.

Help
----
If you have any issues, questions, or comments feel free to contact me on twitter, or file an issue. @turingnerd.



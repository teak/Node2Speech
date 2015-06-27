# Node2Speech
Simple command line exe to convert text to speech.

###### A compiled 32 bit exe is included for convenience.

Requires .NET Framework to be installed.

--

Requires four or more command line arguments:

1. The output volume. Between 0 and 100.
2. The output speed. Between -10 and 10.
3. A voice set by name. Names are returned as the first part the 'list' option (see below). A gender can also be used if a specific voice is not required.
4. The text to speak. Any farther args are joined and spoken as well.

##### Example:
Node2Speech.exe 100 0 "Microsoft Zira Desktop" testing 1 2 3

Node2Speech.exe 50 -2 male testing 1 2 3

--

Run with the single arg 'list' to output all installed and enabled voice info to stdout. Format is: "Name,Description,Gender,Age"

##### Example 'list' output:
"Microsoft Hazel Desktop","Microsoft Hazel Desktop - English (Great Britain)",Female,Adult

--

###### MIT License

# Node2Speech
Simple command line exe to convert text to speech.

There is a compiled 64 bit exe for convenience.

Requires .NET Framework to be installed.

Requires three or more command line arguments:

1. The output volume. Between 0 and 100.
2. The output speed. Between -10 and 10.
3. A gender. If set to anything but female, a male voice will be used.
3. The text to speak. Any farther args are joined and spoken as well.

If run with the single arg 'list' it outputs installed voice info to stdout. Example output:

Microsoft Hazel Desktop - English (Great Britain),Female,Adult

A one per line, comma seperated list. ("Description,Gender,Age")

MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Synthesis;

namespace Node2Speech
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = Int32.Parse(args[0]);
                synthesizer.Rate = Int32.Parse(args[1]);

                string[] speak = new string[args.Length - 2];
                Array.Copy(args, 2, speak, 0, args.Length - 2);

                synthesizer.Speak(string.Join(" ", speak));
            }
        }
    }
}

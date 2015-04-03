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
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            if (args.Length > 2)
            {
                synthesizer.Volume = Int32.Parse(args[0]);
                synthesizer.Rate = Int32.Parse(args[1]);

                var gender = VoiceGender.Male;
                if (args[2] == "female")
                {
                    gender = VoiceGender.Female;
                }

                synthesizer.SelectVoiceByHints(gender);
                synthesizer.SetOutputToDefaultAudioDevice();

                string[] speak = new string[args.Length - 3];
                Array.Copy(args, 3, speak, 0, args.Length - 3);

                PromptBuilder builder = new PromptBuilder();
                builder.AppendText(string.Join(" ", speak));

                synthesizer.Speak(builder);
            }
            else if (args.Length == 1)
            {
                if (args[0] == "list")
                {
                    foreach (var v in synthesizer.GetInstalledVoices().Select(v => v.VoiceInfo))
                    {
                        Console.WriteLine("{0},{1},{2}", v.Description, v.Gender, v.Age);
                    }
                }
            }
        }
    }
}

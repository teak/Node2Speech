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
                try
                {
                    synthesizer.Volume = Int32.Parse(args[0]);
                    synthesizer.Rate = Int32.Parse(args[1]);

                    string voice = "";
                    string voiceFemale = "";
                    foreach (var v in synthesizer.GetInstalledVoices())
                    {
                        if (v.Enabled)
                        {
                            if (voice.Length == 0)
                            {
                                voice = v.VoiceInfo.Name;
                            }
                            if (voiceFemale.Length == 0 && v.VoiceInfo.Gender.ToString() == "Female")
                            {
                                voiceFemale = v.VoiceInfo.Name;
                            }
                        }
                    }

                    if (voice.Length == 0)
                    {
                        Console.WriteLine("no voice enabled on system");
                        return;
                    }

                    if (args[2] == "female")
                    {
                        if (voiceFemale.Length != 0)
                        {
                            voice = voiceFemale;
                        }
                    }
                    else if (args[2].Length != 0)
                    {
                        voice = args[2];
                    }

                    synthesizer.SetOutputToDefaultAudioDevice();

                    string[] speak = new string[args.Length - 3];
                    Array.Copy(args, 3, speak, 0, args.Length - 3);

                    PromptBuilder builder = new PromptBuilder();
                    builder.StartVoice(voice);
                    builder.AppendText(string.Join(" ", speak));
                    builder.EndVoice();

                    synthesizer.Speak(builder);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
            else if (args.Length == 1 && args[0] == "list")
            {
                foreach (var v in synthesizer.GetInstalledVoices())
                {
                    if (v.Enabled)
                    {
                        Console.WriteLine("\"{0}\",\"{1}\",{2},{3}", v.VoiceInfo.Name, v.VoiceInfo.Description, v.VoiceInfo.Gender, v.VoiceInfo.Age);
                    }
                }
            }
            else
            {
                Console.WriteLine("invalid arguments");
            }
        }
    }
}

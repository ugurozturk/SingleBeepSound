using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SingleBeep
{
    class Program
    {
        static async Task PlayBeepAsync(WaveOutEvent outputDevice)
        {
            await Task.Run(() =>
            {
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                }
            });
        }

        static async Task RunSoundAsync()
        {
            var beeSoundLocalation = "D:\\beep.wav";
            using (var audioFile = new AudioFileReader(beeSoundLocalation))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                await PlayBeepAsync(outputDevice);
            }
        }

        static async Task Main(string[] args)
        {
            while (true)
            {
                System.Console.Write("Komut giriniz : ");
                var commands = Console.ReadLine();
                if (commands == "b")
                {
                    await RunSoundAsync();
                }
                else if (commands == "exit")
                {
                    break;
                }
            }
        }
    }
}

// This example demonstrates how to initialize an audio engine and play a sound. 
// Original code: https://miniaud.io/docs/examples/engine_hello_world.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No input file.");
                return;
            }

            ma_result result;
            ma_engine_ptr engine = new ma_engine_ptr(true);

            result = ma_engine_init(engine);
            if (result != ma_result.success)
            {
                engine.Free();
                Console.WriteLine("Failed to initialize audio engine.");
                return;
            }

            ma_engine_play_sound(engine, args[0], new ma_sound_group_ptr(IntPtr.Zero));

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_engine_uninit(engine);

            engine.Free();
        }
    }
}

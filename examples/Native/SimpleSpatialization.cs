// Demonstrates how to do basic spatialization via the high level API.
// Original code: https://miniaud.io/docs/examples/simple_spatialization.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static ma_engine_ptr engine;
        static ma_sound_ptr sound;

        static void Main(string[] args)
        {
            ma_result result;
            
            float listenerAngle = 0;

            if (args.Length < 1)
            {
                Console.WriteLine("No input file.");
                return;
            }

            engine = new ma_engine_ptr(true);
            sound = new ma_sound_ptr(true);

            result = ma_engine_init(engine);
            if (result != ma_result.success)
            {
                CleanUp();
                Console.WriteLine("Failed to initialize engine.");
                return;
            }


            result = ma_sound_init_from_file(engine, args[0], 0, default, default, sound);
            if (result != ma_result.success)
            {
                Console.WriteLine("Failed to load sound: " + args[0]);
                ma_engine_uninit(engine);
                CleanUp();
                return;
            }
            
            Console.CancelKeyPress += OnCancelKeyPress;

            ma_sound_set_looping(sound, 1);

            /* This sets the position of the sound. miniaudio follows the same coordinate system as OpenGL, where -Z is forward. */
            ma_sound_set_position(sound, 0, 0, -1);

            /*
            This sets the position of the listener. The second parameter is the listener index. If you have only a single listener, which is
            most likely, just use 0. The position defaults to (0,0,0).
            */
            ma_engine_listener_set_position(engine, 0, 0, 0, 0);

            /* Sounds are stopped by default. We'll start it once initial parameters have been setup. */
            ma_sound_start(sound);

            /* Rotate the listener on the spot to create an orbiting effect. */
            for (; ; )
            {
                listenerAngle += 0.01f;
                ma_engine_listener_set_direction(engine, 0, (float)Math.Sin(listenerAngle), 0, (float)Math.Cos(listenerAngle));

                System.Threading.Thread.Sleep(1);
            }
        }

        private static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            ma_sound_uninit(sound);
            ma_engine_uninit(engine);
            CleanUp();
        }

        static void CleanUp()
        {
            sound.Free();
            engine.Free();
        }
    }
}
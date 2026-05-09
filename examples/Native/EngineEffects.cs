// Demonstrates how to apply an effect to sounds using the high level engine API. 
// Original code: https://miniaud.io/docs/examples/engine_effects.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static readonly float DELAY_IN_SECONDS = 0.2f;
        static readonly float DECAY = 0.25f;   /* Volume falloff for each echo. */
        static ma_engine_ptr g_engine;
        static ma_sound_ptr g_sound;            /* This example will play only a single sound at once, so we only need one ma_sound object. */
        static ma_delay_node_ptr g_delayNode;   /* The echo effect is achieved using a delay node. */

        static void Main(string[] args)
        {
            ma_result result;

            if (args.Length < 1)
            {
                Console.WriteLine("No input file.");
                return;
            }

            g_engine = new ma_engine_ptr(true);
            g_sound = new ma_sound_ptr(true);
            g_delayNode = new ma_delay_node_ptr(true);

            /* The engine needs to be initialized first. */
            result = ma_engine_init(g_engine);
            if (result != ma_result.success)
            {
                Console.WriteLine("Failed to initialize audio engine.");
                CleanUp();
                return;
            }

            /*
            We'll build our graph starting from the end so initialize the delay node now. The output of
            this node will be connected straight to the output. You could also attach it to a sound group
            or any other node that accepts an input.

            Creating a node requires a pointer to the node graph that owns it. The engine itself is a node
            graph. In the code below we can get a pointer to the node graph with ma_engine_get_node_graph()
            or we could simple cast the engine to a ma_node_graph* like so:

                (ma_node_graph*)&g_engine

            The endpoint of the graph can be retrieved with ma_engine_get_endpoint().
            */
            {
                ma_delay_node_config delayNodeConfig;
                UInt32 channels;
                UInt32 sampleRate;

                channels = ma_engine_get_channels(g_engine);
                sampleRate = ma_engine_get_sample_rate(g_engine);

                delayNodeConfig = ma_delay_node_config_init(channels, sampleRate, (UInt32)(sampleRate * DELAY_IN_SECONDS), DECAY);

                result = ma_delay_node_init(ma_engine_get_node_graph(g_engine), ref delayNodeConfig, g_delayNode);
                if (result != ma_result.success)
                {
                    Console.WriteLine("Failed to initialize delay node.");
                    CleanUp();
                    return;
                }

                /* Connect the output of the delay node to the input of the endpoint. */
                ma_node_attach_output_bus(new ma_node_ptr(g_delayNode.pointer), 0, ma_engine_get_endpoint(g_engine), 0);
            }

            /* Now we can load the sound and connect it to the delay node. */
            {
                result = ma_sound_init_from_file(g_engine, args[0], 0, default, default, g_sound);
                if (result != ma_result.success)
                {
                    Console.WriteLine($"Failed to initialize sound \"{args[0]}\".");
                    CleanUp();
                    return;
                }

                /* Connect the output of the sound to the input of the effect. */
                ma_node_attach_output_bus(new ma_node_ptr(g_sound.pointer), 0, new ma_node_ptr(g_delayNode.pointer), 0);

                /*
                Start the sound after it's applied to the sound. Otherwise there could be a scenario where
                the very first part of it is read before the attachment to the effect is made.
                */
                ma_sound_start(g_sound);
            }

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_sound_uninit(g_sound);
            ma_delay_node_uninit(g_delayNode);
            ma_engine_uninit(g_engine);

            CleanUp();
        }

        static void CleanUp()
        {
            g_engine.Free();
            g_sound.Free();
            g_delayNode.Free();
        }
    }
}
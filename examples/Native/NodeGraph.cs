// This example shows how to use the node graph system. 
// Original code: https://miniaud.io/docs/examples/node_graph.html

using System;
using System.Runtime.InteropServices;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    unsafe class Program
    {
        /* Data Format */
        static readonly ma_format FORMAT = ma_format.f32;   /* Must always be f32. */
        static readonly UInt32 CHANNELS = 2;
        static readonly UInt32 SAMPLE_RATE = 48000;

        /* Effect Properties */
        static readonly float LPF_BIAS = 0.9f;    /* Higher values means more bias towards the low pass filter (the low pass filter will be more audible). Lower values means more bias towards the echo. Must be between 0 and 1. */
        static readonly float LPF_CUTOFF_FACTOR = 80;      /* High values = more filter. */
        static readonly UInt32 LPF_ORDER = 8;
        static readonly float DELAY_IN_SECONDS = 0.2f;
        static readonly float DECAY = 0.5f;    /* Volume falloff for each echo. */

        [StructLayout(LayoutKind.Sequential)]
        public struct sound_node
        {
            public ma_data_source_node node;   /* If you make this the first member, you can pass a pointer to this struct into any ma_node_* API and it will "Just Work". */
            public ma_decoder decoder;
        }

        static ma_node_graph_ptr g_nodeGraph;
        static ma_lpf_node_ptr g_lpfNode;
        static ma_delay_node_ptr g_delayNode;
        static ma_splitter_node_ptr g_splitterNode;
        static sound_node* g_pSoundNodes;
        static int g_soundNodeCount;

        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            /*
            Hearing the output of the node graph is as easy as reading straight into the output buffer. You just need to
            make sure you use a consistent data format or else you'll need to do your own conversion.
            */
            ma_node_graph_read_pcm_frames(g_nodeGraph, pOutput, frameCount, IntPtr.Zero);
        }

        static void Main(string[] args)
        {
            int iarg;
            ma_result result;

            g_nodeGraph = new ma_node_graph_ptr(true);
            g_lpfNode = new ma_lpf_node_ptr(true);
            g_delayNode = new ma_delay_node_ptr(true);
            g_splitterNode = new ma_splitter_node_ptr(true);

            /* We'll set up our nodes starting from the end and working our way back to the start. We'll need to set up the graph first. */
            {
                ma_node_graph_config nodeGraphConfig = ma_node_graph_config_init(CHANNELS);

                result = ma_node_graph_init(ref nodeGraphConfig, g_nodeGraph);
                if (result != ma_result.success)
                {
                    CleanUp();
                    Console.WriteLine("ERROR: Failed to initialize node graph.");
                    return;
                }
            }


            /* Low Pass Filter. */
            {
                ma_lpf_node_config lpfNodeConfig = ma_lpf_node_config_init(CHANNELS, SAMPLE_RATE, SAMPLE_RATE / LPF_CUTOFF_FACTOR, LPF_ORDER);

                result = ma_lpf_node_init(g_nodeGraph, ref lpfNodeConfig, g_lpfNode);
                if (result != ma_result.success)
                {
                    CleanUp();
                    Console.WriteLine("ERROR: Failed to initialize low pass filter node.");
                    return;
                }

                /* Connect the output bus of the low pass filter node to the input bus of the endpoint. */
                ma_node_ptr pNode = new ma_node_ptr(g_lpfNode.pointer);
                ma_node_attach_output_bus(pNode, 0, ma_node_graph_get_endpoint(g_nodeGraph), 0);

                /* Set the volume of the low pass filter to make it more of less impactful. */
                ma_node_set_output_bus_volume(pNode, 0, LPF_BIAS);
            }


            /* Echo / Delay. */
            {
                ma_delay_node_config delayNodeConfig = ma_delay_node_config_init(CHANNELS, SAMPLE_RATE, (UInt32)(SAMPLE_RATE * DELAY_IN_SECONDS), DECAY);

                result = ma_delay_node_init(g_nodeGraph, ref delayNodeConfig, g_delayNode);
                if (result != ma_result.success)
                {
                    CleanUp();
                    Console.WriteLine("ERROR: Failed to initialize delay node.");
                    return;
                }

                /* Connect the output bus of the delay node to the input bus of the endpoint. */
                ma_node_ptr pNode = new ma_node_ptr(g_delayNode.pointer);
                ma_node_attach_output_bus(pNode, 0, ma_node_graph_get_endpoint(g_nodeGraph), 0);

                /* Set the volume of the delay filter to make it more of less impactful. */
                ma_node_set_output_bus_volume(pNode, 0, 1 - LPF_BIAS);
            }


            /* Splitter. */
            {
                ma_splitter_node_config splitterNodeConfig = ma_splitter_node_config_init(CHANNELS);

                result = ma_splitter_node_init(g_nodeGraph, ref splitterNodeConfig, g_splitterNode);
                if (result != ma_result.success)
                {
                    CleanUp();
                    Console.WriteLine("ERROR: Failed to initialize splitter node.");
                    return;
                }

                /* Connect output bus 0 to the input bus of the low pass filter node, and output bus 1 to the input bus of the delay node. */
                ma_node_ptr pSplitterNode = new ma_node_ptr(g_splitterNode.pointer);
                ma_node_ptr pLpfNode = new ma_node_ptr(g_lpfNode.pointer);
                ma_node_ptr pDelayNode = new ma_node_ptr(g_delayNode.pointer);
                ma_node_attach_output_bus(pSplitterNode, 0, pLpfNode, 0);
                ma_node_attach_output_bus(pSplitterNode, 1, pDelayNode, 0);
            }


            /* Data sources. Ignore any that cannot be loaded. */
            g_pSoundNodes = (sound_node*)Marshal.AllocHGlobal(args.Length * sizeof(sound_node));

            if (g_pSoundNodes == null)
            {
                CleanUp();
                Console.WriteLine("Failed to allocate memory for sounds.");
                return;
            }

            g_soundNodeCount = 0;
            for (iarg = 0; iarg < args.Length; iarg += 1)
            {
                ma_decoder_config decoderConfig = ma_decoder_config_init(FORMAT, CHANNELS, SAMPLE_RATE);

                ma_decoder_ptr pDecoder = new ma_decoder_ptr(&g_pSoundNodes[g_soundNodeCount].decoder);

                result = ma_decoder_init_file(args[iarg], ref decoderConfig, pDecoder);
                if (result == ma_result.success)
                {
                    ma_data_source_node_config dataSourceNodeConfig = ma_data_source_node_config_init(new ma_data_source_ptr(pDecoder.pointer));

                    result = ma_data_source_node_init(g_nodeGraph, ref dataSourceNodeConfig, new ma_data_source_node_ptr(&g_pSoundNodes[g_soundNodeCount].node));

                    if (result == ma_result.success)
                    {
                        ma_node_ptr pSplitterNode = new ma_node_ptr(g_splitterNode.pointer);
                        /* The data source node has been created successfully. Attach it to the splitter. */
                        ma_node_attach_output_bus(new ma_node_ptr(&g_pSoundNodes[g_soundNodeCount].node), 0, new ma_node_ptr(g_splitterNode.pointer), 0);
                        g_soundNodeCount += 1;
                    }
                    else
                    {
                        Console.WriteLine($"WARNING: Failed to init data source node for sound \"{args[iarg]}\". Ignoring.");
                        ma_decoder_uninit(pDecoder);
                    }
                }
                else
                {
                    Console.WriteLine($"WARNING: Failed to load sound \"{args[iarg]}\". Ignoring.");
                }
            }

            /* Everything has been initialized successfully so now we can set up a playback device so we can listen to the result. */
            {
                ma_device_config deviceConfig;
                ma_device_ptr device = new ma_device_ptr(true);

                deviceConfig = ma_device_config_init(ma_device_type.playback);
                deviceConfig.playback.format = FORMAT;
                deviceConfig.playback.channels = CHANNELS;
                deviceConfig.sampleRate = SAMPLE_RATE;
                deviceConfig.SetDataCallback(new ma_device_data_proc(data_callback));
                deviceConfig.pUserData = IntPtr.Zero;

                result = ma_device_init(new ma_context_ptr(IntPtr.Zero), ref deviceConfig, device);
                
                if (result != ma_result.success)
                {
                    device.Free();
                    Console.WriteLine("ERROR: Failed to initialize device.");
                    goto cleanup_graph;
                }

                result = ma_device_start(device);

                if (result != ma_result.success)
                {
                    ma_device_uninit(device);
                    device.Free();
                    goto cleanup_graph;
                }

                Console.WriteLine("Press Enter to quit...");
                Console.ReadLine();

                /* We're done. Clean up the device. */
                ma_device_uninit(device);
                device.Free();
            }

        cleanup_graph:
            {
                /* It's good practice to tear down the graph from the lowest level nodes first. */
                int iSound;

                /* Sounds. */
                for (iSound = 0; iSound < g_soundNodeCount; iSound += 1)
                {
                    ma_data_source_node_uninit(new ma_data_source_node_ptr(&g_pSoundNodes[iSound].node));
                    ma_decoder_uninit(new ma_decoder_ptr(&g_pSoundNodes[iSound].decoder));
                }

                Marshal.FreeHGlobal(new IntPtr(g_pSoundNodes));

                /* Splitter. */
                ma_splitter_node_uninit(g_splitterNode);

                /* Echo / Delay */
                ma_delay_node_uninit(g_delayNode);

                /* Low Pass Filter */
                ma_lpf_node_uninit(g_lpfNode);

                /* Node Graph */
                ma_node_graph_uninit(g_nodeGraph);

                CleanUp();
            }
        }

        static void CleanUp()
        {
            g_nodeGraph.Free();
            g_lpfNode.Free();
            g_delayNode.Free();
            g_splitterNode.Free();
        }
    }
}
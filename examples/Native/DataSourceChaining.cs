// Demonstrates one way to chain together a number of data sources so they play back seamlessly without gaps. 
// Original code: https://miniaud.io/docs/examples/data_source_chaining.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static Int32 g_decoderCount = 0;
        static ma_decoder_ptr[] g_pDecoders;
        static readonly ma_format SAMPLE_FORMAT = ma_format.f32;
        static readonly UInt32 CHANNEL_COUNT = 2;
        static readonly UInt32 SAMPLE_RATE = 48000;

        static ma_data_source_ptr next_callback_tail(ma_data_source_ptr pDataSource)
        {
            /* <-- We check for this in Main() so should never happen. */
            if (g_decoderCount > 0)
            {
                return default;
            }

            /*
            This will be fired when the last item in the chain has reached the end. In this example we want
            to loop back to the start, so we need only return a pointer back to the head.
            */
            return new ma_data_source_ptr(g_pDecoders[0].pointer);
        }

        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            /*
            We can just read from the first decoder and miniaudio will resolve the chain for us. Note that
            if you want to loop the chain, like we're doing in this example, you need to set the loop
            parameter to false, or else only the current data source will be looped.
            */
            ma_data_source_read_pcm_frames(new ma_data_source_ptr(g_pDecoders[0].pointer), pOutput, frameCount, IntPtr.Zero);
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No input files");
                return;
            }

            ma_result result = ma_result.success;
            UInt32 iDecoder;
            ma_decoder_config decoderConfig;
            ma_device_config deviceConfig;
            ma_device_ptr device;

            g_decoderCount = args.Length;
            g_pDecoders = new ma_decoder_ptr[g_decoderCount];

            for (Int32 i = 0; i < g_pDecoders.Length; i++)
                g_pDecoders[i] = new ma_decoder_ptr(true);

            /* In this example, all decoders need to have the same output format. */
            decoderConfig = ma_decoder_config_init(SAMPLE_FORMAT, CHANNEL_COUNT, SAMPLE_RATE);

            for (iDecoder = 0; iDecoder < g_decoderCount; ++iDecoder)
            {
                result = ma_decoder_init_file(args[iDecoder], ref decoderConfig, g_pDecoders[iDecoder]);
                if (result != ma_result.success)
                {
                    UInt32 iDecoder2;

                    for (iDecoder2 = 0; iDecoder2 < iDecoder; ++iDecoder2)
                    {
                        ma_decoder_uninit(g_pDecoders[iDecoder2]);
                        g_pDecoders[iDecoder2].Free();
                    }

                    Console.WriteLine("Failed to load " + args[iDecoder]);
                    return;
                }
            }

            /*
            We're going to set up our decoders to run one after the other, but then have the last one loop back
            to the first one. For demonstration purposes we're going to use the callback method for the last
            data source.
            */
            for (iDecoder = 0; iDecoder < g_decoderCount - 1; iDecoder += 1)
            {
                // Note that decoders are also considered ma_data_source so we can explicitly convert them to ma_data_source like this:
                ma_data_source_ptr a = new ma_data_source_ptr(g_pDecoders[iDecoder].pointer);
                ma_data_source_ptr b = new ma_data_source_ptr(g_pDecoders[iDecoder + 1].pointer);
                ma_data_source_set_next(a, b);
            }

            /*
            For the last data source we'll loop back to the start, but for demonstration purposes we'll use a
            callback to determine the next data source in the chain.
            */
            ma_data_source_set_next_callback(new ma_data_source_ptr(g_pDecoders[g_decoderCount - 1].pointer), new ma_data_source_get_next_proc(next_callback_tail));

            /*
            The data source chain has been established so now we can get the device up and running so we
            can listen to it.
            */
            deviceConfig = ma_device_config_init(ma_device_type.playback);
            deviceConfig.playback.format = SAMPLE_FORMAT;
            deviceConfig.playback.channels = CHANNEL_COUNT;
            deviceConfig.sampleRate = SAMPLE_RATE;
            deviceConfig.pUserData = IntPtr.Zero;
            deviceConfig.SetDataCallback(new ma_device_data_proc(data_callback));

            device = new ma_device_ptr(true);

            result = ma_device_init(new ma_context_ptr(IntPtr.Zero), ref deviceConfig, device);
            if (result != ma_result.success)
            {
                device.Free();
                Console.WriteLine("Failed to open playback device.");
                goto done_decoders;
            }

            result = ma_device_start(device);
            if (result != ma_result.success)
            {
                Console.WriteLine("Failed to start playback device.");
                goto done;
            }

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

        done:
            ma_device_uninit(device);

        done_decoders:
            for (iDecoder = 0; iDecoder < g_decoderCount; ++iDecoder)
            {
                ma_decoder_uninit(g_pDecoders[iDecoder]);
                g_pDecoders[iDecoder].Free();
            }
            device.Free();
        }
    }
}

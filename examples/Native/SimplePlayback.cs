// Demonstrates how to load a sound file and play it back using the low-level API.
// Original code: https://miniaud.io/docs/examples/simple_playback.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static unsafe void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            ma_decoder_ptr pDecoder = new ma_decoder_ptr(pDevice.Get()->pUserData);
            if (pDecoder.pointer == IntPtr.Zero)
            {
                return;
            }

            ma_decoder_read_pcm_frames(pDecoder, pOutput, frameCount, IntPtr.Zero);
        }

        static unsafe void Main(string[] args)
        {
            ma_result result;
            ma_decoder_ptr decoder;
            ma_device_config deviceConfig;
            ma_device_ptr device;

            if (args.Length < 1)
            {
                Console.WriteLine("No input file.");
                return;
            }

            decoder = new ma_decoder_ptr(true);

            result = ma_decoder_init_file(args[0], decoder);

            if (result != ma_result.success)
            {
                decoder.Free();
                Console.WriteLine("Could not load file: " + args[0]);
                return;
            }

            deviceConfig = ma_device_config_init(ma_device_type.playback);
            deviceConfig.playback.format = decoder.Get()->outputFormat;
            deviceConfig.playback.channels = decoder.Get()->outputChannels;
            deviceConfig.sampleRate = decoder.Get()->outputSampleRate;
            deviceConfig.pUserData = decoder.pointer;
            deviceConfig.SetDataCallback(new ma_device_data_proc(data_callback));

            device = new ma_device_ptr(true);

            if (ma_device_init(new ma_context_ptr(IntPtr.Zero), ref deviceConfig, device) != ma_result.success)
            {
                Console.WriteLine("Failed to open playback device.");
                ma_decoder_uninit(decoder);
                device.Free();
                decoder.Free();
                return;
            }

            if (ma_device_start(device) != ma_result.success)
            {
                Console.WriteLine("Failed to start playback device.");
                ma_device_uninit(device);
                ma_decoder_uninit(decoder);
                device.Free();
                decoder.Free();
                return;
            }

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_device_uninit(device);
            ma_decoder_uninit(decoder);

            device.Free();
            decoder.Free();
        }
    }
}

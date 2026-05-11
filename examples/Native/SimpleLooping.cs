// Shows one way to handle looping of a sound. 
// https://miniaud.io/docs/examples/simple_looping.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    unsafe class Program
    {
        static ma_device_ptr device;
        static ma_decoder_ptr decoder;

        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            ma_decoder_ptr pDecoder = new ma_decoder_ptr(pDevice.Get()->pUserData);
            if (pDecoder.pointer == IntPtr.Zero)
                return;

            /* Reading PCM frames will loop based on what we specified when called ma_data_source_set_looping(). */
            ma_data_source_read_pcm_frames(new ma_data_source_ptr(pDecoder.pointer), pOutput, frameCount, IntPtr.Zero);
        }

        static void Main(string[] args)
        {
            ma_result result;
            ma_device_config deviceConfig;

            if (args.Length < 1)
            {
                Console.WriteLine("No input file.");
                return;
            }

            device = new ma_device_ptr(true);
            decoder = new ma_decoder_ptr(true);

            result = ma_decoder_init_file(args[0], decoder);
            if (result != ma_result.success)
            {
                CleanUp();
                return;
            }

            ma_data_source_set_looping(new ma_data_source_ptr(decoder.pointer), 1);

            deviceConfig = ma_device_config_init(ma_device_type.playback);
            deviceConfig.playback.format = decoder.Get()->outputFormat;
            deviceConfig.playback.channels = decoder.Get()->outputChannels;
            deviceConfig.sampleRate = decoder.Get()->outputSampleRate;
            deviceConfig.SetDataCallback(data_callback);
            deviceConfig.pUserData = decoder.pointer;

            if (ma_device_init(default, ref deviceConfig, device) != ma_result.success)
            {
                Console.WriteLine("Failed to open playback device.");
                ma_decoder_uninit(decoder);
                CleanUp();
                return;
            }

            if (ma_device_start(device) != ma_result.success)
            {
                Console.WriteLine("Failed to start playback device.");
                ma_device_uninit(device);
                ma_decoder_uninit(decoder);
                CleanUp();
                return;
            }

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_device_uninit(device);
            ma_decoder_uninit(decoder);

            CleanUp();
        }

        static void CleanUp()
        {
            device.Free();
            decoder.Free();
        }
    }
}
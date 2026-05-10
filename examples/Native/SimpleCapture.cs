// Demonstrates how to capture data from a microphone using the low-level API.
// Original code: https://miniaud.io/docs/examples/simple_capture.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    unsafe class Program
    {
        static ma_encoder_ptr encoder;
        static ma_device_ptr device;

        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            ma_encoder_ptr pEncoder = new ma_encoder_ptr(pDevice.Get()->pUserData);
            ma_encoder_write_pcm_frames(pEncoder, pInput, frameCount, out _);
        }

        static void Main(string[] args)
        {
            ma_result result;
            ma_encoder_config encoderConfig;
            ma_device_config deviceConfig;

            if (args.Length < 1)
            {
                Console.WriteLine("No output file.");
                return;
            }

            encoder = new ma_encoder_ptr(true);
            device = new ma_device_ptr(true);

            encoderConfig = ma_encoder_config_init(ma_encoding_format.wav, ma_format.f32, 2, 44100);

            if (ma_encoder_init_file(args[0], ref encoderConfig, encoder) != ma_result.success)
            {
                CleanUp();
                Console.WriteLine("Failed to initialize output file.");
                return;
            }

            deviceConfig = ma_device_config_init(ma_device_type.capture);
            deviceConfig.capture.format = encoder.Get()->config.format;
            deviceConfig.capture.channels = encoder.Get()->config.channels;
            deviceConfig.sampleRate = encoder.Get()->config.sampleRate;
            deviceConfig.SetDataCallback(data_callback);
            deviceConfig.pUserData = encoder.pointer;

            result = ma_device_init(default, ref deviceConfig, device);
            if (result != ma_result.success)
            {
                CleanUp();
                Console.WriteLine("Failed to initialize capture device.");
                return;
            }

            result = ma_device_start(device);
            if (result != ma_result.success)
            {
                ma_device_uninit(device);
                CleanUp();
                Console.WriteLine("Failed to start device.");
                return;
            }

            Console.WriteLine("Press Enter to stop recording...");
            Console.ReadLine();

            ma_device_uninit(device);
            ma_encoder_uninit(encoder);
            CleanUp();
        }

        static void CleanUp()
        {
            encoder.Free();
            device.Free();
        }
    }
}
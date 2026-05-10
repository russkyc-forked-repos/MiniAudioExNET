// Demonstrates how to enumerate over devices. 
// Original code: https://miniaud.io/docs/examples/simple_enumeration.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            ma_result result;
            ma_context_ptr context;
            ma_device_info[] pPlaybackDeviceInfos;
            ma_device_info[] pCaptureDeviceInfos;
            Int32 iDevice;

            context = new ma_context_ptr(true);

            if (ma_context_init(null, context) != ma_result.success)
            {
                context.Free();
                Console.WriteLine("Failed to initialize context.");
                return;
            }

            result = ma_context_get_devices(context, out pPlaybackDeviceInfos, out pCaptureDeviceInfos);
            if (result != ma_result.success)
            {
                context.Free();
                Console.WriteLine("Failed to retrieve device information.");
                return;
            }

            Console.WriteLine("Playback Devices");
            for (iDevice = 0; iDevice < pPlaybackDeviceInfos.Length; ++iDevice)
            {
                Console.WriteLine($"{iDevice}: {pPlaybackDeviceInfos[iDevice].GetName()}");
            }

            Console.WriteLine("");

            Console.WriteLine("Capture Devices");
            for (iDevice = 0; iDevice < pCaptureDeviceInfos.Length; ++iDevice)
            {
                Console.WriteLine($"{iDevice}: {pCaptureDeviceInfos[iDevice].GetName()}");
            }

            ma_context_uninit(context);
            context.Free();
        }
    }
}
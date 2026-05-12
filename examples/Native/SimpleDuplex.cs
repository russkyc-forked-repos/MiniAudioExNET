// Demonstrates duplex mode which is where data is captured from a microphone and then output to a speaker device. 
// Original code: https://miniaud.io/docs/examples/simple_duplex.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    unsafe class Program
    {
        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            /* This example assumes the playback and capture sides use the same format and channel count. */
            ma_device_capture_ptr pCapture = ma_device_get_capture(pDevice);
            ma_device_playback_ptr pPlayback = ma_device_get_playback(pDevice);
            
            if (pCapture.Get()->format != pPlayback.Get()->format || pCapture.Get()->channels != pPlayback.Get()->channels) 
                return;

            /* In this example the format and channel count are the same for both input and output which means we can just memcpy(). */
            int size = (int)(frameCount * ma_get_bytes_per_frame(pCapture.Get()->format, pCapture.Get()->channels));
            Buffer.MemoryCopy(pInput.ToPointer(), pOutput.ToPointer(), size, size);
        }

        static void Main(string[] args)
        {
            ma_result result;
            ma_device_config deviceConfig;
            ma_device_ptr device = new ma_device_ptr(true);

            deviceConfig = ma_device_config_init(ma_device_type.duplex);
            deviceConfig.capture.pDeviceID  = new ma_device_id_ptr(IntPtr.Zero);
            deviceConfig.capture.format     = ma_format.s16;
            deviceConfig.capture.channels   = 2;
            deviceConfig.capture.shareMode  = ma_share_mode.shared;
            deviceConfig.playback.pDeviceID = new ma_device_id_ptr(IntPtr.Zero);
            deviceConfig.playback.format    = ma_format.s16;
            deviceConfig.playback.channels  = 2;
            deviceConfig.SetDataCallback(data_callback);
            
            result = ma_device_init(default, ref deviceConfig, device);

            if (result != ma_result.success) 
            {
                Console.WriteLine("Failed to initialize device: " + result);
                device.Free();
                return;
            }

            ma_device_start(device);

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_device_uninit(device);
            device.Free();
        }
    }
}
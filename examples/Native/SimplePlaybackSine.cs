// Demonstrates playback of a sine wave. 
// Original code: https://miniaud.io/docs/examples/simple_playback_sine.html

using System;
using MiniAudioEx.Native;
using static MiniAudioEx.Native.MiniAudioNative;

namespace MiniAudioExamples
{
    unsafe class Program
    {
        static readonly ma_format DEVICE_FORMAT = ma_format.f32;
        static readonly UInt32 DEVICE_CHANNELS = 2;
        static readonly UInt32 DEVICE_SAMPLE_RATE = 48000;
        static ma_waveform_ptr sineWave;
        static ma_device_ptr device;

        static void data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, UInt32 frameCount)
        {
            ma_device_playback_ptr playback = ma_device_get_playback(device);

            if(playback.Get()->channels != DEVICE_CHANNELS)
                return;

            ma_waveform_ptr pSineWave = new ma_waveform_ptr(pDevice.Get()->pUserData);

            if (pSineWave.pointer == IntPtr.Zero)
                return;

            ma_waveform_read_pcm_frames(pSineWave, pOutput, frameCount, out _);
        }

        static void Main(string[] args)
        {
            ma_device_config deviceConfig;
            ma_waveform_config sineWaveConfig;

            sineWave = new ma_waveform_ptr(true);
            device = new ma_device_ptr(true);

            deviceConfig = ma_device_config_init(ma_device_type.playback);
            deviceConfig.playback.format = DEVICE_FORMAT;
            deviceConfig.playback.channels = DEVICE_CHANNELS;
            deviceConfig.sampleRate = DEVICE_SAMPLE_RATE;
            deviceConfig.SetDataCallback(data_callback);
            deviceConfig.pUserData = sineWave.pointer;

            if (ma_device_init(default, ref deviceConfig, device) != ma_result.success)
            {
                Console.WriteLine("Failed to open playback device.");
                CleanUp();
                return;
            }

            ma_device_playback_ptr playback = ma_device_get_playback(device);

            sineWaveConfig = ma_waveform_config_init(playback.Get()->format, playback.Get()->channels, device.Get()->sampleRate, ma_waveform_type.sine, 0.2, 220);
            ma_waveform_init(ref sineWaveConfig, sineWave);

            if (ma_device_start(device) != ma_result.success)
            {
                Console.WriteLine("Failed to start playback device.");
                ma_device_uninit(device);
                CleanUp();
                return;
            }

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            ma_device_uninit(device);

            CleanUp();
        }

        static void CleanUp()
        {
            sineWave.Free();
            device.Free();
        }
    }
}
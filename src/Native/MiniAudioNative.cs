// This software is available as a choice of the following licenses. Choose
// whichever you prefer.

// ===============================================================================
// ALTERNATIVE 1 - Public Domain (www.unlicense.org)
// ===============================================================================
// This is free and unencumbered software released into the public domain.

// Anyone is free to copy, modify, publish, use, compile, sell, or distribute this
// software, either in source code form or as a compiled binary, for any purpose,
// commercial or non-commercial, and by any means.

// In jurisdictions that recognize copyright laws, the author or authors of this
// software dedicate any and all copyright interest in the software to the public
// domain. We make this dedication for the benefit of the public at large and to
// the detriment of our heirs and successors. We intend this dedication to be an
// overt act of relinquishment in perpetuity of all present and future rights to
// this software under copyright law.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
// ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

// For more information, please refer to <http://unlicense.org/>

// ===============================================================================
// ALTERNATIVE 2 - MIT No Attribution
// ===============================================================================
// Copyright 2026 W.M.R Jap-A-Joe

// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
// of the Software, and to permit persons to whom the Software is furnished to do
// so.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniAudioEx.Native
{
    // ma_typedefs
    using ma_channel = Byte;
    using ma_bool8 = Byte;
    using ma_bool32 = UInt32;
    using ma_uint8 = Byte;
    using ma_uint16 = UInt16;
    using ma_int32 = UInt32;
    using ma_uint32 = UInt32;
    using ma_int64 = Int64;
    using ma_uint64 = UInt64;
    using ma_handle = IntPtr;
    using ma_vfs = IntPtr;
    using ma_vfs_file = IntPtr;
    using ma_spinlock = UInt32;

    /// <summary>
    /// Provides P/Invoke bindings to the native miniaudio library.
    /// All methods in this class are thin wrappers around <c>extern</c> DLL imports from the
    /// native <c>miniaudioex</c> shared library. Each method corresponds to a C function in the
    /// miniaudio public API.
    /// </summary>
    public static class MiniAudioNative
    {
        /// <summary>
        /// The maximum number of audio channels supported.
        /// </summary>
        public const int MA_MAX_CHANNELS = 254;
        /// <summary>
        /// The maximum length of a device name string, including the null terminator.
        /// </summary>
        public const int MA_MAX_DEVICE_NAME_LENGTH = 255;
        /// <summary>
        /// The maximum number of log callbacks that can be registered with a single log instance.
        /// </summary>
        public const int MA_MAX_LOG_CALLBACKS = 4;
        /// <summary>
        /// The maximum number of spatial audio listeners supported by the engine.
        /// </summary>
        public const int MA_ENGINE_MAX_LISTENERS = 4;
        /// <summary>
        /// The maximum number of local buses supported by a node. Used internally for memory management and must never exceed MA_MAX_NODE_BUS_COUNT.
        /// </summary>
        public const int MA_MAX_NODE_LOCAL_BUS_COUNT = 2;
        /// <summary>
        /// The maximum number of buses a node can have.
        /// </summary>
        public const int MA_MAX_NODE_BUS_COUNT = 254;
        /// <summary>
        /// Indicates that the bus count for a node is unknown and must be determined on a per-node basis via the node configuration.
        /// </summary>
        public const int MA_NODE_BUS_COUNT_UNKNOWN = 255;

        private const string LIB_MINIAUDIO_EX = "miniaudioex";

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the number of bytes per sample for the given audio format.
        /// </summary>
        /// <param name="format">The audio format to query.</param>
        /// <returns>The number of bytes per sample for the specified format.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_get_bytes_per_sample(ma_format format);

        /// <summary>
        /// Managed helper that calculates the number of bytes per frame by multiplying bytes per sample with the channel count.
        /// </summary>
        /// <param name="format">The audio format.</param>
        /// <param name="channels">The number of channels.</param>
        /// <returns>The number of bytes per frame for the given format and channel count.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ma_uint32 ma_get_bytes_per_frame(ma_format format, ma_uint32 channels) 
        { 
            return ma_get_bytes_per_sample(format) * channels; 
        }

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Allocates memory for a structure of the given allocation type.
        /// </summary>
        /// <param name="type">The allocation type that determines the size of the allocated memory block.</param>
        /// <returns>A pointer to the allocated memory, or IntPtr.Zero if allocation fails.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ma_allocate_type(ma_allocation_type type);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Allocates a block of memory of the specified size.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <returns>A pointer to the allocated memory, or IntPtr.Zero if allocation fails.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ma_allocate(size_t size);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Frees memory previously allocated with ma_allocate_type.
        /// </summary>
        /// <param name="pData">A pointer to the memory block to free.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_deallocate_type(IntPtr pData);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the size in bytes of the structure associated with the given allocation type.
        /// </summary>
        /// <param name="type">The allocation type to query.</param>
        /// <returns>The size in bytes of the structure for the specified allocation type.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_get_size_of_type(ma_allocation_type type);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Initializes and returns an engine configuration with default settings.
        /// </summary>
        /// <returns>A default-initialized engine configuration structure.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_config ma_engine_config_init();

        // ma_device
        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Initializes a device configuration structure with default settings for the given device type.
        /// </summary>
        /// <param name="deviceType">The type of device (playback, capture, duplex, or loopback).</param>
        /// <returns>A default-initialized device configuration.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_config ma_device_config_init(ma_device_type deviceType);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Initializes a device with the given context and configuration.
        /// </summary>
        /// <param name="pContext">A pointer to the initialized context that will own the device.</param>
        /// <param name="pConfig">The device configuration.</param>
        /// <param name="pDevice">A pointer to the uninitialized device structure to initialize.</param>
        /// <returns>MA_SUCCESS if the device was initialized successfully, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_init(ma_context_ptr pContext, ref ma_device_config pConfig, ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Uninitializes a previously initialized device, releasing its resources.
        /// </summary>
        /// <param name="pDevice">A pointer to the device to uninitialize.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_device_uninit(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the context that owns this device.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <returns>A pointer to the context that owns the device.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_context_ptr ma_device_get_context(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Starts the device, beginning audio processing.
        /// </summary>
        /// <param name="pDevice">A pointer to the device to start.</param>
        /// <returns>MA_SUCCESS if the device was started successfully, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_start(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Stops the device, halting audio processing.
        /// </summary>
        /// <param name="pDevice">A pointer to the device to stop.</param>
        /// <returns>MA_SUCCESS if the device was stopped successfully, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_stop(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Queries whether the device has been started.
        /// </summary>
        /// <param name="pDevice">A pointer to the device to query.</param>
        /// <returns>MA_TRUE if the device is started, otherwise MA_FALSE.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_device_is_started(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current state of the device.
        /// </summary>
        /// <param name="pDevice">A pointer to the device to query.</param>
        /// <returns>The current device state (started, stopped, starting, or stopping).</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_state ma_device_get_state(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the master volume of the device on a linear scale.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <param name="volume">The linear volume level, where 1.0 is the default.</param>
        /// <returns>MA_SUCCESS if the volume was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_set_master_volume(ma_device_ptr pDevice, float volume);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current master volume of the device on a linear scale.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <param name="pVolume">Receives the current linear volume level.</param>
        /// <returns>MA_SUCCESS if the volume was retrieved, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_get_master_volume(ma_device_ptr pDevice, out float pVolume);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the master volume of the device in decibels.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <param name="gainDB">The volume level in decibels, where 0 is the default.</param>
        /// <returns>MA_SUCCESS if the volume was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_set_master_volume_db(ma_device_ptr pDevice, float gainDB);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current master volume of the device in decibels.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <param name="pGainDB">Receives the current volume level in decibels.</param>
        /// <returns>MA_SUCCESS if the volume was retrieved, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_get_master_volume_db(ma_device_ptr pDevice, out float pGainDB);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Manually processes backend-level data for the device, used when the device is not started automatically.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <param name="pOutput">A pointer to the output buffer that will receive the processed audio data.</param>
        /// <param name="pInput">A pointer to the input buffer containing incoming audio data.</param>
        /// <param name="frameCount">The number of audio frames to process.</param>
        /// <returns>MA_SUCCESS if the data callback was handled, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_handle_backend_data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, ma_uint32 frameCount);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the device's resampling configuration.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <returns>A pointer to the resampling data of the device.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_resampling_ptr ma_device_get_resampling(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the device's playback configuration and state.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <returns>A pointer to the playback data of the device.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_playback_ptr ma_device_get_playback(ma_device_ptr pDevice);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the device's capture configuration and state.
        /// </summary>
        /// <param name="pDevice">A pointer to the device.</param>
        /// <returns>A pointer to the capture data of the device.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_capture_ptr ma_device_get_capture(ma_device_ptr pDevice);

        // ma_context
        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Initializes and returns a context configuration structure with default settings.
        /// </summary>
        /// <returns>A default-initialized context configuration.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_context_config ma_context_config_init();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_context_init(ma_backend* backends, ma_uint32 backendCount, ma_context_config* pConfig, ma_context_ptr pContext);

        /// <summary>
        /// Managed helper that initializes a context with the specified backend array and custom configuration. Calls the native ma_context_init function.
        /// </summary>
        /// <param name="backends">An array of backends to try, in order of preference. Pass null or an empty array to use default backends.</param>
        /// <param name="config">The context configuration settings.</param>
        /// <param name="pContext">A pointer to the uninitialized context structure.</param>
        /// <returns>MA_SUCCESS if the context was initialized successfully, otherwise an error code.</returns>
        public static unsafe ma_result ma_context_init(ma_backend[] backends, ref ma_context_config config, ma_context_ptr pContext)
        {
            fixed (ma_context_config* pConfig = &config)
            {
                if (backends?.Length > 0)
                {
                    fixed (ma_backend* pBackends = &backends[0])
                    {
                        return ma_context_init(pBackends, (UInt32)backends.Length, pConfig, pContext);
                    }
                }
                else
                {
                    return ma_context_init(null, 0, pConfig, pContext);
                }
            }
        }

        /// <summary>
        /// Managed helper that initializes a context with the specified backend array using default configuration. Calls the native ma_context_init function with a null config pointer.
        /// </summary>
        /// <param name="backends">An array of backends to try, in order of preference. Pass null or an empty array to use default backends.</param>
        /// <param name="pContext">A pointer to the uninitialized context structure.</param>
        /// <returns>MA_SUCCESS if the context was initialized successfully, otherwise an error code.</returns>
        public static unsafe ma_result ma_context_init(ma_backend[] backends, ma_context_ptr pContext)
        {
            if (backends?.Length > 0)
            {
                fixed (ma_backend* pBackends = &backends[0])
                {
                    return ma_context_init(pBackends, (UInt32)backends.Length, null, pContext);
                }
            }
            else
            {
                return ma_context_init(null, 0, null, pContext);
            }
        }

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Uninitializes a previously initialized context, releasing its resources.
        /// </summary>
        /// <param name="pContext">A pointer to the context to uninitialize.</param>
        /// <returns>MA_SUCCESS if the context was uninitialized successfully, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_context_uninit(ma_context_ptr pContext);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Returns the size in bytes of the context structure.
        /// </summary>
        /// <returns>The size of the context structure in bytes.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_context_sizeof();

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the log instance associated with the context.
        /// </summary>
        /// <param name="pContext">A pointer to the context.</param>
        /// <returns>A pointer to the log instance of the context.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_context_get_log(ma_context_ptr pContext);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_context_enumerate_devices(ma_context_ptr pContext, IntPtr callback, IntPtr pUserData);

        /// <summary>
        /// Managed helper that enumerates available audio devices, invoking the provided callback for each device found.
        /// </summary>
        /// <param name="pContext">A pointer to the context.</param>
        /// <param name="callback">The delegate to invoke for each enumerated device.</param>
        /// <param name="pUserData">A user data pointer passed to each callback invocation.</param>
        /// <returns>MA_SUCCESS if enumeration was successful, otherwise an error code.</returns>
        public static ma_result ma_context_enumerate_devices(ma_context_ptr pContext, ma_enum_devices_callback_proc callback, IntPtr pUserData)
        {
            return ma_context_enumerate_devices(pContext, MarshalHelper.GetFunctionPointerForDelegate(callback), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_context_get_devices(ma_context_ptr pContext, ma_device_info** ppPlaybackDeviceInfos, ma_uint32* pPlaybackDeviceCount, ma_device_info** ppCaptureDeviceInfos, ma_uint32* pCaptureDeviceCount);

        /// <summary>
        /// Managed helper that retrieves arrays of playback and capture device information for the given context.
        /// Copies the native device info structures into managed arrays for safe use in .NET code.
        /// </summary>
        /// <param name="pContext">A pointer to the context.</param>
        /// <param name="ppPlaybackDeviceInfos">Receives an array of playback device information, or null if none are available.</param>
        /// <param name="ppCaptureDeviceInfos">Receives an array of capture device information, or null if none are available.</param>
        /// <returns>MA_SUCCESS if devices were retrieved successfully, otherwise an error code.</returns>
        public static unsafe ma_result ma_context_get_devices(ma_context_ptr pContext, out ma_device_info[] ppPlaybackDeviceInfos, out ma_device_info[] ppCaptureDeviceInfos)
        {
            ppPlaybackDeviceInfos = null;
            ppCaptureDeviceInfos = null;
            ma_uint32 captureCount = 0;
            ma_uint32 playbackCount = 0;
            ma_device_info* pPlayback = null;
            ma_device_info* pCapture = null;

            ma_result result = ma_context_get_devices(pContext, &pPlayback, &playbackCount, &pCapture, &captureCount);

            if (result != ma_result.success)
                return result;

            if (pPlayback != null && playbackCount > 0)
            {
                ppPlaybackDeviceInfos = new ma_device_info[playbackCount];

                for (int i = 0; i < playbackCount; i++)
                {
                    ppPlaybackDeviceInfos[i] = pPlayback[i];
                }
            }

            if (pCapture != null && captureCount > 0)
            {
                ppCaptureDeviceInfos = new ma_device_info[captureCount];

                for (int i = 0; i < captureCount; i++)
                {
                    ppCaptureDeviceInfos[i] = pCapture[i];
                }
            }

            return result;
        }

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves detailed information about a specific audio device.
        /// </summary>
        /// <param name="pContext">A pointer to the context.</param>
        /// <param name="deviceType">The type of device to query (playback or capture).</param>
        /// <param name="pDeviceID">A pointer to the device ID to retrieve information for.</param>
        /// <param name="pDeviceInfo">Receives the device information structure.</param>
        /// <returns>MA_SUCCESS if the device info was retrieved, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_context_get_device_info(ma_context_ptr pContext, ma_device_type deviceType, ma_device_id_ptr pDeviceID, out ma_device_info pDeviceInfo);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Queries whether loopback audio capture is supported by the current backend.
        /// </summary>
        /// <param name="pContext">A pointer to the context.</param>
        /// <returns>MA_TRUE if loopback is supported, otherwise MA_FALSE.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_context_is_loopback_supported(ma_context_ptr pContext);

        // ma_engine
        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Uninitializes a previously initialized engine, releasing its resources.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine to uninitialize.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_uninit(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Initializes an engine with the given configuration.
        /// </summary>
        /// <param name="pConfig">The engine configuration, typically obtained from ma_engine_config_init.</param>
        /// <param name="pEngine">A pointer to the uninitialized engine structure.</param>
        /// <returns>MA_SUCCESS if the engine was initialized successfully, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_init(ref ma_engine_config pConfig, ma_engine_ptr pEngine);

        /// <summary>
        /// Managed helper that initializes an engine with default configuration settings.
        /// </summary>
        /// <param name="pEngine">A pointer to the uninitialized engine structure.</param>
        /// <returns>MA_SUCCESS if the engine was initialized successfully, otherwise an error code.</returns>
        public static ma_result ma_engine_init(ma_engine_ptr pEngine)
        {
            ma_engine_config config = ma_engine_config_init();
            return ma_engine_init(ref config, pEngine);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint64* pFramesRead);

        /// <summary>
        /// Managed helper that reads PCM frames from the engine's output, reporting the number of frames actually read.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="pFramesOut">A pointer to the output buffer that will receive the PCM frame data.</param>
        /// <param name="frameCount">The number of frames to read.</param>
        /// <param name="framesRead">Receives the number of frames actually read.</param>
        /// <returns>MA_SUCCESS if frames were read, otherwise an error code.</returns>
        public static unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount, ref ma_uint64 framesRead)
        {
            fixed (ma_uint64* pFramesRead = &framesRead)
            {
                return ma_engine_read_pcm_frames(pEngine, pFramesOut, frameCount, pFramesRead);
            }
        }

        /// <summary>
        /// Managed helper that reads PCM frames from the engine's output without tracking the number of frames read.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="pFramesOut">A pointer to the output buffer that will receive the PCM frame data.</param>
        /// <param name="frameCount">The number of frames to read.</param>
        /// <returns>MA_SUCCESS if frames were read, otherwise an error code.</returns>
        public static unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount)
        {
            return ma_engine_read_pcm_frames(pEngine, pFramesOut, frameCount, null);
        }

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the engine's internal node graph.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>A pointer to the node graph of the engine.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_ptr ma_engine_get_node_graph(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the engine's resource manager.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>A pointer to the resource manager of the engine.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_resource_manager_ptr ma_engine_get_resource_manager(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the audio device bound to the engine.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>A pointer to the device owned by the engine.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_ptr ma_engine_get_device(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the engine's log instance.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>A pointer to the log instance of the engine.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_engine_get_log(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves a pointer to the engine's endpoint node, which is the final node in the audio graph.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>A pointer to the endpoint node of the engine's node graph.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_ptr ma_engine_get_endpoint(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current global time of the engine in PCM frames.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The current global time in PCM frames.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_engine_get_time_in_pcm_frames(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current global time of the engine in milliseconds.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The current global time in milliseconds.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_engine_get_time_in_milliseconds(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the current global time of the engine in PCM frames.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="globalTime">The new global time in PCM frames.</param>
        /// <returns>MA_SUCCESS if the time was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_time_in_pcm_frames(ma_engine_ptr pEngine, ma_uint64 globalTime);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the current global time of the engine in milliseconds.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="globalTime">The new global time in milliseconds.</param>
        /// <returns>MA_SUCCESS if the time was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_time_in_milliseconds(ma_engine_ptr pEngine, ma_uint64 globalTime);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the number of audio channels configured for the engine.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The number of channels.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_channels(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the sample rate configured for the engine.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The sample rate in Hz.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_sample_rate(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Starts the engine's audio device, beginning audio processing.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine to start.</param>
        /// <returns>MA_SUCCESS if the engine was started, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_start(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Stops the engine's audio device, halting audio processing.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine to stop.</param>
        /// <returns>MA_SUCCESS if the engine was stopped, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_stop(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the master volume of the engine on a linear scale.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="volume">The linear volume level, where 1.0 is the default.</param>
        /// <returns>MA_SUCCESS if the volume was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_volume(ma_engine_ptr pEngine, float volume);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current master volume of the engine on a linear scale.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The current linear volume level.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_engine_get_volume(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the master volume of the engine in decibels.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="gainDB">The volume level in decibels, where 0 is the default.</param>
        /// <returns>MA_SUCCESS if the gain was set, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_gain_db(ma_engine_ptr pEngine, float gainDB);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the current master volume of the engine in decibels.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The current volume level in decibels.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_engine_get_gain_db(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the number of spatial audio listeners active in the engine.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <returns>The number of active listeners.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_listener_count(ma_engine_ptr pEngine);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Finds the index of the listener closest to the specified absolute position.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="absolutePosX">The X coordinate of the position to test.</param>
        /// <param name="absolutePosY">The Y coordinate of the position to test.</param>
        /// <param name="absolutePosZ">The Z coordinate of the position to test.</param>
        /// <returns>The index of the closest listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_find_closest_listener(ma_engine_ptr pEngine, float absolutePosX, float absolutePosY, float absolutePosZ);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the position of a spatial audio listener in 3D space.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="x">The X coordinate of the listener position.</param>
        /// <param name="y">The Y coordinate of the listener position.</param>
        /// <param name="z">The Z coordinate of the listener position.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_position(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the position of a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <returns>The position of the listener as a 3D vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_position(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the direction vector of a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="x">The X component of the direction vector.</param>
        /// <param name="y">The Y component of the direction vector.</param>
        /// <param name="z">The Z component of the direction vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_direction(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the direction vector of a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <returns>The direction vector of the listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_direction(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the velocity vector of a spatial audio listener for Doppler effect calculation.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="x">The X component of the velocity vector.</param>
        /// <param name="y">The Y component of the velocity vector.</param>
        /// <param name="z">The Z component of the velocity vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_velocity(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the velocity vector of a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <returns>The velocity vector of the listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_velocity(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the cone parameters for a spatial audio listener, defining directional attenuation.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="innerAngleInRadians">The inner angle of the cone in radians, where gain is at full volume.</param>
        /// <param name="outerAngleInRadians">The outer angle of the cone in radians, where gain transitions to outerGain.</param>
        /// <param name="outerGain">The gain applied outside the outer cone angle.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_cone(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the cone parameters for a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <param name="pInnerAngleInRadians">Receives the inner cone angle in radians.</param>
        /// <param name="pOuterAngleInRadians">Receives the outer cone angle in radians.</param>
        /// <param name="pOuterGain">Receives the gain applied outside the outer cone.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_get_cone(ma_engine_ptr pEngine, ma_uint32 listenerIndex, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Sets the world-up vector for a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="x">The X component of the world-up vector.</param>
        /// <param name="y">The Y component of the world-up vector.</param>
        /// <param name="z">The Z component of the world-up vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_world_up(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Retrieves the world-up vector for a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <returns>The world-up vector of the listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_world_up(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Enables or disables a spatial audio listener.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to modify.</param>
        /// <param name="isEnabled">MA_TRUE to enable the listener, MA_FALSE to disable it.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_enabled(ma_engine_ptr pEngine, ma_uint32 listenerIndex, ma_bool32 isEnabled);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Queries whether a spatial audio listener is enabled.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="listenerIndex">The index of the listener to query.</param>
        /// <returns>MA_TRUE if the listener is enabled, otherwise MA_FALSE.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_engine_listener_is_enabled(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Plays a sound file from the given path, attaching it to a specific node and input bus.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="pFilePath">The file path of the audio file to play.</param>
        /// <param name="pNode">A pointer to the node to attach the sound to.</param>
        /// <param name="nodeInputBusIndex">The input bus index on the target node to attach the sound to.</param>
        /// <returns>MA_SUCCESS if playback started, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_play_sound_ex(ma_engine_ptr pEngine, string pFilePath, ma_node_ptr pNode, ma_uint32 nodeInputBusIndex);

        /// <summary>
        /// Native function wrapper for the miniaudioex C API. Plays a sound file in a fire-and-forget manner. The returned sound is attached to the engine's endpoint and begins playing immediately.
        /// </summary>
        /// <param name="pEngine">A pointer to the engine.</param>
        /// <param name="pFilePath">The file path of the audio file to play.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <returns>MA_SUCCESS if the sound was created and set to play, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_play_sound(ma_engine_ptr pEngine, string pFilePath, ma_sound_group_ptr pGroup);   /* Fire and forget. */

        // ma_sound
        /// <summary>Initializes a sound from a file path for playback with the given engine.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pFilePath">The file path of the audio file to load.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played (e.g. MA_SOUND_FLAG_DECODE, MA_SOUND_FLAG_STREAM, MA_SOUND_FLAG_ASYNC).</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pDoneFence">Optional fence that is signalled when async loading completes. Pass IntPtr.Zero if not needed.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_file(ma_engine_ptr pEngine, string pFilePath, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        /// <summary>Initializes a sound from a wide-char file path for playback with the given engine.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pFilePath">The wide-char file path of the audio file to load.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pDoneFence">Optional fence that is signalled when async loading completes. Pass IntPtr.Zero if not needed.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_file_w(ma_engine_ptr pEngine, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        /// <summary>Initializes a sound from in-memory audio data for playback with the given engine.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pData">Pointer to the memory buffer containing the encoded audio data.</param>
        /// <param name="dataSize">The size of the memory buffer in bytes.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pDoneFence">Optional fence that is signalled when async loading completes. Pass IntPtr.Zero if not needed.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_memory(ma_engine_ptr pEngine, IntPtr pData, ma_uint64 dataSize, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        /// <summary>Initializes a sound from a procedural data source callback for playback with the given engine.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pConfig">Configuration for the procedural data source including format, channels, sample rate and callback.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pDoneFence">Optional fence that is signalled when async loading completes. Pass IntPtr.Zero if not needed.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_callback(ma_engine_ptr pEngine, ref ma_procedural_data_source_config pConfig, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        /// <summary>Initializes a sound as a copy of an existing sound.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pExistingSound">Pointer to the existing sound to copy.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_copy(ma_engine_ptr pEngine, ma_sound_ptr pExistingSound, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_sound_ptr pSound);

        /// <summary>Initializes a sound from an existing data source for playback with the given engine.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pDataSource">Pointer to an existing data source.</param>
        /// <param name="flags">Flags controlling how the sound is loaded and played.</param>
        /// <param name="pGroup">Optional sound group to attach the sound to. Pass IntPtr.Zero for no group.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_data_source(ma_engine_ptr pEngine, ma_data_source_ptr pDataSource, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_sound_ptr pSound);

        /// <summary>Initializes a sound with full configuration for maximum flexibility.</summary>
        /// <param name="pEngine">The engine to use for playback.</param>
        /// <param name="pConfig">Full sound configuration including data source, end callback, and spatialization settings.</param>
        /// <param name="pSound">Pointer to the sound object to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_ex(ma_engine_ptr pEngine, ref ma_sound_config pConfig, ma_sound_ptr pSound);

        /// <summary>Uninitializes and frees resources associated with a sound.</summary>
        /// <param name="pSound">Pointer to the sound to uninitialize.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_uninit(ma_sound_ptr pSound);

        /// <summary>Retrieves the engine that owns this sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Pointer to the engine that owns the sound.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_ptr ma_sound_get_engine(ma_sound_ptr pSound);

        /// <summary>Retrieves the underlying data source of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Pointer to the data source associated with the sound.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_sound_get_data_source(ma_sound_ptr pSound);

        /// <summary>Starts playback of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_start(ma_sound_ptr pSound);

        /// <summary>Stops playback of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop(ma_sound_ptr pSound);

        /// <summary>Stops playback with a fade-out over the specified number of PCM frames. Overwrites any scheduled stop and fade.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="fadeLengthInFrames">The fade-out duration in PCM frames.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop_with_fade_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 fadeLengthInFrames);     /* Will overwrite any scheduled stop and fade. */

        /// <summary>Stops playback with a fade-out over the specified duration in milliseconds. Overwrites any scheduled stop and fade.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="fadeLengthInFrames">The fade-out duration in milliseconds.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop_with_fade_in_milliseconds(ma_sound_ptr pSound, ma_uint64 fadeLengthInFrames);   /* Will overwrite any scheduled stop and fade. */

        /// <summary>Sets the volume of the sound. A value of 1.0 is the default volume.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="volume">The volume level, where 0.0 is silence and 1.0 is default.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_volume(ma_sound_ptr pSound, float volume);

        /// <summary>Retrieves the current volume of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current volume level.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_volume(ma_sound_ptr pSound);

        /// <summary>Sets the pan of the sound. -1.0 is left, 0.0 is center, 1.0 is right.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pan">The pan value, typically between -1.0 (left) and 1.0 (right).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pan(ma_sound_ptr pSound, float pan);

        /// <summary>Retrieves the current pan of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current pan value, where -1.0 is left, 0.0 is center, and 1.0 is right.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_pan(ma_sound_ptr pSound);

        /// <summary>Sets the pan mode of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="panMode">The panning mode (e.g. balance or pan).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pan_mode(ma_sound_ptr pSound, ma_pan_mode panMode);

        /// <summary>Retrieves the current pan mode of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current pan mode.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_sound_get_pan_mode(ma_sound_ptr pSound);

        /// <summary>Sets the pitch of the sound. A value of 1.0 is the default pitch.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pitch">The pitch multiplier, where 1.0 is normal pitch.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pitch(ma_sound_ptr pSound, float pitch);

        /// <summary>Retrieves the current pitch of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current pitch multiplier.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_pitch(ma_sound_ptr pSound);

        /// <summary>Enables or disables spatialization for the sound. When enabled, the sound will be spatialized based on its position relative to the listener.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="enabled">Whether spatialization is enabled (non-zero) or disabled (0).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_spatialization_enabled(ma_sound_ptr pSound, ma_bool32 enabled);

        /// <summary>Returns whether spatialization is enabled for the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Non-zero if spatialization is enabled, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_spatialization_enabled(ma_sound_ptr pSound);

        /// <summary>Pins the sound to a specific listener index, forcing it to always use that listener.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="listenerIndex">The index of the listener to pin the sound to.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pinned_listener_index(ma_sound_ptr pSound, ma_uint32 listenerIndex);

        /// <summary>Returns the pinned listener index for the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The index of the pinned listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_get_pinned_listener_index(ma_sound_ptr pSound);

        /// <summary>Returns the listener index currently used by the sound for spatialization.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The index of the currently active listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_get_listener_index(ma_sound_ptr pSound);

        /// <summary>Returns the direction vector from the sound to the active listener.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>A <see cref="ma_vec3f"/> representing the direction to the listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_direction_to_listener(ma_sound_ptr pSound);

        /// <summary>Sets the position of the sound in 3D space for spatialization.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        /// <param name="z">The Z coordinate of the position.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_position(ma_sound_ptr pSound, float x, float y, float z);

        /// <summary>Retrieves the current position of the sound in 3D space.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound's position.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_position(ma_sound_ptr pSound);

        /// <summary>Sets the direction the sound is facing in 3D space for directional attenuation.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="x">The X component of the direction vector.</param>
        /// <param name="y">The Y component of the direction vector.</param>
        /// <param name="z">The Z component of the direction vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_direction(ma_sound_ptr pSound, float x, float y, float z);

        /// <summary>Retrieves the current direction the sound is facing.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound's direction vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_direction(ma_sound_ptr pSound);

        /// <summary>Sets the velocity of the sound in 3D space for Doppler effect calculation.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="x">The X component of the velocity vector.</param>
        /// <param name="y">The Y component of the velocity vector.</param>
        /// <param name="z">The Z component of the velocity vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_velocity(ma_sound_ptr pSound, float x, float y, float z);

        /// <summary>Retrieves the current velocity of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound's velocity vector for Doppler effect.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_velocity(ma_sound_ptr pSound);

        /// <summary>Sets the attenuation model for the sound, which controls how volume decreases with distance.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="attenuationModel">The attenuation model to use (e.g. none, inverse, linear, exponential).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_attenuation_model(ma_sound_ptr pSound, ma_attenuation_model attenuationModel);

        /// <summary>Retrieves the current attenuation model of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current attenuation model.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_sound_get_attenuation_model(ma_sound_ptr pSound);

        /// <summary>Sets the positioning mode for the sound (absolute or relative).</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="positioning">The positioning mode.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_positioning(ma_sound_ptr pSound, ma_positioning positioning);

        /// <summary>Retrieves the current positioning mode of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current positioning mode.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_sound_get_positioning(ma_sound_ptr pSound);

        /// <summary>Sets the rolloff factor for the sound, controlling the rate of attenuation.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="rolloff">The rolloff factor.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_rolloff(ma_sound_ptr pSound, float rolloff);

        /// <summary>Retrieves the current rolloff factor of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current rolloff factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_rolloff(ma_sound_ptr pSound);

        /// <summary>Sets the minimum gain (volume) of the sound at maximum distance.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="minGain">The minimum gain value, clamped between 0.0 and 1.0.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_min_gain(ma_sound_ptr pSound, float minGain);

        /// <summary>Retrieves the current minimum gain of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current minimum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_min_gain(ma_sound_ptr pSound);

        /// <summary>Sets the maximum gain (volume) of the sound at minimum distance.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="maxGain">The maximum gain value, clamped between 0.0 and 1.0.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_max_gain(ma_sound_ptr pSound, float maxGain);

        /// <summary>Retrieves the current maximum gain of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current maximum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_max_gain(ma_sound_ptr pSound);

        /// <summary>Sets the minimum distance for the sound's attenuation. At this distance the sound is at max gain.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="minDistance">The minimum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_min_distance(ma_sound_ptr pSound, float minDistance);

        /// <summary>Retrieves the current minimum distance of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current minimum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_min_distance(ma_sound_ptr pSound);

        /// <summary>Sets the maximum distance for the sound's attenuation. At this distance the sound is at min gain.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="maxDistance">The maximum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_max_distance(ma_sound_ptr pSound, float maxDistance);

        /// <summary>Retrieves the current maximum distance of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current maximum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_max_distance(ma_sound_ptr pSound);

        /// <summary>Sets the sound cone parameters for directional attenuation. The cone has an inner angle at full gain and an outer angle at outer gain.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="innerAngleInRadians">The inner cone angle in radians, inside which the sound is at full volume.</param>
        /// <param name="outerAngleInRadians">The outer cone angle in radians, beyond which the sound is at outer gain.</param>
        /// <param name="outerGain">The gain applied outside the outer cone angle.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_cone(ma_sound_ptr pSound, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        /// <summary>Retrieves the current cone parameters of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pInnerAngleInRadians">Receives the inner cone angle in radians.</param>
        /// <param name="pOuterAngleInRadians">Receives the outer cone angle in radians.</param>
        /// <param name="pOuterGain">Receives the outer cone gain.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_get_cone(ma_sound_ptr pSound, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        /// <summary>Sets the Doppler factor for the sound. Set to 0 to disable the Doppler effect.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="dopplerFactor">The Doppler factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_doppler_factor(ma_sound_ptr pSound, float dopplerFactor);

        /// <summary>Retrieves the current Doppler factor of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current Doppler factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_doppler_factor(ma_sound_ptr pSound);

        /// <summary>Sets the directional attenuation factor for the sound. Set to 0 to disable directional attenuation.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="directionalAttenuationFactor">The directional attenuation factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_directional_attenuation_factor(ma_sound_ptr pSound, float directionalAttenuationFactor);

        /// <summary>Retrieves the current directional attenuation factor of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current directional attenuation factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_directional_attenuation_factor(ma_sound_ptr pSound);

        /// <summary>Schedules a volume fade-in over the specified number of PCM frames, starting immediately.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInFrames">The duration of the fade in PCM frames.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_in_pcm_frames(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames);

        /// <summary>Schedules a volume fade-in over the specified duration in milliseconds, starting immediately.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInMilliseconds">The duration of the fade in milliseconds.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_in_milliseconds(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds);

        /// <summary>Schedules a volume fade starting at a specific global time in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInFrames">The duration of the fade in PCM frames.</param>
        /// <param name="absoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to start the fade.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_start_in_pcm_frames(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames, ma_uint64 absoluteGlobalTimeInFrames);

        /// <summary>Schedules a volume fade starting at a specific global time in milliseconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInMilliseconds">The duration of the fade in milliseconds.</param>
        /// <param name="absoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to start the fade.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_start_in_milliseconds(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds, ma_uint64 absoluteGlobalTimeInMilliseconds);

        /// <summary>Retrieves the current fade volume of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The current fade volume applied to the sound.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_current_fade_volume(ma_sound_ptr pSound);

        /// <summary>Schedules the sound to start playing at the specified absolute global time in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="absoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to start the sound.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_start_time_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInFrames);

        /// <summary>Schedules the sound to start playing at the specified absolute global time in milliseconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="absoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to start the sound.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_start_time_in_milliseconds(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInMilliseconds);

        /// <summary>Schedules the sound to stop playing at the specified absolute global time in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="absoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to stop the sound.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInFrames);

        /// <summary>Schedules the sound to stop playing at the specified absolute global time in milliseconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="absoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to stop the sound.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_in_milliseconds(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInMilliseconds);

        /// <summary>Schedules the sound to stop at a specific global time with a fade-out in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="stopAbsoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to stop.</param>
        /// <param name="fadeLengthInFrames">The fade-out duration in PCM frames.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_with_fade_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 stopAbsoluteGlobalTimeInFrames, ma_uint64 fadeLengthInFrames);

        /// <summary>Schedules the sound to stop at a specific global time with a fade-out in milliseconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="stopAbsoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to stop.</param>
        /// <param name="fadeLengthInMilliseconds">The fade-out duration in milliseconds.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_with_fade_in_milliseconds(ma_sound_ptr pSound, ma_uint64 stopAbsoluteGlobalTimeInMilliseconds, ma_uint64 fadeLengthInMilliseconds);

        /// <summary>Returns whether the sound is currently playing.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Non-zero if the sound is playing, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_playing(ma_sound_ptr pSound);

        /// <summary>Returns the current playback position of the sound in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The time in PCM frames since the sound started playing.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_get_time_in_pcm_frames(ma_sound_ptr pSound);

        /// <summary>Returns the current playback position of the sound in milliseconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>The time in milliseconds since the sound started playing.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_get_time_in_milliseconds(ma_sound_ptr pSound);

        /// <summary>Sets whether the sound should loop when it reaches the end.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="isLooping">Non-zero to enable looping, zero to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_looping(ma_sound_ptr pSound, ma_bool32 isLooping);

        /// <summary>Returns whether the sound is set to loop.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Non-zero if looping is enabled, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_looping(ma_sound_ptr pSound);

        /// <summary>Returns whether the sound has reached the end of playback.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <returns>Non-zero if the sound has reached the end, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_at_end(ma_sound_ptr pSound);

        /// <summary>Seeks to a specific PCM frame in the sound. This is a wrapper around ma_data_source_seek_to_pcm_frame().</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="frameIndex">The PCM frame index to seek to.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_seek_to_pcm_frame(ma_sound_ptr pSound, ma_uint64 frameIndex); /* Just a wrapper around ma_data_source_seek_to_pcm_frame(). */

        /// <summary>Seeks to a specific time in seconds. Abstraction to ma_sound_seek_to_pcm_frame().</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="seekPointInSeconds">The time in seconds to seek to.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_seek_to_second(ma_sound_ptr pSound, float seekPointInSeconds); /* Abstraction to ma_sound_seek_to_pcm_frame() */

        /// <summary>Retrieves the data format (sample format, channels, sample rate) of the sound.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pFormat">Receives the sample format (e.g. f32, s16).</param>
        /// <param name="pChannels">Receives the number of channels.</param>
        /// <param name="pSampleRate">Receives the sample rate in Hz.</param>
        /// <param name="pChannelMap">Receives the channel map. Can be 0 if not needed.</param>
        /// <param name="channelMapCap">The capacity of the channel map buffer.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_data_format(ma_sound_ptr pSound, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, Byte pChannelMap, size_t channelMapCap);

        /// <summary>Retrieves the current playback cursor position in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pCursor">Receives the current cursor position in PCM frames.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_cursor_in_pcm_frames(ma_sound_ptr pSound, out ma_uint64 pCursor);

        /// <summary>Retrieves the total length of the sound in PCM frames.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pLength">Receives the total length in PCM frames.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_length_in_pcm_frames(ma_sound_ptr pSound, out ma_uint64 pLength);

        /// <summary>Retrieves the current playback cursor position in seconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pCursor">Receives the current cursor position in seconds.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_cursor_in_seconds(ma_sound_ptr pSound, out float pCursor);

        /// <summary>Retrieves the total length of the sound in seconds.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="pLength">Receives the total length in seconds.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_length_in_seconds(ma_sound_ptr pSound, out float pLength);

        /// <summary>Sets the callback that is called when the sound reaches the end of playback. Extern version using raw function pointer.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="callback">Raw function pointer to the callback.</param>
        /// <param name="pUserData">User data pointer passed to the callback.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_set_end_callback(ma_sound_ptr pSound, IntPtr callback, IntPtr pUserData);

        /// <summary>Sets the callback that is called when the sound reaches the end of playback. Managed version using a delegate.</summary>
        /// <param name="pSound">Pointer to the sound.</param>
        /// <param name="callback">The delegate to invoke at end of playback.</param>
        /// <param name="pUserData">User data pointer passed to the callback.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        public static ma_result ma_sound_set_end_callback(ma_sound_ptr pSound, ma_sound_end_proc callback, IntPtr pUserData)
        {
            return ma_sound_set_end_callback(pSound, MarshalHelper.GetFunctionPointerForDelegate(callback), pUserData);
        }

        // ma_sound_group
        /// <summary>Initializes a sound group. Sounds can be attached to a group to control their properties collectively.</summary>
        /// <param name="pEngine">The engine to use.</param>
        /// <param name="flags">Flags controlling playback behavior.</param>
        /// <param name="pParentGroup">Optional parent sound group. Pass IntPtr.Zero for no parent.</param>
        /// <param name="pGroup">Pointer to the sound group to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_init(ma_engine_ptr pEngine, ma_sound_flags flags, ma_sound_group_ptr pParentGroup, ma_sound_group_ptr pGroup);

        /// <summary>Initializes a sound group with full configuration for maximum flexibility.</summary>
        /// <param name="pEngine">The engine to use.</param>
        /// <param name="pConfig">The full sound group configuration.</param>
        /// <param name="pGroup">Pointer to the sound group to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_init_ex(ma_engine_ptr pEngine, ref ma_sound_group_config pConfig, ma_sound_group_ptr pGroup);

        /// <summary>Uninitializes and frees resources associated with a sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group to uninitialize.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_uninit(ma_sound_group_ptr pGroup);

        /// <summary>Retrieves the engine that owns this sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>Pointer to the engine that owns the sound group.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_ptr ma_sound_group_get_engine(ma_sound_group_ptr pGroup);

        /// <summary>Starts playback of all sounds in the group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_start(ma_sound_group_ptr pGroup);

        /// <summary>Stops playback of all sounds in the group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_stop(ma_sound_group_ptr pGroup);

        /// <summary>Sets the volume for all sounds in the group. A value of 1.0 is the default volume.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="volume">The volume level, where 0.0 is silence and 1.0 is default.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_volume(ma_sound_group_ptr pGroup, float volume);

        /// <summary>Retrieves the current volume of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current volume level.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_volume(ma_sound_group_ptr pGroup);

        /// <summary>Sets the pan for all sounds in the group. -1.0 is left, 0.0 is center, 1.0 is right.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="pan">The pan value, typically between -1.0 (left) and 1.0 (right).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pan(ma_sound_group_ptr pGroup, float pan);

        /// <summary>Retrieves the current pan of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current pan value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_pan(ma_sound_group_ptr pGroup);

        /// <summary>Sets the pan mode for all sounds in the group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="panMode">The panning mode (e.g. balance or pan).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pan_mode(ma_sound_group_ptr pGroup, ma_pan_mode panMode);

        /// <summary>Retrieves the current pan mode of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current pan mode.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_sound_group_get_pan_mode(ma_sound_group_ptr pGroup);

        /// <summary>Sets the pitch for all sounds in the group. A value of 1.0 is the default pitch.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="pitch">The pitch multiplier, where 1.0 is normal pitch.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pitch(ma_sound_group_ptr pGroup, float pitch);

        /// <summary>Retrieves the current pitch of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current pitch multiplier.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_pitch(ma_sound_group_ptr pGroup);

        /// <summary>Enables or disables spatialization for all sounds in the group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="enabled">Whether spatialization is enabled (non-zero) or disabled (0).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_spatialization_enabled(ma_sound_group_ptr pGroup, ma_bool32 enabled);

        /// <summary>Returns whether spatialization is enabled for the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>Non-zero if spatialization is enabled, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_group_is_spatialization_enabled(ma_sound_group_ptr pGroup);

        /// <summary>Pins all sounds in the group to a specific listener index.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="listenerIndex">The index of the listener to pin to.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pinned_listener_index(ma_sound_group_ptr pGroup, ma_uint32 listenerIndex);

        /// <summary>Returns the pinned listener index for the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The index of the pinned listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_group_get_pinned_listener_index(ma_sound_group_ptr pGroup);

        /// <summary>Returns the listener index currently used by the sound group for spatialization.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The index of the currently active listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_group_get_listener_index(ma_sound_group_ptr pGroup);

        /// <summary>Returns the direction vector from the sound group to the active listener.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>A <see cref="ma_vec3f"/> representing the direction to the listener.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_direction_to_listener(ma_sound_group_ptr pGroup);

        /// <summary>Sets the position of the sound group in 3D space for spatialization.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        /// <param name="z">The Z coordinate of the position.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_position(ma_sound_group_ptr pGroup, float x, float y, float z);

        /// <summary>Retrieves the current position of the sound group in 3D space.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound group's position.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_position(ma_sound_group_ptr pGroup);

        /// <summary>Sets the direction the sound group is facing in 3D space for directional attenuation.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="x">The X component of the direction vector.</param>
        /// <param name="y">The Y component of the direction vector.</param>
        /// <param name="z">The Z component of the direction vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_direction(ma_sound_group_ptr pGroup, float x, float y, float z);

        /// <summary>Retrieves the current direction the sound group is facing.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound group's direction vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_direction(ma_sound_group_ptr pGroup);

        /// <summary>Sets the velocity of the sound group in 3D space for Doppler effect calculation.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="x">The X component of the velocity vector.</param>
        /// <param name="y">The Y component of the velocity vector.</param>
        /// <param name="z">The Z component of the velocity vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_velocity(ma_sound_group_ptr pGroup, float x, float y, float z);

        /// <summary>Retrieves the current velocity of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the sound group's velocity vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_velocity(ma_sound_group_ptr pGroup);

        /// <summary>Sets the attenuation model for the sound group, which controls how volume decreases with distance.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="attenuationModel">The attenuation model to use (e.g. none, inverse, linear, exponential).</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_attenuation_model(ma_sound_group_ptr pGroup, ma_attenuation_model attenuationModel);

        /// <summary>Retrieves the current attenuation model of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current attenuation model.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_sound_group_get_attenuation_model(ma_sound_group_ptr pGroup);

        /// <summary>Sets the positioning mode for the sound group (absolute or relative).</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="positioning">The positioning mode.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_positioning(ma_sound_group_ptr pGroup, ma_positioning positioning);

        /// <summary>Retrieves the current positioning mode of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current positioning mode.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_sound_group_get_positioning(ma_sound_group_ptr pGroup);

        /// <summary>Sets the rolloff factor for the sound group, controlling the rate of attenuation.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="rolloff">The rolloff factor.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_rolloff(ma_sound_group_ptr pGroup, float rolloff);

        /// <summary>Retrieves the current rolloff factor of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current rolloff factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_rolloff(ma_sound_group_ptr pGroup);

        /// <summary>Sets the minimum gain (volume) of the sound group at maximum distance.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="minGain">The minimum gain value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_min_gain(ma_sound_group_ptr pGroup, float minGain);

        /// <summary>Retrieves the current minimum gain of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current minimum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_min_gain(ma_sound_group_ptr pGroup);

        /// <summary>Sets the maximum gain (volume) of the sound group at minimum distance.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="maxGain">The maximum gain value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_max_gain(ma_sound_group_ptr pGroup, float maxGain);

        /// <summary>Retrieves the current maximum gain of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current maximum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_max_gain(ma_sound_group_ptr pGroup);

        /// <summary>Sets the minimum distance for the sound group's attenuation. At this distance sounds are at max gain.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="minDistance">The minimum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_min_distance(ma_sound_group_ptr pGroup, float minDistance);

        /// <summary>Retrieves the current minimum distance of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current minimum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_min_distance(ma_sound_group_ptr pGroup);

        /// <summary>Sets the maximum distance for the sound group's attenuation. At this distance sounds are at min gain.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="maxDistance">The maximum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_max_distance(ma_sound_group_ptr pGroup, float maxDistance);

        /// <summary>Retrieves the current maximum distance of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current maximum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_max_distance(ma_sound_group_ptr pGroup);

        /// <summary>Sets the cone parameters for the sound group. The cone has an inner angle at full gain and an outer angle at outer gain.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="innerAngleInRadians">The inner cone angle in radians, inside which sounds are at full volume.</param>
        /// <param name="outerAngleInRadians">The outer cone angle in radians, beyond which sounds are at outer gain.</param>
        /// <param name="outerGain">The gain applied outside the outer cone angle.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_cone(ma_sound_group_ptr pGroup, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        /// <summary>Retrieves the current cone parameters of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="pInnerAngleInRadians">Receives the inner cone angle in radians.</param>
        /// <param name="pOuterAngleInRadians">Receives the outer cone angle in radians.</param>
        /// <param name="pOuterGain">Receives the outer cone gain.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_get_cone(ma_sound_group_ptr pGroup, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        /// <summary>Sets the Doppler factor for the sound group. Set to 0 to disable the Doppler effect.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="dopplerFactor">The Doppler factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_doppler_factor(ma_sound_group_ptr pGroup, float dopplerFactor);

        /// <summary>Retrieves the current Doppler factor of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current Doppler factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_doppler_factor(ma_sound_group_ptr pGroup);

        /// <summary>Sets the directional attenuation factor for the sound group. Set to 0 to disable directional attenuation.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="directionalAttenuationFactor">The directional attenuation factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_directional_attenuation_factor(ma_sound_group_ptr pGroup, float directionalAttenuationFactor);

        /// <summary>Retrieves the current directional attenuation factor of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current directional attenuation factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_directional_attenuation_factor(ma_sound_group_ptr pGroup);

        /// <summary>Schedules a volume fade-in for the sound group over the specified number of PCM frames, starting immediately.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInFrames">The duration of the fade in PCM frames.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_fade_in_pcm_frames(ma_sound_group_ptr pGroup, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames);

        /// <summary>Schedules a volume fade-in for the sound group over the specified duration in milliseconds, starting immediately.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="volumeBeg">The starting volume of the fade.</param>
        /// <param name="volumeEnd">The ending volume of the fade.</param>
        /// <param name="fadeLengthInMilliseconds">The duration of the fade in milliseconds.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_fade_in_milliseconds(ma_sound_group_ptr pGroup, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds);

        /// <summary>Retrieves the current fade volume of the sound group.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The current fade volume applied to the sound group.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_current_fade_volume(ma_sound_group_ptr pGroup);

        /// <summary>Schedules the sound group to start playing at the specified absolute global time in PCM frames.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="absoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to start.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_start_time_in_pcm_frames(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInFrames);

        /// <summary>Schedules the sound group to start playing at the specified absolute global time in milliseconds.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="absoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to start.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_start_time_in_milliseconds(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInMilliseconds);

        /// <summary>Schedules the sound group to stop playing at the specified absolute global time in PCM frames.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="absoluteGlobalTimeInFrames">The absolute global time in PCM frames at which to stop.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_stop_time_in_pcm_frames(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInFrames);

        /// <summary>Schedules the sound group to stop playing at the specified absolute global time in milliseconds.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <param name="absoluteGlobalTimeInMilliseconds">The absolute global time in milliseconds at which to stop.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_stop_time_in_milliseconds(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInMilliseconds);

        /// <summary>Returns whether the sound group is currently playing.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>Non-zero if playing, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_group_is_playing(ma_sound_group_ptr pGroup);

        /// <summary>Returns the current playback position of the sound group in PCM frames.</summary>
        /// <param name="pGroup">Pointer to the sound group.</param>
        /// <returns>The time in PCM frames since the sound group started playing.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_group_get_time_in_pcm_frames(ma_sound_group_ptr pGroup);

        // ma_procedural_data_source
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_procedural_data_source_config ma_procedural_data_source_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, IntPtr pProceduralSoundProc, IntPtr pUserData);

        /// <summary>Initializes a procedural data source configuration for generating audio programmatically.</summary>
        /// <param name="format">The sample format (e.g. f32, s16).</param>
        /// <param name="channels">The number of audio channels.</param>
        /// <param name="sampleRate">The sample rate in Hz.</param>
        /// <param name="pProceduralSoundProc">The delegate to call for generating audio data.</param>
        /// <param name="pUserData">User data pointer passed to the callback.</param>
        /// <returns>A configured <see cref="ma_procedural_data_source_config"/>.</returns>
        public static ma_procedural_data_source_config ma_procedural_data_source_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, ma_procedural_data_source_proc pProceduralSoundProc, IntPtr pUserData)
        {
            return ma_procedural_data_source_config_init(format, channels, sampleRate, MarshalHelper.GetFunctionPointerForDelegate(pProceduralSoundProc), pUserData);
        }
        
        /// <summary>Initializes a procedural data source for programmatic audio generation.</summary>
        /// <param name="pConfig">The configuration specifying format, channels, sample rate and callback.</param>
        /// <param name="pProceduralSound">Pointer to the procedural data source to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_procedural_data_source_init(ref ma_procedural_data_source_config pConfig, ma_procedural_data_source_ptr pProceduralSound);

        /// <summary>Uninitializes and frees resources associated with a procedural data source.</summary>
        /// <param name="pProceduralSound">Pointer to the procedural data source to uninitialize.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_procedural_data_source_uninit(ma_procedural_data_source_ptr pProceduralSound);

        // ma_spatializer_listener
        /// <summary>Initializes a spatializer listener configuration with a given number of output channels.</summary>
        /// <param name="channelsOut">The number of output channels for the listener.</param>
        /// <returns>A configured <see cref="ma_spatializer_listener_config"/>.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_spatializer_listener_config ma_spatializer_listener_config_init(ma_uint32 channelsOut);

        /// <summary>Calculates the heap size required for a spatializer listener.</summary>
        /// <param name="pConfig">The listener configuration.</param>
        /// <param name="pHeapSizeInBytes">Receives the required heap size in bytes.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_get_heap_size(ref ma_spatializer_listener_config pConfig, out size_t pHeapSizeInBytes);

        /// <summary>Initializes a spatializer listener using a pre-allocated heap buffer.</summary>
        /// <param name="pConfig">The listener configuration.</param>
        /// <param name="pHeap">Pointer to the pre-allocated heap buffer.</param>
        /// <param name="pListener">Pointer to the listener to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_init_preallocated(ref ma_spatializer_listener_config pConfig, IntPtr pHeap, ma_spatializer_listener_ptr pListener);

        /// <summary>Initializes a spatializer listener with custom allocation callbacks.</summary>
        /// <param name="pConfig">The listener configuration.</param>
        /// <param name="pAllocationCallbacks">Optional allocation callbacks. Pass IntPtr.Zero for defaults.</param>
        /// <param name="pListener">Pointer to the listener to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_init(ref ma_spatializer_listener_config pConfig, IntPtr pAllocationCallbacks, ma_spatializer_listener_ptr pListener);

        /// <summary>Uninitializes and frees resources associated with a spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener to uninitialize.</param>
        /// <param name="pAllocationCallbacks">Optional allocation callbacks. Pass IntPtr.Zero for defaults.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_uninit(ma_spatializer_listener_ptr pListener, IntPtr pAllocationCallbacks);

        /// <summary>Retrieves the channel map of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>Pointer to the channel map.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_channel_ptr ma_spatializer_listener_get_channel_map(ma_spatializer_listener_ptr pListener);

        /// <summary>Sets the cone parameters for the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="innerAngleInRadians">The inner cone angle in radians, inside which the listener hears at full volume.</param>
        /// <param name="outerAngleInRadians">The outer cone angle in radians, beyond which the listener hears at outer gain.</param>
        /// <param name="outerGain">The gain applied outside the outer cone angle.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_cone(ma_spatializer_listener_ptr pListener, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        /// <summary>Retrieves the current cone parameters of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="pInnerAngleInRadians">Receives the inner cone angle in radians.</param>
        /// <param name="pOuterAngleInRadians">Receives the outer cone angle in radians.</param>
        /// <param name="pOuterGain">Receives the outer cone gain.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_get_cone(ma_spatializer_listener_ptr pListener, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        /// <summary>Sets the position of the spatializer listener in 3D space.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        /// <param name="z">The Z coordinate of the position.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_position(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        /// <summary>Retrieves the current position of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the listener's position.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_position(ma_spatializer_listener_ptr pListener);

        /// <summary>Sets the direction the spatializer listener is facing in 3D space.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="x">The X component of the direction vector.</param>
        /// <param name="y">The Y component of the direction vector.</param>
        /// <param name="z">The Z component of the direction vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_direction(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        /// <summary>Retrieves the current direction the spatializer listener is facing.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the listener's direction vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_direction(ma_spatializer_listener_ptr pListener);

        /// <summary>Sets the velocity of the spatializer listener for Doppler effect calculation.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="x">The X component of the velocity vector.</param>
        /// <param name="y">The Y component of the velocity vector.</param>
        /// <param name="z">The Z component of the velocity vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_velocity(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        /// <summary>Retrieves the current velocity of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the listener's velocity vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_velocity(ma_spatializer_listener_ptr pListener);

        /// <summary>Sets the speed of sound for the spatializer listener, used in Doppler effect calculation.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="speedOfSound">The speed of sound value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_speed_of_sound(ma_spatializer_listener_ptr pListener, float speedOfSound);

        /// <summary>Retrieves the current speed of sound of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>The current speed of sound value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_listener_get_speed_of_sound(ma_spatializer_listener_ptr pListener);

        /// <summary>Sets the world up vector for the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="x">The X component of the world up vector.</param>
        /// <param name="y">The Y component of the world up vector.</param>
        /// <param name="z">The Z component of the world up vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_world_up(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        /// <summary>Retrieves the current world up vector of the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the world up vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_world_up(ma_spatializer_listener_ptr pListener);

        /// <summary>Enables or disables the spatializer listener.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <param name="isEnabled">Non-zero to enable, zero to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_enabled(ma_spatializer_listener_ptr pListener, ma_bool32 isEnabled);

        /// <summary>Returns whether the spatializer listener is enabled.</summary>
        /// <param name="pListener">Pointer to the listener.</param>
        /// <returns>Non-zero if enabled, zero otherwise.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_spatializer_listener_is_enabled(ma_spatializer_listener_ptr pListener);

        // ma_spatializer
        /// <summary>Initializes a spatializer configuration with the given input and output channel counts.</summary>
        /// <param name="channelsIn">The number of input channels.</param>
        /// <param name="channelsOut">The number of output channels.</param>
        /// <returns>A configured <see cref="ma_spatializer_config"/>.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_spatializer_config ma_spatializer_config_init(ma_uint32 channelsIn, ma_uint32 channelsOut);

        /// <summary>Calculates the heap size required for a spatializer.</summary>
        /// <param name="pConfig">The spatializer configuration.</param>
        /// <param name="pHeapSizeInBytes">Receives the required heap size in bytes.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_get_heap_size(ref ma_spatializer_config pConfig, out size_t pHeapSizeInBytes);

        /// <summary>Initializes a spatializer using a pre-allocated heap buffer.</summary>
        /// <param name="pConfig">The spatializer configuration.</param>
        /// <param name="pHeap">Pointer to the pre-allocated heap buffer.</param>
        /// <param name="pSpatializer">Pointer to the spatializer to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_init_preallocated(ref ma_spatializer_config pConfig, IntPtr pHeap, ma_spatializer_ptr pSpatializer);

        /// <summary>Initializes a spatializer with custom allocation callbacks.</summary>
        /// <param name="pConfig">The spatializer configuration.</param>
        /// <param name="pAllocationCallbacks">Optional allocation callbacks. Pass IntPtr.Zero for defaults.</param>
        /// <param name="pSpatializer">Pointer to the spatializer to initialize.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_init(ref ma_spatializer_config pConfig, IntPtr pAllocationCallbacks, ma_spatializer_ptr pSpatializer);

        /// <summary>Uninitializes and frees resources associated with a spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer to uninitialize.</param>
        /// <param name="pAllocationCallbacks">Optional allocation callbacks. Pass IntPtr.Zero for defaults.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_uninit(ma_spatializer_ptr pSpatializer, IntPtr pAllocationCallbacks);

        /// <summary>Processes PCM frames through the spatializer, applying 3D spatial effects based on the listener position.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="pListener">Pointer to the spatializer listener providing position/direction context.</param>
        /// <param name="pFramesOut">Pointer to the output buffer for processed frames.</param>
        /// <param name="pFramesIn">Pointer to the input buffer of source frames.</param>
        /// <param name="frameCount">The number of PCM frames to process.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_process_pcm_frames(ma_spatializer_ptr pSpatializer, ma_spatializer_listener_ptr pListener, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        /// <summary>Sets the master volume of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="volume">The volume level.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_set_master_volume(ma_spatializer_ptr pSpatializer, float volume);

        /// <summary>Retrieves the master volume of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="pVolume">Receives the current master volume.</param>
        /// <returns><see cref="ma_result.success"/> on success, otherwise an error code.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_get_master_volume(ma_spatializer_ptr pSpatializer, out float pVolume);

        /// <summary>Retrieves the number of input channels of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The number of input channels.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_spatializer_get_input_channels(ma_spatializer_ptr pSpatializer);

        /// <summary>Retrieves the number of output channels of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The number of output channels.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_spatializer_get_output_channels(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the attenuation model for the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="attenuationModel">The attenuation model to use.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_attenuation_model(ma_spatializer_ptr pSpatializer, ma_attenuation_model attenuationModel);

        /// <summary>Retrieves the current attenuation model of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current attenuation model.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_spatializer_get_attenuation_model(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the positioning mode for the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="positioning">The positioning mode.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_positioning(ma_spatializer_ptr pSpatializer, ma_positioning positioning);

        /// <summary>Retrieves the current positioning mode of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current positioning mode.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_spatializer_get_positioning(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the rolloff factor for the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="rolloff">The rolloff factor.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_rolloff(ma_spatializer_ptr pSpatializer, float rolloff);

        /// <summary>Retrieves the current rolloff factor of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current rolloff factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_rolloff(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the minimum gain of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="minGain">The minimum gain value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_min_gain(ma_spatializer_ptr pSpatializer, float minGain);

        /// <summary>Retrieves the current minimum gain of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current minimum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_min_gain(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the maximum gain of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="maxGain">The maximum gain value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_max_gain(ma_spatializer_ptr pSpatializer, float maxGain);

        /// <summary>Retrieves the current maximum gain of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current maximum gain value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_max_gain(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the minimum distance of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="minDistance">The minimum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_min_distance(ma_spatializer_ptr pSpatializer, float minDistance);

        /// <summary>Retrieves the current minimum distance of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current minimum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_min_distance(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the maximum distance of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="maxDistance">The maximum distance value.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_max_distance(ma_spatializer_ptr pSpatializer, float maxDistance);

        /// <summary>Retrieves the current maximum distance of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current maximum distance value.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_max_distance(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the cone parameters for the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="innerAngleInRadians">The inner cone angle in radians.</param>
        /// <param name="outerAngleInRadians">The outer cone angle in radians.</param>
        /// <param name="outerGain">The gain applied outside the outer cone angle.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_cone(ma_spatializer_ptr pSpatializer, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        /// <summary>Retrieves the current cone parameters of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="pInnerAngleInRadians">Receives the inner cone angle in radians.</param>
        /// <param name="pOuterAngleInRadians">Receives the outer cone angle in radians.</param>
        /// <param name="pOuterGain">Receives the outer cone gain.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_get_cone(ma_spatializer_ptr pSpatializer, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        /// <summary>Sets the Doppler factor for the spatializer. Set to 0 to disable the Doppler effect.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="dopplerFactor">The Doppler factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_doppler_factor(ma_spatializer_ptr pSpatializer, float dopplerFactor);

        /// <summary>Retrieves the current Doppler factor of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current Doppler factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_doppler_factor(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the directional attenuation factor for the spatializer. Set to 0 to disable directional attenuation.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="directionalAttenuationFactor">The directional attenuation factor. Set to 0 to disable.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_directional_attenuation_factor(ma_spatializer_ptr pSpatializer, float directionalAttenuationFactor);

        /// <summary>Retrieves the current directional attenuation factor of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>The current directional attenuation factor.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_directional_attenuation_factor(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the position of the spatializer in 3D space.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        /// <param name="z">The Z coordinate of the position.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_position(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        /// <summary>Retrieves the current position of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the spatializer's position.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_position(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the direction the spatializer is facing in 3D space.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="x">The X component of the direction vector.</param>
        /// <param name="y">The Y component of the direction vector.</param>
        /// <param name="z">The Z component of the direction vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_direction(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        /// <summary>Retrieves the current direction of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the spatializer's direction vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_direction(ma_spatializer_ptr pSpatializer);

        /// <summary>Sets the velocity of the spatializer for Doppler effect calculation.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="x">The X component of the velocity vector.</param>
        /// <param name="y">The Y component of the velocity vector.</param>
        /// <param name="z">The Z component of the velocity vector.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_velocity(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        /// <summary>Retrieves the current velocity of the spatializer.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <returns>A <see cref="ma_vec3f"/> containing the spatializer's velocity vector.</returns>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_velocity(ma_spatializer_ptr pSpatializer);

        /// <summary>Calculates the relative position and direction of the spatializer from a listener's perspective.</summary>
        /// <param name="pSpatializer">Pointer to the spatializer.</param>
        /// <param name="pListener">Pointer to the spatializer listener.</param>
        /// <param name="pRelativePos">Receives the position of the spatializer relative to the listener.</param>
        /// <param name="pRelativeDir">Receives the direction of the spatializer relative to the listener.</param>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_get_relative_position_and_direction(ma_spatializer_ptr pSpatializer, ma_spatializer_listener_ptr pListener, out ma_vec3f pRelativePos, out ma_vec3f pRelativeDir);

        // ma_decoder
        /// <summary>
        /// Initializes a decoder config with the specified output format, channels, and sample rate.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_decoder_config ma_decoder_config_init(ma_format outputFormat, ma_uint32 outputChannels, ma_uint32 outputSampleRate);

        /// <summary>
        /// Initializes a decoder config with default settings.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_decoder_config ma_decoder_config_init_default();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_decoder_init(IntPtr onRead, IntPtr onSeek, IntPtr pUserData, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Initializes a decoder from custom read and seek callbacks.
        /// </summary>
        public static ma_result ma_decoder_init(ma_decoder_read_proc onRead, ma_decoder_seek_proc onSeek, IntPtr pUserData, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder)
        {
            return ma_decoder_init(MarshalHelper.GetFunctionPointerForDelegate(onRead), MarshalHelper.GetFunctionPointerForDelegate(onSeek), pUserData, ref pConfig, pDecoder);
        }

        /// <summary>
        /// Initializes a decoder from a block of memory containing encoded audio data.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_memory(IntPtr pData, size_t dataSize, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Initializes a decoder from memory using default config settings.
        /// </summary>
        public static ma_result ma_decoder_init_memory(IntPtr pData, size_t dataSize, ma_decoder_ptr pDecoder)
        {
            ma_decoder_config config = ma_decoder_config_init_default();
            return ma_decoder_init_memory(pData, dataSize, ref config, pDecoder);
        }

        /// <summary>
        /// Initializes a decoder from a file using a custom virtual file system.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_vfs(ma_vfs_ptr pVFS, string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Initializes a decoder from a file using a custom virtual file system (wide string path).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_vfs_w(ma_vfs_ptr pVFS, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Initializes a decoder from a file path with the specified config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_file(string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Initializes a decoder from a file path using default config settings.
        /// </summary>
        public static ma_result ma_decoder_init_file(string pFilePath, ma_decoder_ptr pDecoder)
        {
            ma_decoder_config config = ma_decoder_config_init_default();
            return ma_decoder_init_file(pFilePath, ref config, pDecoder);
        }

        /// <summary>
        /// Initializes a decoder from a file path with the specified config (wide string path).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_file_w([MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        /// <summary>
        /// Uninitializes a decoder and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_uninit(ma_decoder_ptr pDecoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_decoder_read_pcm_frames(ma_decoder_ptr pDecoder, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint64* pFramesRead);

        /// <summary>
        /// Reads raw PCM frames from the decoder. Returns the number of frames actually read via pFramesRead.
        /// </summary>
        public static ma_result ma_decoder_read_pcm_frames(ma_decoder_ptr pDecoder, IntPtr pFramesOut, ma_uint64 frameCount, IntPtr pFramesRead)
        {
            unsafe
            {
                if (pFramesRead == IntPtr.Zero)
                {
                    return ma_decoder_read_pcm_frames(pDecoder, pFramesOut, frameCount, null);
                }
                else
                {
                    ma_uint64* pointer = (ma_uint64*)pFramesOut.ToPointer();
                    return ma_decoder_read_pcm_frames(pDecoder, pFramesOut, frameCount, pointer);
                }
            }
        }

        /// <summary>
        /// Seeks the decoder to a specific PCM frame index.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_seek_to_pcm_frame(ma_decoder_ptr pDecoder, ma_uint64 frameIndex);

        /// <summary>
        /// Retrieves the data format of the decoder (format, channels, sample rate, and channel map).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_data_format(ma_decoder_ptr pDecoder, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

        /// <summary>
        /// Gets the current read cursor position in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_cursor_in_pcm_frames(ma_decoder_ptr pDecoder, out ma_uint64 pCursor);

        /// <summary>
        /// Gets the total length of the decoded audio in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_length_in_pcm_frames(ma_decoder_ptr pDecoder, out ma_uint64 pLength);

        /// <summary>
        /// Gets the number of available PCM frames that can be read without blocking.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_available_frames(ma_decoder_ptr pDecoder, out ma_uint64 pAvailableFrames);

        /// <summary>
        /// Decodes an entire file from a virtual file system into a single buffer of PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_from_vfs(ma_vfs_ptr pVFS, string pFilePath, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        /// <summary>
        /// Decodes an entire file into a single buffer of PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_file(string pFilePath, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        /// <summary>
        /// Decodes an entire block of memory containing encoded audio data into a single buffer of PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_memory(IntPtr pData, size_t dataSize, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        // ma_resource_manager
        /// <summary>
        /// Initializes a resource manager config with default settings.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_resource_manager_config ma_resource_manager_config_init();

        /// <summary>
        /// Initializes a resource manager which manages decoding and loading of audio resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_resource_manager_init(ref ma_resource_manager_config pConfig, ma_resource_manager_ptr pResourceManager);

        /// <summary>
        /// Uninitializes a resource manager and releases all associated resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_resource_manager_uninit(ma_resource_manager_ptr pResourceManager);

        /// <summary>
        /// Gets the log object associated with the resource manager.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_resource_manager_get_log(ma_resource_manager_ptr pResourceManager);

        // ma_gainer
        /// <summary>
        /// Initializes a gainer config with the specified channel count and smooth time in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_gainer_config ma_gainer_config_init(ma_uint32 channels, ma_uint32 smoothTimeInFrames);

        /// <summary>
        /// Calculates the heap size required for a gainer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_get_heap_size(ref ma_gainer_config pConfig, out size_t pHeapSizeInBytes);

        /// <summary>
        /// Initializes a gainer with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_init_preallocated(ref ma_gainer_config pConfig, IntPtr pHeap, ma_gainer_ptr pGainer);

        /// <summary>
        /// Initializes a gainer which applies smooth gain adjustments to audio data.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_init(ref ma_gainer_config pConfig, IntPtr pAllocationCallbacks, ma_gainer_ptr pGainer);

        /// <summary>
        /// Uninitializes a gainer and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_gainer_uninit(ma_gainer_ptr pGainer, IntPtr pAllocationCallbacks);

        /// <summary>
        /// Processes PCM frames through the gainer, applying the configured gains.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_process_pcm_frames(ma_gainer_ptr pGainer, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        /// <summary>
        /// Sets the gain for all channels at once.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_gain(ma_gainer_ptr pGainer, float newGain);

        /// <summary>
        /// Sets individual gains for each channel.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_gains(ma_gainer_ptr pGainer, out float pNewGains);

        /// <summary>
        /// Sets the master volume of the gainer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_master_volume(ma_gainer_ptr pGainer, float volume);

        /// <summary>
        /// Gets the current master volume of the gainer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_get_master_volume(ma_gainer_ptr pGainer, out float pVolume);

        // ma_libvorbis
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern ma_decoding_backend_vtable* ma_libvorbis_get_decoding_backend();

        /// <summary>
        /// Retrieves a pointer to the libvorbis decoding backend vtable, which can be used with custom decoding backends.
        /// </summary>
        public static ma_decoding_backend_vtable_ptr ma_libvorbis_get_decoding_backend_ptr()
        {
            unsafe
            {
                return new ma_decoding_backend_vtable_ptr(new IntPtr(ma_libvorbis_get_decoding_backend()));
            }
        }

        // ma_log
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_log_callback ma_log_callback_init(IntPtr onLog, IntPtr pUserData);

        /// <summary>
        /// Initializes a log callback with the specified callback function and user data.
        /// </summary>
        public static ma_log_callback ma_log_callback_init(ma_log_callback_proc onLog, IntPtr pUserData)
        {
            return ma_log_callback_init(MarshalHelper.GetFunctionPointerForDelegate(onLog), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_log_init(ma_allocation_callbacks* pAllocationCallbacks, ma_log_ptr pLog);

        /// <summary>
        /// Initializes a log object with default allocation callbacks.
        /// </summary>
        public static ma_result ma_log_init(ma_log_ptr pLog)
        {
            unsafe
            {
                return ma_log_init(null, pLog);
            }
        }

        /// <summary>
        /// Initializes a log object with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_log_init(ref ma_allocation_callbacks pAllocationCallbacks, ma_log_ptr pLog)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_log_init(pCallbacks, pLog);
                }
            }
        }

        /// <summary>
        /// Uninitializes a log object and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_log_uninit(ma_log_ptr pLog);

        /// <summary>
        /// Registers a callback function to receive log messages.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_register_callback(ma_log_ptr pLog, ma_log_callback callback);

        /// <summary>
        /// Unregisters a previously registered log callback.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_unregister_callback(ma_log_ptr pLog, ma_log_callback callback);

        /// <summary>
        /// Posts a message to the log at the specified log level.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_post(ma_log_ptr pLog, ma_uint32 level, string pMessage);

        /// <summary>
        /// Converts a log level integer value to its string representation.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern string ma_log_level_to_string(ma_uint32 logLevel);

        // ma_node_graph
        /// <summary>
        /// Initializes a node graph config with the specified number of channels.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_config ma_node_graph_config_init(ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_node_graph_init(ref ma_node_graph_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_node_graph_ptr pNodeGraph);

        /// <summary>
        /// Initializes a node graph with custom allocation callbacks. The node graph manages the processing graph of connected audio nodes.
        /// </summary>
        public static ma_result ma_node_graph_init(ref ma_node_graph_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_node_graph_ptr pNodeGraph)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_node_graph_init(ref pConfig, pCallbacks, pNodeGraph);
                }
            }
        }

        /// <summary>
        /// Initializes a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_node_graph_init(ref ma_node_graph_config pConfig, ma_node_graph_ptr pNodeGraph)
        {
            unsafe
            {
                return ma_node_graph_init(ref pConfig, null, pNodeGraph);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_node_graph_uninit(ma_node_graph_ptr pNodeGraph, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a node graph with custom allocation callbacks.
        /// </summary>
        public static void ma_node_graph_uninit(ma_node_graph_ptr pNodeGraph, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_node_graph_uninit(pNodeGraph, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a node graph with default allocation callbacks.
        /// </summary>
        public static void ma_node_graph_uninit(ma_node_graph_ptr pNodeGraph)
        {
            unsafe
            {
                ma_node_graph_uninit(pNodeGraph, null);
            }
        }

        /// <summary>
        /// Gets the endpoint node of the node graph, which is the final output node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_ptr ma_node_graph_get_endpoint(ma_node_graph_ptr pNodeGraph);

        /// <summary>
        /// Reads PCM frames from the node graph, processing all connected nodes.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_graph_read_pcm_frames(ma_node_graph_ptr pNodeGraph, IntPtr pFramesOut, ma_uint64 frameCount, IntPtr pFramesRead);

        /// <summary>
        /// Gets the number of channels in the node graph.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_graph_get_channels(ma_node_graph_ptr pNodeGraph);

        /// <summary>
        /// Gets the current global time of the node graph in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_graph_get_time(ma_node_graph_ptr pNodeGraph);

        /// <summary>
        /// Sets the current global time of the node graph in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_graph_set_time(ma_node_graph_ptr pNodeGraph, ma_uint64 globalTime);

        /// <summary>
        /// Gets the processing size of the node graph in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_node_graph_get_processing_size_in_frames(ma_node_graph_ptr pNodeGraph);

        // ma_node
        /// <summary>
        /// Initializes a node config with default settings.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_config ma_node_config_init();

        /// <summary>
        /// Gets the required heap size for a node with the given config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_get_heap_size(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, out size_t pHeapSizeInBytes);

        /// <summary>
        /// Initializes a node with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_init_preallocated(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, IntPtr pHeap, ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_node_init(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_node_ptr pNode);

        /// <summary>
        /// Initializes a node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_node_init(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_node_init(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, ma_node_ptr pNode)
        {
            unsafe
            {
                return ma_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_node_uninit(ma_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a node with custom allocation callbacks.
        /// </summary>
        public static void ma_node_uninit(ma_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a node with default allocation callbacks.
        /// </summary>
        public static void ma_node_uninit(ma_node_ptr pNode)
        {
            unsafe
            {
                ma_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Gets the node graph that this node belongs to.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_ptr ma_node_get_node_graph(ma_node_ptr pNode);

        /// <summary>
        /// Gets the number of input buses on this node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_input_bus_count(ma_node_ptr pNode);

        /// <summary>
        /// Gets the number of output buses on this node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_output_bus_count(ma_node_ptr pNode);

        /// <summary>
        /// Gets the number of input channels for a specific input bus.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_input_channels(ma_node_ptr pNode, ma_uint32 inputBusIndex);

        /// <summary>
        /// Gets the number of output channels for a specific output bus.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_output_channels(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        /// <summary>
        /// Attaches an output bus of this node to an input bus of another node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_attach_output_bus(ma_node_ptr pNode, ma_uint32 outputBusIndex, ma_node_ptr pOtherNode, ma_uint32 otherNodeInputBusIndex);

        /// <summary>
        /// Detaches an output bus from whatever it is connected to.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_detach_output_bus(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        /// <summary>
        /// Detaches all output buses on this node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_detach_all_output_buses(ma_node_ptr pNode);

        /// <summary>
        /// Sets the volume of a specific output bus.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_output_bus_volume(ma_node_ptr pNode, ma_uint32 outputBusIndex, float volume);

        /// <summary>
        /// Gets the volume of a specific output bus.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_node_get_output_bus_volume(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        /// <summary>
        /// Sets the state of this node (started, stopped, etc.).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_state(ma_node_ptr pNode, ma_node_state state);

        /// <summary>
        /// Gets the current state of this node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state(ma_node_ptr pNode);

        /// <summary>
        /// Sets the state of this node to change at a specific global time.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_state_time(ma_node_ptr pNode, ma_node_state state, ma_uint64 globalTime);

        /// <summary>
        /// Gets the time at which the node last entered the given state.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_get_state_time(ma_node_ptr pNode, ma_node_state state);

        /// <summary>
        /// Gets the state of the node at a specific global time.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state_by_time(ma_node_ptr pNode, ma_uint64 globalTime);

        /// <summary>
        /// Gets the state of the node within a time range. Returns the most significant state.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state_by_time_range(ma_node_ptr pNode, ma_uint64 globalTimeBeg, ma_uint64 globalTimeEnd);

        /// <summary>
        /// Gets the local time of the node in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_get_time(ma_node_ptr pNode);

        /// <summary>
        /// Sets the local time of the node in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_time(ma_node_ptr pNode, ma_uint64 localTime);

        // ma_effect_node
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_effect_node_config ma_effect_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, IntPtr onProcess, IntPtr pUserData);

        /// <summary>
        /// Initializes an effect node config with the specified channels, sample rate, and custom processing callback.
        /// </summary>
        public static ma_effect_node_config ma_effect_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_effect_node_process_proc onProcess, IntPtr pUserData)
        {
            return ma_effect_node_config_init(channels, sampleRate, MarshalHelper.GetFunctionPointerForDelegate(onProcess), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_effect_node_init(ma_node_graph_ptr pNodeGraph, ref ma_effect_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_effect_node_ptr pEffectNode);

        /// <summary>
        /// Initializes an effect node within a node graph. The effect node uses a custom callback for audio processing.
        /// </summary>
        public static ma_result ma_effect_node_init(ma_node_graph_ptr pNodeGraph, ref ma_effect_node_config pConfig, ma_effect_node_ptr pEffectNode)
        {
            unsafe
            {
                return ma_effect_node_init(pNodeGraph, ref pConfig, null, pEffectNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_effect_node_uninit(ma_effect_node_ptr pEffectNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes an effect node and releases its resources.
        /// </summary>
        public static void ma_effect_node_uninit(ma_effect_node_ptr pEffectNode)
        {
            unsafe
            {
                ma_effect_node_uninit(pEffectNode, null);
            }
        }

        // ma_data_source
        /// <summary>
        /// Initializes a data source config with default settings.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_config ma_data_source_config_init();

        /// <summary>
        /// Initializes a data source. A data source is the base abstraction for any object that produces audio data.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_init(ref ma_data_source_config pConfig, ma_data_source_ptr pDataSource);

        /// <summary>
        /// Uninitializes a data source and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_uninit(ma_data_source_ptr pDataSource);

        /// <summary>
        /// Reads PCM frames from the data source.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_read_pcm_frames(ma_data_source_ptr pDataSource, IntPtr pFramesOut, ma_uint64 frameCount, IntPtr pFramesRead);

        /// <summary>
        /// Seeks forward by a number of PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 frameCount, out ma_uint64 pFramesSeeked);

        /// <summary>
        /// Seeks to a specific PCM frame index.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_to_pcm_frame(ma_data_source_ptr pDataSource, ma_uint64 frameIndex);

        /// <summary>
        /// Seeks forward by a number of seconds.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_seconds(ma_data_source_ptr pDataSource, float secondCount, out float pSecondsSeeked);

        /// <summary>
        /// Seeks to a specific point in seconds.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_to_second(ma_data_source_ptr pDataSource, float seekPointInSeconds);

        /// <summary>
        /// Retrieves the data format of the data source.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_data_format(ma_data_source_ptr pDataSource, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

        /// <summary>
        /// Gets the current cursor position in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_cursor_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pCursor);

        /// <summary>
        /// Gets the total length of the data source in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_length_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pLength);

        /// <summary>
        /// Gets the current cursor position in seconds.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_cursor_in_seconds(ma_data_source_ptr pDataSource, out float pCursor);

        /// <summary>
        /// Gets the total length of the data source in seconds.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_length_in_seconds(ma_data_source_ptr pDataSource, out float pLength);

        /// <summary>
        /// Sets whether the data source should loop when it reaches the end.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_looping(ma_data_source_ptr pDataSource, ma_bool32 isLooping);

        /// <summary>
        /// Returns whether the data source is currently set to loop.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_data_source_is_looping(ma_data_source_ptr pDataSource);

        /// <summary>
        /// Sets the playback range in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_range_in_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 rangeBegInFrames, ma_uint64 rangeEndInFrames);

        /// <summary>
        /// Gets the current playback range in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_get_range_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pRangeBegInFrames, out ma_uint64 pRangeEndInFrames);

        /// <summary>
        /// Sets the loop point boundaries in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_loop_point_in_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 loopBegInFrames, ma_uint64 loopEndInFrames);

        /// <summary>
        /// Gets the current loop point boundaries in PCM frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_get_loop_point_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pLoopBegInFrames, out ma_uint64 pLoopEndInFrames);

        /// <summary>
        /// Sets the current child data source for chained playback.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_current(ma_data_source_ptr pDataSource, ma_data_source_ptr pCurrentDataSource);

        /// <summary>
        /// Gets the current child data source.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_data_source_get_current(ma_data_source_ptr pDataSource);

        /// <summary>
        /// Sets the next data source to play after the current one finishes.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_next(ma_data_source_ptr pDataSource, ma_data_source_ptr pNextDataSource);

        /// <summary>
        /// Gets the next data source in the chain.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_data_source_get_next(ma_data_source_ptr pDataSource);

        /// <summary>
        /// Sets a callback to dynamically determine the next data source.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_next_callback(ma_data_source_ptr pDataSource, ma_data_source_get_next_proc onGetNext);

        /// <summary>
        /// Gets the currently set next callback.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_get_next_proc ma_data_source_get_next_callback(ma_data_source_ptr pDataSource);

        /// <summary>
        /// Initializes a data source node config with the specified data source.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_node_config ma_data_source_node_config_init(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_data_source_node_init(ma_node_graph_ptr pNodeGraph, ref ma_data_source_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_data_source_node_ptr pDataSourceNode);

        /// <summary>
        /// Initializes a data source node with custom allocation callbacks. Wraps a data source as a node in the audio graph.
        /// </summary>
        public static ma_result ma_data_source_node_init(ma_node_graph_ptr pNodeGraph, ref ma_data_source_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_data_source_node_ptr pDataSourceNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_data_source_node_init(pNodeGraph, ref pConfig, pCallbacks, pDataSourceNode);
                }
            }
        }

        /// <summary>
        /// Initializes a data source node with default allocation callbacks.
        /// </summary>
        public static ma_result ma_data_source_node_init(ma_node_graph_ptr pNodeGraph, ref ma_data_source_node_config pConfig, ma_data_source_node_ptr pDataSourceNode)
        {
            unsafe
            {
                return ma_data_source_node_init(pNodeGraph, ref pConfig, null, pDataSourceNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_data_source_node_uninit(ma_data_source_node_ptr pDataSourceNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a data source node with custom allocation callbacks.
        /// </summary>
        public static void ma_data_source_node_uninit(ma_data_source_node_ptr pDataSourceNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_data_source_node_uninit(pDataSourceNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a data source node with default allocation callbacks.
        /// </summary>
        public static unsafe void ma_data_source_node_uninit(ma_data_source_node_ptr pDataSourceNode)
        {
            unsafe
            {
                ma_data_source_node_uninit(pDataSourceNode, null);
            }
        }

        /// <summary>
        /// Sets whether the data source node should loop.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_node_set_looping(ma_data_source_node_ptr pDataSourceNode, ma_bool32 isLooping);

        /// <summary>
        /// Returns whether the data source node is currently looping.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_data_source_node_is_looping(ma_data_source_node_ptr pDataSourceNode);

        // ma_fader
        /// <summary>
        /// Initializes a fader config with the specified format, channels, and sample rate.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_fader_config ma_fader_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate);

        /// <summary>
        /// Initializes a fader which applies smooth volume fading over time.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_fader_init(ref ma_fader_config pConfig, ma_fader_ptr pFader);

        /// <summary>
        /// Processes PCM frames through the fader, applying the current fade volume.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_fader_process_pcm_frames(ma_fader_ptr pFader, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        /// <summary>
        /// Gets the data format of the fader.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_get_data_format(ma_fader_ptr pFader, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate);

        /// <summary>
        /// Sets a volume fade from volumeBeg to volumeEnd over the specified length in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_set_fade(ma_fader_ptr pFader, float volumeBeg, float volumeEnd, ma_uint64 lengthInFrames);

        /// <summary>
        /// Sets a volume fade with an additional start offset in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_set_fade_ex(ma_fader_ptr pFader, float volumeBeg, float volumeEnd, ma_uint64 lengthInFrames, ma_int64 startOffsetInFrames);

        /// <summary>
        /// Gets the current volume of the fader.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_fader_get_current_volume(ma_fader_ptr pFader);

        // ma_panner
        /// <summary>
        /// Initializes a panner config with the specified format and channels.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_panner_config ma_panner_config_init(ma_format format, ma_uint32 channels);

        /// <summary>
        /// Initializes a panner which applies panning to audio data.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_panner_init(ref ma_panner_config pConfig, ma_panner_ptr pPanner);

        /// <summary>
        /// Processes PCM frames through the panner, applying the current pan settings.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_panner_process_pcm_frames(ma_panner_ptr pPanner, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        /// <summary>
        /// Sets the panning mode (e.g., balance, panning law).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_panner_set_mode(ma_panner_ptr pPanner, ma_pan_mode mode);

        /// <summary>
        /// Gets the current panning mode.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_panner_get_mode(ma_panner_ptr pPanner);

        /// <summary>
        /// Sets the pan position. -1 is left, 0 is center, +1 is right.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_panner_set_pan(ma_panner_ptr pPanner, float pan);

        /// <summary>
        /// Gets the current pan position.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_panner_get_pan(ma_panner_ptr pPanner);

        // ma_channel_map
        /// <summary>
        /// Gets the channel position at the specified index within a channel map.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_channel ma_channel_map_get_channel(ma_channel_ptr pChannelMap, ma_uint32 channelCount, ma_uint32 channelIndex);

        /// <summary>
        /// Initializes a channel map with blank (unspecified) channel positions.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_init_blank(ma_channel_ptr pChannelMap, ma_uint32 channels);

        /// <summary>
        /// Initializes a channel map with a standard layout (e.g., mono, stereo, 5.1, 7.1).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_init_standard(ma_standard_channel_map standardChannelMap, ma_channel_ptr pChannelMap, size_t channelMapCap, ma_uint32 channels);

        /// <summary>
        /// Copies a channel map from source to destination.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_copy(ma_channel_ptr pOut, ma_channel_ptr pIn, ma_uint32 channels);

        /// <summary>
        /// Copies a channel map, falling back to a default layout if the source is invalid.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_copy_or_default(ma_channel_ptr pOut, size_t channelMapCapOut, ma_channel_ptr pIn, ma_uint32 channels);

        /// <summary>
        /// Returns whether the channel map is valid (all channels have valid positions).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_valid(ma_channel_ptr pChannelMap, ma_uint32 channels);

        /// <summary>
        /// Returns whether two channel maps are equal.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_equal(ma_channel_ptr pChannelMapA, ma_channel_ptr pChannelMapB, ma_uint32 channels);

        /// <summary>
        /// Returns whether the channel map is blank (all channels are unspecified).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_blank(ma_channel_ptr pChannelMap, ma_uint32 channels);

        /// <summary>
        /// Checks if a channel map contains a specific channel position.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_contains_channel_position(ma_uint32 channels, ma_channel_ptr pChannelMap, ma_channel channelPosition);

        /// <summary>
        /// Finds the index of a specific channel position within the channel map.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_find_channel_position(ma_uint32 channels, ma_channel_ptr pChannelMap, ma_channel channelPosition, out ma_uint32 pChannelIndex);

        /// <summary>
        /// Converts a channel map to its string representation (e.g., "FL FR").
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_channel_map_to_string(ma_channel_ptr pChannelMap, ma_uint32 channels, IntPtr pBufferOut, size_t bufferCap);

        // ma_encoder
        /// <summary>
        /// Initializes an encoder config with the specified encoding format, sample format, channels, and sample rate.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_encoder_config ma_encoder_config_init(ma_encoding_format encodingFormat, ma_format format, ma_uint32 channels, ma_uint32 sampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_encoder_init(IntPtr onWrite, IntPtr onSeek, IntPtr pUserData, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        /// <summary>
        /// Initializes an encoder with custom write and seek callbacks.
        /// </summary>
        public static ma_result ma_encoder_init(ma_encoder_write_proc onWrite, ma_encoder_seek_proc onSeek, IntPtr pUserData, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder)
        {
            return ma_encoder_init(MarshalHelper.GetFunctionPointerForDelegate(onWrite), MarshalHelper.GetFunctionPointerForDelegate(onWrite), pUserData, ref pConfig, pEncoder);
        }

        /// <summary>
        /// Initializes an encoder writing to a file using a custom virtual file system.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_vfs(ma_vfs pVFS, string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        /// <summary>
        /// Initializes an encoder writing to a file using a custom virtual file system (wide string path).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_vfs_w(ma_vfs pVFS, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        /// <summary>
        /// Initializes an encoder writing to a file path.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_file(string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        /// <summary>
        /// Initializes an encoder writing to a file path (wide string path).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_file_w([MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        /// <summary>
        /// Uninitializes an encoder and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_encoder_uninit(ma_encoder_ptr pEncoder);

        /// <summary>
        /// Writes PCM frames to the encoder for encoding.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_write_pcm_frames(ma_encoder_ptr pEncoder, IntPtr pFramesIn, ma_uint64 frameCount, out ma_uint64 pFramesWritten);

        // ma_biquad/filters general
        /// <summary>
        /// Initializes a biquad filter config with the specified coefficients.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_biquad_config ma_biquad_config_init(ma_format format, UInt32 channels, double b0, double b1, double b2, double a0, double a1, double a2);
        
        /// <summary>
        /// Calculates the heap size required for a biquad filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_get_heap_size(ref ma_biquad_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a biquad filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_init_preallocated(ref ma_biquad_config pConfig, IntPtr pHeap, ma_biquad_ptr pBQ);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_biquad_init(ref ma_biquad_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_biquad_ptr pBQ);

        /// <summary>
        /// Initializes a biquad filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_biquad_init(ref ma_biquad_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_biquad_ptr pBQ)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_biquad_init(ref pConfig, pCallbacks, pBQ);
                }
            }
        }

        /// <summary>
        /// Initializes a biquad filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_biquad_init(ref ma_biquad_config pConfig, ma_biquad_ptr pBQ)
        {
            unsafe
            {
                return ma_biquad_init(ref pConfig, null, pBQ);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_biquad_uninit(ma_biquad_ptr pBQ, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a biquad filter with custom allocation callbacks.
        /// </summary>
        public static void ma_biquad_uninit(ma_biquad_ptr pBQ, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_biquad_uninit(pBQ, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a biquad filter with default allocation callbacks.
        /// </summary>
        public static void ma_biquad_uninit(ma_biquad_ptr pBQ)
        {
            unsafe
            {
                ma_biquad_uninit(pBQ, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a biquad filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_reinit(ref ma_biquad_config pConfig, ma_biquad_ptr pBQ);
        
        /// <summary>
        /// Clears the internal state (delay buffer) of the biquad filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_clear_cache(ma_biquad_ptr pBQ);
        
        /// <summary>
        /// Processes PCM frames through the biquad filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_process_pcm_frames(ma_biquad_ptr pBQ, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the biquad filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_biquad_get_latency(ma_biquad_ptr pBQ);
        
        /// <summary>
        /// Initializes a first-order low-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf1_config ma_lpf1_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency);
        
        /// <summary>
        /// Initializes a second-order low-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf2_config ma_lpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        /// <summary>
        /// Calculates the heap size required for a first-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_get_heap_size(ref ma_lpf1_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a first-order low-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_init_preallocated(ref ma_lpf1_config pConfig, IntPtr pHeap, ma_lpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf1_init(ref ma_lpf1_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf1_ptr pLPF);

        /// <summary>
        /// Initializes a first-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf1_init(ref ma_lpf1_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_lpf1_ptr pLPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_lpf1_init(ref pConfig, pCallbacks, pLPF);
                }
            }
        }

        /// <summary>
        /// Initializes a first-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf1_init(ref ma_lpf1_config pConfig, ma_lpf1_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf1_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf1_uninit(ma_lpf1_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a first-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_lpf1_uninit(ma_lpf1_ptr pLPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_lpf1_uninit(pLPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a first-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_lpf1_uninit(ma_lpf1_ptr pLPF)
        {
            unsafe
            {
                ma_lpf1_uninit(pLPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a first-order low-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_reinit(ref ma_lpf1_config pConfig, ma_lpf1_ptr pLPF);
        
        /// <summary>
        /// Clears the internal state of the first-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_clear_cache(ma_lpf1_ptr pLPF);
        
        /// <summary>
        /// Processes PCM frames through the first-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_process_pcm_frames(ma_lpf1_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the first-order low-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf1_get_latency(ma_lpf1_ptr pLPF);
        
        /// <summary>
        /// Calculates the heap size required for a second-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_get_heap_size(ref ma_lpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order low-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_init_preallocated(ref ma_lpf2_config pConfig, IntPtr pHeap, ma_lpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf2_init(ref ma_lpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf2_ptr pLPF);

        /// <summary>
        /// Initializes a second-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf2_init(ref ma_lpf2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_lpf2_ptr pLPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_lpf2_init(ref pConfig, pCallbacks, pLPF);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf2_init(ref ma_lpf2_config pConfig, ma_lpf2_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf2_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf2_uninit(ma_lpf2_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_lpf2_uninit(ma_lpf2_ptr pLPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_lpf2_uninit(pLPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_lpf2_uninit(ma_lpf2_ptr pLPF)
        {
            unsafe
            {
                ma_lpf2_uninit(pLPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order low-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_reinit(ref ma_lpf2_config pConfig, ma_lpf2_ptr pLPF);
        
        /// <summary>
        /// Clears the internal state of the second-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_clear_cache(ma_lpf2_ptr pLPF);
        
        /// <summary>
        /// Processes PCM frames through the second-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_process_pcm_frames(ma_lpf2_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order low-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf2_get_latency(ma_lpf2_ptr pLPF);
        
        /// <summary>
        /// Initializes a configurable-order low-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf_config ma_lpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        /// <summary>
        /// Calculates the heap size required for a configurable-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_get_heap_size(ref ma_lpf_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a configurable-order low-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_init_preallocated(ref ma_lpf_config pConfig, IntPtr pHeap, ma_lpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf_init(ref ma_lpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf_ptr pLPF);

        /// <summary>
        /// Initializes a configurable-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf_init(ref ma_lpf_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_lpf_ptr pLPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_lpf_init(ref pConfig, pCallbacks, pLPF);
                }
            }
        }

        /// <summary>
        /// Initializes a configurable-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf_init(ref ma_lpf_config pConfig, ma_lpf_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf_uninit(ma_lpf_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a configurable-order low-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_lpf_uninit(ma_lpf_ptr pLPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_lpf_uninit(pLPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a configurable-order low-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_lpf_uninit(ma_lpf_ptr pLPF)
        {
            unsafe
            {
                ma_lpf_uninit(pLPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a configurable-order low-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_reinit(ref ma_lpf_config pConfig, ma_lpf_ptr pLPF);
        
        /// <summary>
        /// Clears the internal state of the configurable-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_clear_cache(ma_lpf_ptr pLPF);
        
        /// <summary>
        /// Processes PCM frames through the configurable-order low-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_process_pcm_frames(ma_lpf_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the configurable-order low-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf_get_latency(ma_lpf_ptr pLPF);
        
        /// <summary>
        /// Initializes a first-order high-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf1_config ma_hpf1_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency);
        
        /// <summary>
        /// Initializes a second-order high-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf2_config ma_hpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        /// <summary>
        /// Calculates the heap size required for a first-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_get_heap_size(ref ma_hpf1_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a first-order high-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_init_preallocated(ref ma_hpf1_config pConfig, IntPtr pHeap, ma_hpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf1_init(ref ma_hpf1_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf1_ptr pHPF);

        /// <summary>
        /// Initializes a first-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf1_init(ref ma_hpf1_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hpf1_ptr pHPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hpf1_init(ref pConfig, pCallbacks, pHPF);
                }
            }
        }

        /// <summary>
        /// Initializes a first-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf1_init(ref ma_hpf1_config pConfig, ma_hpf1_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf1_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf1_uninit(ma_hpf1_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a first-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_hpf1_uninit(ma_hpf1_ptr pHPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hpf1_uninit(pHPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a first-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_hpf1_uninit(ma_hpf1_ptr pHPF)
        {
            unsafe
            {
                ma_hpf1_uninit(pHPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a first-order high-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_reinit(ref ma_hpf1_config pConfig, ma_hpf1_ptr pHPF);
        
        /// <summary>
        /// Processes PCM frames through the first-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_process_pcm_frames(ma_hpf1_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the first-order high-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf1_get_latency(ma_hpf1_ptr pHPF);
        
        /// <summary>
        /// Calculates the heap size required for a second-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_get_heap_size(ref ma_hpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order high-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_init_preallocated(ref ma_hpf2_config pConfig, IntPtr pHeap, ma_hpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf2_init(ref ma_hpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf2_ptr pHPF);

        /// <summary>
        /// Initializes a second-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf2_init(ref ma_hpf2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hpf2_ptr pHPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hpf2_init(ref pConfig, pCallbacks, pHPF);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf2_init(ref ma_hpf2_config pConfig, ma_hpf2_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf2_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf2_uninit(ma_hpf2_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_hpf2_uninit(ma_hpf2_ptr pHPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hpf2_uninit(pHPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_hpf2_uninit(ma_hpf2_ptr pHPF)
        {
            unsafe
            {
                ma_hpf2_uninit(pHPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order high-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_reinit(ref ma_hpf2_config pConfig, ma_hpf2_ptr pHPF);
        
        /// <summary>
        /// Processes PCM frames through the second-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_process_pcm_frames(ma_hpf2_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order high-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf2_get_latency(ma_hpf2_ptr pHPF);
        
        /// <summary>
        /// Initializes a configurable-order high-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf_config ma_hpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        /// <summary>
        /// Calculates the heap size required for a configurable-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_get_heap_size(ref ma_hpf_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a configurable-order high-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_init_preallocated(ref ma_hpf_config pConfig, IntPtr pHeap, ma_hpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf_init(ref ma_hpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf_ptr pHPF);

        /// <summary>
        /// Initializes a configurable-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf_init(ref ma_hpf_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hpf_ptr pHPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hpf_init(ref pConfig, pCallbacks, pHPF);
                }
            }
        }

        /// <summary>
        /// Initializes a configurable-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf_init(ref ma_hpf_config pConfig, ma_hpf_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf_uninit(ma_hpf_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a configurable-order high-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_hpf_uninit(ma_hpf_ptr pHPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hpf_uninit(pHPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a configurable-order high-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_hpf_uninit(ma_hpf_ptr pHPF)
        {
            unsafe
            {
                ma_hpf_uninit(pHPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a configurable-order high-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_reinit(ref ma_hpf_config pConfig, ma_hpf_ptr pHPF);
        
        /// <summary>
        /// Processes PCM frames through the configurable-order high-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_process_pcm_frames(ma_hpf_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the configurable-order high-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf_get_latency(ma_hpf_ptr pHPF);
        
        /// <summary>
        /// Initializes a second-order band-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf2_config ma_bpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        /// <summary>
        /// Calculates the heap size required for a second-order band-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_get_heap_size(ref ma_bpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order band-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_init_preallocated(ref ma_bpf2_config pConfig, IntPtr pHeap, ma_bpf2_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf2_init(ref ma_bpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf2_ptr pBPF);

        /// <summary>
        /// Initializes a second-order band-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf2_init(ref ma_bpf2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_bpf2_ptr pBPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_bpf2_init(ref pConfig, pCallbacks, pBPF);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order band-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf2_init(ref ma_bpf2_config pConfig, ma_bpf2_ptr pBPF)
        {
            unsafe
            {
                return ma_bpf2_init(ref pConfig, null, pBPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf2_uninit(ma_bpf2_ptr pBPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order band-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_bpf2_uninit(ma_bpf2_ptr pBPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_bpf2_uninit(pBPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order band-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_bpf2_uninit(ma_bpf2_ptr pBPF)
        {
            unsafe
            {
                ma_bpf2_uninit(pBPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order band-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_reinit(ref ma_bpf2_config pConfig, ma_bpf2_ptr pBPF);
        
        /// <summary>
        /// Processes PCM frames through the second-order band-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_process_pcm_frames(ma_bpf2_ptr pBPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order band-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_bpf2_get_latency(ma_bpf2_ptr pBPF);
        
        /// <summary>
        /// Initializes a configurable-order band-pass filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf_config ma_bpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        /// <summary>
        /// Calculates the heap size required for a configurable-order band-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_get_heap_size(ref ma_bpf_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a configurable-order band-pass filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_init_preallocated(ref ma_bpf_config pConfig, IntPtr pHeap, ma_bpf_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf_init(ref ma_bpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf_ptr pBPF);

        /// <summary>
        /// Initializes a configurable-order band-pass filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf_init(ref ma_bpf_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_bpf_ptr pBPF)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_bpf_init(ref pConfig, pCallbacks, pBPF);
                }
            }
        }

        /// <summary>
        /// Initializes a configurable-order band-pass filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf_init(ref ma_bpf_config pConfig, ma_bpf_ptr pBPF)
        {
            unsafe
            {
                return ma_bpf_init(ref pConfig, null, pBPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf_uninit(ma_bpf_ptr pBPF, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a configurable-order band-pass filter with custom allocation callbacks.
        /// </summary>
        public static void ma_bpf_uninit(ma_bpf_ptr pBPF, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_bpf_uninit(pBPF, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a configurable-order band-pass filter with default allocation callbacks.
        /// </summary>
        public static void ma_bpf_uninit(ma_bpf_ptr pBPF)
        {
            unsafe
            {
                ma_bpf_uninit(pBPF, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a configurable-order band-pass filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_reinit(ref ma_bpf_config pConfig, ma_bpf_ptr pBPF);
        
        /// <summary>
        /// Processes PCM frames through the configurable-order band-pass filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_process_pcm_frames(ma_bpf_ptr pBPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the configurable-order band-pass filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_bpf_get_latency(ma_bpf_ptr pBPF);
        
        /// <summary>
        /// Initializes a second-order notch filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_notch2_config ma_notch2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double q, double frequency);
        
        /// <summary>
        /// Calculates the heap size required for a second-order notch filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_get_heap_size(ref ma_notch2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order notch filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_init_preallocated(ref ma_notch2_config pConfig, IntPtr pHeap, ma_notch2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_notch2_init(ref ma_notch2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch2_ptr pFilter);

        /// <summary>
        /// Initializes a second-order notch filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_notch2_init(ref ma_notch2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_notch2_ptr pFilter)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_notch2_init(ref pConfig, pCallbacks, pFilter);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order notch filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_notch2_init(ref ma_notch2_config pConfig, ma_notch2_ptr pFilter)
        {
            unsafe
            {
                return ma_notch2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_notch2_uninit(ma_notch2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order notch filter with custom allocation callbacks.
        /// </summary>
        public static void ma_notch2_uninit(ma_notch2_ptr pFilter, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_notch2_uninit(pFilter, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order notch filter with default allocation callbacks.
        /// </summary>
        public static void ma_notch2_uninit(ma_notch2_ptr pFilter)
        {
            unsafe
            {
                ma_notch2_uninit(pFilter, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order notch filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_reinit(ref ma_notch2_config pConfig, ma_notch2_ptr pFilter);
        
        /// <summary>
        /// Processes PCM frames through the second-order notch filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_process_pcm_frames(ma_notch2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order notch filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_notch2_get_latency(ma_notch2_ptr pFilter);
        
        /// <summary>
        /// Initializes a second-order peaking EQ filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_peak2_config ma_peak2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double q, double frequency);
        
        /// <summary>
        /// Calculates the heap size required for a second-order peaking EQ filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_get_heap_size(ref ma_peak2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order peaking EQ filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_init_preallocated(ref ma_peak2_config pConfig, IntPtr pHeap, ma_peak2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_peak2_init(ref ma_peak2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak2_ptr pFilter);

        /// <summary>
        /// Initializes a second-order peaking EQ filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_peak2_init(ref ma_peak2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_peak2_ptr pFilter)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_peak2_init(ref pConfig, pCallbacks, pFilter);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order peaking EQ filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_peak2_init(ref ma_peak2_config pConfig, ma_peak2_ptr pFilter)
        {
            unsafe
            {
                return ma_peak2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_peak2_uninit(ma_peak2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order peaking EQ filter with custom allocation callbacks.
        /// </summary>
        public static void ma_peak2_uninit(ma_peak2_ptr pFilter, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_peak2_uninit(pFilter, pCallbacks);
                }
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order peaking EQ filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_reinit(ref ma_peak2_config pConfig, ma_peak2_ptr pFilter);
        
        /// <summary>
        /// Processes PCM frames through the second-order peaking EQ filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_process_pcm_frames(ma_peak2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order peaking EQ filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_peak2_get_latency(ma_peak2_ptr pFilter);
        
        /// <summary>
        /// Initializes a second-order low-shelf filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_loshelf2_config ma_loshelf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double shelfSlope, double frequency);
        
        /// <summary>
        /// Calculates the heap size required for a second-order low-shelf filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_get_heap_size(ref ma_loshelf2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order low-shelf filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_init_preallocated(ref ma_loshelf2_config pConfig, IntPtr pHeap, ma_loshelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_loshelf2_init(ref ma_loshelf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf2_ptr pFilter);

        /// <summary>
        /// Initializes a second-order low-shelf filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_loshelf2_init(ref ma_loshelf2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_loshelf2_ptr pFilter)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_loshelf2_init(ref pConfig, pCallbacks, pFilter);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order low-shelf filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_loshelf2_init(ref ma_loshelf2_config pConfig, ma_loshelf2_ptr pFilter)
        {
            unsafe
            {
                return ma_loshelf2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_loshelf2_uninit(ma_loshelf2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order low-shelf filter with custom allocation callbacks.
        /// </summary>
        public static void ma_loshelf2_uninit(ma_loshelf2_ptr pFilter, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_loshelf2_uninit(pFilter, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order low-shelf filter with default allocation callbacks.
        /// </summary>
        public static void ma_loshelf2_uninit(ma_loshelf2_ptr pFilter)
        {
            unsafe
            {
                ma_loshelf2_uninit(pFilter, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order low-shelf filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_reinit(ref ma_loshelf2_config pConfig, ma_loshelf2_ptr pFilter);
        
        /// <summary>
        /// Processes PCM frames through the second-order low-shelf filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_process_pcm_frames(ma_loshelf2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order low-shelf filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_loshelf2_get_latency(ma_loshelf2_ptr pFilter);
        
        /// <summary>
        /// Initializes a second-order high-shelf filter config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hishelf2_config ma_hishelf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double shelfSlope, double frequency);
        
        /// <summary>
        /// Calculates the heap size required for a second-order high-shelf filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_get_heap_size(ref ma_hishelf2_config pConfig, out size_t pHeapSizeInBytes);
        
        /// <summary>
        /// Initializes a second-order high-shelf filter with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_init_preallocated(ref ma_hishelf2_config pConfig, IntPtr pHeap, ma_hishelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hishelf2_init(ref ma_hishelf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf2_ptr pFilter);

        /// <summary>
        /// Initializes a second-order high-shelf filter with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hishelf2_init(ref ma_hishelf2_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hishelf2_ptr pFilter)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hishelf2_init(ref pConfig, pCallbacks, pFilter);
                }
            }
        }

        /// <summary>
        /// Initializes a second-order high-shelf filter with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hishelf2_init(ref ma_hishelf2_config pConfig, ma_hishelf2_ptr pFilter)
        {
            unsafe
            {
                return ma_hishelf2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hishelf2_uninit(ma_hishelf2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a second-order high-shelf filter with custom allocation callbacks.
        /// </summary>
        public static void ma_hishelf2_uninit(ma_hishelf2_ptr pFilter, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hishelf2_uninit(pFilter, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a second-order high-shelf filter with default allocation callbacks.
        /// </summary>
        public static void ma_hishelf2_uninit(ma_hishelf2_ptr pFilter)
        {
            unsafe
            {
                ma_hishelf2_uninit(pFilter, null);
            }
        }
        
        /// <summary>
        /// Reinitializes a second-order high-shelf filter with a new config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_reinit(ref ma_hishelf2_config pConfig, ma_hishelf2_ptr pFilter);
        
        /// <summary>
        /// Processes PCM frames through the second-order high-shelf filter.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_process_pcm_frames(ma_hishelf2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        /// <summary>
        /// Gets the latency of the second-order high-shelf filter in frames.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hishelf2_get_latency(ma_hishelf2_ptr pFilter);

        /// <summary>
        /// Initializes a low-pass filter node config with the specified channels, sample rate, cutoff frequency, and filter order.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf_node_config ma_lpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_lpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf_node_ptr pNode);

        /// <summary>
        /// Initializes a low-pass filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_lpf_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_lpf_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_lpf_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a low-pass filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_lpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_lpf_node_config pConfig, ma_lpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_lpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a low-pass filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_node_reinit(ref ma_lpf_config pConfig, ma_lpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf_node_uninit(ma_lpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a low-pass filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_lpf_node_uninit(ma_lpf_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_lpf_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a low-pass filter node with default allocation callbacks.
        /// </summary>
        public static void ma_lpf_node_uninit(ma_lpf_node_ptr pNode)
        {
            unsafe
            {
                ma_lpf_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a high-pass filter node config with the specified channels, sample rate, cutoff frequency, and filter order.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf_node_config ma_hpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf_node_ptr pNode);

        /// <summary>
        /// Initializes a high-pass filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hpf_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hpf_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hpf_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a high-pass filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hpf_node_config pConfig, ma_hpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_hpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a high-pass filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_node_reinit(ref ma_hpf_config pConfig, ma_hpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf_node_uninit(ma_hpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a high-pass filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_hpf_node_uninit(ma_hpf_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hpf_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a high-pass filter node with default allocation callbacks.
        /// </summary>
        public static void ma_hpf_node_uninit(ma_hpf_node_ptr pNode)
        {
            unsafe
            {
                ma_hpf_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a band-pass filter node config with the specified channels, sample rate, cutoff frequency, and filter order.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf_node_config ma_bpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_bpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf_node_ptr pNode);

        /// <summary>
        /// Initializes a band-pass filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_bpf_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_bpf_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_bpf_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a band-pass filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_bpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_bpf_node_config pConfig, ma_bpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_bpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a band-pass filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_node_reinit(ref ma_bpf_config pConfig, ma_bpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf_node_uninit(ma_bpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a band-pass filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_bpf_node_uninit(ma_bpf_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_bpf_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a band-pass filter node with default allocation callbacks.
        /// </summary>
        public static void ma_bpf_node_uninit(ma_bpf_node_ptr pNode)
        {
            unsafe
            {
                ma_bpf_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a notch (band-reject) filter node config with the specified channels, sample rate, Q factor, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_notch_node_config ma_notch_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_notch_node_init(ma_node_graph_ptr pNodeGraph, ref ma_notch_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch_node_ptr pNode);

        /// <summary>
        /// Initializes a notch filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_notch_node_init(ma_node_graph_ptr pNodeGraph, ref ma_notch_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_notch_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_notch_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a notch filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_notch_node_init(ma_node_graph_ptr pNodeGraph, ref ma_notch_node_config pConfig, ma_notch_node_ptr pNode)
        {
            unsafe
            {
                return ma_notch_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a notch filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch_node_reinit(ref ma_notch_config pConfig, ma_notch_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_notch_node_uninit(ma_notch_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a notch filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_notch_node_uninit(ma_notch_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_notch_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a notch filter node with default allocation callbacks.
        /// </summary>
        public static void ma_notch_node_uninit(ma_notch_node_ptr pNode)
        {
            unsafe
            {
                ma_notch_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a peaking EQ filter node config with the specified channels, sample rate, gain in dB, Q factor, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_peak_node_config ma_peak_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_peak_node_init(ma_node_graph_ptr pNodeGraph, ref ma_peak_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak_node_ptr pNode);

        /// <summary>
        /// Initializes a peaking EQ filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_peak_node_init(ma_node_graph_ptr pNodeGraph, ref ma_peak_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_peak_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_peak_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a peaking EQ filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_peak_node_init(ma_node_graph_ptr pNodeGraph, ref ma_peak_node_config pConfig, ma_peak_node_ptr pNode)
        {
            unsafe
            {
                return ma_peak_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a peaking EQ filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak_node_reinit(ref ma_peak_config pConfig, ma_peak_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_peak_node_uninit(ma_peak_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a peaking EQ filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_peak_node_uninit(ma_peak_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_peak_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a peaking EQ filter node with default allocation callbacks.
        /// </summary>
        public static void ma_peak_node_uninit(ma_peak_node_ptr pNode)
        {
            unsafe
            {
                ma_peak_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a low-shelf filter node config with the specified channels, sample rate, gain in dB, Q factor, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_loshelf_node_config ma_loshelf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_loshelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_loshelf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf_node_ptr pNode);

        /// <summary>
        /// Initializes a low-shelf filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_loshelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_loshelf_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_loshelf_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_loshelf_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a low-shelf filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_loshelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_loshelf_node_config pConfig, ma_loshelf_node_ptr pNode)
        {
            unsafe
            {
                return ma_loshelf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a low-shelf filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf_node_reinit(ref ma_loshelf_config pConfig, ma_loshelf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_loshelf_node_uninit(ma_loshelf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a low-shelf filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_loshelf_node_uninit(ma_loshelf_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_loshelf_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a low-shelf filter node with default allocation callbacks.
        /// </summary>
        public static void ma_loshelf_node_uninit(ma_loshelf_node_ptr pNode)
        {
            unsafe
            {
                ma_loshelf_node_uninit(pNode, null);
            }
        }

        /// <summary>
        /// Initializes a high-shelf filter node config with the specified channels, sample rate, gain in dB, Q factor, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hishelf_node_config ma_hishelf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hishelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hishelf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf_node_ptr pNode);

        /// <summary>
        /// Initializes a high-shelf filter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_hishelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hishelf_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_hishelf_node_ptr pNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_hishelf_node_init(pNodeGraph, ref pConfig, pCallbacks, pNode);
                }
            }
        }

        /// <summary>
        /// Initializes a high-shelf filter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_hishelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hishelf_node_config pConfig, ma_hishelf_node_ptr pNode)
        {
            unsafe
            {
                return ma_hishelf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        /// <summary>
        /// Reinitializes a high-shelf filter node with a new filter configuration.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf_node_reinit(ref ma_hishelf_config pConfig, ma_hishelf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hishelf_node_uninit(ma_hishelf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a high-shelf filter node with custom allocation callbacks.
        /// </summary>
        public static void ma_hishelf_node_uninit(ma_hishelf_node_ptr pNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_hishelf_node_uninit(pNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a high-shelf filter node with default allocation callbacks.
        /// </summary>
        public static void ma_hishelf_node_uninit(ma_hishelf_node_ptr pNode)
        {
            unsafe
            {
                ma_hishelf_node_uninit(pNode, null);
            }
        }

        //ma_delay
        /// <summary>
        /// Initializes a delay config with the specified channels, sample rate, delay in frames, and decay factor.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_delay_config ma_delay_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_uint32 delayInFrames, float decay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_delay_init(ref ma_delay_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay_ptr pDelay);

        /// <summary>
        /// Initializes a delay effect with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_delay_init(ref ma_delay_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_delay_ptr pDelay)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_delay_init(ref pConfig, pCallbacks, pDelay);
                }
            }
        }

        /// <summary>
        /// Initializes a delay effect with default allocation callbacks.
        /// </summary>
        public static ma_result ma_delay_init(ref ma_delay_config pConfig, ma_delay_ptr pDelay)
        {
            unsafe
            {
                return ma_delay_init(ref pConfig, null, pDelay);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_delay_uninit(ma_delay_ptr pDelay, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a delay effect with custom allocation callbacks.
        /// </summary>
        public static void ma_delay_uninit(ma_delay_ptr pDelay, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_delay_uninit(pDelay, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a delay effect with default allocation callbacks.
        /// </summary>
        public static void ma_delay_uninit(ma_delay_ptr pDelay)
        {
            unsafe
            {
                ma_delay_uninit(pDelay, null);
            }
        }

        /// <summary>
        /// Processes PCM frames through the delay effect, producing delayed output.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_delay_process_pcm_frames(ma_delay_ptr pDelay, IntPtr pFramesOut, IntPtr pFramesIn, UInt32 frameCount);

        /// <summary>
        /// Sets the wet (processed) signal level of the delay.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_wet(ma_delay_ptr pDelay, float value);

        /// <summary>
        /// Gets the wet (processed) signal level of the delay.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_wet(ma_delay_ptr pDelay);

        /// <summary>
        /// Sets the dry (unprocessed) signal level of the delay.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_dry(ma_delay_ptr pDelay, float value);

        /// <summary>
        /// Gets the dry (unprocessed) signal level of the delay.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_dry(ma_delay_ptr pDelay);

        /// <summary>
        /// Sets the decay factor of the delay, controlling how much the delayed signal attenuates over time.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_decay(ma_delay_ptr pDelay, float value);

        /// <summary>
        /// Gets the decay factor of the delay.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_decay(ma_delay_ptr pDelay);

        //ma_delay_node
        /// <summary>
        /// Initializes a delay node config with the specified channels, sample rate, delay in frames, and decay factor.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_delay_node_config ma_delay_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_uint32 delayInFrames, float decay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_delay_node_init(ma_node_graph_ptr pNodeGraph, ref ma_delay_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay_node_ptr pDelayNode);

        /// <summary>
        /// Initializes a delay node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_delay_node_init(ma_node_graph_ptr pNodeGraph, ref ma_delay_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_delay_node_ptr pDelayNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_delay_node_init(pNodeGraph, ref pConfig, pCallbacks, pDelayNode);
                }
            }
        }

        /// <summary>
        /// Initializes a delay node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_delay_node_init(ma_node_graph_ptr pNodeGraph, ref ma_delay_node_config pConfig, ma_delay_node_ptr pDelayNode)
        {
            unsafe
            {
                return ma_delay_node_init(pNodeGraph, ref pConfig, null, pDelayNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_delay_node_uninit(ma_delay_node_ptr pDelayNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a delay node with custom allocation callbacks.
        /// </summary>
        public static void ma_delay_node_uninit(ma_delay_node_ptr pDelayNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_delay_node_uninit(pDelayNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a delay node with default allocation callbacks.
        /// </summary>
        public static void ma_delay_node_uninit(ma_delay_node_ptr pDelayNode)
        {
            unsafe
            {
                ma_delay_node_uninit(pDelayNode, null);
            }
        }

        /// <summary>
        /// Sets the wet (processed) signal level of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_wet(ma_delay_node_ptr pDelayNode, float value);

        /// <summary>
        /// Gets the wet (processed) signal level of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_wet(ma_delay_node_ptr pDelayNode);

        /// <summary>
        /// Sets the dry (unprocessed) signal level of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_dry(ma_delay_node_ptr pDelayNode, float value);

        /// <summary>
        /// Gets the dry (unprocessed) signal level of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_dry(ma_delay_node_ptr pDelayNode);

        /// <summary>
        /// Sets the decay factor of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_decay(ma_delay_node_ptr pDelayNode, float value);

        /// <summary>
        /// Gets the decay factor of the delay node.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_decay(ma_delay_node_ptr pDelayNode);

        //ma_splitter_node
        /// <summary>
        /// Initializes a splitter node config with the specified number of channels. A splitter node duplicates its input to multiple output buses.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_splitter_node_config ma_splitter_node_config_init(ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_splitter_node_init(ma_node_graph_ptr pNodeGraph, ref ma_splitter_node_config pConfig, ma_allocation_callbacks *pAllocationCallbacks, ma_splitter_node_ptr pSplitterNode);

        /// <summary>
        /// Initializes a splitter node within a node graph with custom allocation callbacks.
        /// </summary>
        public static ma_result ma_splitter_node_init(ma_node_graph_ptr pNodeGraph, ref ma_splitter_node_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_splitter_node_ptr pSplitterNode)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_splitter_node_init(pNodeGraph, ref pConfig, pCallbacks, pSplitterNode);
                }
            }
        }

        /// <summary>
        /// Initializes a splitter node within a node graph with default allocation callbacks.
        /// </summary>
        public static ma_result ma_splitter_node_init(ma_node_graph_ptr pNodeGraph, ref ma_splitter_node_config pConfig, ma_splitter_node_ptr pSplitterNode)
        {
            unsafe
            {
                return ma_splitter_node_init(pNodeGraph, ref pConfig, null, pSplitterNode);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_splitter_node_uninit(ma_splitter_node_ptr pSplitterNode, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a splitter node with custom allocation callbacks.
        /// </summary>
        public static void ma_splitter_node_uninit(ma_splitter_node_ptr pSplitterNode, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_splitter_node_uninit(pSplitterNode, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a splitter node with default allocation callbacks.
        /// </summary>
        public static void ma_splitter_node_uninit(ma_splitter_node_ptr pSplitterNode)
        {
            unsafe
            {
                ma_splitter_node_uninit(pSplitterNode, null);
            }
        }

        //ma_waveform
        /// <summary>
        /// Initializes a waveform config with the specified format, channels, sample rate, waveform type, amplitude, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_waveform_config ma_waveform_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, ma_waveform_type type, double amplitude, double frequency);

        /// <summary>
        /// Initializes a waveform generator which produces periodic waveforms (sine, square, triangle, sawtooth).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_init(ref ma_waveform_config pConfig, ma_waveform_ptr pWaveform);

        /// <summary>
        /// Uninitializes a waveform generator and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_waveform_uninit(ma_waveform_ptr pWaveform);

        /// <summary>
        /// Reads PCM frames from the waveform generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_read_pcm_frames(ma_waveform_ptr pWaveform, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        /// <summary>
        /// Seeks the waveform generator to a specific PCM frame index.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_seek_to_pcm_frame(ma_waveform_ptr pWaveform, ma_uint64 frameIndex);

        /// <summary>
        /// Sets the amplitude of the generated waveform.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_amplitude(ma_waveform_ptr pWaveform, double amplitude);

        /// <summary>
        /// Sets the frequency of the generated waveform in Hz.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_frequency(ma_waveform_ptr pWaveform, double frequency);

        /// <summary>
        /// Sets the waveform type (sine, square, triangle, sawtooth).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_type(ma_waveform_ptr pWaveform, ma_waveform_type type);

        /// <summary>
        /// Sets the sample rate of the waveform generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_sample_rate(ma_waveform_ptr pWaveform, ma_uint32 sampleRate);

        /// <summary>
        /// Initializes a pulse waveform config with the specified format, channels, sample rate, duty cycle, amplitude, and frequency.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pulsewave_config ma_pulsewave_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, double dutyCycle, double amplitude, double frequency);

        /// <summary>
        /// Initializes a pulse waveform generator which produces a rectangular wave with a controllable duty cycle.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_init(ref ma_pulsewave_config pConfig, ma_pulsewave_ptr pWaveform);

        /// <summary>
        /// Uninitializes a pulse waveform generator and releases its resources.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_pulsewave_uninit(ma_pulsewave_ptr pWaveform);

        /// <summary>
        /// Reads PCM frames from the pulse waveform generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_read_pcm_frames(ma_pulsewave_ptr pWaveform, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        /// <summary>
        /// Seeks the pulse waveform generator to a specific PCM frame index.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_seek_to_pcm_frame(ma_pulsewave_ptr pWaveform, ma_uint64 frameIndex);

        /// <summary>
        /// Sets the amplitude of the pulse waveform.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_amplitude(ma_pulsewave_ptr pWaveform, double amplitude);

        /// <summary>
        /// Sets the frequency of the pulse waveform in Hz.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_frequency(ma_pulsewave_ptr pWaveform, double frequency);

        /// <summary>
        /// Sets the sample rate of the pulse waveform generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_sample_rate(ma_pulsewave_ptr pWaveform, ma_uint32 sampleRate);

        /// <summary>
        /// Sets the duty cycle of the pulse waveform (0.0 to 1.0, where 0.5 is a square wave).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_duty_cycle(ma_pulsewave_ptr pWaveform, double dutyCycle);

        /// <summary>
        /// Initializes a noise generator config with the specified format, channels, noise type, seed, and amplitude.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_noise_config ma_noise_config_init(ma_format format, ma_uint32 channels, ma_noise_type type, ma_int32 seed, double amplitude);

        /// <summary>
        /// Gets the required heap size for a noise generator with the given config.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_get_heap_size(ref ma_noise_config pConfig, out size_t pHeapSizeInBytes);

        /// <summary>
        /// Initializes a noise generator with a pre-allocated heap buffer.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_init_preallocated(ref ma_noise_config pConfig, IntPtr pHeap, ma_noise_ptr pNoise);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_noise_init(ref ma_noise_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_noise_ptr pNoise);

        /// <summary>
        /// Initializes a noise generator with custom allocation callbacks. Produces white, pink, or Brownian noise.
        /// </summary>
        public static ma_result ma_noise_init(ref ma_noise_config pConfig, ref ma_allocation_callbacks pAllocationCallbacks, ma_noise_ptr pNoise)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    return ma_noise_init(ref pConfig, pCallbacks, pNoise);
                }
            }
        }

        /// <summary>
        /// Initializes a noise generator with default allocation callbacks.
        /// </summary>
        public static ma_result ma_noise_init(ref ma_noise_config pConfig, ma_noise_ptr pNoise)
        {
            unsafe
            {
                return ma_noise_init(ref pConfig, null, pNoise);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_noise_uninit(ma_noise_ptr pNoise, ma_allocation_callbacks* pAllocationCallbacks);

        /// <summary>
        /// Uninitializes a noise generator with custom allocation callbacks.
        /// </summary>
        public static void ma_noise_uninit(ma_noise_ptr pNoise, ref ma_allocation_callbacks pAllocationCallbacks)
        {
            unsafe
            {
                fixed (ma_allocation_callbacks* pCallbacks = &pAllocationCallbacks)
                {
                    ma_noise_uninit(pNoise, pCallbacks);
                }
            }
        }

        /// <summary>
        /// Uninitializes a noise generator with default allocation callbacks.
        /// </summary>
        public static void ma_noise_uninit(ma_noise_ptr pNoise)
        {
            unsafe
            {
                ma_noise_uninit(pNoise, null);
            }
        }

        /// <summary>
        /// Reads PCM frames from the noise generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_read_pcm_frames(ma_noise_ptr pNoise, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        /// <summary>
        /// Sets the amplitude of the noise generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_set_amplitude(ma_noise_ptr pNoise, double amplitude);

        /// <summary>
        /// Sets the seed for the noise generator's random number generator.
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_set_seed(ma_noise_ptr pNoise, ma_int32 seed);

        /// <summary>
        /// Sets the noise type (white, pink, or Brownian).
        /// </summary>
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_set_type(ma_noise_ptr pNoise, ma_noise_type type);
    }

    public static class MarshalHelper
    {
        /// <summary>
        /// A value that can be passed to unmanaged code, which, in turn, can use it to call the underlying managed delegate. Does not throw exceptions.
        /// </summary>
        /// <typeparam name="TDelegate">The type of delegate to convert.</typeparam>
        /// <param name="d">The delegate to be passed to unmanaged code.</param>
        /// <returns><A value that can be passed to unmanaged code, which, in turn, can use it to call the underlying managed delegate. Returns IntPtr.Zero if the passed delegate is null./returns>
        public static IntPtr GetFunctionPointerForDelegate<TDelegate>(TDelegate d)
        {
            if (d == null)
                return IntPtr.Zero;
            return Marshal.GetFunctionPointerForDelegate(d);
        }

        /// <summary>
        /// Helper method that supports netstandard 2.0. Converts a pointer to an UTF8 string.
        /// </summary>
        /// <param name="p">The pointer with the string to convert</param>
        /// <returns>A UTF8 encoded string</returns>
        public static string PtrToStringUTF8(IntPtr p)
        {
            if (p == IntPtr.Zero)
                return null;

            int length = 0;

            while (Marshal.ReadByte(p, length) != 0)
            {
                length++;
            }

            byte[] bytes = new byte[length];
            Marshal.Copy(p, bytes, 0, length);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static IntPtr AllocHGlobal(int cb)
        {
            return Marshal.AllocHGlobal(cb);
        }

        public static IntPtr AllocHGlobal(byte[] data, out int size)
        {
            size = 0;

            if (data == null)
                return IntPtr.Zero;

            if (data.Length == 0)
                return IntPtr.Zero;

            IntPtr pData = Marshal.AllocHGlobal(data.Length);

            if (pData == IntPtr.Zero)
                return IntPtr.Zero;

            Marshal.Copy(data, 0, pData, data.Length);
            size = data.Length;
            return pData;
        }

        public static void FreeHGlobal(IntPtr hglobal)
        {
            Marshal.FreeHGlobal(hglobal);
        }
    }
}

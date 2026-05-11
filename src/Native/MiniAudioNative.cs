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

    public static class MiniAudioNative
    {
        public const int MA_MAX_CHANNELS = 254;
        public const int MA_MAX_DEVICE_NAME_LENGTH = 255;
        public const int MA_MAX_LOG_CALLBACKS = 4;
        public const int MA_ENGINE_MAX_LISTENERS = 4;
        public const int MA_MAX_NODE_LOCAL_BUS_COUNT = 2;
        public const int MA_MAX_NODE_BUS_COUNT = 254;
        public const int MA_NODE_BUS_COUNT_UNKNOWN = 255;

        private const string LIB_MINIAUDIO_EX = "miniaudioex";

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ma_allocate_type(ma_allocation_type type);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ma_allocate(size_t size);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_deallocate_type(IntPtr pData);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_get_size_of_type(ma_allocation_type type);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_config ma_engine_config_init();

        // ma_device
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_config ma_device_config_init(ma_device_type deviceType);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_init(ma_context_ptr pContext, ref ma_device_config pConfig, ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_device_uninit(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_context_ptr ma_device_get_context(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_start(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_stop(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_device_is_started(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_state ma_device_get_state(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_set_master_volume(ma_device_ptr pDevice, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_get_master_volume(ma_device_ptr pDevice, out float pVolume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_set_master_volume_db(ma_device_ptr pDevice, float gainDB);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_get_master_volume_db(ma_device_ptr pDevice, out float pGainDB);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_device_handle_backend_data_callback(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, ma_uint32 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_resampling_ptr ma_device_get_resampling(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_playback_ptr ma_device_get_playback(ma_device_ptr pDevice);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_capture_ptr ma_device_get_capture(ma_device_ptr pDevice);

        // ma_context
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_context_config ma_context_config_init();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe ma_result ma_context_init(ma_backend* backends, ma_uint32 backendCount, ma_context_config* pConfig, ma_context_ptr pContext);

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

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_context_uninit(ma_context_ptr pContext);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_context_sizeof();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_context_get_log(ma_context_ptr pContext);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_context_enumerate_devices(ma_context_ptr pContext, IntPtr callback, IntPtr pUserData);

        public static ma_result ma_context_enumerate_devices(ma_context_ptr pContext, ma_enum_devices_callback_proc callback, IntPtr pUserData)
        {
            return ma_context_enumerate_devices(pContext, MarshalHelper.GetFunctionPointerForDelegate(callback), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe ma_result ma_context_get_devices(ma_context_ptr pContext, ma_device_info** ppPlaybackDeviceInfos, ma_uint32* pPlaybackDeviceCount, ma_device_info** ppCaptureDeviceInfos, ma_uint32* pCaptureDeviceCount);

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

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_context_get_device_info(ma_context_ptr pContext, ma_device_type deviceType, ma_device_id_ptr pDeviceID, out ma_device_info pDeviceInfo);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_context_is_loopback_supported(ma_context_ptr pContext);

        // ma_engine
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_uninit(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_init(ref ma_engine_config pConfig, ma_engine_ptr pEngine);

        public static ma_result ma_engine_init(ma_engine_ptr pEngine)
        {
            ma_engine_config config = ma_engine_config_init();
            return ma_engine_init(ref config, pEngine);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint64* pFramesRead);

        public static unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount, ref ma_uint64 framesRead)
        {
            fixed (ma_uint64* pFramesRead = &framesRead)
            {
                return ma_engine_read_pcm_frames(pEngine, pFramesOut, frameCount, pFramesRead);
            }
        }

        public static unsafe ma_result ma_engine_read_pcm_frames(ma_engine_ptr pEngine, IntPtr pFramesOut, ma_uint64 frameCount)
        {
            return ma_engine_read_pcm_frames(pEngine, pFramesOut, frameCount, null);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_ptr ma_engine_get_node_graph(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_resource_manager_ptr ma_engine_get_resource_manager(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_device_ptr ma_engine_get_device(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_engine_get_log(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_ptr ma_engine_get_endpoint(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_engine_get_time_in_pcm_frames(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_engine_get_time_in_milliseconds(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_time_in_pcm_frames(ma_engine_ptr pEngine, ma_uint64 globalTime);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_time_in_milliseconds(ma_engine_ptr pEngine, ma_uint64 globalTime);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_channels(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_sample_rate(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_start(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_stop(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_volume(ma_engine_ptr pEngine, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_engine_get_volume(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_set_gain_db(ma_engine_ptr pEngine, float gainDB);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_engine_get_gain_db(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_get_listener_count(ma_engine_ptr pEngine);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_engine_find_closest_listener(ma_engine_ptr pEngine, float absolutePosX, float absolutePosY, float absolutePosZ);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_position(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_position(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_direction(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_direction(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_velocity(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_velocity(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_cone(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_get_cone(ma_engine_ptr pEngine, ma_uint32 listenerIndex, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_world_up(ma_engine_ptr pEngine, ma_uint32 listenerIndex, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_engine_listener_get_world_up(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_engine_listener_set_enabled(ma_engine_ptr pEngine, ma_uint32 listenerIndex, ma_bool32 isEnabled);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_engine_listener_is_enabled(ma_engine_ptr pEngine, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_play_sound_ex(ma_engine_ptr pEngine, string pFilePath, ma_node_ptr pNode, ma_uint32 nodeInputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_engine_play_sound(ma_engine_ptr pEngine, string pFilePath, ma_sound_group_ptr pGroup);   /* Fire and forget. */

        // ma_sound
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_file(ma_engine_ptr pEngine, string pFilePath, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_file_w(ma_engine_ptr pEngine, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_memory(ma_engine_ptr pEngine, IntPtr pData, ma_uint64 dataSize, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_callback(ma_engine_ptr pEngine, ref ma_procedural_data_source_config pConfig, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_fence_ptr pDoneFence, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_copy(ma_engine_ptr pEngine, ma_sound_ptr pExistingSound, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_from_data_source(ma_engine_ptr pEngine, ma_data_source_ptr pDataSource, ma_sound_flags flags, ma_sound_group_ptr pGroup, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_init_ex(ma_engine_ptr pEngine, ref ma_sound_config pConfig, ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_uninit(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_ptr ma_sound_get_engine(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_sound_get_data_source(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_start(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop_with_fade_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 fadeLengthInFrames);     /* Will overwrite any scheduled stop and fade. */

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_stop_with_fade_in_milliseconds(ma_sound_ptr pSound, ma_uint64 fadeLengthInFrames);   /* Will overwrite any scheduled stop and fade. */

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_volume(ma_sound_ptr pSound, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_volume(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pan(ma_sound_ptr pSound, float pan);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_pan(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pan_mode(ma_sound_ptr pSound, ma_pan_mode panMode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_sound_get_pan_mode(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pitch(ma_sound_ptr pSound, float pitch);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_pitch(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_spatialization_enabled(ma_sound_ptr pSound, ma_bool32 enabled);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_spatialization_enabled(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_pinned_listener_index(ma_sound_ptr pSound, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_get_pinned_listener_index(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_get_listener_index(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_direction_to_listener(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_position(ma_sound_ptr pSound, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_position(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_direction(ma_sound_ptr pSound, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_direction(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_velocity(ma_sound_ptr pSound, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_get_velocity(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_attenuation_model(ma_sound_ptr pSound, ma_attenuation_model attenuationModel);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_sound_get_attenuation_model(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_positioning(ma_sound_ptr pSound, ma_positioning positioning);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_sound_get_positioning(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_rolloff(ma_sound_ptr pSound, float rolloff);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_rolloff(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_min_gain(ma_sound_ptr pSound, float minGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_min_gain(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_max_gain(ma_sound_ptr pSound, float maxGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_max_gain(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_min_distance(ma_sound_ptr pSound, float minDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_min_distance(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_max_distance(ma_sound_ptr pSound, float maxDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_max_distance(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_cone(ma_sound_ptr pSound, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_get_cone(ma_sound_ptr pSound, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_doppler_factor(ma_sound_ptr pSound, float dopplerFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_doppler_factor(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_directional_attenuation_factor(ma_sound_ptr pSound, float directionalAttenuationFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_directional_attenuation_factor(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_in_pcm_frames(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_in_milliseconds(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_start_in_pcm_frames(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames, ma_uint64 absoluteGlobalTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_fade_start_in_milliseconds(ma_sound_ptr pSound, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds, ma_uint64 absoluteGlobalTimeInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_get_current_fade_volume(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_start_time_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_start_time_in_milliseconds(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_in_milliseconds(ma_sound_ptr pSound, ma_uint64 absoluteGlobalTimeInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_with_fade_in_pcm_frames(ma_sound_ptr pSound, ma_uint64 stopAbsoluteGlobalTimeInFrames, ma_uint64 fadeLengthInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_stop_time_with_fade_in_milliseconds(ma_sound_ptr pSound, ma_uint64 stopAbsoluteGlobalTimeInMilliseconds, ma_uint64 fadeLengthInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_playing(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_get_time_in_pcm_frames(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_get_time_in_milliseconds(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_set_looping(ma_sound_ptr pSound, ma_bool32 isLooping);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_is_looping(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_at_end(ma_sound_ptr pSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_seek_to_pcm_frame(ma_sound_ptr pSound, ma_uint64 frameIndex); /* Just a wrapper around ma_data_source_seek_to_pcm_frame(). */

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_seek_to_second(ma_sound_ptr pSound, float seekPointInSeconds); /* Abstraction to ma_sound_seek_to_pcm_frame() */

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_data_format(ma_sound_ptr pSound, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, Byte pChannelMap, size_t channelMapCap);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_cursor_in_pcm_frames(ma_sound_ptr pSound, out ma_uint64 pCursor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_length_in_pcm_frames(ma_sound_ptr pSound, out ma_uint64 pLength);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_cursor_in_seconds(ma_sound_ptr pSound, out float pCursor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_get_length_in_seconds(ma_sound_ptr pSound, out float pLength);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_set_end_callback(ma_sound_ptr pSound, IntPtr callback, IntPtr pUserData);

        public static ma_result ma_sound_set_end_callback(ma_sound_ptr pSound, ma_sound_end_proc callback, IntPtr pUserData)
        {
            return ma_sound_set_end_callback(pSound, MarshalHelper.GetFunctionPointerForDelegate(callback), pUserData);
        }

        // ma_sound_group
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_init(ma_engine_ptr pEngine, ma_sound_flags flags, ma_sound_group_ptr pParentGroup, ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_init_ex(ma_engine_ptr pEngine, ref ma_sound_group_config pConfig, ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_uninit(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_engine_ptr ma_sound_group_get_engine(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_start(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_sound_group_stop(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_volume(ma_sound_group_ptr pGroup, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_volume(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pan(ma_sound_group_ptr pGroup, float pan);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_pan(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pan_mode(ma_sound_group_ptr pGroup, ma_pan_mode panMode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_sound_group_get_pan_mode(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pitch(ma_sound_group_ptr pGroup, float pitch);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_pitch(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_spatialization_enabled(ma_sound_group_ptr pGroup, ma_bool32 enabled);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_group_is_spatialization_enabled(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_pinned_listener_index(ma_sound_group_ptr pGroup, ma_uint32 listenerIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_group_get_pinned_listener_index(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_sound_group_get_listener_index(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_direction_to_listener(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_position(ma_sound_group_ptr pGroup, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_position(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_direction(ma_sound_group_ptr pGroup, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_direction(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_velocity(ma_sound_group_ptr pGroup, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_sound_group_get_velocity(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_attenuation_model(ma_sound_group_ptr pGroup, ma_attenuation_model attenuationModel);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_sound_group_get_attenuation_model(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_positioning(ma_sound_group_ptr pGroup, ma_positioning positioning);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_sound_group_get_positioning(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_rolloff(ma_sound_group_ptr pGroup, float rolloff);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_rolloff(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_min_gain(ma_sound_group_ptr pGroup, float minGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_min_gain(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_max_gain(ma_sound_group_ptr pGroup, float maxGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_max_gain(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_min_distance(ma_sound_group_ptr pGroup, float minDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_min_distance(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_max_distance(ma_sound_group_ptr pGroup, float maxDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_max_distance(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_cone(ma_sound_group_ptr pGroup, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_get_cone(ma_sound_group_ptr pGroup, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_doppler_factor(ma_sound_group_ptr pGroup, float dopplerFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_doppler_factor(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_directional_attenuation_factor(ma_sound_group_ptr pGroup, float directionalAttenuationFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_directional_attenuation_factor(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_fade_in_pcm_frames(ma_sound_group_ptr pGroup, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_fade_in_milliseconds(ma_sound_group_ptr pGroup, float volumeBeg, float volumeEnd, ma_uint64 fadeLengthInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_sound_group_get_current_fade_volume(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_start_time_in_pcm_frames(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_start_time_in_milliseconds(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_stop_time_in_pcm_frames(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_sound_group_set_stop_time_in_milliseconds(ma_sound_group_ptr pGroup, ma_uint64 absoluteGlobalTimeInMilliseconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_sound_group_is_playing(ma_sound_group_ptr pGroup);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_sound_group_get_time_in_pcm_frames(ma_sound_group_ptr pGroup);

        // ma_procedural_data_source
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_procedural_data_source_config ma_procedural_data_source_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, IntPtr pProceduralSoundProc, IntPtr pUserData);

        public static ma_procedural_data_source_config ma_procedural_data_source_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, ma_procedural_data_source_proc pProceduralSoundProc, IntPtr pUserData)
        {
            return ma_procedural_data_source_config_init(format, channels, sampleRate, MarshalHelper.GetFunctionPointerForDelegate(pProceduralSoundProc), pUserData);
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_procedural_data_source_init(ref ma_procedural_data_source_config pConfig, ma_procedural_data_source_ptr pProceduralSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_procedural_data_source_uninit(ma_procedural_data_source_ptr pProceduralSound);

        // ma_spatializer_listener
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_spatializer_listener_config ma_spatializer_listener_config_init(ma_uint32 channelsOut);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_get_heap_size(ref ma_spatializer_listener_config pConfig, out size_t pHeapSizeInBytes);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_init_preallocated(ref ma_spatializer_listener_config pConfig, IntPtr pHeap, ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_listener_init(ref ma_spatializer_listener_config pConfig, IntPtr pAllocationCallbacks, ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_uninit(ma_spatializer_listener_ptr pListener, IntPtr pAllocationCallbacks);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_channel_ptr ma_spatializer_listener_get_channel_map(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_cone(ma_spatializer_listener_ptr pListener, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_get_cone(ma_spatializer_listener_ptr pListener, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_position(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_position(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_direction(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_direction(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_velocity(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_velocity(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_speed_of_sound(ma_spatializer_listener_ptr pListener, float speedOfSound);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_listener_get_speed_of_sound(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_world_up(ma_spatializer_listener_ptr pListener, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_listener_get_world_up(ma_spatializer_listener_ptr pListener);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_listener_set_enabled(ma_spatializer_listener_ptr pListener, ma_bool32 isEnabled);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_spatializer_listener_is_enabled(ma_spatializer_listener_ptr pListener);

        // ma_spatializer
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_spatializer_config ma_spatializer_config_init(ma_uint32 channelsIn, ma_uint32 channelsOut);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_get_heap_size(ref ma_spatializer_config pConfig, out size_t pHeapSizeInBytes);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_init_preallocated(ref ma_spatializer_config pConfig, IntPtr pHeap, ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_init(ref ma_spatializer_config pConfig, IntPtr pAllocationCallbacks, ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_uninit(ma_spatializer_ptr pSpatializer, IntPtr pAllocationCallbacks);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_process_pcm_frames(ma_spatializer_ptr pSpatializer, ma_spatializer_listener_ptr pListener, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_set_master_volume(ma_spatializer_ptr pSpatializer, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_spatializer_get_master_volume(ma_spatializer_ptr pSpatializer, out float pVolume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_spatializer_get_input_channels(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_spatializer_get_output_channels(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_attenuation_model(ma_spatializer_ptr pSpatializer, ma_attenuation_model attenuationModel);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_attenuation_model ma_spatializer_get_attenuation_model(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_positioning(ma_spatializer_ptr pSpatializer, ma_positioning positioning);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_positioning ma_spatializer_get_positioning(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_rolloff(ma_spatializer_ptr pSpatializer, float rolloff);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_rolloff(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_min_gain(ma_spatializer_ptr pSpatializer, float minGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_min_gain(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_max_gain(ma_spatializer_ptr pSpatializer, float maxGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_max_gain(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_min_distance(ma_spatializer_ptr pSpatializer, float minDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_min_distance(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_max_distance(ma_spatializer_ptr pSpatializer, float maxDistance);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_max_distance(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_cone(ma_spatializer_ptr pSpatializer, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_get_cone(ma_spatializer_ptr pSpatializer, out float pInnerAngleInRadians, out float pOuterAngleInRadians, out float pOuterGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_doppler_factor(ma_spatializer_ptr pSpatializer, float dopplerFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_doppler_factor(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_directional_attenuation_factor(ma_spatializer_ptr pSpatializer, float directionalAttenuationFactor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_spatializer_get_directional_attenuation_factor(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_position(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_position(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_direction(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_direction(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_set_velocity(ma_spatializer_ptr pSpatializer, float x, float y, float z);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_vec3f ma_spatializer_get_velocity(ma_spatializer_ptr pSpatializer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_spatializer_get_relative_position_and_direction(ma_spatializer_ptr pSpatializer, ma_spatializer_listener_ptr pListener, out ma_vec3f pRelativePos, out ma_vec3f pRelativeDir);

        // ma_decoder
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_decoder_config ma_decoder_config_init(ma_format outputFormat, ma_uint32 outputChannels, ma_uint32 outputSampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_decoder_config ma_decoder_config_init_default();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_decoder_init(IntPtr onRead, IntPtr onSeek, IntPtr pUserData, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        public static ma_result ma_decoder_init(ma_decoder_read_proc onRead, ma_decoder_seek_proc onSeek, IntPtr pUserData, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder)
        {
            return ma_decoder_init(MarshalHelper.GetFunctionPointerForDelegate(onRead), MarshalHelper.GetFunctionPointerForDelegate(onSeek), pUserData, ref pConfig, pDecoder);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_memory(IntPtr pData, size_t dataSize, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        public static ma_result ma_decoder_init_memory(IntPtr pData, size_t dataSize, ma_decoder_ptr pDecoder)
        {
            ma_decoder_config config = ma_decoder_config_init_default();
            return ma_decoder_init_memory(pData, dataSize, ref config, pDecoder);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_vfs(ma_vfs_ptr pVFS, string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_vfs_w(ma_vfs_ptr pVFS, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_file(string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        public static ma_result ma_decoder_init_file(string pFilePath, ma_decoder_ptr pDecoder)
        {
            ma_decoder_config config = ma_decoder_config_init_default();
            return ma_decoder_init_file(pFilePath, ref config, pDecoder);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_init_file_w([MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_decoder_config pConfig, ma_decoder_ptr pDecoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_uninit(ma_decoder_ptr pDecoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_decoder_read_pcm_frames(ma_decoder_ptr pDecoder, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint64* pFramesRead);

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

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_seek_to_pcm_frame(ma_decoder_ptr pDecoder, ma_uint64 frameIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_data_format(ma_decoder_ptr pDecoder, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_cursor_in_pcm_frames(ma_decoder_ptr pDecoder, out ma_uint64 pCursor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_length_in_pcm_frames(ma_decoder_ptr pDecoder, out ma_uint64 pLength);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decoder_get_available_frames(ma_decoder_ptr pDecoder, out ma_uint64 pAvailableFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_from_vfs(ma_vfs_ptr pVFS, string pFilePath, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_file(string pFilePath, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_decode_memory(IntPtr pData, size_t dataSize, ref ma_decoder_config pConfig, ref ma_uint64 pFrameCountOut, IntPtr ppPCMFramesOut);

        // ma_resource_manager
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_resource_manager_config ma_resource_manager_config_init();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_resource_manager_init(ref ma_resource_manager_config pConfig, ma_resource_manager_ptr pResourceManager);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_resource_manager_uninit(ma_resource_manager_ptr pResourceManager);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_log_ptr ma_resource_manager_get_log(ma_resource_manager_ptr pResourceManager);

        // ma_gainer
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_gainer_config ma_gainer_config_init(ma_uint32 channels, ma_uint32 smoothTimeInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_get_heap_size(ref ma_gainer_config pConfig, out size_t pHeapSizeInBytes);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_init_preallocated(ref ma_gainer_config pConfig, IntPtr pHeap, ma_gainer_ptr pGainer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_init(ref ma_gainer_config pConfig, IntPtr pAllocationCallbacks, ma_gainer_ptr pGainer);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_gainer_uninit(ma_gainer_ptr pGainer, IntPtr pAllocationCallbacks);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_process_pcm_frames(ma_gainer_ptr pGainer, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_gain(ma_gainer_ptr pGainer, float newGain);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_gains(ma_gainer_ptr pGainer, out float pNewGains);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_set_master_volume(ma_gainer_ptr pGainer, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_gainer_get_master_volume(ma_gainer_ptr pGainer, out float pVolume);

        // ma_libvorbis
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern ma_decoding_backend_vtable* ma_libvorbis_get_decoding_backend();

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

        public static ma_log_callback ma_log_callback_init(ma_log_callback_proc onLog, IntPtr pUserData)
        {
            return ma_log_callback_init(MarshalHelper.GetFunctionPointerForDelegate(onLog), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_log_init(ma_allocation_callbacks* pAllocationCallbacks, ma_log_ptr pLog);

        public static ma_result ma_log_init(ma_log_ptr pLog)
        {
            unsafe
            {
                return ma_log_init(null, pLog);
            }
        }

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

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_log_uninit(ma_log_ptr pLog);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_register_callback(ma_log_ptr pLog, ma_log_callback callback);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_unregister_callback(ma_log_ptr pLog, ma_log_callback callback);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_log_post(ma_log_ptr pLog, ma_uint32 level, string pMessage);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern string ma_log_level_to_string(ma_uint32 logLevel);

        // ma_node_graph
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_config ma_node_graph_config_init(ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_node_graph_init(ref ma_node_graph_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_node_graph_ptr pNodeGraph);

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

        public static ma_result ma_node_graph_init(ref ma_node_graph_config pConfig, ma_node_graph_ptr pNodeGraph)
        {
            unsafe
            {
                return ma_node_graph_init(ref pConfig, null, pNodeGraph);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_node_graph_uninit(ma_node_graph_ptr pNodeGraph, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_node_graph_uninit(ma_node_graph_ptr pNodeGraph)
        {
            unsafe
            {
                ma_node_graph_uninit(pNodeGraph, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_ptr ma_node_graph_get_endpoint(ma_node_graph_ptr pNodeGraph);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_graph_read_pcm_frames(ma_node_graph_ptr pNodeGraph, IntPtr pFramesOut, ma_uint64 frameCount, IntPtr pFramesRead);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_graph_get_channels(ma_node_graph_ptr pNodeGraph);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_graph_get_time(ma_node_graph_ptr pNodeGraph);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_graph_set_time(ma_node_graph_ptr pNodeGraph, ma_uint64 globalTime);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_node_graph_get_processing_size_in_frames(ma_node_graph_ptr pNodeGraph);

        // ma_node
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_config ma_node_config_init();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_get_heap_size(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, out size_t pHeapSizeInBytes);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_init_preallocated(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, IntPtr pHeap, ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_node_init(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_node_ptr pNode);

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

        public static ma_result ma_node_init(ma_node_graph_ptr pNodeGraph, ref ma_node_config pConfig, ma_node_ptr pNode)
        {
            unsafe
            {
                return ma_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_node_uninit(ma_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_node_uninit(ma_node_ptr pNode)
        {
            unsafe
            {
                ma_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_graph_ptr ma_node_get_node_graph(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_input_bus_count(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_output_bus_count(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_input_channels(ma_node_ptr pNode, ma_uint32 inputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint32 ma_node_get_output_channels(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_attach_output_bus(ma_node_ptr pNode, ma_uint32 outputBusIndex, ma_node_ptr pOtherNode, ma_uint32 otherNodeInputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_detach_output_bus(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_detach_all_output_buses(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_output_bus_volume(ma_node_ptr pNode, ma_uint32 outputBusIndex, float volume);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_node_get_output_bus_volume(ma_node_ptr pNode, ma_uint32 outputBusIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_state(ma_node_ptr pNode, ma_node_state state);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_state_time(ma_node_ptr pNode, ma_node_state state, ma_uint64 globalTime);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_get_state_time(ma_node_ptr pNode, ma_node_state state);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state_by_time(ma_node_ptr pNode, ma_uint64 globalTime);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_node_state ma_node_get_state_by_time_range(ma_node_ptr pNode, ma_uint64 globalTimeBeg, ma_uint64 globalTimeEnd);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_uint64 ma_node_get_time(ma_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_node_set_time(ma_node_ptr pNode, ma_uint64 localTime);

        // ma_effect_node
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_effect_node_config ma_effect_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, IntPtr onProcess, IntPtr pUserData);

        public static ma_effect_node_config ma_effect_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_effect_node_process_proc onProcess, IntPtr pUserData)
        {
            return ma_effect_node_config_init(channels, sampleRate, MarshalHelper.GetFunctionPointerForDelegate(onProcess), pUserData);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe ma_result ma_effect_node_init(ma_node_graph_ptr pNodeGraph, ref ma_effect_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_effect_node_ptr pEffectNode);

        public static ma_result ma_effect_node_init(ma_node_graph_ptr pNodeGraph, ref ma_effect_node_config pConfig, ma_effect_node_ptr pEffectNode)
        {
            unsafe
            {
                return ma_effect_node_init(pNodeGraph, ref pConfig, null, pEffectNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void ma_effect_node_uninit(ma_effect_node_ptr pEffectNode, ma_allocation_callbacks* pAllocationCallbacks);

        public static void ma_effect_node_uninit(ma_effect_node_ptr pEffectNode)
        {
            unsafe
            {
                ma_effect_node_uninit(pEffectNode, null);
            }
        }

        // ma_data_source
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_config ma_data_source_config_init();

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_init(ref ma_data_source_config pConfig, ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_uninit(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_read_pcm_frames(ma_data_source_ptr pDataSource, IntPtr pFramesOut, ma_uint64 frameCount, IntPtr pFramesRead);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 frameCount, out ma_uint64 pFramesSeeked);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_to_pcm_frame(ma_data_source_ptr pDataSource, ma_uint64 frameIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_seconds(ma_data_source_ptr pDataSource, float secondCount, out float pSecondsSeeked);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_seek_to_second(ma_data_source_ptr pDataSource, float seekPointInSeconds);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_data_format(ma_data_source_ptr pDataSource, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_cursor_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pCursor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_length_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pLength);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_cursor_in_seconds(ma_data_source_ptr pDataSource, out float pCursor);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_get_length_in_seconds(ma_data_source_ptr pDataSource, out float pLength);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_looping(ma_data_source_ptr pDataSource, ma_bool32 isLooping);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_data_source_is_looping(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_range_in_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 rangeBegInFrames, ma_uint64 rangeEndInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_get_range_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pRangeBegInFrames, out ma_uint64 pRangeEndInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_loop_point_in_pcm_frames(ma_data_source_ptr pDataSource, ma_uint64 loopBegInFrames, ma_uint64 loopEndInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_data_source_get_loop_point_in_pcm_frames(ma_data_source_ptr pDataSource, out ma_uint64 pLoopBegInFrames, out ma_uint64 pLoopEndInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_current(ma_data_source_ptr pDataSource, ma_data_source_ptr pCurrentDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_data_source_get_current(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_next(ma_data_source_ptr pDataSource, ma_data_source_ptr pNextDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_ptr ma_data_source_get_next(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_set_next_callback(ma_data_source_ptr pDataSource, ma_data_source_get_next_proc onGetNext);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_get_next_proc ma_data_source_get_next_callback(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_data_source_node_config ma_data_source_node_config_init(ma_data_source_ptr pDataSource);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_data_source_node_init(ma_node_graph_ptr pNodeGraph, ref ma_data_source_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_data_source_node_ptr pDataSourceNode);

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

        public static ma_result ma_data_source_node_init(ma_node_graph_ptr pNodeGraph, ref ma_data_source_node_config pConfig, ma_data_source_node_ptr pDataSourceNode)
        {
            unsafe
            {
                return ma_data_source_node_init(pNodeGraph, ref pConfig, null, pDataSourceNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_data_source_node_uninit(ma_data_source_node_ptr pDataSourceNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static unsafe void ma_data_source_node_uninit(ma_data_source_node_ptr pDataSourceNode)
        {
            unsafe
            {
                ma_data_source_node_uninit(pDataSourceNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_data_source_node_set_looping(ma_data_source_node_ptr pDataSourceNode, ma_bool32 isLooping);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_data_source_node_is_looping(ma_data_source_node_ptr pDataSourceNode);

        // ma_fader
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_fader_config ma_fader_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_fader_init(ref ma_fader_config pConfig, ma_fader_ptr pFader);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_fader_process_pcm_frames(ma_fader_ptr pFader, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_get_data_format(ma_fader_ptr pFader, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_set_fade(ma_fader_ptr pFader, float volumeBeg, float volumeEnd, ma_uint64 lengthInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_fader_set_fade_ex(ma_fader_ptr pFader, float volumeBeg, float volumeEnd, ma_uint64 lengthInFrames, ma_int64 startOffsetInFrames);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_fader_get_current_volume(ma_fader_ptr pFader);

        // ma_panner
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_panner_config ma_panner_config_init(ma_format format, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_panner_init(ref ma_panner_config pConfig, ma_panner_ptr pPanner);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_panner_process_pcm_frames(ma_panner_ptr pPanner, IntPtr pFramesOut, IntPtr pFramesIn, ma_uint64 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_panner_set_mode(ma_panner_ptr pPanner, ma_pan_mode mode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pan_mode ma_panner_get_mode(ma_panner_ptr pPanner);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_panner_set_pan(ma_panner_ptr pPanner, float pan);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_panner_get_pan(ma_panner_ptr pPanner);

        // ma_channel_map
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_channel ma_channel_map_get_channel(ma_channel_ptr pChannelMap, ma_uint32 channelCount, ma_uint32 channelIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_init_blank(ma_channel_ptr pChannelMap, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_init_standard(ma_standard_channel_map standardChannelMap, ma_channel_ptr pChannelMap, size_t channelMapCap, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_copy(ma_channel_ptr pOut, ma_channel_ptr pIn, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_channel_map_copy_or_default(ma_channel_ptr pOut, size_t channelMapCapOut, ma_channel_ptr pIn, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_valid(ma_channel_ptr pChannelMap, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_equal(ma_channel_ptr pChannelMapA, ma_channel_ptr pChannelMapB, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_is_blank(ma_channel_ptr pChannelMap, ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_contains_channel_position(ma_uint32 channels, ma_channel_ptr pChannelMap, ma_channel channelPosition);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bool32 ma_channel_map_find_channel_position(ma_uint32 channels, ma_channel_ptr pChannelMap, ma_channel channelPosition, out ma_uint32 pChannelIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern size_t ma_channel_map_to_string(ma_channel_ptr pChannelMap, ma_uint32 channels, IntPtr pBufferOut, size_t bufferCap);

        // ma_encoder
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_encoder_config ma_encoder_config_init(ma_encoding_format encodingFormat, ma_format format, ma_uint32 channels, ma_uint32 sampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern ma_result ma_encoder_init(IntPtr onWrite, IntPtr onSeek, IntPtr pUserData, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        public static ma_result ma_encoder_init(ma_encoder_write_proc onWrite, ma_encoder_seek_proc onSeek, IntPtr pUserData, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder)
        {
            return ma_encoder_init(MarshalHelper.GetFunctionPointerForDelegate(onWrite), MarshalHelper.GetFunctionPointerForDelegate(onWrite), pUserData, ref pConfig, pEncoder);
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_vfs(ma_vfs pVFS, string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_vfs_w(ma_vfs pVFS, [MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_file(string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_init_file_w([MarshalAs(UnmanagedType.LPWStr)] string pFilePath, ref ma_encoder_config pConfig, ma_encoder_ptr pEncoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_encoder_uninit(ma_encoder_ptr pEncoder);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_encoder_write_pcm_frames(ma_encoder_ptr pEncoder, IntPtr pFramesIn, ma_uint64 frameCount, out ma_uint64 pFramesWritten);

        // ma_biquad/filters general
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_biquad_config ma_biquad_config_init(ma_format format, UInt32 channels, double b0, double b1, double b2, double a0, double a1, double a2);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_get_heap_size(ref ma_biquad_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_init_preallocated(ref ma_biquad_config pConfig, IntPtr pHeap, ma_biquad_ptr pBQ);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_biquad_init(ref ma_biquad_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_biquad_ptr pBQ);

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

        public static ma_result ma_biquad_init(ref ma_biquad_config pConfig, ma_biquad_ptr pBQ)
        {
            unsafe
            {
                return ma_biquad_init(ref pConfig, null, pBQ);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_biquad_uninit(ma_biquad_ptr pBQ, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_biquad_uninit(ma_biquad_ptr pBQ)
        {
            unsafe
            {
                ma_biquad_uninit(pBQ, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_reinit(ref ma_biquad_config pConfig, ma_biquad_ptr pBQ);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_clear_cache(ma_biquad_ptr pBQ);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_biquad_process_pcm_frames(ma_biquad_ptr pBQ, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_biquad_get_latency(ma_biquad_ptr pBQ);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf1_config ma_lpf1_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf2_config ma_lpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_get_heap_size(ref ma_lpf1_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_init_preallocated(ref ma_lpf1_config pConfig, IntPtr pHeap, ma_lpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf1_init(ref ma_lpf1_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf1_ptr pLPF);

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

        public static ma_result ma_lpf1_init(ref ma_lpf1_config pConfig, ma_lpf1_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf1_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf1_uninit(ma_lpf1_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_lpf1_uninit(ma_lpf1_ptr pLPF)
        {
            unsafe
            {
                ma_lpf1_uninit(pLPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_reinit(ref ma_lpf1_config pConfig, ma_lpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_clear_cache(ma_lpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf1_process_pcm_frames(ma_lpf1_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf1_get_latency(ma_lpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_get_heap_size(ref ma_lpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_init_preallocated(ref ma_lpf2_config pConfig, IntPtr pHeap, ma_lpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf2_init(ref ma_lpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf2_ptr pLPF);

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

        public static ma_result ma_lpf2_init(ref ma_lpf2_config pConfig, ma_lpf2_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf2_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf2_uninit(ma_lpf2_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_lpf2_uninit(ma_lpf2_ptr pLPF)
        {
            unsafe
            {
                ma_lpf2_uninit(pLPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_reinit(ref ma_lpf2_config pConfig, ma_lpf2_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_clear_cache(ma_lpf2_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf2_process_pcm_frames(ma_lpf2_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf2_get_latency(ma_lpf2_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf_config ma_lpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_get_heap_size(ref ma_lpf_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_init_preallocated(ref ma_lpf_config pConfig, IntPtr pHeap, ma_lpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf_init(ref ma_lpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf_ptr pLPF);

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

        public static ma_result ma_lpf_init(ref ma_lpf_config pConfig, ma_lpf_ptr pLPF)
        {
            unsafe
            {
                return ma_lpf_init(ref pConfig, null, pLPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf_uninit(ma_lpf_ptr pLPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_lpf_uninit(ma_lpf_ptr pLPF)
        {
            unsafe
            {
                ma_lpf_uninit(pLPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_reinit(ref ma_lpf_config pConfig, ma_lpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_clear_cache(ma_lpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_process_pcm_frames(ma_lpf_ptr pLPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_lpf_get_latency(ma_lpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf1_config ma_hpf1_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf2_config ma_hpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_get_heap_size(ref ma_hpf1_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_init_preallocated(ref ma_hpf1_config pConfig, IntPtr pHeap, ma_hpf1_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf1_init(ref ma_hpf1_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf1_ptr pHPF);

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

        public static ma_result ma_hpf1_init(ref ma_hpf1_config pConfig, ma_hpf1_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf1_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf1_uninit(ma_hpf1_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hpf1_uninit(ma_hpf1_ptr pHPF)
        {
            unsafe
            {
                ma_hpf1_uninit(pHPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_reinit(ref ma_hpf1_config pConfig, ma_hpf1_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf1_process_pcm_frames(ma_hpf1_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf1_get_latency(ma_hpf1_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_get_heap_size(ref ma_hpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_init_preallocated(ref ma_hpf2_config pConfig, IntPtr pHeap, ma_hpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf2_init(ref ma_hpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf2_ptr pHPF);

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

        public static ma_result ma_hpf2_init(ref ma_hpf2_config pConfig, ma_hpf2_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf2_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf2_uninit(ma_hpf2_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hpf2_uninit(ma_hpf2_ptr pHPF)
        {
            unsafe
            {
                ma_hpf2_uninit(pHPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_reinit(ref ma_hpf2_config pConfig, ma_hpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf2_process_pcm_frames(ma_hpf2_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf2_get_latency(ma_hpf2_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf_config ma_hpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_get_heap_size(ref ma_hpf_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_init_preallocated(ref ma_hpf_config pConfig, IntPtr pHeap, ma_hpf_ptr pLPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf_init(ref ma_hpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf_ptr pHPF);

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

        public static ma_result ma_hpf_init(ref ma_hpf_config pConfig, ma_hpf_ptr pHPF)
        {
            unsafe
            {
                return ma_hpf_init(ref pConfig, null, pHPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf_uninit(ma_hpf_ptr pHPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hpf_uninit(ma_hpf_ptr pHPF)
        {
            unsafe
            {
                ma_hpf_uninit(pHPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_reinit(ref ma_hpf_config pConfig, ma_hpf_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_process_pcm_frames(ma_hpf_ptr pHPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hpf_get_latency(ma_hpf_ptr pHPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf2_config ma_bpf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, double q);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_get_heap_size(ref ma_bpf2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_init_preallocated(ref ma_bpf2_config pConfig, IntPtr pHeap, ma_bpf2_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf2_init(ref ma_bpf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf2_ptr pBPF);

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

        public static ma_result ma_bpf2_init(ref ma_bpf2_config pConfig, ma_bpf2_ptr pBPF)
        {
            unsafe
            {
                return ma_bpf2_init(ref pConfig, null, pBPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf2_uninit(ma_bpf2_ptr pBPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_bpf2_uninit(ma_bpf2_ptr pBPF)
        {
            unsafe
            {
                ma_bpf2_uninit(pBPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_reinit(ref ma_bpf2_config pConfig, ma_bpf2_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf2_process_pcm_frames(ma_bpf2_ptr pBPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_bpf2_get_latency(ma_bpf2_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf_config ma_bpf_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double cutoffFrequency, UInt32 order);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_get_heap_size(ref ma_bpf_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_init_preallocated(ref ma_bpf_config pConfig, IntPtr pHeap, ma_bpf_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf_init(ref ma_bpf_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf_ptr pBPF);

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

        public static ma_result ma_bpf_init(ref ma_bpf_config pConfig, ma_bpf_ptr pBPF)
        {
            unsafe
            {
                return ma_bpf_init(ref pConfig, null, pBPF);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf_uninit(ma_bpf_ptr pBPF, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_bpf_uninit(ma_bpf_ptr pBPF)
        {
            unsafe
            {
                ma_bpf_uninit(pBPF, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_reinit(ref ma_bpf_config pConfig, ma_bpf_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_process_pcm_frames(ma_bpf_ptr pBPF, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_bpf_get_latency(ma_bpf_ptr pBPF);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_notch2_config ma_notch2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double q, double frequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_get_heap_size(ref ma_notch2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe ma_result ma_notch2_init_preallocated(ref ma_notch2_config pConfig, IntPtr pHeap, ma_notch2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_notch2_init(ref ma_notch2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch2_ptr pFilter);

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

        public static ma_result ma_notch2_init(ref ma_notch2_config pConfig, ma_notch2_ptr pFilter)
        {
            unsafe
            {
                return ma_notch2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_notch2_uninit(ma_notch2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_notch2_uninit(ma_notch2_ptr pFilter)
        {
            unsafe
            {
                ma_notch2_uninit(pFilter, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_reinit(ref ma_notch2_config pConfig, ma_notch2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch2_process_pcm_frames(ma_notch2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_notch2_get_latency(ma_notch2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_peak2_config ma_peak2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double q, double frequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_get_heap_size(ref ma_peak2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_init_preallocated(ref ma_peak2_config pConfig, IntPtr pHeap, ma_peak2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_peak2_init(ref ma_peak2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak2_ptr pFilter);

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

        public static ma_result ma_peak2_init(ref ma_peak2_config pConfig, ma_peak2_ptr pFilter)
        {
            unsafe
            {
                return ma_peak2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_peak2_uninit(ma_peak2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

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
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_reinit(ref ma_peak2_config pConfig, ma_peak2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak2_process_pcm_frames(ma_peak2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_peak2_get_latency(ma_peak2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_loshelf2_config ma_loshelf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double shelfSlope, double frequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_get_heap_size(ref ma_loshelf2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_init_preallocated(ref ma_loshelf2_config pConfig, IntPtr pHeap, ma_loshelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_loshelf2_init(ref ma_loshelf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf2_ptr pFilter);

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

        public static ma_result ma_loshelf2_init(ref ma_loshelf2_config pConfig, ma_loshelf2_ptr pFilter)
        {
            unsafe
            {
                return ma_loshelf2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_loshelf2_uninit(ma_loshelf2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_loshelf2_uninit(ma_loshelf2_ptr pFilter)
        {
            unsafe
            {
                ma_loshelf2_uninit(pFilter, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_reinit(ref ma_loshelf2_config pConfig, ma_loshelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf2_process_pcm_frames(ma_loshelf2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_loshelf2_get_latency(ma_loshelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hishelf2_config ma_hishelf2_config_init(ma_format format, UInt32 channels, UInt32 sampleRate, double gainDB, double shelfSlope, double frequency);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_get_heap_size(ref ma_hishelf2_config pConfig, out size_t pHeapSizeInBytes);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_init_preallocated(ref ma_hishelf2_config pConfig, IntPtr pHeap, ma_hishelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hishelf2_init(ref ma_hishelf2_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf2_ptr pFilter);

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

        public static ma_result ma_hishelf2_init(ref ma_hishelf2_config pConfig, ma_hishelf2_ptr pFilter)
        {
            unsafe
            {
                return ma_hishelf2_init(ref pConfig, null, pFilter);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hishelf2_uninit(ma_hishelf2_ptr pFilter, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hishelf2_uninit(ma_hishelf2_ptr pFilter)
        {
            unsafe
            {
                ma_hishelf2_uninit(pFilter, null);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_reinit(ref ma_hishelf2_config pConfig, ma_hishelf2_ptr pFilter);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf2_process_pcm_frames(ma_hishelf2_ptr pFilter, IntPtr pFramesOut, IntPtr pFramesIn, UInt64 frameCount);
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 ma_hishelf2_get_latency(ma_hishelf2_ptr pFilter);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_lpf_node_config ma_lpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_lpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_lpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf_node_ptr pNode);

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

        public static ma_result ma_lpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_lpf_node_config pConfig, ma_lpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_lpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_lpf_node_reinit(ref ma_lpf_config pConfig, ma_lpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_lpf_node_uninit(ma_lpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_lpf_node_uninit(ma_lpf_node_ptr pNode)
        {
            unsafe
            {
                ma_lpf_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hpf_node_config ma_hpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf_node_ptr pNode);

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

        public static ma_result ma_hpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hpf_node_config pConfig, ma_hpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_hpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hpf_node_reinit(ref ma_hpf_config pConfig, ma_hpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hpf_node_uninit(ma_hpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hpf_node_uninit(ma_hpf_node_ptr pNode)
        {
            unsafe
            {
                ma_hpf_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_bpf_node_config ma_bpf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double cutoffFrequency, ma_uint32 order);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_bpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_bpf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf_node_ptr pNode);

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

        public static ma_result ma_bpf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_bpf_node_config pConfig, ma_bpf_node_ptr pNode)
        {
            unsafe
            {
                return ma_bpf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_bpf_node_reinit(ref ma_bpf_config pConfig, ma_bpf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_bpf_node_uninit(ma_bpf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_bpf_node_uninit(ma_bpf_node_ptr pNode)
        {
            unsafe
            {
                ma_bpf_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_notch_node_config ma_notch_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_notch_node_init(ma_node_graph_ptr pNodeGraph, ref ma_notch_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch_node_ptr pNode);

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

        public static ma_result ma_notch_node_init(ma_node_graph_ptr pNodeGraph, ref ma_notch_node_config pConfig, ma_notch_node_ptr pNode)
        {
            unsafe
            {
                return ma_notch_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_notch_node_reinit(ref ma_notch_config pConfig, ma_notch_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_notch_node_uninit(ma_notch_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_notch_node_uninit(ma_notch_node_ptr pNode)
        {
            unsafe
            {
                ma_notch_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_peak_node_config ma_peak_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_peak_node_init(ma_node_graph_ptr pNodeGraph, ref ma_peak_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak_node_ptr pNode);

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

        public static ma_result ma_peak_node_init(ma_node_graph_ptr pNodeGraph, ref ma_peak_node_config pConfig, ma_peak_node_ptr pNode)
        {
            unsafe
            {
                return ma_peak_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_peak_node_reinit(ref ma_peak_config pConfig, ma_peak_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_peak_node_uninit(ma_peak_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_peak_node_uninit(ma_peak_node_ptr pNode)
        {
            unsafe
            {
                ma_peak_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_loshelf_node_config ma_loshelf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_loshelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_loshelf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf_node_ptr pNode);

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

        public static ma_result ma_loshelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_loshelf_node_config pConfig, ma_loshelf_node_ptr pNode)
        {
            unsafe
            {
                return ma_loshelf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_loshelf_node_reinit(ref ma_loshelf_config pConfig, ma_loshelf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_loshelf_node_uninit(ma_loshelf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_loshelf_node_uninit(ma_loshelf_node_ptr pNode)
        {
            unsafe
            {
                ma_loshelf_node_uninit(pNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_hishelf_node_config ma_hishelf_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, double gainDB, double q, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_hishelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hishelf_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf_node_ptr pNode);

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

        public static ma_result ma_hishelf_node_init(ma_node_graph_ptr pNodeGraph, ref ma_hishelf_node_config pConfig, ma_hishelf_node_ptr pNode)
        {
            unsafe
            {
                return ma_hishelf_node_init(pNodeGraph, ref pConfig, null, pNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_hishelf_node_reinit(ref ma_hishelf_config pConfig, ma_hishelf_node_ptr pNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_hishelf_node_uninit(ma_hishelf_node_ptr pNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_hishelf_node_uninit(ma_hishelf_node_ptr pNode)
        {
            unsafe
            {
                ma_hishelf_node_uninit(pNode, null);
            }
        }

        //ma_delay
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_delay_config ma_delay_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_uint32 delayInFrames, float decay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_delay_init(ref ma_delay_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay_ptr pDelay);

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

        public static ma_result ma_delay_init(ref ma_delay_config pConfig, ma_delay_ptr pDelay)
        {
            unsafe
            {
                return ma_delay_init(ref pConfig, null, pDelay);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_delay_uninit(ma_delay_ptr pDelay, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_delay_uninit(ma_delay_ptr pDelay)
        {
            unsafe
            {
                ma_delay_uninit(pDelay, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_delay_process_pcm_frames(ma_delay_ptr pDelay, IntPtr pFramesOut, IntPtr pFramesIn, UInt32 frameCount);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_wet(ma_delay_ptr pDelay, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_wet(ma_delay_ptr pDelay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_dry(ma_delay_ptr pDelay, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_dry(ma_delay_ptr pDelay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_set_decay(ma_delay_ptr pDelay, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_get_decay(ma_delay_ptr pDelay);

        //ma_delay_node
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_delay_node_config ma_delay_node_config_init(ma_uint32 channels, ma_uint32 sampleRate, ma_uint32 delayInFrames, float decay);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_delay_node_init(ma_node_graph_ptr pNodeGraph, ref ma_delay_node_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay_node_ptr pDelayNode);

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

        public static ma_result ma_delay_node_init(ma_node_graph_ptr pNodeGraph, ref ma_delay_node_config pConfig, ma_delay_node_ptr pDelayNode)
        {
            unsafe
            {
                return ma_delay_node_init(pNodeGraph, ref pConfig, null, pDelayNode);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_delay_node_uninit(ma_delay_node_ptr pDelayNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_delay_node_uninit(ma_delay_node_ptr pDelayNode)
        {
            unsafe
            {
                ma_delay_node_uninit(pDelayNode, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_wet(ma_delay_node_ptr pDelayNode, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_wet(ma_delay_node_ptr pDelayNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_dry(ma_delay_node_ptr pDelayNode, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_dry(ma_delay_node_ptr pDelayNode);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_delay_node_set_decay(ma_delay_node_ptr pDelayNode, float value);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ma_delay_node_get_decay(ma_delay_node_ptr pDelayNode);

        //ma_splitter_node
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_splitter_node_config ma_splitter_node_config_init(ma_uint32 channels);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_splitter_node_init(ma_node_graph_ptr pNodeGraph, ref ma_splitter_node_config pConfig, ma_allocation_callbacks *pAllocationCallbacks, ma_splitter_node_ptr pSplitterNode);

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

        public static ma_result ma_splitter_node_init(ma_node_graph_ptr pNodeGraph, ref ma_splitter_node_config pConfig, ma_splitter_node_ptr pSplitterNode)
        {
            unsafe
            {
                return ma_splitter_node_init(pNodeGraph, ref pConfig, null, pSplitterNode);
            }
        }
        
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_splitter_node_uninit(ma_splitter_node_ptr pSplitterNode, ma_allocation_callbacks* pAllocationCallbacks);

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

        public static void ma_splitter_node_uninit(ma_splitter_node_ptr pSplitterNode)
        {
            unsafe
            {
                ma_splitter_node_uninit(pSplitterNode, null);
            }
        }

        //ma_waveform
        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_waveform_config ma_waveform_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, ma_waveform_type type, double amplitude, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_init(ref ma_waveform_config pConfig, ma_waveform_ptr pWaveform);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_waveform_uninit(ma_waveform_ptr pWaveform);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_read_pcm_frames(ma_waveform_ptr pWaveform, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_seek_to_pcm_frame(ma_waveform_ptr pWaveform, ma_uint64 frameIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_amplitude(ma_waveform_ptr pWaveform, double amplitude);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_frequency(ma_waveform_ptr pWaveform, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_type(ma_waveform_ptr pWaveform, ma_waveform_type type);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_waveform_set_sample_rate(ma_waveform_ptr pWaveform, ma_uint32 sampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_pulsewave_config ma_pulsewave_config_init(ma_format format, ma_uint32 channels, ma_uint32 sampleRate, double dutyCycle, double amplitude, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_init(ref ma_pulsewave_config pConfig, ma_pulsewave_ptr pWaveform);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ma_pulsewave_uninit(ma_pulsewave_ptr pWaveform);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_read_pcm_frames(ma_pulsewave_ptr pWaveform, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_seek_to_pcm_frame(ma_pulsewave_ptr pWaveform, ma_uint64 frameIndex);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_amplitude(ma_pulsewave_ptr pWaveform, double amplitude);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_frequency(ma_pulsewave_ptr pWaveform, double frequency);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_sample_rate(ma_pulsewave_ptr pWaveform, ma_uint32 sampleRate);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_pulsewave_set_duty_cycle(ma_pulsewave_ptr pWaveform, double dutyCycle);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_noise_config ma_noise_config_init(ma_format format, ma_uint32 channels, ma_noise_type type, ma_int32 seed, double amplitude);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_get_heap_size(ref ma_noise_config pConfig, out size_t pHeapSizeInBytes);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_init_preallocated(ref ma_noise_config pConfig, IntPtr pHeap, ma_noise_ptr pNoise);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe ma_result ma_noise_init(ref ma_noise_config pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_noise_ptr pNoise);

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

        public static ma_result ma_noise_init(ref ma_noise_config pConfig, ma_noise_ptr pNoise)
        {
            unsafe
            {
                return ma_noise_init(ref pConfig, null, pNoise);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void ma_noise_uninit(ma_noise_ptr pNoise, ma_allocation_callbacks* pAllocationCallbacks);

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
        
        public static void ma_noise_uninit(ma_noise_ptr pNoise)
        {
            unsafe
            {
                ma_noise_uninit(pNoise, null);
            }
        }

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_read_pcm_frames(ma_noise_ptr pNoise, IntPtr pFramesOut, ma_uint64 frameCount, out ma_uint64 pFramesRead);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_set_amplitude(ma_noise_ptr pNoise, double amplitude);

        [DllImport(LIB_MINIAUDIO_EX, CallingConvention = CallingConvention.Cdecl)]
        public static extern ma_result ma_noise_set_seed(ma_noise_ptr pNoise, ma_int32 seed);

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

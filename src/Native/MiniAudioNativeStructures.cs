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

    [StructLayout(LayoutKind.Sequential)]
    public struct size_t
    {
        private UIntPtr value;

        public size_t(UIntPtr value)
        {
            this.value = value;
        }

        public static implicit operator size_t(UIntPtr value)
        {
            return new size_t(value);
        }

        public static implicit operator UIntPtr(size_t size)
        {
            return size.value;
        }

        public static implicit operator size_t(int value)
        {
            return new size_t((UIntPtr)(uint)value);
        }

        public static implicit operator size_t(uint value)
        {
            return new size_t((UIntPtr)value);
        }

        public static implicit operator size_t(long value)
        {
            return new size_t((UIntPtr)(ulong)value);
        }

        public static implicit operator size_t(ulong value)
        {
            return new size_t((UIntPtr)value);
        }

        public static size_t operator +(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() + b.ToUInt64()));
        }

        public static size_t operator -(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() - b.ToUInt64()));
        }

        public static size_t operator *(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b.ToUInt64()));
        }

        public static size_t operator /(size_t a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b.ToUInt64()));
        }

        public static bool operator ==(size_t a, size_t b)
        {
            return a.value == b.value;
        }

        public static bool operator !=(size_t a, size_t b)
        {
            return a.value != b.value;
        }

        public static bool operator <(size_t a, size_t b)
        {
            return a.ToUInt64() < b.ToUInt64();
        }

        public static bool operator >(size_t a, size_t b)
        {
            return a.ToUInt64() > b.ToUInt64();
        }

        public static bool operator <=(size_t a, size_t b)
        {
            return a.ToUInt64() <= b.ToUInt64();
        }

        public static bool operator >=(size_t a, size_t b)
        {
            return a.ToUInt64() >= b.ToUInt64();
        }

        public static size_t operator +(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() + b));
        }

        public static size_t operator -(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() - b));
        }

        public static size_t operator *(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b));
        }

        public static size_t operator /(size_t a, ulong b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b));
        }

        public static size_t operator +(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a + b.ToUInt64()));
        }

        public static size_t operator -(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a - b.ToUInt64()));
        }

        public static size_t operator *(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a * b.ToUInt64()));
        }

        public static size_t operator /(ulong a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a / b.ToUInt64()));
        }

        public static size_t operator +(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() + b));
        }

        public static size_t operator -(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() - b));
        }

        public static size_t operator *(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b));
        }

        public static size_t operator /(size_t a, uint b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b));
        }

        public static size_t operator +(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a + b.ToUInt64()));
        }

        public static size_t operator -(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a - b.ToUInt64()));
        }

        public static size_t operator *(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a * b.ToUInt64()));
        }

        public static size_t operator /(uint a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a / b.ToUInt64()));
        }

        public ulong ToUInt64()
        {
            return value.ToUInt64();
        }

        public uint ToUInt32()
        {
            return value.ToUInt32();
        }

        public override bool Equals(object obj)
        {
            if (obj is size_t)
            {
                return this == (size_t)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    // ma_structures
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_allocation_callbacks
    {
        public IntPtr pUserData;
        public IntPtr onMalloc;
        public IntPtr onRealloc;
        public IntPtr onFree;

        public void SetMallocProc(ma_allocation_callbacks_malloc_proc callback)
        {
            onMalloc = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetReallocProc(ma_allocation_callbacks_realloc_proc callback)
        {
            onRealloc = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetFreeProc(ma_allocation_callbacks_free_proc callback)
        {
            onFree = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_descriptor
    {
        public ma_device_id_ptr pDeviceID;
        public ma_share_mode shareMode;
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        private fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        public ma_uint32 periodSizeInFrames;
        public ma_uint32 periodSizeInMilliseconds;
        public ma_uint32 periodCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_vec3f
    {
        public float x;
        public float y;
        public float z;

        public ma_vec3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "(" + x + ", " +  y + ", " + z + ")";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_atomic_vec3f
    {
        public ma_vec3f v;
        public ma_spinlock lck;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_bool32
    {
        [FieldOffset(0)]
        public UInt32 value;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_uint32
    {
        [FieldOffset(0)]
        public UInt32 value;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_int32
    {
        [FieldOffset(0)]
        public Int32 value;
    }

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ma_atomic_uint64
    {
        [FieldOffset(0)]
        public UInt64 value;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_float
    {
        [FieldOffset(0)]
        public float value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_panner_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_pan_mode mode;
        public float pan;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_panner
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_pan_mode mode;
        public float pan;  /* -1..1 where 0 is no pan, -1 is left side, +1 is right side. Defaults to 0. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_node_config
    {
        public ma_engine_ptr pEngine;
        public ma_engine_node_type type;
        public ma_uint32 channelsIn;
        public ma_uint32 channelsOut;
        public ma_uint32 sampleRate;               /* Only used when the type is set to ma_engine_node_type_sound. */
        public ma_uint32 volumeSmoothTimeInPCMFrames;  /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        public ma_mono_expansion_mode monoExpansionMode;
        public ma_bool8 isPitchDisabled;           /* Pitching can be explicitly disabled with MA_SOUND_FLAG_NO_PITCH to optimize processing. */
        public ma_bool8 isSpatializationDisabled;  /* Spatialization can be explicitly disabled with MA_SOUND_FLAG_NO_SPATIALIZATION. */
        public ma_uint8 pinnedListenerIndex;       /* The index of the listener this node should always use for spatialization. If set to MA_LISTENER_INDEX_CLOSEST the engine will use the closest listener. */
        public ma_resampler_config resampling;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_node
    {
        public ma_node_base baseNode;                              /* Must be the first member for compatibility with the ma_node API. */
        public ma_engine_ptr pEngine;                                 /* A pointer to the engine. Set based on the value from the config. */
        public ma_uint32 sampleRate;                               /* The sample rate of the input data. For sounds backed by a data source, this will be the data source's sample rate. Otherwise it'll be the engine's sample rate. */
        public ma_uint32 volumeSmoothTimeInPCMFrames;
        public ma_mono_expansion_mode monoExpansionMode;
        public ma_fader fader;
        public ma_resampler resampler;                      /* For pitch shift. */
        public ma_spatializer spatializer;
        public ma_panner panner;
        public ma_gainer volumeGainer;                             /* This will only be used if volumeSmoothTimeInPCMFrames is > 0. */
        public float volume;                             /* Defaults to 1. */
        public float pitch;
        public float oldPitch;                                     /* For determining whether or not the resampler needs to be updated to reflect the new pitch. The resampler will be updated on the mixing thread. */
        public float oldDopplerPitch;                              /* For determining whether or not the resampler needs to be updated to take a new doppler pitch into account. */
        public ma_bool32 isPitchDisabled;            /* When set to true, pitching will be disabled which will allow the resampler to be bypassed to save some computation. */
        public ma_bool32 isSpatializationDisabled;   /* Set to false by default. When set to false, will not have spatialisation applied. */
        public ma_uint32 pinnedListenerIndex;        /* The index of the listener this node should always use for spatialization. If set to MA_LISTENER_INDEX_CLOSEST the engine will use the closest listener. */
        /* When setting a fade, it's not done immediately in ma_sound_set_fade(). It's deferred to the audio thread which means we need to store the settings here. */
        public fade_settings fadeSettings;
        /* Memory management. */
        public ma_bool8 _ownsHeap;
        public IntPtr _pHeap;

        [StructLayout(LayoutKind.Sequential)]
        public struct fade_settings
        {
            public float volumeBeg;
            public float volumeEnd;
            public ma_uint64 fadeLengthInFrames;            /* <-- Defaults to (~(ma_uint64)0) which is used to indicate that no fade should be applied. */
            public ma_uint64 absoluteGlobalTimeInFrames;    /* <-- The time to start the fade. */
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_config
    {
        public ma_resource_manager_ptr pResourceManager;          /* Can be null in which case a resource manager will be created for you. */
        public ma_context_ptr pContext;
        public ma_device_ptr pDevice;                             /* If set, the caller is responsible for calling ma_engine_data_callback() in the device's data callback. */
        public ma_device_id_ptr pPlaybackDeviceID;                /* The ID of the playback device to use with the default listener. */
        public IntPtr dataCallback;               /* Can be null. Can be used to provide a custom device data callback. */
        public IntPtr notificationCallback;
        public ma_log_ptr pLog;                                   /* When set to NULL, will use the context's log. */
        public ma_uint32 listenerCount;                        /* Must be between 1 and MA_ENGINE_MAX_LISTENERS. */
        public ma_uint32 channels;                             /* The number of channels to use when mixing and spatializing. When set to 0, will use the native channel count of the device. */
        public ma_uint32 sampleRate;                           /* The sample rate. When set to 0 will use the native sample rate of the device. */
        public ma_uint32 periodSizeInFrames;                   /* If set to something other than 0, updates will always be exactly this size. The underlying device may be a different size, but from the perspective of the mixer that won't matter.*/
        public ma_uint32 periodSizeInMilliseconds;             /* Used if periodSizeInFrames is unset. */
        public ma_uint32 gainSmoothTimeInFrames;               /* The number of frames to interpolate the gain of spatialized sounds across. If set to 0, will use gainSmoothTimeInMilliseconds. */
        public ma_uint32 gainSmoothTimeInMilliseconds;         /* When set to 0, gainSmoothTimeInFrames will be used. If both are set to 0, a default value will be used. */
        public ma_uint32 defaultVolumeSmoothTimeInPCMFrames;   /* Defaults to 0. Controls the default amount of smoothing to apply to volume changes to sounds. High values means more smoothing at the expense of high latency (will take longer to reach the new volume). */
        public ma_uint32 preMixStackSizeInBytes;               /* A stack is used for internal processing in the node graph. This allows you to configure the size of this stack. Smaller values will reduce the maximum depth of your node graph. You should rarely need to modify this. */
        public ma_allocation_callbacks allocationCallbacks;
        public ma_bool32 noAutoStart;                          /* When set to true, requires an explicit call to ma_engine_start(). This is false by default, meaning the engine will be started automatically in ma_engine_init(). */
        public ma_bool32 noDevice;                             /* When set to true, don't create a default device. ma_engine_read_pcm_frames() can be called manually to read data. */
        public ma_mono_expansion_mode monoExpansionMode;       /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        public ma_vfs_ptr pResourceManagerVFS;                    /* A pointer to a pre-allocated VFS object to use with the resource manager. This is ignored if pResourceManager is not NULL. */
        public IntPtr onProcess;               /* Fired at the end of each call to ma_engine_read_pcm_frames(). For engine's that manage their own internal device (the default configuration), this will be fired from the audio thread, and you do not need to call ma_engine_read_pcm_frames() manually in order to trigger this. */
        public IntPtr pProcessUserData;                         /* User data that's passed into onProcess. */
        public ma_resampler_config resourceManagerResampling;  /* The resampling config to use with the resource manager. */
        public ma_resampler_config pitchResampling;            /* The resampling config for the pitch and Doppler effects. You will typically want this to be a fast resampler. For high quality stuff, it's recommended that you pre-resample. */

        public void SetDataProc(ma_device_data_proc callback)
        {
            dataCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetNotificationProc(ma_device_notification_proc callback)
        {
            notificationCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        
        public void SetEngineProcessProc(ma_engine_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine
    {
        public ma_node_graph nodeGraph;                        /* An engine is a node graph. It should be able to be plugged into any ma_node_graph API (with a cast) which means this must be the first member of this struct. */
        public ma_resource_manager_ptr pResourceManager;
        public ma_device_ptr pDevice;                             /* Optionally set via the config, otherwise allocated by the engine in ma_engine_init(). */
        public ma_log_ptr pLog;
        public ma_uint32 sampleRate;
        public ma_uint32 listenerCount;
        public ma_spatializer_listener_array listeners;
        public ma_allocation_callbacks allocationCallbacks;
        public ma_bool8 ownsResourceManager;
        public ma_bool8 ownsDevice;
        public ma_spinlock inlinedSoundLock;                   /* For synchronizing access to the inlined sound list. */
        public ma_sound_inlined_ptr pInlinedSoundHead;            /* The first inlined sound. Inlined sounds are tracked in a linked list. */
        public UInt32 inlinedSoundCount;      /* The total number of allocated inlined sound objects. Used for debugging. */
        public ma_uint32 gainSmoothTimeInFrames;               /* The number of frames to interpolate the gain of spatialized sounds across. */
        public ma_uint32 defaultVolumeSmoothTimeInPCMFrames;
        public ma_mono_expansion_mode monoExpansionMode;
        public IntPtr onProcess;
        public IntPtr pProcessUserData;
        public ma_resampler_config pitchResamplingConfig;

        public void SetProcessProc(ma_engine_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct ma_spatializer_listener_array
        {
            public ma_spatializer_listener l0;
            public ma_spatializer_listener l1;
            public ma_spatializer_listener l2;
            public ma_spatializer_listener l3;
            public ref ma_spatializer_listener this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= MiniAudioNative.MA_ENGINE_MAX_LISTENERS)
                    {
                        throw new IndexOutOfRangeException("Index must be between 0 and 3.");
                    }
                    fixed (ma_spatializer_listener* p = &l0)
                    {
                        return ref p[index];
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_procedural_data_source_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        public IntPtr callback;
        public IntPtr pUserData;

        public void SetCallback(ma_procedural_data_source_proc callback)
        {
            this.callback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_procedural_data_source
    {
        public ma_data_source_base ds;
        public ma_procedural_data_source_config config;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_fader_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_fader
    {
        public ma_fader_config config;
        public float volumeBeg;            /* If volumeBeg and volumeEnd is equal to 1, no fading happens (ma_fader_process_pcm_frames() will run as a passthrough). */
        public float volumeEnd;
        public ma_uint64 lengthInFrames;   /* The total length of the fade. */
        public ma_int64 cursorInFrames;   /* The current time in frames. Incremented by ma_fader_process_pcm_frames(). Signed because it'll be offset by startOffsetInFrames in set_fade_ex(). */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_log_callback
    {
        public IntPtr onLog;
        public IntPtr pUserData;
        public void SetLogCallback(ma_log_callback_proc callback)
        {
            onLog = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_log
    {
        public ma_log_callback_array callbacks;
        public ma_uint32 callbackCount;
        public ma_allocation_callbacks allocationCallbacks; /* Need to store these persistently because ma_log_postv() might need to allocate a buffer on the heap. */
        //There is a mutex here but the size depends on platform

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_log_callback_array
        {
            public ma_log_callback cb0;
            public ma_log_callback cb1;
            public ma_log_callback cb2;
            public ma_log_callback cb3;
            public unsafe ref ma_log_callback this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= MiniAudioNative.MA_MAX_LOG_CALLBACKS)
                    {
                        throw new IndexOutOfRangeException("Index must be between 0 and 3.");
                    }
                    fixed (ma_log_callback* p = &cb0)
                    {
                        return ref p[index];
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_context_config
    {
        public ma_log_ptr pLog;
        public ma_thread_priority threadPriority;
        public size_t threadStackSize;
        public IntPtr pUserData;
        public ma_allocation_callbacks allocationCallbacks;
        public dsound_info dsound;
        public alsa_info alsa;
        public pulse_info pulse;
        public coreaudio_info coreaudio;
        public jack_info jack;
        public ma_backend_callbacks custom;

        [StructLayout(LayoutKind.Sequential)]
        public struct dsound_info
        {
            public ma_handle hWnd; /* HWND. Optional window handle to pass into SetCooperativeLevel(). Will default to the foreground window, and if that fails, the desktop window. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct alsa_info
        {
            public ma_bool32 useVerboseDeviceEnumeration;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct pulse_info
        {
            public IntPtr pApplicationName;
            public IntPtr pServerName;
            public ma_bool32 tryAutoSpawn; /* Enables autospawning of the PulseAudio daemon if necessary. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct coreaudio_info
        {
            public ma_ios_session_category sessionCategory;
            public ma_uint32 sessionCategoryOptions;
            public ma_bool32 noAudioSessionActivate;   /* iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstace] setActive:true] on initialization. */
            public ma_bool32 noAudioSessionDeactivate; /* iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstace] setActive:false] on uninitialization. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct jack_info
        {
            public IntPtr pClientName;
            public ma_bool32 tryStartServer;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_context
    {
        public ma_backend_callbacks callbacks;
        public ma_backend backend;                 /* DirectSound, ALSA, etc. */
        public ma_log_ptr pLog;
        public ma_log log; /* Only used if the log is owned by the context. The pLog member will be set to &log in this case. */
        public ma_thread_priority threadPriority;
        public size_t threadStackSize;
        public IntPtr pUserData;
        public ma_allocation_callbacks allocationCallbacks;
        //More (variable sized) fields here...
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_pipeline_stage_notification
    {
        public ma_async_notification_ptr pNotification;
        public ma_fence_ptr pFence;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_pipeline_notifications
    {
        public ma_resource_manager_pipeline_stage_notification init;    /* Initialization of the decoder. */
        public ma_resource_manager_pipeline_stage_notification done;    /* Decoding fully completed. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_backend_callbacks
    {
        public IntPtr onContextInit;
        public IntPtr onContextUninit;
        public IntPtr onContextEnumerateDevices;
        public IntPtr onContextGetDeviceInfo;
        public IntPtr onDeviceInit;
        public IntPtr onDeviceUninit;
        public IntPtr onDeviceStart;
        public IntPtr onDeviceStop;
        public IntPtr onDeviceRead;
        public IntPtr onDeviceWrite;
        public IntPtr onDeviceDataLoop;
        public IntPtr onDeviceDataLoopWakeup;
        public IntPtr onDeviceGetInfo;

        public void Set(ma_backend_context_init_proc callback)
        {
            onContextInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_context_uninit_proc callback)
        {
            onContextUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_context_enumerate_devices_proc callback)
        {
            onContextEnumerateDevices = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_context_get_device_info_proc callback)
        {
            onContextGetDeviceInfo = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_init_proc callback)
        {
            onDeviceInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_uninit_proc callback)
        {
            onDeviceUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_start_proc callback)
        {
            onDeviceStart = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_stop_proc callback)
        {
            onDeviceStop = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_read_proc callback)
        {
            onDeviceRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_write_proc callback)
        {
            onDeviceWrite = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_dataloop_proc callback)
        {
            onDeviceDataLoop = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_dataloop_wakeup_proc callback)
        {
            onDeviceDataLoopWakeup = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void Set(ma_backend_device_get_info_proc callback)
        {
            onDeviceGetInfo = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_config
    {
        public IntPtr pFilePath;                      /* Set this to load from the resource manager. */
        public IntPtr pFilePathW;                  /* Set this to load from the resource manager. */
        public ma_data_source_ptr pDataSource;                /* Set this to load from an existing data source. */
        public ma_node_ptr pInitialAttachment;                /* If set, the sound will be attached to an input of this node. This can be set to a ma_sound. If set to NULL, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in `flags`. */
        public ma_uint32 initialAttachmentInputBusIndex;   /* The index of the input bus of pInitialAttachment to attach the sound to. */
        public ma_uint32 channelsIn;                       /* Ignored if using a data source as input (the data source's channel count will be used always). Otherwise, setting to 0 will cause the engine's channel count to be used. */
        public ma_uint32 channelsOut;                      /* Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count (only used if using a data source as input). */
        public ma_mono_expansion_mode monoExpansionMode;   /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        public ma_uint32 flags;                            /* A combination of MA_SOUND_FLAG_* flags. */
        public ma_uint32 volumeSmoothTimeInPCMFrames;      /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        public ma_uint64 initialSeekPointInPCMFrames;      /* Initializes the sound such that it's seeked to this location by default. */
        public ma_uint64 rangeBegInPCMFrames;
        public ma_uint64 rangeEndInPCMFrames;
        public ma_uint64 loopPointBegInPCMFrames;
        public ma_uint64 loopPointEndInPCMFrames;
        public IntPtr endCallback;
        public IntPtr pEndCallbackUserData;
        public ma_resampler_config pitchResampling;
        public ma_resource_manager_pipeline_notifications initNotifications;
        public ma_fence_ptr pDoneFence;                       /* Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams. */
        public ma_bool32 isLooping;                        /* Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in `flags` instead. */

        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound
    {
        public ma_engine_node engineNode;          /* Must be the first member for compatibility with the ma_node API. */
        public ma_data_source_ptr pDataSource;
        public ma_uint64 seekTarget; /* The PCM frame index to seek to in the mixing thread. Set to (~(ma_uint64)0) to not perform any seeking. */
        public ma_bool32 atEnd;
        public IntPtr endCallback;
        public IntPtr pEndCallbackUserData;
        public IntPtr pProcessingCache;            /* Will be null if pDataSource is null. */ 
        public ma_uint32 processingCacheFramesRemaining;
        public ma_uint32 processingCacheCap;
        public ma_bool8 ownsDataSource;

        /*
        We're declaring a resource manager data source object here to save us a malloc when loading a
        sound via the resource manager, which I *think* will be the most common scenario.
        */
        public ma_resource_manager_data_source_ptr pResourceManagerDataSource;

        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_inlined
    {
        public ma_sound sound;
        public ma_sound_inlined_ptr pNext;
        public ma_sound_inlined_ptr pPrev;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_group_config
    {
        public IntPtr pFilePath;                      /* Set this to load from the resource manager. */
        public IntPtr pFilePathW;                  /* Set this to load from the resource manager. */
        public ma_data_source_ptr pDataSource;                /* Set this to load from an existing data source. */
        public ma_node_ptr pInitialAttachment;                /* If set, the sound will be attached to an input of this node. This can be set to a ma_sound. If set to NULL, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in `flags`. */
        public ma_uint32 initialAttachmentInputBusIndex;   /* The index of the input bus of pInitialAttachment to attach the sound to. */
        public ma_uint32 channelsIn;                       /* Ignored if using a data source as input (the data source's channel count will be used always). Otherwise, setting to 0 will cause the engine's channel count to be used. */
        public ma_uint32 channelsOut;                      /* Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count (only used if using a data source as input). */
        public ma_mono_expansion_mode monoExpansionMode;   /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        public ma_uint32 flags;                            /* A combination of MA_SOUND_FLAG_* flags. */
        public ma_uint32 volumeSmoothTimeInPCMFrames;      /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        public ma_uint64 initialSeekPointInPCMFrames;      /* Initializes the sound such that it's seeked to this location by default. */
        public ma_uint64 rangeBegInPCMFrames;
        public ma_uint64 rangeEndInPCMFrames;
        public ma_uint64 loopPointBegInPCMFrames;
        public ma_uint64 loopPointEndInPCMFrames;
        public IntPtr endCallback;
        public IntPtr pEndCallbackUserData;
        public ma_resource_manager_pipeline_notifications initNotifications;
        public ma_fence_ptr pDoneFence;                       /* Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams. */
        public ma_bool32 isLooping;                        /* Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in `flags` instead. */

        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_native_data_format
    {
        public ma_uint32 format; // Assuming ma_format is a uint. Adjust as necessary.
        public ma_uint32 channels; // If set to 0, all channels are supported.
        public ma_uint32 sampleRate; // If set to 0, all sample rates are supported.
        public ma_uint32 flags; // A combination of MA_DATA_FORMAT_FLAG_* flags.
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_info
    {
        /* Basic info. This is the only information guaranteed to be filled in during device enumeration. */
        public ma_device_id id;
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1];
        public ma_bool32 isDefault;
        public ma_uint32 nativeDataFormatCount;
        public ma_native_data_format_array nativeDataFormats;

        public string GetName()
        {
            unsafe
            {
                fixed (byte* pName = name)
                {
                    // Find length up to null terminator
                    int len = 0;
                    while (len < MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH && pName[len] != 0) len++;

                    if (len == 0) return string.Empty;

                    // Assume UTF-8 encoding for device names
                    return System.Text.Encoding.UTF8.GetString(pName, len);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_native_data_format_array
        {
            public ma_native_data_format ndf0;
            public ma_native_data_format ndf1;
            public ma_native_data_format ndf2;
            public ma_native_data_format ndf3;
            public ma_native_data_format ndf4;
            public ma_native_data_format ndf5;
            public ma_native_data_format ndf6;
            public ma_native_data_format ndf7;
            public ma_native_data_format ndf8;
            public ma_native_data_format ndf9;
            public ma_native_data_format ndf10;
            public ma_native_data_format ndf11;
            public ma_native_data_format ndf12;
            public ma_native_data_format ndf13;
            public ma_native_data_format ndf14;
            public ma_native_data_format ndf15;
            public ma_native_data_format ndf16;
            public ma_native_data_format ndf17;
            public ma_native_data_format ndf18;
            public ma_native_data_format ndf19;
            public ma_native_data_format ndf20;
            public ma_native_data_format ndf21;
            public ma_native_data_format ndf22;
            public ma_native_data_format ndf23;
            public ma_native_data_format ndf24;
            public ma_native_data_format ndf25;
            public ma_native_data_format ndf26;
            public ma_native_data_format ndf27;
            public ma_native_data_format ndf28;
            public ma_native_data_format ndf29;
            public ma_native_data_format ndf30;
            public ma_native_data_format ndf31;
            public ma_native_data_format ndf32;
            public ma_native_data_format ndf33;
            public ma_native_data_format ndf34;
            public ma_native_data_format ndf35;
            public ma_native_data_format ndf36;
            public ma_native_data_format ndf37;
            public ma_native_data_format ndf38;
            public ma_native_data_format ndf39;
            public ma_native_data_format ndf40;
            public ma_native_data_format ndf41;
            public ma_native_data_format ndf42;
            public ma_native_data_format ndf43;
            public ma_native_data_format ndf44;
            public ma_native_data_format ndf45;
            public ma_native_data_format ndf46;
            public ma_native_data_format ndf47;
            public ma_native_data_format ndf48;
            public ma_native_data_format ndf49;
            public ma_native_data_format ndf50;
            public ma_native_data_format ndf51;
            public ma_native_data_format ndf52;
            public ma_native_data_format ndf53;
            public ma_native_data_format ndf54;
            public ma_native_data_format ndf55;
            public ma_native_data_format ndf56;
            public ma_native_data_format ndf57;
            public ma_native_data_format ndf58;
            public ma_native_data_format ndf59;
            public ma_native_data_format ndf60;
            public ma_native_data_format ndf61;
            public ma_native_data_format ndf62;
            public ma_native_data_format ndf63;
            public ref ma_native_data_format this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= 64)
                    {
                        throw new IndexOutOfRangeException("Index must be between 0 and 63.");
                    }
                    fixed (ma_native_data_format* p = &ndf0)
                    {
                        return ref p[index];
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resampler_config
    {
        public ma_format format;   /* Must be either ma_format_f32 or ma_format_s16. */
        public ma_uint32 channels;
        public ma_uint32 sampleRateIn;
        public ma_uint32 sampleRateOut;
        public ma_resample_algorithm algorithm;    /* When set to ma_resample_algorithm_custom, pBackendVTable will be used. */
        public ma_resampling_backend_vtable_ptr pBackendVTable;
        public IntPtr pBackendUserData;
        public linear_info linear;
        [StructLayout(LayoutKind.Sequential)]
        public struct linear_info
        {
            public ma_uint32 lpfOrder;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device_config
    {
        public ma_device_type deviceType;
        public ma_uint32 sampleRate;
        public ma_uint32 periodSizeInFrames;
        public ma_uint32 periodSizeInMilliseconds;
        public ma_uint32 periods;
        public ma_performance_profile performanceProfile;
        public ma_bool8 noPreSilencedOutputBuffer; /* When set to true, the contents of the output buffer passed into the data callback will be left undefined rather than initialized to silence. */
        public ma_bool8 noClip;                    /* When set to true, the contents of the output buffer passed into the data callback will not be clipped after returning. Only applies when the playback sample format is f32. */
        public ma_bool8 noDisableDenormals;        /* Do not disable denormals when firing the data callback. */
        public ma_bool8 noFixedSizedCallback;      /* Disables strict fixed-sized data callbacks. Setting this to true will result in the period size being treated only as a hint to the backend. This is an optimization for those who don't need fixed sized callbacks. */
        public IntPtr dataCallback;
        public IntPtr notificationCallback;
        public IntPtr stopCallback;
        public IntPtr pUserData;
        public ma_resampler_config resampling;
        public playback_info playback;
        public capture_info capture;
        public wasapi_info wasapi;
        public alsa_info alsa;
        public pulse_info pulse;
        public coreaudio_info coreaudio;
        public opensl_info opensl;
        public aaudio_info aaudio;

        [StructLayout(LayoutKind.Sequential)]
        public struct playback_info
        {
            public ma_device_id_ptr pDeviceID;
            public ma_format format;
            public ma_uint32 channels;
            public ma_channel_ptr pChannelMap;
            public ma_channel_mix_mode channelMixMode;
            public ma_bool32 calculateLFEFromSpatialChannels;  /* When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels (LR, FR, etc.). Ignored when an input LFE is present. */
            public ma_share_mode shareMode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct capture_info
        {
            public ma_device_id_ptr pDeviceID;
            public ma_format format;
            public ma_uint32 channels;
            public ma_channel_ptr pChannelMap;
            public ma_channel_mix_mode channelMixMode;
            public ma_bool32 calculateLFEFromSpatialChannels;  /* When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels (LR, FR, etc.). Ignored when an input LFE is present. */
            public ma_share_mode shareMode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct wasapi_info
        {
            public ma_wasapi_usage usage;              /* When configured, uses Avrt APIs to set the thread characteristics. */
            public ma_bool8 noAutoConvertSRC;          /* When set to true, disables the use of AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM. */
            public ma_bool8 noDefaultQualitySRC;       /* When set to true, disables the use of AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY. */
            public ma_bool8 noAutoStreamRouting;       /* Disables automatic stream routing. */
            public ma_bool8 noHardwareOffloading;      /* Disables WASAPI's hardware offloading feature. */
            public ma_uint32 loopbackProcessID;        /* The process ID to include or exclude for loopback mode. Set to 0 to capture audio from all processes. Ignored when an explicit device ID is specified. */
            public ma_bool8 loopbackProcessExclude;    /* When set to true, excludes the process specified by loopbackProcessID. By default, the process will be included. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct alsa_info
        {
            public ma_bool32 noMMap;           /* Disables MMap mode. */
            public ma_bool32 noAutoFormat;     /* Opens the ALSA device with SND_PCM_NO_AUTO_FORMAT. */
            public ma_bool32 noAutoChannels;   /* Opens the ALSA device with SND_PCM_NO_AUTO_CHANNELS. */
            public ma_bool32 noAutoResample;   /* Opens the ALSA device with SND_PCM_NO_AUTO_RESAMPLE. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct pulse_info
        {
            public IntPtr pStreamNamePlayback;
            public IntPtr pStreamNameCapture;
            public int channelMap;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct coreaudio_info
        {
            public ma_bool32 allowNominalSampleRateChange; /* Desktop only. When enabled, allows changing of the sample rate at the operating system level. */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct opensl_info
        {
            public ma_opensl_stream_type streamType;
            public ma_opensl_recording_preset recordingPreset;
            public ma_bool32 enableCompatibilityWorkarounds;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct aaudio_info
        {
            public ma_aaudio_usage usage;
            public ma_aaudio_content_type contentType;
            public ma_aaudio_input_preset inputPreset;
            public ma_aaudio_allowed_capture_policy allowedCapturePolicy;
            public ma_bool32 noAutoStartAfterReroute;
            public ma_bool32 enableCompatibilityWorkarounds;
            public ma_bool32 allowSetBufferCapacity;
        }

        public void SetDataCallback(ma_device_data_proc dataCallback)
        {
            this.dataCallback = MarshalHelper.GetFunctionPointerForDelegate(dataCallback);
        }

        public void SetNotificationCallback(ma_device_notification_proc notificationCallback)
        {
            this.notificationCallback = MarshalHelper.GetFunctionPointerForDelegate(notificationCallback);
        }

        public void SetStopCallback(ma_stop_proc stopCallback)
        {
            this.stopCallback = MarshalHelper.GetFunctionPointerForDelegate(stopCallback);
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 256)] // largest member size determines union size
    public unsafe struct ma_device_id
    {
        [FieldOffset(0)]
        public fixed ma_uint16 wasapi[64];
        [FieldOffset(0)]
        public fixed byte dsound[16];
        [FieldOffset(0)]
        public ma_uint32 winmm;
        [FieldOffset(0)]
        public fixed byte alsa[256];
        [FieldOffset(0)]
        public fixed byte pulse[256];
        [FieldOffset(0)]
        public int jack;
        [FieldOffset(0)]
        public fixed byte coreaudio[256];
        [FieldOffset(0)]
        public fixed byte sndio[256];
        [FieldOffset(0)]
        public fixed byte audio4[256];
        [FieldOffset(0)]
        public fixed byte oss[64];
        [FieldOffset(0)]
        public int aaudio;
        [FieldOffset(0)]
        public uint opensl;
        [FieldOffset(0)]
        public fixed byte webaudio[32];
        [FieldOffset(0)]
        public int custom_i;
        [FieldOffset(0)]
        public fixed byte custom_s[256];
        [FieldOffset(0)]
        public IntPtr custom_p;
        [FieldOffset(0)]
        public int nullbackend;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device_resampling
    {
        public ma_resample_algorithm algorithm;
        public ma_resampling_backend_vtable_ptr pBackendVTable;
        public IntPtr pBackendUserData;
        public ma_device_lpf_order linear;
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_device_lpf_order
        {
            ma_uint32 lpfOrder;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_playback
    {
        public ma_device_id_ptr pID;                  /* Set to NULL if using default ID, otherwise set to the address of "id". */
        public ma_device_id id;                    /* If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0. */
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1]; /* Maybe temporary. Likely to be replaced with a query API. */
        public ma_share_mode shareMode;            /* Set to whatever was passed in when the device was initialized. */
        public ma_format format;
        public ma_uint32 channels;
        public fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        public ma_format internalFormat;
        public ma_uint32 internalChannels;
        public ma_uint32 internalSampleRate;
        public fixed ma_channel internalChannelMap[MiniAudioNative.MA_MAX_CHANNELS];
        public ma_uint32 internalPeriodSizeInFrames;
        public ma_uint32 internalPeriods;
        public ma_channel_mix_mode channelMixMode;
        public ma_bool32 calculateLFEFromSpatialChannels;
        public ma_data_converter converter;
        public IntPtr pIntermediaryBuffer;          /* For implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks. */
        public ma_uint32 intermediaryBufferCap;
        public ma_uint32 intermediaryBufferLen;    /* How many valid frames are sitting in the intermediary buffer. */
        public IntPtr pInputCache;                  /* In external format. Can be null. */
        public ma_uint64 inputCacheCap;
        public ma_uint64 inputCacheConsumed;
        public ma_uint64 inputCacheRemaining;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_capture
    {
        public ma_device_id_ptr pID;                  /* Set to NULL if using default ID, otherwise set to the address of "id". */
        public ma_device_id id;                    /* If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0. */
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1];                     /* Maybe temporary. Likely to be replaced with a query API. */
        public ma_share_mode shareMode;            /* Set to whatever was passed in when the device was initialized. */
        public ma_format format;
        public ma_uint32 channels;
        public fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        public ma_format internalFormat;
        public ma_uint32 internalChannels;
        public ma_uint32 internalSampleRate;
        public fixed ma_channel internalChannelMap[MiniAudioNative.MA_MAX_CHANNELS];
        public ma_uint32 internalPeriodSizeInFrames;
        public ma_uint32 internalPeriods;
        public ma_channel_mix_mode channelMixMode;
        public ma_bool32 calculateLFEFromSpatialChannels;
        public ma_data_converter converter;
        public IntPtr pIntermediaryBuffer;          /* For implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks. */
        public ma_uint32 intermediaryBufferCap;
        public ma_uint32 intermediaryBufferLen;    /* How many valid frames are sitting in the intermediary buffer. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device
    {
        public ma_context_ptr pContext;
        public ma_device_type type;
        public ma_uint32 sampleRate;
        public ma_device_state state;                      /* The state of the device is variable and can change at any time on any thread. Must be used atomically. */
        public IntPtr onData;                 /* Set once at initialization time and should not be changed after. */
        public IntPtr onNotification; /* Set once at initialization time and should not be changed after. */
        public IntPtr onStop;                        /* DEPRECATED. Use the notification callback instead. Set once at initialization time and should not be changed after. */
        public IntPtr pUserData;                            /* Application defined data. */
        //There are a lot more fields down here but they are not needed as long other ma_types only use a pointer to ma_device

        public void SetDataProc(ma_device_data_proc onData)
        {
            this.onData = MarshalHelper.GetFunctionPointerForDelegate(onData);
        }

        public void SetNotificationProc(ma_device_notification_proc onNotification)
        {
            this.onNotification = MarshalHelper.GetFunctionPointerForDelegate(onNotification);
        }

        public void SetStopProc(ma_stop_proc onStop)
        {
            this.onStop = MarshalHelper.GetFunctionPointerForDelegate(onStop);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoder_config
    {
        public ma_format format;      /* Set to 0 or ma_format_unknown to use the stream's internal format. */
        public ma_uint32 channels;    /* Set to 0 to use the stream's internal channels. */
        public ma_uint32 sampleRate;  /* Set to 0 to use the stream's internal sample rate. */
        public ma_channel_ptr pChannelMap;
        public ma_channel_mix_mode channelMixMode;
        public ma_dither_mode ditherMode;
        public ma_resampler_config resampling;
        public ma_allocation_callbacks allocationCallbacks;
        public ma_encoding_format encodingFormat;
        public ma_uint32 seekPointCount;   /* When set to > 0, specifies the number of seek points to use for the generation of a seek table. Not all decoding backends support this. */
        public IntPtr ppCustomBackendVTables;
        public ma_uint32 customBackendCount;
        public IntPtr pCustomBackendUserData;

        /// <summary>
        /// Sets the ppCustomBackendVTables and customBackendCount fields. The caller is responsible for cleaning up memory by calling FreeCustomBackendVTables().
        /// </summary>
        /// <param name="customDecodingBackends"></param>
        public unsafe void SetCustomBackendVTables(ma_decoding_backend_vtable_ptr[] customDecodingBackends)
        {
            int count = 0;

            for (int i = 0; i < customDecodingBackends.Length; i++)
            {
                if (customDecodingBackends[i].pointer != IntPtr.Zero)
                    count++;
            }

            IntPtr vtableMemory = IntPtr.Zero;

            if (count > 0)
            {
                vtableMemory = Marshal.AllocHGlobal(sizeof(IntPtr) * count);

                ma_decoding_backend_vtable** pCustomBackendVTables = (ma_decoding_backend_vtable**)vtableMemory;

                int index = 0;

                for (int i = 0; i < customDecodingBackends.Length; i++)
                {
                    if (customDecodingBackends[i].pointer != IntPtr.Zero)
                        pCustomBackendVTables[index++] = (ma_decoding_backend_vtable*)customDecodingBackends[i].pointer;
                }

            }

            ppCustomBackendVTables = vtableMemory;
            customBackendCount = (UInt32)count;
        }

        public void FreeCustomBackendVTables()
        {
            if (ppCustomBackendVTables != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(ppCustomBackendVTables);
                ppCustomBackendVTables = IntPtr.Zero;
                customBackendCount = 0;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoder
    {
        public ma_data_source_base ds;
        public ma_data_source_ptr pBackend;                   /* The decoding backend we'll be pulling data from. */
        public IntPtr pBackendVTable; /* The vtable for the decoding backend. This needs to be stored so we can access the onUninit() callback. */
        public IntPtr pBackendUserData;
        public IntPtr onRead;
        public IntPtr onSeek;
        public IntPtr onTell;
        public IntPtr pUserData;
        public ma_uint64 readPointerInPCMFrames;      /* In output sample rate. Used for keeping track of how many frames are available for decoding. */
        public ma_format outputFormat;
        public ma_uint32 outputChannels;
        public ma_uint32 outputSampleRate;
        public ma_data_converter converter;    /* Data conversion is achieved by running frames through this. */
        public IntPtr pInputCache;              /* In input format. Can be null if it's not needed. */
        public ma_uint64 inputCacheCap;        /* The capacity of the input cache. */
        public ma_uint64 inputCacheConsumed;   /* The number of frames that have been consumed in the cache. Used for determining the next valid frame. */
        public ma_uint64 inputCacheRemaining;  /* The number of valid frames remaining in the cache. */
        public ma_allocation_callbacks allocationCallbacks;
        public ma_decoder_data_union data;

        public void SetReadProc(ma_decoder_read_proc callback)
        {
            onRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        public void SetSeekProc(ma_decoder_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        public void SetTellProc(ma_decoder_tell_proc callback)
        {
            onTell = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_decoder_data_vfs
        {
            public ma_vfs_ptr pVFS;
            public ma_vfs_file file;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_decoder_data_memory
        {
            public IntPtr pData; // const ma_uint8*
            public size_t dataSize;
            public size_t currentReadPos;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ma_decoder_data_union
        {
            [FieldOffset(0)]
            public ma_decoder_data_vfs vfs;

            [FieldOffset(0)]
            public ma_decoder_data_memory memory;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_encoder_config
    {
        public ma_encoding_format encodingFormat;
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        public ma_allocation_callbacks allocationCallbacks;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_encoder
    {
        public ma_encoder_config config;
        public IntPtr onWrite;
        public IntPtr onSeek;
        public IntPtr onInit;
        public IntPtr onUninit;
        public IntPtr onWritePCMFrames;
        public IntPtr pUserData;
        public IntPtr pInternalEncoder;
        public ma_encoder_vfs_data data;

        public void SetWriteProc(ma_encoder_write_proc callback)
        {
            onWrite = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetSeekProc(ma_encoder_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetInitProc(ma_encoder_init_proc callback)
        {
            onInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetUninitProc(ma_encoder_uninit_proc callback)
        {
            onUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetWritePCMFramesProc(ma_encoder_write_pcm_frames_proc callback)
        {
            onWritePCMFrames = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ma_encoder_vfs_data
        {    
            [FieldOffset(0)]
            public ma_vfs pVFS;    
            
            [FieldOffset(0)]
            public ma_vfs_file file;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_vtable
    {
        public IntPtr onRead;
        public IntPtr onSeek;
        public IntPtr onGetDataFormat;
        public IntPtr onGetCursor;
        public IntPtr onGetLength;
        public IntPtr onSetLooping;
        public ma_uint32 flags;
        
        public void SetReadProc(ma_data_source_vtable_read_proc callback)
        {
            onRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetSeekProc(ma_data_source_vtable_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetGetDataFormatProc(ma_data_source_vtable_get_data_format_proc callback)
        {
            onGetDataFormat = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetGetCursorProc(ma_data_source_vtable_get_cursor_proc callback)
        {
            onGetCursor = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetGetLengthProc(ma_data_source_vtable_get_length_proc callback)
        {
            onGetLength = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetSetLoopingProc(ma_data_source_vtable_set_looping_proc callback)
        {
            onSetLooping = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_config
    {
        public ma_data_source_vtable_ptr vtable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_node_config
    {
        public ma_node_config nodeConfig;
        public ma_data_source_ptr pDataSource;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_node
    {
        public ma_node_base baseNode;
        public ma_data_source_ptr pDataSource;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_base
    {
        public IntPtr vtable;
        public ma_uint64 rangeBegInFrames;
        public ma_uint64 rangeEndInFrames;             /* Set to -1 for unranged (default). */
        public ma_uint64 loopBegInFrames;              /* Relative to rangeBegInFrames. */
        public ma_uint64 loopEndInFrames;              /* Relative to rangeBegInFrames. Set to -1 for the end of the range. */
        public ma_data_source_ptr pCurrent;               /* When non-NULL, the data source being initialized will act as a proxy and will route all operations to pCurrent. Used in conjunction with pNext/onGetNext for seamless chaining. */
        public ma_data_source_ptr pNext;                  /* When set to NULL, onGetNext will be used. */
        public IntPtr onGetNext; /* Will be used when pNext is NULL. If both are NULL, no next will be used. */
        public ma_bool32 isLooping;

        public void SetNextProc(ma_data_source_get_next_proc callback)
        {
            onGetNext = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_channel_converter
    {
        public ma_format format;
        public ma_uint32 channelsIn;
        public ma_uint32 channelsOut;
        public ma_channel_mix_mode mixingMode;
        public ma_channel_conversion_path conversionPath;
        public ma_channel_ptr pChannelMapIn;
        public ma_channel_ptr pChannelMapOut;
        public IntPtr pShuffleTable;    /* Indexed by output channel index. */
        public ma_channel_converter_weights weights;  /* [in][out] */
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
        
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_channel_converter_weights
        {
            [FieldOffset(0)]
            public IntPtr f32;  // float**
            [FieldOffset(0)]
            public IntPtr s16;  // ma_int32**
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ma_biquad_coefficient
    {
        [FieldOffset(0)]
        public float f32;
        [FieldOffset(0)]
        public UInt32 s32;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_biquad_config
    {
        public ma_format format;
        public UInt32 channels;
        public double b0;
        public double b1;
        public double b2;
        public double a0;
        public double a1;
        public double a2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_biquad
    {
        public ma_format format;
        public UInt32 channels;
        public ma_biquad_coefficient b0;
        public ma_biquad_coefficient b1;
        public ma_biquad_coefficient b2;
        public ma_biquad_coefficient a1;
        public ma_biquad_coefficient a2;
        public ma_biquad_coefficient_ptr pR1;
        public ma_biquad_coefficient_ptr pR2;
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf1_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public double q;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public double q;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf1
    {
        public ma_format format;
        public UInt32 channels;
        public ma_biquad_coefficient a;
        public ma_biquad_coefficient_ptr pR1;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf2
    {
        public ma_biquad bq;   /* The second order low-pass filter is implemented as a biquad filter. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public UInt32 lpf1Count;
        public UInt32 lpf2Count;
        public ma_lpf1_ptr pLPF1;
        public ma_lpf2_ptr pLPF2;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf1_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public double q;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public double q;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf1
    {
        public ma_format format;
        public UInt32 channels;
        public ma_biquad_coefficient a;
        public ma_biquad_coefficient_ptr pR1;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf2
    {
        public ma_biquad bq;   /* The second order high-pass filter is implemented as a biquad filter. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public UInt32 hpf1Count;
        public UInt32 hpf2Count;
        public ma_hpf1_ptr pHPF1;
        public ma_hpf2_ptr pHPF2;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public double q;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf2
    {
        public ma_biquad bq;   /* The second order band-pass filter is implemented as a biquad filter. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double cutoffFrequency;
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 bpf2Count;
        public ma_bpf2_ptr pBPF2;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double q;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double q;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch2
    {
        public ma_biquad bq;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double q;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double q;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak2
    {
        public ma_biquad bq;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double shelfSlope;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double shelfSlope;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf2
    {
        public ma_biquad bq;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf2_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double shelfSlope;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_config
    {
        public ma_format format;
        public UInt32 channels;
        public UInt32 sampleRate;
        public double gainDB;
        public double shelfSlope;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf2
    {
        public ma_biquad bq;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_node_config
    {
        public ma_node_config nodeConfig;
        public ma_lpf_config lpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_node
    {
        public ma_node_base baseNode;
        public ma_lpf lpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_node_config
    {
        public ma_node_config nodeConfig;
        public ma_hpf_config hpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_node
    {
        public ma_node_base baseNode;
        public ma_hpf hpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_node_config
    {
        public ma_node_config nodeConfig;
        public ma_bpf_config bpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_node
    {
        public ma_node_base baseNode;
        public ma_bpf bpf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_node_config
    {
        public ma_node_config nodeConfig;
        public ma_notch_config notch;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_node
    {
        public ma_node_base baseNode;
        public ma_notch2 notch;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_node_config
    {
        public ma_node_config nodeConfig;
        public ma_peak_config peak;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_node
    {
        public ma_node_base baseNode;
        public ma_peak2 peak;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_node_config
    {
        public ma_node_config nodeConfig;
        public ma_loshelf_config loshelf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_node
    {
        public ma_node_base baseNode;
        public ma_loshelf2 loshelf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_node_config
    {
        public ma_node_config nodeConfig;
        public ma_hishelf_config hishelf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_node
    {
        public ma_node_base baseNode;
        public ma_hishelf2 hishelf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_config
    {
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        public ma_uint32 delayInFrames;
        public ma_bool32 delayStart;       /* Set to true to delay the start of the output; false otherwise. */
        public float wet;                  /* 0..1. Default = 1. */
        public float dry;                  /* 0..1. Default = 1. */
        public float decay;                /* 0..1. Default = 0 (no feedback). Feedback decay. Use this for echo. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay
    {
        public ma_delay_config config;
        public ma_uint32 cursor;               /* Feedback is written to this cursor. Always equal or in front of the read cursor. */
        public ma_uint32 bufferSizeInFrames;
        public IntPtr pBuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_node_config
    {
        public ma_node_config nodeConfig;
        public ma_delay_config delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_node
    {
        public ma_node_base baseNode;
        public ma_delay delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_splitter_node_config
    {
        public ma_node_config nodeConfig;
        public ma_uint32 channels;
        public ma_uint32 outputBusCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_splitter_node
    {
        public ma_node_base baseNode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_linear_resampler_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRateIn;
        public ma_uint32 sampleRateOut;
        public ma_uint32 lpfOrder;         /* The low-pass filter order. Setting this to 0 will disable low-pass filtering. */
        public double    lpfNyquistFactor; /* 0..1. Defaults to 1. 1 = Half the sampling frequency (Nyquist Frequency), 0.5 = Quarter the sampling frequency (half Nyquest Frequency), etc. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_linear_resampler
    {
        public ma_linear_resampler_config config;
        public ma_uint32 inAdvanceInt;
        public ma_uint32 inAdvanceFrac;
        public ma_uint32 inTimeInt;
        public ma_uint32 inTimeFrac;
        public ma_linear_resampler_data x0; /* The previous input frame. */
        public ma_linear_resampler_data x1; /* The next input frame. */
        public ma_lpf lpf;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public struct ma_linear_resampler_data
        {
            [FieldOffset(0)]
            public IntPtr f32;
            [FieldOffset(0)]
            public IntPtr s16;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resampler
    {
        public IntPtr pBackend;
        public IntPtr pBackendVTable;
        public IntPtr pBackendUserData;
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRateIn;
        public ma_uint32 sampleRateOut;
        public ma_resampler_state state;    /* State for stock resamplers so we can avoid a malloc. For stock resamplers, pBackend will point here. */
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public struct ma_resampler_state
        {
            [FieldOffset(0)]
            public ma_linear_resampler linear;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_converter
    {
        public ma_format formatIn;
        public ma_format formatOut;
        public ma_uint32 channelsIn;
        public ma_uint32 channelsOut;
        public ma_uint32 sampleRateIn;
        public ma_uint32 sampleRateOut;
        public ma_dither_mode ditherMode;
        public ma_data_converter_execution_path executionPath; /* The execution path the data converter will follow when processing. */
        public ma_channel_converter channelConverter;
        public ma_resampler resampler;
        public ma_bool8 hasPreFormatConversion;
        public ma_bool8 hasPostFormatConversion;
        public ma_bool8 hasChannelConverter;
        public ma_bool8 hasResampler;
        public ma_bool8 isPassthrough;
        /* Memory management. */
        public ma_bool8 _ownsHeap;
        public IntPtr _pHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_config
    {
        public ma_allocation_callbacks allocationCallbacks;
        public ma_log_ptr pLog;
        public ma_format decodedFormat;        /* The decoded format to use. Set to ma_format_unknown (default) to use the file's native format. */
        public ma_uint32 decodedChannels;      /* The decoded channel count to use. Set to 0 (default) to use the file's native channel count. */
        public ma_uint32 decodedSampleRate;    /* the decoded sample rate to use. Set to 0 (default) to use the file's native sample rate. */
        public ma_uint32 jobThreadCount;       /* Set to 0 if you want to self-manage your job threads. Defaults to 1. */
        public size_t jobThreadStackSize;
        public ma_uint32 jobQueueCapacity;     /* The maximum number of jobs that can fit in the queue at a time. Defaults to MA_JOB_TYPE_RESOURCE_MANAGER_QUEUE_CAPACITY. Cannot be zero. */
        public ma_uint32 flags;
        public ma_vfs_ptr pVFS;                   /* Can be NULL in which case defaults will be used. */
        public IntPtr ppCustomDecodingBackendVTables;
        public ma_uint32 customDecodingBackendCount;
        public IntPtr pCustomDecodingBackendUserData;
        public ma_resampler_config resampling;

        /// <summary>
        /// Sets the ppCustomDecodingBackendVTables and customDecodingBackendCount fields. The caller is responsible for cleaning up memory by calling FreeCustomDecodingBackendVTables().
        /// </summary>
        /// <param name="customDecodingBackends"></param>
        public unsafe void SetCustomDecodingBackendVTables(ma_decoding_backend_vtable_ptr[] customDecodingBackends)
        {
            int count = 0;

            for (int i = 0; i < customDecodingBackends.Length; i++)
            {
                if (customDecodingBackends[i].pointer != IntPtr.Zero)
                    count++;
            }

            IntPtr vtableMemory = IntPtr.Zero;

            if (count > 0)
            {
                vtableMemory = Marshal.AllocHGlobal(sizeof(IntPtr) * count);

                ma_decoding_backend_vtable** pCustomBackendVTables = (ma_decoding_backend_vtable**)vtableMemory;

                int index = 0;

                for (int i = 0; i < customDecodingBackends.Length; i++)
                {
                    if (customDecodingBackends[i].pointer != IntPtr.Zero)
                        pCustomBackendVTables[index++] = (ma_decoding_backend_vtable*)customDecodingBackends[i].pointer;
                }

            }

            ppCustomDecodingBackendVTables = vtableMemory;
            customDecodingBackendCount = (UInt32)count;
        }

        public void FreeCustomDecodingBackendVTables()
        {
            if (ppCustomDecodingBackendVTables != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(ppCustomDecodingBackendVTables);
                ppCustomDecodingBackendVTables = IntPtr.Zero;
                customDecodingBackendCount = 0;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoding_backend_vtable
    {
        public IntPtr onInit;
        public IntPtr onInitFile;
        public IntPtr onInitFileW;
        public IntPtr onInitMemory;
        public IntPtr onUninit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_stack
    {
        public size_t offset;
        public size_t sizeInBytes;
        public fixed byte _data[1];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_config
    {
        public ma_node_vtable_ptr vtable;          /* Should never be null. Initialization of the node will fail if so. */
        public ma_node_state initialState;         /* Defaults to ma_node_state_started. */
        public ma_uint32 inputBusCount;            /* Only used if the vtable specifies an input bus count of `MA_NODE_BUS_COUNT_UNKNOWN`, otherwise must be set to `MA_NODE_BUS_COUNT_UNKNOWN` (default). */
        public ma_uint32 outputBusCount;           /* Only used if the vtable specifies an output bus count of `MA_NODE_BUS_COUNT_UNKNOWN`, otherwise  be set to `MA_NODE_BUS_COUNT_UNKNOWN` (default). */
        public IntPtr pInputChannels;          /* The number of elements are determined by the input bus count as determined by the vtable, or `inputBusCount` if the vtable specifies `MA_NODE_BUS_COUNT_UNKNOWN`. */
        public IntPtr pOutputChannels;         /* The number of elements are determined by the output bus count as determined by the vtable, or `outputBusCount` if the vtable specifies `MA_NODE_BUS_COUNT_UNKNOWN`. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_vtable
    {
        /*
        Extended processing callback. This callback is used for effects that process input and output
        at different rates (i.e. they perform resampling). This is similar to the simple version, only
        they take two separate frame counts: one for input, and one for output.

        On input, `pFrameCountOut` is equal to the capacity of the output buffer for each bus, whereas
        `pFrameCountIn` will be equal to the number of PCM frames in each of the buffers in `ppFramesIn`.

        On output, set `pFrameCountOut` to the number of PCM frames that were actually output and set
        `pFrameCountIn` to the number of input frames that were consumed.
        */
        public IntPtr onProcess;

        /*
        A callback for retrieving the number of input frames that are required to output the
        specified number of output frames. You would only want to implement this when the node performs
        resampling. This is optional, even for nodes that perform resampling, but it does offer a
        small reduction in latency as it allows miniaudio to calculate the exact number of input frames
        to read at a time instead of having to estimate.
        */
        public IntPtr onGetRequiredInputFrameCount;

        /*
        The number of input buses. This is how many sub-buffers will be contained in the `ppFramesIn`
        parameters of the callbacks above.
        */
        public ma_uint8 inputBusCount;

        /*
        The number of output buses. This is how many sub-buffers will be contained in the `ppFramesOut`
        parameters of the callbacks above.
        */
        public ma_uint8 outputBusCount;

        /*
        Flags describing characteristics of the node. This is currently just a placeholder for some
        ideas for later on.
        */
        public ma_node_flags flags;

        public void SetOnProcess(ma_node_vtable_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        public void SetOnGetRequiredInputFrameCount(ma_node_vtable_get_required_input_frame_count_proc callback)
        {
            onGetRequiredInputFrameCount = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_output_bus
    {
        /* Immutable. */
        public ma_node_ptr pNode;                                         /* The node that owns this output bus. The input node. Will be null for dummy head and tail nodes. */
        public ma_uint8 outputBusIndex;                                /* The index of the output bus on pNode that this output bus represents. */
        public ma_uint8 channels;                                      /* The number of channels in the audio stream for this bus. */

        /* Mutable via multiple threads. Must be used atomically. The weird ordering here is for packing reasons. */
        public ma_uint8 inputNodeInputBusIndex;                        /* The index of the input bus on the input. Required for detaching. Will only be used within the spinlock so does not need to be atomic. */
        public ma_uint32 flags;                          /* Some state flags for tracking the read state of the output buffer. A combination of MA_NODE_OUTPUT_BUS_FLAG_*. */
        public ma_uint32 refCount;                       /* Reference count for some thread-safety when detaching. */
        public ma_bool32 isAttached;                     /* This is used to prevent iteration of nodes that are in the middle of being detached. Used for thread safety. */
        public ma_spinlock lck;                         /* Unfortunate lock, but significantly simplifies the implementation. Required for thread-safe attaching and detaching. */
        public float volume;                             /* Linear. */
        public ma_node_output_bus_ptr pNext;    /* If null, it's the tail node or detached. */
        public ma_node_output_bus_ptr pPrev;    /* If null, it's the head node or detached. */
        public ma_node_ptr pInputNode;          /* The node that this output bus is attached to. Required for detaching. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_input_bus
    {
        /* Mutable via multiple threads. */
        public ma_node_output_bus head;                /* Dummy head node for simplifying some lock-free thread-safety stuff. */
        public ma_uint32 nextCounter;    /* This is used to determine whether or not the input bus is finding the next node in the list. Used for thread safety when detaching output buses. */
        public ma_spinlock lck;         /* Unfortunate lock, but significantly simplifies the implementation. Required for thread-safe attaching and detaching. */
        /* Set once at startup. */
        public ma_uint8 channels;                      /* The number of channels in the audio stream for this bus. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_node_base
    {
        /* These variables are set once at startup. */
        public ma_node_graph_ptr pNodeGraph;                  /* The graph this node belongs to. */
        public ma_node_vtable_ptr vtable;
        public ma_uint32 inputBusCount;
        public ma_uint32 outputBusCount;
        public ma_node_input_bus_ptr pInputBuses;
        public ma_node_output_bus_ptr pOutputBuses;
        public IntPtr pCachedData;                         /* Allocated on the heap. Fixed size. Needs to be stored on the heap because reading from output buses is done in separate function calls. */
        public ma_uint16 cachedDataCapInFramesPerBus;      /* The capacity of the input data cache in frames, per bus. */

        /* These variables are read and written only from the audio thread. */
        public ma_uint16 cachedFrameCountOut;
        public ma_uint16 cachedFrameCountIn;
        public ma_uint16 consumedFrameCountIn;

        /* These variables are read and written between different threads. */
        public ma_node_state state;          /* When set to stopped, nothing will be read, regardless of the times in stateTimes. */
        public fixed ma_uint64 stateTimes[2];      /* Indexed by ma_node_state. Specifies the time based on the global clock that a node should be considered to be in the relevant state. */
        public ma_uint64 localTime;          /* The node's local clock. This is just a running sum of the number of output frames that have been processed. Can be modified by any thread with `ma_node_set_time()`. */

        /* Memory management. */
        public ma_node_input_bus_array _inputBuses;
        public ma_node_output_bus_array _outputBuses;
        public IntPtr _pHeap;   /* A heap allocation for internal use only. pInputBuses and/or pOutputBuses will point to this if the bus count exceeds MA_MAX_NODE_LOCAL_BUS_COUNT. */
        public ma_bool32 _ownsHeap;    /* If set to true, the node owns the heap allocation and _pHeap will be freed in ma_node_uninit(). */

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_node_input_bus_array
        {
            public ma_node_input_bus b0;
            public ma_node_input_bus b1;
            public ref ma_node_input_bus this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= MiniAudioNative.MA_MAX_NODE_LOCAL_BUS_COUNT)
                    {
                        throw new IndexOutOfRangeException("Index must be between 0 and 1.");
                    }
                    fixed (ma_node_input_bus* p = &b0)
                    {
                        return ref p[index];
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ma_node_output_bus_array
        {
            public ma_node_output_bus b0;
            public ma_node_output_bus b1;
            public ref ma_node_output_bus this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= MiniAudioNative.MA_MAX_NODE_LOCAL_BUS_COUNT)
                    {
                        throw new IndexOutOfRangeException("Index must be between 0 and 1.");
                    }
                    fixed (ma_node_output_bus* p = &b0)
                    {
                        return ref p[index];
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_graph_config
    {
        public ma_uint32 channels;
        public ma_uint32 processingSizeInFrames;   /* This is the preferred processing size for node processing callbacks unless overridden by a node itself. Can be 0 in which case it will be based on the frame count passed into ma_node_graph_read_pcm_frames(), but will not be well defined. */
        public size_t preMixStackSizeInBytes;      /* Defaults to 512KB per channel. Reducing this will save memory, but the depth of your node graph will be more restricted. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_graph
    {
        /* Immutable. */
        public ma_node_base baseNode;                  /* The node graph itself is a node so it can be connected as an input to different node graph. This has zero inputs and calls ma_node_graph_read_pcm_frames() to generate it's output. */
        public ma_node_base endpoint;              /* Special node that all nodes eventually connect to. Data is read from this node in ma_node_graph_read_pcm_frames(). */
        public IntPtr pProcessingCache;            /* This will be allocated when processingSizeInFrames is non-zero. This is needed because ma_node_graph_read_pcm_frames() can be called with a variable number of frames, and we may need to do some buffering in situations where the caller requests a frame count that's not a multiple of processingSizeInFrames. */
        public ma_uint32 processingCacheFramesRemaining;
        public ma_uint32 processingSizeInFrames;
        /* Read and written by multiple threads. */
        public ma_bool32 isReading;
        /* Modified only by the audio thread. */
        public ma_stack_ptr pPreMixStack;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_effect_node_config
    {
        public ma_uint32 sampleRate;
        public ma_uint32 channels;
        public IntPtr onProcess;
        public IntPtr pUserData;

        public void SetOnProcess(ma_effect_node_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_effect_node
    {
        public ma_node_base baseNode;
        public ma_effect_node_config config;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_gainer_config
    {
        public ma_uint32 channels;
        public ma_uint32 smoothTimeInFrames;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_gainer
    {
        public ma_gainer_config config;
        public ma_uint32 t;
        public float masterVolume;
        public IntPtr pOldGains;
        public IntPtr pNewGains;
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_config
    {
        public ma_uint32 channelsIn;
        public ma_uint32 channelsOut;
        public ma_channel_ptr pChannelMapIn;
        public ma_attenuation_model attenuationModel;
        public ma_positioning positioning;
        public ma_handedness handedness;           /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        public float minGain;
        public float maxGain;
        public float minDistance;
        public float maxDistance;
        public float rolloff;
        public float coneInnerAngleInRadians;
        public float coneOuterAngleInRadians;
        public float coneOuterGain;
        public float dopplerFactor;                /* Set to 0 to disable doppler effect. */
        public float directionalAttenuationFactor; /* Set to 0 to disable directional attenuation. */
        public float minSpatializationChannelGain; /* The minimal scaling factor to apply to channel gains when accounting for the direction of the sound relative to the listener. Must be in the range of 0..1. Smaller values means more aggressive directional panning, larger values means more subtle directional panning. */
        public ma_uint32 gainSmoothTimeInFrames;   /* When the gain of a channel changes during spatialization, the transition will be linearly interpolated over this number of frames. */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer
    {
        public ma_uint32 channelsIn;
        public ma_uint32 channelsOut;
        public ma_channel_ptr pChannelMapIn;
        public ma_attenuation_model attenuationModel;
        public ma_positioning positioning;
        public ma_handedness handedness;           /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        public float minGain;
        public float maxGain;
        public float minDistance;
        public float maxDistance;
        public float rolloff;
        public float coneInnerAngleInRadians;
        public float coneOuterAngleInRadians;
        public float coneOuterGain;
        public float dopplerFactor;                /* Set to 0 to disable doppler effect. */
        public float directionalAttenuationFactor; /* Set to 0 to disable directional attenuation. */
        public ma_uint32 gainSmoothTimeInFrames;   /* When the gain of a channel changes during spatialization, the transition will be linearly interpolated over this number of frames. */
        public ma_atomic_vec3f position;
        public ma_atomic_vec3f direction;
        public ma_atomic_vec3f velocity;  /* For doppler effect. */
        public float dopplerPitch; /* Will be updated by ma_spatializer_process_pcm_frames() and can be used by higher level functions to apply a pitch shift for doppler effect. */
        public float minSpatializationChannelGain;
        public ma_gainer gainer;   /* For smooth gain transitions. */
        public IntPtr pNewChannelGainsOut; /* An offset of _pHeap. Used by ma_spatializer_process_pcm_frames() to store new channel gains. The number of elements in this array is equal to config.channelsOut. */
        /* Memory management. */
        public IntPtr _pHeap;
        public ma_bool32 _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_listener_config
    {
        public ma_uint32 channelsOut;
        public ma_channel_ptr pChannelMapOut;
        public ma_handedness handedness;   /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        public float coneInnerAngleInRadians;
        public float coneOuterAngleInRadians;
        public float coneOuterGain;
        public float speedOfSound;
        public ma_vec3f worldUp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_listener
    {
        public ma_spatializer_listener_config config;
        public ma_atomic_vec3f position;  /* The absolute position of the listener. */
        public ma_atomic_vec3f direction; /* The direction the listener is facing. The world up vector is config.worldUp. */
        public ma_atomic_vec3f velocity;
        public ma_bool32 isEnabled;
        /* Memory management. */
        public ma_bool32 _ownsHeap;
        public IntPtr _pHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_waveform_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        public ma_waveform_type type;
        public double amplitude;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_waveform
    {
        public ma_data_source_base ds;
        public ma_waveform_config config;
        public double advance;
        public double time;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_pulsewave_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_uint32 sampleRate;
        public double dutyCycle;
        public double amplitude;
        public double frequency;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_pulsewave
    {
        public ma_waveform waveform;
        public ma_pulsewave_config config;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_noise_config
    {
        public ma_format format;
        public ma_uint32 channels;
        public ma_noise_type type;
        public ma_int32 seed;
        public double amplitude;
        public ma_bool32 duplicateChannels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lcg
    {
        public ma_uint32 state;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ma_noise
    {
        ma_data_source_base ds;
        ma_noise_config config;
        ma_lcg lcg;
        State state;
        /* Memory management. */
        IntPtr _pHeap;
        ma_bool32 _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public struct State
        {
            [FieldOffset(0)]
            public Pink pink;
            [FieldOffset(0)]
            public Brownian brownian;
            [StructLayout(LayoutKind.Sequential)]
            public struct Pink
            {
                public IntPtr bin;
                public IntPtr accumulation;
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct Brownian
            {
                public IntPtr accumulation;
            }
        }
    }
}
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
    /// Represents a platform-sized unsigned integer, analogous to <c>size_t</c> in C/C++.
    /// Provides implicit conversions from and arithmetic operators for <see cref="UIntPtr"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, and <see cref="ulong"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct size_t
    {
        private UIntPtr value;

        /// <summary>
        /// Initializes a new instance of the <see cref="size_t"/> struct with the specified <see cref="UIntPtr"/> value.
        /// </summary>
        /// <param name="value">The unsigned pointer-sized value.</param>
        public size_t(UIntPtr value)
        {
            this.value = value;
        }

        /// <summary>
        /// Implicitly converts a <see cref="UIntPtr"/> to a <see cref="size_t"/>.
        /// </summary>
        public static implicit operator size_t(UIntPtr value)
        {
            return new size_t(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="size_t"/> to a <see cref="UIntPtr"/>.
        /// </summary>
        public static implicit operator UIntPtr(size_t size)
        {
            return size.value;
        }

        /// <summary>
        /// Implicitly converts an <see cref="int"/> to a <see cref="size_t"/>.
        /// </summary>
        public static implicit operator size_t(int value)
        {
            return new size_t((UIntPtr)(uint)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="uint"/> to a <see cref="size_t"/>.
        /// </summary>
        public static implicit operator size_t(uint value)
        {
            return new size_t((UIntPtr)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="long"/> to a <see cref="size_t"/>.
        /// </summary>
        public static implicit operator size_t(long value)
        {
            return new size_t((UIntPtr)(ulong)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ulong"/> to a <see cref="size_t"/>.
        /// </summary>
        public static implicit operator size_t(ulong value)
        {
            return new size_t((UIntPtr)value);
        }

        /// <summary>
        /// Adds two <see cref="size_t"/> values.
        /// </summary>
        public static size_t operator +(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() + b.ToUInt64()));
        }

        /// <summary>
        /// Subtracts one <see cref="size_t"/> from another.
        /// </summary>
        public static size_t operator -(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() - b.ToUInt64()));
        }

        /// <summary>
        /// Multiplies two <see cref="size_t"/> values.
        /// </summary>
        public static size_t operator *(size_t a, size_t b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b.ToUInt64()));
        }

        /// <summary>
        /// Divides one <see cref="size_t"/> by another.
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public static size_t operator /(size_t a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b.ToUInt64()));
        }

        /// <summary>
        /// Compares two <see cref="size_t"/> values for equality.
        /// </summary>
        public static bool operator ==(size_t a, size_t b)
        {
            return a.value == b.value;
        }

        /// <summary>
        /// Compares two <see cref="size_t"/> values for inequality.
        /// </summary>
        public static bool operator !=(size_t a, size_t b)
        {
            return a.value != b.value;
        }

        /// <summary>
        /// Determines whether one <see cref="size_t"/> is less than another.
        /// </summary>
        public static bool operator <(size_t a, size_t b)
        {
            return a.ToUInt64() < b.ToUInt64();
        }

        /// <summary>
        /// Determines whether one <see cref="size_t"/> is greater than another.
        /// </summary>
        public static bool operator >(size_t a, size_t b)
        {
            return a.ToUInt64() > b.ToUInt64();
        }

        /// <summary>
        /// Determines whether one <see cref="size_t"/> is less than or equal to another.
        /// </summary>
        public static bool operator <=(size_t a, size_t b)
        {
            return a.ToUInt64() <= b.ToUInt64();
        }

        /// <summary>
        /// Determines whether one <see cref="size_t"/> is greater than or equal to another.
        /// </summary>
        public static bool operator >=(size_t a, size_t b)
        {
            return a.ToUInt64() >= b.ToUInt64();
        }

        /// <summary>
        /// Adds a <see cref="ulong"/> to a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator +(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() + b));
        }

        /// <summary>
        /// Subtracts a <see cref="ulong"/> from a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator -(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() - b));
        }

        /// <summary>
        /// Multiplies a <see cref="size_t"/> by a <see cref="ulong"/>.
        /// </summary>
        public static size_t operator *(size_t a, ulong b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b));
        }

        /// <summary>
        /// Divides a <see cref="size_t"/> by a <see cref="ulong"/>.
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public static size_t operator /(size_t a, ulong b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b));
        }

        /// <summary>
        /// Adds a <see cref="size_t"/> to a <see cref="ulong"/>.
        /// </summary>
        public static size_t operator +(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a + b.ToUInt64()));
        }

        /// <summary>
        /// Subtracts a <see cref="size_t"/> from a <see cref="ulong"/>.
        /// </summary>
        public static size_t operator -(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a - b.ToUInt64()));
        }

        /// <summary>
        /// Multiplies a <see cref="ulong"/> by a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator *(ulong a, size_t b)
        {
            return new size_t((UIntPtr)(a * b.ToUInt64()));
        }

        /// <summary>
        /// Divides a <see cref="ulong"/> by a <see cref="size_t"/>.
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public static size_t operator /(ulong a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a / b.ToUInt64()));
        }

        /// <summary>
        /// Adds a <see cref="uint"/> to a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator +(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() + b));
        }

        /// <summary>
        /// Subtracts a <see cref="uint"/> from a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator -(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.value.ToUInt64() - b));
        }

        /// <summary>
        /// Multiplies a <see cref="size_t"/> by a <see cref="uint"/>.
        /// </summary>
        public static size_t operator *(size_t a, uint b)
        {
            return new size_t((UIntPtr)(a.ToUInt64() * b));
        }

        /// <summary>
        /// Divides a <see cref="size_t"/> by a <see cref="uint"/>.
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public static size_t operator /(size_t a, uint b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a.ToUInt64() / b));
        }

        /// <summary>
        /// Adds a <see cref="size_t"/> to a <see cref="uint"/>.
        /// </summary>
        public static size_t operator +(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a + b.ToUInt64()));
        }

        /// <summary>
        /// Subtracts a <see cref="size_t"/> from a <see cref="uint"/>.
        /// </summary>
        public static size_t operator -(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a - b.ToUInt64()));
        }

        /// <summary>
        /// Multiplies a <see cref="uint"/> by a <see cref="size_t"/>.
        /// </summary>
        public static size_t operator *(uint a, size_t b)
        {
            return new size_t((UIntPtr)(a * b.ToUInt64()));
        }

        /// <summary>
        /// Divides a <see cref="uint"/> by a <see cref="size_t"/>.
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public static size_t operator /(uint a, size_t b)
        {
            if (b.value == UIntPtr.Zero)
                throw new DivideByZeroException();
            return new size_t((UIntPtr)(a / b.ToUInt64()));
        }

        /// <summary>
        /// Converts the value to a <see cref="ulong"/>.
        /// </summary>
        /// <returns>The value as a <see cref="ulong"/>.</returns>
        public ulong ToUInt64()
        {
            return value.ToUInt64();
        }

        /// <summary>
        /// Converts the value to a <see cref="uint"/>.
        /// </summary>
        /// <returns>The value as a <see cref="uint"/>.</returns>
        public uint ToUInt32()
        {
            return value.ToUInt32();
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a <see cref="size_t"/> with the same value; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is size_t)
            {
                return this == (size_t)obj;
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    // ma_structures
    /// <summary>
    /// Custom memory allocation callbacks. Allows the application to override the default memory
    /// allocation routines used by miniaudio. Each callback receives the user data pointer as a parameter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_allocation_callbacks
    {
        /// <summary>
        /// A pointer to user data that is passed to each allocation callback.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// A pointer to the custom allocation function (<c>void* (*)(size_t, void*)</c>).
        /// </summary>
        public IntPtr onMalloc;
        /// <summary>
        /// A pointer to the custom reallocation function (<c>void* (*)(void*, size_t, void*)</c>).
        /// </summary>
        public IntPtr onRealloc;
        /// <summary>
        /// A pointer to the custom free function (<c>void (*)(void*, void*)</c>).
        /// </summary>
        public IntPtr onFree;

        /// <summary>
        /// Sets the custom memory allocation callback.
        /// </summary>
        /// <param name="callback">The delegate of type <see cref="ma_allocation_callbacks_malloc_proc"/>.</param>
        public void SetMallocProc(ma_allocation_callbacks_malloc_proc callback)
        {
            onMalloc = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the custom memory reallocation callback.
        /// </summary>
        /// <param name="callback">The delegate of type <see cref="ma_allocation_callbacks_realloc_proc"/>.</param>
        public void SetReallocProc(ma_allocation_callbacks_realloc_proc callback)
        {
            onRealloc = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the custom memory free callback.
        /// </summary>
        /// <param name="callback">The delegate of type <see cref="ma_allocation_callbacks_free_proc"/>.</param>
        public void SetFreeProc(ma_allocation_callbacks_free_proc callback)
        {
            onFree = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Describes the basic details about a playback or capture device, including format,
    /// channel map, sample rate, and period configuration.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_descriptor
    {
        /// <summary>
        /// A pointer to the ID of the device. Set to <c>null</c> to use the default device.
        /// </summary>
        public ma_device_id_ptr pDeviceID;
        /// <summary>
        /// The share mode of the device (exclusive or shared).
        /// </summary>
        public ma_share_mode shareMode;
        /// <summary>
        /// The sample format of the device (e.g. f32, s16).
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRate;
        private fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        /// <summary>
        /// The period size in PCM frames.
        /// </summary>
        public ma_uint32 periodSizeInFrames;
        /// <summary>
        /// The period size in milliseconds.
        /// </summary>
        public ma_uint32 periodSizeInMilliseconds;
        /// <summary>
        /// The number of periods.
        /// </summary>
        public ma_uint32 periodCount;
    }

    /// <summary>
    /// Represents a 3D vector with float components, used for positions, directions, and velocities
    /// in spatialization calculations.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_vec3f
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public float x;
        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public float y;
        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        public float z;

        /// <summary>
        /// Initializes a new instance of the <see cref="ma_vec3f"/> struct.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public ma_vec3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Returns a string representation of the vector in the form "(x, y, z)".
        /// </summary>
        /// <returns>A string that represents the current vector.</returns>
        public override string ToString()
        {
            return "(" + x + ", " +  y + ", " + z + ")";
        }
    }

    /// <summary>
    /// A thread-safe 3D vector protected by a spinlock for atomic access.
    /// Used for spatialization data that may be accessed from multiple threads.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_atomic_vec3f
    {
        /// <summary>
        /// The 3D vector value.
        /// </summary>
        public ma_vec3f v;
        /// <summary>
        /// The spinlock used for atomic synchronization of the vector.
        /// </summary>
        public ma_spinlock lck;
    }

    /// <summary>
    /// A typesafe atomic 32-bit boolean. The struct enforces atomic access at compile time
    /// to prevent accidental non-atomic operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_bool32
    {
        /// <summary>
        /// The underlying 32-bit value.
        /// </summary>
        [FieldOffset(0)]
        public UInt32 value;
    }

    /// <summary>
    /// A typesafe atomic 32-bit unsigned integer. The struct enforces atomic access at compile time
    /// to prevent accidental non-atomic operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_uint32
    {
        /// <summary>
        /// The underlying 32-bit unsigned integer value.
        /// </summary>
        [FieldOffset(0)]
        public UInt32 value;
    }

    /// <summary>
    /// A typesafe atomic 32-bit signed integer. The struct enforces atomic access at compile time
    /// to prevent accidental non-atomic operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_int32
    {
        /// <summary>
        /// The underlying 32-bit signed integer value.
        /// </summary>
        [FieldOffset(0)]
        public Int32 value;
    }

    /// <summary>
    /// A typesafe atomic 64-bit unsigned integer. The struct enforces atomic access at compile time
    /// to prevent accidental non-atomic operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ma_atomic_uint64
    {
        /// <summary>
        /// The underlying 64-bit unsigned integer value.
        /// </summary>
        [FieldOffset(0)]
        public UInt64 value;
    }

    /// <summary>
    /// A typesafe atomic float. The struct enforces atomic access at compile time
    /// to prevent accidental non-atomic operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ma_atomic_float
    {
        /// <summary>
        /// The underlying float value.
        /// </summary>
        [FieldOffset(0)]
        public float value;
    }

    /// <summary>
    /// Configuration for a stereo panner. Specifies the audio format, channel count,
    /// pan mode, and initial pan position.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_panner_config
    {
        /// <summary>
        /// The sample format of the audio data to be panned.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The pan mode: <see cref="ma_pan_mode.ma_pan_mode_balance"/> (default) performs simple balance,
        /// <see cref="ma_pan_mode.ma_pan_mode_pan"/> performs true panning where sound moves from one side to the other.
        /// </summary>
        public ma_pan_mode mode;
        /// <summary>
        /// The pan position ranging from -1 (left) to +1 (right), where 0 is center. Defaults to 0.
        /// </summary>
        public float pan;
    }

    /// <summary>
    /// Represents the runtime state of a stereo panner. Performs panning (balance or true pan)
    /// on audio data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_panner
    {
        /// <summary>
        /// The sample format of the audio data to be panned.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The pan mode. <see cref="ma_pan_mode.ma_pan_mode_balance"/> for balance, <see cref="ma_pan_mode.ma_pan_mode_pan"/> for true pan.
        /// </summary>
        public ma_pan_mode mode;
        /// <summary>
        /// The pan position ranging from -1 (left) to +1 (right), where 0 is center. Defaults to 0.
        /// </summary>
        public float pan;  /* -1..1 where 0 is no pan, -1 is left side, +1 is right side. Defaults to 0. */
    }

    /// <summary>
    /// Configuration for initializing an engine node. An engine node is the base object for both
    /// <c>ma_sound</c> and <c>ma_sound_group</c>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_node_config
    {
        /// <summary>
        /// A pointer to the engine that owns this node.
        /// </summary>
        public ma_engine_ptr pEngine;
        /// <summary>
        /// The type of the engine node (sound or group).
        /// </summary>
        public ma_engine_node_type type;
        /// <summary>
        /// The number of input channels.
        /// </summary>
        public ma_uint32 channelsIn;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// The sample rate. Only used when the type is set to <see cref="ma_engine_node_type.ma_engine_node_type_sound"/>.
        /// </summary>
        public ma_uint32 sampleRate;               /* Only used when the type is set to ma_engine_node_type_sound. */
        /// <summary>
        /// The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used.
        /// </summary>
        public ma_uint32 volumeSmoothTimeInPCMFrames;  /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        /// <summary>
        /// Controls how a mono channel should be expanded to other channels when spatialization is disabled.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;
        /// <summary>
        /// Pitching can be explicitly disabled with <c>MA_SOUND_FLAG_NO_PITCH</c> to optimize processing.
        /// </summary>
        public ma_bool8 isPitchDisabled;           /* Pitching can be explicitly disabled with MA_SOUND_FLAG_NO_PITCH to optimize processing. */
        /// <summary>
        /// Spatialization can be explicitly disabled with <c>MA_SOUND_FLAG_NO_SPATIALIZATION</c>.
        /// </summary>
        public ma_bool8 isSpatializationDisabled;  /* Spatialization can be explicitly disabled with MA_SOUND_FLAG_NO_SPATIALIZATION. */
        /// <summary>
        /// The index of the listener this node should always use for spatialization. If set to <c>MA_LISTENER_INDEX_CLOSEST</c> the engine will use the closest listener.
        /// </summary>
        public ma_uint8 pinnedListenerIndex;       /* The index of the listener this node should always use for spatialization. If set to MA_LISTENER_INDEX_CLOSEST the engine will use the closest listener. */
        /// <summary>
        /// The resampler configuration for pitch shifting.
        /// </summary>
        public ma_resampler_config resampling;
    }

    /// <summary>
    /// Base node object for both <c>ma_sound</c> and <c>ma_sound_group</c>. Contains all common
    /// audio processing components such as fader, resampler, spatializer, panner, and volume gainer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_node
    {
        /// <summary>
        /// Must be the first member for compatibility with the ma_node API.
        /// </summary>
        public ma_node_base baseNode;                              /* Must be the first member for compatibility with the ma_node API. */
        /// <summary>
        /// A pointer to the engine. Set based on the value from the config.
        /// </summary>
        public ma_engine_ptr pEngine;                                 /* A pointer to the engine. Set based on the value from the config. */
        /// <summary>
        /// The sample rate of the input data. For sounds backed by a data source, this will be the data source's sample rate. Otherwise it'll be the engine's sample rate.
        /// </summary>
        public ma_uint32 sampleRate;                               /* The sample rate of the input data. For sounds backed by a data source, this will be the data source's sample rate. Otherwise it'll be the engine's sample rate. */
        /// <summary>
        /// The number of frames to smooth over volume changes.
        /// </summary>
        public ma_uint32 volumeSmoothTimeInPCMFrames;
        /// <summary>
        /// Controls how a mono channel should be expanded to other channels when spatialization is disabled.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;
        /// <summary>
        /// The fader used for fade-in and fade-out effects.
        /// </summary>
        public ma_fader fader;
        /// <summary>
        /// The resampler used for pitch shifting.
        /// </summary>
        public ma_resampler resampler;                      /* For pitch shift. */
        /// <summary>
        /// The spatializer used for 3D audio positioning.
        /// </summary>
        public ma_spatializer spatializer;
        /// <summary>
        /// The stereo panner.
        /// </summary>
        public ma_panner panner;
        /// <summary>
        /// The volume gainer for smooth volume transitions. Only used if <see cref="volumeSmoothTimeInPCMFrames"/> is greater than 0.
        /// </summary>
        public ma_gainer volumeGainer;                             /* This will only be used if volumeSmoothTimeInPCMFrames is > 0. */
        /// <summary>
        /// The volume level. Defaults to 1.
        /// </summary>
        public float volume;                             /* Defaults to 1. */
        /// <summary>
        /// The pitch multiplier.
        /// </summary>
        public float pitch;
        /// <summary>
        /// The previous pitch value, used for determining whether the resampler needs to be updated. Updated on the mixing thread.
        /// </summary>
        public float oldPitch;                                     /* For determining whether or not the resampler needs to be updated to reflect the new pitch. The resampler will be updated on the mixing thread. */
        /// <summary>
        /// The previous Doppler pitch value, used for determining whether the resampler needs to be updated for Doppler effect changes.
        /// </summary>
        public float oldDopplerPitch;                              /* For determining whether or not the resampler needs to be updated to take a new doppler pitch into account. */
        /// <summary>
        /// When set to true, pitching will be disabled which will allow the resampler to be bypassed to save computation.
        /// </summary>
        public ma_bool32 isPitchDisabled;            /* When set to true, pitching will be disabled which will allow the resampler to be bypassed to save some computation. */
        /// <summary>
        /// Set to false by default. When set to false, will not have spatialization applied.
        /// </summary>
        public ma_bool32 isSpatializationDisabled;   /* Set to false by default. When set to false, will not have spatialisation applied. */
        /// <summary>
        /// The index of the listener this node should always use for spatialization. If set to <c>MA_LISTENER_INDEX_CLOSEST</c> the engine will use the closest listener.
        /// </summary>
        public ma_uint32 pinnedListenerIndex;        /* The index of the listener this node should always use for spatialization. If set to MA_LISTENER_INDEX_CLOSEST the engine will use the closest listener. */
        /* When setting a fade, it's not done immediately in ma_sound_set_fade(). It's deferred to the audio thread which means we need to store the settings here. */
        /// <summary>
        /// Deferred fade settings. Setting a fade is not done immediately in <c>ma_sound_set_fade()</c>; it is deferred to the audio thread which means the settings are stored here.
        /// </summary>
        public fade_settings fadeSettings;
        /* Memory management. */
        /// <summary>
        /// Indicates whether this node owns its heap allocation.
        /// </summary>
        public ma_bool8 _ownsHeap;
        /// <summary>
        /// A pointer to the heap-allocated internal data for this node.
        /// </summary>
        public IntPtr _pHeap;

        /// <summary>
        /// Stores the deferred fade settings for an engine node. When a fade is set via <c>ma_sound_set_fade()</c>,
        /// it is not applied immediately but deferred to the audio thread for thread safety.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct fade_settings
        {
            /// <summary>
            /// The volume at the beginning of the fade.
            /// </summary>
            public float volumeBeg;
            /// <summary>
            /// The volume at the end of the fade.
            /// </summary>
            public float volumeEnd;
            /// <summary>
            /// The total length of the fade in PCM frames. Defaults to <c>(~(ma_uint64)0)</c> which indicates that no fade should be applied.
            /// </summary>
            public ma_uint64 fadeLengthInFrames;            /* <-- Defaults to (~(ma_uint64)0) which is used to indicate that no fade should be applied. */
            /// <summary>
            /// The absolute global time (in PCM frames) at which the fade should start.
            /// </summary>
            public ma_uint64 absoluteGlobalTimeInFrames;    /* <-- The time to start the fade. */
        }
    }

    /// <summary>
    /// Configuration for initializing a <see cref="ma_engine"/> object. The engine is a high-level API
    /// for managing and mixing sounds and effect processing, encapsulating a resource manager and a node graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine_config
    {
        /// <summary>
        /// A pointer to a resource manager. Can be null in which case a resource manager will be created for you.
        /// </summary>
        public ma_resource_manager_ptr pResourceManager;          /* Can be null in which case a resource manager will be created for you. */
        /// <summary>
        /// A pointer to the miniaudio context.
        /// </summary>
        public ma_context_ptr pContext;
        /// <summary>
        /// A pointer to a pre-initialized device. If set, the caller is responsible for calling <c>ma_engine_data_callback()</c> in the device's data callback.
        /// </summary>
        public ma_device_ptr pDevice;                             /* If set, the caller is responsible for calling ma_engine_data_callback() in the device's data callback. */
        /// <summary>
        /// The ID of the playback device to use with the default listener.
        /// </summary>
        public ma_device_id_ptr pPlaybackDeviceID;                /* The ID of the playback device to use with the default listener. */
        /// <summary>
        /// An optional custom device data callback. Can be null.
        /// </summary>
        public IntPtr dataCallback;               /* Can be null. Can be used to provide a custom device data callback. */
        /// <summary>
        /// An optional notification callback for device events.
        /// </summary>
        public IntPtr notificationCallback;
        /// <summary>
        /// A pointer to the log to use. When set to NULL, will use the context's log.
        /// </summary>
        public ma_log_ptr pLog;                                   /* When set to NULL, will use the context's log. */
        /// <summary>
        /// The number of spatialization listeners. Must be between 1 and <c>MA_ENGINE_MAX_LISTENERS</c>.
        /// </summary>
        public ma_uint32 listenerCount;                        /* Must be between 1 and MA_ENGINE_MAX_LISTENERS. */
        /// <summary>
        /// The number of channels to use when mixing and spatializing. When set to 0, will use the native channel count of the device.
        /// </summary>
        public ma_uint32 channels;                             /* The number of channels to use when mixing and spatializing. When set to 0, will use the native channel count of the device. */
        /// <summary>
        /// The sample rate. When set to 0 will use the native sample rate of the device.
        /// </summary>
        public ma_uint32 sampleRate;                           /* The sample rate. When set to 0 will use the native sample rate of the device. */
        /// <summary>
        /// If set to something other than 0, updates will always be exactly this size in frames.
        /// </summary>
        public ma_uint32 periodSizeInFrames;                   /* If set to something other than 0, updates will always be exactly this size. The underlying device may be a different size, but from the perspective of the mixer that won't matter.*/
        /// <summary>
        /// The period size in milliseconds. Used if <see cref="periodSizeInFrames"/> is unset.
        /// </summary>
        public ma_uint32 periodSizeInMilliseconds;             /* Used if periodSizeInFrames is unset. */
        /// <summary>
        /// The number of frames to interpolate the gain of spatialized sounds across. If set to 0, will use <see cref="gainSmoothTimeInMilliseconds"/>.
        /// </summary>
        public ma_uint32 gainSmoothTimeInFrames;               /* The number of frames to interpolate the gain of spatialized sounds across. If set to 0, will use gainSmoothTimeInMilliseconds. */
        /// <summary>
        /// The number of milliseconds to interpolate the gain of spatialized sounds across. When set to 0, <see cref="gainSmoothTimeInFrames"/> will be used. If both are 0, a default value is used.
        /// </summary>
        public ma_uint32 gainSmoothTimeInMilliseconds;         /* When set to 0, gainSmoothTimeInFrames will be used. If both are set to 0, a default value will be used. */
        /// <summary>
        /// Controls the default amount of smoothing to apply to volume changes to sounds. Defaults to 0. Higher values mean more smoothing at the expense of higher latency.
        /// </summary>
        public ma_uint32 defaultVolumeSmoothTimeInPCMFrames;   /* Defaults to 0. Controls the default amount of smoothing to apply to volume changes to sounds. High values means more smoothing at the expense of high latency (will take longer to reach the new volume). */
        /// <summary>
        /// The pre-mix stack size in bytes. Used for internal processing in the node graph. Smaller values reduce the maximum depth of your node graph.
        /// </summary>
        public ma_uint32 preMixStackSizeInBytes;               /* A stack is used for internal processing in the node graph. This allows you to configure the size of this stack. Smaller values will reduce the maximum depth of your node graph. You should rarely need to modify this. */
        /// <summary>
        /// Custom memory allocation callbacks.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// When set to true, requires an explicit call to <c>ma_engine_start()</c>. This is false by default, meaning the engine starts automatically in <c>ma_engine_init()</c>.
        /// </summary>
        public ma_bool32 noAutoStart;                          /* When set to true, requires an explicit call to ma_engine_start(). This is false by default, meaning the engine will be started automatically in ma_engine_init(). */
        /// <summary>
        /// When set to true, don't create a default device. <c>ma_engine_read_pcm_frames()</c> can be called manually to read data.
        /// </summary>
        public ma_bool32 noDevice;                             /* When set to true, don't create a default device. ma_engine_read_pcm_frames() can be called manually to read data. */
        /// <summary>
        /// Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;       /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        /// <summary>
        /// A pointer to a pre-allocated VFS object to use with the resource manager. This is ignored if <see cref="pResourceManager"/> is not NULL.
        /// </summary>
        public ma_vfs_ptr pResourceManagerVFS;                    /* A pointer to a pre-allocated VFS object to use with the resource manager. This is ignored if pResourceManager is not NULL. */
        /// <summary>
        /// Fired at the end of each call to <c>ma_engine_read_pcm_frames()</c>. For engines that manage their own internal device, this fires from the audio thread.
        /// </summary>
        public IntPtr onProcess;               /* Fired at the end of each call to ma_engine_read_pcm_frames(). For engine's that manage their own internal device (the default configuration), this will be fired from the audio thread, and you do not need to call ma_engine_read_pcm_frames() manually in order to trigger this. */
        /// <summary>
        /// User data that is passed into <see cref="onProcess"/>.
        /// </summary>
        public IntPtr pProcessUserData;                         /* User data that's passed into onProcess. */
        /// <summary>
        /// The resampling config to use with the resource manager.
        /// </summary>
        public ma_resampler_config resourceManagerResampling;  /* The resampling config to use with the resource manager. */
        /// <summary>
        /// The resampling config for the pitch and Doppler effects. You will typically want this to be a fast resampler.
        /// </summary>
        public ma_resampler_config pitchResampling;            /* The resampling config for the pitch and Doppler effects. You will typically want this to be a fast resampler. For high quality stuff, it's recommended that you pre-resample. */

        /// <summary>
        /// Sets the device data callback delegate.
        /// </summary>
        /// <param name="callback">The <see cref="ma_device_data_proc"/> delegate.</param>
        public void SetDataProc(ma_device_data_proc callback)
        {
            dataCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device notification callback delegate.
        /// </summary>
        /// <param name="callback">The <see cref="ma_device_notification_proc"/> delegate.</param>
        public void SetNotificationProc(ma_device_notification_proc callback)
        {
            notificationCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        
        /// <summary>
        /// Sets the engine process callback delegate.
        /// </summary>
        /// <param name="callback">The <see cref="ma_engine_process_proc"/> delegate.</param>
        public void SetEngineProcessProc(ma_engine_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents the runtime state of a miniaudio engine. The engine is a high-level API for managing
    /// and mixing sounds and effect processing. It encapsulates a node graph and optionally a resource manager
    /// and a playback device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_engine
    {
        /// <summary>
        /// An engine is a node graph and must be the first member for compatibility with the ma_node_graph API.
        /// </summary>
        public ma_node_graph nodeGraph;                        /* An engine is a node graph. It should be able to be plugged into any ma_node_graph API (with a cast) which means this must be the first member of this struct. */
        /// <summary>
        /// A pointer to the resource manager.
        /// </summary>
        public ma_resource_manager_ptr pResourceManager;
        /// <summary>
        /// A pointer to the device. Optionally set via the config, otherwise allocated by the engine in <c>ma_engine_init()</c>.
        /// </summary>
        public ma_device_ptr pDevice;                             /* Optionally set via the config, otherwise allocated by the engine in ma_engine_init(). */
        /// <summary>
        /// A pointer to the log.
        /// </summary>
        public ma_log_ptr pLog;
        /// <summary>
        /// The sample rate of the engine.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The number of spatialization listeners.
        /// </summary>
        public ma_uint32 listenerCount;
        /// <summary>
        /// The array of spatialization listeners. Each listener has a position, direction, and velocity for 3D audio.
        /// </summary>
        public ma_spatializer_listener_array listeners;
        /// <summary>
        /// Custom memory allocation callbacks.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// Whether the engine owns the resource manager.
        /// </summary>
        public ma_bool8 ownsResourceManager;
        /// <summary>
        /// Whether the engine owns the device.
        /// </summary>
        public ma_bool8 ownsDevice;
        /// <summary>
        /// A spinlock for synchronizing access to the inlined sound list.
        /// </summary>
        public ma_spinlock inlinedSoundLock;                   /* For synchronizing access to the inlined sound list. */
        /// <summary>
        /// The first inlined sound in the linked list. Inlined sounds are tracked in a linked list.
        /// </summary>
        public ma_sound_inlined_ptr pInlinedSoundHead;            /* The first inlined sound. Inlined sounds are tracked in a linked list. */
        /// <summary>
        /// The total number of allocated inlined sound objects. Used for debugging.
        /// </summary>
        public UInt32 inlinedSoundCount;      /* The total number of allocated inlined sound objects. Used for debugging. */
        /// <summary>
        /// The number of frames to interpolate the gain of spatialized sounds across.
        /// </summary>
        public ma_uint32 gainSmoothTimeInFrames;               /* The number of frames to interpolate the gain of spatialized sounds across. */
        /// <summary>
        /// The default amount of smoothing to apply to volume changes to sounds.
        /// </summary>
        public ma_uint32 defaultVolumeSmoothTimeInPCMFrames;
        /// <summary>
        /// Controls how a mono channel should be expanded to other channels when spatialization is disabled on a sound.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;
        /// <summary>
        /// The engine process callback, fired at the end of each call to <c>ma_engine_read_pcm_frames()</c>.
        /// </summary>
        public IntPtr onProcess;
        /// <summary>
        /// User data that is passed into <see cref="onProcess"/>.
        /// </summary>
        public IntPtr pProcessUserData;
        /// <summary>
        /// The resampling configuration for pitch effects.
        /// </summary>
        public ma_resampler_config pitchResamplingConfig;

        /// <summary>
        /// Sets the engine process callback delegate.
        /// </summary>
        /// <param name="callback">The <see cref="ma_engine_process_proc"/> delegate.</param>
        public void SetProcessProc(ma_engine_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Represents a fixed-size array of spatialization listeners. The engine supports up to
        /// <c>MA_ENGINE_MAX_LISTENERS</c> listeners (default 4) for 3D audio spatialization.
        /// Provides an indexer for accessing individual listeners.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct ma_spatializer_listener_array
        {
            /// <summary>
            /// Listener at index 0.
            /// </summary>
            public ma_spatializer_listener l0;
            /// <summary>
            /// Listener at index 1.
            /// </summary>
            public ma_spatializer_listener l1;
            /// <summary>
            /// Listener at index 2.
            /// </summary>
            public ma_spatializer_listener l2;
            /// <summary>
            /// Listener at index 3.
            /// </summary>
            public ma_spatializer_listener l3;
            /// <summary>
            /// Gets or sets the <see cref="ma_spatializer_listener"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the listener to get or set.</param>
            /// <returns>The <see cref="ma_spatializer_listener"/> at the specified index.</returns>
            /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than or equal to <c>MA_ENGINE_MAX_LISTENERS</c>.</exception>
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

    /// <summary>
    /// Configuration for a procedural data source.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_procedural_data_source_config
    {
        /// <summary>
        /// The sample format of the data source.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels in the data source.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate of the data source.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// Function pointer to the procedural callback.
        /// </summary>
        public IntPtr callback;
        /// <summary>
        /// User data pointer passed to the callback.
        /// </summary>
        public IntPtr pUserData;

        /// <summary>
        /// Sets the procedural data source callback.
        /// </summary>
        /// <param name="callback">The callback delegate to invoke for generating data.</param>
        public void SetCallback(ma_procedural_data_source_proc callback)
        {
            this.callback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents a procedural data source at runtime. Generates audio data programmatically via a callback.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_procedural_data_source
    {
        /// <summary>
        /// The base data source.
        /// </summary>
        public ma_data_source_base ds;
        /// <summary>
        /// The procedural data source configuration.
        /// </summary>
        public ma_procedural_data_source_config config;
    }

    /// <summary>
    /// Configuration for a fader that applies a volume ramp over a specified duration.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_fader_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public ma_uint32 sampleRate;
    }

    /// <summary>
    /// Represents a fader at runtime. Applies a linear volume ramp from one volume to another over a specified number of frames.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_fader
    {
        /// <summary>
        /// The fader configuration.
        /// </summary>
        public ma_fader_config config;
        /// <summary>
        /// The starting volume. If both volumeBeg and volumeEnd equal 1, no fading happens and the fader acts as a passthrough.
        /// </summary>
        public float volumeBeg;            /* If volumeBeg and volumeEnd is equal to 1, no fading happens (ma_fader_process_pcm_frames() will run as a passthrough). */
        /// <summary>
        /// The ending volume.
        /// </summary>
        public float volumeEnd;
        /// <summary>
        /// The total length of the fade in PCM frames.
        /// </summary>
        public ma_uint64 lengthInFrames;   /* The total length of the fade. */
        /// <summary>
        /// The current time in frames. Incremented by ma_fader_process_pcm_frames(). Signed because it will be offset by startOffsetInFrames in set_fade_ex().
        /// </summary>
        public ma_int64 cursorInFrames;   /* The current time in frames. Incremented by ma_fader_process_pcm_frames(). Signed because it'll be offset by startOffsetInFrames in set_fade_ex(). */
    }

    /// <summary>
    /// Holds a log callback function pointer and associated user data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_log_callback
    {
        /// <summary>
        /// Function pointer to the log callback.
        /// </summary>
        public IntPtr onLog;
        /// <summary>
        /// User data pointer passed to the log callback.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// Sets the log callback.
        /// </summary>
        /// <param name="callback">The log callback delegate.</param>
        public void SetLogCallback(ma_log_callback_proc callback)
        {
            onLog = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents the log system. Manages registered log callbacks and routes log messages to them.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_log
    {
        /// <summary>
        /// Array of registered log callbacks.
        /// </summary>
        public ma_log_callback_array callbacks;
        /// <summary>
        /// The number of registered callbacks.
        /// </summary>
        public ma_uint32 callbackCount;
        /// <summary>
        /// Allocation callbacks used for internal memory management. Stored persistently because ma_log_postv() might need to allocate a buffer on the heap.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks; /* Need to store these persistently because ma_log_postv() might need to allocate a buffer on the heap. */
        //There is a mutex here but the size depends on platform

        /// <summary>
        /// Fixed-size array of log callbacks with an indexer for access.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_log_callback_array
        {
            /// <summary>
            /// Callback slot 0.
            /// </summary>
            public ma_log_callback cb0;
            /// <summary>
            /// Callback slot 1.
            /// </summary>
            public ma_log_callback cb1;
            /// <summary>
            /// Callback slot 2.
            /// </summary>
            public ma_log_callback cb2;
            /// <summary>
            /// Callback slot 3.
            /// </summary>
            public ma_log_callback cb3;
            /// <summary>
            /// Indexed access to the callback array. Bounds-checked between 0 and MA_MAX_LOG_CALLBACKS-1.
            /// </summary>
            /// <param name="index">The index of the callback to access.</param>
            /// <returns>A reference to the callback at the given index.</returns>
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

    /// <summary>
    /// Configuration for a miniaudio context. Holds backend-specific settings and optional log system reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_context_config
    {
        /// <summary>
        /// Pointer to the log system. Can be null to use no logging.
        /// </summary>
        public ma_log_ptr pLog;
        /// <summary>
        /// The thread priority to use internally.
        /// </summary>
        public ma_thread_priority threadPriority;
        /// <summary>
        /// The thread stack size to use internally.
        /// </summary>
        public size_t threadStackSize;
        /// <summary>
        /// Application-defined user data.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// Allocation callbacks used for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// DirectSound backend-specific configuration.
        /// </summary>
        public dsound_info dsound;
        /// <summary>
        /// ALSA backend-specific configuration.
        /// </summary>
        public alsa_info alsa;
        /// <summary>
        /// PulseAudio backend-specific configuration.
        /// </summary>
        public pulse_info pulse;
        /// <summary>
        /// Core Audio backend-specific configuration.
        /// </summary>
        public coreaudio_info coreaudio;
        /// <summary>
        /// JACK backend-specific configuration.
        /// </summary>
        public jack_info jack;
        /// <summary>
        /// Custom backend callbacks.
        /// </summary>
        public ma_backend_callbacks custom;

        /// <summary>
        /// DirectSound-specific context configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct dsound_info
        {
            /// <summary>
            /// Optional window handle to pass into SetCooperativeLevel(). Will default to the foreground window, and if that fails, the desktop window.
            /// </summary>
            public ma_handle hWnd; /* HWND. Optional window handle to pass into SetCooperativeLevel(). Will default to the foreground window, and if that fails, the desktop window. */
        }

        /// <summary>
        /// ALSA-specific context configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct alsa_info
        {
            /// <summary>
            /// When set to true, uses verbose device enumeration.
            /// </summary>
            public ma_bool32 useVerboseDeviceEnumeration;
        }

        /// <summary>
        /// PulseAudio-specific context configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct pulse_info
        {
            /// <summary>
            /// The application name string to use with PulseAudio.
            /// </summary>
            public IntPtr pApplicationName;
            /// <summary>
            /// The server name string. Set to IntPtr.Zero to use the default server.
            /// </summary>
            public IntPtr pServerName;
            /// <summary>
            /// Enables autospawning of the PulseAudio daemon if necessary.
            /// </summary>
            public ma_bool32 tryAutoSpawn; /* Enables autospawning of the PulseAudio daemon if necessary. */
        }

        /// <summary>
        /// Core Audio-specific context configuration (iOS/macOS).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct coreaudio_info
        {
            /// <summary>
            /// The iOS session category.
            /// </summary>
            public ma_ios_session_category sessionCategory;
            /// <summary>
            /// Additional iOS session category options.
            /// </summary>
            public ma_uint32 sessionCategoryOptions;
            /// <summary>
            /// iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstance] setActive:true] on initialization.
            /// </summary>
            public ma_bool32 noAudioSessionActivate;   /* iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstace] setActive:true] on initialization. */
            /// <summary>
            /// iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstance] setActive:false] on uninitialization.
            /// </summary>
            public ma_bool32 noAudioSessionDeactivate; /* iOS only. When set to true, does not perform an explicit [[AVAudioSession sharedInstace] setActive:false] on uninitialization. */
        }

        /// <summary>
        /// JACK-specific context configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct jack_info
        {
            /// <summary>
            /// The client name to use with the JACK server.
            /// </summary>
            public IntPtr pClientName;
            /// <summary>
            /// When set to true, attempts to start the JACK server if it is not already running.
            /// </summary>
            public ma_bool32 tryStartServer;
        }
    }

    /// <summary>
    /// Represents a miniaudio context at runtime. Acts as the root object for managing backends, devices, and logging.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_context
    {
        /// <summary>
        /// Backend callbacks for the underlying audio backend implementation.
        /// </summary>
        public ma_backend_callbacks callbacks;
        /// <summary>
        /// The active backend (DirectSound, ALSA, etc.).
        /// </summary>
        public ma_backend backend;                 /* DirectSound, ALSA, etc. */
        /// <summary>
        /// Pointer to the log system.
        /// </summary>
        public ma_log_ptr pLog;
        /// <summary>
        /// Internal log instance used when the context owns the log. In this case, pLog will be set to point here.
        /// </summary>
        public ma_log log; /* Only used if the log is owned by the context. The pLog member will be set to &log in this case. */
        /// <summary>
        /// The thread priority used internally.
        /// </summary>
        public ma_thread_priority threadPriority;
        /// <summary>
        /// The thread stack size used internally.
        /// </summary>
        public size_t threadStackSize;
        /// <summary>
        /// Application-defined user data.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// Allocation callbacks used for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        //More (variable sized) fields here...
    }

    /// <summary>
    /// Represents a notification for a single stage in the resource manager pipeline (e.g. initialization or completion).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_pipeline_stage_notification
    {
        /// <summary>
        /// Pointer to an asynchronous notification to be signaled.
        /// </summary>
        public ma_async_notification_ptr pNotification;
        /// <summary>
        /// Pointer to a fence to be signaled.
        /// </summary>
        public ma_fence_ptr pFence;
    }

    /// <summary>
    /// Holds pipeline stage notifications for init (decoder initialization) and done (decoding fully completed) events.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_pipeline_notifications
    {
        /// <summary>
        /// Notification for initialization of the decoder.
        /// </summary>
        public ma_resource_manager_pipeline_stage_notification init;    /* Initialization of the decoder. */
        /// <summary>
        /// Notification for decoding fully completed.
        /// </summary>
        public ma_resource_manager_pipeline_stage_notification done;    /* Decoding fully completed. */
    }

    /// <summary>
    /// Holds function pointers for backend callbacks, allowing custom audio backends to be implemented.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_backend_callbacks
    {
        /// <summary>
        /// Function pointer for context initialization.
        /// </summary>
        public IntPtr onContextInit;
        /// <summary>
        /// Function pointer for context uninitialization.
        /// </summary>
        public IntPtr onContextUninit;
        /// <summary>
        /// Function pointer for enumerating devices on the context.
        /// </summary>
        public IntPtr onContextEnumerateDevices;
        /// <summary>
        /// Function pointer for getting device info from the context.
        /// </summary>
        public IntPtr onContextGetDeviceInfo;
        /// <summary>
        /// Function pointer for device initialization.
        /// </summary>
        public IntPtr onDeviceInit;
        /// <summary>
        /// Function pointer for device uninitialization.
        /// </summary>
        public IntPtr onDeviceUninit;
        /// <summary>
        /// Function pointer for starting the device.
        /// </summary>
        public IntPtr onDeviceStart;
        /// <summary>
        /// Function pointer for stopping the device.
        /// </summary>
        public IntPtr onDeviceStop;
        /// <summary>
        /// Function pointer for reading data from the device.
        /// </summary>
        public IntPtr onDeviceRead;
        /// <summary>
        /// Function pointer for writing data to the device.
        /// </summary>
        public IntPtr onDeviceWrite;
        /// <summary>
        /// Function pointer for the device data loop.
        /// </summary>
        public IntPtr onDeviceDataLoop;
        /// <summary>
        /// Function pointer for waking up the device data loop.
        /// </summary>
        public IntPtr onDeviceDataLoopWakeup;
        /// <summary>
        /// Function pointer for getting device information.
        /// </summary>
        public IntPtr onDeviceGetInfo;

        /// <summary>
        /// Sets the context initialization callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_context_init_proc callback)
        {
            onContextInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the context uninitialization callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_context_uninit_proc callback)
        {
            onContextUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the context device enumeration callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_context_enumerate_devices_proc callback)
        {
            onContextEnumerateDevices = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the context get device info callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_context_get_device_info_proc callback)
        {
            onContextGetDeviceInfo = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device initialization callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_init_proc callback)
        {
            onDeviceInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device uninitialization callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_uninit_proc callback)
        {
            onDeviceUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device start callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_start_proc callback)
        {
            onDeviceStart = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device stop callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_stop_proc callback)
        {
            onDeviceStop = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device read callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_read_proc callback)
        {
            onDeviceRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device write callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_write_proc callback)
        {
            onDeviceWrite = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device data loop callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_dataloop_proc callback)
        {
            onDeviceDataLoop = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device data loop wakeup callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_dataloop_wakeup_proc callback)
        {
            onDeviceDataLoopWakeup = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the device get info callback.
        /// </summary>
        /// <param name="callback">The callback delegate.</param>
        public void Set(ma_backend_device_get_info_proc callback)
        {
            onDeviceGetInfo = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Configuration for a sound that can be loaded from a file, an existing data source, or the resource manager.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_config
    {
        /// <summary>
        /// Set this to load from the resource manager using an ANSI file path.
        /// </summary>
        public IntPtr pFilePath;                      /* Set this to load from the resource manager. */
        /// <summary>
        /// Set this to load from the resource manager using a wide-char file path.
        /// </summary>
        public IntPtr pFilePathW;                  /* Set this to load from the resource manager. */
        /// <summary>
        /// Set this to load from an existing data source.
        /// </summary>
        public ma_data_source_ptr pDataSource;                /* Set this to load from an existing data source. */
        /// <summary>
        /// If set, the sound will be attached to an input of this node. This can be a ma_sound. If null, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in flags.
        /// </summary>
        public ma_node_ptr pInitialAttachment;                /* If set, the sound will be attached to an input of this node. This can be set to a ma_sound. If set to NULL, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in `flags`. */
        /// <summary>
        /// The index of the input bus of pInitialAttachment to attach the sound to.
        /// </summary>
        public ma_uint32 initialAttachmentInputBusIndex;   /* The index of the input bus of pInitialAttachment to attach the sound to. */
        /// <summary>
        /// Ignored if using a data source as input (the data source's channel count will be used always). Otherwise, setting to 0 will cause the engine's channel count to be used.
        /// </summary>
        public ma_uint32 channelsIn;                       /* Ignored if using a data source as input (the data source's channel count will be used always). Otherwise, setting to 0 will cause the engine's channel count to be used. */
        /// <summary>
        /// Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count.
        /// </summary>
        public ma_uint32 channelsOut;                      /* Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count (only used if using a data source as input). */
        /// <summary>
        /// Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;   /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        /// <summary>
        /// A combination of MA_SOUND_FLAG_* flags.
        /// </summary>
        public ma_uint32 flags;                            /* A combination of MA_SOUND_FLAG_* flags. */
        /// <summary>
        /// The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used.
        /// </summary>
        public ma_uint32 volumeSmoothTimeInPCMFrames;      /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        /// <summary>
        /// Initializes the sound such that it is seeked to this location by default.
        /// </summary>
        public ma_uint64 initialSeekPointInPCMFrames;      /* Initializes the sound such that it's seeked to this location by default. */
        /// <summary>
        /// The beginning of the range to play, in PCM frames.
        /// </summary>
        public ma_uint64 rangeBegInPCMFrames;
        /// <summary>
        /// The end of the range to play, in PCM frames.
        /// </summary>
        public ma_uint64 rangeEndInPCMFrames;
        /// <summary>
        /// The loop start point, in PCM frames.
        /// </summary>
        public ma_uint64 loopPointBegInPCMFrames;
        /// <summary>
        /// The loop end point, in PCM frames.
        /// </summary>
        public ma_uint64 loopPointEndInPCMFrames;
        /// <summary>
        /// Function pointer to the end callback, called when the sound finishes playing.
        /// </summary>
        public IntPtr endCallback;
        /// <summary>
        /// User data pointer passed to the end callback.
        /// </summary>
        public IntPtr pEndCallbackUserData;
        /// <summary>
        /// Resampler configuration for pitch changes.
        /// </summary>
        public ma_resampler_config pitchResampling;
        /// <summary>
        /// Notifications for initialization stages.
        /// </summary>
        public ma_resource_manager_pipeline_notifications initNotifications;
        /// <summary>
        /// Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams.
        /// </summary>
        public ma_fence_ptr pDoneFence;                       /* Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams. */
        /// <summary>
        /// Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in flags instead.
        /// </summary>
        public ma_bool32 isLooping;                        /* Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in `flags` instead. */

        /// <summary>
        /// Sets the end callback for the sound.
        /// </summary>
        /// <param name="callback">The callback delegate invoked when the sound finishes playing.</param>
        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents a sound at runtime. Wraps an engine node with data source access, seeking, and end-of-sound tracking.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound
    {
        /// <summary>
        /// Must be the first member for compatibility with the ma_node API.
        /// </summary>
        public ma_engine_node engineNode;          /* Must be the first member for compatibility with the ma_node API. */
        /// <summary>
        /// Pointer to the underlying data source.
        /// </summary>
        public ma_data_source_ptr pDataSource;
        /// <summary>
        /// The PCM frame index to seek to in the mixing thread. Set to (~(ma_uint64)0) to not perform any seeking.
        /// </summary>
        public ma_uint64 seekTarget; /* The PCM frame index to seek to in the mixing thread. Set to (~(ma_uint64)0) to not perform any seeking. */
        /// <summary>
        /// Whether the sound has reached the end.
        /// </summary>
        public ma_bool32 atEnd;
        /// <summary>
        /// Function pointer to the end callback.
        /// </summary>
        public IntPtr endCallback;
        /// <summary>
        /// User data passed to the end callback.
        /// </summary>
        public IntPtr pEndCallbackUserData;
        /// <summary>
        /// Processing cache buffer. Will be null if pDataSource is null.
        /// </summary>
        public IntPtr pProcessingCache;            /* Will be null if pDataSource is null. */ 
        /// <summary>
        /// Number of frames remaining in the processing cache.
        /// </summary>
        public ma_uint32 processingCacheFramesRemaining;
        /// <summary>
        /// Capacity of the processing cache.
        /// </summary>
        public ma_uint32 processingCacheCap;
        /// <summary>
        /// Whether this sound owns its data source.
        /// </summary>
        public ma_bool8 ownsDataSource;

        /*
        We're declaring a resource manager data source object here to save us a malloc when loading a
        sound via the resource manager, which I *think* will be the most common scenario.
        */
        /// <summary>
        /// Resource manager data source pointer, stored inline to save a malloc when loading via the resource manager.
        /// </summary>
        public ma_resource_manager_data_source_ptr pResourceManagerDataSource;

        /// <summary>
        /// Sets the end callback for the sound.
        /// </summary>
        /// <param name="callback">The callback delegate invoked when the sound finishes playing.</param>
        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents a sound inlined in a linked list. Contains next and previous pointers for list traversal.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_inlined
    {
        /// <summary>
        /// The sound itself.
        /// </summary>
        public ma_sound sound;
        /// <summary>
        /// Pointer to the next sound in the list.
        /// </summary>
        public ma_sound_inlined_ptr pNext;
        /// <summary>
        /// Pointer to the previous sound in the list.
        /// </summary>
        public ma_sound_inlined_ptr pPrev;
    }

    /// <summary>
    /// Configuration for a sound group. Groups multiple sounds together for collective control.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_sound_group_config
    {
        /// <summary>
        /// Set this to load from the resource manager using an ANSI file path.
        /// </summary>
        public IntPtr pFilePath;                      /* Set this to load from the resource manager. */
        /// <summary>
        /// Set this to load from the resource manager using a wide-char file path.
        /// </summary>
        public IntPtr pFilePathW;                  /* Set this to load from the resource manager. */
        /// <summary>
        /// Set this to load from an existing data source.
        /// </summary>
        public ma_data_source_ptr pDataSource;                /* Set this to load from an existing data source. */
        /// <summary>
        /// If set, the sound will be attached to an input of this node. This can be a ma_sound. If null, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in flags.
        /// </summary>
        public ma_node_ptr pInitialAttachment;                /* If set, the sound will be attached to an input of this node. This can be set to a ma_sound. If set to NULL, the sound will be attached directly to the endpoint unless MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT is set in `flags`. */
        /// <summary>
        /// The index of the input bus of pInitialAttachment to attach the sound to.
        /// </summary>
        public ma_uint32 initialAttachmentInputBusIndex;   /* The index of the input bus of pInitialAttachment to attach the sound to. */
        /// <summary>
        /// Ignored if using a data source as input. Otherwise, setting to 0 will cause the engine's channel count to be used.
        /// </summary>
        public ma_uint32 channelsIn;                       /* Ignored if using a data source as input (the data source's channel count will be used always). Otherwise, setting to 0 will cause the engine's channel count to be used. */
        /// <summary>
        /// Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count.
        /// </summary>
        public ma_uint32 channelsOut;                      /* Set this to 0 (default) to use the engine's channel count. Set to MA_SOUND_SOURCE_CHANNEL_COUNT to use the data source's channel count (only used if using a data source as input). */
        /// <summary>
        /// Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound.
        /// </summary>
        public ma_mono_expansion_mode monoExpansionMode;   /* Controls how the mono channel should be expanded to other channels when spatialization is disabled on a sound. */
        /// <summary>
        /// A combination of MA_SOUND_FLAG_* flags.
        /// </summary>
        public ma_uint32 flags;                            /* A combination of MA_SOUND_FLAG_* flags. */
        /// <summary>
        /// The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used.
        /// </summary>
        public ma_uint32 volumeSmoothTimeInPCMFrames;      /* The number of frames to smooth over volume changes. Defaults to 0 in which case no smoothing is used. */
        /// <summary>
        /// Initializes the sound such that it is seeked to this location by default.
        /// </summary>
        public ma_uint64 initialSeekPointInPCMFrames;      /* Initializes the sound such that it's seeked to this location by default. */
        /// <summary>
        /// The beginning of the range to play, in PCM frames.
        /// </summary>
        public ma_uint64 rangeBegInPCMFrames;
        /// <summary>
        /// The end of the range to play, in PCM frames.
        /// </summary>
        public ma_uint64 rangeEndInPCMFrames;
        /// <summary>
        /// The loop start point, in PCM frames.
        /// </summary>
        public ma_uint64 loopPointBegInPCMFrames;
        /// <summary>
        /// The loop end point, in PCM frames.
        /// </summary>
        public ma_uint64 loopPointEndInPCMFrames;
        /// <summary>
        /// Function pointer to the end callback, called when the sound finishes playing.
        /// </summary>
        public IntPtr endCallback;
        /// <summary>
        /// User data pointer passed to the end callback.
        /// </summary>
        public IntPtr pEndCallbackUserData;
        /// <summary>
        /// Notifications for initialization stages.
        /// </summary>
        public ma_resource_manager_pipeline_notifications initNotifications;
        /// <summary>
        /// Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams.
        /// </summary>
        public ma_fence_ptr pDoneFence;                       /* Deprecated. Use initNotifications instead. Released when the resource manager has finished decoding the entire sound. Not used with streams. */
        /// <summary>
        /// Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in flags instead.
        /// </summary>
        public ma_bool32 isLooping;                        /* Deprecated. Use the MA_SOUND_FLAG_LOOPING flag in `flags` instead. */

        /// <summary>
        /// Sets the end callback for the sound group.
        /// </summary>
        /// <param name="callback">The callback delegate invoked when the sound finishes playing.</param>
        public void SetEndCallback(ma_sound_end_proc callback)
        {
            endCallback = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Describes a native data format supported by a device (format, channels, sample rate, flags).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_native_data_format
    {
        /// <summary>
        /// The sample format. If set to ma_format_unknown, all formats are supported.
        /// </summary>
        public ma_uint32 format; // Assuming ma_format is a uint. Adjust as necessary.
        /// <summary>
        /// The number of channels. If set to 0, all channels are supported.
        /// </summary>
        public ma_uint32 channels; // If set to 0, all channels are supported.
        /// <summary>
        /// The sample rate. If set to 0, all sample rates are supported.
        /// </summary>
        public ma_uint32 sampleRate; // If set to 0, all sample rates are supported.
        /// <summary>
        /// A combination of MA_DATA_FORMAT_FLAG_* flags.
        /// </summary>
        public ma_uint32 flags; // A combination of MA_DATA_FORMAT_FLAG_* flags.
    }

    /// <summary>
    /// Contains information about an audio device including its ID, name, and supported native data formats.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_info
    {
        /* Basic info. This is the only information guaranteed to be filled in during device enumeration. */
        /// <summary>
        /// The unique device identifier.
        /// </summary>
        public ma_device_id id;
        /// <summary>
        /// The device name (fixed-size UTF-8 buffer). Use GetName() to retrieve as a string.
        /// </summary>
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1];
        /// <summary>
        /// Whether this device is the system default device.
        /// </summary>
        public ma_bool32 isDefault;
        /// <summary>
        /// The number of native data formats supported by this device.
        /// </summary>
        public ma_uint32 nativeDataFormatCount;
        /// <summary>
        /// Array of native data formats supported by this device.
        /// </summary>
        public ma_native_data_format_array nativeDataFormats;

        /// <summary>
        /// Gets the device name as a managed UTF-8 string.
        /// </summary>
        /// <returns>The device name, or an empty string if no name is set.</returns>
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

        /// <summary>
        /// Fixed-size array of native data formats with an indexer for access.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_native_data_format_array
        {
            /// <summary>
            /// Native data format slot 0.
            /// </summary>
            public ma_native_data_format ndf0;
            /// <summary>
            /// Native data format slot 1.
            /// </summary>
            public ma_native_data_format ndf1;
            /// <summary>
            /// Native data format slot 2.
            /// </summary>
            public ma_native_data_format ndf2;
            /// <summary>
            /// Native data format slot 3.
            /// </summary>
            public ma_native_data_format ndf3;
            /// <summary>
            /// Native data format slot 4.
            /// </summary>
            public ma_native_data_format ndf4;
            /// <summary>
            /// Native data format slot 5.
            /// </summary>
            public ma_native_data_format ndf5;
            /// <summary>
            /// Native data format slot 6.
            /// </summary>
            public ma_native_data_format ndf6;
            /// <summary>
            /// Native data format slot 7.
            /// </summary>
            public ma_native_data_format ndf7;
            /// <summary>
            /// Native data format slot 8.
            /// </summary>
            public ma_native_data_format ndf8;
            /// <summary>
            /// Native data format slot 9.
            /// </summary>
            public ma_native_data_format ndf9;
            /// <summary>
            /// Native data format slot 10.
            /// </summary>
            public ma_native_data_format ndf10;
            /// <summary>
            /// Native data format slot 11.
            /// </summary>
            public ma_native_data_format ndf11;
            /// <summary>
            /// Native data format slot 12.
            /// </summary>
            public ma_native_data_format ndf12;
            /// <summary>
            /// Native data format slot 13.
            /// </summary>
            public ma_native_data_format ndf13;
            /// <summary>
            /// Native data format slot 14.
            /// </summary>
            public ma_native_data_format ndf14;
            /// <summary>
            /// Native data format slot 15.
            /// </summary>
            public ma_native_data_format ndf15;
            /// <summary>
            /// Native data format slot 16.
            /// </summary>
            public ma_native_data_format ndf16;
            /// <summary>
            /// Native data format slot 17.
            /// </summary>
            public ma_native_data_format ndf17;
            /// <summary>
            /// Native data format slot 18.
            /// </summary>
            public ma_native_data_format ndf18;
            /// <summary>
            /// Native data format slot 19.
            /// </summary>
            public ma_native_data_format ndf19;
            /// <summary>
            /// Native data format slot 20.
            /// </summary>
            public ma_native_data_format ndf20;
            /// <summary>
            /// Native data format slot 21.
            /// </summary>
            public ma_native_data_format ndf21;
            /// <summary>
            /// Native data format slot 22.
            /// </summary>
            public ma_native_data_format ndf22;
            /// <summary>
            /// Native data format slot 23.
            /// </summary>
            public ma_native_data_format ndf23;
            /// <summary>
            /// Native data format slot 24.
            /// </summary>
            public ma_native_data_format ndf24;
            /// <summary>
            /// Native data format slot 25.
            /// </summary>
            public ma_native_data_format ndf25;
            /// <summary>
            /// Native data format slot 26.
            /// </summary>
            public ma_native_data_format ndf26;
            /// <summary>
            /// Native data format slot 27.
            /// </summary>
            public ma_native_data_format ndf27;
            /// <summary>
            /// Native data format slot 28.
            /// </summary>
            public ma_native_data_format ndf28;
            /// <summary>
            /// Native data format slot 29.
            /// </summary>
            public ma_native_data_format ndf29;
            /// <summary>
            /// Native data format slot 30.
            /// </summary>
            public ma_native_data_format ndf30;
            /// <summary>
            /// Native data format slot 31.
            /// </summary>
            public ma_native_data_format ndf31;
            /// <summary>
            /// Native data format slot 32.
            /// </summary>
            public ma_native_data_format ndf32;
            /// <summary>
            /// Native data format slot 33.
            /// </summary>
            public ma_native_data_format ndf33;
            /// <summary>
            /// Native data format slot 34.
            /// </summary>
            public ma_native_data_format ndf34;
            /// <summary>
            /// Native data format slot 35.
            /// </summary>
            public ma_native_data_format ndf35;
            /// <summary>
            /// Native data format slot 36.
            /// </summary>
            public ma_native_data_format ndf36;
            /// <summary>
            /// Native data format slot 37.
            /// </summary>
            public ma_native_data_format ndf37;
            /// <summary>
            /// Native data format slot 38.
            /// </summary>
            public ma_native_data_format ndf38;
            /// <summary>
            /// Native data format slot 39.
            /// </summary>
            public ma_native_data_format ndf39;
            /// <summary>
            /// Native data format slot 40.
            /// </summary>
            public ma_native_data_format ndf40;
            /// <summary>
            /// Native data format slot 41.
            /// </summary>
            public ma_native_data_format ndf41;
            /// <summary>
            /// Native data format slot 42.
            /// </summary>
            public ma_native_data_format ndf42;
            /// <summary>
            /// Native data format slot 43.
            /// </summary>
            public ma_native_data_format ndf43;
            /// <summary>
            /// Native data format slot 44.
            /// </summary>
            public ma_native_data_format ndf44;
            /// <summary>
            /// Native data format slot 45.
            /// </summary>
            public ma_native_data_format ndf45;
            /// <summary>
            /// Native data format slot 46.
            /// </summary>
            public ma_native_data_format ndf46;
            /// <summary>
            /// Native data format slot 47.
            /// </summary>
            public ma_native_data_format ndf47;
            /// <summary>
            /// Native data format slot 48.
            /// </summary>
            public ma_native_data_format ndf48;
            /// <summary>
            /// Native data format slot 49.
            /// </summary>
            public ma_native_data_format ndf49;
            /// <summary>
            /// Native data format slot 50.
            /// </summary>
            public ma_native_data_format ndf50;
            /// <summary>
            /// Native data format slot 51.
            /// </summary>
            public ma_native_data_format ndf51;
            /// <summary>
            /// Native data format slot 52.
            /// </summary>
            public ma_native_data_format ndf52;
            /// <summary>
            /// Native data format slot 53.
            /// </summary>
            public ma_native_data_format ndf53;
            /// <summary>
            /// Native data format slot 54.
            /// </summary>
            public ma_native_data_format ndf54;
            /// <summary>
            /// Native data format slot 55.
            /// </summary>
            public ma_native_data_format ndf55;
            /// <summary>
            /// Native data format slot 56.
            /// </summary>
            public ma_native_data_format ndf56;
            /// <summary>
            /// Native data format slot 57.
            /// </summary>
            public ma_native_data_format ndf57;
            /// <summary>
            /// Native data format slot 58.
            /// </summary>
            public ma_native_data_format ndf58;
            /// <summary>
            /// Native data format slot 59.
            /// </summary>
            public ma_native_data_format ndf59;
            /// <summary>
            /// Native data format slot 60.
            /// </summary>
            public ma_native_data_format ndf60;
            /// <summary>
            /// Native data format slot 61.
            /// </summary>
            public ma_native_data_format ndf61;
            /// <summary>
            /// Native data format slot 62.
            /// </summary>
            public ma_native_data_format ndf62;
            /// <summary>
            /// Native data format slot 63.
            /// </summary>
            public ma_native_data_format ndf63;
            /// <summary>
            /// Indexed access to the native data format array. Bounds-checked between 0 and 63.
            /// </summary>
            /// <param name="index">The index of the native data format to access.</param>
            /// <returns>A reference to the native data format at the given index.</returns>
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

    /// <summary>
    /// Configuration for a resampler. Specifies input/output formats, channel counts, sample rates, and algorithm.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resampler_config
    {
        /// <summary>
        /// The sample format. Must be either ma_format_f32 or ma_format_s16.
        /// </summary>
        public ma_format format;   /* Must be either ma_format_f32 or ma_format_s16. */
        /// <summary>
        /// The number of channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The input sample rate.
        /// </summary>
        public ma_uint32 sampleRateIn;
        /// <summary>
        /// The output sample rate.
        /// </summary>
        public ma_uint32 sampleRateOut;
        /// <summary>
        /// The resampling algorithm. When set to ma_resample_algorithm_custom, pBackendVTable will be used.
        /// </summary>
        public ma_resample_algorithm algorithm;    /* When set to ma_resample_algorithm_custom, pBackendVTable will be used. */
        /// <summary>
        /// Pointer to a custom backend vtable for resampling.
        /// </summary>
        public ma_resampling_backend_vtable_ptr pBackendVTable;
        /// <summary>
        /// User data for the custom resampling backend.
        /// </summary>
        public IntPtr pBackendUserData;
        /// <summary>
        /// Linear resampler specific configuration.
        /// </summary>
        public linear_info linear;
        /// <summary>
        /// Linear resampler specific info controlling the low-pass filter order.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct linear_info
        {
            /// <summary>
            /// The low-pass filter order for the linear resampler.
            /// </summary>
            public ma_uint32 lpfOrder;
        }
    }

    /// <summary>
    /// Configuration for an audio device. Specifies device type, format, period size, callbacks, and backend-specific options.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device_config
    {
        /// <summary>
        /// The type of device (playback, capture, duplex, or loopback).
        /// </summary>
        public ma_device_type deviceType;
        /// <summary>
        /// The requested sample rate.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The requested period size in frames.
        /// </summary>
        public ma_uint32 periodSizeInFrames;
        /// <summary>
        /// The requested period size in milliseconds.
        /// </summary>
        public ma_uint32 periodSizeInMilliseconds;
        /// <summary>
        /// The number of periods.
        /// </summary>
        public ma_uint32 periods;
        /// <summary>
        /// The performance profile for the device.
        /// </summary>
        public ma_performance_profile performanceProfile;
        /// <summary>
        /// When set to true, the contents of the output buffer passed into the data callback will be left undefined rather than initialized to silence.
        /// </summary>
        public ma_bool8 noPreSilencedOutputBuffer; /* When set to true, the contents of the output buffer passed into the data callback will be left undefined rather than initialized to silence. */
        /// <summary>
        /// When set to true, the contents of the output buffer passed into the data callback will not be clipped after returning. Only applies when the playback sample format is f32.
        /// </summary>
        public ma_bool8 noClip;                    /* When set to true, the contents of the output buffer passed into the data callback will not be clipped after returning. Only applies when the playback sample format is f32. */
        /// <summary>
        /// Do not disable denormals when firing the data callback.
        /// </summary>
        public ma_bool8 noDisableDenormals;        /* Do not disable denormals when firing the data callback. */
        /// <summary>
        /// Disables strict fixed-sized data callbacks. Setting this to true will result in the period size being treated only as a hint to the backend.
        /// </summary>
        public ma_bool8 noFixedSizedCallback;      /* Disables strict fixed-sized data callbacks. Setting this to true will result in the period size being treated only as a hint to the backend. This is an optimization for those who don't need fixed sized callbacks. */
        /// <summary>
        /// Function pointer to the data callback.
        /// </summary>
        public IntPtr dataCallback;
        /// <summary>
        /// Function pointer to the notification callback.
        /// </summary>
        public IntPtr notificationCallback;
        /// <summary>
        /// Function pointer to the stop callback (DEPRECATED, use notification callback instead).
        /// </summary>
        public IntPtr stopCallback;
        /// <summary>
        /// Application-defined user data.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// Resampling configuration.
        /// </summary>
        public ma_resampler_config resampling;
        /// <summary>
        /// Playback-specific configuration.
        /// </summary>
        public playback_info playback;
        /// <summary>
        /// Capture-specific configuration.
        /// </summary>
        public capture_info capture;
        /// <summary>
        /// WASAPI-specific configuration.
        /// </summary>
        public wasapi_info wasapi;
        /// <summary>
        /// ALSA-specific configuration.
        /// </summary>
        public alsa_info alsa;
        /// <summary>
        /// PulseAudio-specific configuration.
        /// </summary>
        public pulse_info pulse;
        /// <summary>
        /// Core Audio-specific configuration.
        /// </summary>
        public coreaudio_info coreaudio;
        /// <summary>
        /// OpenSL|ES-specific configuration.
        /// </summary>
        public opensl_info opensl;
        /// <summary>
        /// AAudio-specific configuration.
        /// </summary>
        public aaudio_info aaudio;

        /// <summary>
        /// Playback sub-configuration specifying the playback device, format, channels, and channel mix mode.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct playback_info
        {
            /// <summary>
            /// Pointer to the device ID. Set to null for default device.
            /// </summary>
            public ma_device_id_ptr pDeviceID;
            /// <summary>
            /// The playback sample format.
            /// </summary>
            public ma_format format;
            /// <summary>
            /// The number of playback channels.
            /// </summary>
            public ma_uint32 channels;
            /// <summary>
            /// Pointer to the channel map for the playback device.
            /// </summary>
            public ma_channel_ptr pChannelMap;
            /// <summary>
            /// The channel mix mode for the playback device.
            /// </summary>
            public ma_channel_mix_mode channelMixMode;
            /// <summary>
            /// When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels.
            /// </summary>
            public ma_bool32 calculateLFEFromSpatialChannels;  /* When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels (LR, FR, etc.). Ignored when an input LFE is present. */
            /// <summary>
            /// The share mode for the playback device.
            /// </summary>
            public ma_share_mode shareMode;
        }

        /// <summary>
        /// Capture sub-configuration specifying the capture device, format, channels, and channel mix mode.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct capture_info
        {
            /// <summary>
            /// Pointer to the device ID. Set to null for default device.
            /// </summary>
            public ma_device_id_ptr pDeviceID;
            /// <summary>
            /// The capture sample format.
            /// </summary>
            public ma_format format;
            /// <summary>
            /// The number of capture channels.
            /// </summary>
            public ma_uint32 channels;
            /// <summary>
            /// Pointer to the channel map for the capture device.
            /// </summary>
            public ma_channel_ptr pChannelMap;
            /// <summary>
            /// The channel mix mode for the capture device.
            /// </summary>
            public ma_channel_mix_mode channelMixMode;
            /// <summary>
            /// When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels.
            /// </summary>
            public ma_bool32 calculateLFEFromSpatialChannels;  /* When an output LFE channel is present, but no input LFE, set to true to set the output LFE to the average of all spatial channels (LR, FR, etc.). Ignored when an input LFE is present. */
            /// <summary>
            /// The share mode for the capture device.
            /// </summary>
            public ma_share_mode shareMode;
        }

        /// <summary>
        /// WASAPI-specific device configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct wasapi_info
        {
            /// <summary>
            /// When configured, uses Avrt APIs to set the thread characteristics.
            /// </summary>
            public ma_wasapi_usage usage;              /* When configured, uses Avrt APIs to set the thread characteristics. */
            /// <summary>
            /// When set to true, disables the use of AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM.
            /// </summary>
            public ma_bool8 noAutoConvertSRC;          /* When set to true, disables the use of AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM. */
            /// <summary>
            /// When set to true, disables the use of AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY.
            /// </summary>
            public ma_bool8 noDefaultQualitySRC;       /* When set to true, disables the use of AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY. */
            /// <summary>
            /// Disables automatic stream routing.
            /// </summary>
            public ma_bool8 noAutoStreamRouting;       /* Disables automatic stream routing. */
            /// <summary>
            /// Disables WASAPI's hardware offloading feature.
            /// </summary>
            public ma_bool8 noHardwareOffloading;      /* Disables WASAPI's hardware offloading feature. */
            /// <summary>
            /// The process ID to include or exclude for loopback mode. Set to 0 to capture audio from all processes.
            /// </summary>
            public ma_uint32 loopbackProcessID;        /* The process ID to include or exclude for loopback mode. Set to 0 to capture audio from all processes. Ignored when an explicit device ID is specified. */
            /// <summary>
            /// When set to true, excludes the process specified by loopbackProcessID. By default, the process will be included.
            /// </summary>
            public ma_bool8 loopbackProcessExclude;    /* When set to true, excludes the process specified by loopbackProcessID. By default, the process will be included. */
        }

        /// <summary>
        /// ALSA-specific device configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct alsa_info
        {
            /// <summary>
            /// Disables MMap mode.
            /// </summary>
            public ma_bool32 noMMap;           /* Disables MMap mode. */
            /// <summary>
            /// Opens the ALSA device with SND_PCM_NO_AUTO_FORMAT.
            /// </summary>
            public ma_bool32 noAutoFormat;     /* Opens the ALSA device with SND_PCM_NO_AUTO_FORMAT. */
            /// <summary>
            /// Opens the ALSA device with SND_PCM_NO_AUTO_CHANNELS.
            /// </summary>
            public ma_bool32 noAutoChannels;   /* Opens the ALSA device with SND_PCM_NO_AUTO_CHANNELS. */
            /// <summary>
            /// Opens the ALSA device with SND_PCM_NO_AUTO_RESAMPLE.
            /// </summary>
            public ma_bool32 noAutoResample;   /* Opens the ALSA device with SND_PCM_NO_AUTO_RESAMPLE. */
        }

        /// <summary>
        /// PulseAudio-specific device configuration.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct pulse_info
        {
            /// <summary>
            /// The stream name for playback.
            /// </summary>
            public IntPtr pStreamNamePlayback;
            /// <summary>
            /// The stream name for capture.
            /// </summary>
            public IntPtr pStreamNameCapture;
            /// <summary>
            /// The channel map for PulseAudio.
            /// </summary>
            public int channelMap;
        }

        /// <summary>
        /// Core Audio-specific device configuration (macOS).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct coreaudio_info
        {
            /// <summary>
            /// Desktop only. When enabled, allows changing of the sample rate at the operating system level.
            /// </summary>
            public ma_bool32 allowNominalSampleRateChange; /* Desktop only. When enabled, allows changing of the sample rate at the operating system level. */
        }

        /// <summary>
        /// OpenSL|ES-specific device configuration (Android).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct opensl_info
        {
            /// <summary>
            /// The OpenSL|ES stream type.
            /// </summary>
            public ma_opensl_stream_type streamType;
            /// <summary>
            /// The OpenSL|ES recording preset.
            /// </summary>
            public ma_opensl_recording_preset recordingPreset;
            /// <summary>
            /// Enables compatibility workarounds for OpenSL|ES.
            /// </summary>
            public ma_bool32 enableCompatibilityWorkarounds;
        }

        /// <summary>
        /// AAudio-specific device configuration (Android).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct aaudio_info
        {
            /// <summary>
            /// The AAudio usage hint.
            /// </summary>
            public ma_aaudio_usage usage;
            /// <summary>
            /// The AAudio content type.
            /// </summary>
            public ma_aaudio_content_type contentType;
            /// <summary>
            /// The AAudio input preset.
            /// </summary>
            public ma_aaudio_input_preset inputPreset;
            /// <summary>
            /// The AAudio allowed capture policy.
            /// </summary>
            public ma_aaudio_allowed_capture_policy allowedCapturePolicy;
            /// <summary>
            /// When set to true, does not auto-start the stream after a reroute.
            /// </summary>
            public ma_bool32 noAutoStartAfterReroute;
            /// <summary>
            /// Enables compatibility workarounds for AAudio.
            /// </summary>
            public ma_bool32 enableCompatibilityWorkarounds;
            /// <summary>
            /// When set to true, allows setting the buffer capacity.
            /// </summary>
            public ma_bool32 allowSetBufferCapacity;
        }

        /// <summary>
        /// Sets the data callback for the device.
        /// </summary>
        /// <param name="dataCallback">The data callback delegate.</param>
        public void SetDataCallback(ma_device_data_proc dataCallback)
        {
            this.dataCallback = MarshalHelper.GetFunctionPointerForDelegate(dataCallback);
        }

        /// <summary>
        /// Sets the notification callback for the device.
        /// </summary>
        /// <param name="notificationCallback">The notification callback delegate.</param>
        public void SetNotificationCallback(ma_device_notification_proc notificationCallback)
        {
            this.notificationCallback = MarshalHelper.GetFunctionPointerForDelegate(notificationCallback);
        }

        /// <summary>
        /// Sets the stop callback for the device (DEPRECATED).
        /// </summary>
        /// <param name="stopCallback">The stop callback delegate.</param>
        public void SetStopCallback(ma_stop_proc stopCallback)
        {
            this.stopCallback = MarshalHelper.GetFunctionPointerForDelegate(stopCallback);
        }
    }

    /// <summary>
    /// A union structure representing the device ID across different backends (WASAPI, DirectSound, ALSA, PulseAudio, JACK, CoreAudio, etc.).
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 256)] // largest member size determines union size
    public unsafe struct ma_device_id
    {
        /// <summary>
        /// WASAPI device identifier (wide-char array).
        /// </summary>
        [FieldOffset(0)]
        public fixed ma_uint16 wasapi[64];
        /// <summary>
        /// DirectSound device identifier (GUID).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte dsound[16];
        /// <summary>
        /// WinMM device identifier (integer).
        /// </summary>
        [FieldOffset(0)]
        public ma_uint32 winmm;
        /// <summary>
        /// ALSA device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte alsa[256];
        /// <summary>
        /// PulseAudio device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte pulse[256];
        /// <summary>
        /// JACK device identifier (integer).
        /// </summary>
        [FieldOffset(0)]
        public int jack;
        /// <summary>
        /// Core Audio device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte coreaudio[256];
        /// <summary>
        /// sndio device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte sndio[256];
        /// <summary>
        /// Audio4 device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte audio4[256];
        /// <summary>
        /// OSS device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte oss[64];
        /// <summary>
        /// AAudio device identifier (integer).
        /// </summary>
        [FieldOffset(0)]
        public int aaudio;
        /// <summary>
        /// OpenSL|ES device identifier (unsigned integer).
        /// </summary>
        [FieldOffset(0)]
        public uint opensl;
        /// <summary>
        /// Web Audio device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte webaudio[32];
        /// <summary>
        /// Custom backend device identifier (integer).
        /// </summary>
        [FieldOffset(0)]
        public int custom_i;
        /// <summary>
        /// Custom backend device identifier (string).
        /// </summary>
        [FieldOffset(0)]
        public fixed byte custom_s[256];
        /// <summary>
        /// Custom backend device identifier (pointer).
        /// </summary>
        [FieldOffset(0)]
        public IntPtr custom_p;
        /// <summary>
        /// Null backend device identifier (integer).
        /// </summary>
        [FieldOffset(0)]
        public int nullbackend;
    }

    /// <summary>
    /// Configuration for device-side resampling.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device_resampling
    {
        /// <summary>
        /// The resampling algorithm to use.
        /// </summary>
        public ma_resample_algorithm algorithm;
        /// <summary>
        /// Pointer to a custom backend vtable for resampling.
        /// </summary>
        public ma_resampling_backend_vtable_ptr pBackendVTable;
        /// <summary>
        /// User data for the custom resampling backend.
        /// </summary>
        public IntPtr pBackendUserData;
        /// <summary>
        /// Linear resampler specific configuration.
        /// </summary>
        public ma_device_lpf_order linear;
        /// <summary>
        /// Low-pass filter order for the device's linear resampler.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_device_lpf_order
        {
            /// <summary>
            /// The low-pass filter order.
            /// </summary>
            ma_uint32 lpfOrder;
        }
    }

    /// <summary>
    /// Runtime state for the playback side of a device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_playback
    {
        /// <summary>
        /// Set to NULL if using default ID, otherwise set to the address of the id field.
        /// </summary>
        public ma_device_id_ptr pID;                  /* Set to NULL if using default ID, otherwise set to the address of "id". */
        /// <summary>
        /// If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0.
        /// </summary>
        public ma_device_id id;                    /* If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0. */
        /// <summary>
        /// The device name (fixed-size buffer). Maybe temporary; likely to be replaced with a query API.
        /// </summary>
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1]; /* Maybe temporary. Likely to be replaced with a query API. */
        /// <summary>
        /// The share mode used when the device was initialized.
        /// </summary>
        public ma_share_mode shareMode;            /* Set to whatever was passed in when the device was initialized. */
        /// <summary>
        /// The external playback format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The external playback channel count.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The external playback channel map.
        /// </summary>
        public fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        /// <summary>
        /// The internal format used by the backend.
        /// </summary>
        public ma_format internalFormat;
        /// <summary>
        /// The internal channel count used by the backend.
        /// </summary>
        public ma_uint32 internalChannels;
        /// <summary>
        /// The internal sample rate used by the backend.
        /// </summary>
        public ma_uint32 internalSampleRate;
        /// <summary>
        /// The internal channel map used by the backend.
        /// </summary>
        public fixed ma_channel internalChannelMap[MiniAudioNative.MA_MAX_CHANNELS];
        /// <summary>
        /// The internal period size in frames.
        /// </summary>
        public ma_uint32 internalPeriodSizeInFrames;
        /// <summary>
        /// The internal number of periods.
        /// </summary>
        public ma_uint32 internalPeriods;
        /// <summary>
        /// The channel mix mode for playback.
        /// </summary>
        public ma_channel_mix_mode channelMixMode;
        /// <summary>
        /// Whether to calculate LFE from spatial channels when an output LFE is present but no input LFE.
        /// </summary>
        public ma_bool32 calculateLFEFromSpatialChannels;
        /// <summary>
        /// The data converter for format/channel conversion.
        /// </summary>
        public ma_data_converter converter;
        /// <summary>
        /// Intermediary buffer for implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks.
        /// </summary>
        public IntPtr pIntermediaryBuffer;          /* For implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks. */
        /// <summary>
        /// Capacity of the intermediary buffer.
        /// </summary>
        public ma_uint32 intermediaryBufferCap;
        /// <summary>
        /// Number of valid frames sitting in the intermediary buffer.
        /// </summary>
        public ma_uint32 intermediaryBufferLen;    /* How many valid frames are sitting in the intermediary buffer. */
        /// <summary>
        /// Input cache buffer in external format. Can be null.
        /// </summary>
        public IntPtr pInputCache;                  /* In external format. Can be null. */
        /// <summary>
        /// Capacity of the input cache.
        /// </summary>
        public ma_uint64 inputCacheCap;
        /// <summary>
        /// Number of frames consumed from the input cache.
        /// </summary>
        public ma_uint64 inputCacheConsumed;
        /// <summary>
        /// Number of valid frames remaining in the input cache.
        /// </summary>
        public ma_uint64 inputCacheRemaining;
    }

    /// <summary>
    /// Runtime state for the capture side of a device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_capture
    {
        /// <summary>
        /// Set to NULL if using default ID, otherwise set to the address of the id field.
        /// </summary>
        public ma_device_id_ptr pID;                  /* Set to NULL if using default ID, otherwise set to the address of "id". */
        /// <summary>
        /// If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0.
        /// </summary>
        public ma_device_id id;                    /* If using an explicit device, will be set to a copy of the ID used for initialization. Otherwise cleared to 0. */
        /// <summary>
        /// The device name (fixed-size buffer). Maybe temporary; likely to be replaced with a query API.
        /// </summary>
        public fixed byte name[MiniAudioNative.MA_MAX_DEVICE_NAME_LENGTH + 1];                     /* Maybe temporary. Likely to be replaced with a query API. */
        /// <summary>
        /// The share mode used when the device was initialized.
        /// </summary>
        public ma_share_mode shareMode;            /* Set to whatever was passed in when the device was initialized. */
        /// <summary>
        /// The external capture format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The external capture channel count.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The external capture channel map.
        /// </summary>
        public fixed ma_channel channelMap[MiniAudioNative.MA_MAX_CHANNELS];
        /// <summary>
        /// The internal format used by the backend.
        /// </summary>
        public ma_format internalFormat;
        /// <summary>
        /// The internal channel count used by the backend.
        /// </summary>
        public ma_uint32 internalChannels;
        /// <summary>
        /// The internal sample rate used by the backend.
        /// </summary>
        public ma_uint32 internalSampleRate;
        /// <summary>
        /// The internal channel map used by the backend.
        /// </summary>
        public fixed ma_channel internalChannelMap[MiniAudioNative.MA_MAX_CHANNELS];
        /// <summary>
        /// The internal period size in frames.
        /// </summary>
        public ma_uint32 internalPeriodSizeInFrames;
        /// <summary>
        /// The internal number of periods.
        /// </summary>
        public ma_uint32 internalPeriods;
        /// <summary>
        /// The channel mix mode for capture.
        /// </summary>
        public ma_channel_mix_mode channelMixMode;
        /// <summary>
        /// Whether to calculate LFE from spatial channels when an output LFE is present but no input LFE.
        /// </summary>
        public ma_bool32 calculateLFEFromSpatialChannels;
        /// <summary>
        /// The data converter for format/channel conversion.
        /// </summary>
        public ma_data_converter converter;
        /// <summary>
        /// Intermediary buffer for implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks.
        /// </summary>
        public IntPtr pIntermediaryBuffer;          /* For implementing fixed sized buffer callbacks. Will be null if using variable sized callbacks. */
        /// <summary>
        /// Capacity of the intermediary buffer.
        /// </summary>
        public ma_uint32 intermediaryBufferCap;
        /// <summary>
        /// Number of valid frames sitting in the intermediary buffer.
        /// </summary>
        public ma_uint32 intermediaryBufferLen;    /* How many valid frames are sitting in the intermediary buffer. */
    }

    /// <summary>
    /// Represents an audio device at runtime. Contains pointers to callbacks, context, and device state.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_device
    {
        /// <summary>
        /// Pointer to the parent context.
        /// </summary>
        public ma_context_ptr pContext;
        /// <summary>
        /// The type of device (playback, capture, duplex, or loopback).
        /// </summary>
        public ma_device_type type;
        /// <summary>
        /// The device sample rate.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The state of the device. Variable and can change at any time on any thread; must be used atomically.
        /// </summary>
        public ma_device_state state;                      /* The state of the device is variable and can change at any time on any thread. Must be used atomically. */
        /// <summary>
        /// Function pointer to the data callback. Set once at initialization time and should not be changed after.
        /// </summary>
        public IntPtr onData;                 /* Set once at initialization time and should not be changed after. */
        /// <summary>
        /// Function pointer to the notification callback. Set once at initialization time and should not be changed after.
        /// </summary>
        public IntPtr onNotification; /* Set once at initialization time and should not be changed after. */
        /// <summary>
        /// DEPRECATED. Use the notification callback instead. Set once at initialization time and should not be changed after.
        /// </summary>
        public IntPtr onStop;                        /* DEPRECATED. Use the notification callback instead. Set once at initialization time and should not be changed after. */
        /// <summary>
        /// Application-defined user data.
        /// </summary>
        public IntPtr pUserData;                            /* Application defined data. */
        //There are a lot more fields down here but they are not needed as long other ma_types only use a pointer to ma_device

        /// <summary>
        /// Sets the data callback for the device.
        /// </summary>
        /// <param name="onData">The data callback delegate.</param>
        public void SetDataProc(ma_device_data_proc onData)
        {
            this.onData = MarshalHelper.GetFunctionPointerForDelegate(onData);
        }

        /// <summary>
        /// Sets the notification callback for the device.
        /// </summary>
        /// <param name="onNotification">The notification callback delegate.</param>
        public void SetNotificationProc(ma_device_notification_proc onNotification)
        {
            this.onNotification = MarshalHelper.GetFunctionPointerForDelegate(onNotification);
        }

        /// <summary>
        /// Sets the stop callback for the device (DEPRECATED).
        /// </summary>
        /// <param name="onStop">The stop callback delegate.</param>
        public void SetStopProc(ma_stop_proc onStop)
        {
            this.onStop = MarshalHelper.GetFunctionPointerForDelegate(onStop);
        }
    }

    /// <summary>
    /// Configuration for a decoder. Specifies output format, channel count, sample rate, encoding format, and custom backends.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoder_config
    {
        /// <summary>
        /// The output sample format. Set to 0 or ma_format_unknown to use the stream's internal format.
        /// </summary>
        public ma_format format;      /* Set to 0 or ma_format_unknown to use the stream's internal format. */
        /// <summary>
        /// The output channel count. Set to 0 to use the stream's internal channels.
        /// </summary>
        public ma_uint32 channels;    /* Set to 0 to use the stream's internal channels. */
        /// <summary>
        /// The output sample rate. Set to 0 to use the stream's internal sample rate.
        /// </summary>
        public ma_uint32 sampleRate;  /* Set to 0 to use the stream's internal sample rate. */
        /// <summary>
        /// Pointer to the channel map for the output.
        /// </summary>
        public ma_channel_ptr pChannelMap;
        /// <summary>
        /// The channel mix mode to use when converting channels.
        /// </summary>
        public ma_channel_mix_mode channelMixMode;
        /// <summary>
        /// The dither mode to use for format conversion.
        /// </summary>
        public ma_dither_mode ditherMode;
        /// <summary>
        /// Resampling configuration.
        /// </summary>
        public ma_resampler_config resampling;
        /// <summary>
        /// Allocation callbacks used for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// The encoding format of the input data.
        /// </summary>
        public ma_encoding_format encodingFormat;
        /// <summary>
        /// When set to > 0, specifies the number of seek points to use for the generation of a seek table. Not all decoding backends support this.
        /// </summary>
        public ma_uint32 seekPointCount;   /* When set to > 0, specifies the number of seek points to use for the generation of a seek table. Not all decoding backends support this. */
        /// <summary>
        /// Pointer to an array of custom decoding backend vtable pointers.
        /// </summary>
        public IntPtr ppCustomBackendVTables;
        /// <summary>
        /// The number of custom decoding backend vtables.
        /// </summary>
        public ma_uint32 customBackendCount;
        /// <summary>
        /// User data passed to custom decoding backends.
        /// </summary>
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

    /// <summary>
    /// Represents a decoder at runtime. Reads audio data from a backend, with support for reading, seeking, and format conversion.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoder
    {
        /// <summary>
        /// The base data source.
        /// </summary>
        public ma_data_source_base ds;
        /// <summary>
        /// The decoding backend from which data is pulled.
        /// </summary>
        public ma_data_source_ptr pBackend;                   /* The decoding backend we'll be pulling data from. */
        /// <summary>
        /// The vtable for the decoding backend. Stored so we can access the onUninit() callback.
        /// </summary>
        public IntPtr pBackendVTable; /* The vtable for the decoding backend. This needs to be stored so we can access the onUninit() callback. */
        /// <summary>
        /// User data passed to the decoding backend.
        /// </summary>
        public IntPtr pBackendUserData;
        /// <summary>
        /// Function pointer to the custom read callback.
        /// </summary>
        public IntPtr onRead;
        /// <summary>
        /// Function pointer to the custom seek callback.
        /// </summary>
        public IntPtr onSeek;
        /// <summary>
        /// Function pointer to the custom tell callback.
        /// </summary>
        public IntPtr onTell;
        /// <summary>
        /// User data for custom read/seek/tell callbacks.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// The read pointer in output sample rate PCM frames. Used for keeping track of how many frames are available for decoding.
        /// </summary>
        public ma_uint64 readPointerInPCMFrames;      /* In output sample rate. Used for keeping track of how many frames are available for decoding. */
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format outputFormat;
        /// <summary>
        /// The output channel count.
        /// </summary>
        public ma_uint32 outputChannels;
        /// <summary>
        /// The output sample rate.
        /// </summary>
        public ma_uint32 outputSampleRate;
        /// <summary>
        /// Data converter for converting frames from the backend format to the output format.
        /// </summary>
        public ma_data_converter converter;    /* Data conversion is achieved by running frames through this. */
        /// <summary>
        /// Input cache buffer in input format. Can be null if it is not needed.
        /// </summary>
        public IntPtr pInputCache;              /* In input format. Can be null if it's not needed. */
        /// <summary>
        /// The capacity of the input cache.
        /// </summary>
        public ma_uint64 inputCacheCap;        /* The capacity of the input cache. */
        /// <summary>
        /// The number of frames that have been consumed in the cache.
        /// </summary>
        public ma_uint64 inputCacheConsumed;   /* The number of frames that have been consumed in the cache. Used for determining the next valid frame. */
        /// <summary>
        /// The number of valid frames remaining in the cache.
        /// </summary>
        public ma_uint64 inputCacheRemaining;  /* The number of valid frames remaining in the cache. */
        /// <summary>
        /// Allocation callbacks used for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// The decoder data (either VFS file or memory buffer).
        /// </summary>
        public ma_decoder_data_union data;

        /// <summary>
        /// Sets the custom read callback for the decoder.
        /// </summary>
        /// <param name="callback">The read callback delegate.</param>
        public void SetReadProc(ma_decoder_read_proc callback)
        {
            onRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        /// <summary>
        /// Sets the custom seek callback for the decoder.
        /// </summary>
        /// <param name="callback">The seek callback delegate.</param>
        public void SetSeekProc(ma_decoder_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
        /// <summary>
        /// Sets the custom tell callback for the decoder.
        /// </summary>
        /// <param name="callback">The tell callback delegate.</param>
        public void SetTellProc(ma_decoder_tell_proc callback)
        {
            onTell = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// VFS-based decoder data (file opened via virtual file system).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_decoder_data_vfs
        {
            /// <summary>
            /// Pointer to the virtual file system.
            /// </summary>
            public ma_vfs_ptr pVFS;
            /// <summary>
            /// The VFS file handle.
            /// </summary>
            public ma_vfs_file file;
        }

        /// <summary>
        /// Memory-based decoder data (raw memory buffer).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_decoder_data_memory
        {
            /// <summary>
            /// Pointer to the raw memory buffer.
            /// </summary>
            public IntPtr pData; // const ma_uint8*
            /// <summary>
            /// The size of the data in bytes.
            /// </summary>
            public size_t dataSize;
            /// <summary>
            /// The current read position in bytes.
            /// </summary>
            public size_t currentReadPos;
        }

        /// <summary>
        /// Union of VFS and memory-based decoder data.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_decoder_data_union
        {
            /// <summary>
            /// VFS-based data.
            /// </summary>
            [FieldOffset(0)]
            public ma_decoder_data_vfs vfs;

            /// <summary>
            /// Memory-based data.
            /// </summary>
            [FieldOffset(0)]
            public ma_decoder_data_memory memory;
        }
    }

    /// <summary>
    /// Configuration for an encoder. Specifies the encoding format, output format, channel count, and sample rate.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_encoder_config
    {
        /// <summary>
        /// The encoding format (WAV, FLAC, etc.).
        /// </summary>
        public ma_encoding_format encodingFormat;
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The output channel count.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The output sample rate.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// Allocation callbacks used for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
    }

    /// <summary>
    /// Represents an encoder at runtime. Encodes PCM audio data to a specified format with custom write/seek/init callbacks.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_encoder
    {
        /// <summary>
        /// The encoder configuration.
        /// </summary>
        public ma_encoder_config config;
        /// <summary>
        /// Function pointer to the custom write callback.
        /// </summary>
        public IntPtr onWrite;
        /// <summary>
        /// Function pointer to the custom seek callback.
        /// </summary>
        public IntPtr onSeek;
        /// <summary>
        /// Function pointer to the custom init callback.
        /// </summary>
        public IntPtr onInit;
        /// <summary>
        /// Function pointer to the custom uninit callback.
        /// </summary>
        public IntPtr onUninit;
        /// <summary>
        /// Function pointer to the custom write PCM frames callback.
        /// </summary>
        public IntPtr onWritePCMFrames;
        /// <summary>
        /// Application-defined user data.
        /// </summary>
        public IntPtr pUserData;
        /// <summary>
        /// Pointer to the internal encoder implementation.
        /// </summary>
        public IntPtr pInternalEncoder;
        /// <summary>
        /// VFS data for file-based encoding.
        /// </summary>
        public ma_encoder_vfs_data data;

        /// <summary>
        /// Sets the write callback for the encoder.
        /// </summary>
        /// <param name="callback">The write callback delegate.</param>
        public void SetWriteProc(ma_encoder_write_proc callback)
        {
            onWrite = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the seek callback for the encoder.
        /// </summary>
        /// <param name="callback">The seek callback delegate.</param>
        public void SetSeekProc(ma_encoder_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the init callback for the encoder.
        /// </summary>
        /// <param name="callback">The init callback delegate.</param>
        public void SetInitProc(ma_encoder_init_proc callback)
        {
            onInit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the uninit callback for the encoder.
        /// </summary>
        /// <param name="callback">The uninit callback delegate.</param>
        public void SetUninitProc(ma_encoder_uninit_proc callback)
        {
            onUninit = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the write PCM frames callback for the encoder.
        /// </summary>
        /// <param name="callback">The write PCM frames callback delegate.</param>
        public void SetWritePCMFramesProc(ma_encoder_write_pcm_frames_proc callback)
        {
            onWritePCMFrames = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Union of VFS and file data for the encoder.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_encoder_vfs_data
        {    
            /// <summary>
            /// Pointer to the virtual file system.
            /// </summary>
            [FieldOffset(0)]
            public ma_vfs pVFS;    
            
            /// <summary>
            /// The VFS file handle.
            /// </summary>
            [FieldOffset(0)]
            public ma_vfs_file file;
        }
    }

    /// <summary>
    /// Virtual table for a custom data source. Contains function pointers for read, seek, get data format, get cursor, get length, and set looping.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_vtable
    {
        /// <summary>
        /// Function pointer for reading PCM frames from the data source.
        /// </summary>
        public IntPtr onRead;
        /// <summary>
        /// Function pointer for seeking within the data source.
        /// </summary>
        public IntPtr onSeek;
        /// <summary>
        /// Function pointer for getting the data format of the data source.
        /// </summary>
        public IntPtr onGetDataFormat;
        /// <summary>
        /// Function pointer for getting the current cursor position.
        /// </summary>
        public IntPtr onGetCursor;
        /// <summary>
        /// Function pointer for getting the total length in PCM frames.
        /// </summary>
        public IntPtr onGetLength;
        /// <summary>
        /// Function pointer for setting the looping state.
        /// </summary>
        public IntPtr onSetLooping;
        /// <summary>
        /// Flags describing characteristics of the data source.
        /// </summary>
        public ma_uint32 flags;
        
        /// <summary>
        /// Sets the read callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The read callback delegate.</param>
        public void SetReadProc(ma_data_source_vtable_read_proc callback)
        {
            onRead = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the seek callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The seek callback delegate.</param>
        public void SetSeekProc(ma_data_source_vtable_seek_proc callback)
        {
            onSeek = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the get data format callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The get data format callback delegate.</param>
        public void SetGetDataFormatProc(ma_data_source_vtable_get_data_format_proc callback)
        {
            onGetDataFormat = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the get cursor callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The get cursor callback delegate.</param>
        public void SetGetCursorProc(ma_data_source_vtable_get_cursor_proc callback)
        {
            onGetCursor = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the get length callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The get length callback delegate.</param>
        public void SetGetLengthProc(ma_data_source_vtable_get_length_proc callback)
        {
            onGetLength = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the set looping callback for the data source vtable.
        /// </summary>
        /// <param name="callback">The set looping callback delegate.</param>
        public void SetSetLoopingProc(ma_data_source_vtable_set_looping_proc callback)
        {
            onSetLooping = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Configuration for a data source. Holds a pointer to the data source vtable.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_config
    {
        /// <summary>
        /// Pointer to the data source vtable.
        /// </summary>
        public ma_data_source_vtable_ptr vtable;
    }

    /// <summary>
    /// Configuration for a data source node that wraps a data source as a node in the audio graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// Pointer to the data source to wrap.
        /// </summary>
        public ma_data_source_ptr pDataSource;
    }

    /// <summary>
    /// Represents a data source node at runtime. Wraps a data source as a node in the audio graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_node
    {
        /// <summary>
        /// The base node.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// Pointer to the wrapped data source.
        /// </summary>
        public ma_data_source_ptr pDataSource;
    }

    /// <summary>
    /// Base structure for all data sources. Contains the vtable pointer, range and loop settings, and chaining support.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_source_base
    {
        /// <summary>
        /// Pointer to the data source vtable.
        /// </summary>
        public IntPtr vtable;
        /// <summary>
        /// The beginning of the playback range in frames.
        /// </summary>
        public ma_uint64 rangeBegInFrames;
        /// <summary>
        /// The end of the playback range in frames. Set to -1 for unranged (default).
        /// </summary>
        public ma_uint64 rangeEndInFrames;             /* Set to -1 for unranged (default). */
        /// <summary>
        /// The loop start point relative to rangeBegInFrames.
        /// </summary>
        public ma_uint64 loopBegInFrames;              /* Relative to rangeBegInFrames. */
        /// <summary>
        /// The loop end point relative to rangeBegInFrames. Set to -1 for the end of the range.
        /// </summary>
        public ma_uint64 loopEndInFrames;              /* Relative to rangeBegInFrames. Set to -1 for the end of the range. */
        /// <summary>
        /// When non-NULL, the data source will act as a proxy and route all operations to pCurrent. Used in conjunction with pNext/onGetNext for seamless chaining.
        /// </summary>
        public ma_data_source_ptr pCurrent;               /* When non-NULL, the data source being initialized will act as a proxy and will route all operations to pCurrent. Used in conjunction with pNext/onGetNext for seamless chaining. */
        /// <summary>
        /// The next data source in the chain. When set to NULL, onGetNext will be used.
        /// </summary>
        public ma_data_source_ptr pNext;                  /* When set to NULL, onGetNext will be used. */
        /// <summary>
        /// Callback to determine the next data source. Will be used when pNext is NULL. If both are NULL, no next will be used.
        /// </summary>
        public IntPtr onGetNext; /* Will be used when pNext is NULL. If both are NULL, no next will be used. */
        /// <summary>
        /// Whether looping is enabled.
        /// </summary>
        public ma_bool32 isLooping;

        /// <summary>
        /// Sets the callback for determining the next data source in the chain.
        /// </summary>
        /// <param name="callback">The get next callback delegate.</param>
        public void SetNextProc(ma_data_source_get_next_proc callback)
        {
            onGetNext = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Converts audio data between different channel configurations. Supports different mixing modes and channel maps.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_channel_converter
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of input channels.
        /// </summary>
        public ma_uint32 channelsIn;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// The channel mixing mode.
        /// </summary>
        public ma_channel_mix_mode mixingMode;
        /// <summary>
        /// The channel conversion path.
        /// </summary>
        public ma_channel_conversion_path conversionPath;
        /// <summary>
        /// Pointer to the input channel map.
        /// </summary>
        public ma_channel_ptr pChannelMapIn;
        /// <summary>
        /// Pointer to the output channel map.
        /// </summary>
        public ma_channel_ptr pChannelMapOut;
        /// <summary>
        /// Pointer to the shuffle table, indexed by output channel index.
        /// </summary>
        public IntPtr pShuffleTable;    /* Indexed by output channel index. */
        /// <summary>
        /// Channel mixing weights ([in][out]).
        /// </summary>
        public ma_channel_converter_weights weights;  /* [in][out] */
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the converter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
        
        /// <summary>
        /// Union of float and int16 weight arrays for the channel converter.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_channel_converter_weights
        {
            /// <summary>
            /// Float weight array pointer (float**).
            /// </summary>
            [FieldOffset(0)]
            public IntPtr f32;  // float**
            /// <summary>
            /// Int16 weight array pointer (ma_int32**).
            /// </summary>
            [FieldOffset(0)]
            public IntPtr s16;  // ma_int32**
        }
    }

    /// <summary>
    /// Represents a biquad filter coefficient as a union of float and int32.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ma_biquad_coefficient
    {
        /// <summary>
        /// The coefficient as a float value.
        /// </summary>
        [FieldOffset(0)]
        public float f32;
        /// <summary>
        /// The coefficient as a signed 32-bit integer value.
        /// </summary>
        [FieldOffset(0)]
        public UInt32 s32;
    }

    /// <summary>
    /// Configuration for a biquad filter. Specifies format, channels, and the six biquad coefficients (b0-b2, a0-a2).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_biquad_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// Feed-forward coefficient b0.
        /// </summary>
        public double b0;
        /// <summary>
        /// Feed-forward coefficient b1.
        /// </summary>
        public double b1;
        /// <summary>
        /// Feed-forward coefficient b2.
        /// </summary>
        public double b2;
        /// <summary>
        /// Feed-back coefficient a0.
        /// </summary>
        public double a0;
        /// <summary>
        /// Feed-back coefficient a1.
        /// </summary>
        public double a1;
        /// <summary>
        /// Feed-back coefficient a2.
        /// </summary>
        public double a2;
    }

    /// <summary>
    /// Represents a biquad filter at runtime with quantized coefficients and delay line state.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_biquad
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// Quantized coefficient b0.
        /// </summary>
        public ma_biquad_coefficient b0;
        /// <summary>
        /// Quantized coefficient b1.
        /// </summary>
        public ma_biquad_coefficient b1;
        /// <summary>
        /// Quantized coefficient b2.
        /// </summary>
        public ma_biquad_coefficient b2;
        /// <summary>
        /// Quantized coefficient a1.
        /// </summary>
        public ma_biquad_coefficient a1;
        /// <summary>
        /// Quantized coefficient a2.
        /// </summary>
        public ma_biquad_coefficient a2;
        /// <summary>
        /// Pointer to delay line state r1 (per channel).
        /// </summary>
        public ma_biquad_coefficient_ptr pR1;
        /// <summary>
        /// Pointer to delay line state r2 (per channel).
        /// </summary>
        public ma_biquad_coefficient_ptr pR2;
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the biquad owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Configuration for a first-order low-pass filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf1_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
    }

    /// <summary>
    /// Configuration for a second-order low-pass filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
    }

    /// <summary>
    /// Represents a first-order low-pass filter at runtime.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf1
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The filter coefficient.
        /// </summary>
        public ma_biquad_coefficient a;
        /// <summary>
        /// Pointer to delay line state r1 (per channel).
        /// </summary>
        public ma_biquad_coefficient_ptr pR1;
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the filter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Represents a second-order low-pass filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf2
    {
        /// <summary>
        /// The underlying biquad filter implementing the second-order low-pass.
        /// </summary>
        public ma_biquad bq;   /* The second order low-pass filter is implemented as a biquad filter. */
    }

    /// <summary>
    /// Configuration for a configurable-order low-pass filter. Set order to 0 for passthrough.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The filter order. If set to 0, will be treated as a passthrough (no filtering will be applied).
        /// </summary>
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    /// <summary>
    /// Represents a configurable-order low-pass filter at runtime. Composed of first and second-order stages.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The number of first-order LPF stages.
        /// </summary>
        public UInt32 lpf1Count;
        /// <summary>
        /// The number of second-order LPF stages.
        /// </summary>
        public UInt32 lpf2Count;
        /// <summary>
        /// Pointer to the array of first-order LPF stages.
        /// </summary>
        public ma_lpf1_ptr pLPF1;
        /// <summary>
        /// Pointer to the array of second-order LPF stages.
        /// </summary>
        public ma_lpf2_ptr pLPF2;
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the filter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Configuration for a first-order high-pass filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf1_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
    }

    /// <summary>
    /// Configuration for a second-order high-pass filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
    }
    
    /// <summary>
    /// Represents a first-order high-pass filter at runtime.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf1
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The filter coefficient.
        /// </summary>
        public ma_biquad_coefficient a;
        /// <summary>
        /// Pointer to delay line state r1 (per channel).
        /// </summary>
        public ma_biquad_coefficient_ptr pR1;
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the filter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Represents a second-order high-pass filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf2
    {
        /// <summary>
        /// The underlying biquad filter implementing the second-order high-pass.
        /// </summary>
        public ma_biquad bq;   /* The second order high-pass filter is implemented as a biquad filter. */
    }

    /// <summary>
    /// Configuration for a configurable-order high-pass filter. Set order to 0 for passthrough.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The filter order. If set to 0, will be treated as a passthrough (no filtering will be applied).
        /// </summary>
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    /// <summary>
    /// Represents a configurable-order high-pass filter at runtime. Composed of first and second-order stages.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The number of first-order HPF stages.
        /// </summary>
        public UInt32 hpf1Count;
        /// <summary>
        /// The number of second-order HPF stages.
        /// </summary>
        public UInt32 hpf2Count;
        /// <summary>
        /// Pointer to the array of first-order HPF stages.
        /// </summary>
        public ma_hpf1_ptr pHPF1;
        /// <summary>
        /// Pointer to the array of second-order HPF stages.
        /// </summary>
        public ma_hpf2_ptr pHPF2;
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the filter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Configuration for a second-order band-pass filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
    }

    /// <summary>
    /// Represents a second-order band-pass filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf2
    {
        /// <summary>
        /// The underlying biquad filter implementing the second-order band-pass.
        /// </summary>
        public ma_biquad bq;   /* The second order band-pass filter is implemented as a biquad filter. */
    }

    /// <summary>
    /// Configuration for a configurable-order band-pass filter. Set order to 0 for passthrough.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The cutoff frequency in Hz.
        /// </summary>
        public double cutoffFrequency;
        /// <summary>
        /// The filter order. If set to 0, will be treated as a passthrough (no filtering will be applied).
        /// </summary>
        public UInt32 order;    /* If set to 0, will be treated as a passthrough (no filtering will be applied). */
    }

    /// <summary>
    /// Represents a configurable-order band-pass filter at runtime. Composed of second-order stages.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The number of second-order BPF stages.
        /// </summary>
        public UInt32 bpf2Count;
        /// <summary>
        /// Pointer to the array of second-order BPF stages.
        /// </summary>
        public ma_bpf2_ptr pBPF2;
        /* Memory management. */
        /// <summary>
        /// Heap allocation pointer.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether the filter owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }
    
    /// <summary>
    /// Configuration for a second-order notch (band-stop) filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
        /// <summary>
        /// The notch frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Configuration for a notch (band-stop) filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
        /// <summary>
        /// The notch frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Represents a second-order notch filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch2
    {
        /// <summary>
        /// The underlying biquad filter implementing the notch filter.
        /// </summary>
        public ma_biquad bq;
    }

    /// <summary>
    /// Configuration for a second-order peaking EQ filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
        /// <summary>
        /// The peak frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Configuration for a peaking EQ filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The quality factor.
        /// </summary>
        public double q;
        /// <summary>
        /// The peak frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Represents a second-order peaking EQ filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak2
    {
        /// <summary>
        /// The underlying biquad filter implementing the peaking EQ.
        /// </summary>
        public ma_biquad bq;
    }

    /// <summary>
    /// Configuration for a second-order low-shelf filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The shelf slope.
        /// </summary>
        public double shelfSlope;
        /// <summary>
        /// The shelf frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Configuration for a low-shelf filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The shelf slope.
        /// </summary>
        public double shelfSlope;
        /// <summary>
        /// The shelf frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Represents a second-order low-shelf filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf2
    {
        /// <summary>
        /// The underlying biquad filter implementing the low-shelf.
        /// </summary>
        public ma_biquad bq;
    }

    /// <summary>
    /// Configuration for a second-order high-shelf filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf2_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The shelf slope.
        /// </summary>
        public double shelfSlope;
        /// <summary>
        /// The shelf frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Configuration for a high-shelf filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of channels.
        /// </summary>
        public UInt32 channels;
        /// <summary>
        /// The sample rate.
        /// </summary>
        public UInt32 sampleRate;
        /// <summary>
        /// The gain in decibels.
        /// </summary>
        public double gainDB;
        /// <summary>
        /// The shelf slope.
        /// </summary>
        public double shelfSlope;
        /// <summary>
        /// The shelf frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Represents a second-order high-shelf filter at runtime, implemented as a biquad filter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf2
    {
        /// <summary>
        /// The underlying biquad filter implementing the high-shelf.
        /// </summary>
        public ma_biquad bq;
    }

    /// <summary>
    /// Configuration for a low-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The low-pass filter configuration.
        /// </summary>
        public ma_lpf_config lpf;
    }

    /// <summary>
    /// Runtime state for a low-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lpf_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The low-pass filter runtime state.
        /// </summary>
        public ma_lpf lpf;
    }

    /// <summary>
    /// Configuration for a high-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The high-pass filter configuration.
        /// </summary>
        public ma_hpf_config hpf;
    }

    /// <summary>
    /// Runtime state for a high-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hpf_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The high-pass filter runtime state.
        /// </summary>
        public ma_hpf hpf;
    }

    /// <summary>
    /// Configuration for a band-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The band-pass filter configuration.
        /// </summary>
        public ma_bpf_config bpf;
    }

    /// <summary>
    /// Runtime state for a band-pass filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_bpf_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The band-pass filter runtime state.
        /// </summary>
        public ma_bpf bpf;
    }

    /// <summary>
    /// Configuration for a notch filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The notch filter configuration.
        /// </summary>
        public ma_notch_config notch;
    }

    /// <summary>
    /// Runtime state for a notch filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_notch_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The notch filter runtime state (order 2).
        /// </summary>
        public ma_notch2 notch;
    }

    /// <summary>
    /// Configuration for a peaking EQ audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The peaking EQ filter configuration.
        /// </summary>
        public ma_peak_config peak;
    }

    /// <summary>
    /// Runtime state for a peaking EQ audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_peak_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The peaking EQ filter runtime state (order 2).
        /// </summary>
        public ma_peak2 peak;
    }

    /// <summary>
    /// Configuration for a low-shelf filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The low-shelf filter configuration.
        /// </summary>
        public ma_loshelf_config loshelf;
    }

    /// <summary>
    /// Runtime state for a low-shelf filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_loshelf_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The low-shelf filter runtime state (order 2).
        /// </summary>
        public ma_loshelf2 loshelf;
    }

    /// <summary>
    /// Configuration for a high-shelf filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The high-shelf filter configuration.
        /// </summary>
        public ma_hishelf_config hishelf;
    }

    /// <summary>
    /// Runtime state for a high-shelf filter audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_hishelf_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The high-shelf filter runtime state (order 2).
        /// </summary>
        public ma_hishelf2 hishelf;
    }

    /// <summary>
    /// Configuration for a delay effect. Supports feedback decay for echo effects.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_config
    {
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The delay length in PCM frames.
        /// </summary>
        public ma_uint32 delayInFrames;
        /// <summary>
        /// Set to true to delay the start of the output; false otherwise.
        /// </summary>
        public ma_bool32 delayStart;       /* Set to true to delay the start of the output; false otherwise. */
        /// <summary>
        /// The wet (processed) signal level in the range 0..1. Default = 1.
        /// </summary>
        public float wet;                  /* 0..1. Default = 1. */
        /// <summary>
        /// The dry (unprocessed) signal level in the range 0..1. Default = 1.
        /// </summary>
        public float dry;                  /* 0..1. Default = 1. */
        /// <summary>
        /// Feedback decay in the range 0..1. Default = 0 (no feedback). Use this for echo.
        /// </summary>
        public float decay;                /* 0..1. Default = 0 (no feedback). Feedback decay. Use this for echo. */
    }

    /// <summary>
    /// Runtime state for a delay effect.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay
    {
        /// <summary>
        /// The delay configuration.
        /// </summary>
        public ma_delay_config config;
        /// <summary>
        /// Feedback is written to this cursor. Always equal or in front of the read cursor.
        /// </summary>
        public ma_uint32 cursor;               /* Feedback is written to this cursor. Always equal or in front of the read cursor. */
        /// <summary>
        /// The size of the internal delay buffer in frames.
        /// </summary>
        public ma_uint32 bufferSizeInFrames;
        /// <summary>
        /// Pointer to the internal delay buffer (interleaved float samples).
        /// </summary>
        public IntPtr pBuffer;
    }

    /// <summary>
    /// Configuration for a delay effect audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The delay effect configuration.
        /// </summary>
        public ma_delay_config delay;
    }

    /// <summary>
    /// Runtime state for a delay effect audio node.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_delay_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The delay effect runtime state.
        /// </summary>
        public ma_delay delay;
    }

    /// <summary>
    /// Configuration for a splitter audio node. Takes 1 input bus and splits/copies it to multiple output buses.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_splitter_node_config
    {
        /// <summary>
        /// The base node configuration.
        /// </summary>
        public ma_node_config nodeConfig;
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The number of output buses to split to.
        /// </summary>
        public ma_uint32 outputBusCount;
    }

    /// <summary>
    /// Runtime state for a splitter audio node. 1 input bus, many output buses.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_splitter_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
    }

    /// <summary>
    /// Configuration for a linear resampler. Provides low-quality but efficient sample rate conversion using linear interpolation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_linear_resampler_config
    {
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The input sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateIn;
        /// <summary>
        /// The output sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateOut;
        /// <summary>
        /// The low-pass filter order. Setting this to 0 will disable low-pass filtering.
        /// </summary>
        public ma_uint32 lpfOrder;         /* The low-pass filter order. Setting this to 0 will disable low-pass filtering. */
        /// <summary>
        /// The low-pass filter Nyquist factor in the range 0..1. Defaults to 1.
        /// 1 = Half the sampling frequency (Nyquist Frequency), 0.5 = Quarter the sampling frequency (half Nyquist Frequency), etc.
        /// </summary>
        public double    lpfNyquistFactor; /* 0..1. Defaults to 1. 1 = Half the sampling frequency (Nyquist Frequency), 0.5 = Quarter the sampling frequency (half Nyquest Frequency), etc. */
    }

    /// <summary>
    /// Runtime state for a linear resampler.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_linear_resampler
    {
        /// <summary>
        /// The resampler configuration.
        /// </summary>
        public ma_linear_resampler_config config;
        /// <summary>
        /// Integer part of the input advance per output frame.
        /// </summary>
        public ma_uint32 inAdvanceInt;
        /// <summary>
        /// Fractional part of the input advance per output frame.
        /// </summary>
        public ma_uint32 inAdvanceFrac;
        /// <summary>
        /// Integer part of the current input time position.
        /// </summary>
        public ma_uint32 inTimeInt;
        /// <summary>
        /// Fractional part of the current input time position.
        /// </summary>
        public ma_uint32 inTimeFrac;
        /// <summary>
        /// The previous input frame.
        /// </summary>
        public ma_linear_resampler_data x0; /* The previous input frame. */
        /// <summary>
        /// The next input frame.
        /// </summary>
        public ma_linear_resampler_data x1; /* The next input frame. */
        /// <summary>
        /// The low-pass filter used for anti-aliasing.
        /// </summary>
        public ma_lpf lpf;
        /* Memory management. */
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether this resampler owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;

        /// <summary>
        /// A sample frame in the resampler's internal buffer. Can represent f32 or s16 depending on format.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_linear_resampler_data
        {
            /// <summary>
            /// Pointer to float samples.
            /// </summary>
            [FieldOffset(0)]
            public IntPtr f32;
            /// <summary>
            /// Pointer to signed 16-bit integer samples.
            /// </summary>
            [FieldOffset(0)]
            public IntPtr s16;
        }
    }

    /// <summary>
    /// Runtime state for a resampler. Supports swappable backends via a vtable.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resampler
    {
        /// <summary>
        /// Pointer to the resampler backend instance.
        /// </summary>
        public IntPtr pBackend;
        /// <summary>
        /// Pointer to the backend vtable (function pointers).
        /// </summary>
        public IntPtr pBackendVTable;
        /// <summary>
        /// User data pointer for the backend.
        /// </summary>
        public IntPtr pBackendUserData;
        /// <summary>
        /// The sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The input sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateIn;
        /// <summary>
        /// The output sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateOut;
        /// <summary>
        /// State for stock resamplers so we can avoid a malloc. For stock resamplers, pBackend will point here.
        /// </summary>
        public ma_resampler_state state;    /* State for stock resamplers so we can avoid a malloc. For stock resamplers, pBackend will point here. */
        /* Memory management. */
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether this resampler owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;

        /// <summary>
        /// Union of stock resampler state types. For the built-in linear resampler, this contains a ma_linear_resampler.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ma_resampler_state
        {
            /// <summary>
            /// State for the built-in linear resampler.
            /// </summary>
            [FieldOffset(0)]
            public ma_linear_resampler linear;
        }
    }

    /// <summary>
    /// Runtime state for a data converter. Wraps sample format conversion, channel conversion, and resampling in a single object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_data_converter
    {
        /// <summary>
        /// The input sample format.
        /// </summary>
        public ma_format formatIn;
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format formatOut;
        /// <summary>
        /// The input channel count.
        /// </summary>
        public ma_uint32 channelsIn;
        /// <summary>
        /// The output channel count.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// The input sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateIn;
        /// <summary>
        /// The output sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRateOut;
        /// <summary>
        /// The dithering mode to use during format conversion.
        /// </summary>
        public ma_dither_mode ditherMode;
        /// <summary>
        /// The execution path the data converter will follow when processing.
        /// </summary>
        public ma_data_converter_execution_path executionPath; /* The execution path the data converter will follow when processing. */
        /// <summary>
        /// The channel converter used for channel count conversion.
        /// </summary>
        public ma_channel_converter channelConverter;
        /// <summary>
        /// The resampler used for sample rate conversion.
        /// </summary>
        public ma_resampler resampler;
        /// <summary>
        /// Whether pre-format-conversion is needed.
        /// </summary>
        public ma_bool8 hasPreFormatConversion;
        /// <summary>
        /// Whether post-format-conversion is needed.
        /// </summary>
        public ma_bool8 hasPostFormatConversion;
        /// <summary>
        /// Whether channel conversion is needed.
        /// </summary>
        public ma_bool8 hasChannelConverter;
        /// <summary>
        /// Whether resampling is needed.
        /// </summary>
        public ma_bool8 hasResampler;
        /// <summary>
        /// Whether the data converter is in passthrough mode (no conversion needed).
        /// </summary>
        public ma_bool8 isPassthrough;
        /* Memory management. */
        /// <summary>
        /// Whether this converter owns the heap allocation.
        /// </summary>
        public ma_bool8 _ownsHeap;
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
    }

    /// <summary>
    /// Configuration for the resource manager. Manages asynchronous loading, decoding, and streaming of audio data sources.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_resource_manager_config
    {
        /// <summary>
        /// The allocation callbacks to use for memory management.
        /// </summary>
        public ma_allocation_callbacks allocationCallbacks;
        /// <summary>
        /// Optional pointer to a log instance for diagnostic output.
        /// </summary>
        public ma_log_ptr pLog;
        /// <summary>
        /// The decoded format to use. Set to ma_format_unknown (default) to use the file's native format.
        /// </summary>
        public ma_format decodedFormat;        /* The decoded format to use. Set to ma_format_unknown (default) to use the file's native format. */
        /// <summary>
        /// The decoded channel count to use. Set to 0 (default) to use the file's native channel count.
        /// </summary>
        public ma_uint32 decodedChannels;      /* The decoded channel count to use. Set to 0 (default) to use the file's native channel count. */
        /// <summary>
        /// The decoded sample rate to use. Set to 0 (default) to use the file's native sample rate.
        /// </summary>
        public ma_uint32 decodedSampleRate;    /* the decoded sample rate to use. Set to 0 (default) to use the file's native sample rate. */
        /// <summary>
        /// The number of job threads. Set to 0 if you want to self-manage your job threads. Defaults to 1.
        /// </summary>
        public ma_uint32 jobThreadCount;       /* Set to 0 if you want to self-manage your job threads. Defaults to 1. */
        /// <summary>
        /// The stack size for each job thread.
        /// </summary>
        public size_t jobThreadStackSize;
        /// <summary>
        /// The maximum number of jobs that can fit in the queue at a time. Defaults to MA_JOB_TYPE_RESOURCE_MANAGER_QUEUE_CAPACITY. Cannot be zero.
        /// </summary>
        public ma_uint32 jobQueueCapacity;     /* The maximum number of jobs that can fit in the queue at a time. Defaults to MA_JOB_TYPE_RESOURCE_MANAGER_QUEUE_CAPACITY. Cannot be zero. */
        /// <summary>
        /// Configuration flags for the resource manager.
        /// </summary>
        public ma_uint32 flags;
        /// <summary>
        /// Optional virtual file system interface. Can be NULL in which case defaults will be used.
        /// </summary>
        public ma_vfs_ptr pVFS;                   /* Can be NULL in which case defaults will be used. */
        /// <summary>
        /// Array of custom decoding backend vtable pointers for supporting additional file formats.
        /// </summary>
        public IntPtr ppCustomDecodingBackendVTables;
        /// <summary>
        /// The number of custom decoding backend vtables.
        /// </summary>
        public ma_uint32 customDecodingBackendCount;
        /// <summary>
        /// User data passed to custom decoding backends.
        /// </summary>
        public IntPtr pCustomDecodingBackendUserData;
        /// <summary>
        /// The resampler configuration used when decoding sources.
        /// </summary>
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

    /// <summary>
    /// Vtable for custom decoding backends. Each field is a function pointer for a decoding operation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_decoding_backend_vtable
    {
        /// <summary>
        /// Function pointer for the onInit callback.
        /// </summary>
        public IntPtr onInit;
        /// <summary>
        /// Function pointer for the onInitFile callback.
        /// </summary>
        public IntPtr onInitFile;
        /// <summary>
        /// Function pointer for the onInitFileW (wide char) callback.
        /// </summary>
        public IntPtr onInitFileW;
        /// <summary>
        /// Function pointer for the onInitMemory callback.
        /// </summary>
        public IntPtr onInitMemory;
        /// <summary>
        /// Function pointer for the onUninit callback.
        /// </summary>
        public IntPtr onUninit;
    }

    /// <summary>
    /// A simple fixed-size stack used internally by the node graph for pre-mix processing.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_stack
    {
        /// <summary>
        /// Current offset into the stack data.
        /// </summary>
        public size_t offset;
        /// <summary>
        /// Total size of the stack in bytes.
        /// </summary>
        public size_t sizeInBytes;
        /// <summary>
        /// The stack data buffer (variable-length, fixed-size in C# representation).
        /// </summary>
        public fixed byte _data[1];
    }

    /// <summary>
    /// Configuration for a node in the audio DSP graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_config
    {
        /// <summary>
        /// The node vtable. Should never be null. Initialization of the node will fail if null.
        /// </summary>
        public ma_node_vtable_ptr vtable;          /* Should never be null. Initialization of the node will fail if so. */
        /// <summary>
        /// The initial playback state of the node. Defaults to ma_node_state_started.
        /// </summary>
        public ma_node_state initialState;         /* Defaults to ma_node_state_started. */
        /// <summary>
        /// Only used if the vtable specifies an input bus count of MA_NODE_BUS_COUNT_UNKNOWN, otherwise must be set to MA_NODE_BUS_COUNT_UNKNOWN (default).
        /// </summary>
        public ma_uint32 inputBusCount;            /* Only used if the vtable specifies an input bus count of `MA_NODE_BUS_COUNT_UNKNOWN`, otherwise must be set to `MA_NODE_BUS_COUNT_UNKNOWN` (default). */
        /// <summary>
        /// Only used if the vtable specifies an output bus count of MA_NODE_BUS_COUNT_UNKNOWN, otherwise must be set to MA_NODE_BUS_COUNT_UNKNOWN (default).
        /// </summary>
        public ma_uint32 outputBusCount;           /* Only used if the vtable specifies an output bus count of `MA_NODE_BUS_COUNT_UNKNOWN`, otherwise  be set to `MA_NODE_BUS_COUNT_UNKNOWN` (default). */
        /// <summary>
        /// Channel counts per input bus. The number of elements is determined by the input bus count.
        /// </summary>
        public IntPtr pInputChannels;          /* The number of elements are determined by the input bus count as determined by the vtable, or `inputBusCount` if the vtable specifies `MA_NODE_BUS_COUNT_UNKNOWN`. */
        /// <summary>
        /// Channel counts per output bus. The number of elements is determined by the output bus count.
        /// </summary>
        public IntPtr pOutputChannels;         /* The number of elements are determined by the output bus count as determined by the vtable, or `outputBusCount` if the vtable specifies `MA_NODE_BUS_COUNT_UNKNOWN`. */
    }

    /// <summary>
    /// Vtable for a node in the audio graph. Contains the processing callback and configuration.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_vtable
    {
        /// <summary>
        /// Extended processing callback. Used for effects that process input and output at different rates (i.e. resampling).
        /// On input, pFrameCountOut is the capacity of the output buffer; pFrameCountIn is the number of PCM frames in the input buffers.
        /// On output, set pFrameCountOut to frames actually output and pFrameCountIn to frames consumed.
        /// </summary>
        public IntPtr onProcess;
        /// <summary>
        /// Optional callback for retrieving the number of input frames required to output the specified number of output frames.
        /// Useful for nodes that perform resampling to reduce latency.
        /// </summary>
        public IntPtr onGetRequiredInputFrameCount;
        /// <summary>
        /// The number of input buses. This determines how many sub-buffers are contained in the processing callback's ppFramesIn.
        /// </summary>
        public ma_uint8 inputBusCount;
        /// <summary>
        /// The number of output buses. This determines how many sub-buffers are contained in the processing callback's ppFramesOut.
        /// </summary>
        public ma_uint8 outputBusCount;
        /// <summary>
        /// Flags describing characteristics of the node.
        /// </summary>
        public ma_node_flags flags;

        /// <summary>
        /// Sets the onProcess callback from a managed delegate.
        /// </summary>
        /// <param name="callback">The delegate to use as the processing callback.</param>
        public void SetOnProcess(ma_node_vtable_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }

        /// <summary>
        /// Sets the onGetRequiredInputFrameCount callback from a managed delegate.
        /// </summary>
        /// <param name="callback">The delegate to use as the input frame count callback.</param>
        public void SetOnGetRequiredInputFrameCount(ma_node_vtable_get_required_input_frame_count_proc callback)
        {
            onGetRequiredInputFrameCount = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Represents an output bus of a node in the audio graph. An output bus is attached to an input bus as an item in a linked list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_output_bus
    {
        /* Immutable. */
        /// <summary>
        /// The node that owns this output bus. Will be null for dummy head and tail nodes.
        /// </summary>
        public ma_node_ptr pNode;                                         /* The node that owns this output bus. The input node. Will be null for dummy head and tail nodes. */
        /// <summary>
        /// The index of the output bus on the owning node.
        /// </summary>
        public ma_uint8 outputBusIndex;                                /* The index of the output bus on pNode that this output bus represents. */
        /// <summary>
        /// The number of audio channels in this bus.
        /// </summary>
        public ma_uint8 channels;                                      /* The number of channels in the audio stream for this bus. */

        /* Mutable via multiple threads. Must be used atomically. The weird ordering here is for packing reasons. */
        /// <summary>
        /// The index of the input bus on the connected input node. Required for detaching.
        /// </summary>
        public ma_uint8 inputNodeInputBusIndex;                        /* The index of the input bus on the input. Required for detaching. Will only be used within the spinlock so does not need to be atomic. */
        /// <summary>
        /// State flags for tracking the read state of the output buffer. Combination of MA_NODE_OUTPUT_BUS_FLAG_*.
        /// </summary>
        public ma_uint32 flags;                          /* Some state flags for tracking the read state of the output buffer. A combination of MA_NODE_OUTPUT_BUS_FLAG_*. */
        /// <summary>
        /// Reference count for thread safety when detaching.
        /// </summary>
        public ma_uint32 refCount;                       /* Reference count for some thread-safety when detaching. */
        /// <summary>
        /// Prevents iteration of nodes that are in the middle of being detached. Used for thread safety.
        /// </summary>
        public ma_bool32 isAttached;                     /* This is used to prevent iteration of nodes that are in the middle of being detached. Used for thread safety. */
        /// <summary>
        /// Spinlock for thread-safe attaching and detaching.
        /// </summary>
        public ma_spinlock lck;                         /* Unfortunate lock, but significantly simplifies the implementation. Required for thread-safe attaching and detaching. */
        /// <summary>
        /// Linear volume of this output bus.
        /// </summary>
        public float volume;                             /* Linear. */
        /// <summary>
        /// Pointer to the next output bus in the linked list. Null if tail node or detached.
        /// </summary>
        public ma_node_output_bus_ptr pNext;    /* If null, it's the tail node or detached. */
        /// <summary>
        /// Pointer to the previous output bus in the linked list. Null if head node or detached.
        /// </summary>
        public ma_node_output_bus_ptr pPrev;    /* If null, it's the head node or detached. */
        /// <summary>
        /// The node that this output bus is attached to. Required for detaching.
        /// </summary>
        public ma_node_ptr pInputNode;          /* The node that this output bus is attached to. Required for detaching. */
    }

    /// <summary>
    /// Represents an input bus of a node. An input bus is essentially a linked list of output buses from other nodes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_input_bus
    {
        /* Mutable via multiple threads. */
        /// <summary>
        /// Dummy head node for simplifying lock-free thread safety.
        /// </summary>
        public ma_node_output_bus head;                /* Dummy head node for simplifying some lock-free thread-safety stuff. */
        /// <summary>
        /// Counter used to determine whether the input bus is finding the next node in the list. Used for thread safety when detaching.
        /// </summary>
        public ma_uint32 nextCounter;    /* This is used to determine whether or not the input bus is finding the next node in the list. Used for thread safety when detaching output buses. */
        /// <summary>
        /// Spinlock for thread-safe attaching and detaching.
        /// </summary>
        public ma_spinlock lck;         /* Unfortunate lock, but significantly simplifies the implementation. Required for thread-safe attaching and detaching. */
        /* Set once at startup. */
        /// <summary>
        /// The number of audio channels in this input bus.
        /// </summary>
        public ma_uint8 channels;                      /* The number of channels in the audio stream for this bus. */
    }

    /// <summary>
    /// The base structure for all nodes in the audio graph. Contains common state, bus management, and timing information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_node_base
    {
        /* These variables are set once at startup. */
        /// <summary>
        /// The node graph this node belongs to.
        /// </summary>
        public ma_node_graph_ptr pNodeGraph;                  /* The graph this node belongs to. */
        /// <summary>
        /// The node vtable pointer.
        /// </summary>
        public ma_node_vtable_ptr vtable;
        /// <summary>
        /// The number of input buses.
        /// </summary>
        public ma_uint32 inputBusCount;
        /// <summary>
        /// The number of output buses.
        /// </summary>
        public ma_uint32 outputBusCount;
        /// <summary>
        /// Pointer to the array of input buses.
        /// </summary>
        public ma_node_input_bus_ptr pInputBuses;
        /// <summary>
        /// Pointer to the array of output buses.
        /// </summary>
        public ma_node_output_bus_ptr pOutputBuses;
        /// <summary>
        /// Cached input data allocated on the heap. Fixed size, per bus.
        /// </summary>
        public IntPtr pCachedData;                         /* Allocated on the heap. Fixed size. Needs to be stored on the heap because reading from output buses is done in separate function calls. */
        /// <summary>
        /// The capacity of the input data cache in frames, per bus.
        /// </summary>
        public ma_uint16 cachedDataCapInFramesPerBus;      /* The capacity of the input data cache in frames, per bus. */

        /* These variables are read and written only from the audio thread. */
        /// <summary>
        /// The number of cached output frames.
        /// </summary>
        public ma_uint16 cachedFrameCountOut;
        /// <summary>
        /// The number of cached input frames.
        /// </summary>
        public ma_uint16 cachedFrameCountIn;
        /// <summary>
        /// The number of input frames that have been consumed.
        /// </summary>
        public ma_uint16 consumedFrameCountIn;

        /* These variables are read and written between different threads. */
        /// <summary>
        /// The playback state of the node. When stopped, nothing will be read.
        /// </summary>
        public ma_node_state state;          /* When set to stopped, nothing will be read, regardless of the times in stateTimes. */
        /// <summary>
        /// Times (indexed by ma_node_state) at which the node should enter the given state, based on the global clock.
        /// </summary>
        public fixed ma_uint64 stateTimes[2];      /* Indexed by ma_node_state. Specifies the time based on the global clock that a node should be considered to be in the relevant state. */
        /// <summary>
        /// The node's local clock. A running sum of output frames processed. Can be modified with ma_node_set_time().
        /// </summary>
        public ma_uint64 localTime;          /* The node's local clock. This is just a running sum of the number of output frames that have been processed. Can be modified by any thread with `ma_node_set_time()`. */

        /* Memory management. */
        /// <summary>
        /// Inline array of input buses for local bus storage.
        /// </summary>
        public ma_node_input_bus_array _inputBuses;
        /// <summary>
        /// Inline array of output buses for local bus storage.
        /// </summary>
        public ma_node_output_bus_array _outputBuses;
        /// <summary>
        /// Heap allocation for internal use. pInputBuses/pOutputBuses point here if bus count exceeds MA_MAX_NODE_LOCAL_BUS_COUNT.
        /// </summary>
        public IntPtr _pHeap;   /* A heap allocation for internal use only. pInputBuses and/or pOutputBuses will point to this if the bus count exceeds MA_MAX_NODE_LOCAL_BUS_COUNT. */
        /// <summary>
        /// If true, the node owns the heap allocation and _pHeap will be freed in ma_node_uninit().
        /// </summary>
        public ma_bool32 _ownsHeap;    /* If set to true, the node owns the heap allocation and _pHeap will be freed in ma_node_uninit(). */

        /// <summary>
        /// Inline fixed-size array of input buses with indexer access.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_node_input_bus_array
        {
            /// <summary>
            /// Bus at index 0.
            /// </summary>
            public ma_node_input_bus b0;
            /// <summary>
            /// Bus at index 1.
            /// </summary>
            public ma_node_input_bus b1;
            /// <summary>
            /// Gets the input bus at the specified index.
            /// </summary>
            /// <param name="index">The bus index (0 or 1).</param>
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

        /// <summary>
        /// Inline fixed-size array of output buses with indexer access.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ma_node_output_bus_array
        {
            /// <summary>
            /// Bus at index 0.
            /// </summary>
            public ma_node_output_bus b0;
            /// <summary>
            /// Bus at index 1.
            /// </summary>
            public ma_node_output_bus b1;
            /// <summary>
            /// Gets the output bus at the specified index.
            /// </summary>
            /// <param name="index">The bus index (0 or 1).</param>
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

    /// <summary>
    /// Configuration for a node graph. Specifies channel count, processing buffer size, and stack memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_graph_config
    {
        /// <summary>
        /// The number of audio channels in the graph.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The preferred processing size for node processing callbacks. Can be 0 to derive from the read request frame count.
        /// </summary>
        public ma_uint32 processingSizeInFrames;   /* This is the preferred processing size for node processing callbacks unless overridden by a node itself. Can be 0 in which case it will be based on the frame count passed into ma_node_graph_read_pcm_frames(), but will not be well defined. */
        /// <summary>
        /// The size of the pre-mix stack in bytes. Defaults to 512KB per channel. Reducing saves memory but restricts graph depth.
        /// </summary>
        public size_t preMixStackSizeInBytes;      /* Defaults to 512KB per channel. Reducing this will save memory, but the depth of your node graph will be more restricted. */
    }

    /// <summary>
    /// An audio DSP graph. The graph itself is a node so it can be connected as input to another graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_node_graph
    {
        /* Immutable. */
        /// <summary>
        /// The base node representing the graph itself. Has zero inputs; calls ma_node_graph_read_pcm_frames() to generate output.
        /// </summary>
        public ma_node_base baseNode;                  /* The node graph itself is a node so it can be connected as an input to different node graph. This has zero inputs and calls ma_node_graph_read_pcm_frames() to generate it's output. */
        /// <summary>
        /// Special endpoint node that all nodes in the graph eventually connect to. Data is read from this node in ma_node_graph_read_pcm_frames().
        /// </summary>
        public ma_node_base endpoint;              /* Special node that all nodes eventually connect to. Data is read from this node in ma_node_graph_read_pcm_frames(). */
        /// <summary>
        /// Processing cache buffer allocated when processingSizeInFrames is non-zero. Used for buffering variable frame count reads.
        /// </summary>
        public IntPtr pProcessingCache;            /* This will be allocated when processingSizeInFrames is non-zero. This is needed because ma_node_graph_read_pcm_frames() can be called with a variable number of frames, and we may need to do some buffering in situations where the caller requests a frame count that's not a multiple of processingSizeInFrames. */
        /// <summary>
        /// Number of frames remaining in the processing cache.
        /// </summary>
        public ma_uint32 processingCacheFramesRemaining;
        /// <summary>
        /// The processing size in frames.
        /// </summary>
        public ma_uint32 processingSizeInFrames;
        /* Read and written by multiple threads. */
        /// <summary>
        /// Whether the graph is currently being read from.
        /// </summary>
        public ma_bool32 isReading;
        /* Modified only by the audio thread. */
        /// <summary>
        /// Pointer to the pre-mix stack used during graph processing.
        /// </summary>
        public ma_stack_ptr pPreMixStack;
    }

    /// <summary>
    /// Configuration for an effect node. Allows custom processing via a user-provided callback.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_effect_node_config
    {
        /// <summary>
        /// The sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// Function pointer for the custom effect processing callback.
        /// </summary>
        public IntPtr onProcess;
        /// <summary>
        /// User data pointer passed to the processing callback.
        /// </summary>
        public IntPtr pUserData;

        /// <summary>
        /// Sets the onProcess callback from a managed delegate.
        /// </summary>
        /// <param name="callback">The delegate to use as the effect processing callback.</param>
        public void SetOnProcess(ma_effect_node_process_proc callback)
        {
            onProcess = MarshalHelper.GetFunctionPointerForDelegate(callback);
        }
    }

    /// <summary>
    /// Runtime state for an effect node. Wraps a user-defined effect within the audio graph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_effect_node
    {
        /// <summary>
        /// The base node state.
        /// </summary>
        public ma_node_base baseNode;
        /// <summary>
        /// The effect node configuration.
        /// </summary>
        public ma_effect_node_config config;
    }

    /// <summary>
    /// Configuration for a gainer, which provides smooth volume transitions between old and new gain values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_gainer_config
    {
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The number of frames over which gain changes are linearly interpolated.
        /// </summary>
        public ma_uint32 smoothTimeInFrames;
    }

    /// <summary>
    /// Runtime state for a gainer. Used internally by the spatializer and can be used standalone for smooth volume changes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_gainer
    {
        /// <summary>
        /// The gainer configuration.
        /// </summary>
        public ma_gainer_config config;
        /// <summary>
        /// Current interpolation time in frames.
        /// </summary>
        public ma_uint32 t;
        /// <summary>
        /// The master volume (linear).
        /// </summary>
        public float masterVolume;
        /// <summary>
        /// Pointer to the old per-channel gain values.
        /// </summary>
        public IntPtr pOldGains;
        /// <summary>
        /// Pointer to the new per-channel gain values.
        /// </summary>
        public IntPtr pNewGains;
        /* Memory management. */
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether this gainer owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Configuration for a spatializer, which applies 3D positioning, attenuation, and Doppler effect to audio.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_config
    {
        /// <summary>
        /// The number of input channels.
        /// </summary>
        public ma_uint32 channelsIn;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// Optional channel map for the input. Maps input channels to speaker positions for proper spatialization.
        /// </summary>
        public ma_channel_ptr pChannelMapIn;
        /// <summary>
        /// The attenuation model to use (none, inverse, linear, exponential).
        /// </summary>
        public ma_attenuation_model attenuationModel;
        /// <summary>
        /// The positioning algorithm to use.
        /// </summary>
        public ma_positioning positioning;
        /// <summary>
        /// The coordinate system handedness. Defaults to right-handed. Forward is -Z in right-handed, +Z in left-handed.
        /// </summary>
        public ma_handedness handedness;           /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        /// <summary>
        /// The minimum gain applied by the spatializer.
        /// </summary>
        public float minGain;
        /// <summary>
        /// The maximum gain applied by the spatializer.
        /// </summary>
        public float maxGain;
        /// <summary>
        /// The distance at which the sound begins attenuating.
        /// </summary>
        public float minDistance;
        /// <summary>
        /// The distance at which the sound reaches its minimum gain.
        /// </summary>
        public float maxDistance;
        /// <summary>
        /// The rolloff factor controlling the shape of the attenuation curve.
        /// </summary>
        public float rolloff;
        /// <summary>
        /// The inner cone angle in radians for directional audio.
        /// </summary>
        public float coneInnerAngleInRadians;
        /// <summary>
        /// The outer cone angle in radians for directional audio.
        /// </summary>
        public float coneOuterAngleInRadians;
        /// <summary>
        /// The gain applied outside the outer cone angle.
        /// </summary>
        public float coneOuterGain;
        /// <summary>
        /// The Doppler effect factor. Set to 0 to disable Doppler effect.
        /// </summary>
        public float dopplerFactor;                /* Set to 0 to disable doppler effect. */
        /// <summary>
        /// The directional attenuation factor. Set to 0 to disable directional attenuation.
        /// </summary>
        public float directionalAttenuationFactor; /* Set to 0 to disable directional attenuation. */
        /// <summary>
        /// The minimal scaling factor for channel gains during spatialization. Range 0..1. Smaller values = more aggressive panning.
        /// </summary>
        public float minSpatializationChannelGain; /* The minimal scaling factor to apply to channel gains when accounting for the direction of the sound relative to the listener. Must be in the range of 0..1. Smaller values means more aggressive directional panning, larger values means more subtle directional panning. */
        /// <summary>
        /// The number of frames over which gain changes are linearly interpolated.
        /// </summary>
        public ma_uint32 gainSmoothTimeInFrames;   /* When the gain of a channel changes during spatialization, the transition will be linearly interpolated over this number of frames. */
    }

    /// <summary>
    /// Runtime state for a spatializer. Processes audio with 3D positioning relative to a listener.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer
    {
        /// <summary>
        /// The number of input channels.
        /// </summary>
        public ma_uint32 channelsIn;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// Optional channel map for the input.
        /// </summary>
        public ma_channel_ptr pChannelMapIn;
        /// <summary>
        /// The attenuation model.
        /// </summary>
        public ma_attenuation_model attenuationModel;
        /// <summary>
        /// The positioning algorithm.
        /// </summary>
        public ma_positioning positioning;
        /// <summary>
        /// The coordinate system handedness.
        /// </summary>
        public ma_handedness handedness;           /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        /// <summary>
        /// The minimum gain.
        /// </summary>
        public float minGain;
        /// <summary>
        /// The maximum gain.
        /// </summary>
        public float maxGain;
        /// <summary>
        /// The minimum distance for attenuation.
        /// </summary>
        public float minDistance;
        /// <summary>
        /// The maximum distance for attenuation.
        /// </summary>
        public float maxDistance;
        /// <summary>
        /// The rolloff factor.
        /// </summary>
        public float rolloff;
        /// <summary>
        /// The inner cone angle in radians.
        /// </summary>
        public float coneInnerAngleInRadians;
        /// <summary>
        /// The outer cone angle in radians.
        /// </summary>
        public float coneOuterAngleInRadians;
        /// <summary>
        /// The gain outside the outer cone.
        /// </summary>
        public float coneOuterGain;
        /// <summary>
        /// The Doppler factor. Set to 0 to disable.
        /// </summary>
        public float dopplerFactor;                /* Set to 0 to disable doppler effect. */
        /// <summary>
        /// The directional attenuation factor. Set to 0 to disable.
        /// </summary>
        public float directionalAttenuationFactor; /* Set to 0 to disable directional attenuation. */
        /// <summary>
        /// The number of frames for gain smoothing.
        /// </summary>
        public ma_uint32 gainSmoothTimeInFrames;   /* When the gain of a channel changes during spatialization, the transition will be linearly interpolated over this number of frames. */
        /// <summary>
        /// The current 3D position of the sound source (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f position;
        /// <summary>
        /// The current 3D direction of the sound source (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f direction;
        /// <summary>
        /// The current 3D velocity of the sound source for Doppler effect (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f velocity;  /* For doppler effect. */
        /// <summary>
        /// The Doppler pitch factor computed during processing. Can be used by higher-level code for pitch shifting.
        /// </summary>
        public float dopplerPitch; /* Will be updated by ma_spatializer_process_pcm_frames() and can be used by higher level functions to apply a pitch shift for doppler effect. */
        /// <summary>
        /// The minimal spatialization channel gain.
        /// </summary>
        public float minSpatializationChannelGain;
        /// <summary>
        /// Internal gainer used for smooth gain transitions.
        /// </summary>
        public ma_gainer gainer;   /* For smooth gain transitions. */
        /// <summary>
        /// Buffer for storing new channel gains during processing. Heap-allocated, offset of _pHeap.
        /// </summary>
        public IntPtr pNewChannelGainsOut; /* An offset of _pHeap. Used by ma_spatializer_process_pcm_frames() to store new channel gains. The number of elements in this array is equal to config.channelsOut. */
        /* Memory management. */
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
        /// <summary>
        /// Whether this spatializer owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
    }

    /// <summary>
    /// Configuration for a spatializer listener. Defines the listener's output setup and world parameters.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_listener_config
    {
        /// <summary>
        /// The number of output channels for the listener.
        /// </summary>
        public ma_uint32 channelsOut;
        /// <summary>
        /// Optional channel map for the output. Maps output channels to speaker positions.
        /// </summary>
        public ma_channel_ptr pChannelMapOut;
        /// <summary>
        /// The coordinate system handedness. Defaults to right-handed.
        /// </summary>
        public ma_handedness handedness;   /* Defaults to right. Forward is -1 on the Z axis. In a left handed system, forward is +1 on the Z axis. */
        /// <summary>
        /// The inner cone angle of the listener in radians.
        /// </summary>
        public float coneInnerAngleInRadians;
        /// <summary>
        /// The outer cone angle of the listener in radians.
        /// </summary>
        public float coneOuterAngleInRadians;
        /// <summary>
        /// The gain applied outside the outer cone.
        /// </summary>
        public float coneOuterGain;
        /// <summary>
        /// The speed of sound used for Doppler effect calculations.
        /// </summary>
        public float speedOfSound;
        /// <summary>
        /// The world up vector (e.g. (0, 1, 0) for Y-up).
        /// </summary>
        public ma_vec3f worldUp;
    }

    /// <summary>
    /// Runtime state for a spatializer listener. Represents the listener's position, direction, and velocity in 3D space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_spatializer_listener
    {
        /// <summary>
        /// The listener configuration.
        /// </summary>
        public ma_spatializer_listener_config config;
        /// <summary>
        /// The absolute 3D position of the listener (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f position;  /* The absolute position of the listener. */
        /// <summary>
        /// The direction the listener is facing. The world up vector is defined in config.worldUp (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f direction; /* The direction the listener is facing. The world up vector is config.worldUp. */
        /// <summary>
        /// The velocity of the listener for Doppler effect (thread-safe atomic).
        /// </summary>
        public ma_atomic_vec3f velocity;
        /// <summary>
        /// Whether the listener is enabled for spatialization.
        /// </summary>
        public ma_bool32 isEnabled;
        /* Memory management. */
        /// <summary>
        /// Whether this listener owns the heap allocation.
        /// </summary>
        public ma_bool32 _ownsHeap;
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        public IntPtr _pHeap;
    }

    /// <summary>
    /// Configuration for a waveform generator data source. Produces sine, square, triangle, and sawtooth waves.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_waveform_config
    {
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The type of waveform to generate.
        /// </summary>
        public ma_waveform_type type;
        /// <summary>
        /// The amplitude of the waveform.
        /// </summary>
        public double amplitude;
        /// <summary>
        /// The frequency of the waveform in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Runtime state for a waveform generator. Extends ma_data_source_base as a data source.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_waveform
    {
        /// <summary>
        /// The base data source state.
        /// </summary>
        public ma_data_source_base ds;
        /// <summary>
        /// The waveform configuration.
        /// </summary>
        public ma_waveform_config config;
        /// <summary>
        /// The phase advance per output frame.
        /// </summary>
        public double advance;
        /// <summary>
        /// The current phase time in seconds.
        /// </summary>
        public double time;
    }

    /// <summary>
    /// Configuration for a pulse wave generator. Produces a rectangular pulse with a configurable duty cycle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_pulsewave_config
    {
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The sample rate in Hz.
        /// </summary>
        public ma_uint32 sampleRate;
        /// <summary>
        /// The duty cycle of the pulse wave in the range 0..1.
        /// </summary>
        public double dutyCycle;
        /// <summary>
        /// The amplitude of the pulse wave.
        /// </summary>
        public double amplitude;
        /// <summary>
        /// The frequency in Hz.
        /// </summary>
        public double frequency;
    }

    /// <summary>
    /// Runtime state for a pulse wave generator. Internally uses a ma_waveform for the underlying oscillation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_pulsewave
    {
        /// <summary>
        /// The underlying waveform used for oscillation.
        /// </summary>
        public ma_waveform waveform;
        /// <summary>
        /// The pulse wave configuration.
        /// </summary>
        public ma_pulsewave_config config;
    }

    /// <summary>
    /// Configuration for a noise generator data source. Produces white, pink, or brownian noise.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_noise_config
    {
        /// <summary>
        /// The output sample format.
        /// </summary>
        public ma_format format;
        /// <summary>
        /// The number of output channels.
        /// </summary>
        public ma_uint32 channels;
        /// <summary>
        /// The type of noise to generate (white, pink, or brownian).
        /// </summary>
        public ma_noise_type type;
        /// <summary>
        /// The seed for the random number generator.
        /// </summary>
        public ma_int32 seed;
        /// <summary>
        /// The amplitude of the noise.
        /// </summary>
        public double amplitude;
        /// <summary>
        /// Whether to duplicate the same noise across all channels. If false, each channel gets independent noise.
        /// </summary>
        public ma_bool32 duplicateChannels;
    }

    /// <summary>
    /// A simple linear congruential generator (LCG) used for pseudo-random number generation in the noise generator.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_lcg
    {
        /// <summary>
        /// The current LCG state.
        /// </summary>
        public ma_uint32 state;
    }

    /// <summary>
    /// Runtime state for a noise generator. Extends ma_data_source_base as a data source. Supports white, pink, and brownian noise.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ma_noise
    {
        /// <summary>
        /// The base data source state.
        /// </summary>
        ma_data_source_base ds;
        /// <summary>
        /// The noise generator configuration.
        /// </summary>
        ma_noise_config config;
        /// <summary>
        /// The linear congruential generator for pseudo-random numbers.
        /// </summary>
        ma_lcg lcg;
        /// <summary>
        /// The noise state union (pink or brownian, depending on noise type).
        /// </summary>
        State state;
        /* Memory management. */
        /// <summary>
        /// Pointer to the internal heap memory.
        /// </summary>
        IntPtr _pHeap;
        /// <summary>
        /// Whether this noise generator owns the heap allocation.
        /// </summary>
        ma_bool32 _ownsHeap;

        /// <summary>
        /// Union of noise state types. Either pink noise or brownian noise state, depending on configuration.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct State
        {
            /// <summary>
            /// Pink noise state (Voss-McCartney algorithm).
            /// </summary>
            [FieldOffset(0)]
            public Pink pink;
            /// <summary>
            /// Brownian noise state (integrated white noise).
            /// </summary>
            [FieldOffset(0)]
            public Brownian brownian;

            /// <summary>
            /// State for pink noise generation using the Voss-McCartney algorithm. Contains frequency bins and accumulation buffers.
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct Pink
            {
                /// <summary>
                /// Pointer to the frequency bin array.
                /// </summary>
                public IntPtr bin;
                /// <summary>
                /// Pointer to the per-channel accumulation values.
                /// </summary>
                public IntPtr accumulation;
            }

            /// <summary>
            /// State for brownian noise generation. Integrates white noise for a random walk effect.
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct Brownian
            {
                /// <summary>
                /// Pointer to the per-channel accumulation values.
                /// </summary>
                public IntPtr accumulation;
            }
        }
    }
}
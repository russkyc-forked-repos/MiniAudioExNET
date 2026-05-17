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
    // ma_pointer_types
    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_uint32"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_uint32_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_uint32_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_uint32_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_uint32_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_uint32_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory via <see cref="MiniAudioNative.ma_allocate"/> with size <c>Marshal.SizeOf&lt;UInt32&gt;()</c>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate(Marshal.SizeOf<UInt32>());
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_uint32"/> data.
		/// </summary>
		/// <returns>A <c>ma_uint32*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt32* Get()
		{
			return (UInt32*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_async_notification"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_async_notification_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_async_notification_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_async_notification_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_async_notification_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_async_notification_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.async_notification);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_biquad_coefficient"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_biquad_coefficient_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_biquad_coefficient_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_biquad_coefficient_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_biquad_coefficient_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_biquad_coefficient_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.biquad_coefficient);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_biquad_coefficient"/> data.
		/// </summary>
		/// <returns>A <c>ma_biquad_coefficient*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_biquad_coefficient* Get()
		{
			return (ma_biquad_coefficient*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_channel"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_channel_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_channel_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_channel_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_channel_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_channel_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.channel);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_context"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_context_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_context_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_context_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_context_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_context_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.context);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_context"/> data.
        /// </summary>
        /// <returns>A <c>ma_context*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_context* Get()
        {
            return (ma_context*)pointer;
        }
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_data_source"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_data_source_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_data_source_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_data_source_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_data_source_node_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_data_source_node_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_data_source_node_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_data_source_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_data_source_node_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source_node);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_data_source_node"/> data.
        /// </summary>
        /// <returns>A <c>ma_data_source_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_data_source_node* Get()
        {
            return (ma_data_source_node*)pointer;
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_data_source_vtable"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_data_source_vtable_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_data_source_vtable_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_data_source_vtable_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_data_source_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_data_source_vtable_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source_vtable);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_data_source_vtable"/> data.
        /// </summary>
        /// <returns>A <c>ma_data_source_vtable*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_data_source_vtable* Get()
        {
            return (ma_data_source_vtable*)pointer;
        }
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_decoder"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_decoder_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_decoder_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_decoder_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_decoder_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_decoder_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.decoder);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_decoder"/> data.
		/// </summary>
		/// <returns>A <c>ma_decoder*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_decoder* Get()
		{
            return (ma_decoder*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_decoding_backend_vtable"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_decoding_backend_vtable_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_decoding_backend_vtable_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_decoding_backend_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_decoding_backend_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_decoding_backend_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.decoding_backend_vtable);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_decoding_backend_vtable"/> data.
		/// </summary>
		/// <returns>A <c>ma_decoding_backend_vtable*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_decoding_backend_vtable* Get()
		{
            return (ma_decoding_backend_vtable*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_encoder"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_encoder_ptr
    {
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_encoder_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_encoder_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_encoder_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_encoder_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.encoder);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_encoder"/> data.
		/// </summary>
		/// <returns>A <c>ma_encoder*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_encoder* Get()
		{
            return (ma_encoder*)pointer;
		}
    }

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_resampling"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_resampling_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_resampling_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_resampling_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_resampling_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_resampling_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_resampling);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_resampling"/> data.
		/// </summary>
		/// <returns>A <c>ma_device_resampling*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_resampling* Get()
		{
			return (ma_device_resampling*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_playback"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_playback_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_playback_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_playback_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_playback_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_playback_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_playback);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_playback"/> data.
		/// </summary>
		/// <returns>A <c>ma_device_playback*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_playback* Get()
		{
			return (ma_device_playback*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_capture"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_capture_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_capture_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_capture_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_capture_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_capture_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_capture);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_capture"/> data.
		/// </summary>
		/// <returns>A <c>ma_device_capture*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_capture* Get()
		{
			return (ma_device_capture*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device"/> data.
		/// </summary>
		/// <returns>A <c>ma_device*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device* Get()
		{
			return (ma_device*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_id"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_id_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_id_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_id_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_id_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_id_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_id);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_id"/> data.
		/// </summary>
		/// <returns>A <c>ma_device_id*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_id* Get()
		{
			return (ma_device_id*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_notification"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_notification_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_device_notification_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_device_notification_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_notification_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_device_notification_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_notification);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_descriptor"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_descriptor_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_device_descriptor_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_device_descriptor_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_descriptor_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_device_descriptor_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_descriptor);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_descriptor"/> data.
        /// </summary>
        /// <returns>A <c>ma_device_descriptor*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_descriptor* Get()
        {
            return (ma_device_descriptor*)pointer;            
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_device_info"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_info_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_device_info_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_device_info_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_device_info_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_device_info_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_info);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_device_info"/> data.
        /// </summary>
        /// <returns>A <c>ma_device_info*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_info* Get()
        {
            return (ma_device_info*)pointer;
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_effect_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_effect_node_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_effect_node_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_effect_node_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_effect_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_effect_node_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.effect_node);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_effect_node"/> data.
        /// </summary>
        /// <returns>A <c>ma_effect_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_effect_node* Get()
        {
            return (ma_effect_node*)pointer;
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_engine"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_engine_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_engine_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_engine_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_engine_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_engine_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.engine);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_engine"/> data.
        /// </summary>
        /// <returns>A <c>ma_engine*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_engine* Get()
        {
            return (ma_engine*)pointer;
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_fader"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_fader_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_fader_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_fader_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_fader_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_fader_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.fader);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_fader"/> data.
        /// </summary>
        /// <returns>A <c>ma_fader*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_fader* Get()
        {
            return (ma_fader*)pointer;
        }
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_fence"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_fence_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_fence_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_fence_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_fence_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_fence_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.fence);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_gainer"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_gainer_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_gainer_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_gainer_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_gainer_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_gainer_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.gainer);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_gainer"/> data.
        /// </summary>
        /// <returns>A <c>ma_gainer*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_gainer* Get()
        {
            return (ma_gainer*)pointer;
        }
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_log"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_log_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_log_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_log_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_log_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_log_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.log);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_log"/> data.
        /// </summary>
        /// <returns>A <c>ma_log*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_log* Get()
        {
            return (ma_log*)pointer;
        }
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_lpf"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_lpf_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_lpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_lpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_lpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_lpf"/> data.
		/// </summary>
		/// <returns>A <c>ma_lpf*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf* Get()
		{
			return (ma_lpf*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_lpf1"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf1_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_lpf1_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_lpf1_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_lpf1_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_lpf1_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf1);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_lpf1"/> data.
		/// </summary>
		/// <returns>A <c>ma_lpf1*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf1* Get()
		{
			return (ma_lpf1*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_lpf2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_lpf2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_lpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_lpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_lpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_lpf2"/> data.
		/// </summary>
		/// <returns>A <c>ma_lpf2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf2* Get()
		{
			return (ma_lpf2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hpf"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hpf_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hpf"/> data.
		/// </summary>
		/// <returns>A <c>ma_hpf*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf* Get()
		{
			return (ma_hpf*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hpf1"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf1_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hpf1_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hpf1_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hpf1_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hpf1_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf1);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hpf1"/> data.
		/// </summary>
		/// <returns>A <c>ma_hpf1*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf1* Get()
		{
			return (ma_hpf1*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hpf2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hpf2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hpf2"/> data.
		/// </summary>
		/// <returns>A <c>ma_hpf2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf2* Get()
		{
			return (ma_hpf2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_bpf"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_bpf_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_bpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_bpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_bpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_bpf"/> data.
		/// </summary>
		/// <returns>A <c>ma_bpf*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf* Get()
		{
			return (ma_bpf*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_bpf2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_bpf2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_bpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_bpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_bpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_bpf2"/> data.
		/// </summary>
		/// <returns>A <c>ma_bpf2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf2* Get()
		{
			return (ma_bpf2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_biquad"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_biquad_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_biquad_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_biquad_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_biquad_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_biquad_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.biquad);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_biquad"/> data.
		/// </summary>
		/// <returns>A <c>ma_biquad*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_biquad* Get()
		{
			return (ma_biquad*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_notch2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_notch2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_notch2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_notch2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_notch2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_notch2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.notch2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_notch2"/> data.
		/// </summary>
		/// <returns>A <c>ma_notch2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_notch2* Get()
		{
			return (ma_notch2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_peak2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_peak2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_peak2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_peak2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_peak2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_peak2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.peak2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_peak2"/> data.
		/// </summary>
		/// <returns>A <c>ma_peak2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_peak2* Get()
		{
			return (ma_peak2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_loshelf2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_loshelf2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_loshelf2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_loshelf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_loshelf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_loshelf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.loshelf2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_loshelf2"/> data.
		/// </summary>
		/// <returns>A <c>ma_loshelf2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_loshelf2* Get()
		{
			return (ma_loshelf2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hishelf2"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hishelf2_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hishelf2_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hishelf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hishelf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hishelf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hishelf2);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hishelf2"/> data.
		/// </summary>
		/// <returns>A <c>ma_hishelf2*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hishelf2* Get()
		{
			return (ma_hishelf2*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_lpf_node"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_lpf_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_lpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_lpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_lpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_lpf_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_lpf_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf_node* Get()
		{
			return (ma_lpf_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hpf_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hpf_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hpf_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_hpf_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf_node* Get()
		{
			return (ma_hpf_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_bpf_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_bpf_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_bpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_bpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_bpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_bpf_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_bpf_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf_node* Get()
		{
			return (ma_bpf_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_notch_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_notch_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_notch_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_notch_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_notch_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_notch_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.notch_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_notch_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_notch_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_notch_node* Get()
		{
			return (ma_notch_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_peak_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_peak_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_peak_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_peak_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_peak_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_peak_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.peak_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_peak_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_peak_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_peak_node* Get()
		{
			return (ma_peak_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_loshelf_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_loshelf_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_loshelf_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_loshelf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_loshelf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_loshelf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.loshelf_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_loshelf_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_loshelf_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_loshelf_node* Get()
		{
			return (ma_loshelf_node*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_hishelf_node"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hishelf_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_hishelf_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_hishelf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_hishelf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_hishelf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hishelf_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_hishelf_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_hishelf_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hishelf_node* Get()
		{
			return (ma_hishelf_node*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_delay"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_delay_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_delay_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_delay_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_delay_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_delay_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.delay);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_delay"/> data.
		/// </summary>
		/// <returns>A <c>ma_delay*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_delay* Get()
		{
			return (ma_delay*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_delay_node"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_delay_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_delay_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_delay_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_delay_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_delay_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.delay_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_delay_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_delay_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_delay_node* Get()
		{
			return (ma_delay_node*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_splitter_node"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_splitter_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_splitter_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_splitter_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_splitter_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_splitter_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.splitter_node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_splitter_node"/> data.
		/// </summary>
		/// <returns>A <c>ma_splitter_node*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_splitter_node* Get()
		{
			return (ma_splitter_node*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node_base"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_base_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_base_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_base_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_base_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_base_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_base);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_node_base"/> data.
		/// </summary>
		/// <returns>A <c>ma_node_base*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_base* Get()
		{
			return (ma_node_base*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node_graph"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_graph_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_graph_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_graph_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_graph_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_graph_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_graph);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_node_graph"/> data.
		/// </summary>
		/// <returns>A <c>ma_node_graph*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_graph* Get()
		{
			return (ma_node_graph*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node_input_bus"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_input_bus_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_input_bus_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_input_bus_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_input_bus_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_input_bus_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_input_bus);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_node_input_bus"/> data.
		/// </summary>
		/// <returns>A <c>ma_node_input_bus*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_input_bus* Get()
		{
			return (ma_node_input_bus*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node_output_bus"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_output_bus_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_output_bus_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_output_bus_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_output_bus_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_output_bus_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_output_bus);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_node_output_bus"/> data.
		/// </summary>
		/// <returns>A <c>ma_node_output_bus*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_output_bus* Get()
		{
			return (ma_node_output_bus*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_node_vtable"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_vtable_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_node_vtable_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_node_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_node_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_node_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_vtable);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_node_vtable"/> data.
		/// </summary>
		/// <returns>A <c>ma_node_vtable*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_vtable* Get()
		{
			return (ma_node_vtable*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_panner"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_panner_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_panner_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_panner_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_panner_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_panner_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.panner);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_panner"/> data.
		/// </summary>
		/// <returns>A <c>ma_panner*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_panner* Get()
		{
			return (ma_panner*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_procedural_data_source"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_procedural_data_source_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_procedural_data_source_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_procedural_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_procedural_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_procedural_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.procedural_data_source);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_procedural_data_source"/> data.
		/// </summary>
		/// <returns>A <c>ma_procedural_data_source*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_procedural_data_source* Get()
		{
			return (ma_procedural_data_source*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_resampling_backend_vtable"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resampling_backend_vtable_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_resampling_backend_vtable_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_resampling_backend_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_resampling_backend_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_resampling_backend_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resampling_backend_vtable);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_resource_manager"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resource_manager_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_resource_manager_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_resource_manager_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_resource_manager_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_resource_manager_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resource_manager);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_resource_manager_data_source"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resource_manager_data_source_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_resource_manager_data_source_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_resource_manager_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_resource_manager_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_resource_manager_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resource_manager_data_source);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}


    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_sound"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_sound_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_sound_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_sound_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_sound_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_sound_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_sound"/> data.
		/// </summary>
		/// <returns>A <c>ma_sound*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound* Get()
		{
			return (ma_sound*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_sound_inlined"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_sound_inlined_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_sound_inlined_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_sound_inlined_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_sound_inlined_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_sound_inlined_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound_inlined);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_sound_inlined"/> data.
		/// </summary>
		/// <returns>A <c>ma_sound_inlined*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound_inlined* Get()
		{
			return (ma_sound_inlined*)pointer;
		}
	}

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_sound_group"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ma_sound_group is an alias for ma_sound
    public unsafe struct ma_sound_group_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_sound_group_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_sound_group_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_sound_group_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_sound_group_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound_group);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_sound_group"/> data.
        /// </summary>
        /// <returns>A <c>ma_sound_group*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound* Get()
        {
            return (ma_sound*)pointer;
        }
    }

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_spatializer"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_spatializer_ptr
    {
        /// <summary>
        /// A pointer to the unmanaged memory for this type.
        /// </summary>
        public IntPtr pointer;
        /// <summary>
        /// Creates an uninitialized pointer wrapper.
        /// </summary>
        public ma_spatializer_ptr() { }
        /// <summary>
        /// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
        /// </summary>
        /// <param name="handle">The native pointer handle to wrap.</param>
        public ma_spatializer_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_spatializer_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        /// <summary>
        /// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
        /// </summary>
        /// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
        public ma_spatializer_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        /// <summary>
        /// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
        /// </summary>
        /// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.spatializer);
            return pointer != IntPtr.Zero;
        }
        /// <summary>
        /// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
        /// </summary>
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_spatializer"/> data.
        /// </summary>
        /// <returns>A <c>ma_spatializer*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_spatializer* Get()
        {
            return (ma_spatializer*)pointer;
        }
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_spatializer_listener"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_spatializer_listener_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_spatializer_listener_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_spatializer_listener_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_spatializer_listener_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_spatializer_listener_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.spatializer_listener);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_spatializer_listener"/> data.
		/// </summary>
		/// <returns>A <c>ma_spatializer_listener*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_spatializer_listener* Get()
		{
			return (ma_spatializer_listener*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_stack"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_stack_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_stack_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_stack_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_stack_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_stack_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.stack);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_stack"/> data.
		/// </summary>
		/// <returns>A <c>ma_stack*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_stack* Get()
		{
			return (ma_stack*)pointer;
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_vfs"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_vfs_ptr
	{
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_vfs_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_vfs_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_vfs_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_vfs_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.vfs);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	/// <summary>
	/// A pointer wrapper for the native <see cref="MiniAudioEx.ma_waveform"/> type.
	/// Provides managed memory allocation and deallocation via miniaudio's allocation API.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_waveform_ptr
    {
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_waveform_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_waveform_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_waveform_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_waveform_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.waveform);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_waveform"/> data.
		/// </summary>
		/// <returns>A <c>ma_waveform*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_waveform* Get()
		{
            return (ma_waveform*)pointer;
		}
    }

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_pulsewave"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_pulsewave_ptr
    {
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_pulsewave_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_pulsewave_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_pulsewave_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_pulsewave_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.pulsewave);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_pulsewave"/> data.
		/// </summary>
		/// <returns>A <c>ma_pulsewave*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_pulsewave* Get()
		{
            return (ma_pulsewave*)pointer;
		}
    }

    /// <summary>
    /// A pointer wrapper for the native <see cref="MiniAudioEx.ma_noise"/> type.
    /// Provides managed memory allocation and deallocation via miniaudio's allocation API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_noise_ptr
    {
		/// <summary>
		/// A pointer to the unmanaged memory for this type.
		/// </summary>
		public IntPtr pointer;
		/// <summary>
		/// Creates an uninitialized pointer wrapper.
		/// </summary>
		public ma_noise_ptr() { }
		/// <summary>
		/// Creates a pointer wrapper from an existing <see cref="IntPtr"/> handle.
		/// </summary>
		/// <param name="handle">The native pointer handle to wrap.</param>
		public ma_noise_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		/// <summary>
		/// Creates a pointer wrapper from a native <c>void*</c> pointer.
		/// </summary>
		/// <param name="handle">The native void pointer to wrap.</param>
		public ma_noise_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		/// <summary>
		/// Creates a pointer wrapper and optionally allocates unmanaged memory for the native type.
		/// </summary>
		/// <param name="allocate">If <c>true</c>, allocates memory via the miniaudio allocation API.</param>
		public ma_noise_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		/// <summary>
		/// Allocates unmanaged memory for the native type via <see cref="MiniAudioNative.ma_allocate_type"/>.
		/// </summary>
		/// <returns><c>true</c> if allocation succeeded; otherwise, <c>false</c>.</returns>
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.noise);
			return pointer != IntPtr.Zero;
		}
		/// <summary>
		/// Deallocates the unmanaged memory via <see cref="MiniAudioNative.ma_deallocate_type"/> and sets the pointer to <see cref="IntPtr.Zero"/>.
		/// </summary>
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// Returns a typed pointer to the underlying <see cref="MiniAudioEx.ma_noise"/> data.
		/// </summary>
		/// <returns>A <c>ma_noise*</c> pointer cast from the wrapped <see cref="IntPtr"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_noise* Get()
		{
            return (ma_noise*)pointer;
		}
    }
}

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
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_uint32_ptr
    {
        public IntPtr pointer;
        public ma_uint32_ptr() { }
        public ma_uint32_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_uint32_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_uint32_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate(Marshal.SizeOf<UInt32>());
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt32* Get()
		{
			return (UInt32*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_async_notification_ptr
	{
		public IntPtr pointer;
		public ma_async_notification_ptr() { }
		public ma_async_notification_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_async_notification_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_async_notification_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.async_notification);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_biquad_coefficient_ptr
	{
		public IntPtr pointer;
		public ma_biquad_coefficient_ptr() { }
		public ma_biquad_coefficient_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_biquad_coefficient_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_biquad_coefficient_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.biquad_coefficient);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_biquad_coefficient* Get()
		{
			return (ma_biquad_coefficient*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_channel_ptr
	{
		public IntPtr pointer;
		public ma_channel_ptr() { }
		public ma_channel_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_channel_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_channel_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.channel);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_context_ptr
    {
        public IntPtr pointer;
        public ma_context_ptr() { }
        public ma_context_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_context_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_context_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.context);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_context* Get()
        {
            return (ma_context*)pointer;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_data_source_ptr
	{
		public IntPtr pointer;
		public ma_data_source_ptr() { }
		public ma_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_data_source_node_ptr
    {
        public IntPtr pointer;
        public ma_data_source_node_ptr() { }
        public ma_data_source_node_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_data_source_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_data_source_node_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source_node);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_data_source_node* Get()
        {
            return (ma_data_source_node*)pointer;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_data_source_vtable_ptr
    {
        public IntPtr pointer;
        public ma_data_source_vtable_ptr() { }
        public ma_data_source_vtable_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_data_source_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_data_source_vtable_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.data_source_vtable);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_data_source_vtable* Get()
        {
            return (ma_data_source_vtable*)pointer;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_decoder_ptr
	{
		public IntPtr pointer;
		public ma_decoder_ptr() { }
		public ma_decoder_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_decoder_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_decoder_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.decoder);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_decoder* Get()
		{
            return (ma_decoder*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_decoding_backend_vtable_ptr
	{
		public IntPtr pointer;
		public ma_decoding_backend_vtable_ptr() { }
		public ma_decoding_backend_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_decoding_backend_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_decoding_backend_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.decoding_backend_vtable);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_decoding_backend_vtable* Get()
		{
            return (ma_decoding_backend_vtable*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_encoder_ptr
    {
		public IntPtr pointer;
		public ma_encoder_ptr() { }
		public ma_encoder_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_encoder_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_encoder_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.encoder);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_encoder* Get()
		{
            return (ma_encoder*)pointer;
		}
    }

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_ptr
	{
		public IntPtr pointer;
		public ma_device_ptr() { }
		public ma_device_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_device_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_device_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device* Get()
		{
			return (ma_device*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_id_ptr
	{
		public IntPtr pointer;
		public ma_device_id_ptr() { }
		public ma_device_id_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_device_id_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_device_id_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_id);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_id* Get()
		{
			return (ma_device_id*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_notification_ptr
    {
        public IntPtr pointer;
        public ma_device_notification_ptr() { }
        public ma_device_notification_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_device_notification_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_device_notification_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_notification);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_device_descriptor_ptr
    {
        public IntPtr pointer;
        public ma_device_descriptor_ptr() { }
        public ma_device_descriptor_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_device_descriptor_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_device_descriptor_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_descriptor);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_descriptor* Get()
        {
            return (ma_device_descriptor*)pointer;            
        }
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_device_info_ptr
	{
		public IntPtr pointer;
		public ma_device_info_ptr() { }
		public ma_device_info_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_device_info_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_device_info_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.device_info);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_device_info* Get()
        {
            return (ma_device_info*)pointer;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_effect_node_ptr
    {
        public IntPtr pointer;
        public ma_effect_node_ptr() { }
        public ma_effect_node_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_effect_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_effect_node_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.effect_node);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_effect_node* Get()
        {
            return (ma_effect_node*)pointer;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_engine_ptr
    {
        public IntPtr pointer;
        public ma_engine_ptr() { }
        public ma_engine_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_engine_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_engine_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.engine);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_engine* Get()
        {
            return (ma_engine*)pointer;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_fader_ptr
    {
        public IntPtr pointer;
        public ma_fader_ptr() { }
        public ma_fader_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_fader_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_fader_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.fader);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_fader* Get()
        {
            return (ma_fader*)pointer;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_fence_ptr
	{
		public IntPtr pointer;
		public ma_fence_ptr() { }
		public ma_fence_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_fence_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_fence_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.fence);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_gainer_ptr
    {
        public IntPtr pointer;
        public ma_gainer_ptr() { }
        public ma_gainer_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_gainer_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_gainer_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.gainer);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_gainer* Get()
        {
            return (ma_gainer*)pointer;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_log_ptr
	{
		public IntPtr pointer;
		public ma_log_ptr() { }
		public ma_log_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_log_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_log_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.log);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_log* Get()
        {
            return (ma_log*)pointer;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf_ptr
	{
		public IntPtr pointer;
		public ma_lpf_ptr() { }
		public ma_lpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_lpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_lpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf* Get()
		{
			return (ma_lpf*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf1_ptr
	{
		public IntPtr pointer;
		public ma_lpf1_ptr() { }
		public ma_lpf1_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_lpf1_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_lpf1_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf1);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf1* Get()
		{
			return (ma_lpf1*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf2_ptr
	{
		public IntPtr pointer;
		public ma_lpf2_ptr() { }
		public ma_lpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_lpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_lpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf2* Get()
		{
			return (ma_lpf2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf_ptr
	{
		public IntPtr pointer;
		public ma_hpf_ptr() { }
		public ma_hpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf* Get()
		{
			return (ma_hpf*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf1_ptr
	{
		public IntPtr pointer;
		public ma_hpf1_ptr() { }
		public ma_hpf1_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hpf1_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hpf1_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf1);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf1* Get()
		{
			return (ma_hpf1*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf2_ptr
	{
		public IntPtr pointer;
		public ma_hpf2_ptr() { }
		public ma_hpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf2* Get()
		{
			return (ma_hpf2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf_ptr
	{
		public IntPtr pointer;
		public ma_bpf_ptr() { }
		public ma_bpf_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_bpf_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_bpf_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf* Get()
		{
			return (ma_bpf*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf2_ptr
	{
		public IntPtr pointer;
		public ma_bpf2_ptr() { }
		public ma_bpf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_bpf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_bpf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf2* Get()
		{
			return (ma_bpf2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_biquad_ptr
	{
		public IntPtr pointer;
		public ma_biquad_ptr() { }
		public ma_biquad_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_biquad_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_biquad_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.biquad);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_biquad* Get()
		{
			return (ma_biquad*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_notch2_ptr
	{
		public IntPtr pointer;
		public ma_notch2_ptr() { }
		public ma_notch2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_notch2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_notch2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.notch2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_notch2* Get()
		{
			return (ma_notch2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_peak2_ptr
	{
		public IntPtr pointer;
		public ma_peak2_ptr() { }
		public ma_peak2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_peak2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_peak2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.peak2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_peak2* Get()
		{
			return (ma_peak2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_loshelf2_ptr
	{
		public IntPtr pointer;
		public ma_loshelf2_ptr() { }
		public ma_loshelf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_loshelf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_loshelf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.loshelf2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_loshelf2* Get()
		{
			return (ma_loshelf2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hishelf2_ptr
	{
		public IntPtr pointer;
		public ma_hishelf2_ptr() { }
		public ma_hishelf2_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hishelf2_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hishelf2_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hishelf2);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hishelf2* Get()
		{
			return (ma_hishelf2*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_lpf_node_ptr
	{
		public IntPtr pointer;
		public ma_lpf_node_ptr() { }
		public ma_lpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_lpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_lpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.lpf_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_lpf_node* Get()
		{
			return (ma_lpf_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hpf_node_ptr
	{
		public IntPtr pointer;
		public ma_hpf_node_ptr() { }
		public ma_hpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hpf_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hpf_node* Get()
		{
			return (ma_hpf_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_bpf_node_ptr
	{
		public IntPtr pointer;
		public ma_bpf_node_ptr() { }
		public ma_bpf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_bpf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_bpf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.bpf_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_bpf_node* Get()
		{
			return (ma_bpf_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_notch_node_ptr
	{
		public IntPtr pointer;
		public ma_notch_node_ptr() { }
		public ma_notch_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_notch_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_notch_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.notch_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_notch_node* Get()
		{
			return (ma_notch_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_peak_node_ptr
	{
		public IntPtr pointer;
		public ma_peak_node_ptr() { }
		public ma_peak_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_peak_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_peak_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.peak_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_peak_node* Get()
		{
			return (ma_peak_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_loshelf_node_ptr
	{
		public IntPtr pointer;
		public ma_loshelf_node_ptr() { }
		public ma_loshelf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_loshelf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_loshelf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.loshelf_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_loshelf_node* Get()
		{
			return (ma_loshelf_node*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_hishelf_node_ptr
	{
		public IntPtr pointer;
		public ma_hishelf_node_ptr() { }
		public ma_hishelf_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_hishelf_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_hishelf_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.hishelf_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_hishelf_node* Get()
		{
			return (ma_hishelf_node*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_delay_ptr
	{
		public IntPtr pointer;
		public ma_delay_ptr() { }
		public ma_delay_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_delay_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_delay_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.delay);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_delay* Get()
		{
			return (ma_delay*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_delay_node_ptr
	{
		public IntPtr pointer;
		public ma_delay_node_ptr() { }
		public ma_delay_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_delay_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_delay_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.delay_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_delay_node* Get()
		{
			return (ma_delay_node*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_splitter_node_ptr
	{
		public IntPtr pointer;
		public ma_splitter_node_ptr() { }
		public ma_splitter_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_splitter_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_splitter_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.splitter_node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_splitter_node* Get()
		{
			return (ma_splitter_node*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_ptr
	{
		public IntPtr pointer;
		public ma_node_ptr() { }
		public ma_node_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_base_ptr
	{
		public IntPtr pointer;
		public ma_node_base_ptr() { }
		public ma_node_base_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_base_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_base_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_base);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_base* Get()
		{
			return (ma_node_base*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_graph_ptr
	{
		public IntPtr pointer;
		public ma_node_graph_ptr() { }
		public ma_node_graph_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_graph_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_graph_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_graph);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_graph* Get()
		{
			return (ma_node_graph*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_input_bus_ptr
	{
		public IntPtr pointer;
		public ma_node_input_bus_ptr() { }
		public ma_node_input_bus_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_input_bus_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_input_bus_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_input_bus);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_input_bus* Get()
		{
			return (ma_node_input_bus*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_output_bus_ptr
	{
		public IntPtr pointer;
		public ma_node_output_bus_ptr() { }
		public ma_node_output_bus_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_output_bus_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_output_bus_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_output_bus);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_output_bus* Get()
		{
			return (ma_node_output_bus*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_node_vtable_ptr
	{
		public IntPtr pointer;
		public ma_node_vtable_ptr() { }
		public ma_node_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_node_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_node_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.node_vtable);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_node_vtable* Get()
		{
			return (ma_node_vtable*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_panner_ptr
	{
		public IntPtr pointer;
		public ma_panner_ptr() { }
		public ma_panner_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_panner_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_panner_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.panner);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_panner* Get()
		{
			return (ma_panner*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_procedural_data_source_ptr
	{
		public IntPtr pointer;
		public ma_procedural_data_source_ptr() { }
		public ma_procedural_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_procedural_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_procedural_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.procedural_data_source);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_procedural_data_source* Get()
		{
			return (ma_procedural_data_source*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resampling_backend_vtable_ptr
	{
		public IntPtr pointer;
		public ma_resampling_backend_vtable_ptr() { }
		public ma_resampling_backend_vtable_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_resampling_backend_vtable_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_resampling_backend_vtable_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resampling_backend_vtable);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resource_manager_ptr
	{
		public IntPtr pointer;
		public ma_resource_manager_ptr() { }
		public ma_resource_manager_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_resource_manager_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_resource_manager_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resource_manager);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

    [StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_resource_manager_data_source_ptr
	{
		public IntPtr pointer;
		public ma_resource_manager_data_source_ptr() { }
		public ma_resource_manager_data_source_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_resource_manager_data_source_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_resource_manager_data_source_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.resource_manager_data_source);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}


    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_sound_ptr
    {
        public IntPtr pointer;
        public ma_sound_ptr() { }
        public ma_sound_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_sound_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_sound_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound* Get()
		{
			return (ma_sound*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_sound_inlined_ptr
    {
        public IntPtr pointer;
        public ma_sound_inlined_ptr() { }
        public ma_sound_inlined_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_sound_inlined_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_sound_inlined_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound_inlined);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound_inlined* Get()
		{
			return (ma_sound_inlined*)pointer;
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    // ma_sound_group is an alias for ma_sound
    public unsafe struct ma_sound_group_ptr
    {
        public IntPtr pointer;
        public ma_sound_group_ptr() { }
        public ma_sound_group_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_sound_group_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_sound_group_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.sound_group);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_sound* Get()
        {
            return (ma_sound*)pointer;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_spatializer_ptr
    {
        public IntPtr pointer;
        public ma_spatializer_ptr() { }
        public ma_spatializer_ptr(IntPtr handle)
        {
            pointer = handle;
        }
		public ma_spatializer_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
        public ma_spatializer_ptr(bool allocate)
        {
            if (allocate)
                Allocate();
        }
        public bool Allocate()
        {
            pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.spatializer);
            return pointer != IntPtr.Zero;
        }
        public void Free()
        {
            if (pointer != IntPtr.Zero)
            {
                MiniAudioNative.ma_deallocate_type(pointer);
                pointer = IntPtr.Zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_spatializer* Get()
        {
            return (ma_spatializer*)pointer;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_spatializer_listener_ptr
	{
		public IntPtr pointer;
		public ma_spatializer_listener_ptr() { }
		public ma_spatializer_listener_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_spatializer_listener_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_spatializer_listener_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.spatializer_listener);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_spatializer_listener* Get()
		{
			return (ma_spatializer_listener*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_stack_ptr
	{
		public IntPtr pointer;
		public ma_stack_ptr() { }
		public ma_stack_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_stack_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_stack_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.stack);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_stack* Get()
		{
			return (ma_stack*)pointer;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ma_vfs_ptr
	{
		public IntPtr pointer;
		public ma_vfs_ptr() { }
		public ma_vfs_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_vfs_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_vfs_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.vfs);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
	}

[StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_waveform_ptr
    {
		public IntPtr pointer;
		public ma_waveform_ptr() { }
		public ma_waveform_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_waveform_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_waveform_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.waveform);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_waveform* Get()
		{
            return (ma_waveform*)pointer;
		}
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_pulsewave_ptr
    {
		public IntPtr pointer;
		public ma_pulsewave_ptr() { }
		public ma_pulsewave_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_pulsewave_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_pulsewave_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.pulsewave);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_pulsewave* Get()
		{
            return (ma_pulsewave*)pointer;
		}
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ma_noise_ptr
    {
		public IntPtr pointer;
		public ma_noise_ptr() { }
		public ma_noise_ptr(IntPtr handle)
		{
			pointer = handle;
		}
		public ma_noise_ptr(void* handle)
		{
			pointer = new IntPtr(handle);
		}
		public ma_noise_ptr(bool allocate)
		{
			if (allocate)
				Allocate();
		}
		public bool Allocate()
		{
			pointer = MiniAudioNative.ma_allocate_type(ma_allocation_type.noise);
			return pointer != IntPtr.Zero;
		}
		public void Free()
		{
			if (pointer != IntPtr.Zero)
			{
				MiniAudioNative.ma_deallocate_type(pointer);
				pointer = IntPtr.Zero;
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ma_noise* Get()
		{
            return (ma_noise*)pointer;
		}
    }
}
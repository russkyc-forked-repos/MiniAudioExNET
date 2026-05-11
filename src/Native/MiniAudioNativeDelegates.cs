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
using System.Runtime.InteropServices;

namespace MiniAudioEx.Native
{
    // ma_typedefs
    using ma_bool32 = UInt32;
    using ma_uint32 = UInt32;
    using ma_int64 = Int64;
    using ma_uint64 = UInt64;

    // ma_callbacks
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_sound_end_proc(IntPtr pUserData, ma_sound_ptr pSound);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_procedural_data_source_proc(IntPtr pUserData, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint32 channels);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_device_data_proc(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, ma_uint32 frameCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_device_notification_proc(ma_device_notification_ptr pNotification);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_stop_proc(ma_device_ptr pDevice);  /* DEPRECATED. Use ma_device_notification_proc instead. */

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_bool32 ma_enum_devices_callback_proc(ma_context_ptr pContext, ma_device_type deviceType, ma_device_info pInfo, IntPtr pUserData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_engine_process_proc(IntPtr pUserData, IntPtr pFramesOut, ma_uint64 frameCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_read_proc(ma_decoder_ptr pDecoder, IntPtr pBufferOut, size_t bytesToRead, out size_t pBytesRead);         /* Returns the number of bytes read. */

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_seek_proc(ma_decoder_ptr pDecoder, ma_int64 byteOffset, ma_seek_origin origin);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_tell_proc(ma_decoder_ptr pDecoder, ref ma_int64 pCursor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_data_source_ptr ma_data_source_get_next_proc(ma_data_source_ptr pDataSource);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_log_callback_proc(IntPtr pUserData, ma_uint32 level, IntPtr pMessage);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_node_vtable_process_proc(ma_node_ptr pNode, IntPtr ppFramesIn, IntPtr pFrameCountIn, IntPtr ppFramesOut, IntPtr pFrameCountOut);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_node_vtable_get_required_input_frame_count_proc(ma_node_ptr pNode, ma_uint32 outputFrameCount, IntPtr pInputFrameCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr ma_allocation_callbacks_malloc_proc(size_t sz, IntPtr pUserData);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr ma_allocation_callbacks_realloc_proc(IntPtr p, size_t sz, IntPtr pUserData);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_allocation_callbacks_free_proc(IntPtr p, IntPtr pUserData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_init_proc(ma_context_ptr pContext, ref ma_context_config pConfig, ref ma_backend_callbacks pCallbacks);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_uninit_proc(ma_context_ptr pContext);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_enumerate_devices_proc(ma_context_ptr pContext, ma_enum_devices_callback_proc callback, IntPtr pUserData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_get_device_info_proc(ma_context_ptr pContext, ma_device_type deviceType, ma_device_id_ptr pDeviceID, ma_device_info_ptr pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_init_proc(ma_device_ptr pDevice, ref ma_device_config pConfig, ma_device_descriptor_ptr pDescriptorPlayback, ma_device_descriptor_ptr pDescriptorCapture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_uninit_proc(ma_device_ptr pDevice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_start_proc(ma_device_ptr pDevice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_stop_proc(ma_device_ptr pDevice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_read_proc(ma_device_ptr pDevice, IntPtr pFrames, ma_uint32 frameCount, IntPtr pFramesRead);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_write_proc(ma_device_ptr pDevice, IntPtr pFrames, ma_uint32 frameCount, IntPtr pFramesWritten);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_dataloop_proc(ma_device_ptr pDevice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_dataloop_wakeup_proc(ma_device_ptr pDevice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_get_info_proc(ma_device_ptr pDevice, ma_device_type type, ma_device_info_ptr pDeviceInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_read_proc(ma_data_source_ptr pDataSource, IntPtr pFramesOut, ma_uint64 frameCount, out UInt64 pFramesRead);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_seek_proc(ma_data_source_ptr pDataSource, ma_uint64 frameIndex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_data_format_proc(ma_data_source_ptr pDataSource, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_cursor_proc(ma_data_source_ptr pDataSource, out UInt64 pCursor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_length_proc(ma_data_source_ptr pDataSource, IntPtr pLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_set_looping_proc(ma_data_source_ptr pDataSource, ma_bool32 isLooping);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_effect_node_process_proc(ma_node_ptr pNode, IntPtr ppFramesIn, IntPtr pFrameCountIn, IntPtr ppFramesOut, IntPtr pFrameCountOut);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_write_proc(ma_encoder_ptr pEncoder, IntPtr pBufferIn, size_t bytesToWrite, out size_t pBytesWritten);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_seek_proc(ma_encoder_ptr pEncoder, ma_int64 offset, ma_seek_origin origin);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_init_proc(ma_encoder_ptr pEncoder);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_encoder_uninit_proc(ma_encoder_ptr pEncoder);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_write_pcm_frames_proc(ma_encoder_ptr pEncoder, IntPtr pFramesIn, ma_uint64 frameCount, out ma_uint64 pFramesWritten);
}
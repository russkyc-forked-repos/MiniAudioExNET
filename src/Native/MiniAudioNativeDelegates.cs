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

    /// <summary>
    /// Callback for when a sound reaches the end. This is fired from the audio thread.
    /// Do not restart, uninitialize or otherwise change the state of the sound from
    /// this callback. Instead fire an event or set a variable to indicate to a
    /// different thread to change the state of the sound. Will not be fired in
    /// response to a scheduled stop with ma_sound_set_stop_time_*().
    /// </summary>
    /// <param name="pUserData">A pointer to user data associated with the callback.</param>
    /// <param name="pSound">A pointer to the ma_sound that has reached the end.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_sound_end_proc(IntPtr pUserData, ma_sound_ptr pSound);

    /// <summary>
    /// Callback for reading audio data from a procedural data source. This is invoked
    /// each time the data source needs to generate audio data programmatically, such as
    /// for waveform or noise generation, or for any custom data source that synthesizes
    /// audio dynamically rather than reading from a file or memory buffer.
    /// </summary>
    /// <param name="pUserData">A pointer to user data associated with the callback.</param>
    /// <param name="pFramesOut">A pointer to the output buffer that will receive the generated PCM frames.</param>
    /// <param name="frameCount">The number of PCM frames to generate.</param>
    /// <param name="channels">The number of audio channels.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_procedural_data_source_proc(IntPtr pUserData, IntPtr pFramesOut, ma_uint64 frameCount, ma_uint32 channels);

    /// <summary>
    /// The callback for processing audio data from the device. This is fired by miniaudio
    /// whenever the device needs to have more data delivered to a playback device, or
    /// when a capture device has some data available. This is called as soon as the
    /// backend asks for more data which means it may be called with inconsistent frame
    /// counts. You cannot assume the callback will be fired with a consistent frame count.
    /// </summary>
    /// <param name="pDevice">A pointer to the relevant device.</param>
    /// <param name="pOutput">A pointer to the output buffer that will receive audio data for playback.
    /// This will be non-null for a playback or full-duplex device and null for a capture and loopback device.</param>
    /// <param name="pInput">A pointer to the buffer containing input data from a recording device.
    /// This will be non-null for a capture, full-duplex or loopback device and null for a playback device.</param>
    /// <param name="frameCount">The number of PCM frames to process. Note that this will not necessarily
    /// be equal to what was requested when the device was initialized. The periodSizeInFrames and
    /// periodSizeInMilliseconds members of the device config are just hints.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_device_data_proc(ma_device_ptr pDevice, IntPtr pOutput, IntPtr pInput, ma_uint32 frameCount);

    /// <summary>
    /// The notification callback for when the application should be notified of a change
    /// to the device. This callback is used for notifying the application of changes such
    /// as when the device has started, stopped, rerouted or an interruption has occurred.
    /// Note that not all backends will post all notification types. Do not restart or
    /// uninitialize the device from this callback.
    /// </summary>
    /// <param name="pNotification">A pointer to a structure containing information about the event.
    /// Use the type member to discriminate against each of the notification types (started,
    /// stopped, rerouted, interruption).</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_device_notification_proc(ma_device_notification_ptr pNotification);

    /// <summary>
    /// Callback for when the device has stopped. This will be called when the device is
    /// stopped explicitly with ma_device_stop() and also called implicitly when the device
    /// is stopped through external forces such as being unplugged or an internal error
    /// occurring. Do not restart or uninitialize the device from the callback.
    /// </summary>
    /// <param name="pDevice">A pointer to the device that has just stopped.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_stop_proc(ma_device_ptr pDevice);  /* DEPRECATED. Use ma_device_notification_proc instead. */

    /// <summary>
    /// The callback for handling device enumeration. This is fired from
    /// ma_context_enumerate_devices(). The return value indicates whether
    /// enumeration should continue. Return non-zero (MA_TRUE) to continue
    /// enumerating, or zero (MA_FALSE) to stop.
    /// </summary>
    /// <param name="pContext">A pointer to the context performing the enumeration.</param>
    /// <param name="deviceType">The type of the device being enumerated. This will always
    /// be either ma_device_type_playback or ma_device_type_capture.</param>
    /// <param name="pInfo">A pointer to a ma_device_info containing the ID and name of
    /// the enumerated device. Note that this will not include detailed information about
    /// the device, only basic information (ID and name).</param>
    /// <param name="pUserData">The user data pointer passed into ma_context_enumerate_devices().</param>
    /// <returns>MA_TRUE (non-zero) to continue enumeration or MA_FALSE (zero) to stop.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_bool32 ma_enum_devices_callback_proc(ma_context_ptr pContext, ma_device_type deviceType, ma_device_info pInfo, IntPtr pUserData);

    /// <summary>
    /// Callback for custom processing of engine output audio data. This is invoked by
    /// the engine to allow custom processing or inspection of the final mixed audio
    /// frames before they are sent to the device.
    /// </summary>
    /// <param name="pUserData">A pointer to user data associated with the callback.</param>
    /// <param name="pFramesOut">A pointer to the buffer of output PCM frames to process.</param>
    /// <param name="frameCount">The number of PCM frames in the buffer.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_engine_process_proc(IntPtr pUserData, IntPtr pFramesOut, ma_uint64 frameCount);

    /// <summary>
    /// Callback for reading raw bytes from a decoder. This is invoked when the decoder
    /// needs to read uncompressed audio data from the underlying source. Returns the
    /// number of bytes read via the pBytesRead output parameter.
    /// </summary>
    /// <param name="pDecoder">A pointer to the decoder from which to read.</param>
    /// <param name="pBufferOut">A pointer to the buffer that will receive the read bytes.</param>
    /// <param name="bytesToRead">The number of bytes to read.</param>
    /// <param name="pBytesRead">Output parameter that receives the number of bytes actually read.</param>
    /// <returns>MA_SUCCESS if the read operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_read_proc(ma_decoder_ptr pDecoder, IntPtr pBufferOut, size_t bytesToRead, out size_t pBytesRead);         /* Returns the number of bytes read. */

    /// <summary>
    /// Callback for seeking to a specific byte offset within a decoder. This allows
    /// repositioning the read cursor to a specific location within the audio data.
    /// </summary>
    /// <param name="pDecoder">A pointer to the decoder to seek within.</param>
    /// <param name="byteOffset">The byte offset to seek to, interpreted relative to the origin parameter.</param>
    /// <param name="origin">The seek origin specifying how to interpret the byte offset.</param>
    /// <returns>MA_SUCCESS if the seek operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_seek_proc(ma_decoder_ptr pDecoder, ma_int64 byteOffset, ma_seek_origin origin);

    /// <summary>
    /// Callback for retrieving the current read cursor position of a decoder in bytes.
    /// </summary>
    /// <param name="pDecoder">A pointer to the decoder to query.</param>
    /// <param name="pCursor">A reference that receives the current cursor position in bytes.</param>
    /// <returns>MA_SUCCESS if the operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_decoder_tell_proc(ma_decoder_ptr pDecoder, ref ma_int64 pCursor);

    /// <summary>
    /// Callback for retrieving the next data source in a data source chain. This is used
    /// to support seamless chaining of data sources, allowing one data source to hand off
    /// to another when it reaches the end of its data.
    /// </summary>
    /// <param name="pDataSource">A pointer to the current data source.</param>
    /// <returns>A pointer to the next data source in the chain, or NULL if there is no next data source.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_data_source_ptr ma_data_source_get_next_proc(ma_data_source_ptr pDataSource);

    /// <summary>
    /// The callback for handling log messages from miniaudio. This is invoked whenever
    /// miniaudio posts a log message, allowing the application to capture and handle
    /// diagnostic output.
    /// </summary>
    /// <param name="pUserData">The user data pointer that was passed into ma_log_register_callback().</param>
    /// <param name="level">The log level. This can be one of MA_LOG_LEVEL_DEBUG, MA_LOG_LEVEL_INFO,
    /// MA_LOG_LEVEL_WARNING, or MA_LOG_LEVEL_ERROR.</param>
    /// <param name="pMessage">A pointer to the null-terminated log message string.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_log_callback_proc(IntPtr pUserData, ma_uint32 level, IntPtr pMessage);

    /// <summary>
    /// Extended processing callback for the audio node graph. This callback is used for
    /// effects and nodes that process input and output at potentially different rates
    /// (e.g. nodes that perform resampling). On input, pFrameCountOut is equal to the
    /// capacity of the output buffer for each bus, whereas pFrameCountIn will be equal
    /// to the number of PCM frames in each of the buffers in ppFramesIn. On output,
    /// set pFrameCountOut to the number of PCM frames that were actually output and
    /// set pFrameCountIn to the number of input frames that were consumed.
    /// </summary>
    /// <param name="pNode">A pointer to the node being processed.</param>
    /// <param name="ppFramesIn">A pointer to an array of input buffer pointers, one per input bus.</param>
    /// <param name="pFrameCountIn">A pointer to an array of frame counts for each input bus.</param>
    /// <param name="ppFramesOut">A pointer to an array of output buffer pointers, one per output bus.</param>
    /// <param name="pFrameCountOut">A pointer to an array of frame counts for each output bus.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_node_vtable_process_proc(ma_node_ptr pNode, IntPtr ppFramesIn, IntPtr pFrameCountIn, IntPtr ppFramesOut, IntPtr pFrameCountOut);

    /// <summary>
    /// A callback for retrieving the number of input frames that are required to output
    /// the specified number of output frames. This is useful for nodes that perform
    /// resampling and helps miniaudio reduce latency by calculating the exact number
    /// of input frames to read at a time instead of having to estimate. This is optional,
    /// even for nodes that perform resampling.
    /// </summary>
    /// <param name="pNode">A pointer to the node being queried.</param>
    /// <param name="outputFrameCount">The number of output frames that are desired.</param>
    /// <param name="pInputFrameCount">A pointer that receives the number of input frames required.</param>
    /// <returns>MA_SUCCESS if the operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_node_vtable_get_required_input_frame_count_proc(ma_node_ptr pNode, ma_uint32 outputFrameCount, IntPtr pInputFrameCount);

    /// <summary>
    /// Custom memory allocation callback. Invoked by miniaudio when memory needs to
    /// be allocated. This is the first member of the ma_allocation_callbacks structure.
    /// </summary>
    /// <param name="sz">The number of bytes to allocate.</param>
    /// <param name="pUserData">A pointer to user data associated with the allocation callbacks.</param>
    /// <returns>A pointer to the allocated memory block, or NULL if allocation failed.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr ma_allocation_callbacks_malloc_proc(size_t sz, IntPtr pUserData);

    /// <summary>
    /// Custom memory reallocation callback. Invoked by miniaudio when an existing memory
    /// block needs to be resized. This is the second member of the ma_allocation_callbacks
    /// structure.
    /// </summary>
    /// <param name="p">A pointer to the existing memory block to reallocate, or NULL to allocate a new block.</param>
    /// <param name="sz">The new number of bytes for the memory block.</param>
    /// <param name="pUserData">A pointer to user data associated with the allocation callbacks.</param>
    /// <returns>A pointer to the reallocated memory block, or NULL if reallocation failed.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr ma_allocation_callbacks_realloc_proc(IntPtr p, size_t sz, IntPtr pUserData);

    /// <summary>
    /// Custom memory free callback. Invoked by miniaudio when an allocated memory block
    /// should be released. This is the third member of the ma_allocation_callbacks structure.
    /// </summary>
    /// <param name="p">A pointer to the memory block to free.</param>
    /// <param name="pUserData">A pointer to user data associated with the allocation callbacks.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_allocation_callbacks_free_proc(IntPtr p, IntPtr pUserData);

    /// <summary>
    /// Callback for initializing a backend-specific context. This is part of the
    /// ma_backend_callbacks structure and is invoked when a miniaudio context is
    /// initialized with a specific backend.
    /// </summary>
    /// <param name="pContext">A pointer to the context to initialize.</param>
    /// <param name="pConfig">The context configuration specifying initialization parameters.</param>
    /// <param name="pCallbacks">A pointer to the backend callbacks structure to be populated.</param>
    /// <returns>MA_SUCCESS if the context was initialized successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_init_proc(ma_context_ptr pContext, ref ma_context_config pConfig, ref ma_backend_callbacks pCallbacks);

    /// <summary>
    /// Callback for uninitializing a backend-specific context. This is part of the
    /// ma_backend_callbacks structure and is invoked when a miniaudio context is
    /// being shut down.
    /// </summary>
    /// <param name="pContext">A pointer to the context to uninitialize.</param>
    /// <returns>MA_SUCCESS if the context was uninitialized successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_uninit_proc(ma_context_ptr pContext);

    /// <summary>
    /// Callback for enumerating available audio devices for a backend-specific context.
    /// This is part of the ma_backend_callbacks structure and is invoked when
    /// ma_context_enumerate_devices() is called.
    /// </summary>
    /// <param name="pContext">A pointer to the context performing the enumeration.</param>
    /// <param name="callback">The callback to invoke for each enumerated device.</param>
    /// <param name="pUserData">A pointer to user data to pass to the enumeration callback.</param>
    /// <returns>MA_SUCCESS if the enumeration completed successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_enumerate_devices_proc(ma_context_ptr pContext, ma_enum_devices_callback_proc callback, IntPtr pUserData);

    /// <summary>
    /// Callback for retrieving detailed information about a specific audio device from
    /// a backend-specific context. This is part of the ma_backend_callbacks structure.
    /// </summary>
    /// <param name="pContext">A pointer to the context.</param>
    /// <param name="deviceType">The type of device to get information for (playback or capture).</param>
    /// <param name="pDeviceID">A pointer to the device ID identifying the specific device.</param>
    /// <param name="pDeviceInfo">A pointer that receives the device information.</param>
    /// <returns>MA_SUCCESS if the device information was retrieved successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_context_get_device_info_proc(ma_context_ptr pContext, ma_device_type deviceType, ma_device_id_ptr pDeviceID, ma_device_info_ptr pDeviceInfo);

    /// <summary>
    /// Callback for initializing a backend-specific device. This is part of the
    /// ma_backend_callbacks structure and is invoked when a device is initialized
    /// with a specific backend.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to initialize.</param>
    /// <param name="pConfig">The device configuration specifying initialization parameters.</param>
    /// <param name="pDescriptorPlayback">A pointer to the playback device descriptor, or NULL if not applicable.</param>
    /// <param name="pDescriptorCapture">A pointer to the capture device descriptor, or NULL if not applicable.</param>
    /// <returns>MA_SUCCESS if the device was initialized successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_init_proc(ma_device_ptr pDevice, ref ma_device_config pConfig, ma_device_descriptor_ptr pDescriptorPlayback, ma_device_descriptor_ptr pDescriptorCapture);

    /// <summary>
    /// Callback for uninitializing a backend-specific device. This is part of the
    /// ma_backend_callbacks structure and is invoked when a device is being shut down.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to uninitialize.</param>
    /// <returns>MA_SUCCESS if the device was uninitialized successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_uninit_proc(ma_device_ptr pDevice);

    /// <summary>
    /// Callback for starting a backend-specific device. This is part of the
    /// ma_backend_callbacks structure and is invoked when the audio device
    /// should begin processing.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to start.</param>
    /// <returns>MA_SUCCESS if the device was started successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_start_proc(ma_device_ptr pDevice);

    /// <summary>
    /// Callback for stopping a backend-specific device. This is part of the
    /// ma_backend_callbacks structure and is invoked when the audio device
    /// should stop processing.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to stop.</param>
    /// <returns>MA_SUCCESS if the device was stopped successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_stop_proc(ma_device_ptr pDevice);

    /// <summary>
    /// Callback for reading audio frames from a backend-specific device. This is part
    /// of the ma_backend_callbacks structure and is used for capture or full-duplex
    /// devices.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to read from.</param>
    /// <param name="pFrames">A pointer to the buffer that will receive the captured PCM frames.</param>
    /// <param name="frameCount">The number of PCM frames to read.</param>
    /// <param name="pFramesRead">A pointer that receives the number of frames actually read.</param>
    /// <returns>MA_SUCCESS if the read operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_read_proc(ma_device_ptr pDevice, IntPtr pFrames, ma_uint32 frameCount, IntPtr pFramesRead);

    /// <summary>
    /// Callback for writing audio frames to a backend-specific device. This is part
    /// of the ma_backend_callbacks structure and is used for playback or full-duplex
    /// devices.
    /// </summary>
    /// <param name="pDevice">A pointer to the device to write to.</param>
    /// <param name="pFrames">A pointer to the buffer containing PCM frames to write.</param>
    /// <param name="frameCount">The number of PCM frames to write.</param>
    /// <param name="pFramesWritten">A pointer that receives the number of frames actually written.</param>
    /// <returns>MA_SUCCESS if the write operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_write_proc(ma_device_ptr pDevice, IntPtr pFrames, ma_uint32 frameCount, IntPtr pFramesWritten);

    /// <summary>
    /// Callback for the backend-specific audio data loop. This is part of the
    /// ma_backend_callbacks structure and implements the main audio processing loop
    /// for the backend. It is responsible for feeding audio data to and from the
    /// device on a separate audio thread.
    /// </summary>
    /// <param name="pDevice">A pointer to the device whose data loop should run.</param>
    /// <returns>MA_SUCCESS if the data loop completed normally, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_dataloop_proc(ma_device_ptr pDevice);

    /// <summary>
    /// Callback for waking up the backend-specific audio data loop. This is part of
    /// the ma_backend_callbacks structure and is used to signal the data loop thread
    /// that it should wake up, typically when the device is being started or when
    /// a state change has occurred.
    /// </summary>
    /// <param name="pDevice">A pointer to the device whose data loop should be woken up.</param>
    /// <returns>MA_SUCCESS if the wakeup signal was sent successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_dataloop_wakeup_proc(ma_device_ptr pDevice);

    /// <summary>
    /// Callback for retrieving device information from an initialized backend-specific
    /// device. This is part of the ma_backend_callbacks structure and is optional.
    /// If implemented by the backend, it allows for more efficient device information
    /// retrieval compared to the context-level equivalent.
    /// </summary>
    /// <param name="pDevice">A pointer to the initialized device.</param>
    /// <param name="type">The type of device information to retrieve (playback or capture).</param>
    /// <param name="pDeviceInfo">A pointer that receives the device information.</param>
    /// <returns>MA_SUCCESS if the device information was retrieved successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_backend_device_get_info_proc(ma_device_ptr pDevice, ma_device_type type, ma_device_info_ptr pDeviceInfo);

    /// <summary>
    /// Callback for reading PCM frames from a data source. This is a member of the
    /// ma_data_source_vtable structure and is invoked when audio data needs to be
    /// retrieved from the data source.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to read from.</param>
    /// <param name="pFramesOut">A pointer to the buffer that will receive the output PCM frames.</param>
    /// <param name="frameCount">The number of PCM frames to read.</param>
    /// <param name="pFramesRead">Output parameter that receives the number of frames actually read.</param>
    /// <returns>MA_SUCCESS if the read operation succeeded, or an appropriate error code otherwise.
    /// Return MA_AT_END if the end of the data source has been reached.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_read_proc(ma_data_source_ptr pDataSource, IntPtr pFramesOut, ma_uint64 frameCount, out UInt64 pFramesRead);

    /// <summary>
    /// Callback for seeking to a specific PCM frame index within a data source. This is
    /// a member of the ma_data_source_vtable structure and is invoked when the data
    /// source's read position needs to be changed.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to seek within.</param>
    /// <param name="frameIndex">The PCM frame index to seek to.</param>
    /// <returns>MA_SUCCESS if the seek operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_seek_proc(ma_data_source_ptr pDataSource, ma_uint64 frameIndex);

    /// <summary>
    /// Callback for retrieving the data format of a data source. This is a member of
    /// the ma_data_source_vtable structure and provides the format, channel count,
    /// sample rate, and channel map of the data source.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to query.</param>
    /// <param name="pFormat">Output parameter that receives the sample format of the data source.</param>
    /// <param name="pChannels">Output parameter that receives the number of channels.</param>
    /// <param name="pSampleRate">Output parameter that receives the sample rate in Hz.</param>
    /// <param name="pChannelMap">A pointer to a buffer that receives the channel map.</param>
    /// <param name="channelMapCap">The capacity of the channel map buffer.</param>
    /// <returns>MA_SUCCESS if the format was retrieved successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_data_format_proc(ma_data_source_ptr pDataSource, out ma_format pFormat, out ma_uint32 pChannels, out ma_uint32 pSampleRate, ma_channel_ptr pChannelMap, size_t channelMapCap);

    /// <summary>
    /// Callback for retrieving the current cursor position of a data source in PCM
    /// frames. This is a member of the ma_data_source_vtable structure.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to query.</param>
    /// <param name="pCursor">Output parameter that receives the current read cursor position in PCM frames.</param>
    /// <returns>MA_SUCCESS if the cursor position was retrieved successfully. Return
    /// MA_NOT_IMPLEMENTED if there is no notion of a cursor, in which case pCursor should be set to 0.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_cursor_proc(ma_data_source_ptr pDataSource, out UInt64 pCursor);

    /// <summary>
    /// Callback for retrieving the total length of a data source in PCM frames.
    /// This is a member of the ma_data_source_vtable structure.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to query.</param>
    /// <param name="pLength">A pointer that receives the total length in PCM frames. Return
    /// MA_NOT_IMPLEMENTED and set the value to 0 if there is no notion of a length or if the length is unknown.</param>
    /// <returns>MA_SUCCESS if the length was retrieved successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_get_length_proc(ma_data_source_ptr pDataSource, IntPtr pLength);

    /// <summary>
    /// Callback for enabling or disabling looping on a data source. This is a member
    /// of the ma_data_source_vtable structure and controls whether the data source
    /// should loop when it reaches the end of its data.
    /// </summary>
    /// <param name="pDataSource">A pointer to the data source to configure.</param>
    /// <param name="isLooping">Non-zero (MA_TRUE) to enable looping, zero (MA_FALSE) to disable looping.</param>
    /// <returns>MA_SUCCESS if the looping state was set successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_data_source_vtable_set_looping_proc(ma_data_source_ptr pDataSource, ma_bool32 isLooping);

    /// <summary>
    /// Callback for processing audio through an effect node in the audio node graph.
    /// This is invoked when an effect node needs to process audio data, applying
    /// its effect transformation to the input and producing output. This is equivalent
    /// to the onProcess callback in the ma_node_vtable structure, specifically for
    /// effect-type nodes.
    /// </summary>
    /// <param name="pNode">A pointer to the effect node being processed.</param>
    /// <param name="ppFramesIn">A pointer to an array of input buffer pointers, one per input bus.</param>
    /// <param name="pFrameCountIn">A pointer to an array of input frame counts per bus.</param>
    /// <param name="ppFramesOut">A pointer to an array of output buffer pointers, one per output bus.</param>
    /// <param name="pFrameCountOut">A pointer to an array of output frame counts per bus.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_effect_node_process_proc(ma_node_ptr pNode, IntPtr ppFramesIn, IntPtr pFrameCountIn, IntPtr ppFramesOut, IntPtr pFrameCountOut);

    /// <summary>
    /// Callback for writing raw bytes to an encoder. Encoders do not perform any format
    /// conversion. If the target format does not support the input format, an error
    /// will be returned.
    /// </summary>
    /// <param name="pEncoder">A pointer to the encoder to write to.</param>
    /// <param name="pBufferIn">A pointer to the buffer containing raw bytes to encode.</param>
    /// <param name="bytesToWrite">The number of bytes to write.</param>
    /// <param name="pBytesWritten">Output parameter that receives the number of bytes actually written.</param>
    /// <returns>MA_SUCCESS if the write operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_write_proc(ma_encoder_ptr pEncoder, IntPtr pBufferIn, size_t bytesToWrite, out size_t pBytesWritten);

    /// <summary>
    /// Callback for seeking to a specific byte offset within an encoder. This allows
    /// repositioning the write cursor to a specific location within the encoded data.
    /// </summary>
    /// <param name="pEncoder">A pointer to the encoder to seek within.</param>
    /// <param name="offset">The byte offset to seek to, interpreted relative to the origin parameter.</param>
    /// <param name="origin">The seek origin specifying how to interpret the offset.</param>
    /// <returns>MA_SUCCESS if the seek operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_seek_proc(ma_encoder_ptr pEncoder, ma_int64 offset, ma_seek_origin origin);

    /// <summary>
    /// Callback for initializing an encoder. This is invoked when the encoder needs
    /// to set up its internal state and prepare for encoding operations.
    /// </summary>
    /// <param name="pEncoder">A pointer to the encoder to initialize.</param>
    /// <returns>MA_SUCCESS if the encoder was initialized successfully, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_init_proc(ma_encoder_ptr pEncoder);

    /// <summary>
    /// Callback for uninitializing an encoder. This is invoked when the encoder is
    /// being shut down and should release any resources it has acquired.
    /// </summary>
    /// <param name="pEncoder">A pointer to the encoder to uninitialize.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ma_encoder_uninit_proc(ma_encoder_ptr pEncoder);

    /// <summary>
    /// Callback for writing PCM frames to an encoder. This is invoked when the encoder
    /// needs to encode audio data, taking raw PCM frames as input and producing encoded
    /// output.
    /// </summary>
    /// <param name="pEncoder">A pointer to the encoder to write to.</param>
    /// <param name="pFramesIn">A pointer to the buffer containing PCM frames to encode.</param>
    /// <param name="frameCount">The number of PCM frames to encode.</param>
    /// <param name="pFramesWritten">Output parameter that receives the number of frames actually written.</param>
    /// <returns>MA_SUCCESS if the write operation succeeded, or an appropriate error code otherwise.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ma_result ma_encoder_write_pcm_frames_proc(ma_encoder_ptr pEncoder, IntPtr pFramesIn, ma_uint64 frameCount, out ma_uint64 pFramesWritten);
}
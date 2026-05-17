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

namespace MiniAudioEx.Native
{
    // ma_enums
    /// <summary>
    /// Result codes returned by miniaudio operations. A value of <c>success</c> (0) indicates
    /// the operation completed successfully. Negative values represent specific error categories.
    /// </summary>
    public enum ma_result
    {
        /// <summary>Operation completed successfully.</summary>
        success = 0,
        /// <summary>A generic error occurred during the operation.</summary>
        error = -1,  /* A generic error. */
        /// <summary>One or more arguments passed to the function were invalid.</summary>
        invalid_args = -2,
        /// <summary>The operation is not valid in the current context.</summary>
        invalid_operation = -3,
        /// <summary>A memory allocation failed.</summary>
        out_of_memory = -4,
        /// <summary>A value was out of the valid range.</summary>
        out_of_range = -5,
        /// <summary>Access to the requested resource was denied.</summary>
        access_denied = -6,
        /// <summary>The requested item does not exist.</summary>
        does_not_exist = -7,
        /// <summary>The item already exists and cannot be created again.</summary>
        already_exists = -8,
        /// <summary>Too many files are currently open.</summary>
        too_many_open_files = -9,
        /// <summary>The file is invalid or corrupted.</summary>
        invalid_file = -10,
        /// <summary>The data is too large for the operation.</summary>
        too_big = -11,
        /// <summary>The file path exceeds the maximum allowed length.</summary>
        path_too_long = -12,
        /// <summary>The name exceeds the maximum allowed length.</summary>
        name_too_long = -13,
        /// <summary>The path does not point to a directory.</summary>
        not_directory = -14,
        /// <summary>The path points to a directory rather than a file.</summary>
        is_directory = -15,
        /// <summary>The directory is not empty and cannot be removed.</summary>
        directory_not_empty = -16,
        /// <summary>Reached the end of the data. For decoders and data sources, this means no
        /// more data is available and the stream has ended.</summary>
        at_end = -17,
        /// <summary>No space left on the device.</summary>
        no_space = -18,
        /// <summary>The resource is busy and cannot be used at this time.</summary>
        busy = -19,
        /// <summary>An I/O error occurred during reading or writing.</summary>
        io_error = -20,
        /// <summary>The operation was interrupted.</summary>
        interrupt = -21,
        /// <summary>The requested resource is unavailable.</summary>
        unavailable = -22,
        /// <summary>The resource is already in use by another operation.</summary>
        already_in_use = -23,
        /// <summary>A bad memory address was encountered.</summary>
        bad_address = -24,
        /// <summary>A seek operation failed due to an invalid position.</summary>
        bad_seek = -25,
        /// <summary>A pipe operation failed.</summary>
        bad_pipe = -26,
        /// <summary>A deadlock was detected.</summary>
        deadlock = -27,
        /// <summary>Too many symbolic links were encountered.</summary>
        too_many_links = -28,
        /// <summary>The requested feature or operation is not implemented.</summary>
        not_implemented = -29,
        /// <summary>No message was available when one was expected.</summary>
        no_message = -30,
        /// <summary>A received message was malformed.</summary>
        bad_message = -31,
        /// <summary>No data is available for reading.</summary>
        no_data_available = -32,
        /// <summary>The data is invalid or corrupted.</summary>
        invalid_data = -33,
        /// <summary>The operation timed out.</summary>
        timeout = -34,
        /// <summary>No network connection is available.</summary>
        no_network = -35,
        /// <summary>The item is not unique when uniqueness was required.</summary>
        not_unique = -36,
        /// <summary>The resource is not a socket.</summary>
        not_socket = -37,
        /// <summary>No address was provided or available.</summary>
        no_address = -38,
        /// <summary>A bad protocol was specified.</summary>
        bad_protocol = -39,
        /// <summary>The requested protocol is unavailable.</summary>
        protocol_unavailable = -40,
        /// <summary>The protocol is not supported.</summary>
        protocol_not_supported = -41,
        /// <summary>The protocol family is not supported.</summary>
        protocol_family_not_supported = -42,
        /// <summary>The address family is not supported.</summary>
        address_family_not_supported = -43,
        /// <summary>Sockets are not supported on this platform.</summary>
        socket_not_supported = -44,
        /// <summary>The connection was reset by the peer.</summary>
        connection_reset = -45,
        /// <summary>The socket or connection is already connected.</summary>
        already_connected = -46,
        /// <summary>The socket or connection is not connected.</summary>
        not_connected = -47,
        /// <summary>The connection was refused by the remote host.</summary>
        connection_refused = -48,
        /// <summary>No host was found for the given address.</summary>
        no_host = -49,
        /// <summary>The operation is still in progress.</summary>
        in_progress = -50,
        /// <summary>The operation was cancelled.</summary>
        cancelled = -51,
        /// <summary>The requested memory region is already mapped.</summary>
        memory_already_mapped = -52,

        /* General non-standard errors. */
        /// <summary>A CRC checksum mismatch was detected, indicating data corruption.</summary>
        crc_mismatch = -100,

        /* General miniaudio-specific errors. */
        /// <summary>The requested sample format is not supported by the device or backend.</summary>
        format_not_supported = -200,
        /// <summary>The device type (playback, capture, duplex, loopback) is not supported
        /// by the backend.</summary>
        device_type_not_supported = -201,
        /// <summary>The share mode (shared or exclusive) is not supported by the backend.</summary>
        share_mode_not_supported = -202,
        /// <summary>No backend is available for audio I/O on this platform.</summary>
        no_backend = -203,
        /// <summary>No device matching the requested criteria was found.</summary>
        no_device = -204,
        /// <summary>The requested backend API was not found on the system.</summary>
        api_not_found = -205,
        /// <summary>The device configuration is invalid.</summary>
        invalid_device_config = -206,
        /// <summary>A loop was detected in a node graph or data pipeline.</summary>
        loop = -207,
        /// <summary>The requested backend is not enabled in the build configuration.</summary>
        backend_not_enabled = -208,

        /* State errors. */
        /// <summary>The device has not been initialized. Call a device init function first.</summary>
        device_not_initialized = -300,
        /// <summary>The device has already been initialized and cannot be initialized again.</summary>
        device_already_initialized = -301,
        /// <summary>The device has not been started. Call ma_device_start() first.</summary>
        device_not_started = -302,
        /// <summary>The device has not been stopped. The operation requires the device to be
        /// in a stopped state.</summary>
        device_not_stopped = -303,

        /* Operation errors. */
        /// <summary>Initialization of the audio backend failed.</summary>
        failed_to_init_backend = -400,
        /// <summary>Failed to open the backend-specific audio device.</summary>
        failed_to_open_backend_device = -401,
        /// <summary>Failed to start the backend-specific audio device.</summary>
        failed_to_start_backend_device = -402,
        /// <summary>Failed to stop the backend-specific audio device.</summary>
        failed_to_stop_backend_device = -403
    }

    /// <summary>
    /// Standard channel position maps for different audio formats and conventions.
    /// Used by <c>ma_channel_map_init_standard()</c> to initialize channel maps according
    /// to well-known standards.
    /// </summary>
    public enum ma_standard_channel_map
    {
        /// <summary>Microsoft channel ordering (e.g. FL, FR, FC, LFE, BL, BR). This is
        /// the default.</summary>
        microsoft,
        /// <summary>ALSA channel ordering used on Linux systems.</summary>
        alsa,
        /// <summary>RFC 3551 channel ordering based on AIFF. For assigning channels to speaker positions according to RFC 3551.</summary>
        rfc3551,   /* Based off AIFF. */
        /// <summary>FLAC channel ordering.</summary>
        flac,
        /// <summary>Vorbis channel ordering.</summary>
        vorbis,
        /// <summary>FreeBSD's sound(4) driver channel ordering.</summary>
        sound4,    /* FreeBSD's sound(4). */
        /// <summary>sndio channel ordering (www.sndio.org/tips.html).</summary>
        sndio,     /* www.sndio.org/tips.html */
        /// <summary>Web Audio API channel ordering. Only 1, 2, 4 and 6 channels are defined; gaps fill in with logical assumptions.</summary>
        webaudio = flac, /* https://webaudio.github.io/web-audio-api/#ChannelOrdering. Only 1, 2, 4 and 6 channels are defined, but can fill in the gaps with logical assumptions. */
        /// <summary>The default standard channel map. Equivalent to <c>microsoft</c>.</summary>
        standard = microsoft
    }

    /// <summary>
    /// Types of notifications that can be sent from a device to the application
    /// via the notification callback. These cover lifecycle events such as starting,
    /// stopping, rerouting, and interruptions.
    /// </summary>
    public enum ma_device_notification_type
    {
        /// <summary>The device has just started and is now processing audio data.</summary>
        started,
        /// <summary>The device has been stopped, either explicitly or due to an error
        /// or disconnection.</summary>
        stopped,
        /// <summary>The device has been rerouted to a different physical audio endpoint
        /// (e.g. headphones unplugged, switching to speakers). Not all backends support
        /// this notification.</summary>
        rerouted,
        /// <summary>An audio interruption has begun (e.g. incoming phone call on mobile).
        /// Currently implemented on iOS.</summary>
        interruption_began,
        /// <summary>An audio interruption has ended and normal operation can resume.
        /// Currently implemented on iOS.</summary>
        interruption_ended,
        /// <summary>On Web Audio, fired after a user gesture has unlocked the ability
        /// to play audio.</summary>
        unlocked
    }

    /// <summary>
    /// Specifies how the resource manager supplies data to a data source node.
    /// Determines the type of connector used between the resource manager and the node.
    /// </summary>
    public enum ma_resource_manager_data_supply_type
    {
        /// <summary>The data supply type has not been initialized. Used for determining initialization state.</summary>
        unknown = 0,   /* Used for determining whether or the data supply has been initialized. */
        /// <summary>Data is supplied as an encoded buffer using a ma_decoder connector for on-the-fly decoding.</summary>
        encoded,       /* Data supply is an encoded buffer. Connector is ma_decoder. */
        /// <summary>Data is supplied as a pre-decoded buffer using a ma_audio_buffer connector.</summary>
        decoded,       /* Data supply is a decoded buffer. Connector is ma_audio_buffer. */
        /// <summary>Data is supplied as a linked list of decoded pages using a ma_paged_audio_buffer connector.</summary>
        decoded_paged  /* Data supply is a linked list of decoded buffers. Connector is ma_paged_audio_buffer. */
    }

    /// <summary>
    /// Seek origin points for operations that move the read/write cursor
    /// within a data stream, file, or audio buffer.
    /// </summary>
    public enum ma_seek_origin
    {
        /// <summary>Seek relative to the beginning of the data.</summary>
        start,
        /// <summary>Seek relative to the current cursor position.</summary>
        current,
        /// <summary>Seek relative to the end of the data. Not applicable to decoders.</summary>
        end  /* Not used by decoders. */
    }

    /// <summary>
    /// Performance profiles that influence the default buffer size and latency settings
    /// when initializing a device. Used when no explicit buffer size is provided.
    /// </summary>
    public enum ma_performance_profile
    {
        /// <summary>Low latency. Results in a smaller default buffer size for reduced
        /// audio delay, but higher CPU usage. This is the default.</summary>
        low_latency = 0,
        /// <summary>Conservative. Results in a larger default buffer size for higher
        /// reliability and lower CPU usage, but increased audio delay.</summary>
        conservative
    }

    /// <summary>
    /// Channel mixing modes used when converting between different channel counts.
    /// Determines how channels are combined or dropped during conversion.
    /// </summary>
    public enum ma_channel_mix_mode
    {
        /// <summary>Simple rectangular averaging based on the spatial plane(s) each channel sits on. The default mixing mode.</summary>
        rectangular = 0,   /* Simple averaging based on the plane(s) the channel is sitting on. */
        /// <summary>Simple mode dropping excess channels and zeroing out extra channels.</summary>
        simple,            /* Drop excess channels; zeroed out extra channels. */
        /// <summary>Use custom weights specified in the ma_channel_converter_config for precise control over channel mixing.</summary>
        custom_weights,    /* Use custom weights specified in ma_channel_converter_config. */
        /// <summary>The default channel mixing mode. Equivalent to <c>rectangular</c>.</summary>
        standard = rectangular // Actually called 'ma_channel_mix_mode_default' but 'default' is a reserved keyword in C#
    }

    /// <summary>
    /// Usage types for the WASAPI (Windows Audio Session API) backend. Controls how
    /// Windows categorizes the audio stream, which affects the audio thread priority
    /// and system mixing behavior.
    /// </summary>
    public enum ma_wasapi_usage
    {
        /// <summary>The default WASAPI usage. Equivalent to the shared-mode default for media or games.</summary>
        standard = 0, // Actually called 'ma_wasapi_usage_default' but 'default' is a reserved keyword in C#
        /// <summary>Game audio. Uses the AUDCLNT_STREAMFLAGS_RATEADJUST flag for
        /// games category processing.</summary>
        games,
        /// <summary>Professional audio. Uses AUDCLNT_STREAMFLAGS_RATEADJUST for
        /// pro audio category processing.</summary>
        pro_audio,
    }

    /// <summary>
    /// Stream types for the OpenSL ES backend on Android. Corresponds to Android's
    /// SL_ANDROID_STREAM_* constants and controls how the system treats the audio
    /// stream (e.g. volume control, routing).
    /// </summary>
    public enum ma_opensl_stream_type
    {
        /// <summary>Leaves the stream type unset, using the system default. Equivalent to the default SL_ANDROID_STREAM.</summary>
        standard = 0,              /* Leaves the stream type unset. */
        /// <summary>SL_ANDROID_STREAM_VOICE. For voice call audio.</summary>
        voice,                    /* SL_ANDROID_STREAM_VOICE */
        /// <summary>SL_ANDROID_STREAM_SYSTEM. For system sounds.</summary>
        system,                   /* SL_ANDROID_STREAM_SYSTEM */
        /// <summary>SL_ANDROID_STREAM_RING. For ringtone audio.</summary>
        ring,                     /* SL_ANDROID_STREAM_RING */
        /// <summary>SL_ANDROID_STREAM_MEDIA. For music and media playback.</summary>
        media,                    /* SL_ANDROID_STREAM_MEDIA */
        /// <summary>SL_ANDROID_STREAM_ALARM. For alarm audio.</summary>
        alarm,                    /* SL_ANDROID_STREAM_ALARM */
        /// <summary>SL_ANDROID_STREAM_NOTIFICATION. For notification sounds.</summary>
        notification              /* SL_ANDROID_STREAM_NOTIFICATION */
    }

    /// <summary>
    /// Recording presets for the OpenSL ES backend on Android. Corresponds to
    /// Android's SL_ANDROID_RECORDING_PRESET_* constants and controls audio
    /// processing applied to the microphone input.
    /// </summary>
    public enum ma_opensl_recording_preset
    {
        /// <summary>Leaves the input preset unset, using the system default.</summary>
        standard = 0,         /* Leaves the input preset unset. */
        /// <summary>SL_ANDROID_RECORDING_PRESET_GENERIC. No special processing.</summary>
        generic,             /* SL_ANDROID_RECORDING_PRESET_GENERIC */
        /// <summary>SL_ANDROID_RECORDING_PRESET_CAMCORDER. Optimized for video recording.</summary>
        camcorder,           /* SL_ANDROID_RECORDING_PRESET_CAMCORDER */
        /// <summary>SL_ANDROID_RECORDING_PRESET_VOICE_RECOGNITION. Optimized for
        /// speech recognition.</summary>
        voice_recognition,   /* SL_ANDROID_RECORDING_PRESET_VOICE_RECOGNITION */
        /// <summary>SL_ANDROID_RECORDING_PRESET_VOICE_COMMUNICATION. Optimized for
        /// voice communication (e.g. VoIP).</summary>
        voice_communication, /* SL_ANDROID_RECORDING_PRESET_VOICE_COMMUNICATION */
        /// <summary>SL_ANDROID_RECORDING_PRESET_UNPROCESSED. Raw, unprocessed
        /// microphone input.</summary>
        voice_unprocessed    /* SL_ANDROID_RECORDING_PRESET_UNPROCESSED */
    }

    /// <summary>
    /// Usage types for the AAudio backend on Android. Corresponds to Android's
    /// AAUDIO_USAGE_* constants and controls how the system treats the audio stream.
    /// </summary>
    public enum ma_aaudio_usage
    {
        /// <summary>Leaves the usage type unset, using the system default.</summary>
        standard = 0,                    /* Leaves the usage type unset. */
        /// <summary>AAUDIO_USAGE_MEDIA. For music and media playback.</summary>
        media,                          /* AAUDIO_USAGE_MEDIA */
        /// <summary>AAUDIO_USAGE_VOICE_COMMUNICATION. For voice calls and VoIP.</summary>
        voice_communication,            /* AAUDIO_USAGE_VOICE_COMMUNICATION */
        /// <summary>AAUDIO_USAGE_VOICE_COMMUNICATION_SIGNALLING. For signalling
        /// associated with voice communication.</summary>
        voice_communication_signalling, /* AAUDIO_USAGE_VOICE_COMMUNICATION_SIGNALLING */
        /// <summary>AAUDIO_USAGE_ALARM. For alarm sounds.</summary>
        alarm,                          /* AAUDIO_USAGE_ALARM */
        /// <summary>AAUDIO_USAGE_NOTIFICATION. For notification sounds.</summary>
        notification,                   /* AAUDIO_USAGE_NOTIFICATION */
        /// <summary>AAUDIO_USAGE_NOTIFICATION_RINGTONE. For ringtone notifications.</summary>
        notification_ringtone,          /* AAUDIO_USAGE_NOTIFICATION_RINGTONE */
        /// <summary>AAUDIO_USAGE_NOTIFICATION_EVENT. For event notifications.</summary>
        notification_event,             /* AAUDIO_USAGE_NOTIFICATION_EVENT */
        /// <summary>AAUDIO_USAGE_ASSISTANCE_ACCESSIBILITY. For accessibility
        /// assistance.</summary>
        assistance_accessibility,       /* AAUDIO_USAGE_ASSISTANCE_ACCESSIBILITY */
        /// <summary>AAUDIO_USAGE_ASSISTANCE_NAVIGATION_GUIDANCE. For navigation
        /// guidance.</summary>
        assistance_navigation_guidance, /* AAUDIO_USAGE_ASSISTANCE_NAVIGATION_GUIDANCE */
        /// <summary>AAUDIO_USAGE_ASSISTANCE_SONIFICATION. For sonification of
        /// assistive data.</summary>
        assistance_sonification,        /* AAUDIO_USAGE_ASSISTANCE_SONIFICATION */
        /// <summary>AAUDIO_USAGE_GAME. For game audio.</summary>
        game,                           /* AAUDIO_USAGE_GAME */
        /// <summary>AAUDIO_USAGE_ASSISTANT. For virtual assistant audio.</summary>
        assitant,                       /* AAUDIO_USAGE_ASSISTANT */
        /// <summary>AAUDIO_SYSTEM_USAGE_EMERGENCY. For emergency audio.</summary>
        emergency,                      /* AAUDIO_SYSTEM_USAGE_EMERGENCY */
        /// <summary>AAUDIO_SYSTEM_USAGE_SAFETY. For safety-related audio.</summary>
        safety,                         /* AAUDIO_SYSTEM_USAGE_SAFETY */
        /// <summary>AAUDIO_SYSTEM_USAGE_VEHICLE_STATUS. For vehicle status audio.</summary>
        vehicle_status,                 /* AAUDIO_SYSTEM_USAGE_VEHICLE_STATUS */
        /// <summary>AAUDIO_SYSTEM_USAGE_ANNOUNCEMENT. For announcement audio.</summary>
        announcement                    /* AAUDIO_SYSTEM_USAGE_ANNOUNCEMENT */
    }

    /// <summary>
    /// Content types for the AAudio backend on Android. Corresponds to Android's
    /// AAUDIO_CONTENT_TYPE_* constants and describes the type of audio content
    /// being played.
    /// </summary>
    public enum ma_aaudio_content_type
    {
        /// <summary>Leaves the content type unset, using the system default.</summary>
        standard = 0,             /* Leaves the content type unset. */
        /// <summary>AAUDIO_CONTENT_TYPE_SPEECH. For spoken word content.</summary>
        speech,                  /* AAUDIO_CONTENT_TYPE_SPEECH */
        /// <summary>AAUDIO_CONTENT_TYPE_MUSIC. For music content.</summary>
        music,                   /* AAUDIO_CONTENT_TYPE_MUSIC */
        /// <summary>AAUDIO_CONTENT_TYPE_MOVIE. For movie and video content.</summary>
        movie,                   /* AAUDIO_CONTENT_TYPE_MOVIE */
        /// <summary>AAUDIO_CONTENT_TYPE_SONIFICATION. For sonification content
        /// (audio representations of data).</summary>
        sonification             /* AAUDIO_CONTENT_TYPE_SONIFICATION */
    }

    /// <summary>
    /// Input presets for the AAudio backend on Android. Corresponds to Android's
    /// AAUDIO_INPUT_PRESET_* constants and controls audio processing applied to
    /// the microphone input.
    /// </summary>
    public enum ma_aaudio_input_preset
    {
        /// <summary>Leaves the input preset unset, using the system default.</summary>
        standard = 0,             /* Leaves the input preset unset. */
        /// <summary>AAUDIO_INPUT_PRESET_GENERIC. No special processing.</summary>
        generic,                 /* AAUDIO_INPUT_PRESET_GENERIC */
        /// <summary>AAUDIO_INPUT_PRESET_CAMCORDER. Optimized for video recording.</summary>
        camcorder,               /* AAUDIO_INPUT_PRESET_CAMCORDER */
        /// <summary>AAUDIO_INPUT_PRESET_VOICE_RECOGNITION. Optimized for speech
        /// recognition.</summary>
        voice_recognition,       /* AAUDIO_INPUT_PRESET_VOICE_RECOGNITION */
        /// <summary>AAUDIO_INPUT_PRESET_VOICE_COMMUNICATION. Optimized for voice
        /// communication (e.g. VoIP).</summary>
        voice_communication,     /* AAUDIO_INPUT_PRESET_VOICE_COMMUNICATION */
        /// <summary>AAUDIO_INPUT_PRESET_UNPROCESSED. Raw, unprocessed microphone input.</summary>
        unprocessed,             /* AAUDIO_INPUT_PRESET_UNPROCESSED */
        /// <summary>AAUDIO_INPUT_PRESET_VOICE_PERFORMANCE. Optimized for vocal
        /// performance (e.g. karaoke).</summary>
        voice_performance        /* AAUDIO_INPUT_PRESET_VOICE_PERFORMANCE */
    }

    /// <summary>
    /// Capture policies for the AAudio backend on Android. Corresponds to Android's
    /// AAUDIO_ALLOW_CAPTURE_BY_* constants and controls which apps can capture
    /// audio from this stream.
    /// </summary>
    public enum ma_aaudio_allowed_capture_policy
    {
        /// <summary>Leaves the allowed capture policy unset, using the system default.</summary>
        standard = 0,            /* Leaves the allowed capture policy unset. */
        /// <summary>AAUDIO_ALLOW_CAPTURE_BY_ALL. Any app can capture audio
        /// from this stream.</summary>
        by_all,                 /* AAUDIO_ALLOW_CAPTURE_BY_ALL */
        /// <summary>AAUDIO_ALLOW_CAPTURE_BY_SYSTEM. Only system apps can capture
        /// audio from this stream.</summary>
        by_system,              /* AAUDIO_ALLOW_CAPTURE_BY_SYSTEM */
        /// <summary>AAUDIO_ALLOW_CAPTURE_BY_NONE. No apps can capture audio
        /// from this stream.</summary>
        by_none                 /* AAUDIO_ALLOW_CAPTURE_BY_NONE */
    }

    /// <summary>
    /// Resampling algorithms used when the device sample rate differs from the
    /// source sample rate. The linear algorithm is the default and provides
    /// a good balance of quality and performance.
    /// </summary>
    public enum ma_resample_algorithm
    {
        /// <summary>Linear resampling with optional low-pass filtering. Fastest speed, lowest quality. This is the default.</summary>
        linear = 0,    /* Fastest, lowest quality. Optional low-pass filtering. Default. */
        /// <summary>Custom resampling algorithm. A user-provided backend vtable
        /// must be supplied in the resampler config.</summary>
        custom,
    }

    /// <summary>
    /// Share modes for audio devices. Controls whether the device is shared with
    /// other applications or used exclusively.
    /// </summary>
    public enum ma_share_mode
    {
        /// <summary>Shared mode. The audio device is shared with other applications.
        /// The system mixer will handle format conversion and mixing. This is the
        /// default and most compatible mode.</summary>
        shared = 0,
        /// <summary>Exclusive mode. The application has exclusive access to the
        /// audio device. Provides lower latency and bit-perfect output, but prevents
        /// other applications from using the device. Not supported by all backends.</summary>
        exclusive
    }

    /// <summary>
    /// Distance attenuation models for 3D spatialization. Determines how the volume
    /// of a sound decreases as it moves away from the listener.
    /// </summary>
    public enum ma_attenuation_model
    {
        /// <summary>No distance attenuation and no spatialization. The sound plays
        /// at full volume regardless of distance.</summary>
        none,          /* No distance attenuation and no spatialization. */
        /// <summary>Inverse distance attenuation. Volume decreases as 1/distance.
        /// Equivalent to OpenAL's AL_INVERSE_DISTANCE_CLAMPED.</summary>
        inverse,       /* Equivalent to OpenAL's AL_INVERSE_DISTANCE_CLAMPED. */
        /// <summary>Linear attenuation. Volume decreases linearly with distance.
        /// Equivalent to OpenAL's AL_LINEAR_DISTANCE_CLAMPED.</summary>
        linear,        /* Linear attenuation. Equivalent to OpenAL's AL_LINEAR_DISTANCE_CLAMPED. */
        /// <summary>Exponential attenuation. Volume decreases exponentially with
        /// distance. Equivalent to OpenAL's AL_EXPONENT_DISTANCE_CLAMPED.</summary>
        exponential    /* Exponential attenuation. Equivalent to OpenAL's AL_EXPONENT_DISTANCE_CLAMPED. */
    }

    /// <summary>
    /// Audio backends listed in priority order. The first available backend
    /// on a given platform will be used automatically. The null backend is always
    /// last and serves as the terminator for backend enumeration.
    /// </summary>
    /* Backend enums must be in priority order. */
    public enum ma_backend
    {
        /// <summary>Windows Audio Session API (WASAPI). The primary backend on
        /// Windows with support for both shared and exclusive modes.</summary>
        wasapi,
        /// <summary>DirectSound. A legacy Windows backend with broad compatibility
        /// but higher latency than WASAPI.</summary>
        dsound,
        /// <summary>Windows Multimedia (WinMM). A legacy Windows backend with
        /// the broadest compatibility but highest latency.</summary>
        winmm,
        /// <summary>Core Audio. The primary backend on macOS and iOS.</summary>
        coreaudio,
        /// <summary>sndio. Audio backend used on OpenBSD and some other BSD systems.</summary>
        sndio,
        /// <summary>audio(4). Audio backend for NetBSD and OpenBSD systems.</summary>
        audio4,
        /// <summary>OSS (Open Sound System). Audio backend for FreeBSD and
        /// DragonFly BSD.</summary>
        oss,
        /// <summary>PulseAudio. A common Linux audio server providing per-application
        /// volume control and network transparency.</summary>
        pulseaudio,
        /// <summary>ALSA (Advanced Linux Sound Architecture). The low-level audio
        /// API on Linux providing direct hardware access.</summary>
        alsa,
        /// <summary>JACK Audio Connection Kit. A professional-grade low-latency
        /// audio server for Linux and macOS.</summary>
        jack,
        /// <summary>AAudio. The modern low-latency audio API on Android (SDK 27+).</summary>
        aaudio,
        /// <summary>OpenSL ES. The legacy audio API on Android with broader
        /// compatibility.</summary>
        opensl,
        /// <summary>Web Audio API. Used within web browsers via Emscripten.</summary>
        webaudio,
        /// <summary>Custom backend using user-provided callbacks defined in the context config.</summary>
        custom,  /* <-- Custom backend, with callbacks defined by the context config. */
        /// <summary>Null backend. Always the last item with the lowest priority, serving as the terminator for backend enumeration.</summary>
        nill     /* <-- Must always be the last item. Lowest priority, and used as the terminator for backend enumeration. */
    }

    /// <summary>
    /// Sample formats for PCM audio data. Determines the bit depth and data type
    /// of individual samples. Values are explicitly assigned to serve as keys
    /// into lookup tables.
    /// </summary>
    public enum ma_format
    {
        /*
        I like to keep these explicitly defined because they're used as a key into a lookup table. When items are
        added to this, make sure there are no gaps and that they're added to the lookup table in ma_get_bytes_per_sample().
        */
        /// <summary>Unknown or unspecified format. Used as the default output format for decoders and for error indication.</summary>
        unknown = 0,     /* Mainly used for indicating an error, but also used as the default for the output format for decoders. */
        /// <summary>Unsigned 8-bit integer. Range: 0 to 255 with a midpoint of 128.</summary>
        u8 = 1,
        /// <summary>Signed 16-bit integer. The most widely supported format across
        /// all backends. Range: -32768 to 32767.</summary>
        s16 = 2,     /* Seems to be the most widely supported format. */
        /// <summary>Signed 24-bit integer, tightly packed. 3 bytes per sample.</summary>
        s24 = 3,     /* Tightly packed. 3 bytes per sample. */
        /// <summary>Signed 32-bit integer. Range: -2147483648 to 2147483647.</summary>
        s32 = 4,
        /// <summary>32-bit floating point. Range: -1.0 to 1.0. Used internally
        /// by the node graph system.</summary>
        f32 = 5,
        /// <summary>The number of defined format values. Used as an array size in lookup tables.</summary>
        count
    }

    /// <summary>
    /// Pan modes for stereo panning. Controls how the audio signal is distributed
    /// between the left and right channels.
    /// </summary>
    public enum ma_pan_mode
    {
        /// <summary>Simple balance without blending one side into the other. Compatible with other popular audio engines. This is the default.</summary>
        balance = 0,    /* Does not blend one side with the other. Technically just a balance. Compatible with other popular audio engines and therefore the default. */
        /// <summary>A true pan. The sound from one side will "move" to the other side
        /// and blend with it, creating a more natural stereo field than simple balance.</summary>
        pan             /* A true pan. The sound from one side will "move" to the other side and blend with it. */
    }

    /// <summary>
    /// Positioning modes for 3D spatialization. Determines how the position of a
    /// sound source is interpreted relative to the listener.
    /// </summary>
    public enum ma_positioning
    {
        /// <summary>Absolute positioning. The sound's position is specified in
        /// world-space coordinates.</summary>
        absolute,
        /// <summary>Relative positioning. The sound's position is specified relative
        /// to the listener's position.</summary>
        relative
    }

    /// <summary>
    /// Handedness of the coordinate system used for 3D spatialization. Determines
    /// the orientation of the forward direction on the Z axis.
    /// </summary>
    public enum ma_handedness
    {
        /// <summary>Right-handed coordinate system. Forward is -1 on the Z axis.
        /// This is the default.</summary>
        right,
        /// <summary>Left-handed coordinate system. Forward is +1 on the Z axis.</summary>
        left
    }

    /// <summary>
    /// Allocation type identifiers.
    /// Each value corresponds to a specific 'ma' data structure or object type that
    /// miniaudio allocates internally.
    /// </summary>
    public enum ma_allocation_type
    {
        /// <summary>Async notification object.</summary>
        async_notification,
        /// <summary>Biquad filter coefficient set.</summary>
        biquad_coefficient,
        /// <summary>Biquad filter with configurable order.</summary>
        biquad,
        /// <summary>Band-pass filter with configurable order.</summary>
        bpf,
        /// <summary>Second order band-pass filter.</summary>
        bpf2,
        /// <summary>Band-pass filter node.</summary>
        bpf_node,
        /// <summary>Channel data buffer.</summary>
        channel,
        /// <summary>Audio context.</summary>
        context,
        /// <summary>Data source object.</summary>
        data_source,
        /// <summary>Data source node.</summary>
        data_source_node,
        /// <summary>Data source virtual table.</summary>
        data_source_vtable,
        /// <summary>Audio decoder.</summary>
        decoder,
        /// <summary>Decoding backend virtual table.</summary>
        decoding_backend_vtable,
        /// <summary>Delay/echo effect.</summary>
        delay,
        /// <summary>Delay node.</summary>
        delay_node,
        /// <summary>Audio device.</summary>
        device,
        /// <summary>Capture device component.</summary>
        device_capture,
        /// <summary>Device descriptor.</summary>
        device_descriptor,
        /// <summary>Device ID.</summary>
        device_id,
        /// <summary>Device information structure.</summary>
        device_info,
        /// <summary>Device notification.</summary>
        device_notification,
        /// <summary>Playback device component.</summary>
        device_playback,
        /// <summary>Device resampling component.</summary>
        device_resampling,
        /// <summary>Effect node.</summary>
        effect_node,
        /// <summary>Audio encoder.</summary>
        encoder,
        /// <summary>Audio engine.</summary>
        engine,
        /// <summary>Volume fader.</summary>
        fader,
        /// <summary>Synchronization fence.</summary>
        fence,
        /// <summary>Volume gainer (smooth gain transitions).</summary>
        gainer,
        /// <summary>Second order high-shelf filter.</summary>
        hishelf2,
        /// <summary>High-shelf filter node.</summary>
        hishelf_node,
        /// <summary>High-pass filter with configurable order.</summary>
        hpf,
        /// <summary>First order high-pass filter.</summary>
        hpf1,
        /// <summary>Second order high-pass filter.</summary>
        hpf2,
        /// <summary>High-pass filter node.</summary>
        hpf_node,
        /// <summary>Logging system.</summary>
        log,
        /// <summary>Second order low-shelf filter.</summary>
        loshelf2,
        /// <summary>Low-shelf filter node.</summary>
        loshelf_node,
        /// <summary>Low-pass filter with configurable order.</summary>
        lpf,
        /// <summary>First order low-pass filter.</summary>
        lpf1,
        /// <summary>Second order low-pass filter.</summary>
        lpf2,
        /// <summary>Low-pass filter node.</summary>
        lpf_node,
        /// <summary>Node in a node graph.</summary>
        node,
        /// <summary>Base node component.</summary>
        node_base,
        /// <summary>Node graph for audio processing.</summary>
        node_graph,
        /// <summary>Node input bus.</summary>
        node_input_bus,
        /// <summary>Node output bus.</summary>
        node_output_bus,
        /// <summary>Node virtual table.</summary>
        node_vtable,
        /// <summary>Noise generator.</summary>
        noise,
        /// <summary>Second order notch filter.</summary>
        notch2,
        /// <summary>Notch filter node.</summary>
        notch_node,
        /// <summary>Stereo panner.</summary>
        panner,
        /// <summary>Second order peaking EQ filter.</summary>
        peak2,
        /// <summary>Peaking EQ filter node.</summary>
        peak_node,
        /// <summary>Procedural data source.</summary>
        procedural_data_source,
        /// <summary>Pulse wave generator.</summary>
        pulsewave,
        /// <summary>Resampling backend virtual table.</summary>
        resampling_backend_vtable,
        /// <summary>Resource manager.</summary>
        resource_manager,
        /// <summary>Resource manager data source.</summary>
        resource_manager_data_source,
        /// <summary>Sound object in the engine.</summary>
        sound,
        /// <summary>Inlined sound object.</summary>
        sound_inlined,
        /// <summary>Sound group for collective control.</summary>
        sound_group,
        /// <summary>3D spatializer effect.</summary>
        spatializer,
        /// <summary>Spatializer listener.</summary>
        spatializer_listener,
        /// <summary>Splitter node for routing audio.</summary>
        splitter_node,
        /// <summary>Memory stack.</summary>
        stack,
        /// <summary>Virtual file system.</summary>
        vfs,
        /// <summary>Waveform generator.</summary>
        waveform,
    }

    /// <summary>
    /// Device type flags indicating the direction(s) of audio data flow.
    /// Can be combined with bitwise OR for duplex operation.
    /// </summary>
    public enum ma_device_type
    {
        /// <summary>Playback device. Outputs audio to speakers or headphones.</summary>
        playback = 1,
        /// <summary>Capture device. Records audio from a microphone or line-in.</summary>
        capture = 2,
        /// <summary>Duplex device. Supports simultaneous playback and capture.
        /// Equivalent to <c>playback | capture</c>.</summary>
        duplex = playback | capture, /* 3 */
        /// <summary>Loopback device. Captures audio that is being played by the
        /// system (what you hear).</summary>
        loopback = 4
    }

    /// <summary>
    /// Mono expansion modes for converting a mono signal to multi-channel output.
    /// Determines how a single channel of audio is distributed across multiple
    /// output channels.
    /// </summary>
    public enum ma_mono_expansion_mode
    {
        /// <summary>Duplicate the mono signal to all output channels. This is the default.</summary>
        duplicate = 0,   /* The default. */
        /// <summary>Average the mono channel across all channels, reducing volume
        /// to maintain consistent loudness.</summary>
        average,         /* Average the mono channel across all channels. */
        /// <summary>Duplicate the mono signal to the left and right channels only,
        /// leaving other channels silent.</summary>
        stereo_only,     /* Duplicate to the left and right channels only and ignore the others. */
        /// <summary>The default mono expansion mode. Equivalent to <c>duplicate</c>.</summary>
        standard = duplicate
    }

    /// <summary>
    /// Thread priority levels for audio worker threads. Higher values indicate
    /// higher scheduling priority. The default priority is <c>highest</c> (0).
    /// </summary>
    public enum ma_thread_priority
    {
        /// <summary>Idle priority. Lowest possible scheduling priority.</summary>
        idle = -5,
        /// <summary>Lowest priority above idle.</summary>
        lowest = -4,
        /// <summary>Low priority.</summary>
        low = -3,
        /// <summary>Normal priority.</summary>
        normal = -2,
        /// <summary>High priority.</summary>
        high = -1,
        /// <summary>Highest priority. This is the default for audio threads.</summary>
        highest = 0,
        /// <summary>Realtime priority. The highest possible scheduling priority,
        /// only recommended for professional audio applications.</summary>
        realtime = 1,
        /// <summary>The default thread priority. Equivalent to <c>highest</c>.</summary>
        standard = 0
    }

    /// <summary>
    /// iOS/tvOS/watchOS audio session categories for the Core Audio backend.
    /// Corresponds to Apple's AVAudioSessionCategory constants and controls how
    /// audio interacts with other apps and system services.
    /// </summary>
    public enum ma_ios_session_category
    {
        standard = 0,        /* AVAudioSessionCategoryPlayAndRecord. */
        /// <summary>Leave the session category unchanged from the system default.</summary>
        none,               /* Leave the session category unchanged. */
        /// <summary>AVAudioSessionCategoryAmbient. Audio plays with the ring/silent
        /// switch and screen lock. Mixes with other audio.</summary>
        ambient,            /* AVAudioSessionCategoryAmbient */
        /// <summary>AVAudioSessionCategorySoloAmbient. Similar to Ambient but
        /// silences other audio.</summary>
        solo_ambient,       /* AVAudioSessionCategorySoloAmbient */
        /// <summary>AVAudioSessionCategoryPlayback. Audio plays even with the
        /// ring/silent switch set to silent and the screen locked.</summary>
        playback,           /* AVAudioSessionCategoryPlayback */
        /// <summary>AVAudioSessionCategoryRecord. Audio recording only; silences
        /// playback audio.</summary>
        record,             /* AVAudioSessionCategoryRecord */
        /// <summary>AVAudioSessionCategoryPlayAndRecord. Simultaneous playback
        /// and recording. This is the default.</summary>
        play_and_record,    /* AVAudioSessionCategoryPlayAndRecord */
        /// <summary>AVAudioSessionCategoryMultiRoute. Supports simultaneous
        /// output to multiple audio routes.</summary>
        multi_route         /* AVAudioSessionCategoryMultiRoute */
    }

    /// <summary>
    /// Dither modes for format conversion. Dithering adds a small amount of noise
    /// to reduce quantization distortion when converting to lower bit depths.
    /// </summary>
    public enum ma_dither_mode
    {
        /// <summary>No dithering. Fastest but may introduce quantization artifacts.</summary>
        none = 0,
        /// <summary>Rectangular dither. Adds uniform white noise to mask
        /// quantization distortion.</summary>
        rectangle,
        /// <summary>Triangular dither. Adds triangular probability density noise
        /// for improved noise shaping compared to rectangular dither.</summary>
        triangle
    }

    /// <summary>
    /// Audio encoding and container formats supported by miniaudio for both
    /// decoding and encoding operations.
    /// </summary>
    public enum ma_encoding_format
    {
        /// <summary>Unknown or unspecified format.</summary>
        unknown = 0,
        /// <summary>WAV (Waveform Audio File Format). Uncompressed PCM data
        /// stored in a RIFF container.</summary>
        wav,
        /// <summary>FLAC (Free Lossless Audio Codec). Lossless audio compression.</summary>
        flac,
        /// <summary>MP3 (MPEG Audio Layer III). Lossy audio compression.</summary>
        mp3,
        /// <summary>Vorbis. Lossy audio compression typically stored in an
        /// Ogg container.</summary>
        vorbis
    }

    /// <summary>
    /// Execution paths for the data converter. Determines the sequence of conversion
    /// steps (format, channel, and resampling) applied to audio data. The converter
    /// selects the optimal path automatically based on the input and output configurations.
    /// </summary>
    public enum ma_data_converter_execution_path
    {
        /// <summary>No conversion needed. Input and output formats, channels, and
        /// sample rates are identical.</summary>
        passthrough,       /* No conversion. */
        /// <summary>Only format conversion is needed (e.g. s16 to f32).</summary>
        format_only,       /* Only format conversion. */
        /// <summary>Only channel conversion is needed (e.g. stereo to mono).</summary>
        channels_only,     /* Only channel conversion. */
        /// <summary>Only resampling is needed (e.g. 44100 Hz to 48000 Hz).</summary>
        resample_only,     /* Only resampling. */
        /// <summary>All conversion types needed, with resampling performed as the
        /// first step.</summary>
        resample_first,    /* All conversions, but resample as the first step. */
        /// <summary>All conversion types needed, with channel conversion performed
        /// as the first step.</summary>
        channels_first     /* All conversions, but channels as the first step. */
    }

    /// <summary>
    /// Channel conversion paths used internally by the channel converter. Describes
    /// the strategy used to convert between input and output channel configurations.
    /// </summary>
    public enum ma_channel_conversion_path
    {
        /// <summary>Unknown conversion path.</summary>
        unknown,
        /// <summary>No conversion needed. Input and output channel maps are identical.</summary>
        passthrough,
        /// <summary>Converting a multi-channel signal to mono by averaging all channels.</summary>
        mono_out,    /* Converting to mono. */
        /// <summary>Converting a mono signal to multi-channel output.</summary>
        mono_in,     /* Converting from mono. */
        /// <summary>Simple channel reordering. Used when all channels are present in both input and output maps but in different positions.</summary>
        shuffle,     /* Simple shuffle. Will use this when all channels are present in both input and output channel maps, but just in a different order. */
        /// <summary>Conversion using weighted blending. Used when the input and output
        /// channel maps differ significantly, requiring channel mixing based on weights.</summary>
        weights      /* Blended based on weights. */
    }

    /// <summary>
    /// Device lifecycle states. Tracks whether a device is initialized, started,
    /// stopped, or in a transitional state between started and stopped.
    /// </summary>
    public enum ma_device_state
    {
        /// <summary>The device has not been initialized. Default state before
        /// calling an init function.</summary>
        uninitialized = 0,
        /// <summary>The device has been initialized but is not processing audio. This is the default state after calling a device init function.</summary>
        stopped = 1,  /* The device's default state after initialization. */
        /// <summary>The device is actively requesting and/or delivering audio data.</summary>
        started = 2,  /* The device is started and is requesting and/or delivering audio data. */
        /// <summary>The device is in the process of transitioning from stopped to started.</summary>
        starting = 3,  /* Transitioning from a stopped state to started. */
        /// <summary>The device is in the process of transitioning from started to stopped.</summary>
        stopping = 4   /* Transitioning from a started state to stopped. */
    }

    /// <summary>
    /// Flags for sound initialization in the engine. Controls how the resource manager
    /// loads and manages the audio data, plus engine-specific behavior. Can be combined
    /// with bitwise OR.
    /// </summary>
    [Flags]
    public enum ma_sound_flags
    {
        /// <summary>Load the sound as a stream. The sound data will be loaded incrementally
        /// from disk on a background thread rather than fully loaded into memory. Best for
        /// long audio files and music. Equivalent to MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM.</summary>
        stream = 0x00000001,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM */
        /// <summary>Decode the sound data before storing in memory. The decoding is done at the
        /// resource manager level rather than on the mixing thread, resulting in faster mixing
        /// but higher memory usage. Equivalent to MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE.</summary>
        decode = 0x00000002,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE */
        /// <summary>Load the sound asynchronously. The sound will be loaded on a background
        /// thread, and initialization will return immediately. Equivalent to
        /// MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC.</summary>
        asynchronous = 0x00000004,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC */
        /// <summary>Wait for initialization of the underlying data source to complete before
        /// returning from the init function. When combined with <c>asynchronous</c>, the init
        /// function blocks until the first data is available. Equivalent to
        /// MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT.</summary>
        wait_init = 0x00000008,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT */
        /// <summary>Hint that the length of the data source is unknown. Avoids calling
        /// ma_data_source_get_length_in_pcm_frames(). Useful for internet radio streams.
        /// Equivalent to MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH.</summary>
        unknown_length = 0x00000010,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH */
        /// <summary>Configure the sound to loop by default. Equivalent to
        /// MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_LOOPING.</summary>
        looping = 0x00000020,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_LOOPING */

        /// <summary>Do not attach the sound to the engine's endpoint by default. Useful
        /// when setting up nodes in a complex graph system where manual routing is required.</summary>
        /* ma_sound specific flags. */
        no_default_attachment = 0x00001000,   /* Do not attach to the endpoint by default. Useful for when setting up nodes in a complex graph system. */
        /// <summary>Disable pitch shifting. Pitching functions will have no effect.
        /// This is an optimization that allows the resampler to be bypassed.</summary>
        no_pitch = 0x00002000,   /* Disable pitch shifting with ma_sound_set_pitch() and ma_sound_group_set_pitch(). This is an optimization. */
        /// <summary>Disable 3D spatialization. The sound will not be positioned in 3D space
        /// and will play as a regular stereo/mono source. This is an optimization.</summary>
        no_spatialization = 0x00004000    /* Disable spatialization. */
    }

    /// <summary>
    /// Playback states for nodes in the audio node graph. A node can be either
    /// started (actively processing) or stopped (silent).
    /// </summary>
    public enum ma_node_state
    {
        /// <summary>The node is started and actively processing audio data.</summary>
        started = 0,
        /// <summary>The node is stopped and will not process audio data.
        /// Data is not read from its input connections when stopped.</summary>
        stopped = 1
    }

    /// <summary>
    /// Flags describing behavioral characteristics of nodes in the audio node graph.
    /// Can be combined with bitwise OR.
    /// </summary>
    [Flags]
    public enum ma_node_flags
    {
        /// <summary>Passthrough mode. Input audio data passes through the node
        /// without any processing.</summary>
        passthrough = 0x00000001,
        /// <summary>Continuous processing mode. The node's processing callback will
        /// be called continuously even when no input data is available, allowing
        /// the node to generate output from its internal state (e.g. oscillators).</summary>
        continuous_processing = 0x00000002,
        /// <summary>Allow null input. The node's processing callback will be invoked
        /// even when no input connections are attached, with null input buffers.</summary>
        allow_null_input = 0x00000004,
        /// <summary>Enable different processing rates. The node may consume input
        /// frames and produce output frames at different rates, such as when
        /// performing resampling internally.</summary>
        different_processing_rates = 0x00000008,
        /// <summary>Silent output hint. The node's output is expected to be silence
        /// and downstream processing may be optimized accordingly.</summary>
        silent_output = 0x00000010
    }

    /// <summary>
    /// Waveform types for the waveform generator. Produces periodic audio signals
    /// with configurable amplitude and frequency.
    /// </summary>
    public enum ma_waveform_type
    {
        /// <summary>Sine wave. Produces a smooth, pure tone with no harmonics.</summary>
        sine,
        /// <summary>Square wave. Produces a hollow, bright tone with odd harmonics.
        /// Amplitude alternates between positive and negative at the given frequency.</summary>
        square,
        /// <summary>Triangle wave. Produces a softer tone than a square wave with
        /// odd harmonics that roll off more quickly.</summary>
        triangle,
        /// <summary>Sawtooth wave. Produces a bright, buzzy tone containing both
        /// even and odd harmonics. The waveform ramps upward and jumps downward.</summary>
        sawtooth
    }

    /// <summary>
    /// Noise types for the noise generator. Each type has a different frequency
    /// spectrum characteristic.
    /// </summary>
    public enum ma_noise_type
    {
        /// <summary>White noise. Equal energy per frequency across the entire
        /// spectrum. Sounds like static or hiss.</summary>
        white,
        /// <summary>Pink noise. Equal energy per octave, with power decreasing
        /// by 3 dB per octave. Sounds more natural than white noise.</summary>
        pink,
        /// <summary>Brownian noise (brown noise). Power decreases by 6 dB per octave.
        /// Sounds deeper and more muffled than pink noise, like a low rumble.</summary>
        brownian
    }

    /// <summary>
    /// Engine node types for the high-level audio engine. Distinguishes between
    /// individual sound nodes and sound group nodes for collective control.
    /// </summary>
    public enum ma_engine_node_type
    {
        /// <summary>A sound node representing an individual audio source that
        /// can be positioned, pitched, and faded independently.</summary>
        ma_engine_node_type_sound,
        /// <summary>A sound group node that can contain multiple children
        /// (sounds or sub-groups) for collective control of volume, pitch,
        /// and spatialization.</summary>
        ma_engine_node_type_group
    }
}
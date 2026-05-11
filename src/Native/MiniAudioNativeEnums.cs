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
    public enum ma_result
    {
        success = 0,
        error = -1,  /* A generic error. */
        invalid_args = -2,
        invalid_operation = -3,
        out_of_memory = -4,
        out_of_range = -5,
        access_denied = -6,
        does_not_exist = -7,
        already_exists = -8,
        too_many_open_files = -9,
        invalid_file = -10,
        too_big = -11,
        path_too_long = -12,
        name_too_long = -13,
        not_directory = -14,
        is_directory = -15,
        directory_not_empty = -16,
        at_end = -17,
        no_space = -18,
        busy = -19,
        io_error = -20,
        interrupt = -21,
        unavailable = -22,
        already_in_use = -23,
        bad_address = -24,
        bad_seek = -25,
        bad_pipe = -26,
        deadlock = -27,
        too_many_links = -28,
        not_implemented = -29,
        no_message = -30,
        bad_message = -31,
        no_data_available = -32,
        invalid_data = -33,
        timeout = -34,
        no_network = -35,
        not_unique = -36,
        not_socket = -37,
        no_address = -38,
        bad_protocol = -39,
        protocol_unavailable = -40,
        protocol_not_supported = -41,
        protocol_family_not_supported = -42,
        address_family_not_supported = -43,
        socket_not_supported = -44,
        connection_reset = -45,
        already_connected = -46,
        not_connected = -47,
        connection_refused = -48,
        no_host = -49,
        in_progress = -50,
        cancelled = -51,
        memory_already_mapped = -52,

        /* General non-standard errors. */
        crc_mismatch = -100,

        /* General miniaudio-specific errors. */
        format_not_supported = -200,
        device_type_not_supported = -201,
        share_mode_not_supported = -202,
        no_backend = -203,
        no_device = -204,
        api_not_found = -205,
        invalid_device_config = -206,
        loop = -207,
        backend_not_enabled = -208,

        /* State errors. */
        device_not_initialized = -300,
        device_already_initialized = -301,
        device_not_started = -302,
        device_not_stopped = -303,

        /* Operation errors. */
        failed_to_init_backend = -400,
        failed_to_open_backend_device = -401,
        failed_to_start_backend_device = -402,
        failed_to_stop_backend_device = -403
    }

    public enum ma_standard_channel_map
    {
        microsoft,
        alsa,
        rfc3551,   /* Based off AIFF. */
        flac,
        vorbis,
        sound4,    /* FreeBSD's sound(4). */
        sndio,     /* www.sndio.org/tips.html */
        webaudio = flac, /* https://webaudio.github.io/web-audio-api/#ChannelOrdering. Only 1, 2, 4 and 6 channels are defined, but can fill in the gaps with logical assumptions. */
        standard = microsoft
    }

    public enum ma_device_notification_type
    {
        started,
        stopped,
        rerouted,
        interruption_began,
        interruption_ended,
        unlocked
    }

    public enum ma_resource_manager_data_supply_type
    {
        unknown = 0,   /* Used for determining whether or the data supply has been initialized. */
        encoded,       /* Data supply is an encoded buffer. Connector is ma_decoder. */
        decoded,       /* Data supply is a decoded buffer. Connector is ma_audio_buffer. */
        decoded_paged  /* Data supply is a linked list of decoded buffers. Connector is ma_paged_audio_buffer. */
    }

    public enum ma_seek_origin
    {
        start,
        current,
        end  /* Not used by decoders. */
    }

    public enum ma_performance_profile
    {
        low_latency = 0,
        conservative
    }

    public enum ma_channel_mix_mode
    {
        rectangular = 0,   /* Simple averaging based on the plane(s) the channel is sitting on. */
        simple,            /* Drop excess channels; zeroed out extra channels. */
        custom_weights,    /* Use custom weights specified in ma_channel_converter_config. */
        standard = rectangular // Actually called 'ma_channel_mix_mode_default' but 'default' is a reserved keyword in C#
    }

    public enum ma_wasapi_usage
    {
        standard = 0, // Actually called 'ma_wasapi_usage_default' but 'default' is a reserved keyword in C#
        games,
        pro_audio,
    }

    public enum ma_opensl_stream_type
    {
        standard = 0,              /* Leaves the stream type unset. */
        voice,                    /* SL_ANDROID_STREAM_VOICE */
        system,                   /* SL_ANDROID_STREAM_SYSTEM */
        ring,                     /* SL_ANDROID_STREAM_RING */
        media,                    /* SL_ANDROID_STREAM_MEDIA */
        alarm,                    /* SL_ANDROID_STREAM_ALARM */
        notification              /* SL_ANDROID_STREAM_NOTIFICATION */
    }

    public enum ma_opensl_recording_preset
    {
        standard = 0,         /* Leaves the input preset unset. */
        generic,             /* SL_ANDROID_RECORDING_PRESET_GENERIC */
        camcorder,           /* SL_ANDROID_RECORDING_PRESET_CAMCORDER */
        voice_recognition,   /* SL_ANDROID_RECORDING_PRESET_VOICE_RECOGNITION */
        voice_communication, /* SL_ANDROID_RECORDING_PRESET_VOICE_COMMUNICATION */
        voice_unprocessed    /* SL_ANDROID_RECORDING_PRESET_UNPROCESSED */
    }

    public enum ma_aaudio_usage
    {
        standard = 0,                    /* Leaves the usage type unset. */
        media,                          /* AAUDIO_USAGE_MEDIA */
        voice_communication,            /* AAUDIO_USAGE_VOICE_COMMUNICATION */
        voice_communication_signalling, /* AAUDIO_USAGE_VOICE_COMMUNICATION_SIGNALLING */
        alarm,                          /* AAUDIO_USAGE_ALARM */
        notification,                   /* AAUDIO_USAGE_NOTIFICATION */
        notification_ringtone,          /* AAUDIO_USAGE_NOTIFICATION_RINGTONE */
        notification_event,             /* AAUDIO_USAGE_NOTIFICATION_EVENT */
        assistance_accessibility,       /* AAUDIO_USAGE_ASSISTANCE_ACCESSIBILITY */
        assistance_navigation_guidance, /* AAUDIO_USAGE_ASSISTANCE_NAVIGATION_GUIDANCE */
        assistance_sonification,        /* AAUDIO_USAGE_ASSISTANCE_SONIFICATION */
        game,                           /* AAUDIO_USAGE_GAME */
        assitant,                       /* AAUDIO_USAGE_ASSISTANT */
        emergency,                      /* AAUDIO_SYSTEM_USAGE_EMERGENCY */
        safety,                         /* AAUDIO_SYSTEM_USAGE_SAFETY */
        vehicle_status,                 /* AAUDIO_SYSTEM_USAGE_VEHICLE_STATUS */
        announcement                    /* AAUDIO_SYSTEM_USAGE_ANNOUNCEMENT */
    }

    public enum ma_aaudio_content_type
    {
        standard = 0,             /* Leaves the content type unset. */
        speech,                  /* AAUDIO_CONTENT_TYPE_SPEECH */
        music,                   /* AAUDIO_CONTENT_TYPE_MUSIC */
        movie,                   /* AAUDIO_CONTENT_TYPE_MOVIE */
        sonification             /* AAUDIO_CONTENT_TYPE_SONIFICATION */
    }

    public enum ma_aaudio_input_preset
    {
        standard = 0,             /* Leaves the input preset unset. */
        generic,                 /* AAUDIO_INPUT_PRESET_GENERIC */
        camcorder,               /* AAUDIO_INPUT_PRESET_CAMCORDER */
        voice_recognition,       /* AAUDIO_INPUT_PRESET_VOICE_RECOGNITION */
        voice_communication,     /* AAUDIO_INPUT_PRESET_VOICE_COMMUNICATION */
        unprocessed,             /* AAUDIO_INPUT_PRESET_UNPROCESSED */
        voice_performance        /* AAUDIO_INPUT_PRESET_VOICE_PERFORMANCE */
    }

    public enum ma_aaudio_allowed_capture_policy
    {
        standard = 0,            /* Leaves the allowed capture policy unset. */
        by_all,                 /* AAUDIO_ALLOW_CAPTURE_BY_ALL */
        by_system,              /* AAUDIO_ALLOW_CAPTURE_BY_SYSTEM */
        by_none                 /* AAUDIO_ALLOW_CAPTURE_BY_NONE */
    }

    public enum ma_resample_algorithm
    {
        linear = 0,    /* Fastest, lowest quality. Optional low-pass filtering. Default. */
        custom,
    }

    public enum ma_share_mode
    {
        shared = 0,
        exclusive
    }

    public enum ma_attenuation_model
    {
        none,          /* No distance attenuation and no spatialization. */
        inverse,       /* Equivalent to OpenAL's AL_INVERSE_DISTANCE_CLAMPED. */
        linear,        /* Linear attenuation. Equivalent to OpenAL's AL_LINEAR_DISTANCE_CLAMPED. */
        exponential    /* Exponential attenuation. Equivalent to OpenAL's AL_EXPONENT_DISTANCE_CLAMPED. */
    }

    /* Backend enums must be in priority order. */
    public enum ma_backend
    {
        wasapi,
        dsound,
        winmm,
        coreaudio,
        sndio,
        audio4,
        oss,
        pulseaudio,
        alsa,
        jack,
        aaudio,
        opensl,
        webaudio,
        custom,  /* <-- Custom backend, with callbacks defined by the context config. */
        nill     /* <-- Must always be the last item. Lowest priority, and used as the terminator for backend enumeration. */
    }

    public enum ma_format
    {
        /*
        I like to keep these explicitly defined because they're used as a key into a lookup table. When items are
        added to this, make sure there are no gaps and that they're added to the lookup table in ma_get_bytes_per_sample().
        */
        unknown = 0,     /* Mainly used for indicating an error, but also used as the default for the output format for decoders. */
        u8 = 1,
        s16 = 2,     /* Seems to be the most widely supported format. */
        s24 = 3,     /* Tightly packed. 3 bytes per sample. */
        s32 = 4,
        f32 = 5,
        count
    }

    public enum ma_pan_mode
    {
        balance = 0,    /* Does not blend one side with the other. Technically just a balance. Compatible with other popular audio engines and therefore the default. */
        pan             /* A true pan. The sound from one side will "move" to the other side and blend with it. */
    }

    public enum ma_positioning
    {
        absolute,
        relative
    }

    public enum ma_handedness
    {
        right,
        left
    }

    public enum ma_allocation_type
    {
        async_notification,
        biquad_coefficient,
        biquad,
        bpf,
        bpf2,
        bpf_node,
        channel,
        context,
        data_source,
        data_source_node,
        data_source_vtable,
        decoder,
        decoding_backend_vtable,
        delay,
        delay_node,
        device,
        device_capture,
        device_descriptor,
        device_id,
        device_info,
        device_notification,
        device_playback,
        device_resampling,
        effect_node,
        encoder,
        engine,
        fader,
        fence,
        gainer,
        hishelf2,
        hishelf_node,
        hpf,
        hpf1,
        hpf2,
        hpf_node,
        log,
        loshelf2,
        loshelf_node,
        lpf,
        lpf1,
        lpf2,
        lpf_node,
        node,
        node_base,
        node_graph,
        node_input_bus,
        node_output_bus,
        node_vtable,
        noise,
        notch2,
        notch_node,
        panner,
        peak2,
        peak_node,
        procedural_data_source,
        pulsewave,
        resampling_backend_vtable,
        resource_manager,
        resource_manager_data_source,
        sound,
        sound_inlined,
        sound_group,
        spatializer,
        spatializer_listener,
        splitter_node,
        stack,
        vfs,
        waveform,
    }

    public enum ma_device_type
    {
        playback = 1,
        capture = 2,
        duplex = playback | capture, /* 3 */
        loopback = 4
    }

    public enum ma_mono_expansion_mode
    {
        duplicate = 0,   /* The default. */
        average,         /* Average the mono channel across all channels. */
        stereo_only,     /* Duplicate to the left and right channels only and ignore the others. */
        standard = duplicate
    }

    public enum ma_thread_priority
    {
        idle = -5,
        lowest = -4,
        low = -3,
        normal = -2,
        high = -1,
        highest = 0,
        realtime = 1,
        standard = 0
    }

    public enum ma_ios_session_category
    {
        standard = 0,        /* AVAudioSessionCategoryPlayAndRecord. */
        none,               /* Leave the session category unchanged. */
        ambient,            /* AVAudioSessionCategoryAmbient */
        solo_ambient,       /* AVAudioSessionCategorySoloAmbient */
        playback,           /* AVAudioSessionCategoryPlayback */
        record,             /* AVAudioSessionCategoryRecord */
        play_and_record,    /* AVAudioSessionCategoryPlayAndRecord */
        multi_route         /* AVAudioSessionCategoryMultiRoute */
    }

    public enum ma_dither_mode
    {
        none = 0,
        rectangle,
        triangle
    }

    public enum ma_encoding_format
    {
        unknown = 0,
        wav,
        flac,
        mp3,
        vorbis
    }

    public enum ma_data_converter_execution_path
    {
        passthrough,       /* No conversion. */
        format_only,       /* Only format conversion. */
        channels_only,     /* Only channel conversion. */
        resample_only,     /* Only resampling. */
        resample_first,    /* All conversions, but resample as the first step. */
        channels_first     /* All conversions, but channels as the first step. */
    }

    public enum ma_channel_conversion_path
    {
        unknown,
        passthrough,
        mono_out,    /* Converting to mono. */
        mono_in,     /* Converting from mono. */
        shuffle,     /* Simple shuffle. Will use this when all channels are present in both input and output channel maps, but just in a different order. */
        weights      /* Blended based on weights. */
    }

    public enum ma_device_state
    {
        uninitialized = 0,
        stopped = 1,  /* The device's default state after initialization. */
        started = 2,  /* The device is started and is requesting and/or delivering audio data. */
        starting = 3,  /* Transitioning from a stopped state to started. */
        stopping = 4   /* Transitioning from a started state to stopped. */
    }

    [Flags]
    public enum ma_sound_flags
    {
        stream = 0x00000001,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM */
        decode = 0x00000002,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE */
        asynchronous = 0x00000004,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC */
        wait_init = 0x00000008,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT */
        unknown_length = 0x00000010,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH */
        looping = 0x00000020,   /* MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_LOOPING */

        /* ma_sound specific flags. */
        no_default_attachment = 0x00001000,   /* Do not attach to the endpoint by default. Useful for when setting up nodes in a complex graph system. */
        no_pitch = 0x00002000,   /* Disable pitch shifting with ma_sound_set_pitch() and ma_sound_group_set_pitch(). This is an optimization. */
        no_spatialization = 0x00004000    /* Disable spatialization. */
    }

    public enum ma_node_state
    {
        started = 0,
        stopped = 1
    }

    [Flags]
    public enum ma_node_flags
    {
        passthrough = 0x00000001,
        continuous_processing = 0x00000002,
        allow_null_input = 0x00000004,
        different_processing_rates = 0x00000008,
        silent_output = 0x00000010
    }

    public enum ma_waveform_type
    {
        sine,
        square,
        triangle,
        sawtooth
    }

    public enum ma_noise_type
    {
        white,
        pink,
        brownian
    }
}
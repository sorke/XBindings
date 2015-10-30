using System;
using ObjCRuntime;

namespace XBindings.Yuntongxun
{
    [Native]
    public enum ECConnectState : ulong
    {
        Success = 0,
        ing,
        Failed
    }

    [Native]
    public enum ECNetworkType : long
    {
        None = 0,
        Wifi,
        ECNetworkType_4G,
        ECNetworkType_3G,
        Gprs,
        Lan
    }

    [Native]
    public enum ECSpeakStatus : long
    {
        Allow = 1,
        Forbid
    }

    [Native]
    public enum ECSexType : long
    {
        Male = 1,
        Female
    }

    [Native]
    public enum ECMemberRole : long
    {
        Creator = 1,
        Admin,
        Member
    }

    [Native]
    public enum ECAckType : long
    {
        None = 0,
        Reject = 1,
        Agree = 2,
        Done = 3
    }

    [Native]
    public enum ECMessageState : long
    {
        SendFail = -1,
        SendSuccess = 0,
        Sending = 1,
        Receive = 2
    }

    [Native]
    public enum ECRotate : ulong
    {
        Auto,
        Rotate_0,
        Rotate_90,
        Rotate_180,
        Rotate_270
    }

    [Native]
    public enum ECAudioType : ulong
    {
        Agc,
        Ec,
        Ns
    }

    [Native]
    public enum ECAudioNsMode : ulong
    {
        Unchanged = 0,
        Default,
        Conference,
        LowSuppression,
        ModerateSuppression,
        HighSuppression,
        VeryHighSuppression
    }

    [Native]
    public enum ECAudioAgcMode : ulong
    {
        Unchanged = 0,
        Default,
        AdaptiveAnalog,
        AdaptiveDigital,
        FixedDigital
    }

    [Native]
    public enum ECAudioEcMode : ulong
    {
        Unchanged = 0,
        Default,
        Conference,
        Aec,
        Aecm
    }

    [Native]
    public enum APPFirewallPolicy : ulong
    {
        NoFirewall = 0,
        UseIce
    }

    [Native]
    public enum ECCodec : ulong
    {
        iLBC = 0,
        G729,
        Pcmu,
        Pcma,
        H264,
        Silk8k,
        Amr,
        Vp8,
        Silk16k
    }

    [Native]
    public enum ECMeetingType : long
    {
        MultiVoice = 1,
        MultiVideo = 2,
        Interphone = 3
    }

    [Native]
    public enum MessageBodyType : long
    {
        Text = 1,
        Voice = 2,
        Video = 3,
        Image = 4,
        Location = 5,
        File = 6
    }

    [Native]
    public enum ECErrorType : long
    {
        Connecting = 100,
        NoError = 200,
        ContentTooLong = 170001,
        IsEmpty = 170002,
        NotLogin = 170003,
        SendMsgFailed = 170004,
        IsRecording = 170005,
        RecordTimeOut = 170006,
        RecordStoped = 170007,
        RecordTimeTooShort = 170008,
        FileNotExist = 170011,
        TypeIsWrong = 170012,
        SDKUnSupport = 170013,
        CalleeSDKUnSupport = 170014,
        NO_CallID = 170015,
        SDK_NO_ConfigFile = 170016,
        LocalCallBusy = 170486,
        NoResponse = 175001,
        KickedOff = 175004,
        OtherSideOffline = 175404,
        Timeout = 175408,
        CallMissed = 175409,
        Gone = 175410,
        TemporarilyNotAvailable = 175480,
        CallBusy = 175486,
        Declined = 175603,
        MD5TokenIsEmpty = 520003,
        TimestampIsEmpty = 520004,
        ApptokenIsEmpty = 520005,
        MD5TokenTimeInvalid = 520007,
        MD5TokenIsInvalid = 520008,
        TokenAuthFailed = 520016,
        AuthServerException = 529999,
        ConnectorServerException = 559999,
        File_NoJoined = 560072,
        File_Have_Forbid = 560073,
        Have_Forbid = 580010,
        Have_Joined = 590017
    }

    [Native]
    public enum ECMediaDownloadStatus : ulong
    {
        UnDownload,
        Downloading,
        DownloadSuccessed,
        DownloadFailure
    }

    [Native]
    public enum ECGroupScope : ulong
    {
        None = 0,
        Temp = 1,
        Normal,
        Normal_Senior,
        Vip,
        VIP_Senior
    }

    [Native]
    public enum ECGroupPermMode : ulong
    {
        None = 0,
        DefaultJoin = 1,
        NeedIdAuth,
        PrivateGroup
    }

    [Native]
    public enum ECGroupSearchType : ulong
    {
        Id = 1,
        Name = 2
    }

    [Native]
    public enum ECGroupMessageType : ulong
    {
        Dissmiss,
        Invite,
        Propose,
        Join,
        Quit,
        RemoveMember,
        ReplyInvite,
        ReplyJoin,
        ModifyGroup
    }

    [Native]
    public enum ECallDirect : ulong
    {
        Outgoing = 0,
        Incoming
    }

    [Native]
    public enum ECallStatus : ulong
    {
        Proceeding = 0,
        Alerting,
        Failed,
        Ring,
        Streaming,
        Releasing,
        Paused,
        PausedByRemote,
        Resumed,
        ResumedByRemote,
        Transfered,
        End
    }

    [Native]
    public enum CallType : ulong
    {
        Voice = 0,
        Video = 1,
        LandingCall = 2
    }

    [Native]
    public enum ECInterphoneMeetingMsgType : ulong
    {
        Invite = 201,
        Join = 202,
        Exit = 203,
        Over = 204,
        Controlmic = 205,
        Releasemic = 206
    }

    [Native]
    public enum ECMultiVoiceMeetingMsgType : ulong
    {
        Join = 301,
        Exit = 302,
        Delete = 303,
        Removemember = 304,
        Refuse = 306
    }

    [Native]
    public enum ECMultiVideoMeetingMsgType : ulong
    {
        Join = 601,
        Exit = 602,
        Delete = 603,
        Removemember = 604,
        Publish = 607,
        Unpublish = 608,
        Refuse = 609
    }

    [Native]
    public enum LoginMode : ulong
    {
        InputPassword = 1,
        AutoInputLogin = 2
    }

    [Native]
    public enum LoginAuthType : ulong
    {
        NormalAuth = 1,
        PasswordAuth = 3,
        MD5TokenAuth = 4
    }
}
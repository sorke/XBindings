using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace XBindings.RongCloud
{
    public enum Mode : ulong
    {
        Mr475 = 0,
        Mr515,
        Mr59,
        Mr67,
        Mr74,
        Mr795,
        Mr102,
        Mr122,
        Mrdtx,
        NModes
    }

    static class CFunctions
    {
        // extern void * Encoder_Interface_init (int dtx);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void* Encoder_Interface_init(int dtx);

        // extern void Encoder_Interface_exit (void *state);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void Encoder_Interface_exit(void* state);

        // extern int Encoder_Interface_Encode (void *state, enum Mode mode, const short *speech, unsigned char *out, int forceSpeech);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe int Encoder_Interface_Encode(void* state, Mode mode, short* speech, byte* @out, int forceSpeech);

        // extern void * Decoder_Interface_init ();
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void* Decoder_Interface_init();

        // extern void Decoder_Interface_exit (void *state);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void Decoder_Interface_exit(void* state);

        // extern void Decoder_Interface_Decode (void *state, const unsigned char *in, short *out, int bfi);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void Decoder_Interface_Decode(void* state, byte* @in, short* @out, int bfi);
    }

    [Native]
    public enum RCConnectErrorCode : long
    {
        NetNaviError = 30000,
        NetChannelInvalid = 30001,
        NetUnavailable = 30002,
        MsgRespTimeout = 30003,
        HttpSendFail = 30004,
        HttpReqTimeout = 30005,
        HttpRecvFail = 30006,
        NaviResourceError = 30007,
        NodeNotFound = 30008,
        DomainNotResolve = 30009,
        SocketNotCreated = 30010,
        SocketDisconnected = 30011,
        PingSendFail = 30012,
        PongRecvFail = 30013,
        MsgSendFail = 30014,
        ConnAckTimeout = 31000,
        ConnProtoVersionError = 31001,
        ConnIdReject = 31002,
        ConnServerUnavailable = 31003,
        ConnTokenIncorrect = 31004,
        ConnNotAuthrorized = 31005,
        ConnRedirected = 31006,
        ConnPackageNameInvalid = 31007,
        ConnAppBlockedOrDeleted = 31008,
        ConnUserBlocked = 31009,
        DisconnKick = 31010,
        QueryAckNoData = 32001,
        MsgDataIncomplete = 32002,
        InvalidArgument = -1000
    }

    [Native]
    public enum RCConnectionStatus : long
    {
        Unknown = -1,
        Connected = 0,
        NetworkUnavailable = 1,
        AirplaneMode = 2,
        Cellular_2G = 3,
        Cellular_3G_4G = 4,
        Wifi = 5,
        KickedOfflineByOtherClient = 6,
        LoginOnWeb = 7,
        ServerInvalid = 8,
        ValidateInvalid = 9,
        Connecting = 10,
        Unconnected = 11,
        SignUp = 12,
        TokenIncorrect = 31004,
        DisconnException = 31011
    }

    [Native]
    public enum RCConversationType : ulong
    {
        Private = 1,
        Discussion,
        Group,
        Chatroom,
        Customerservice,
        System,
        Appservice,
        Publicservice,
        Pushservice
    }

    [Native]
    public enum RCMessageDirection : ulong
    {
        Send = 1,
        Receive
    }

    [Native]
    public enum RCMediaType : ulong
    {
        Image = 1,
        Audio,
        Video,
        File = 100
    }

    [Native]
    public enum RCMessagePersistent : ulong
    {
        None = 0,
        Ispersisted = 1 << 0,
        Iscounted = 1 << 1
    }

    [Native]
    public enum RCSentStatus : ulong
    {
        Sending = 10,
        Failed = 20,
        Sent = 30,
        Received = 40,
        Read = 50,
        Destroyed = 60
    }

    [Native]
    public enum RCReceivedStatus : ulong
    {
        Unread = 0,
        Read = 1,
        Listened = 2,
        Downloaded = 4
    }

    [Native]
    public enum RCErrorCode : long
    {
        ErrorcodeUnknown = -1,
        ErrorcodeTimeout = 5004,
        RejectedByBlacklist = 405,
        NotInDiscussion = 21406,
        NotInGroup = 22406,
        ForbiddenInGroup = 22408,
        NotInChatroom = 23406
    }

    [Native]
    public enum RCConversationNotificationStatus : ulong
    {
        DoNotDisturb = 0,
        Notify = 1
    }

    [Native]
    public enum RCCurrentConnectionStatus : ulong
    {
        Disconnected = 9,
        Connected = 0,
        Connecting = 2
    }

    [Native]
    public enum RCSearchType : ulong
    {
        Exact = 0,
        Fuzzy = 1
    }

    [Native]
    public enum RCPublicServiceType : ulong
    {
        AppPublicService = 7,
        PublicService = 8
    }

    [Native]
    public enum RCPublicServiceMenuItemType : ulong
    {
        Group = 0,
        View = 1,
        Click = 2
    }

    [Native]
    public enum RCSDKRunningMode : ulong
    {
        Backgroud = 0,
        Foregroud = 1
    }

    [Native]
    public enum RCNetworkStatus : ulong
    {
        NotReachable = 0,
        ReachableViaWiFi,
        ReachableViaLTE,
        ReachableVia3G,
        ReachableVia2G
    }

    [Native]
    public enum RCDiscussionNotificationType : long
    {
        InviteDiscussionNotification = 1,
        QuitDiscussionNotification,
        RenameDiscussionTitleNotification,
        RemoveDiscussionMemberNotification,
        SwichInvitationAccessNotification
    }

    [Native]
    public enum RCRealTimeLocationStatus : long
    {
        Idle,
        Incoming,
        Outgoing,
        Connected
    }

    [Native]
    public enum RCRealTimeLocationErrorCode : long
    {
        NotSupport,
        ConversationNotSupport,
        ExceedMaxParticipant,
        GetConversationFailure
    }
}
using System;
using ObjCRuntime;

namespace XBindings.EaseMob
{
    [Native]
    public enum EMChatState : long
    {
        Stopped = 0,
        Composing,
        Paused
    }

    [Native]
    public enum EMOnlineStatus : long
    {
        OffLine = 0,
        Online,
        Away,
        Busy,
        Invisible,
        Do_Not_Disturb
    }

    [Native]
    public enum EMPushNotificationDisplayStyle : long
    {
        simpleBanner = 0,
        messageSummary = 1
    }

    [Native]
    public enum EMPushNotificationNoDisturbStatus : long
    {
        Day = 0,
        Custom = 1,
        Close = 2
    }

    [Native]
    public enum EMGroupLeaveReason : long
    {
        BeRemoved = 1,
        UserLeave,
        Destroyed
    }

    [Native]
    public enum EMGroupMemberRole : long
    {
        Member = 0,
        Admin,
        Owner
    }

    [Native]
    public enum MessageBodyType : long
    {
        Text = 1,
        Image,
        Video,
        Location,
        Voice,
        File,
        Command
    }

    [Native]
    public enum MessageDeliveryState : long
    {
        Pending = 0,
        Delivering,
        Delivered,
        Failure
    }

    [Native]
    public enum EMReceiptType : long
    {
        quest = 0,
        sponse
    }

    [Native]
    public enum EMConversationType : long
    {
        Chat,
        GroupChat,
        ChatRoom
    }

    [Native]
    public enum EMMessageType : long
    {
        Chat,
        GroupChat,
        ChatRoom
    }

    [Native]
    public enum EMBackupMessagesStatus : long
    {
        None = 0,
        Formatting,
        Compressing,
        Uploading,
        Updating,
        Cancelled,
        Failed,
        Succeeded
    }

    [Native]
    public enum EMRestoreBackupStatus : long
    {
        None = 0,
        Downloading,
        Decompressing,
        Importing,
        Cancelled,
        Failed,
        Succeeded
    }

    [Native]
    public enum EMAudioOutputDevice : long
    {
        earphone = 0,
        speaker
    }

    [Native]
    public enum EMAudioPlaybackMode : long
    {
        Simple = 0,
        SimpleExclusive,
        PersistPlay,
        RecordOnly,
        PlayAndRecord
    }

    [Native]
    public enum EMErrorType : long
    {
        NotFound = 404,
        ServerMaxCountExceeded = 500,
        ConfigInvalidAppKey = 1000,
        ServerNotLogin = 1002,
        ServerNotReachable,
        ServerTimeout,
        ServerAuthenticationFailure,
        ServerAPNSRegistrationFailure,
        ServerDuplicatedAccount,
        ServerInsufficientPrivilege,
        ServerTooManyOperations,
        AttachmentNotFound,
        AttachmentUploadFailure,
        IllegalURI,
        MessageInvalid_NULL,
        MessageContainSensitiveWords,
        GroupInvalidID_NULL,
        GroupJoined,
        GroupJoinNeedRequired,
        GroupFetchInfoFailure,
        GroupInvalidRequired,
        GroupInvalidSubject_NULL,
        GroupAddOccupantFailure,
        InvalidUsername,
        InvalidUsername_NULL,
        InvalidUsername_Chinese,
        InvalidPassword_NULL,
        InvalidPassword_Chinese,
        ApnsInvalidOption,
        HasFetchedBuddyList,
        BlockBuddyFailure,
        UnblockBuddyFailure,
        CallRemoteOffline,
        CallInvalidId,
        CallConnectFailure,
        Existed,
        InitFailure,
        NetworkNotConnected,
        Failure,
        FeatureNotImplemented,
        RequestRefused,
        ChatroomInvalidID_NULL,
        ChatroomJoined,
        ChatroomNotJoined,
        ReachLimit = ServerMaxCountExceeded,
        OutOfRateLimited = ServerMaxCountExceeded,
        GroupOccupantsReachLimit = ServerMaxCountExceeded,
        TooManyLoginRequest = ServerTooManyOperations,
        TooManyLogoffRequest = ServerTooManyOperations,
        PermissionFailure = ServerInsufficientPrivilege,
        IsExist = Existed,
        PushNotificationInvalidOption = ApnsInvalidOption,
        CallChatterOffline = CallRemoteOffline
    }

    [Native]
    public enum EMRelationship : long
    {
        Both = 0,
        From,
        To
    }

    [Native]
    public enum EMConnectionState : ulong
    {
        Connected,
        Disconnected
    }

    [Native]
    public enum EMConnectionType : long
    {
        None = 0,
        Wwan,
        Wifi,
        eConnectionType_2G,
        eConnectionType_3G,
        eConnectionType_4G
    }

    [Native]
    public enum EMConnectionName : long
    {
        Internet = 0,
        LocalWIFI,
        Default = Internet
    }

    [Native]
    public enum EMChatroomBeKickedReason : long
    {
        BeRemoved = 1,
        Destroyed
    }

    [Native]
    public enum EMAttachmentDownloadStatus : ulong
    {
        Downloading,
        DownloadSuccessed,
        DownloadFailure,
        NotStarted
    }

    [Native]
    public enum EMBuddyFollowState : long
    {
        NotFollowed = 0,
        Followed,
        BeFollowed,
        FollowedBoth
    }

    [Native]
    public enum EMGroupStyle : long
    {
        PrivateOnlyOwnerInvite = 0,
        PrivateMemberCanInvite,
        PublicJoinNeedApproval,
        PublicOpenJoin,
        PublicAnonymous,
        Default = PrivateOnlyOwnerInvite
    }

    [Native]
    public enum EMCallSessionStatus : long
    {
        Disconnected = 0,
        Ringing,
        Answering,
        Pausing,
        Connecting,
        Connected,
        Accepted
    }

    [Native]
    public enum EMCallSessionType : long
    {
        Audio = 0,
        Video,
        Content
    }

    [Native]
    public enum EMCallStatusChangedReason : long
    {
        Null = 0,
        Offline,
        NoResponse,
        Hangup,
        Reject,
        Busy,
        Failure,
        Null = Null,
        Offline = Offline,
        NoResponse = NoResponse,
        Hangup = Hangup,
        Reject = Reject,
        Busy = Busy,
        Failure = Failure
    }

    [Native]
    public enum EMCallConnectType : long
    {
        None = 0,
        Direct,
        Relay
    }
}
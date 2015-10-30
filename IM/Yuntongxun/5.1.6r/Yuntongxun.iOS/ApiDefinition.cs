using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace XBindings.Yuntongxun
{
    // @protocol ECManagerBase <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ECManagerBase
    {
    }

    // @interface ECMessageBody : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }
    }

    // @interface ECMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMessage
    {
        // @property (copy, nonatomic) NSString * from;
        [Export("from")]
        string From { get; set; }

        // @property (copy, nonatomic) NSString * to;
        [Export("to")]
        string To { get; set; }

        // @property (copy, nonatomic) NSString * messageId;
        [Export("messageId")]
        string MessageId { get; set; }

        // @property (nonatomic, strong) ECMessageBody * messageBody;
        [Export("messageBody", ArgumentSemantic.Strong)]
        ECMessageBody MessageBody { get; set; }

        // @property (copy, nonatomic) NSString * timestamp;
        [Export("timestamp")]
        string Timestamp { get; set; }

        // @property (copy, nonatomic) NSString * userData;
        [Export("userData")]
        string UserData { get; set; }

        // @property (copy, nonatomic) NSString * sessionId;
        [Export("sessionId")]
        string SessionId { get; set; }

        // @property (nonatomic) BOOL isGroup;
        [Export("isGroup")]
        bool IsGroup { get; set; }

        // @property (nonatomic) ECMessageState messageState;
        [Export("messageState", ArgumentSemantic.Assign)]
        ECMessageState MessageState { get; set; }

        // @property (nonatomic) BOOL isRead;
        [Export("isRead")]
        bool IsRead { get; set; }

        // @property (copy, nonatomic) NSString * groupSenderName;
        [Export("groupSenderName")]
        string GroupSenderName { get; set; }

        // -(instancetype)initWithReceiver:(NSString *)receiver body:(ECMessageBody *)body;
        [Export("initWithReceiver:body:")]
        IntPtr Constructor(string receiver, ECMessageBody body);
    }

    // @interface ECError : NSObject
    [BaseType(typeof(NSObject))]
    interface ECError
    {
        // @property (readonly, nonatomic) ECErrorType errorCode;
        [Export("errorCode")]
        ECErrorType ErrorCode { get; }

        // @property (copy, nonatomic) NSString * errorDescription;
        [Export("errorDescription")]
        string ErrorDescription { get; set; }

        // +(ECError *)errorWithCode:(ECErrorType)errorCode;
        [Static]
        [Export("errorWithCode:")]
        ECError ErrorWithCode(ECErrorType errorCode);

        // +(ECError *)errorWithNSError:(NSError *)error;
        [Static]
        [Export("errorWithNSError:")]
        ECError ErrorWithNSError(NSError error);
    }

    // @protocol ECProgressDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ECProgressDelegate
    {
        // @required -(void)setProgress:(float)progress forMessage:(ECMessage *)message;
        //[Abstract]
        [Export("setProgress:forMessage:")]
        void ForMessage(float progress, ECMessage message);
    }

    // @interface ECFileMessageBody : ECMessageBody
    [BaseType(typeof(ECMessageBody))]
    interface ECFileMessageBody
    {
        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * serverTime;
        [Export("serverTime", ArgumentSemantic.Strong)]
        string ServerTime { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic, strong) NSString * remotePath;
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) ECMediaDownloadStatus mediaDownloadStatus;
        [Export("mediaDownloadStatus", ArgumentSemantic.Assign)]
        ECMediaDownloadStatus MediaDownloadStatus { get; set; }

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)displayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string displayName);
    }

    // @interface ECVoiceMessageBody : ECFileMessageBody
    [BaseType(typeof(ECFileMessageBody))]
    interface ECVoiceMessageBody
    {
        // @property (assign, nonatomic) BOOL isPlay;
        [Export("isPlay")]
        bool IsPlay { get; set; }

        // @property (nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)displayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string displayName);
    }

    // @interface ECVideoMessageBody : ECFileMessageBody
    [BaseType(typeof(ECFileMessageBody))]
    interface ECVideoMessageBody
    {
        // @property (nonatomic, strong) NSString * thumbnailLocalPath;
        [Export("thumbnailLocalPath", ArgumentSemantic.Strong)]
        string ThumbnailLocalPath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailRemotePath;
        [Export("thumbnailRemotePath", ArgumentSemantic.Strong)]
        string ThumbnailRemotePath { get; set; }

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)displayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string displayName);
    }

    // @interface ECImageMessageBody : ECFileMessageBody
    [BaseType(typeof(ECFileMessageBody))]
    interface ECImageMessageBody
    {
        // @property (nonatomic) ECMediaDownloadStatus thumbnailDownloadStatus;
        [Export("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
        ECMediaDownloadStatus ThumbnailDownloadStatus { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailLocalPath;
        [Export("thumbnailLocalPath", ArgumentSemantic.Strong)]
        string ThumbnailLocalPath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailRemotePath;
        [Export("thumbnailRemotePath", ArgumentSemantic.Strong)]
        string ThumbnailRemotePath { get; set; }

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)displayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string displayName);
    }

    // @protocol ECChatManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ECChatManager : ECManagerBase
    {
        // @required -(NSString *)sendMessage:(ECMessage *)message progress:(id<ECProgressDelegate>)progress completion:(void (^)(ECError *, ECMessage *))completion;
        //[Abstract]
        [Export("sendMessage:progress:completion:")]
        string SendMessage(ECMessage message, ECProgressDelegate progress, Action<ECError, ECMessage> completion);

        // @required -(void)startVoiceRecording:(ECVoiceMessageBody *)msg error:(void (^)(ECError *, ECVoiceMessageBody *))error;
        //[Abstract]
        [Export("startVoiceRecording:error:")]
        void StartVoiceRecording(ECVoiceMessageBody msg, Action<ECError, ECVoiceMessageBody> error);

        // @required -(void)stopVoiceRecording:(void (^)(ECError *, ECVoiceMessageBody *))completion;
        //[Abstract]
        [Export("stopVoiceRecording:")]
        void StopVoiceRecording(Action<ECError, ECVoiceMessageBody> completion);

        // @required -(void)playVoiceMessage:(ECVoiceMessageBody *)msg completion:(void (^)(ECError *))completion;
        //[Abstract]
        [Export("playVoiceMessage:completion:")]
        void PlayVoiceMessage(ECVoiceMessageBody msg, Action<ECError> completion);

        // @required -(BOOL)stopPlayingVoiceMessage;
        //[Abstract]
        [Export("stopPlayingVoiceMessage")]
        //[Verify (MethodToProperty)]
        bool StopPlayingVoiceMessage { get; }

        // @required -(void)downloadMediaMessage:(ECMessage *)message progress:(id<ECProgressDelegate>)progress completion:(void (^)(ECError *, ECMessage *))completion;
        //[Abstract]
        [Export("downloadMediaMessage:progress:completion:")]
        void DownloadMediaMessage(ECMessage message, ECProgressDelegate progress, Action<ECError, ECMessage> completion);

        // @required -(void)downloadThumbnailMessage:(ECMessage *)message progress:(id<ECProgressDelegate>)progress completion:(void (^)(ECError *, ECMessage *))completion;
        //[Abstract]
        [Export("downloadThumbnailMessage:progress:completion:")]
        void DownloadThumbnailMessage(ECMessage message, ECProgressDelegate progress, Action<ECError, ECMessage> completion);
    }

    // @interface ECGroup : NSObject
    [BaseType(typeof(NSObject))]
    interface ECGroup
    {
        // @property (copy, nonatomic) NSString * groupId;
        [Export("groupId")]
        string GroupId { get; set; }

        // @property (copy, nonatomic) NSString * owner;
        [Export("owner")]
        string Owner { get; set; }

        // @property (copy, nonatomic) NSString * createdTime;
        [Export("createdTime")]
        string CreatedTime { get; set; }

        // @property (copy, nonatomic) NSString * name;
        [Export("name")]
        string Name { get; set; }

        // @property (nonatomic, strong) NSArray * members;
        [Export("members", ArgumentSemantic.Strong)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] Members { get; set; }

        // @property (copy, nonatomic) NSString * declared;
        [Export("declared")]
        string Declared { get; set; }

        // @property (copy, nonatomic) NSString * remark;
        [Export("remark")]
        string Remark { get; set; }

        // @property (assign, nonatomic) ECGroupPermMode mode;
        [Export("mode", ArgumentSemantic.Assign)]
        ECGroupPermMode Mode { get; set; }

        // @property (assign, nonatomic) ECGroupScope scope;
        [Export("scope", ArgumentSemantic.Assign)]
        ECGroupScope Scope { get; set; }

        // @property (assign, nonatomic) NSInteger memberCount;
        [Export("memberCount")]
        nint MemberCount { get; set; }

        // @property (assign, nonatomic) NSInteger type;
        [Export("type")]
        nint Type { get; set; }

        // @property (copy, nonatomic) NSString * province;
        [Export("province")]
        string Province { get; set; }

        // @property (copy, nonatomic) NSString * city;
        [Export("city")]
        string City { get; set; }

        // @property (assign, nonatomic) BOOL isDismiss;
        [Export("isDismiss")]
        bool IsDismiss { get; set; }

        // @property (assign, nonatomic) BOOL isNotice;
        [Export("isNotice")]
        bool IsNotice { get; set; }

        // @property (assign, nonatomic) BOOL isPushAPNS;
        [Export("isPushAPNS")]
        bool IsPushAPNS { get; set; }

        // -(ECGroup *)initWithID:(NSString *)groupId;
        [Export("initWithID:")]
        IntPtr Constructor(string groupId);
    }

    // @interface ECGroupMatch : NSObject
    [BaseType(typeof(NSObject))]
    interface ECGroupMatch
    {
        // @property (assign, nonatomic) ECGroupSearchType searchType;
        [Export("searchType", ArgumentSemantic.Assign)]
        ECGroupSearchType SearchType { get; set; }

        // @property (copy, nonatomic) NSString * keywords;
        [Export("keywords")]
        string Keywords { get; set; }
    }

    // @interface ECGroupMember : NSObject
    [BaseType(typeof(NSObject))]
    interface ECGroupMember
    {
        // @property (copy, nonatomic) NSString * memberId;
        [Export("memberId")]
        string MemberId { get; set; }

        // @property (copy, nonatomic) NSString * display;
        [Export("display")]
        string Display { get; set; }

        // @property (copy, nonatomic) NSString * tel;
        [Export("tel")]
        string Tel { get; set; }

        // @property (copy, nonatomic) NSString * mail;
        [Export("mail")]
        string Mail { get; set; }

        // @property (copy, nonatomic) NSString * remark;
        [Export("remark")]
        string Remark { get; set; }

        // @property (copy, nonatomic) NSString * groupId;
        [Export("groupId")]
        string GroupId { get; set; }

        // @property (assign, nonatomic) ECSpeakStatus speakStatus;
        [Export("speakStatus", ArgumentSemantic.Assign)]
        ECSpeakStatus SpeakStatus { get; set; }

        // @property (assign, nonatomic) ECMemberRole role;
        [Export("role", ArgumentSemantic.Assign)]
        ECMemberRole Role { get; set; }

        // @property (assign, nonatomic) ECSexType sex;
        [Export("sex", ArgumentSemantic.Assign)]
        ECSexType Sex { get; set; }
    }

    // @interface ECGroupOption : NSObject
    [BaseType(typeof(NSObject))]
    interface ECGroupOption
    {
        // @property (copy, nonatomic) NSString * groupId;
        [Export("groupId")]
        string GroupId { get; set; }

        // @property (assign, nonatomic) BOOL isNotice;
        [Export("isNotice")]
        bool IsNotice { get; set; }

        // @property (assign, nonatomic) BOOL isPushAPNS;
        [Export("isPushAPNS")]
        bool IsPushAPNS { get; set; }
    }

    // @protocol ECGroupManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(ECManagerBase))]
    interface ECGroupManager
    {
        // @required -(void)createGroup:(ECGroup *)group completion:(void (^)(ECError *, ECGroup *))completion;
        //[Abstract]
        [Export("createGroup:completion:")]
        void CreateGroup(ECGroup group, Action<ECError, ECGroup> completion);

        // @required -(void)modifyGroup:(ECGroup *)group completion:(void (^)(ECError *, ECGroup *))completion;
        //[Abstract]
        [Export("modifyGroup:completion:")]
        void ModifyGroup(ECGroup group, Action<ECError, ECGroup> completion);

        // @required -(void)deleteGroup:(NSString *)groupId completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("deleteGroup:completion:")]
        void DeleteGroup(string groupId, Action<ECError, NSString> completion);

        // @required -(void)searchPublicGroups:(ECGroupMatch *)match completion:(void (^)(ECError *, NSArray *))completion;
        //[Abstract]
        [Export("searchPublicGroups:completion:")]
        void SearchPublicGroups(ECGroupMatch match, Action<ECError, NSArray> completion);

        // @required -(void)getGroupDetail:(NSString *)groupId completion:(void (^)(ECError *, ECGroup *))completion;
        //[Abstract]
        [Export("getGroupDetail:completion:")]
        void GetGroupDetail(string groupId, Action<ECError, ECGroup> completion);

        // @required -(void)joinGroup:(NSString *)groupId reason:(NSString *)reason completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("joinGroup:reason:completion:")]
        void JoinGroup(string groupId, string reason, Action<ECError, NSString> completion);

        // @required -(void)inviteJoinGroup:(NSString *)groupId reason:(NSString *)reason members:(NSArray *)members confirm:(NSInteger)confirm completion:(void (^)(ECError *, NSString *, NSArray *))completion;
        //[Abstract]
        [Export("inviteJoinGroup:reason:members:confirm:completion:")]
        //[Verify (StronglyTypedNSArray)]
        void InviteJoinGroup(string groupId, string reason, NSObject[] members, nint confirm, Action<ECError, NSString, NSArray> completion);

        // @required -(void)deleteGroupMember:(NSString *)groupId member:(NSString *)member completion:(void (^)(ECError *, NSString *, NSString *))completion;
        //[Abstract]
        [Export("deleteGroupMember:member:completion:")]
        void DeleteGroupMember(string groupId, string member, Action<ECError, NSString, NSString> completion);

        // @required -(void)quitGroup:(NSString *)groupId completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("quitGroup:completion:")]
        void QuitGroup(string groupId, Action<ECError, NSString> completion);

        // @required -(void)modifyMemberCard:(ECGroupMember *)member completion:(void (^)(ECError *, ECGroupMember *))completion;
        //[Abstract]
        [Export("modifyMemberCard:completion:")]
        void ModifyMemberCard(ECGroupMember member, Action<ECError, ECGroupMember> completion);

        // @required -(void)queryMemberCard:(NSString *)memberId belong:(NSString *)groupId completion:(void (^)(ECError *, ECGroupMember *))completion;
        //[Abstract]
        [Export("queryMemberCard:belong:completion:")]
        void QueryMemberCard(string memberId, string groupId, Action<ECError, ECGroupMember> completion);

        // @required -(void)queryGroupMembers:(NSString *)groupId completion:(void (^)(ECError *, NSString *, NSArray *))completion;
        //[Abstract]
        [Export("queryGroupMembers:completion:")]
        void QueryGroupMembers(string groupId, Action<ECError, NSString, NSArray> completion);

        // @required -(void)queryGroupMembers:(NSString *)groupId border:(NSString *)borderMemberId pageSize:(NSInteger)pageSize completion:(void (^)(ECError *, NSString *, NSArray *))completion;
        //[Abstract]
        [Export("queryGroupMembers:border:pageSize:completion:")]
        void QueryGroupMembers(string groupId, string borderMemberId, nint pageSize, Action<ECError, NSString, NSArray> completion);

        // @required -(void)queryOwnGroups:(void (^)(ECError *, NSArray *))completion;
        //[Abstract]
        [Export("queryOwnGroups:")]
        void QueryOwnGroups(Action<ECError, NSArray> completion);

        // @required -(void)queryOwnGroupsWithBoarder:(NSString *)boarderGroupId pageSize:(NSInteger)pageSize completion:(void (^)(ECError *, NSArray *))completion;
        //[Abstract]
        [Export("queryOwnGroupsWithBoarder:pageSize:completion:")]
        void QueryOwnGroupsWithBoarder(string boarderGroupId, nint pageSize, Action<ECError, NSArray> completion);

        // @required -(void)forbidMemberSpeakStatus:(NSString *)groupId member:(NSString *)memberId speakStatus:(ECSpeakStatus)status completion:(void (^)(ECError *, NSString *, NSString *))completion;
        //[Abstract]
        [Export("forbidMemberSpeakStatus:member:speakStatus:completion:")]
        void ForbidMemberSpeakStatus(string groupId, string memberId, ECSpeakStatus status, Action<ECError, NSString, NSString> completion);

        // @required -(void)ackJoinGroupRequest:(NSString *)groupId member:(NSString *)memberId ackType:(ECAckType)type completion:(void (^)(ECError *, NSString *, NSString *))completion;
        //[Abstract]
        [Export("ackJoinGroupRequest:member:ackType:completion:")]
        void AckJoinGroupRequest(string groupId, string memberId, ECAckType type, Action<ECError, NSString, NSString> completion);

        // @required -(void)ackInviteJoinGroupRequest:(NSString *)groupId invitor:(NSString *)invitor ackType:(ECAckType)type completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("ackInviteJoinGroupRequest:invitor:ackType:completion:")]
        void AckInviteJoinGroupRequest(string groupId, string invitor, ECAckType type, Action<ECError, NSString> completion);

        // @required -(void)setGroupMessageOption:(ECGroupOption *)option completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("setGroupMessageOption:completion:")]
        void SetGroupMessageOption(ECGroupOption option, Action<ECError, NSString> completion);
    }

    // @protocol ECDeskManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(ECManagerBase))]
    interface ECDeskManager
    {
        // @optional -(void)startConsultationWithAgent:(NSString *)agent completion:(void (^)(ECError *, NSString *))completion;
        [Export("startConsultationWithAgent:completion:")]
        void StartConsultationWithAgent(string agent, Action<ECError, NSString> completion);

        // @optional -(void)finishConsultationWithAgent:(NSString *)agent completion:(void (^)(ECError *, NSString *))completion;
        [Export("finishConsultationWithAgent:completion:")]
        void FinishConsultationWithAgent(string agent, Action<ECError, NSString> completion);

        // @optional -(NSString *)sendToDeskMessage:(ECMessage *)message progress:(id<ECProgressDelegate>)progress completion:(void (^)(ECError *, ECMessage *))completion;
        [Export("sendToDeskMessage:progress:completion:")]
        string SendToDeskMessage(ECMessage message, ECProgressDelegate progress, Action<ECError, ECMessage> completion);
    }

    // @protocol ECMessageManager <ECChatManager, ECGroupManager, ECDeskManager>
    [Protocol]
    [BaseType(typeof(ECChatManager))]
    interface ECMessageManager : ECGroupManager, ECDeskManager
    {
    }

    // @protocol ECDelegateBase <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ECDelegateBase
    {
        // @optional -(void)onConnected:(ECError *)error;
        [Export("onConnected:")]
        void OnConnected(ECError error);

        // @optional -(void)onConnectState:(ECConnectState)state failed:(ECError *)error;
        [Export("onConnectState:failed:")]
        void OnConnectState(ECConnectState state, ECError error);

        // @optional -(void)onServicePersonVersion:(unsigned long long)version;
        [Export("onServicePersonVersion:")]
        void OnServicePersonVersion(ulong version);
    }

    // @protocol ECNetworkDelegate <ECDelegateBase>
    [Protocol, Model]
    [BaseType(typeof(ECDelegateBase))]
    interface ECNetworkDelegate
    {
        // @optional -(void)onReachbilityChanged:(ECNetworkType)status;
        [Export("onReachbilityChanged:")]
        void OnReachbilityChanged(ECNetworkType status);
    }

    // @interface ECGroupNoticeMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface ECGroupNoticeMessage
    {
        // @property (copy, nonatomic) NSString * sender;
        [Export("sender")]
        string Sender { get; set; }

        // @property (copy, nonatomic) NSString * groupId;
        [Export("groupId")]
        string GroupId { get; set; }

        // @property (copy, nonatomic) NSString * groupName;
        [Export("groupName")]
        string GroupName { get; set; }

        // @property (readonly, nonatomic) ECGroupMessageType messageType;
        [Export("messageType")]
        ECGroupMessageType MessageType { get; }

        // @property (copy, nonatomic) NSString * dateCreated;
        [Export("dateCreated")]
        string DateCreated { get; set; }

        // @property (assign, nonatomic) BOOL isRead;
        [Export("isRead")]
        bool IsRead { get; set; }
    }

    // @interface ECDismissGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECDismissGroupMsg
    {
    }

    // @interface ECInviterMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECInviterMsg
    {
        // @property (copy, nonatomic) NSString * admin;
        [Export("admin")]
        string Admin { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }

        // @property (copy, nonatomic) NSString * declared;
        [Export("declared")]
        string Declared { get; set; }

        // @property (assign, nonatomic) NSInteger confirm;
        [Export("confirm")]
        nint Confirm { get; set; }
    }

    // @interface ECProposerMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECProposerMsg
    {
        // @property (copy, nonatomic) NSString * proposer;
        [Export("proposer")]
        string Proposer { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }

        // @property (copy, nonatomic) NSString * declared;
        [Export("declared")]
        string Declared { get; set; }

        // @property (assign, nonatomic) NSInteger confirm;
        [Export("confirm")]
        nint Confirm { get; set; }
    }

    // @interface ECJoinGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECJoinGroupMsg
    {
        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }

        // @property (copy, nonatomic) NSString * declared;
        [Export("declared")]
        string Declared { get; set; }
    }

    // @interface ECQuitGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECQuitGroupMsg
    {
        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }
    }

    // @interface ECRemoveMemberMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECRemoveMemberMsg
    {
        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }
    }

    // @interface ECReplyJoinGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECReplyJoinGroupMsg
    {
        // @property (copy, nonatomic) NSString * admin;
        [Export("admin")]
        string Admin { get; set; }

        // @property (assign, nonatomic) NSInteger confirm;
        [Export("confirm")]
        nint Confirm { get; set; }

        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }
    }

    // @interface ECReplyInviteGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECReplyInviteGroupMsg
    {
        // @property (copy, nonatomic) NSString * admin;
        [Export("admin")]
        string Admin { get; set; }

        // @property (assign, nonatomic) NSInteger confirm;
        [Export("confirm")]
        nint Confirm { get; set; }

        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }
    }

    // @interface ECModifyGroupMsg : ECGroupNoticeMessage
    [BaseType(typeof(ECGroupNoticeMessage))]
    interface ECModifyGroupMsg
    {
        // @property (copy, nonatomic) NSString * member;
        [Export("member")]
        string Member { get; set; }

        // @property (copy, nonatomic) NSDictionary * modifyDic;
        [Export("modifyDic", ArgumentSemantic.Copy)]
        NSDictionary ModifyDic { get; set; }
    }

    // @protocol ECGroupDelegate <ECDelegateBase>
    [Protocol, Model]
    interface ECGroupDelegate : ECDelegateBase
    {
        // @optional -(void)onReceiveGroupNoticeMessage:(ECGroupNoticeMessage *)groupMsg;
        [Export("onReceiveGroupNoticeMessage:")]
        void OnReceiveGroupNoticeMessage(ECGroupNoticeMessage groupMsg);
    }

    // @protocol ECChatDelegate <ECDelegateBase>
    [Protocol, Model]
    interface ECChatDelegate : ECDelegateBase
    {
        // @optional -(void)onRecordingAmplitude:(double)amplitude;
        [Export("onRecordingAmplitude:")]
        void OnRecordingAmplitude(double amplitude);

        // @optional -(void)onReceiveMessage:(ECMessage *)message;
        [Export("onReceiveMessage:")]
        void OnReceiveMessage(ECMessage message);

        // @optional -(void)onOfflineMessageCount:(NSUInteger)count;
        [Export("onOfflineMessageCount:")]
        void OnOfflineMessageCount(nuint count);

        // @optional -(NSInteger)onGetOfflineMessage;
        [Export("onGetOfflineMessage")]
        //[Verify (MethodToProperty)]
        nint OnGetOfflineMessage { get; }

        // @optional -(void)onReceiveOfflineMessage:(ECMessage *)message;
        [Export("onReceiveOfflineMessage:")]
        void OnReceiveOfflineMessage(ECMessage message);

        // @optional -(void)onReceiveOfflineCompletion:(BOOL)isCompletion;
        [Export("onReceiveOfflineCompletion:")]
        void OnReceiveOfflineCompletion(bool isCompletion);
    }

    // @protocol ECMessageDelegate <ECChatDelegate, ECGroupDelegate>
    [Protocol, Model]
    interface ECMessageDelegate : ECChatDelegate, ECGroupDelegate
    {
    }

    // @protocol ECDeskDelegate <ECDelegateBase>
    [Protocol, Model]
    interface ECDeskDelegate : ECDelegateBase
    {
        // @optional -(void)onReceiveDeskMessage:(ECMessage *)message;
        [Export("onReceiveDeskMessage:")]
        void OnReceiveDeskMessage(ECMessage message);
    }

    // @interface VoIPCall : NSObject
    [BaseType(typeof(NSObject))]
    interface VoIPCall
    {
        // @property (copy, nonatomic) NSString * callID;
        [Export("callID")]
        string CallID { get; set; }

        // @property (copy, nonatomic) NSString * caller;
        [Export("caller")]
        string Caller { get; set; }

        // @property (copy, nonatomic) NSString * callee;
        [Export("callee")]
        string Callee { get; set; }

        // @property (assign, nonatomic) ECallDirect callDirect;
        [Export("callDirect", ArgumentSemantic.Assign)]
        ECallDirect CallDirect { get; set; }

        // @property (assign, nonatomic) ECallStatus callStatus;
        [Export("callStatus", ArgumentSemantic.Assign)]
        ECallStatus CallStatus { get; set; }

        // @property (assign, nonatomic) CallType callType;
        [Export("callType", ArgumentSemantic.Assign)]
        CallType CallType { get; set; }

        // @property (assign, nonatomic) NSInteger reason;
        [Export("reason")]
        nint Reason { get; set; }
    }

    // @interface VoIPCallUserInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface VoIPCallUserInfo
    {
        // @property (copy, nonatomic) NSString * phoneNum;
        [Export("phoneNum")]
        string PhoneNum { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }
    }

    // @interface ECCallBackEntity : NSObject
    [BaseType(typeof(NSObject))]
    interface ECCallBackEntity
    {
        // @property (copy, nonatomic) NSString * src;
        [Export("src")]
        string Src { get; set; }

        // @property (copy, nonatomic) NSString * dest;
        [Export("dest")]
        string Dest { get; set; }

        // @property (copy, nonatomic) NSString * srcSerNum;
        [Export("srcSerNum")]
        string SrcSerNum { get; set; }

        // @property (copy, nonatomic) NSString * destSerNum;
        [Export("destSerNum")]
        string DestSerNum { get; set; }
    }

    // @protocol ECVoIPCallDelegate <ECDelegateBase>
    [Protocol, Model]
    interface ECVoIPCallDelegate : ECDelegateBase
    {
        // @optional -(NSString *)onIncomingCallReceived:(NSString *)callid withCallerAccount:(NSString *)caller withCallerPhone:(NSString *)callerphone withCallerName:(NSString *)callername withCallType:(CallType)calltype;
        [Export("onIncomingCallReceived:withCallerAccount:withCallerPhone:withCallerName:withCallType:")]
        string OnIncomingCallReceived(string callid, string caller, string callerphone, string callername, CallType calltype);

        // @optional -(void)onCallEvents:(VoIPCall *)voipCall;
        [Export("onCallEvents:")]
        void OnCallEvents(VoIPCall voipCall);

        // @optional -(void)onReceiveFrom:(NSString *)callid DTMF:(NSString *)dtmf;
        [Export("onReceiveFrom:DTMF:")]
        void OnReceiveFrom(string callid, string dtmf);

        // @optional -(void)onCallVideoRatioChanged:(NSString *)callid andVoIP:(NSString *)voip andIsConfrence:(BOOL)isConference andWidth:(NSInteger)width andHeight:(NSInteger)height;
        [Export("onCallVideoRatioChanged:andVoIP:andIsConfrence:andWidth:andHeight:")]
        void OnCallVideoRatioChanged(string callid, string voip, bool isConference, nint width, nint height);

        // @optional -(void)onSwitchCallMediaTypeRequest:(NSString *)callid withMediaType:(CallType)requestType;
        [Export("onSwitchCallMediaTypeRequest:withMediaType:")]
        void OnSwitchCallMediaTypeRequest(string callid, CallType requestType);

        // @optional -(void)onSwitchCallMediaTypeResponse:(NSString *)callid withMediaType:(CallType)responseType;
        [Export("onSwitchCallMediaTypeResponse:withMediaType:")]
        void OnSwitchCallMediaTypeResponse(string callid, CallType responseType);
    }

    // @interface ECInterphoneMeetingMsg : NSObject
    [BaseType(typeof(NSObject))]
    interface ECInterphoneMeetingMsg
    {
        // @property (assign, nonatomic) ECInterphoneMeetingMsgType type;
        [Export("type", ArgumentSemantic.Assign)]
        ECInterphoneMeetingMsgType Type { get; set; }

        // @property (copy, nonatomic) NSString * interphoneId;
        [Export("interphoneId")]
        string InterphoneId { get; set; }

        // @property (copy, nonatomic) NSString * dateCreated;
        [Export("dateCreated")]
        string DateCreated { get; set; }

        // @property (copy, nonatomic) NSString * fromVoip;
        [Export("fromVoip")]
        string FromVoip { get; set; }

        // @property (copy, nonatomic) NSArray * joinArr;
        [Export("joinArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] JoinArr { get; set; }

        // @property (copy, nonatomic) NSArray * exitArr;
        [Export("exitArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] ExitArr { get; set; }

        // @property (copy, nonatomic) NSString * voip;
        [Export("voip")]
        string Voip { get; set; }
    }

    // @interface ECVoIPAccount : NSObject
    [BaseType(typeof(NSObject))]
    interface ECVoIPAccount
    {
        // @property (assign, nonatomic) BOOL isVoIP;
        [Export("isVoIP")]
        bool IsVoIP { get; set; }

        // @property (copy, nonatomic) NSString * account;
        [Export("account")]
        string Account { get; set; }
    }

    // @interface ECMeetingMember : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMeetingMember
    {
        // @property (assign, nonatomic) ECMeetingType meetingType;
        [Export("meetingType", ArgumentSemantic.Assign)]
        ECMeetingType MeetingType { get; set; }

        // @property (assign, nonatomic) NSInteger role;
        [Export("role")]
        nint Role { get; set; }
    }

    // @interface ECMultiVoiceMeetingMember : ECMeetingMember
    [BaseType(typeof(ECMeetingMember))]
    interface ECMultiVoiceMeetingMember
    {
        // @property (nonatomic, strong) ECVoIPAccount * account;
        [Export("account", ArgumentSemantic.Strong)]
        ECVoIPAccount Account { get; set; }
    }

    // @interface ECInterphoneMeetingMember : ECMeetingMember
    [BaseType(typeof(ECMeetingMember))]
    interface ECInterphoneMeetingMember
    {
        // @property (copy, nonatomic) NSString * number;
        [Export("number")]
        string Number { get; set; }

        // @property (assign, nonatomic) BOOL isOnline;
        [Export("isOnline")]
        bool IsOnline { get; set; }

        // @property (assign, nonatomic) BOOL isMic;
        [Export("isMic")]
        bool IsMic { get; set; }
    }

    // @interface ECMultiVideoMeetingMember : ECMeetingMember
    [BaseType(typeof(ECMeetingMember))]
    interface ECMultiVideoMeetingMember
    {
        // @property (nonatomic, strong) ECVoIPAccount * voipAccount;
        [Export("voipAccount", ArgumentSemantic.Strong)]
        ECVoIPAccount VoipAccount { get; set; }

        // @property (assign, nonatomic) NSInteger videoState;
        [Export("videoState")]
        nint VideoState { get; set; }

        // @property (retain, nonatomic) NSString * videoSource;
        [Export("videoSource", ArgumentSemantic.Retain)]
        string VideoSource { get; set; }
    }

    // @interface ECMultiVoiceMeetingMsg : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMultiVoiceMeetingMsg
    {
        // @property (assign, nonatomic) ECMultiVoiceMeetingMsgType type;
        [Export("type", ArgumentSemantic.Assign)]
        ECMultiVoiceMeetingMsgType Type { get; set; }

        // @property (copy, nonatomic) NSString * roomNo;
        [Export("roomNo")]
        string RoomNo { get; set; }

        // @property (copy, nonatomic) NSArray * joinArr;
        [Export("joinArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] JoinArr { get; set; }

        // @property (copy, nonatomic) NSArray * exitArr;
        [Export("exitArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] ExitArr { get; set; }

        // @property (nonatomic, strong) ECVoIPAccount * who;
        [Export("who", ArgumentSemantic.Strong)]
        ECVoIPAccount Who { get; set; }

        // @property (copy, nonatomic) NSArray * refuseArr;
        [Export("refuseArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] RefuseArr { get; set; }
    }

    // @interface ECMultiVideoMeetingMsg : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMultiVideoMeetingMsg
    {
        // @property (assign, nonatomic) ECMultiVideoMeetingMsgType type;
        [Export("type", ArgumentSemantic.Assign)]
        ECMultiVideoMeetingMsgType Type { get; set; }

        // @property (copy, nonatomic) NSString * roomNo;
        [Export("roomNo")]
        string RoomNo { get; set; }

        // @property (copy, nonatomic) NSArray * joinArr;
        [Export("joinArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] JoinArr { get; set; }

        // @property (copy, nonatomic) NSArray * exitArr;
        [Export("exitArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] ExitArr { get; set; }

        // @property (nonatomic, strong) ECVoIPAccount * who;
        [Export("who", ArgumentSemantic.Strong)]
        ECVoIPAccount Who { get; set; }

        // @property (assign, nonatomic) NSInteger videoState;
        [Export("videoState")]
        nint VideoState { get; set; }

        // @property (retain, nonatomic) NSString * videoSource;
        [Export("videoSource", ArgumentSemantic.Retain)]
        string VideoSource { get; set; }

        // @property (copy, nonatomic) NSArray * refuseArr;
        [Export("refuseArr", ArgumentSemantic.Copy)]
        //[Verify (StronglyTypedNSArray)]
        NSObject[] RefuseArr { get; set; }
    }

    // @interface ECMeetingRoom : NSObject
    [BaseType(typeof(NSObject))]
    interface ECMeetingRoom
    {
        // @property (assign, nonatomic) ECMeetingType meetingType;
        [Export("meetingType", ArgumentSemantic.Assign)]
        ECMeetingType MeetingType { get; set; }

        // @property (copy, nonatomic) NSString * roomNo;
        [Export("roomNo")]
        string RoomNo { get; set; }

        // @property (copy, nonatomic) NSString * roomName;
        [Export("roomName")]
        string RoomName { get; set; }

        // @property (copy, nonatomic) NSString * creator;
        [Export("creator")]
        string Creator { get; set; }

        // @property (assign, nonatomic) NSInteger square;
        [Export("square")]
        nint Square { get; set; }

        // @property (copy, nonatomic) NSString * keywords;
        [Export("keywords")]
        string Keywords { get; set; }

        // @property (assign, nonatomic) NSInteger joinNum;
        [Export("joinNum")]
        nint JoinNum { get; set; }

        // @property (assign, nonatomic) BOOL isValidate;
        [Export("isValidate")]
        bool IsValidate { get; set; }
    }

    // @interface ECMultiVoiceMeetingRoom : ECMeetingRoom
    [BaseType(typeof(ECMeetingRoom))]
    interface ECMultiVoiceMeetingRoom
    {
    }

    // @interface ECMultiVideoMeetingRoom : ECMeetingRoom
    [BaseType(typeof(ECMeetingRoom))]
    interface ECMultiVideoMeetingRoom
    {
    }

    [Static]
    //[Verify (ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const ECMeetingDelegate_CallerAccount __attribute__((visibility("default")));
        [Field("ECMeetingDelegate_CallerAccount", "__Internal")]
        NSString ECMeetingDelegate_CallerAccount { get; }

        // extern NSString *const ECMeetingDelegate_CallerPhone __attribute__((visibility("default")));
        [Field("ECMeetingDelegate_CallerPhone", "__Internal")]
        NSString ECMeetingDelegate_CallerPhone { get; }

        // extern NSString *const ECMeetingDelegate_CallerName __attribute__((visibility("default")));
        [Field("ECMeetingDelegate_CallerName", "__Internal")]
        NSString ECMeetingDelegate_CallerName { get; }

        // extern NSString *const ECMeetingDelegate_CallerConfId __attribute__((visibility("default")));
        [Field("ECMeetingDelegate_CallerConfId", "__Internal")]
        NSString ECMeetingDelegate_CallerConfId { get; }
    }

    // @protocol ECMeetingDelegate <ECDelegateBase>
    [Protocol, Model]
    interface ECMeetingDelegate : ECDelegateBase
    {
        // @optional -(NSString *)onMeetingCallReceived:(NSString *)callid withCallType:(CallType)calltype withMeetingData:(NSDictionary *)meetingData;
        [Export("onMeetingCallReceived:withCallType:withMeetingData:")]
        string OnMeetingCallReceived(string callid, CallType calltype, NSDictionary meetingData);

        // @optional -(void)onReceiveInterphoneMeetingMsg:(ECInterphoneMeetingMsg *)msg;
        [Export("onReceiveInterphoneMeetingMsg:")]
        void OnReceiveInterphoneMeetingMsg(ECInterphoneMeetingMsg msg);

        // @optional -(void)onReceiveMultiVoiceMeetingMsg:(ECMultiVoiceMeetingMsg *)msg;
        [Export("onReceiveMultiVoiceMeetingMsg:")]
        void OnReceiveMultiVoiceMeetingMsg(ECMultiVoiceMeetingMsg msg);

        // @optional -(void)onReceiveMultiVideoMeetingMsg:(ECMultiVideoMeetingMsg *)msg;
        [Export("onReceiveMultiVideoMeetingMsg:")]
        void OnReceiveMultiVideoMeetingMsg(ECMultiVideoMeetingMsg msg);
    }

    // @protocol ECDeviceDelegate <ECNetworkDelegate, ECMessageDelegate, ECDeskDelegate, ECVoIPCallDelegate, ECMeetingDelegate>
    [BaseType(typeof(ECNetworkDelegate))]
    [Protocol, Model]
    interface ECDeviceDelegate : ECMessageDelegate, ECDeskDelegate, ECVoIPCallDelegate, ECMeetingDelegate
    {
    }

    // @interface ECLoginInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ECLoginInfo
    {
        // @property (assign, nonatomic) LoginAuthType authType;
        [Export("authType", ArgumentSemantic.Assign)]
        LoginAuthType AuthType { get; set; }

        // @property (assign, nonatomic) LoginMode mode;
        [Export("mode", ArgumentSemantic.Assign)]
        LoginMode Mode { get; set; }

        // @property (copy, nonatomic) NSString * username;
        [Export("username")]
        string Username { get; set; }

        // @property (copy, nonatomic) NSString * userPassword;
        [Export("userPassword")]
        string UserPassword { get; set; }

        // @property (copy, nonatomic) NSString * appKey;
        [Export("appKey")]
        string AppKey { get; set; }

        // @property (copy, nonatomic) NSString * appToken;
        [Export("appToken")]
        string AppToken { get; set; }

        // @property (copy, nonatomic) NSString * timestamp;
        [Export("timestamp")]
        string Timestamp { get; set; }

        // @property (copy, nonatomic) NSString * MD5Token;
        [Export("MD5Token")]
        string MD5Token { get; set; }
    }

    // @interface ECAudioConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface ECAudioConfig
    {
        // @property (assign, nonatomic) ECAudioType audioType;
        [Export("audioType", ArgumentSemantic.Assign)]
        ECAudioType AudioType { get; set; }

        // @property (assign, nonatomic) BOOL enable;
        [Export("enable")]
        bool Enable { get; set; }

        // @property (assign, nonatomic) NSInteger audioMode;
        [Export("audioMode")]
        nint AudioMode { get; set; }
    }

    // @interface NetworkStatistic : NSObject
    [BaseType(typeof(NSObject))]
    interface NetworkStatistic
    {
        // @property (nonatomic) long long duration;
        [Export("duration")]
        long Duration { get; set; }

        // @property (nonatomic) long long txBytes_sim;
        [Export("txBytes_sim")]
        long TxBytes_sim { get; set; }

        // @property (nonatomic) long long rxBytes_sim;
        [Export("rxBytes_sim")]
        long RxBytes_sim { get; set; }

        // @property (nonatomic) long long txBytes_wifi;
        [Export("txBytes_wifi")]
        long TxBytes_wifi { get; set; }

        // @property (nonatomic) long long rxBytes_wifi;
        [Export("rxBytes_wifi")]
        long RxBytes_wifi { get; set; }
    }

    // @interface CallStatisticsInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface CallStatisticsInfo
    {
        // @property (assign, nonatomic) NSUInteger rlFractionLost;
        [Export("rlFractionLost")]
        nuint RlFractionLost { get; set; }

        // @property (assign, nonatomic) NSUInteger rlCumulativeLost;
        [Export("rlCumulativeLost")]
        nuint RlCumulativeLost { get; set; }

        // @property (assign, nonatomic) NSUInteger rlExtendedMax;
        [Export("rlExtendedMax")]
        nuint RlExtendedMax { get; set; }

        // @property (assign, nonatomic) NSUInteger rlJitterSamples;
        [Export("rlJitterSamples")]
        nuint RlJitterSamples { get; set; }

        // @property (assign, nonatomic) NSInteger rlRttMs;
        [Export("rlRttMs")]
        nint RlRttMs { get; set; }

        // @property (assign, nonatomic) NSUInteger rlBytesSent;
        [Export("rlBytesSent")]
        nuint RlBytesSent { get; set; }

        // @property (assign, nonatomic) NSUInteger rlPacketsSent;
        [Export("rlPacketsSent")]
        nuint RlPacketsSent { get; set; }

        // @property (assign, nonatomic) NSUInteger rlBytesReceived;
        [Export("rlBytesReceived")]
        nuint RlBytesReceived { get; set; }

        // @property (assign, nonatomic) NSUInteger rlPacketsReceived;
        [Export("rlPacketsReceived")]
        nuint RlPacketsReceived { get; set; }
    }

    // @protocol ECVoIPSetManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(ECManagerBase))]
    interface ECVoIPSetManager
    {
        // @required -(NSInteger)setMute:(BOOL)on;
        //[Abstract]
        [Export("setMute:")]
        nint SetMute(bool on);

        // @required -(BOOL)getMuteStatus;
        //[Abstract]
        [Export("getMuteStatus")]
        //[Verify (MethodToProperty)]
        bool MuteStatus { get; }

        // @required -(BOOL)getLoudsSpeakerStatus;
        //[Abstract]
        [Export("getLoudsSpeakerStatus")]
        //[Verify (MethodToProperty)]
        bool LoudsSpeakerStatus { get; }

        // @required -(NSInteger)enableLoudsSpeaker:(BOOL)enable;
        //[Abstract]
        [Export("enableLoudsSpeaker:")]
        nint EnableLoudsSpeaker(bool enable);

        // @required -(void)setSelfPhoneNumber:(NSString *)phoneNumber;
        //[Abstract]
        [Export("setSelfPhoneNumber:")]
        void SetSelfPhoneNumber(string phoneNumber);

        // @required -(void)setVoipCallUserInfo:(VoIPCallUserInfo *)voipCallUserInfo;
        //[Abstract]
        [Export("setVoipCallUserInfo:")]
        void SetVoipCallUserInfo(VoIPCallUserInfo voipCallUserInfo);

        // @required -(NSInteger)setVideoView:(UIView *)view andLocalView:(UIView *)localView;
        //[Abstract]
        [Export("setVideoView:andLocalView:")]
        nint SetVideoView(UIView view, UIView localView);

        // @required -(NSArray *)getCameraInfo;
        //[Abstract]
        [Export("getCameraInfo")]
        //[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
        NSObject[] CameraInfo { get; }

        // @required -(NSInteger)selectCamera:(NSInteger)cameraIndex capability:(NSInteger)capabilityIndex fps:(NSInteger)fps rotate:(ECRotate)rotate;
        //[Abstract]
        [Export("selectCamera:capability:fps:rotate:")]
        nint SelectCamera(nint cameraIndex, nint capabilityIndex, nint fps, ECRotate rotate);

        // @required -(void)setCodecEnabledWithCodec:(ECCodec)codec andEnabled:(BOOL)enabled;
        //[Abstract]
        [Export("setCodecEnabledWithCodec:andEnabled:")]
        void SetCodecEnabledWithCodec(ECCodec codec, bool enabled);

        // @required -(BOOL)getCondecEnabelWithCodec:(ECCodec)codec;
        //[Abstract]
        [Export("getCondecEnabelWithCodec:")]
        bool GetCondecEnabelWithCodec(ECCodec codec);

        // @required -(void)setUserAgent:(NSString *)agent;
        //[Abstract]
        [Export("setUserAgent:")]
        void SetUserAgent(string agent);

        // @required -(NSInteger)setAudioConfigEnabledWithType:(ECAudioType)type andEnabled:(BOOL)enabled andMode:(NSInteger)mode;
        //[Abstract]
        [Export("setAudioConfigEnabledWithType:andEnabled:andMode:")]
        nint SetAudioConfigEnabledWithType(ECAudioType type, bool enabled, nint mode);

        // @required -(ECAudioConfig *)getAudioConfigEnabelWithType:(ECAudioType)type;
        //[Abstract]
        [Export("getAudioConfigEnabelWithType:")]
        ECAudioConfig GetAudioConfigEnabelWithType(ECAudioType type);

        // @required -(void)setVideoBitRates:(NSInteger)bitrates;
        //[Abstract]
        [Export("setVideoBitRates:")]
        void SetVideoBitRates(nint bitrates);

        // @required -(CallStatisticsInfo *)getCallStatisticsWithCallid:(NSString *)digid andType:(CallType)type;
        //[Abstract]
        [Export("getCallStatisticsWithCallid:andType:")]
        CallStatisticsInfo GetCallStatisticsWithCallid(string digid, CallType type);

        // @required -(NetworkStatistic *)getNetworkStatisticWithCallId:(NSString *)callid;
        //[Abstract]
        [Export("getNetworkStatisticWithCallId:")]
        NetworkStatistic GetNetworkStatisticWithCallId(string callid);
    }

    // @protocol ECVoIPCallManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(ECManagerBase))]
    interface ECVoIPCallManager //: ECManagerBase
    {
        // @required -(void)makeCallback:(ECCallBackEntity *)callBackEntity completion:(void (^)(ECError *, ECCallBackEntity *))completion;
        //[Abstract]
        [Export("makeCallback:completion:")]
        void MakeCallback(ECCallBackEntity callBackEntity, Action<ECError, ECCallBackEntity> completion);

        // @required -(NSString *)makeCallWithType:(CallType)callType andCalled:(NSString *)called;
        //[Abstract]
        [Export("makeCallWithType:andCalled:")]
        string MakeCallWithType(CallType callType, string called);

        // @required -(NSInteger)releaseCall:(NSString *)callid;
        //[Abstract]
        [Export("releaseCall:")]
        nint ReleaseCall(string callid);

        // @required -(NSInteger)releaseCall:(NSString *)callid andReason:(NSInteger)reason;
        //[Abstract]
        [Export("releaseCall:andReason:")]
        nint ReleaseCall(string callid, nint reason);

        // @required -(NSInteger)acceptCall:(NSString *)callid __attribute__((deprecated("")));
        //[Abstract]
        [Export("acceptCall:")]
        nint AcceptCall(string callid);

        // @required -(NSInteger)acceptCall:(NSString *)callid withType:(CallType)callType;
        //[Abstract]
        [Export("acceptCall:withType:")]
        nint AcceptCall(string callid, CallType callType);

        // @required -(NSInteger)rejectCall:(NSString *)callid andReason:(NSInteger)reason;
        //[Abstract]
        [Export("rejectCall:andReason:")]
        nint RejectCall(string callid, nint reason);

        // @required -(NSString *)getCurrentCall;
        //[Abstract]
        [Export("getCurrentCall")]
        //[Verify (MethodToProperty)]
        string CurrentCall { get; }

        // @required -(NSInteger)requestSwitchCallMediaType:(NSString *)callid toMediaType:(CallType)callType;
        //[Abstract]
        [Export("requestSwitchCallMediaType:toMediaType:")]
        nint RequestSwitchCallMediaType(string callid, CallType callType);

        // @required -(NSInteger)responseSwitchCallMediaType:(NSString *)callid withMediaType:(CallType)callType;
        //[Abstract]
        [Export("responseSwitchCallMediaType:withMediaType:")]
        nint ResponseSwitchCallMediaType(string callid, CallType callType);

        // @required -(NSInteger)sendDTMF:(NSString *)callid dtmf:(NSString *)dtmf;
        //[Abstract]
        [Export("sendDTMF:dtmf:")]
        nint SendDTMF(string callid, string dtmf);
    }

    // @protocol ECVoIPManager <ECVoIPCallManager, ECVoIPSetManager>
    [Protocol]
    [BaseType(typeof(ECVoIPCallManager))]
    interface ECVoIPManager : ECVoIPSetManager
    {
    }

    // @interface ECCreateMeetingParams : NSObject
    [BaseType(typeof(NSObject))]
    interface ECCreateMeetingParams
    {
        // @property (assign, nonatomic) ECMeetingType meetingType;
        [Export("meetingType", ArgumentSemantic.Assign)]
        ECMeetingType MeetingType { get; set; }

        // @property (assign, nonatomic) BOOL autoClose;
        [Export("autoClose")]
        bool AutoClose { get; set; }

        // @property (assign, nonatomic) BOOL autoDelete;
        [Export("autoDelete")]
        bool AutoDelete { get; set; }

        // @property (assign, nonatomic) BOOL autoJoin;
        [Export("autoJoin")]
        bool AutoJoin { get; set; }

        // @property (copy, nonatomic) NSString * keywords;
        [Export("keywords")]
        string Keywords { get; set; }

        // @property (copy, nonatomic) NSString * meetingName;
        [Export("meetingName")]
        string MeetingName { get; set; }

        // @property (copy, nonatomic) NSString * meetingPwd;
        [Export("meetingPwd")]
        string MeetingPwd { get; set; }

        // @property (assign, nonatomic) NSInteger square;
        [Export("square")]
        nint Square { get; set; }

        // @property (assign, nonatomic) NSInteger voiceMod;
        [Export("voiceMod")]
        nint VoiceMod { get; set; }
    }

    // @protocol ECMeetingManager <ECManagerBase>
    [Protocol]
    [BaseType(typeof(ECManagerBase))]
    interface ECMeetingManager //: ECManagerBase
    {
        // @required -(void)createMultMeetingByType:(ECCreateMeetingParams *)params completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("createMultMeetingByType:completion:")]
        void CreateMultMeetingByType(ECCreateMeetingParams @params1, Action<ECError, NSString> completion);

        // @required -(void)joinMeeting:(NSString *)meetingNumber ByMeetingType:(ECMeetingType)meetingType andMeetingPwd:(NSString *)meetingPwd completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("joinMeeting:ByMeetingType:andMeetingPwd:completion:")]
        void JoinMeeting(string meetingNumber, ECMeetingType meetingType, string meetingPwd, Action<ECError, NSString> completion);

        // @required -(void)inviteMembersJoinToVoiceMeeting:(NSString *)meetingNumber andIsLoandingCall:(BOOL)isLoadingCall andMembers:(NSArray *)members completion:(void (^)(ECError *, NSString *))completion __attribute__((deprecated("")));
        //[Abstract]
        [Export("inviteMembersJoinToVoiceMeeting:andIsLoandingCall:andMembers:completion:")]
        //[Verify (StronglyTypedNSArray)]
        void InviteMembersJoinToVoiceMeeting(string meetingNumber, bool isLoadingCall, NSObject[] members, Action<ECError, NSString> completion);

        // @required -(void)inviteMembersJoinMultiMediaMeeting:(NSString *)meetingNumber andIsLoandingCall:(BOOL)isLoadingCall andMembers:(NSArray *)members completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("inviteMembersJoinMultiMediaMeeting:andIsLoandingCall:andMembers:completion:")]
        //[Verify (StronglyTypedNSArray)]
        void InviteMembersJoinMultiMediaMeeting(string meetingNumber, bool isLoadingCall, NSObject[] members, Action<ECError, NSString> completion);

        // @required -(BOOL)exitMeeting;
        //[Abstract]
        [Export("exitMeeting")]
        //[Verify (MethodToProperty)]
        bool ExitMeeting { get; }

        // @required -(void)deleteMultMeetingByMeetingType:(ECMeetingType)multMeetingType andMeetingNumber:(NSString *)meetingNumber completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("deleteMultMeetingByMeetingType:andMeetingNumber:completion:")]
        void DeleteMultMeetingByMeetingType(ECMeetingType multMeetingType, string meetingNumber, Action<ECError, NSString> completion);

        // @required -(void)queryMeetingMembersByMeetingType:(ECMeetingType)meetingtype andMeetingNumber:(NSString *)meetingNumber completion:(void (^)(ECError *, NSArray *))completion;
        //[Abstract]
        [Export("queryMeetingMembersByMeetingType:andMeetingNumber:completion:")]
        void QueryMeetingMembersByMeetingType(ECMeetingType meetingtype, string meetingNumber, Action<ECError, NSArray> completion);

        // @required -(void)removeMemberFromMultMeetingByMeetingType:(ECMeetingType)multMeetingType andMeetingNumber:(NSString *)meetingNumber andMember:(ECVoIPAccount *)membervVoip completion:(void (^)(ECError *, ECVoIPAccount *))completion;
        //[Abstract]
        [Export("removeMemberFromMultMeetingByMeetingType:andMeetingNumber:andMember:completion:")]
        void RemoveMemberFromMultMeetingByMeetingType(ECMeetingType multMeetingType, string meetingNumber, ECVoIPAccount membervVoip, Action<ECError, ECVoIPAccount> completion);

        // @required -(void)listAllMultMeetingsByMeetingType:(ECMeetingType)multMeetingType andKeywords:(NSString *)keywords completion:(void (^)(ECError *, NSArray *))completion;
        //[Abstract]
        [Export("listAllMultMeetingsByMeetingType:andKeywords:completion:")]
        void ListAllMultMeetingsByMeetingType(ECMeetingType multMeetingType, string keywords, Action<ECError, NSArray> completion);

        // @required -(void)createInterphoneMeetingWithMembers:(NSArray *)members completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("createInterphoneMeetingWithMembers:completion:")]
        //[Verify (StronglyTypedNSArray)]
        void CreateInterphoneMeetingWithMembers(NSObject[] members, Action<ECError, NSString> completion);

        // @required -(void)controlMicInInterphoneMeeting:(NSString *)meetingNumber completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("controlMicInInterphoneMeeting:completion:")]
        void ControlMicInInterphoneMeeting(string meetingNumber, Action<ECError, NSString> completion);

        // @required -(void)releaseMicInInterphoneMeeting:(NSString *)meetingNumber completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("releaseMicInInterphoneMeeting:completion:")]
        void ReleaseMicInInterphoneMeeting(string meetingNumber, Action<ECError, NSString> completion);

        // @required -(void)publishSelfVideoFrameInVideoMeeting:(NSString *)meetingNumber completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("publishSelfVideoFrameInVideoMeeting:completion:")]
        void PublishSelfVideoFrameInVideoMeeting(string meetingNumber, Action<ECError, NSString> completion);

        // @required -(void)cancelPublishSelfVideoFrameInVideoMeeting:(NSString *)meetingNumber completion:(void (^)(ECError *, NSString *))completion;
        //[Abstract]
        [Export("cancelPublishSelfVideoFrameInVideoMeeting:completion:")]
        void CancelPublishSelfVideoFrameInVideoMeeting(string meetingNumber, Action<ECError, NSString> completion);

        // @required -(void)requestMemberVideoWithAccount:(NSString *)username andDisplayView:(UIView *)displayView andVideoMeeting:(NSString *)meetingNumber andPwd:(NSString *)meetingPwd andPort:(NSInteger)port completion:(void (^)(ECError *, NSString *, NSString *))completion;
        //[Abstract]
        [Export("requestMemberVideoWithAccount:andDisplayView:andVideoMeeting:andPwd:andPort:completion:")]
        void RequestMemberVideoWithAccount(string username, UIView displayView, string meetingNumber, string meetingPwd, nint port, Action<ECError, NSString, NSString> completion);

        // @required -(void)cancelMemberVideoWithAccount:(NSString *)username andVideoMeeting:(NSString *)meetingNumber andPwd:(NSString *)meetingPwd completion:(void (^)(ECError *, NSString *, NSString *))completion;
        //[Abstract]
        [Export("cancelMemberVideoWithAccount:andVideoMeeting:andPwd:completion:")]
        void CancelMemberVideoWithAccount(string username, string meetingNumber, string meetingPwd, Action<ECError, NSString, NSString> completion);

        // @required -(NSInteger)setVideoConferenceAddr:(NSString *)addr;
        //[Abstract]
        [Export("setVideoConferenceAddr:")]
        nint SetVideoConferenceAddr(string addr);
    }

    // @interface ECPersonInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ECPersonInfo
    {
        // @property (copy, nonatomic) NSString * userAcc;
        [Export("userAcc")]
        string UserAcc { get; set; }

        // @property (copy, nonatomic) NSString * nickName;
        [Export("nickName")]
        string NickName { get; set; }

        // @property (assign, nonatomic) ECSexType sex;
        [Export("sex", ArgumentSemantic.Assign)]
        ECSexType Sex { get; set; }

        // @property (copy, nonatomic) NSString * birth;
        [Export("birth")]
        string Birth { get; set; }

        // @property (copy, nonatomic) NSString * sign;
        [Export("sign")]
        string Sign { get; set; }

        // @property (assign, nonatomic) long long version;
        [Export("version")]
        long Version { get; set; }
    }

    // @interface ECTextMessageBody : ECMessageBody
    [BaseType(typeof(ECMessageBody))]
    interface ECTextMessageBody
    {
        // @property (nonatomic, strong) NSString * text;
        [Export("text", ArgumentSemantic.Strong)]
        string Text { get; set; }

        // @property (nonatomic, strong) NSString * serverTime;
        [Export("serverTime", ArgumentSemantic.Strong)]
        string ServerTime { get; set; }

        // -(instancetype)initWithText:(NSString *)text;
        [Export("initWithText:")]
        IntPtr Constructor(string text);
    }

    // @interface ECDevice : NSObject <UIApplicationDelegate>
    [BaseType(typeof(NSObject))]
    interface ECDevice : IUIApplicationDelegate
    {
        // +(ECDevice *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        //[Verify (MethodToProperty)]
        ECDevice SharedInstance { get; }

        // -(NSInteger)SwitchServerEvn:(BOOL)isSandBox;
        [Export("SwitchServerEvn:")]
        nint SwitchServerEvn(bool isSandBox);

        // -(void)login:(ECLoginInfo *)info completion:(void (^)(ECError *))completion;
        [Export("login:completion:")]
        void Login(ECLoginInfo info, Action<ECError> completion);

        // -(void)logout:(void (^)(ECError *))completion;
        [Export("logout:")]
        void Logout(Action<ECError> completion);

        // -(void)setPersonInfo:(ECPersonInfo *)person completion:(void (^)(ECError *, ECPersonInfo *))completion;
        [Export("setPersonInfo:completion:")]
        void SetPersonInfo(ECPersonInfo person, Action<ECError, ECPersonInfo> completion);

        // -(void)getPersonInfo:(void (^)(ECError *, ECPersonInfo *))completion;
        [Export("getPersonInfo:")]
        void GetPersonInfo(Action<ECError, ECPersonInfo> completion);

        // -(void)getOtherPersonInfoWith:(NSString *)userAcc completion:(void (^)(ECError *, ECPersonInfo *))completion;
        [Export("getOtherPersonInfoWith:completion:")]
        void GetOtherPersonInfoWith(string userAcc, Action<ECError, ECPersonInfo> completion);

        // -(void)setPrivateCloudCompanyId:(NSString *)companyid andCompanyPwd:(NSString *)companyPwd;
        [Export("setPrivateCloudCompanyId:andCompanyPwd:")]
        void SetPrivateCloudCompanyId(string companyid, string companyPwd);

        [Wrap("WeakDelegate")]
        ECDeviceDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ECDeviceDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) id<ECMessageManager> messageManager;
        [Export("messageManager", ArgumentSemantic.Strong)]
        ECMessageManager MessageManager { get; }

        //@property (readonly, nonatomic, strong)
        [Export("VoIPManager", ArgumentSemantic.Strong)]
        ECVoIPManager VoIPManager { get; }

        //@property (readonly, nonatomic, strong)
        [Export("meetingManager", ArgumentSemantic.Strong)]
        ECMeetingManager MeetingManager { get; }
    }
}


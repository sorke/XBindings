using System;
using CoreFoundation;
using CoreGraphics;
using CoreLocation;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XBindings.EaseMob
{
    // @protocol IChatManagerBase <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IChatManagerBase
    {
        // @required -(void)addDelegate:(id<EMChatManagerDelegate>)delegate delegateQueue:(dispatch_queue_t)queue;
        [Abstract]
        [Export("addDelegate:delegateQueue:")]
        void AddDelegate(EMChatManagerDelegate @delegate, DispatchQueue queue);

        // @required -(void)removeDelegate:(id<EMChatManagerDelegate>)delegate;
        [Abstract]
        [Export("removeDelegate:")]
        void RemoveDelegate(EMChatManagerDelegate @delegate);
    }

    // @protocol IChatManagerChat <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerChat : IIChatManagerBase
    {
        // @required -(EMMessage *)sendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError;
        [Abstract]
        [Export("sendMessage:progress:error:")]
        EMMessage SendMessage(EMMessage message, IEMChatProgressDelegate progress, out EMError pError);

        // @required -(EMMessage *)asyncSendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress;
        [Abstract]
        [Export("asyncSendMessage:progress:")]
        EMMessage AsyncSendMessage(EMMessage message, IEMChatProgressDelegate progress);

        // @required -(EMMessage *)asyncSendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress prepare:(void (^)(EMMessage *, EMError *))prepare onQueue:(dispatch_queue_t)aPrepareQueue completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aCompletionQueue;
        [Abstract]
        [Export("asyncSendMessage:progress:prepare:onQueue:completion:onQueue:")]
        EMMessage AsyncSendMessage(EMMessage message, IEMChatProgressDelegate progress, Action<EMMessage, EMError> prepare, DispatchQueue aPrepareQueue, Action<EMMessage, EMError> completion, DispatchQueue aCompletionQueue);

        // @required -(void)sendReadAckForMessage:(EMMessage *)message;
        [Abstract]
        [Export("sendReadAckForMessage:")]
        void SendReadAckForMessage(EMMessage message);

        // @required -(EMMessage *)resendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError;
        [Abstract]
        [Export("resendMessage:progress:error:")]
        EMMessage ResendMessage(EMMessage message, IEMChatProgressDelegate progress, out EMError pError);

        // @required -(EMMessage *)asyncResendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress;
        [Abstract]
        [Export("asyncResendMessage:progress:")]
        EMMessage AsyncResendMessage(EMMessage message, IEMChatProgressDelegate progress);

        // @required -(EMMessage *)asyncResendMessage:(EMMessage *)message progress:(id<IEMChatProgressDelegate>)progress prepare:(void (^)(EMMessage *, EMError *))prepare onQueue:(dispatch_queue_t)aPrepareQueue completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aCompletionQueue;
        [Abstract]
        [Export("asyncResendMessage:progress:prepare:onQueue:completion:onQueue:")]
        EMMessage AsyncResendMessage(EMMessage message, IEMChatProgressDelegate progress, Action<EMMessage, EMError> prepare, DispatchQueue aPrepareQueue, Action<EMMessage, EMError> completion, DispatchQueue aCompletionQueue);

        // @optional -(void)sendHasReadResponseForMessage:(EMMessage *)message __attribute__((deprecated("")));
        [Export("sendHasReadResponseForMessage:")]
        void SendHasReadResponseForMessage(EMMessage message);

        // @optional -(EMMessage *)forwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username isGroup:(BOOL)isGroup progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError __attribute__((deprecated("")));
        [Export("forwardMessage:ext:to:isGroup:progress:error:")]
        EMMessage ForwardMessage(EMMessage message, NSDictionary ext, string username, bool isGroup, IEMChatProgressDelegate progress, out EMError pError);

        // @optional -(EMMessage *)asyncForwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username isGroup:(BOOL)isGroup progress:(id<IEMChatProgressDelegate>)progress __attribute__((deprecated("")));
        [Export("asyncForwardMessage:ext:to:isGroup:progress:")]
        EMMessage AsyncForwardMessage(EMMessage message, NSDictionary ext, string username, bool isGroup, IEMChatProgressDelegate progress);

        // @optional -(EMMessage *)asyncForwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username isGroup:(BOOL)isGroup progress:(id<IEMChatProgressDelegate>)progress prepare:(void (^)(EMMessage *, EMError *))prepare onQueue:(dispatch_queue_t)aPrepareQueue completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aCompletionQueue __attribute__((deprecated("")));
        [Export("asyncForwardMessage:ext:to:isGroup:progress:prepare:onQueue:completion:onQueue:")]
        EMMessage AsyncForwardMessage(EMMessage message, NSDictionary ext, string username, bool isGroup, IEMChatProgressDelegate progress, Action<EMMessage, EMError> prepare, DispatchQueue aPrepareQueue, Action<EMMessage, EMError> completion, DispatchQueue aCompletionQueue);

        // @optional -(EMMessage *)forwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username messageType:(EMMessageType)type progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError __attribute__((deprecated("")));
        [Export("forwardMessage:ext:to:messageType:progress:error:")]
        EMMessage ForwardMessage(EMMessage message, NSDictionary ext, string username, EMMessageType type, IEMChatProgressDelegate progress, out EMError pError);

        // @optional -(EMMessage *)asyncForwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username messageType:(EMMessageType)type progress:(id<IEMChatProgressDelegate>)progress __attribute__((deprecated("")));
        [Export("asyncForwardMessage:ext:to:messageType:progress:")]
        EMMessage AsyncForwardMessage(EMMessage message, NSDictionary ext, string username, EMMessageType type, IEMChatProgressDelegate progress);

        // @optional -(EMMessage *)asyncForwardMessage:(EMMessage *)message ext:(NSDictionary *)ext to:(NSString *)username messageType:(EMMessageType)type progress:(id<IEMChatProgressDelegate>)progress prepare:(void (^)(EMMessage *, EMError *))prepare onQueue:(dispatch_queue_t)aPrepareQueue completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aCompletionQueue __attribute__((deprecated("")));
        [Export("asyncForwardMessage:ext:to:messageType:progress:prepare:onQueue:completion:onQueue:")]
        EMMessage AsyncForwardMessage(EMMessage message, NSDictionary ext, string username, EMMessageType type, IEMChatProgressDelegate progress, Action<EMMessage, EMError> prepare, DispatchQueue aPrepareQueue, Action<EMMessage, EMError> completion, DispatchQueue aCompletionQueue);
    }

    // @protocol IEMChatCryptor <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IEMChatCryptor
    {
        // @required -(NSData *)encryptData:(NSData *)data args:(id)aArgs;
        [Abstract]
        [Export("encryptData:args:")]
        NSData EncryptData(NSData data, NSObject aArgs);

        // @required -(NSData *)decryptData:(NSData *)data args:(id)aArgs;
        [Abstract]
        [Export("decryptData:args:")]
        NSData DecryptData(NSData data, NSObject aArgs);
    }

    // @protocol IChatManagerEncryption <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerEncryption : IIChatManagerBase
    {
        // @required @property (nonatomic, strong) id<IEMChatCryptor> chatCryptor;
        [Abstract]
        [Export("chatCryptor", ArgumentSemantic.Strong)]
        IEMChatCryptor ChatCryptor { get; set; }
    }

    // @protocol IChatManagerConversation <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerConversation : IIChatManagerBase
    {
        // @optional @property (readonly, nonatomic) NSArray * conversations;
        [Export("conversations")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Conversations { get; }

        // @optional -(EMConversation *)conversationForChatter:(NSString *)chatter conversationType:(EMConversationType)type;
        [Export("conversationForChatter:conversationType:")]
        EMConversation ConversationForChatter(string chatter, EMConversationType type);

        // @optional -(NSArray *)loadAllConversationsFromDatabaseWithAppend2Chat:(BOOL)append2Chat;
        [Export("loadAllConversationsFromDatabaseWithAppend2Chat:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllConversationsFromDatabaseWithAppend2Chat(bool append2Chat);

        // @optional -(BOOL)insertConversationToDB:(EMConversation *)conversation append2Chat:(BOOL)append2Chat;
        [Export("insertConversationToDB:append2Chat:")]
        bool InsertConversationToDB(EMConversation conversation, bool append2Chat);

        // @optional -(NSInteger)insertConversationsToDB:(NSArray *)conversations append2Chat:(BOOL)append2Chat;
        [Export("insertConversationsToDB:append2Chat:")]
        [Verify(StronglyTypedNSArray)]
        nint InsertConversationsToDB(NSObject[] conversations, bool append2Chat);

        // @optional -(BOOL)removeConversationByChatter:(NSString *)chatter deleteMessages:(BOOL)aDeleteMessages append2Chat:(BOOL)append2Chat;
        [Export("removeConversationByChatter:deleteMessages:append2Chat:")]
        bool RemoveConversationByChatter(string chatter, bool aDeleteMessages, bool append2Chat);

        // @optional -(NSUInteger)removeConversationsByChatters:(NSArray *)chatters deleteMessages:(BOOL)aDeleteMessages append2Chat:(BOOL)append2Chat;
        [Export("removeConversationsByChatters:deleteMessages:append2Chat:")]
        [Verify(StronglyTypedNSArray)]
        nuint RemoveConversationsByChatters(NSObject[] chatters, bool aDeleteMessages, bool append2Chat);

        // @optional -(BOOL)removeAllConversationsWithDeleteMessages:(BOOL)aDeleteMessages append2Chat:(BOOL)append2Chat;
        [Export("removeAllConversationsWithDeleteMessages:append2Chat:")]
        bool RemoveAllConversationsWithDeleteMessages(bool aDeleteMessages, bool append2Chat);

        // @optional -(NSUInteger)loadTotalUnreadMessagesCountFromDatabase;
        [Export("loadTotalUnreadMessagesCountFromDatabase")]
        [Verify(MethodToProperty)]
        nuint LoadTotalUnreadMessagesCountFromDatabase { get; }

        // @optional -(NSUInteger)unreadMessagesCountForConversation:(NSString *)chatter;
        [Export("unreadMessagesCountForConversation:")]
        nuint UnreadMessagesCountForConversation(string chatter);

        // @optional -(NSArray *)searchMessagesWithCriteria:(NSString *)criteria;
        [Export("searchMessagesWithCriteria:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] SearchMessagesWithCriteria(string criteria);

        // @optional -(NSArray *)searchMessagesWithCriteria:(NSString *)criteria withChatter:(NSString *)chatter;
        [Export("searchMessagesWithCriteria:withChatter:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] SearchMessagesWithCriteria(string criteria, string chatter);

        // @optional -(BOOL)insertMessageToDB:(EMMessage *)message;
        [Export("insertMessageToDB:")]
        bool InsertMessageToDB(EMMessage message);

        // @optional -(BOOL)insertMessageToDB:(EMMessage *)message append2Chat:(BOOL)append2Chat;
        [Export("insertMessageToDB:append2Chat:")]
        bool InsertMessageToDB(EMMessage message, bool append2Chat);

        // @optional -(NSInteger)insertMessagesToDB:(NSArray *)messages;
        [Export("insertMessagesToDB:")]
        [Verify(StronglyTypedNSArray)]
        nint InsertMessagesToDB(NSObject[] messages);

        // @optional -(BOOL)insertMessagesToDB:(NSArray *)messages forChatter:(NSString *)chatter append2Chat:(BOOL)append2Chat;
        [Export("insertMessagesToDB:forChatter:append2Chat:")]
        [Verify(StronglyTypedNSArray)]
        bool InsertMessagesToDB(NSObject[] messages, string chatter, bool append2Chat);

        // @optional -(EMConversation *)conversationForChatter:(NSString *)chatter isGroup:(BOOL)isGroup __attribute__((deprecated("")));
        [Export("conversationForChatter:isGroup:")]
        EMConversation ConversationForChatter(string chatter, bool isGroup);

        // @optional -(NSArray *)loadAllConversations __attribute__((deprecated("")));
        [Export("loadAllConversations")]
        [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllConversations { get; }

        // @optional -(NSArray *)loadAllConversationsFromDatabase __attribute__((deprecated("")));
        [Export("loadAllConversationsFromDatabase")]
        [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllConversationsFromDatabase { get; }

        // @optional -(NSInteger)saveAllConversations __attribute__((deprecated("")));
        [Export("saveAllConversations")]
        [Verify(MethodToProperty)]
        nint SaveAllConversations { get; }

        // @optional -(BOOL)removeConversationByChatter:(NSString *)chatter deleteMessages:(BOOL)aDeleteMessages __attribute__((deprecated("")));
        [Export("removeConversationByChatter:deleteMessages:")]
        bool RemoveConversationByChatter(string chatter, bool aDeleteMessages);

        // @optional -(NSUInteger)removeConversationsByChatters:(NSArray *)chatters deleteMessages:(BOOL)aDeleteMessages __attribute__((deprecated("")));
        [Export("removeConversationsByChatters:deleteMessages:")]
        [Verify(StronglyTypedNSArray)]
        nuint RemoveConversationsByChatters(NSObject[] chatters, bool aDeleteMessages);

        // @optional -(BOOL)removeAllConversationsWithDeleteMessages:(BOOL)aDeleteMessages __attribute__((deprecated("")));
        [Export("removeAllConversationsWithDeleteMessages:")]
        bool RemoveAllConversationsWithDeleteMessages(bool aDeleteMessages);

        // @optional -(NSUInteger)unreadConversationsCount __attribute__((deprecated("")));
        [Export("unreadConversationsCount")]
        [Verify(MethodToProperty)]
        nuint UnreadConversationsCount { get; }

        // @optional -(NSUInteger)totalUnreadMessagesCount __attribute__((deprecated("")));
        [Export("totalUnreadMessagesCount")]
        [Verify(MethodToProperty)]
        nuint TotalUnreadMessagesCount { get; }

        // @optional -(BOOL)saveMessage:(EMMessage *)message __attribute__((deprecated("")));
        [Export("saveMessage:")]
        bool SaveMessage(EMMessage message);

        // @optional -(BOOL)importMessage:(EMMessage *)message append2Chat:(BOOL)append2Chat __attribute__((deprecated("")));
        [Export("importMessage:append2Chat:")]
        bool ImportMessage(EMMessage message, bool append2Chat);

        // @optional -(NSInteger)saveMessages:(NSArray *)messages __attribute__((deprecated("")));
        [Export("saveMessages:")]
        [Verify(StronglyTypedNSArray)]
        nint SaveMessages(NSObject[] messages);
    }

    // @protocol IChatManagerUtil <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerUtil : IIChatManagerBase
    {
        // @required -(EMMessage *)fetchMessage:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError;
        [Abstract]
        [Export("fetchMessage:progress:error:")]
        EMMessage FetchMessage(EMMessage aMessage, IEMChatProgressDelegate progress, out EMError pError);

        // @required -(void)asyncFetchMessage:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress;
        [Abstract]
        [Export("asyncFetchMessage:progress:")]
        void AsyncFetchMessage(EMMessage aMessage, IEMChatProgressDelegate progress);

        // @required -(void)asyncFetchMessage:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchMessage:progress:completion:onQueue:")]
        void AsyncFetchMessage(EMMessage aMessage, IEMChatProgressDelegate progress, Action<EMMessage, EMError> completion, DispatchQueue aQueue);

        // @required -(EMMessage *)fetchMessageThumbnail:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress error:(EMError **)pError;
        [Abstract]
        [Export("fetchMessageThumbnail:progress:error:")]
        EMMessage FetchMessageThumbnail(EMMessage aMessage, IEMChatProgressDelegate progress, out EMError pError);

        // @required -(void)asyncFetchMessageThumbnail:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress;
        [Abstract]
        [Export("asyncFetchMessageThumbnail:progress:")]
        void AsyncFetchMessageThumbnail(EMMessage aMessage, IEMChatProgressDelegate progress);

        // @required -(void)asyncFetchMessageThumbnail:(EMMessage *)aMessage progress:(id<IEMChatProgressDelegate>)progress completion:(void (^)(EMMessage *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchMessageThumbnail:progress:completion:onQueue:")]
        void AsyncFetchMessageThumbnail(EMMessage aMessage, IEMChatProgressDelegate progress, Action<EMMessage, EMError> completion, DispatchQueue aQueue);
    }

    // @protocol IChatManagerLogin <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerLogin : IIChatManagerBase
    {
        // @required @property (readonly, nonatomic, strong) NSDictionary * loginInfo;
        [Export("loginInfo", ArgumentSemantic.Strong)]
        NSDictionary LoginInfo { get; }

        // @required @property (readonly, nonatomic) BOOL isLoggedIn;
        [Export("isLoggedIn")]
        bool IsLoggedIn { get; }

        // @required @property (readonly, nonatomic) BOOL isConnected;
        [Export("isConnected")]
        bool IsConnected { get; }

        // @required -(EMError *)importDataToNewDatabase;
        [Abstract]
        [Export("importDataToNewDatabase")]
        [Verify(MethodToProperty)]
        EMError ImportDataToNewDatabase { get; }

        // @required -(EMError *)loadDataFromDatabase;
        [Abstract]
        [Export("loadDataFromDatabase")]
        [Verify(MethodToProperty)]
        EMError LoadDataFromDatabase { get; }

        // @required -(BOOL)registerNewAccount:(NSString *)username password:(NSString *)password error:(EMError **)pError;
        [Abstract]
        [Export("registerNewAccount:password:error:")]
        bool RegisterNewAccount(string username, string password, out EMError pError);

        // @required -(void)asyncRegisterNewAccount:(NSString *)username password:(NSString *)password;
        [Abstract]
        [Export("asyncRegisterNewAccount:password:")]
        void AsyncRegisterNewAccount(string username, string password);

        // @required -(void)asyncRegisterNewAccount:(NSString *)username password:(NSString *)password withCompletion:(void (^)(NSString *, NSString *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncRegisterNewAccount:password:withCompletion:onQueue:")]
        void AsyncRegisterNewAccount(string username, string password, Action<NSString, NSString, EMError> completion, DispatchQueue aQueue);

        // @required -(NSDictionary *)loginWithUsername:(NSString *)username password:(NSString *)password error:(EMError **)pError;
        [Abstract]
        [Export("loginWithUsername:password:error:")]
        NSDictionary LoginWithUsername(string username, string password, out EMError pError);

        // @required -(void)asyncLoginWithUsername:(NSString *)username password:(NSString *)password;
        [Abstract]
        [Export("asyncLoginWithUsername:password:")]
        void AsyncLoginWithUsername(string username, string password);

        // @required -(void)asyncLoginWithUsername:(NSString *)username password:(NSString *)password completion:(void (^)(NSDictionary *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncLoginWithUsername:password:completion:onQueue:")]
        void AsyncLoginWithUsername(string username, string password, Action<NSDictionary, EMError> completion, DispatchQueue aQueue);

        // @required -(NSDictionary *)logoffWithUnbindDeviceToken:(BOOL)isUnbind error:(EMError **)pError;
        [Abstract]
        [Export("logoffWithUnbindDeviceToken:error:")]
        NSDictionary LogoffWithUnbindDeviceToken(bool isUnbind, out EMError pError);

        // @required -(void)asyncLogoffWithUnbindDeviceToken:(BOOL)isUnbind;
        [Abstract]
        [Export("asyncLogoffWithUnbindDeviceToken:")]
        void AsyncLogoffWithUnbindDeviceToken(bool isUnbind);

        // @required -(void)asyncLogoffWithUnbindDeviceToken:(BOOL)isUnbind completion:(void (^)(NSDictionary *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncLogoffWithUnbindDeviceToken:completion:onQueue:")]
        void AsyncLogoffWithUnbindDeviceToken(bool isUnbind, Action<NSDictionary, EMError> completion, DispatchQueue aQueue);

        // @optional -(NSDictionary *)logoffWithError:(EMError **)pError __attribute__((deprecated("")));
        [Export("logoffWithError:")]
        NSDictionary LogoffWithError(out EMError pError);

        // @optional -(void)asyncLogoff __attribute__((deprecated("")));
        [Export("asyncLogoff")]
        void AsyncLogoff();

        // @optional -(void)asyncLogoffWithCompletion:(void (^)(NSDictionary *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncLogoffWithCompletion:onQueue:")]
        void AsyncLogoffWithCompletion(Action<NSDictionary, EMError> completion, DispatchQueue aQueue);
    }

    // @protocol IChatManagerBuddy <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerBuddy : IIChatManagerBase
    {
        // @required @property (readonly, nonatomic, strong) NSArray * buddyList;
        [Abstract]
        [Export("buddyList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] BuddyList { get; }

        // @required @property (readonly, nonatomic, strong) NSArray * blockedList;
        [Abstract]
        [Export("blockedList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] BlockedList { get; }

        // @required -(NSArray *)fetchBuddyListWithError:(EMError **)pError;
        [Abstract]
        [Export("fetchBuddyListWithError:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchBuddyListWithError(out EMError pError);

        // @required -(void *)asyncFetchBuddyList;
        [Abstract]
        [Export("asyncFetchBuddyList")]
        [Verify(MethodToProperty)]
        unsafe void* AsyncFetchBuddyList { get; }

        // @required -(void *)asyncFetchBuddyListWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)queue;
        [Abstract]
        [Export("asyncFetchBuddyListWithCompletion:onQueue:")]
        unsafe void* AsyncFetchBuddyListWithCompletion(Action<NSArray, EMError> completion, DispatchQueue queue);

        // @required -(BOOL)addBuddy:(NSString *)username message:(NSString *)message error:(EMError **)pError;
        [Abstract]
        [Export("addBuddy:message:error:")]
        bool AddBuddy(string username, string message, out EMError pError);

        // @required -(BOOL)addBuddy:(NSString *)username message:(NSString *)message toGroups:(NSArray *)groupNames error:(EMError **)pError;
        [Abstract]
        [Export("addBuddy:message:toGroups:error:")]
        [Verify(StronglyTypedNSArray)]
        bool AddBuddy(string username, string message, NSObject[] groupNames, out EMError pError);

        // @required -(BOOL)removeBuddy:(NSString *)username removeFromRemote:(BOOL)removeFromRemote error:(EMError **)pError;
        [Abstract]
        [Export("removeBuddy:removeFromRemote:error:")]
        bool RemoveBuddy(string username, bool removeFromRemote, out EMError pError);

        // @required -(BOOL)acceptBuddyRequest:(NSString *)username error:(EMError **)pError;
        [Abstract]
        [Export("acceptBuddyRequest:error:")]
        bool AcceptBuddyRequest(string username, out EMError pError);

        // @required -(BOOL)rejectBuddyRequest:(NSString *)username reason:(NSString *)reason error:(EMError **)pError;
        [Abstract]
        [Export("rejectBuddyRequest:reason:error:")]
        bool RejectBuddyRequest(string username, string reason, out EMError pError);

        // @required -(NSArray *)fetchBlockedList:(EMError **)pError;
        [Abstract]
        [Export("fetchBlockedList:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchBlockedList(out EMError pError);

        // @required -(void)asyncFetchBlockedList;
        [Abstract]
        [Export("asyncFetchBlockedList")]
        void AsyncFetchBlockedList();

        // @required -(void)asyncFetchBlockedListWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchBlockedListWithCompletion:onQueue:")]
        void AsyncFetchBlockedListWithCompletion(Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @required -(EMError *)blockBuddy:(NSString *)username relationship:(EMRelationship)relationship;
        [Abstract]
        [Export("blockBuddy:relationship:")]
        EMError BlockBuddy(string username, EMRelationship relationship);

        // @required -(void)asyncBlockBuddy:(NSString *)username relationship:(EMRelationship)relationship;
        [Abstract]
        [Export("asyncBlockBuddy:relationship:")]
        void AsyncBlockBuddy(string username, EMRelationship relationship);

        // @required -(void)asyncBlockBuddy:(NSString *)username relationship:(EMRelationship)relationship withCompletion:(void (^)(NSString *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncBlockBuddy:relationship:withCompletion:onQueue:")]
        void AsyncBlockBuddy(string username, EMRelationship relationship, Action<NSString, EMError> completion, DispatchQueue aQueue);

        // @required -(EMError *)unblockBuddy:(NSString *)username;
        [Abstract]
        [Export("unblockBuddy:")]
        EMError UnblockBuddy(string username);

        // @required -(void)asyncUnblockBuddy:(NSString *)username;
        [Abstract]
        [Export("asyncUnblockBuddy:")]
        void AsyncUnblockBuddy(string username);

        // @required -(void)asyncUnblockBuddy:(NSString *)username withCompletion:(void (^)(NSString *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncUnblockBuddy:withCompletion:onQueue:")]
        void AsyncUnblockBuddy(string username, Action<NSString, EMError> completion, DispatchQueue aQueue);

        // @optional @property (readonly, nonatomic, strong) NSArray * buddyGroupList __attribute__((deprecated("")));
        [Export("buddyGroupList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] BuddyGroupList { get; }

        // @optional -(BOOL)addBuddy:(NSString *)username withNickname:(NSString *)nickname message:(NSString *)message error:(EMError **)pError __attribute__((deprecated("")));
        [Export("addBuddy:withNickname:message:error:")]
        bool AddBuddy(string username, string nickname, string message, out EMError pError);

        // @optional -(BOOL)addBuddy:(NSString *)username withNickname:(NSString *)nickname message:(NSString *)message toGroups:(NSArray *)groupNames error:(EMError **)pError __attribute__((deprecated("")));
        [Export("addBuddy:withNickname:message:toGroups:error:")]
        [Verify(StronglyTypedNSArray)]
        bool AddBuddy(string username, string nickname, string message, NSObject[] groupNames, out EMError pError);

        // @optional -(void)asyncFetchBlockListWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncFetchBlockListWithCompletion:onQueue:")]
        void AsyncFetchBlockListWithCompletion(Action<NSArray, EMError> completion, DispatchQueue aQueue);
    }

    // @protocol IChatManagerGroup <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerGroup : IIChatManagerBase
    {
        // @required @property (readonly, nonatomic, strong) NSArray * groupList;
        [Abstract]
        [Export("groupList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] GroupList { get; }

        // @required -(NSArray *)loadAllMyGroupsFromDatabaseWithAppend2Chat:(BOOL)append2Chat;
        [Abstract]
        [Export("loadAllMyGroupsFromDatabaseWithAppend2Chat:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllMyGroupsFromDatabaseWithAppend2Chat(bool append2Chat);

        // @required -(EMGroup *)createGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage styleSetting:(EMGroupStyleSetting *)styleSetting error:(EMError **)pError;
        [Abstract]
        [Export("createGroupWithSubject:description:invitees:initialWelcomeMessage:styleSetting:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup CreateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, EMGroupStyleSetting styleSetting, out EMError pError);

        // @required -(void)asyncCreateGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage styleSetting:(EMGroupStyleSetting *)styleSetting;
        [Abstract]
        [Export("asyncCreateGroupWithSubject:description:invitees:initialWelcomeMessage:styleSetting:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, EMGroupStyleSetting styleSetting);

        // @required -(void)asyncCreateGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage styleSetting:(EMGroupStyleSetting *)styleSetting completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncCreateGroupWithSubject:description:invitees:initialWelcomeMessage:styleSetting:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, EMGroupStyleSetting styleSetting, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)createAnonymousGroupWithSubject:(NSString *)subject description:(NSString *)description initialWelcomeMessage:(NSString *)welcomeMessage nickname:(NSString *)nickname styleSetting:(EMGroupStyleSetting *)styleSetting error:(EMError **)pError;
        [Abstract]
        [Export("createAnonymousGroupWithSubject:description:initialWelcomeMessage:nickname:styleSetting:error:")]
        EMGroup CreateAnonymousGroupWithSubject(string subject, string description, string welcomeMessage, string nickname, EMGroupStyleSetting styleSetting, out EMError pError);

        // @required -(void)asyncCreateAnonymousGroupWithSubject:(NSString *)subject description:(NSString *)description initialWelcomeMessage:(NSString *)welcomeMessage nickname:(NSString *)nickname styleSetting:(EMGroupStyleSetting *)styleSetting;
        [Abstract]
        [Export("asyncCreateAnonymousGroupWithSubject:description:initialWelcomeMessage:nickname:styleSetting:")]
        void AsyncCreateAnonymousGroupWithSubject(string subject, string description, string welcomeMessage, string nickname, EMGroupStyleSetting styleSetting);

        // @required -(void)asyncCreateAnonymousGroupWithSubject:(NSString *)subject description:(NSString *)description initialWelcomeMessage:(NSString *)welcomeMessage nickname:(NSString *)nickname styleSetting:(EMGroupStyleSetting *)styleSetting completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncCreateAnonymousGroupWithSubject:description:initialWelcomeMessage:nickname:styleSetting:completion:onQueue:")]
        void AsyncCreateAnonymousGroupWithSubject(string subject, string description, string welcomeMessage, string nickname, EMGroupStyleSetting styleSetting, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)joinAnonymousPublicGroup:(NSString *)groupId nickname:(NSString *)nickname error:(EMError **)pError;
        [Abstract]
        [Export("joinAnonymousPublicGroup:nickname:error:")]
        EMGroup JoinAnonymousPublicGroup(string groupId, string nickname, out EMError pError);

        // @required -(void)asyncJoinAnonymousPublicGroup:(NSString *)groupId nickname:(NSString *)nickname;
        [Abstract]
        [Export("asyncJoinAnonymousPublicGroup:nickname:")]
        void AsyncJoinAnonymousPublicGroup(string groupId, string nickname);

        // @required -(void)asyncJoinAnonymousPublicGroup:(NSString *)groupId nickname:(NSString *)nickname completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncJoinAnonymousPublicGroup:nickname:completion:onQueue:")]
        void AsyncJoinAnonymousPublicGroup(string groupId, string nickname, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)leaveGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("leaveGroup:error:")]
        EMGroup LeaveGroup(string groupId, out EMError pError);

        // @required -(void)asyncLeaveGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncLeaveGroup:")]
        void AsyncLeaveGroup(string groupId);

        // @required -(void)asyncLeaveGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMGroupLeaveReason, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncLeaveGroup:completion:onQueue:")]
        void AsyncLeaveGroup(string groupId, Action<EMGroup, EMGroupLeaveReason, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)destroyGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("destroyGroup:error:")]
        EMGroup DestroyGroup(string groupId, out EMError pError);

        // @required -(void)asyncDestroyGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncDestroyGroup:")]
        void AsyncDestroyGroup(string groupId);

        // @required -(void)asyncDestroyGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMGroupLeaveReason, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncDestroyGroup:completion:onQueue:")]
        void AsyncDestroyGroup(string groupId, Action<EMGroup, EMGroupLeaveReason, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)addOccupants:(NSArray *)occupants toGroup:(NSString *)groupId welcomeMessage:(NSString *)welcomeMessage error:(EMError **)pError;
        [Abstract]
        [Export("addOccupants:toGroup:welcomeMessage:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup AddOccupants(NSObject[] occupants, string groupId, string welcomeMessage, out EMError pError);

        // @required -(void)asyncAddOccupants:(NSArray *)occupants toGroup:(NSString *)groupId welcomeMessage:(NSString *)welcomeMessage;
        [Abstract]
        [Export("asyncAddOccupants:toGroup:welcomeMessage:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncAddOccupants(NSObject[] occupants, string groupId, string welcomeMessage);

        // @required -(void)asyncAddOccupants:(NSArray *)occupants toGroup:(NSString *)groupId welcomeMessage:(NSString *)welcomeMessage completion:(void (^)(NSArray *, EMGroup *, NSString *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncAddOccupants:toGroup:welcomeMessage:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncAddOccupants(NSObject[] occupants, string groupId, string welcomeMessage, Action<NSArray, EMGroup, NSString, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)removeOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("removeOccupants:fromGroup:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup RemoveOccupants(NSObject[] occupants, string groupId, out EMError pError);

        // @required -(void)asyncRemoveOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncRemoveOccupants:fromGroup:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncRemoveOccupants(NSObject[] occupants, string groupId);

        // @required -(void)asyncRemoveOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncRemoveOccupants:fromGroup:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncRemoveOccupants(NSObject[] occupants, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)blockOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("blockOccupants:fromGroup:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup BlockOccupants(NSObject[] occupants, string groupId, out EMError pError);

        // @required -(void)asyncBlockOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncBlockOccupants:fromGroup:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncBlockOccupants(NSObject[] occupants, string groupId);

        // @required -(void)asyncBlockOccupants:(NSArray *)occupants fromGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncBlockOccupants:fromGroup:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncBlockOccupants(NSObject[] occupants, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)unblockOccupants:(NSArray *)occupants forGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("unblockOccupants:forGroup:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup UnblockOccupants(NSObject[] occupants, string groupId, out EMError pError);

        // @required -(void)asyncUnblockOccupants:(NSArray *)occupants forGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncUnblockOccupants:forGroup:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncUnblockOccupants(NSObject[] occupants, string groupId);

        // @required -(void)asyncUnblockOccupants:(NSArray *)occupants forGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncUnblockOccupants:forGroup:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncUnblockOccupants(NSObject[] occupants, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)changeGroupSubject:(NSString *)subject forGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("changeGroupSubject:forGroup:error:")]
        EMGroup ChangeGroupSubject(string subject, string groupId, out EMError pError);

        // @required -(void)asyncChangeGroupSubject:(NSString *)subject forGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncChangeGroupSubject:forGroup:")]
        void AsyncChangeGroupSubject(string subject, string groupId);

        // @required -(void)asyncChangeGroupSubject:(NSString *)subject forGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncChangeGroupSubject:forGroup:completion:onQueue:")]
        void AsyncChangeGroupSubject(string subject, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)changeDescription:(NSString *)newDescription forGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("changeDescription:forGroup:error:")]
        EMGroup ChangeDescription(string newDescription, string groupId, out EMError pError);

        // @required -(void)asyncChangeDescription:(NSString *)newDescription forGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncChangeDescription:forGroup:")]
        void AsyncChangeDescription(string newDescription, string groupId);

        // @required -(void)asyncChangeDescription:(NSString *)newDescription forGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncChangeDescription:forGroup:completion:onQueue:")]
        void AsyncChangeDescription(string newDescription, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(void)acceptApplyJoinGroup:(NSString *)groupId groupname:(NSString *)groupname applicant:(NSString *)username error:(EMError **)pError;
        [Abstract]
        [Export("acceptApplyJoinGroup:groupname:applicant:error:")]
        void AcceptApplyJoinGroup(string groupId, string groupname, string username, out EMError pError);

        // @required -(void)asyncAcceptApplyJoinGroup:(NSString *)groupId groupname:(NSString *)groupname applicant:(NSString *)username;
        [Abstract]
        [Export("asyncAcceptApplyJoinGroup:groupname:applicant:")]
        void AsyncAcceptApplyJoinGroup(string groupId, string groupname, string username);

        // @required -(void)asyncAcceptApplyJoinGroup:(NSString *)groupId groupname:(NSString *)groupname applicant:(NSString *)username completion:(void (^)(EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncAcceptApplyJoinGroup:groupname:applicant:completion:onQueue:")]
        void AsyncAcceptApplyJoinGroup(string groupId, string groupname, string username, Action<EMError> completion, DispatchQueue aQueue);

        // @required -(void)rejectApplyJoinGroup:(NSString *)groupId groupname:(NSString *)groupname toApplicant:(NSString *)username reason:(NSString *)reason;
        [Abstract]
        [Export("rejectApplyJoinGroup:groupname:toApplicant:reason:")]
        void RejectApplyJoinGroup(string groupId, string groupname, string username, string reason);

        // @required -(EMGroup *)fetchGroupInfo:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("fetchGroupInfo:error:")]
        EMGroup FetchGroupInfo(string groupId, out EMError pError);

        // @required -(void)asyncFetchGroupInfo:(NSString *)groupId;
        [Abstract]
        [Export("asyncFetchGroupInfo:")]
        void AsyncFetchGroupInfo(string groupId);

        // @required -(void)asyncFetchGroupInfo:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchGroupInfo:completion:onQueue:")]
        void AsyncFetchGroupInfo(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(NSArray *)fetchOccupantList:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("fetchOccupantList:error:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchOccupantList(string groupId, out EMError pError);

        // @required -(void)asyncFetchOccupantList:(NSString *)groupId;
        [Abstract]
        [Export("asyncFetchOccupantList:")]
        void AsyncFetchOccupantList(string groupId);

        // @required -(void)asyncFetchOccupantList:(NSString *)groupId completion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchOccupantList:completion:onQueue:")]
        void AsyncFetchOccupantList(string groupId, Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)fetchGroupInfo:(NSString *)groupId includesOccupantList:(BOOL)includesOccupantList error:(EMError **)pError;
        [Abstract]
        [Export("fetchGroupInfo:includesOccupantList:error:")]
        EMGroup FetchGroupInfo(string groupId, bool includesOccupantList, out EMError pError);

        // @required -(void)asyncFetchGroupInfo:(NSString *)groupId includesOccupantList:(BOOL)includesOccupantList;
        [Abstract]
        [Export("asyncFetchGroupInfo:includesOccupantList:")]
        void AsyncFetchGroupInfo(string groupId, bool includesOccupantList);

        // @required -(void)asyncFetchGroupInfo:(NSString *)groupId includesOccupantList:(BOOL)includesOccupantList completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchGroupInfo:includesOccupantList:completion:onQueue:")]
        void AsyncFetchGroupInfo(string groupId, bool includesOccupantList, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(NSArray *)fetchGroupBansList:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("fetchGroupBansList:error:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchGroupBansList(string groupId, out EMError pError);

        // @required -(void)asyncFetchGroupBansList:(NSString *)groupId;
        [Abstract]
        [Export("asyncFetchGroupBansList:")]
        void AsyncFetchGroupBansList(string groupId);

        // @required -(void)asyncFetchGroupBansList:(NSString *)groupId completion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchGroupBansList:completion:onQueue:")]
        void AsyncFetchGroupBansList(string groupId, Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @required -(NSArray *)fetchMyGroupsListWithError:(EMError **)pError;
        [Abstract]
        [Export("fetchMyGroupsListWithError:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchMyGroupsListWithError(out EMError pError);

        // @required -(void)asyncFetchMyGroupsList;
        [Abstract]
        [Export("asyncFetchMyGroupsList")]
        void AsyncFetchMyGroupsList();

        // @required -(void)asyncFetchMyGroupsListWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchMyGroupsListWithCompletion:onQueue:")]
        void AsyncFetchMyGroupsListWithCompletion(Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @required -(NSArray *)fetchAllPublicGroupsWithError:(EMError **)pError;
        [Abstract]
        [Export("fetchAllPublicGroupsWithError:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchAllPublicGroupsWithError(out EMError pError);

        // @required -(void)asyncFetchAllPublicGroups;
        [Abstract]
        [Export("asyncFetchAllPublicGroups")]
        void AsyncFetchAllPublicGroups();

        // @required -(void)asyncFetchAllPublicGroupsWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncFetchAllPublicGroupsWithCompletion:onQueue:")]
        void AsyncFetchAllPublicGroupsWithCompletion(Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @required -(EMCursorResult *)fetchPublicGroupsFromServerWithCursor:(NSString *)cursor pageSize:(NSInteger)pageSize andError:(EMError **)pError;
        [Abstract]
        [Export("fetchPublicGroupsFromServerWithCursor:pageSize:andError:")]
        EMCursorResult FetchPublicGroupsFromServerWithCursor(string cursor, nint pageSize, out EMError pError);

        // @required -(void)asyncFetchPublicGroupsFromServerWithCursor:(NSString *)cursor pageSize:(NSInteger)pageSize andCompletion:(void (^)(EMCursorResult *, EMError *))completion;
        [Abstract]
        [Export("asyncFetchPublicGroupsFromServerWithCursor:pageSize:andCompletion:")]
        void AsyncFetchPublicGroupsFromServerWithCursor(string cursor, nint pageSize, Action<EMCursorResult, EMError> completion);

        // @required -(EMGroup *)joinPublicGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("joinPublicGroup:error:")]
        EMGroup JoinPublicGroup(string groupId, out EMError pError);

        // @required -(void)asyncJoinPublicGroup:(NSString *)groupId;
        [Abstract]
        [Export("asyncJoinPublicGroup:")]
        void AsyncJoinPublicGroup(string groupId);

        // @required -(void)asyncJoinPublicGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncJoinPublicGroup:completion:onQueue:")]
        void AsyncJoinPublicGroup(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)applyJoinPublicGroup:(NSString *)groupId withGroupname:(NSString *)groupName message:(NSString *)message error:(EMError **)pError;
        [Abstract]
        [Export("applyJoinPublicGroup:withGroupname:message:error:")]
        EMGroup ApplyJoinPublicGroup(string groupId, string groupName, string message, out EMError pError);

        // @required -(void)asyncApplyJoinPublicGroup:(NSString *)groupId withGroupname:(NSString *)groupName message:(NSString *)message;
        [Abstract]
        [Export("asyncApplyJoinPublicGroup:withGroupname:message:")]
        void AsyncApplyJoinPublicGroup(string groupId, string groupName, string message);

        // @required -(void)asyncApplyJoinPublicGroup:(NSString *)groupId withGroupname:(NSString *)groupName message:(NSString *)message completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncApplyJoinPublicGroup:withGroupname:message:completion:onQueue:")]
        void AsyncApplyJoinPublicGroup(string groupId, string groupName, string message, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)searchPublicGroupWithGroupId:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("searchPublicGroupWithGroupId:error:")]
        EMGroup SearchPublicGroupWithGroupId(string groupId, out EMError pError);

        // @required -(void)asyncSearchPublicGroupWithGroupId:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncSearchPublicGroupWithGroupId:completion:onQueue:")]
        void AsyncSearchPublicGroupWithGroupId(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)blockGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("blockGroup:error:")]
        EMGroup BlockGroup(string groupId, out EMError pError);

        // @required -(void)asyncBlockGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncBlockGroup:completion:onQueue:")]
        void AsyncBlockGroup(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @required -(EMGroup *)unblockGroup:(NSString *)groupId error:(EMError **)pError;
        [Abstract]
        [Export("unblockGroup:error:")]
        EMGroup UnblockGroup(string groupId, out EMError pError);

        // @required -(void)asyncUnblockGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncUnblockGroup:completion:onQueue:")]
        void AsyncUnblockGroup(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(NSArray *)loadAllMyGroupsFromDatabase __attribute__((deprecated("")));
        [Export("loadAllMyGroupsFromDatabase")]
        [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllMyGroupsFromDatabase { get; }

        // @optional -(EMGroup *)createPrivateGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage error:(EMError **)pError __attribute__((deprecated("")));
        [Export("createPrivateGroupWithSubject:description:invitees:initialWelcomeMessage:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup CreatePrivateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, out EMError pError);

        // @optional -(void)asyncCreatePrivateGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage __attribute__((deprecated("")));
        [Export("asyncCreatePrivateGroupWithSubject:description:invitees:initialWelcomeMessage:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreatePrivateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage);

        // @optional -(void)asyncCreatePrivateGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncCreatePrivateGroupWithSubject:description:invitees:initialWelcomeMessage:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreatePrivateGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(EMGroup *)createPublicGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage error:(EMError **)pError __attribute__((deprecated("")));
        [Export("createPublicGroupWithSubject:description:invitees:initialWelcomeMessage:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup CreatePublicGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, out EMError pError);

        // @optional -(void)asyncCreatePublicGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage __attribute__((deprecated("")));
        [Export("asyncCreatePublicGroupWithSubject:description:invitees:initialWelcomeMessage:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreatePublicGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage);

        // @optional -(void)asyncCreatePublicGroupWithSubject:(NSString *)subject description:(NSString *)description invitees:(NSArray *)invitees initialWelcomeMessage:(NSString *)welcomeMessage completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncCreatePublicGroupWithSubject:description:invitees:initialWelcomeMessage:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncCreatePublicGroupWithSubject(string subject, string description, NSObject[] invitees, string welcomeMessage, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(EMGroup *)changePassword:(NSString *)newPassword forGroup:(NSString *)groupId error:(EMError **)pError __attribute__((deprecated("")));
        [Export("changePassword:forGroup:error:")]
        EMGroup ChangePassword(string newPassword, string groupId, out EMError pError);

        // @optional -(void)asyncChangePassword:(NSString *)newPassword forGroup:(NSString *)groupId __attribute__((deprecated("")));
        [Export("asyncChangePassword:forGroup:")]
        void AsyncChangePassword(string newPassword, string groupId);

        // @optional -(void)asyncChangePassword:(NSString *)newPassword forGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncChangePassword:forGroup:completion:onQueue:")]
        void AsyncChangePassword(string newPassword, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(EMGroup *)changeAffiliation:(EMGroupMemberRole)newAffiliation forOccupants:(NSArray *)occupants inGroup:(NSString *)groupId error:(EMError **)pError __attribute__((deprecated("")));
        [Export("changeAffiliation:forOccupants:inGroup:error:")]
        [Verify(StronglyTypedNSArray)]
        EMGroup ChangeAffiliation(EMGroupMemberRole newAffiliation, NSObject[] occupants, string groupId, out EMError pError);

        // @optional -(void)asyncChangeAffiliation:(EMGroupMemberRole)newAffiliation forOccupants:(NSArray *)occupants inGroup:(NSString *)groupId __attribute__((deprecated("")));
        [Export("asyncChangeAffiliation:forOccupants:inGroup:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncChangeAffiliation(EMGroupMemberRole newAffiliation, NSObject[] occupants, string groupId);

        // @optional -(void)asyncChangeAffiliation:(EMGroupMemberRole)newAffiliation forOccupants:(NSArray *)occupants inGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncChangeAffiliation:forOccupants:inGroup:completion:onQueue:")]
        [Verify(StronglyTypedNSArray)]
        void AsyncChangeAffiliation(EMGroupMemberRole newAffiliation, NSObject[] occupants, string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(NSArray *)fetchAllPrivateGroupsWithError:(EMError **)pError __attribute__((deprecated("")));
        [Export("fetchAllPrivateGroupsWithError:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchAllPrivateGroupsWithError(out EMError pError);

        // @optional -(void)asyncFetchAllPrivateGroups __attribute__((deprecated("")));
        [Export("asyncFetchAllPrivateGroups")]
        void AsyncFetchAllPrivateGroups();

        // @optional -(void)asyncFetchAllPrivateGroupsWithCompletion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncFetchAllPrivateGroupsWithCompletion:onQueue:")]
        void AsyncFetchAllPrivateGroupsWithCompletion(Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @optional -(EMGroup *)acceptInvitationFromGroup:(NSString *)groupId error:(EMError **)pError __attribute__((deprecated("")));
        [Export("acceptInvitationFromGroup:error:")]
        EMGroup AcceptInvitationFromGroup(string groupId, out EMError pError);

        // @optional -(void)asyncAcceptInvitationFromGroup:(NSString *)groupId __attribute__((deprecated("")));
        [Export("asyncAcceptInvitationFromGroup:")]
        void AsyncAcceptInvitationFromGroup(string groupId);

        // @optional -(void)asyncAcceptInvitationFromGroup:(NSString *)groupId completion:(void (^)(EMGroup *, EMError *))completion onQueue:(dispatch_queue_t)aQueue __attribute__((deprecated("")));
        [Export("asyncAcceptInvitationFromGroup:completion:onQueue:")]
        void AsyncAcceptInvitationFromGroup(string groupId, Action<EMGroup, EMError> completion, DispatchQueue aQueue);

        // @optional -(void)rejectInvitationForGroup:(NSString *)groupId toInviter:(NSString *)username reason:(NSString *)reason __attribute__((deprecated("")));
        [Export("rejectInvitationForGroup:toInviter:reason:")]
        void RejectInvitationForGroup(string groupId, string username, string reason);
    }

    // @protocol IChatManagerSettingOptions <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerSettingOptions : IIChatManagerBase
    {
        // @optional @property (nonatomic, strong) NSString * apnsNickname;
        [Export("apnsNickname", ArgumentSemantic.Strong)]
        string ApnsNickname { get; set; }

        // @optional @property (nonatomic) BOOL isAutoLoginEnabled;
        [Export("isAutoLoginEnabled")]
        bool IsAutoLoginEnabled { get; set; }

        // @optional -(void)enableAutoLogin;
        [Export("enableAutoLogin")]
        void EnableAutoLogin();

        // @optional -(void)disableAutoLogin;
        [Export("disableAutoLogin")]
        void DisableAutoLogin();

        // @optional @property (nonatomic) BOOL isAutoFetchBuddyList;
        [Export("isAutoFetchBuddyList")]
        bool IsAutoFetchBuddyList { get; set; }

        // @optional -(void)enableAutoFetchBuddyList;
        [Export("enableAutoFetchBuddyList")]
        void EnableAutoFetchBuddyList();

        // @optional -(void)disableAutoFetchBuddyList;
        [Export("disableAutoFetchBuddyList")]
        void DisableAutoFetchBuddyList();

        // @optional @property (nonatomic) BOOL isUseIp;
        [Export("isUseIp")]
        bool IsUseIp { get; set; }

        // @optional -(void)enableUseIp;
        [Export("enableUseIp")]
        void EnableUseIp();

        // @optional -(void)disableUseIp;
        [Export("disableUseIp")]
        void DisableUseIp();

        // @optional -(void)enableDeliveryNotification;
        [Export("enableDeliveryNotification")]
        void EnableDeliveryNotification();

        // @optional -(void)disableDeliveryNotification;
        [Export("disableDeliveryNotification")]
        void DisableDeliveryNotification();

        // @optional @property (nonatomic) BOOL isAutoDeleteConversationWhenLeaveGroup;
        [Export("isAutoDeleteConversationWhenLeaveGroup")]
        bool IsAutoDeleteConversationWhenLeaveGroup { get; set; }

        // @optional -(void)enableAutoDeleteConversatonWhenLeaveGroup;
        [Export("enableAutoDeleteConversatonWhenLeaveGroup")]
        void EnableAutoDeleteConversatonWhenLeaveGroup();

        // @optional -(void)disableAutoDeleteConversatonWhenLeaveGroup;
        [Export("disableAutoDeleteConversatonWhenLeaveGroup")]
        void DisableAutoDeleteConversatonWhenLeaveGroup();

        // @optional @property (nonatomic, strong) NSString * nickname __attribute__((deprecated("")));
        [Export("nickname", ArgumentSemantic.Strong)]
        string Nickname { get; set; }

        // @optional @property (nonatomic) BOOL autoFetchBuddyList __attribute__((deprecated("")));
        [Export("autoFetchBuddyList")]
        bool AutoFetchBuddyList { get; set; }
    }

    // @protocol IChatManagerPushNotification <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerPushNotification : IIChatManagerBase
    {
        // @required @property (readonly, nonatomic, strong) EMPushNotificationOptions * pushNotificationOptions;
        [Abstract]
        [Export("pushNotificationOptions", ArgumentSemantic.Strong)]
        EMPushNotificationOptions PushNotificationOptions { get; }

        // @required @property (readonly, nonatomic, strong) NSArray * ignoredGroupIds;
        [Abstract]
        [Export("ignoredGroupIds", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] IgnoredGroupIds { get; }

        // @required -(EMPushNotificationOptions *)updatePushOptions:(EMPushNotificationOptions *)options error:(EMError **)pError;
        [Abstract]
        [Export("updatePushOptions:error:")]
        EMPushNotificationOptions UpdatePushOptions(EMPushNotificationOptions options, out EMError pError);

        // @required -(void)asyncUpdatePushOptions:(EMPushNotificationOptions *)options;
        [Abstract]
        [Export("asyncUpdatePushOptions:")]
        void AsyncUpdatePushOptions(EMPushNotificationOptions options);

        // @required -(void)asyncUpdatePushOptions:(EMPushNotificationOptions *)options completion:(void (^)(EMPushNotificationOptions *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncUpdatePushOptions:completion:onQueue:")]
        void AsyncUpdatePushOptions(EMPushNotificationOptions options, Action<EMPushNotificationOptions, EMError> completion, DispatchQueue aQueue);

        // @required -(NSArray *)ignoreGroupPushNotification:(NSString *)groupId ignore:(BOOL)ignore error:(EMError **)pError;
        [Abstract]
        [Export("ignoreGroupPushNotification:ignore:error:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] IgnoreGroupPushNotification(string groupId, bool ignore, out EMError pError);

        // @required -(void)asyncIgnoreGroupPushNotification:(NSString *)groupId isIgnore:(BOOL)isIgnore;
        [Abstract]
        [Export("asyncIgnoreGroupPushNotification:isIgnore:")]
        void AsyncIgnoreGroupPushNotification(string groupId, bool isIgnore);

        // @required -(void)asyncIgnoreGroupPushNotification:(NSString *)groupId isIgnore:(BOOL)isIgnore completion:(void (^)(NSArray *, EMError *))completion onQueue:(dispatch_queue_t)aQueue;
        [Abstract]
        [Export("asyncIgnoreGroupPushNotification:isIgnore:completion:onQueue:")]
        void AsyncIgnoreGroupPushNotification(string groupId, bool isIgnore, Action<NSArray, EMError> completion, DispatchQueue aQueue);

        // @optional @property (readonly, nonatomic, strong) NSArray * ignoredGroupList __attribute__((deprecated("")));
        [Export("ignoredGroupList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] IgnoredGroupList { get; }
    }

    // @interface EMChatroom : NSObject
    [BaseType(typeof(NSObject))]
    interface EMChatroom
    {
        // @property (readonly, nonatomic, strong) NSString * chatroomId;
        [Export("chatroomId", ArgumentSemantic.Strong)]
        string ChatroomId { get; }

        // @property (readonly, nonatomic, strong) NSString * chatroomSubject;
        [Export("chatroomSubject", ArgumentSemantic.Strong)]
        string ChatroomSubject { get; }

        // @property (readonly, nonatomic, strong) NSString * chatroomDescription;
        [Export("chatroomDescription", ArgumentSemantic.Strong)]
        string ChatroomDescription { get; }

        // @property (readonly, nonatomic) NSInteger chatroomMaxOccupantsCount;
        [Export("chatroomMaxOccupantsCount")]
        nint ChatroomMaxOccupantsCount { get; }

        // +(instancetype)chatroomWithId:(NSString *)chatroomId;
        [Static]
        [Export("chatroomWithId:")]
        EMChatroom ChatroomWithId(string chatroomId);
    }

    // @protocol IChatManagerChatroom <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerChatroom : IIChatManagerBase
    {
        // @required -(EMCursorResult *)fetchChatroomsFromServerWithCursor:(NSString *)cursor pageSize:(NSInteger)pageSize andError:(EMError **)pError;
        [Abstract]
        [Export("fetchChatroomsFromServerWithCursor:pageSize:andError:")]
        EMCursorResult FetchChatroomsFromServerWithCursor(string cursor, nint pageSize, out EMError pError);

        // @required -(void)asyncFetchChatroomsFromServerWithCursor:(NSString *)cursor pageSize:(NSInteger)pageSize andCompletion:(void (^)(EMCursorResult *, EMError *))completion;
        [Abstract]
        [Export("asyncFetchChatroomsFromServerWithCursor:pageSize:andCompletion:")]
        void AsyncFetchChatroomsFromServerWithCursor(string cursor, nint pageSize, Action<EMCursorResult, EMError> completion);

        // @required -(EMChatroom *)fetchChatroomInfo:(NSString *)chatroomId error:(EMError **)pError;
        [Abstract]
        [Export("fetchChatroomInfo:error:")]
        EMChatroom FetchChatroomInfo(string chatroomId, out EMError pError);

        // @required -(void)asyncFetchChatroomInfo:(NSString *)chatroomId completion:(void (^)(EMChatroom *, EMError *))completion;
        [Abstract]
        [Export("asyncFetchChatroomInfo:completion:")]
        void AsyncFetchChatroomInfo(string chatroomId, Action<EMChatroom, EMError> completion);

        // @required -(EMCursorResult *)fetchOccupantsForChatroom:(NSString *)chatroomId cursor:(NSString *)cursor pageSize:(NSInteger)pageSize andError:(EMError **)pError;
        [Abstract]
        [Export("fetchOccupantsForChatroom:cursor:pageSize:andError:")]
        EMCursorResult FetchOccupantsForChatroom(string chatroomId, string cursor, nint pageSize, out EMError pError);

        // @required -(void)asyncFetchOccupantsForChatroom:(NSString *)chatroomId cursor:(NSString *)cursor pageSize:(NSInteger)pageSize completion:(void (^)(EMCursorResult *, EMError *))completion;
        [Abstract]
        [Export("asyncFetchOccupantsForChatroom:cursor:pageSize:completion:")]
        void AsyncFetchOccupantsForChatroom(string chatroomId, string cursor, nint pageSize, Action<EMCursorResult, EMError> completion);

        // @required -(EMChatroom *)joinChatroom:(NSString *)chatroomId error:(EMError **)pError;
        [Abstract]
        [Export("joinChatroom:error:")]
        EMChatroom JoinChatroom(string chatroomId, out EMError pError);

        // @required -(void)asyncJoinChatroom:(NSString *)chatroomId completion:(void (^)(EMChatroom *, EMError *))completion;
        [Abstract]
        [Export("asyncJoinChatroom:completion:")]
        void AsyncJoinChatroom(string chatroomId, Action<EMChatroom, EMError> completion);

        // @required -(EMChatroom *)leaveChatroom:(NSString *)chatroomId error:(EMError **)pError;
        [Abstract]
        [Export("leaveChatroom:error:")]
        EMChatroom LeaveChatroom(string chatroomId, out EMError pError);

        // @required -(void)asyncLeaveChatroom:(NSString *)chatroomId completion:(void (^)(EMChatroom *, EMError *))completion;
        [Abstract]
        [Export("asyncLeaveChatroom:completion:")]
        void AsyncLeaveChatroom(string chatroomId, Action<EMChatroom, EMError> completion);
    }

    // @protocol IChatManagerRobot <IChatManagerBase>
    [Protocol, Model]
    interface IChatManagerRobot : IIChatManagerBase
    {
        // @required @property (readonly, nonatomic, strong) NSArray * robotList;
        [Abstract]
        [Export("robotList", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] RobotList { get; }

        // @required -(NSArray *)fetchRobotsFromServerWithError:(EMError **)pError;
        [Abstract]
        [Export("fetchRobotsFromServerWithError:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] FetchRobotsFromServerWithError(out EMError pError);

        // @required -(void)asyncFetchRobotsFromServerWithCompletion:(void (^)(NSArray *, EMError *))completion;
        [Abstract]
        [Export("asyncFetchRobotsFromServerWithCompletion:")]
        void AsyncFetchRobotsFromServerWithCompletion(Action<NSArray, EMError> completion);
    }

    // @protocol IChatManager <IChatManagerChat, IChatManagerLogin, IChatManagerConversation, IChatManagerEncryption, IChatManagerUtil, IChatManagerGroup, IChatManagerBuddy, IChatManagerSettingOptions, IChatManagerPushNotification, IChatManagerChatroom, IChatManagerRobot>
    [Protocol, Model]
    interface IChatManager : IIChatManagerChat, IIChatManagerLogin, IIChatManagerConversation, IIChatManagerEncryption, IIChatManagerUtil, IIChatManagerGroup, IIChatManagerBuddy, IIChatManagerSettingOptions, IIChatManagerPushNotification, IIChatManagerChatroom, IIChatManagerRobot
    {
    }

    // @protocol IDeviceManager
    [Protocol, Model]
    interface IDeviceManager
    {
    }

    // @protocol EMChatManagerDelegateBase <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface EMChatManagerDelegateBase
    {
    }

    // @protocol EMChatManagerChatDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerChatDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)willSendMessage:(EMMessage *)message error:(EMError *)error;
        [Export("willSendMessage:error:")]
        void WillSendMessage(EMMessage message, EMError error);

        // @optional -(void)didSendMessage:(EMMessage *)message error:(EMError *)error;
        [Export("didSendMessage:error:")]
        void DidSendMessage(EMMessage message, EMError error);

        // @optional -(void)didReceiveMessage:(EMMessage *)message;
        [Export("didReceiveMessage:")]
        void DidReceiveMessage(EMMessage message);

        // @optional -(void)didReceiveCmdMessage:(EMMessage *)cmdMessage;
        [Export("didReceiveCmdMessage:")]
        void DidReceiveCmdMessage(EMMessage cmdMessage);

        // @optional -(void)didReceiveMessageId:(NSString *)messageId chatter:(NSString *)conversationChatter error:(EMError *)error;
        [Export("didReceiveMessageId:chatter:error:")]
        void DidReceiveMessageId(string messageId, string conversationChatter, EMError error);

        // @optional -(void)didFetchingMessageAttachments:(EMMessage *)message progress:(float)progress;
        [Export("didFetchingMessageAttachments:progress:")]
        void DidFetchingMessageAttachments(EMMessage message, float progress);

        // @optional -(void)didMessageAttachmentsStatusChanged:(EMMessage *)message error:(EMError *)error;
        [Export("didMessageAttachmentsStatusChanged:error:")]
        void DidMessageAttachmentsStatusChanged(EMMessage message, EMError error);

        // @optional -(void)didReceiveHasReadResponse:(EMReceipt *)resp;
        [Export("didReceiveHasReadResponse:")]
        void DidReceiveHasReadResponse(EMReceipt resp);

        // @optional -(void)didReceiveHasDeliveredResponse:(EMReceipt *)resp;
        [Export("didReceiveHasDeliveredResponse:")]
        void DidReceiveHasDeliveredResponse(EMReceipt resp);

        // @optional -(void)didUpdateConversationList:(NSArray *)conversationList;
        [Export("didUpdateConversationList:")]
        [Verify(StronglyTypedNSArray)]
        void DidUpdateConversationList(NSObject[] conversationList);

        // @optional -(void)didUnreadMessagesCountChanged;
        [Export("didUnreadMessagesCountChanged")]
        void DidUnreadMessagesCountChanged();

        // @optional -(void)willReceiveOfflineMessages;
        [Export("willReceiveOfflineMessages")]
        void WillReceiveOfflineMessages();

        // @optional -(void)didReceiveOfflineMessages:(NSArray *)offlineMessages;
        [Export("didReceiveOfflineMessages:")]
        [Verify(StronglyTypedNSArray)]
        void DidReceiveOfflineMessages(NSObject[] offlineMessages);

        // @optional -(void)didReceiveOfflineCmdMessages:(NSArray *)offlineCmdMessages;
        [Export("didReceiveOfflineCmdMessages:")]
        [Verify(StronglyTypedNSArray)]
        void DidReceiveOfflineCmdMessages(NSObject[] offlineCmdMessages);

        // @optional -(void)didFinishedReceiveOfflineMessages;
        [Export("didFinishedReceiveOfflineMessages")]
        void DidFinishedReceiveOfflineMessages();

        // @optional -(void)didFinishedReceiveOfflineCmdMessages;
        [Export("didFinishedReceiveOfflineCmdMessages")]
        void DidFinishedReceiveOfflineCmdMessages();

        // @optional -(void)didFinishedReceiveOfflineCmdMessages:(NSArray *)offlineCmdMessages __attribute__((deprecated("")));
        [Export("didFinishedReceiveOfflineCmdMessages:")]
        [Verify(StronglyTypedNSArray)]
        void DidFinishedReceiveOfflineCmdMessages(NSObject[] offlineCmdMessages);

        // @optional -(void)didFinishedReceiveOfflineMessages:(NSArray *)offlineMessages __attribute__((deprecated("")));
        [Export("didFinishedReceiveOfflineMessages:")]
        [Verify(StronglyTypedNSArray)]
        void DidFinishedReceiveOfflineMessages(NSObject[] offlineMessages);
    }

    // @protocol EMChatManagerEncryptionDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerEncryptionDelegate : IEMChatManagerDelegateBase
    {
    }

    // @protocol EMChatManagerLoginDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerLoginDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)willAutoLoginWithInfo:(NSDictionary *)loginInfo error:(EMError *)error;
        [Export("willAutoLoginWithInfo:error:")]
        void WillAutoLoginWithInfo(NSDictionary loginInfo, EMError error);

        // @optional -(void)didAutoLoginWithInfo:(NSDictionary *)loginInfo error:(EMError *)error;
        [Export("didAutoLoginWithInfo:error:")]
        void DidAutoLoginWithInfo(NSDictionary loginInfo, EMError error);

        // @optional -(void)didLoginWithInfo:(NSDictionary *)loginInfo error:(EMError *)error;
        [Export("didLoginWithInfo:error:")]
        void DidLoginWithInfo(NSDictionary loginInfo, EMError error);

        // @optional -(void)didLogoffWithError:(EMError *)error;
        [Export("didLogoffWithError:")]
        void DidLogoffWithError(EMError error);

        // @optional -(void)didLoginFromOtherDevice;
        [Export("didLoginFromOtherDevice")]
        void DidLoginFromOtherDevice();

        // @optional -(void)didRemovedFromServer;
        [Export("didRemovedFromServer")]
        void DidRemovedFromServer();

        // @optional -(void)didServersChanged;
        [Export("didServersChanged")]
        void DidServersChanged();

        // @optional -(void)didAppkeyChanged;
        [Export("didAppkeyChanged")]
        void DidAppkeyChanged();

        // @optional -(void)didReconnect __attribute__((deprecated("需要使用 willAutoReconnect 与 didAutoReconnectFinishedWithError: 方法判断是否正在重连")));
        [Export("didReconnect")]
        void DidReconnect();

        // @optional -(void)didRegisterNewAccount:(NSString *)username password:(NSString *)password error:(EMError *)error;
        [Export("didRegisterNewAccount:password:error:")]
        void DidRegisterNewAccount(string username, string password, EMError error);

        // @optional -(void)willAutoReconnect;
        [Export("willAutoReconnect")]
        void WillAutoReconnect();

        // @optional -(void)didAutoReconnectFinishedWithError:(NSError *)error;
        [Export("didAutoReconnectFinishedWithError:")]
        void DidAutoReconnectFinishedWithError(NSError error);
    }

    // @protocol EMChatManagerBuddyDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerBuddyDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)didReceiveBuddyRequest:(NSString *)username message:(NSString *)message;
        [Export("didReceiveBuddyRequest:message:")]
        void DidReceiveBuddyRequest(string username, string message);

        // @optional -(void)didAcceptedByBuddy:(NSString *)username;
        [Export("didAcceptedByBuddy:")]
        void DidAcceptedByBuddy(string username);

        // @optional -(void)didRejectedByBuddy:(NSString *)username;
        [Export("didRejectedByBuddy:")]
        void DidRejectedByBuddy(string username);

        // @optional -(void)didAcceptBuddySucceed:(NSString *)username;
        [Export("didAcceptBuddySucceed:")]
        void DidAcceptBuddySucceed(string username);

        // @optional -(void)didRemovedByBuddy:(NSString *)username;
        [Export("didRemovedByBuddy:")]
        void DidRemovedByBuddy(string username);

        // @optional -(void)didUpdateBuddyList:(NSArray *)buddyList changedBuddies:(NSArray *)changedBuddies isAdd:(BOOL)isAdd;
        [Export("didUpdateBuddyList:changedBuddies:isAdd:")]
        [Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        void DidUpdateBuddyList(NSObject[] buddyList, NSObject[] changedBuddies, bool isAdd);

        // @optional -(void)didUpdateBuddyGroupList:(NSArray *)buddyGroupList __attribute__((deprecated("")));
        [Export("didUpdateBuddyGroupList:")]
        [Verify(StronglyTypedNSArray)]
        void DidUpdateBuddyGroupList(NSObject[] buddyGroupList);

        // @optional -(void)didFetchedBuddyList:(NSArray *)buddyList error:(EMError *)error;
        [Export("didFetchedBuddyList:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidFetchedBuddyList(NSObject[] buddyList, EMError error);

        // @optional -(void)didChangedOnlineStatus:(BOOL)isOnline forBuddy:(NSString *)username __attribute__((deprecated("")));
        [Export("didChangedOnlineStatus:forBuddy:")]
        void DidChangedOnlineStatus(bool isOnline, string username);

        // @optional -(void)didUpdateBlockedList:(NSArray *)blockedList;
        [Export("didUpdateBlockedList:")]
        [Verify(StronglyTypedNSArray)]
        void DidUpdateBlockedList(NSObject[] blockedList);

        // @optional -(void)didBlockBuddy:(NSString *)username error:(EMError *)pError;
        [Export("didBlockBuddy:error:")]
        void DidBlockBuddy(string username, EMError pError);

        // @optional -(void)didUnblockBuddy:(NSString *)username error:(EMError *)pError;
        [Export("didUnblockBuddy:error:")]
        void DidUnblockBuddy(string username, EMError pError);
    }

    // @protocol EMChatManagerUtilDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerUtilDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)didFetchMessage:(EMMessage *)aMessage error:(EMError *)error;
        [Export("didFetchMessage:error:")]
        void DidFetchMessage(EMMessage aMessage, EMError error);

        // @optional -(void)didFetchMessageThumbnail:(EMMessage *)aMessage error:(EMError *)error;
        [Export("didFetchMessageThumbnail:error:")]
        void DidFetchMessageThumbnail(EMMessage aMessage, EMError error);

        // @optional -(void)didConnectionStateChanged:(EMConnectionState)connectionState;
        [Export("didConnectionStateChanged:")]
        void DidConnectionStateChanged(EMConnectionState connectionState);
    }

    // @protocol EMChatManagerGroupDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerGroupDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)group:(EMGroup *)group didCreateWithError:(EMError *)error;
        [Export("group:didCreateWithError:")]
        void Group(EMGroup group, EMError error);

        // @optional -(void)group:(EMGroup *)group didLeave:(EMGroupLeaveReason)reason error:(EMError *)error;
        [Export("group:didLeave:error:")]
        void Group(EMGroup group, EMGroupLeaveReason reason, EMError error);

        // @optional -(void)groupDidUpdateInfo:(EMGroup *)group error:(EMError *)error;
        [Export("groupDidUpdateInfo:error:")]
        void GroupDidUpdateInfo(EMGroup group, EMError error);

        // @optional -(void)didReceiveGroupInvitationFrom:(NSString *)groupId inviter:(NSString *)username message:(NSString *)message __attribute__((deprecated("")));
        [Export("didReceiveGroupInvitationFrom:inviter:message:")]
        void DidReceiveGroupInvitationFrom(string groupId, string username, string message);

        // @optional -(void)didAutoAcceptedGroupInvitationFrom:(NSString *)groupId inviter:(NSString *)username message:(NSString *)message __attribute__((deprecated("")));
        [Export("didAutoAcceptedGroupInvitationFrom:inviter:message:")]
        void DidAutoAcceptedGroupInvitationFrom(string groupId, string username, string message);

        // @optional -(void)didAcceptInvitationFromGroup:(EMGroup *)group error:(EMError *)error;
        [Export("didAcceptInvitationFromGroup:error:")]
        void DidAcceptInvitationFromGroup(EMGroup group, EMError error);

        // @optional -(void)didReceiveGroupInvitationFrom:(NSString *)groupId inviter:(NSString *)username message:(NSString *)message error:(EMError *)error;
        [Export("didReceiveGroupInvitationFrom:inviter:message:error:")]
        void DidReceiveGroupInvitationFrom(string groupId, string username, string message, EMError error);

        // @optional -(void)didReceiveGroupRejectFrom:(NSString *)groupId invitee:(NSString *)username reason:(NSString *)reason __attribute__((deprecated("")));
        [Export("didReceiveGroupRejectFrom:invitee:reason:")]
        void DidReceiveGroupRejectFrom(string groupId, string username, string reason);

        // @optional -(void)didReceiveGroupRejectFrom:(NSString *)groupId invitee:(NSString *)username reason:(NSString *)reason error:(EMError *)error;
        [Export("didReceiveGroupRejectFrom:invitee:reason:error:")]
        void DidReceiveGroupRejectFrom(string groupId, string username, string reason, EMError error);

        // @optional -(void)didReceiveApplyToJoinGroup:(NSString *)groupId groupname:(NSString *)groupname applyUsername:(NSString *)username reason:(NSString *)reason __attribute__((deprecated("")));
        [Export("didReceiveApplyToJoinGroup:groupname:applyUsername:reason:")]
        void DidReceiveApplyToJoinGroup(string groupId, string groupname, string username, string reason);

        // @optional -(void)didReceiveApplyToJoinGroup:(NSString *)groupId groupname:(NSString *)groupname applyUsername:(NSString *)username reason:(NSString *)reason error:(EMError *)error;
        [Export("didReceiveApplyToJoinGroup:groupname:applyUsername:reason:error:")]
        void DidReceiveApplyToJoinGroup(string groupId, string groupname, string username, string reason, EMError error);

        // @optional -(void)didReceiveRejectApplyToJoinGroupFrom:(NSString *)fromId groupname:(NSString *)groupname reason:(NSString *)reason __attribute__((deprecated("")));
        [Export("didReceiveRejectApplyToJoinGroupFrom:groupname:reason:")]
        void DidReceiveRejectApplyToJoinGroupFrom(string fromId, string groupname, string reason);

        // @optional -(void)didReceiveRejectApplyToJoinGroupFrom:(NSString *)fromId groupname:(NSString *)groupname reason:(NSString *)reason error:(EMError *)error;
        [Export("didReceiveRejectApplyToJoinGroupFrom:groupname:reason:error:")]
        void DidReceiveRejectApplyToJoinGroupFrom(string fromId, string groupname, string reason, EMError error);

        // @optional -(void)didReceiveAcceptApplyToJoinGroup:(NSString *)groupId groupname:(NSString *)groupname __attribute__((deprecated("")));
        [Export("didReceiveAcceptApplyToJoinGroup:groupname:")]
        void DidReceiveAcceptApplyToJoinGroup(string groupId, string groupname);

        // @optional -(void)didReceiveAcceptApplyToJoinGroup:(NSString *)groupId groupname:(NSString *)groupname error:(EMError *)error;
        [Export("didReceiveAcceptApplyToJoinGroup:groupname:error:")]
        void DidReceiveAcceptApplyToJoinGroup(string groupId, string groupname, EMError error);

        // @optional -(void)didAcceptApplyJoinGroup:(NSString *)groupId username:(NSString *)username error:(EMError *)error;
        [Export("didAcceptApplyJoinGroup:username:error:")]
        void DidAcceptApplyJoinGroup(string groupId, string username, EMError error);

        // @optional -(void)didUpdateGroupList:(NSArray *)groupList error:(EMError *)error;
        [Export("didUpdateGroupList:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidUpdateGroupList(NSObject[] groupList, EMError error);

        // @optional -(void)didFetchAllPublicGroups:(NSArray *)groups error:(EMError *)error;
        [Export("didFetchAllPublicGroups:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidFetchAllPublicGroups(NSObject[] groups, EMError error);

        // @optional -(void)didFetchGroupInfo:(EMGroup *)group error:(EMError *)error;
        [Export("didFetchGroupInfo:error:")]
        void DidFetchGroupInfo(EMGroup group, EMError error);

        // @optional -(void)didFetchGroupOccupantsList:(NSArray *)occupantsList error:(EMError *)error;
        [Export("didFetchGroupOccupantsList:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidFetchGroupOccupantsList(NSObject[] occupantsList, EMError error);

        // @optional -(void)didFetchGroupBans:(NSString *)groupId list:(NSArray *)bansList error:(EMError *)error;
        [Export("didFetchGroupBans:list:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidFetchGroupBans(string groupId, NSObject[] bansList, EMError error);

        // @optional -(void)didJoinPublicGroup:(EMGroup *)group error:(EMError *)error;
        [Export("didJoinPublicGroup:error:")]
        void DidJoinPublicGroup(EMGroup group, EMError error);

        // @optional -(void)didApplyJoinPublicGroup:(EMGroup *)group error:(EMError *)error;
        [Export("didApplyJoinPublicGroup:error:")]
        void DidApplyJoinPublicGroup(EMGroup group, EMError error);

        // @optional -(NSString *)nicknameForAccount:(NSString *)account inGroup:(NSString *)groupId;
        [Export("nicknameForAccount:inGroup:")]
        string NicknameForAccount(string account, string groupId);
    }

    // @protocol EMChatManagerPushNotificationDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerPushNotificationDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)didUpdatePushOptions:(EMPushNotificationOptions *)options error:(EMError *)error;
        [Export("didUpdatePushOptions:error:")]
        void DidUpdatePushOptions(EMPushNotificationOptions options, EMError error);

        // @optional -(void)didIgnoreGroupPushNotification:(NSArray *)ignoredGroupList error:(EMError *)error;
        [Export("didIgnoreGroupPushNotification:error:")]
        [Verify(StronglyTypedNSArray)]
        void DidIgnoreGroupPushNotification(NSObject[] ignoredGroupList, EMError error);
    }

    // @protocol EMChatManagerChatroomDelegate <EMChatManagerDelegateBase>
    [Protocol, Model]
    interface EMChatManagerChatroomDelegate : IEMChatManagerDelegateBase
    {
        // @optional -(void)chatroom:(EMChatroom *)chatroom occupantDidJoin:(NSString *)username;
        [Export("chatroom:occupantDidJoin:")]
        void Chatroom(EMChatroom chatroom, string username);

        // @optional -(void)chatroom:(EMChatroom *)chatroom occupantDidLeave:(NSString *)username;
        [Export("chatroom:occupantDidLeave:")]
        void Chatroom(EMChatroom chatroom, string username);

        // @optional -(void)beKickedOutFromChatroom:(EMChatroom *)chatroom reason:(EMChatroomBeKickedReason)reason;
        [Export("beKickedOutFromChatroom:reason:")]
        void BeKickedOutFromChatroom(EMChatroom chatroom, EMChatroomBeKickedReason reason);

        // @optional -(void)didReceiveChatroomInvitationFrom:(NSString *)chatroomId inviter:(NSString *)username message:(NSString *)message;
        [Export("didReceiveChatroomInvitationFrom:inviter:message:")]
        void DidReceiveChatroomInvitationFrom(string chatroomId, string username, string message);
    }

    // @protocol EMChatManagerDelegate <EMChatManagerChatDelegate, EMChatManagerLoginDelegate, EMChatManagerEncryptionDelegate, EMChatManagerBuddyDelegate, EMChatManagerUtilDelegate, EMChatManagerGroupDelegate, EMChatManagerPushNotificationDelegate, EMChatManagerChatroomDelegate>
    [Protocol, Model]
    interface EMChatManagerDelegate : IEMChatManagerChatDelegate, IEMChatManagerLoginDelegate, IEMChatManagerEncryptionDelegate, IEMChatManagerBuddyDelegate, IEMChatManagerUtilDelegate, IEMChatManagerGroupDelegate, IEMChatManagerPushNotificationDelegate, IEMChatManagerChatroomDelegate
    {
    }

    // @protocol IChatManagerDelegate <EMChatManagerDelegate>
    [Protocol, Model]
    interface IChatManagerDelegate : IEMChatManagerDelegate
    {
    }

    // @protocol EMDeviceManagerNetworkDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface EMDeviceManagerNetworkDelegate
    {
        // @optional -(void)didConnectionChanged:(EMConnectionType)connectionType fromConnectionType:(EMConnectionType)fromConnectionType;
        [Export("didConnectionChanged:fromConnectionType:")]
        void FromConnectionType(EMConnectionType connectionType, EMConnectionType fromConnectionType);
    }

    // @protocol EMDeviceManagerDelegate <EMDeviceManagerNetworkDelegate>
    [Protocol, Model]
    interface EMDeviceManagerDelegate : IEMDeviceManagerNetworkDelegate
    {
    }

    // @protocol IDeviceManagerDelegate <EMDeviceManagerDelegate>
    [Protocol, Model]
    interface IDeviceManagerDelegate : IEMDeviceManagerDelegate
    {
    }

    // @interface EMMessage : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface EMMessage : INSCoding
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

        // @property (nonatomic) BOOL requireEncryption;
        [Export("requireEncryption")]
        bool RequireEncryption { get; set; }

        // @property (nonatomic) BOOL isEncryptedOnServer;
        [Export("isEncryptedOnServer")]
        bool IsEncryptedOnServer { get; set; }

        // @property (nonatomic) long long timestamp;
        [Export("timestamp")]
        long Timestamp { get; set; }

        // @property (nonatomic) BOOL isRead;
        [Export("isRead")]
        bool IsRead { get; set; }

        // @property (nonatomic) BOOL isAcked __attribute__((deprecated("")));
        [Export("isAcked")]
        bool IsAcked { get; set; }

        // @property (nonatomic) BOOL isReadAcked;
        [Export("isReadAcked")]
        bool IsReadAcked { get; set; }

        // @property (nonatomic) BOOL isDelivered __attribute__((deprecated("")));
        [Export("isDelivered")]
        bool IsDelivered { get; set; }

        // @property (nonatomic) BOOL isDeliveredAcked;
        [Export("isDeliveredAcked")]
        bool IsDeliveredAcked { get; set; }

        // @property (nonatomic, strong) NSArray * messageBodies;
        [Export("messageBodies", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] MessageBodies { get; set; }

        // @property (nonatomic, strong) NSString * conversationChatter;
        [Export("conversationChatter", ArgumentSemantic.Strong)]
        string ConversationChatter { get; set; }

        // @property (nonatomic, weak) EMConversation * _Nullable conversation __attribute__((deprecated("")));
        [NullAllowed, Export("conversation", ArgumentSemantic.Weak)]
        EMConversation Conversation { get; set; }

        // @property (nonatomic) BOOL isGroup __attribute__((deprecated("")));
        [Export("isGroup")]
        bool IsGroup { get; set; }

        // @property (copy, nonatomic) NSString * groupSenderName;
        [Export("groupSenderName")]
        string GroupSenderName { get; set; }

        // @property (readonly, nonatomic) BOOL isOfflineMessage;
        [Export("isOfflineMessage")]
        bool IsOfflineMessage { get; }

        // @property (nonatomic, strong) NSDictionary * ext;
        [Export("ext", ArgumentSemantic.Strong)]
        NSDictionary Ext { get; set; }

        // @property (nonatomic) MessageDeliveryState deliveryState;
        [Export("deliveryState", ArgumentSemantic.Assign)]
        MessageDeliveryState DeliveryState { get; set; }

        // @property (nonatomic) BOOL isAnonymous;
        [Export("isAnonymous")]
        bool IsAnonymous { get; set; }

        // @property (nonatomic) EMMessageType messageType;
        [Export("messageType", ArgumentSemantic.Assign)]
        EMMessageType MessageType { get; set; }

        // -(id)initWithReceiver:(NSString *)receiver bodies:(NSArray *)bodies;
        [Export("initWithReceiver:bodies:")]
        [Verify(StronglyTypedNSArray)]
        IntPtr Constructor(string receiver, NSObject[] bodies);

        // -(id)initMessageWithID:(NSString *)messageId sender:(NSString *)sender receiver:(NSString *)receiver bodies:(NSArray *)bodies;
        [Export("initMessageWithID:sender:receiver:bodies:")]
        [Verify(StronglyTypedNSArray)]
        IntPtr Constructor(string messageId, string sender, string receiver, NSObject[] bodies);

        // -(NSArray *)addMessageBody:(id<IEMMessageBody>)body;
        [Export("addMessageBody:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] AddMessageBody(IEMMessageBody body);

        // -(NSArray *)removeMessageBody:(id<IEMMessageBody>)body;
        [Export("removeMessageBody:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] RemoveMessageBody(IEMMessageBody body);

        // -(BOOL)updateMessageDeliveryStateToDB;
        [Export("updateMessageDeliveryStateToDB")]
        [Verify(MethodToProperty)]
        bool UpdateMessageDeliveryStateToDB { get; }

        // -(BOOL)updateMessageExtToDB;
        [Export("updateMessageExtToDB")]
        [Verify(MethodToProperty)]
        bool UpdateMessageExtToDB { get; }

        // -(BOOL)updateMessageBodiesToDB;
        [Export("updateMessageBodiesToDB")]
        [Verify(MethodToProperty)]
        bool UpdateMessageBodiesToDB { get; }

        // -(BOOL)updateMessageStatusFailedToDB;
        [Export("updateMessageStatusFailedToDB")]
        [Verify(MethodToProperty)]
        bool UpdateMessageStatusFailedToDB { get; }
    }

    // @protocol IEMMessageBody <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IEMMessageBody
    {
        // @required @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Abstract]
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @required @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Abstract]
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @required @property (nonatomic, weak) EMMessage * _Nullable message;
        [Abstract]
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @required -(id)initWithChatObject:(id<IEMChatObject>)aChatObject;
        [Abstract]
        [Export("initWithChatObject:")]
        IntPtr Constructor(IEMChatObject aChatObject);
    }

    [Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const EMMessageBodyAttrKeyType;
        [Field("EMMessageBodyAttrKeyType", "__Internal")]
        NSString EMMessageBodyAttrKeyType { get; }

        // extern NSString *const EMMessageBodyAttrKeyUrl;
        [Field("EMMessageBodyAttrKeyUrl", "__Internal")]
        NSString EMMessageBodyAttrKeyUrl { get; }

        // extern NSString *const EMMessageBodyAttrKeySecret;
        [Field("EMMessageBodyAttrKeySecret", "__Internal")]
        NSString EMMessageBodyAttrKeySecret { get; }

        // extern NSString *const EMMessageBodyAttrKeyFileName;
        [Field("EMMessageBodyAttrKeyFileName", "__Internal")]
        NSString EMMessageBodyAttrKeyFileName { get; }

        // extern NSString *const EMMessageBodyAttrKeyFileLength;
        [Field("EMMessageBodyAttrKeyFileLength", "__Internal")]
        NSString EMMessageBodyAttrKeyFileLength { get; }

        // extern NSString *const EMMessageBodyAttrKeySize;
        [Field("EMMessageBodyAttrKeySize", "__Internal")]
        NSString EMMessageBodyAttrKeySize { get; }

        // extern NSString *const EMMessageBodyAttrKeySizeWidth;
        [Field("EMMessageBodyAttrKeySizeWidth", "__Internal")]
        NSString EMMessageBodyAttrKeySizeWidth { get; }

        // extern NSString *const EMMessageBodyAttrKeySizeHeight;
        [Field("EMMessageBodyAttrKeySizeHeight", "__Internal")]
        NSString EMMessageBodyAttrKeySizeHeight { get; }

        // extern NSString *const EMMessageBodyAttrKeyThumb;
        [Field("EMMessageBodyAttrKeyThumb", "__Internal")]
        NSString EMMessageBodyAttrKeyThumb { get; }

        // extern NSString *const EMMessageBodyAttrKeyThumbSecret;
        [Field("EMMessageBodyAttrKeyThumbSecret", "__Internal")]
        NSString EMMessageBodyAttrKeyThumbSecret { get; }

        // extern NSString *const EMMessageBodyAttrKeyDuration;
        [Field("EMMessageBodyAttrKeyDuration", "__Internal")]
        NSString EMMessageBodyAttrKeyDuration { get; }

        // extern NSString *const EMMessageBodyAttrTypeTxt;
        [Field("EMMessageBodyAttrTypeTxt", "__Internal")]
        NSString EMMessageBodyAttrTypeTxt { get; }

        // extern NSString *const EMMessageBodyAttrTypeImag;
        [Field("EMMessageBodyAttrTypeImag", "__Internal")]
        NSString EMMessageBodyAttrTypeImag { get; }

        // extern NSString *const EMMessageBodyAttrTypeAudio;
        [Field("EMMessageBodyAttrTypeAudio", "__Internal")]
        NSString EMMessageBodyAttrTypeAudio { get; }

        // extern NSString *const EMMessageBodyAttrTypeLoc;
        [Field("EMMessageBodyAttrTypeLoc", "__Internal")]
        NSString EMMessageBodyAttrTypeLoc { get; }

        // extern NSString *const EMMessageBodyAttrTypeVideo;
        [Field("EMMessageBodyAttrTypeVideo", "__Internal")]
        NSString EMMessageBodyAttrTypeVideo { get; }

        // extern NSString *const EMMessageBodyAttrTypeFile;
        [Field("EMMessageBodyAttrTypeFile", "__Internal")]
        NSString EMMessageBodyAttrTypeFile { get; }

        // extern NSString *const EMMessageBodyAttrTypeCmd;
        [Field("EMMessageBodyAttrTypeCmd", "__Internal")]
        NSString EMMessageBodyAttrTypeCmd { get; }
    }

    // @protocol IEMFileMessageBody <IEMMessageBody>
    [Protocol, Model]
    interface IEMFileMessageBody : IIEMMessageBody
    {
        // @required @property (nonatomic, strong) NSString * uuid;
        [Abstract]
        [Export("uuid", ArgumentSemantic.Strong)]
        string Uuid { get; set; }

        // @required @property (nonatomic, strong) NSString * displayName;
        [Abstract]
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @required @property (nonatomic, strong) NSString * localPath;
        [Abstract]
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @required @property (nonatomic, strong) NSString * remotePath;
        [Abstract]
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @required @property (nonatomic, strong) NSString * secretKey;
        [Abstract]
        [Export("secretKey", ArgumentSemantic.Strong)]
        string SecretKey { get; set; }

        // @required @property (nonatomic) EMAttachmentDownloadStatus attachmentDownloadStatus;
        [Abstract]
        [Export("attachmentDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus AttachmentDownloadStatus { get; set; }

        // @required @property (nonatomic) long long fileLength;
        [Abstract]
        [Export("fileLength")]
        long FileLength { get; set; }
    }

    // @interface EMVideoMessageBody : NSObject <IEMFileMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMVideoMessageBody : IIEMFileMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic, strong) NSString * remotePath;
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @property (nonatomic, strong) NSString * secretKey;
        [Export("secretKey", ArgumentSemantic.Strong)]
        string SecretKey { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailUuid;
        [Export("thumbnailUuid", ArgumentSemantic.Strong)]
        string ThumbnailUuid { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailLocalPath;
        [Export("thumbnailLocalPath", ArgumentSemantic.Strong)]
        string ThumbnailLocalPath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailRemotePath;
        [Export("thumbnailRemotePath", ArgumentSemantic.Strong)]
        string ThumbnailRemotePath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailSecretKey;
        [Export("thumbnailSecretKey", ArgumentSemantic.Strong)]
        string ThumbnailSecretKey { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // @property (nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; set; }

        // @property (nonatomic) EMAttachmentDownloadStatus attachmentDownloadStatus;
        [Export("attachmentDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus AttachmentDownloadStatus { get; set; }

        // @property (nonatomic) EMAttachmentDownloadStatus thumbnailDownloadStatus;
        [Export("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus ThumbnailDownloadStatus { get; set; }

        // -(id)initWithChatObject:(EMChatVideo *)aChatVideo;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatVideo aChatVideo);

        // +(instancetype)videoMessageBodyFromBodyDict:(NSDictionary *)bodyDict forChatter:(NSString *)chatter;
        [Static]
        [Export("videoMessageBodyFromBodyDict:forChatter:")]
        EMVideoMessageBody VideoMessageBodyFromBodyDict(NSDictionary bodyDict, string chatter);
    }

    // @interface EMVoiceMessageBody : NSObject <IEMFileMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMVoiceMessageBody : IIEMFileMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic, strong) NSString * remotePath;
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @property (nonatomic, strong) NSString * secretKey;
        [Export("secretKey", ArgumentSemantic.Strong)]
        string SecretKey { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // @property (nonatomic) EMAttachmentDownloadStatus attachmentDownloadStatus;
        [Export("attachmentDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus AttachmentDownloadStatus { get; set; }

        // -(id)initWithChatObject:(EMChatVoice *)aChatVoice;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatVoice aChatVoice);

        // +(instancetype)voiceMessageBodyFromBodyDict:(NSDictionary *)bodyDict forChatter:(NSString *)chatter;
        [Static]
        [Export("voiceMessageBodyFromBodyDict:forChatter:")]
        EMVoiceMessageBody VoiceMessageBodyFromBodyDict(NSDictionary bodyDict, string chatter);
    }

    // @interface EMTextMessageBody : NSObject <IEMMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMTextMessageBody : IIEMMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic, strong) NSString * text;
        [Export("text", ArgumentSemantic.Strong)]
        string Text { get; set; }

        // -(id)initWithChatObject:(EMChatText *)aChatText;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatText aChatText);
    }

    // @interface EMLocationMessageBody : NSObject <IEMMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMLocationMessageBody : IIEMMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic) double latitude;
        [Export("latitude")]
        double Latitude { get; set; }

        // @property (nonatomic) double longitude;
        [Export("longitude")]
        double Longitude { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // -(id)initWithChatObject:(EMChatLocation *)aChatLocation;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatLocation aChatLocation);
    }

    // @interface EMImageMessageBody : NSObject <IEMFileMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMImageMessageBody : IIEMFileMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailUuid;
        [Export("thumbnailUuid", ArgumentSemantic.Strong)]
        string ThumbnailUuid { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailDisplayName;
        [Export("thumbnailDisplayName", ArgumentSemantic.Strong)]
        string ThumbnailDisplayName { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailLocalPath;
        [Export("thumbnailLocalPath", ArgumentSemantic.Strong)]
        string ThumbnailLocalPath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailRemotePath;
        [Export("thumbnailRemotePath", ArgumentSemantic.Strong)]
        string ThumbnailRemotePath { get; set; }

        // @property (nonatomic, strong) NSString * thumbnailSecretKey;
        [Export("thumbnailSecretKey", ArgumentSemantic.Strong)]
        string ThumbnailSecretKey { get; set; }

        // @property (nonatomic) CGSize thumbnailSize;
        [Export("thumbnailSize", ArgumentSemantic.Assign)]
        CGSize ThumbnailSize { get; set; }

        // @property (nonatomic) long long thumbnailFileLength;
        [Export("thumbnailFileLength")]
        long ThumbnailFileLength { get; set; }

        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic, strong) NSString * remotePath;
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @property (nonatomic, strong) NSString * secretKey;
        [Export("secretKey", ArgumentSemantic.Strong)]
        string SecretKey { get; set; }

        // @property (nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (readonly, nonatomic, strong) EMChatImage * image;
        [Export("image", ArgumentSemantic.Strong)]
        EMChatImage Image { get; }

        // @property (readonly, nonatomic, strong) EMChatImage * thumbnailImage;
        [Export("thumbnailImage", ArgumentSemantic.Strong)]
        EMChatImage ThumbnailImage { get; }

        // @property (nonatomic) EMAttachmentDownloadStatus attachmentDownloadStatus;
        [Export("attachmentDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus AttachmentDownloadStatus { get; set; }

        // @property (nonatomic) EMAttachmentDownloadStatus thumbnailDownloadStatus;
        [Export("thumbnailDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus ThumbnailDownloadStatus { get; set; }

        // -(id)initWithImage:(EMChatImage *)aImage thumbnailImage:(EMChatImage *)aThumbnialImage;
        [Export("initWithImage:thumbnailImage:")]
        IntPtr Constructor(EMChatImage aImage, EMChatImage aThumbnialImage);

        // -(id)initWithChatObject:(EMChatImage *)aChatObject;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatImage aChatObject);

        // +(instancetype)imageMessageBodyFromBodyDict:(NSDictionary *)bodyDict forChatter:(NSString *)chatter;
        [Static]
        [Export("imageMessageBodyFromBodyDict:forChatter:")]
        EMImageMessageBody ImageMessageBodyFromBodyDict(NSDictionary bodyDict, string chatter);
    }

    // @interface EMCommandMessageBody : NSObject <IEMMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMCommandMessageBody : IIEMMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (readonly, nonatomic, strong) NSString * action;
        [Export("action", ArgumentSemantic.Strong)]
        string Action { get; }

        // @property (readonly, nonatomic, strong) NSArray * params;
        [Export("params", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Params { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // -(id)initWithChatObject:(EMChatCommand *)aChatCommand;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatCommand aChatCommand);
    }

    // @interface EMFileMessageBody : NSObject <IEMFileMessageBody>
    [BaseType(typeof(NSObject))]
    interface EMFileMessageBody : IIEMFileMessageBody
    {
        // @property (readonly, nonatomic) MessageBodyType messageBodyType;
        [Export("messageBodyType")]
        MessageBodyType MessageBodyType { get; }

        // @property (readonly, nonatomic, strong) id<IEMChatObject> chatObject;
        [Export("chatObject", ArgumentSemantic.Strong)]
        IEMChatObject ChatObject { get; }

        // @property (nonatomic, weak) EMMessage * _Nullable message;
        [NullAllowed, Export("message", ArgumentSemantic.Weak)]
        EMMessage Message { get; set; }

        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic, strong) NSString * remotePath;
        [Export("remotePath", ArgumentSemantic.Strong)]
        string RemotePath { get; set; }

        // @property (nonatomic, strong) NSString * secretKey;
        [Export("secretKey", ArgumentSemantic.Strong)]
        string SecretKey { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) EMAttachmentDownloadStatus attachmentDownloadStatus;
        [Export("attachmentDownloadStatus", ArgumentSemantic.Assign)]
        EMAttachmentDownloadStatus AttachmentDownloadStatus { get; set; }

        // -(id)initWithChatObject:(EMChatFile *)aChatFile;
        [Export("initWithChatObject:")]
        IntPtr Constructor(EMChatFile aChatFile);

        // +(instancetype)fileMessageBodyFromBodyDict:(NSDictionary *)bodyDict forChatter:(NSString *)chatter;
        [Static]
        [Export("fileMessageBodyFromBodyDict:forChatter:")]
        EMFileMessageBody FileMessageBodyFromBodyDict(NSDictionary bodyDict, string chatter);
    }

    // @protocol IEMChatObject <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IEMChatObject
    {
        // @required @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [Abstract]
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }
    }

    // @protocol IEMChatFile <IEMChatObject>
    [Protocol, Model]
    interface IEMChatFile : IIEMChatObject
    {
        // @required @property (nonatomic, strong) NSString * displayName;
        [Abstract]
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @required @property (nonatomic, strong) NSString * localPath;
        [Abstract]
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @required @property (nonatomic) long long fileLength;
        [Abstract]
        [Export("fileLength")]
        long FileLength { get; set; }

        // @required -(id)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Abstract]
        [Export("initWithData:displayName:")]
        IntPtr DisplayName(NSData aData, string aDisplayName);

        // @required -(id)initWithFile:(NSString *)filePath displayName:(NSString *)aDisplayName;
        [Abstract]
        [Export("initWithFile:displayName:")]
        IntPtr DisplayName(string filePath, string aDisplayName);
    }

    // @interface EMChatVideo : NSObject <IEMChatFile>
    [BaseType(typeof(NSObject))]
    interface EMChatVideo : IIEMChatFile
    {
        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (assign, nonatomic) BOOL shouldGenerateThumbnail;
        [Export("shouldGenerateThumbnail")]
        bool ShouldGenerateThumbnail { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (copy, nonatomic) NSString * thumbnailPath;
        [Export("thumbnailPath")]
        string ThumbnailPath { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // @property (nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // -(id)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)aDisplayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string aDisplayName);
    }

    // @interface EMChatVoice : NSObject <IEMChatFile>
    [BaseType(typeof(NSObject))]
    interface EMChatVoice : IIEMChatFile
    {
        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) NSInteger duration;
        [Export("duration")]
        nint Duration { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // -(id)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)aDisplayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string aDisplayName);
    }

    // @interface EMChatText : NSObject <IEMChatObject>
    [BaseType(typeof(NSObject))]
    interface EMChatText : IIEMChatObject
    {
        // @property (nonatomic, strong) NSString * text;
        [Export("text", ArgumentSemantic.Strong)]
        string Text { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // -(id)initWithText:(NSString *)text;
        [Export("initWithText:")]
        IntPtr Constructor(string text);
    }

    // @interface EMChatLocation : NSObject <IEMChatObject>
    [BaseType(typeof(NSObject))]
    interface EMChatLocation : IIEMChatObject
    {
        // @property (nonatomic) double latitude;
        [Export("latitude")]
        double Latitude { get; set; }

        // @property (nonatomic) double longitude;
        [Export("longitude")]
        double Longitude { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) CLLocation * location;
        [Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // -(id)initWithLatitude:(double)latitude longitude:(double)longitude address:(NSString *)address;
        [Export("initWithLatitude:longitude:address:")]
        IntPtr Constructor(double latitude, double longitude, string address);

        // -(id)initWithCLLocation:(CLLocation *)location;
        [Export("initWithCLLocation:")]
        IntPtr Constructor(CLLocation location);
    }

    // @protocol IChatImageOptions <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IChatImageOptions
    {
        // @required @property (assign, nonatomic) CGFloat compressionQuality;
        [Abstract]
        [Export("compressionQuality")]
        nfloat CompressionQuality { get; set; }
    }

    // @interface EMChatImage : NSObject <IEMChatFile>
    [BaseType(typeof(NSObject))]
    interface EMChatImage : IIEMChatFile
    {
        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // @property (nonatomic, strong) id<IChatImageOptions> imageOptions;
        [Export("imageOptions", ArgumentSemantic.Strong)]
        IChatImageOptions ImageOptions { get; set; }

        // -(id)initWithUIImage:(UIImage *)aImage displayName:(NSString *)aDisplayName;
        [Export("initWithUIImage:displayName:")]
        IntPtr Constructor(UIImage aImage, string aDisplayName);

        // -(id)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)aDisplayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string aDisplayName);
    }

    // @interface EMChatFile : NSObject <IEMChatFile>
    [BaseType(typeof(NSObject))]
    interface EMChatFile : IIEMChatFile
    {
        // @property (nonatomic, strong) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Strong)]
        string DisplayName { get; set; }

        // @property (nonatomic, strong) NSString * localPath;
        [Export("localPath", ArgumentSemantic.Strong)]
        string LocalPath { get; set; }

        // @property (nonatomic) long long fileLength;
        [Export("fileLength")]
        long FileLength { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }

        // -(id)initWithData:(NSData *)aData displayName:(NSString *)aDisplayName;
        [Export("initWithData:displayName:")]
        IntPtr Constructor(NSData aData, string aDisplayName);

        // -(id)initWithFile:(NSString *)filePath displayName:(NSString *)aDisplayName;
        [Export("initWithFile:displayName:")]
        IntPtr Constructor(string filePath, string aDisplayName);
    }

    // @interface EMChatCommand : NSObject <IEMChatObject>
    [BaseType(typeof(NSObject))]
    interface EMChatCommand : IIEMChatObject
    {
        // @property (nonatomic, strong) NSString * cmd;
        [Export("cmd", ArgumentSemantic.Strong)]
        string Cmd { get; set; }

        // @property (nonatomic, strong) NSArray * params __attribute__((deprecated("")));
        [Export("params", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Params { get; set; }

        // @property (nonatomic, weak) id<IEMMessageBody> _Nullable messageBody;
        [NullAllowed, Export("messageBody", ArgumentSemantic.Weak)]
        IEMMessageBody MessageBody { get; set; }
    }

    // @interface EMBuddy : NSObject
    [BaseType(typeof(NSObject))]
    interface EMBuddy
    {
        // +(instancetype)buddyWithUsername:(NSString *)username;
        [Static]
        [Export("buddyWithUsername:")]
        EMBuddy BuddyWithUsername(string username);

        // @property (readonly, copy, nonatomic) NSString * username;
        [Export("username")]
        string Username { get; }

        // @property (nonatomic) EMBuddyFollowState followState;
        [Export("followState", ArgumentSemantic.Assign)]
        EMBuddyFollowState FollowState { get; set; }

        // @property (nonatomic) BOOL isPendingApproval;
        [Export("isPendingApproval")]
        bool IsPendingApproval { get; set; }
    }

    // @interface EMGroupStyleSetting : NSObject
    [BaseType(typeof(NSObject))]
    interface EMGroupStyleSetting
    {
        // @property (nonatomic) EMGroupStyle groupStyle;
        [Export("groupStyle", ArgumentSemantic.Assign)]
        EMGroupStyle GroupStyle { get; set; }

        // @property (nonatomic) NSInteger groupMaxUsersCount;
        [Export("groupMaxUsersCount")]
        nint GroupMaxUsersCount { get; set; }
    }

    // @interface EMGroup : NSObject
    [BaseType(typeof(NSObject))]
    interface EMGroup
    {
        // @property (readonly, nonatomic, strong) NSString * groupId;
        [Export("groupId", ArgumentSemantic.Strong)]
        string GroupId { get; }

        // @property (readonly, nonatomic, strong) NSString * groupSubject;
        [Export("groupSubject", ArgumentSemantic.Strong)]
        string GroupSubject { get; }

        // @property (readonly, nonatomic, strong) NSString * groupDescription;
        [Export("groupDescription", ArgumentSemantic.Strong)]
        string GroupDescription { get; }

        // @property (readonly, nonatomic) NSInteger groupOccupantsCount;
        [Export("groupOccupantsCount")]
        nint GroupOccupantsCount { get; }

        // @property (readonly, nonatomic) NSInteger groupOnlineOccupantsCount;
        [Export("groupOnlineOccupantsCount")]
        nint GroupOnlineOccupantsCount { get; }

        // @property (readonly, nonatomic, strong) NSString * password __attribute__((deprecated("")));
        [Export("password", ArgumentSemantic.Strong)]
        string Password { get; }

        // @property (readonly, nonatomic) BOOL isPublic;
        [Export("isPublic")]
        bool IsPublic { get; }

        // @property (readonly, nonatomic, strong) EMGroupStyleSetting * groupSetting;
        [Export("groupSetting", ArgumentSemantic.Strong)]
        EMGroupStyleSetting GroupSetting { get; }

        // @property (readonly, nonatomic) BOOL isPushNotificationEnabled;
        [Export("isPushNotificationEnabled")]
        bool IsPushNotificationEnabled { get; }

        // @property (readonly, nonatomic) BOOL isBlocked;
        [Export("isBlocked")]
        bool IsBlocked { get; }

        // @property (readonly, nonatomic, strong) NSString * owner;
        [Export("owner", ArgumentSemantic.Strong)]
        string Owner { get; }

        // @property (readonly, nonatomic, strong) NSArray * admins __attribute__((deprecated("")));
        [Export("admins", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Admins { get; }

        // @property (readonly, nonatomic, strong) NSArray * members;
        [Export("members", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Members { get; }

        // @property (readonly, nonatomic, strong) NSArray * occupants;
        [Export("occupants", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Occupants { get; }

        // @property (readonly, nonatomic, strong) NSArray * bans;
        [Export("bans", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Bans { get; }

        // -(EMGroupOccupant *)occupantWithUsername:(NSString *)username;
        [Export("occupantWithUsername:")]
        EMGroupOccupant OccupantWithUsername(string username);

        // +(instancetype)groupWithId:(NSString *)groupId;
        [Static]
        [Export("groupWithId:")]
        EMGroup GroupWithId(string groupId);
    }

    // @interface EMConversation : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface EMConversation : INSCoding
    {
        // @property (readonly, nonatomic, strong) NSString * chatter;
        [Export("chatter", ArgumentSemantic.Strong)]
        string Chatter { get; }

        // @property (readonly, nonatomic) BOOL isGroup __attribute__((deprecated("")));
        [Export("isGroup")]
        bool IsGroup { get; }

        // @property (readwrite, nonatomic) BOOL enableUnreadMessagesCountEvent;
        [Export("enableUnreadMessagesCountEvent")]
        bool EnableUnreadMessagesCountEvent { get; set; }

        // @property (nonatomic, strong) NSDictionary * ext;
        [Export("ext", ArgumentSemantic.Strong)]
        NSDictionary Ext { get; set; }

        // @property (readonly, nonatomic, strong) NSArray * messages __attribute__((deprecated("")));
        [Export("messages", ArgumentSemantic.Strong)]
        [Verify(StronglyTypedNSArray)]
        NSObject[] Messages { get; }

        // @property (readwrite, nonatomic) BOOL enableReceiveMessage __attribute__((deprecated("")));
        [Export("enableReceiveMessage")]
        bool EnableReceiveMessage { get; set; }

        // @property (readonly, nonatomic) EMConversationType conversationType;
        [Export("conversationType")]
        EMConversationType ConversationType { get; }

        // -(BOOL)removeMessageWithId:(NSString *)aMessageId;
        [Export("removeMessageWithId:")]
        bool RemoveMessageWithId(string aMessageId);

        // -(BOOL)removeMessage:(EMMessage *)aMessage;
        [Export("removeMessage:")]
        bool RemoveMessage(EMMessage aMessage);

        // -(NSUInteger)removeMessages:(NSArray *)aMessageIds __attribute__((deprecated("")));
        [Export("removeMessages:")]
        [Verify(StronglyTypedNSArray)]
        nuint RemoveMessages(NSObject[] aMessageIds);

        // -(NSUInteger)removeMessagesWithIds:(NSArray *)aMessageIds;
        [Export("removeMessagesWithIds:")]
        [Verify(StronglyTypedNSArray)]
        nuint RemoveMessagesWithIds(NSObject[] aMessageIds);

        // -(BOOL)removeAllMessages;
        [Export("removeAllMessages")]
        [Verify(MethodToProperty)]
        bool RemoveAllMessages { get; }

        // -(NSArray *)loadAllMessages;
        [Export("loadAllMessages")]
        [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] LoadAllMessages { get; }

        // -(EMMessage *)loadMessage:(NSString *)aMessageId __attribute__((deprecated("")));
        [Export("loadMessage:")]
        EMMessage LoadMessage(string aMessageId);

        // -(EMMessage *)loadMessageWithId:(NSString *)aMessageId;
        [Export("loadMessageWithId:")]
        EMMessage LoadMessageWithId(string aMessageId);

        // -(NSArray *)loadMessages:(NSArray *)aMessageIds __attribute__((deprecated("")));
        [Export("loadMessages:")]
        [Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        NSObject[] LoadMessages(NSObject[] aMessageIds);

        // -(NSArray *)loadMessagesWithIds:(NSArray *)aMessageIds;
        [Export("loadMessagesWithIds:")]
        [Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        NSObject[] LoadMessagesWithIds(NSObject[] aMessageIds);

        // -(NSArray *)loadNumbersOfMessages:(NSUInteger)aCount before:(long long)timestamp;
        [Export("loadNumbersOfMessages:before:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] LoadNumbersOfMessages(nuint aCount, long timestamp);

        // -(NSArray *)loadNumbersOfMessages:(NSUInteger)aCount withMessageId:(NSString *)messageId;
        [Export("loadNumbersOfMessages:withMessageId:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] LoadNumbersOfMessages(nuint aCount, string messageId);

        // -(NSArray *)loadNumbersOfMessages:(NSUInteger)aCount bodyType:(MessageBodyType)type before:(long long)timestamp;
        [Export("loadNumbersOfMessages:bodyType:before:")]
        [Verify(StronglyTypedNSArray)]
        NSObject[] LoadNumbersOfMessages(nuint aCount, MessageBodyType type, long timestamp);

        // -(EMMessage *)latestMessage;
        [Export("latestMessage")]
        [Verify(MethodToProperty)]
        EMMessage LatestMessage { get; }

        // -(EMMessage *)latestMessageFromOthers;
        [Export("latestMessageFromOthers")]
        [Verify(MethodToProperty)]
        EMMessage LatestMessageFromOthers { get; }

        // -(NSUInteger)markMessagesAsRead:(BOOL)isRead __attribute__((deprecated("")));
        [Export("markMessagesAsRead:")]
        nuint MarkMessagesAsRead(bool isRead);

        // -(BOOL)markAllMessagesAsRead:(BOOL)isRead;
        [Export("markAllMessagesAsRead:")]
        bool MarkAllMessagesAsRead(bool isRead);

        // -(BOOL)markMessage:(NSString *)aMessageId asRead:(BOOL)isRead __attribute__((deprecated("")));
        [Export("markMessage:asRead:")]
        bool MarkMessage(string aMessageId, bool isRead);

        // -(BOOL)markMessageWithId:(NSString *)aMessageId asRead:(BOOL)isRead;
        [Export("markMessageWithId:asRead:")]
        bool MarkMessageWithId(string aMessageId, bool isRead);

        // -(NSUInteger)unreadMessagesCount;
        [Export("unreadMessagesCount")]
        [Verify(MethodToProperty)]
        nuint UnreadMessagesCount { get; }
    }

    // @interface EMReceiptBase : NSObject
    [BaseType(typeof(NSObject))]
    interface EMReceiptBase
    {
        // @property (copy, nonatomic) NSString * from;
        [Export("from")]
        string From { get; set; }

        // @property (copy, nonatomic) NSString * to;
        [Export("to")]
        string To { get; set; }

        // @property (copy, nonatomic) NSString * chatId;
        [Export("chatId")]
        string ChatId { get; set; }

        // @property (nonatomic) BOOL isGroup;
        [Export("isGroup")]
        bool IsGroup { get; set; }

        // @property (nonatomic) EMReceiptType type;
        [Export("type", ArgumentSemantic.Assign)]
        EMReceiptType Type { get; set; }

        // @property (nonatomic) long long timestamp;
        [Export("timestamp")]
        long Timestamp { get; set; }
    }

    // @interface EMReceipt : EMReceiptBase
    [BaseType(typeof(EMReceiptBase))]
    interface EMReceipt
    {
        // @property (nonatomic, strong) NSString * conversationChatter;
        [Export("conversationChatter", ArgumentSemantic.Strong)]
        string ConversationChatter { get; set; }

        // @property (assign, nonatomic) BOOL isAnonymous;
        [Export("isAnonymous")]
        bool IsAnonymous { get; set; }

        // +(EMReceipt *)createFromMessage:(EMMessage *)message type:(EMReceiptType)type;
        [Static]
        [Export("createFromMessage:type:")]
        EMReceipt CreateFromMessage(EMMessage message, EMReceiptType type);
    }

    // @interface EMError : NSObject
    [BaseType(typeof(NSObject))]
    interface EMError
    {
        // @property (nonatomic) EMErrorType errorCode;
        [Export("errorCode", ArgumentSemantic.Assign)]
        EMErrorType ErrorCode { get; set; }

        // @property (copy, nonatomic) NSString * description;
        [Export("description")]
        string Description { get; set; }

        // +(EMError *)errorWithCode:(EMErrorType)errCode andDescription:(NSString *)description;
        [Static]
        [Export("errorWithCode:andDescription:")]
        EMError ErrorWithCode(EMErrorType errCode, string description);

        // +(EMError *)errorWithNSError:(NSError *)error;
        [Static]
        [Export("errorWithNSError:")]
        EMError ErrorWithNSError(NSError error);
    }

    // @interface EMPushNotificationOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface EMPushNotificationOptions
    {
        // @property (nonatomic, strong) NSString * nickname;
        [Export("nickname", ArgumentSemantic.Strong)]
        string Nickname { get; set; }

        // @property (nonatomic) EMPushNotificationDisplayStyle displayStyle;
        [Export("displayStyle", ArgumentSemantic.Assign)]
        EMPushNotificationDisplayStyle DisplayStyle { get; set; }

        // @property (nonatomic) BOOL noDisturbing __attribute__((deprecated("")));
        [Export("noDisturbing")]
        bool NoDisturbing { get; set; }

        // @property (nonatomic) EMPushNotificationNoDisturbStatus noDisturbStatus;
        [Export("noDisturbStatus", ArgumentSemantic.Assign)]
        EMPushNotificationNoDisturbStatus NoDisturbStatus { get; set; }

        // @property (nonatomic) NSUInteger noDisturbingStartH;
        [Export("noDisturbingStartH")]
        nuint NoDisturbingStartH { get; set; }

        // @property (nonatomic) NSUInteger noDisturbingStartM;
        [Export("noDisturbingStartM")]
        nuint NoDisturbingStartM { get; set; }

        // @property (nonatomic) NSUInteger noDisturbingEndH;
        [Export("noDisturbingEndH")]
        nuint NoDisturbingEndH { get; set; }

        // @property (nonatomic) NSUInteger noDisturbingEndM;
        [Export("noDisturbingEndM")]
        nuint NoDisturbingEndM { get; set; }

        // @property (nonatomic, strong) NSString * backupType;
        [Export("backupType", ArgumentSemantic.Strong)]
        string BackupType { get; set; }

        // @property (nonatomic, strong) NSString * backupVersion;
        [Export("backupVersion", ArgumentSemantic.Strong)]
        string BackupVersion { get; set; }

        // @property (nonatomic) NSUInteger backupDataSize;
        [Export("backupDataSize")]
        nuint BackupDataSize { get; set; }

        // @property (nonatomic) NSTimeInterval backupTimeInterval;
        [Export("backupTimeInterval")]
        double BackupTimeInterval { get; set; }

        // @property (nonatomic, strong) NSString * backupPaths;
        [Export("backupPaths", ArgumentSemantic.Strong)]
        string BackupPaths { get; set; }
    }

    // @protocol IEMChatProgressDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IEMChatProgressDelegate
    {
        // @optional -(void)setProgress:(float)progress forMessage:(EMMessage *)message __attribute__((deprecated("")));
        [Export("setProgress:forMessage:")]
        void ForMessage(float progress, EMMessage message);

        // @optional -(void)setProgress:(float)progress;
        [Export("setProgress:")]
        void SetProgress(float progress);

        // @required -(void)setProgress:(float)progress forMessage:(EMMessage *)message forMessageBody:(id<IEMMessageBody>)messageBody;
        [Abstract]
        [Export("setProgress:forMessage:forMessageBody:")]
        void ForMessage(float progress, EMMessage message, IEMMessageBody messageBody);
    }

    // @interface EaseMob : NSObject <UIApplicationDelegate>
    [BaseType(typeof(NSObject))]
    interface EaseMob : IUIApplicationDelegate
    {
        // @property (readonly, nonatomic, strong) id<IChatManager> chatManager;
        [Export("chatManager", ArgumentSemantic.Strong)]
        IChatManager ChatManager { get; }

        // @property (readonly, nonatomic, strong) id<IDeviceManager> deviceManager;
        [Export("deviceManager", ArgumentSemantic.Strong)]
        IDeviceManager DeviceManager { get; }

        // @property (readonly, nonatomic, strong) NSString * sdkVersion;
        [Export("sdkVersion", ArgumentSemantic.Strong)]
        string SdkVersion { get; }

        // +(EaseMob *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        [Verify(MethodToProperty)]
        EaseMob SharedInstance { get; }

        // -(EMError *)registerSDKWithAppKey:(NSString *)anAppKey __attribute__((deprecated("")));
        [Export("registerSDKWithAppKey:")]
        EMError RegisterSDKWithAppKey(string anAppKey);

        // -(EMError *)registerSDKWithAppKey:(NSString *)anAppKey apnsCertName:(NSString *)anAPNSCertName;
        [Export("registerSDKWithAppKey:apnsCertName:")]
        EMError RegisterSDKWithAppKey(string anAppKey, string anAPNSCertName);

        // -(EMError *)registerSDKWithAppKey:(NSString *)anAppKey apnsCertName:(NSString *)anAPNSCertName otherConfig:(NSDictionary *)anOtherConfig;
        [Export("registerSDKWithAppKey:apnsCertName:otherConfig:")]
        EMError RegisterSDKWithAppKey(string anAppKey, string anAPNSCertName, NSDictionary anOtherConfig);

        // -(void)enableBackgroundReceiveMessage __attribute__((deprecated("")));
        [Export("enableBackgroundReceiveMessage")]
        void EnableBackgroundReceiveMessage();

        // -(void)enableUncaughtExceptionHandler;
        [Export("enableUncaughtExceptionHandler")]
        void EnableUncaughtExceptionHandler();
    }

    // @protocol ICallManagerBase <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ICallManagerBase
    {
        // @required -(void)addDelegate:(id<EMCallManagerDelegate>)delegate delegateQueue:(dispatch_queue_t)queue;
        [Abstract]
        [Export("addDelegate:delegateQueue:")]
        void AddDelegate(EMCallManagerDelegate @delegate, DispatchQueue queue);

        // @required -(void)removeDelegate:(id<EMCallManagerDelegate>)delegate;
        [Abstract]
        [Export("removeDelegate:")]
        void RemoveDelegate(EMCallManagerDelegate @delegate);
    }

    // @protocol ICallManagerCall <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ICallManagerCall
    {
        // @required -(EMError *)asyncAnswerCall:(NSString *)sessionId;
        [Abstract]
        [Export("asyncAnswerCall:")]
        EMError AsyncAnswerCall(string sessionId);

        // @required -(EMError *)asyncEndCall:(NSString *)sessionId reason:(EMCallStatusChangedReason)reason;
        [Abstract]
        [Export("asyncEndCall:reason:")]
        EMError AsyncEndCall(string sessionId, EMCallStatusChangedReason reason);

        // @required -(EMError *)markCallSession:(NSString *)sessionId asSilence:(BOOL)isSilence;
        [Abstract]
        [Export("markCallSession:asSilence:")]
        EMError MarkCallSession(string sessionId, bool isSilence);

        // @required -(EMCallSession *)asyncMakeVoiceCall:(NSString *)chatter timeout:(NSUInteger)timeout error:(EMError **)pError;
        [Abstract]
        [Export("asyncMakeVoiceCall:timeout:error:")]
        EMCallSession AsyncMakeVoiceCall(string chatter, nuint timeout, out EMError pError);

        // @required -(EMCallSession *)asyncMakeVideoCall:(NSString *)chatter timeout:(NSUInteger)timeout error:(EMError **)pError;
        [Abstract]
        [Export("asyncMakeVideoCall:timeout:error:")]
        EMCallSession AsyncMakeVideoCall(string chatter, nuint timeout, out EMError pError);

        // @required -(void)processPreviewData:(char *)data width:(int)width height:(int)height;
        [Abstract]
        [Export("processPreviewData:width:height:")]
        unsafe void ProcessPreviewData(sbyte* data, int width, int height);

        // @required -(int)getVideoTimedelay;
        [Abstract]
        [Export("getVideoTimedelay")]
        [Verify(MethodToProperty)]
        int VideoTimedelay { get; }

        // @required -(int)getVideoFramerate;
        [Abstract]
        [Export("getVideoFramerate")]
        [Verify(MethodToProperty)]
        int VideoFramerate { get; }

        // @required -(int)getVideoLostcnt;
        [Abstract]
        [Export("getVideoLostcnt")]
        [Verify(MethodToProperty)]
        int VideoLostcnt { get; }

        // @required -(int)getVideoWidth;
        [Abstract]
        [Export("getVideoWidth")]
        [Verify(MethodToProperty)]
        int VideoWidth { get; }

        // @required -(int)getVideoHeight;
        [Abstract]
        [Export("getVideoHeight")]
        [Verify(MethodToProperty)]
        int VideoHeight { get; }

        // @required -(int)getVideoRemoteBitrate;
        [Abstract]
        [Export("getVideoRemoteBitrate")]
        [Verify(MethodToProperty)]
        int VideoRemoteBitrate { get; }

        // @required -(int)getVideoLocalBitrate;
        [Abstract]
        [Export("getVideoLocalBitrate")]
        [Verify(MethodToProperty)]
        int VideoLocalBitrate { get; }

        // @optional -(EMError *)asyncAcceptCallSessionWithId:(NSString *)sessionId __attribute__((deprecated("")));
        [Export("asyncAcceptCallSessionWithId:")]
        EMError AsyncAcceptCallSessionWithId(string sessionId);

        // @optional -(EMError *)asyncTerminateCallSessionWithId:(NSString *)sessionId reason:(EMCallStatusChangedReason)reason __attribute__((deprecated("")));
        [Export("asyncTerminateCallSessionWithId:reason:")]
        EMError AsyncTerminateCallSessionWithId(string sessionId, EMCallStatusChangedReason reason);

        // @optional -(EMCallSession *)asyncCallAudioWithChatter:(NSString *)chatter timeout:(NSUInteger)timeout error:(EMError **)pError __attribute__((deprecated("")));
        [Export("asyncCallAudioWithChatter:timeout:error:")]
        EMCallSession AsyncCallAudioWithChatter(string chatter, nuint timeout, out EMError pError);
    }

    // @protocol ICallManager <ICallManagerBase, ICallManagerCall>
    [Protocol, Model]
    interface ICallManager : IICallManagerBase, IICallManagerCall
    {
    }

    // @protocol EMCallManagerCallDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface EMCallManagerCallDelegate
    {
        // @optional -(void)callSessionStatusChanged:(EMCallSession *)callSession changeReason:(EMCallStatusChangedReason)reason error:(EMError *)error;
        [Export("callSessionStatusChanged:changeReason:error:")]
        void ChangeReason(EMCallSession callSession, EMCallStatusChangedReason reason, EMError error);
    }

    // @protocol EMCallManagerDelegate <EMCallManagerCallDelegate>
    [Protocol, Model]
    interface EMCallManagerDelegate : IEMCallManagerCallDelegate
    {
    }

    // @interface EMCallSession : NSObject
    [BaseType(typeof(NSObject))]
    interface EMCallSession
    {
        // @property (readonly, nonatomic, strong) NSString * sessionId;
        [Export("sessionId", ArgumentSemantic.Strong)]
        string SessionId { get; }

        // @property (nonatomic, strong) NSString * sessionChatter;
        [Export("sessionChatter", ArgumentSemantic.Strong)]
        string SessionChatter { get; set; }

        // @property (readonly, nonatomic) EMCallSessionType type;
        [Export("type")]
        EMCallSessionType Type { get; }

        // @property (readonly, nonatomic) EMCallSessionStatus status;
        [Export("status")]
        EMCallSessionStatus Status { get; }

        // @property (readonly, nonatomic) EMCallConnectType connectType;
        [Export("connectType")]
        EMCallConnectType ConnectType { get; }

        // @property (nonatomic, strong) OpenGLView20 * displayView;
        [Export("displayView", ArgumentSemantic.Strong)]
        OpenGLView20 DisplayView { get; set; }

        // -(instancetype)initWithSessionId:(NSString *)sessionId;
        [Export("initWithSessionId:")]
        IntPtr Constructor(string sessionId);
    }

    // @protocol IOpenGLView <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IOpenGLView
    {
        // @required -(void)displayYUV420pData:(char *)data width:(GLuint)width height:(GLuint)height;
        [Abstract]
        [Export("displayYUV420pData:width:height:")]
        unsafe void DisplayYUV420pData(sbyte* data, uint width, uint height);

        // @required -(void)setVideoSize:(GLuint)width height:(GLuint)height;
        [Abstract]
        [Export("setVideoSize:height:")]
        void SetVideoSize(uint width, uint height);

        // @required -(void)clearFrame;
        [Abstract]
        [Export("clearFrame")]
        void ClearFrame();
    }

    // @interface OpenGLView20 : UIView <IOpenGLView>
    [BaseType(typeof(UIView))]
    interface OpenGLView20 : IIOpenGLView
    {
        // @property (nonatomic, strong) NSString * sessionPreset;
        [Export("sessionPreset", ArgumentSemantic.Strong)]
        string SessionPreset { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary * outputSettings;
        [Export("outputSettings", ArgumentSemantic.Strong)]
        NSDictionary OutputSettings { get; }

        // @property (readonly, nonatomic) CMTime videoMinFrameDuration;
        [Export("videoMinFrameDuration")]
        CMTime VideoMinFrameDuration { get; }
    }

    // @interface CallService (EaseMob)
    [Category]
    [BaseType(typeof(EaseMob))]
    interface EaseMob_CallService
    {
        // @property (readonly, nonatomic, strong) id<ICallManager> callManager;
        [Export("callManager", ArgumentSemantic.Strong)]
        ICallManager CallManager { get; }
    }
}
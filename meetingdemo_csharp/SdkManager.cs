using System;
using System.Collections.Generic;
using System.Windows.Forms;
using fspclr;

namespace meetingdemo_csharp
{
    public struct AudioDeviceInfo
    {
        public int devId { get; set; }
        public String devName { get; set; }
    }

    public struct VideoDeviceInfo
    {
        public int cameraId { get; set; }
        public String devName { get; set; }
    }

    public enum ScreenShareMode
    {
        SCREEN_SHARE_MODE_DESKTOP,
        SCREEN_SHARE_MODE_REGION
    }

    class SdkManager
    {
        private String appId;
        private String appSecret;

        // Thread syncrolization
        private Object syncLock = new Object();

        // Singleton
        private static SdkManager instance = new SdkManager();
        public static SdkManager Instance()
        {
            return instance;
        }

        // User ID and Group ID
        public String UserId { get; set; }
        public String GroupId { get; set; }

        // Callback delegate
        delegate void CommonEventCallback(CommonEventClr commonEvent, ErrCodeClr errCode);
        delegate void DeviceEventCallback(DeviceEventClr deviceEvent);
        delegate void RemoteAudioEventCallback(String userId, RemoteAudioEventClr remoteAudioEvent);
        delegate void RemoteVideoEventCallback(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent);
        delegate void RemoteControlEventCallback(String userId, RemoteControlOperationTypeClr opType);
        delegate void GroupUserRefreshedCallback(List<String> useList);
        delegate void RemoteUserEventCallback(String remoteUserId, RemoteUserEventTypeClr eventType);
        delegate void InviteComeCallback(String inviterUserId, int inviteId, String groupid, String msg);
        delegate void IniviteAcceptedCallback(String remoteUserId, int invitedId);
        delegate void IniviteRejectedCallback(String remoteUserId, int invitedId);
        delegate void UserMsgComeCallback(String senderUserId, int msgId, String msg);
        delegate void GroupMsgComeCallback(String senderUserId, int msgId, String msg);
        delegate void UserStateRefreshedCallback(ErrCodeClr ec, int requetId, List<UserInfoClr> users);
        delegate void UserStateChangeCallback(UserInfoClr userInfo);

        // Property to access forms
        public LoginForm LoginForm { get; set; }
        public OnlineForm OnlineForm { get; set; }
        public MainForm MainForm { get; set; }

        // Transfer to UI thread

        // 登录、加入分组事件处理
        private void OnFspCommonEvent(CommonEventClr commonEvent, ErrCodeClr errCode)
        {
            if (commonEvent == CommonEventClr.CLR_COMMONEVENT_LOGIN_RESULT)
            { 
                CommonEventCallback cb = new CommonEventCallback(LoginForm.LoginResultHandler);
                LoginForm.Invoke(cb, new object[] { commonEvent, errCode });
            }
            else if (commonEvent == CommonEventClr.CLR_COMMONEVENT_JOINGROUP_RESULT)
            {
                CommonEventCallback cb = new CommonEventCallback(OnlineForm.JoinGroupResultHandler);
                OnlineForm.Invoke(cb, new object[] { commonEvent, errCode });
            }
            else
            {
                ; // TODO:
            }
        }

        // 音视频设备热插拔事件处理
        private void OnFspDeviceEvent(DeviceEventClr deviceEvent)
        {

        }

        // 远端广播音频事件处理
        private void OnFspRemoteAudioEvent(String userId, RemoteAudioEventClr remoteAudioEvent)
        {
            if (MainForm != null)
            {
                RemoteAudioEventCallback cb = new RemoteAudioEventCallback(MainForm.RemoteAudioEventHandler);
                MainForm.Invoke(cb, new object[] { userId, remoteAudioEvent });
            }
        }

        // 远端广播视频事件处理
        private void OnFspRemoteVideoEvent(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent)
        {
            if (MainForm != null)
            {
                RemoteVideoEventCallback cb = new RemoteVideoEventCallback(MainForm.RemoteVideoEventHandler);
                MainForm.Invoke(cb, new object[] { userId, videoId, remoteVideoEvent });
            }
        }

        // 屏幕共享远程控制事件处理
        private void OnFspRemoteControlEvent(String userId, RemoteControlOperationTypeClr opType)
        {
        }

        private void OnFspGroupUserRefreshed(List<String> userList)
        {
            if (MainForm != null)
            {
                GroupUserRefreshedCallback cb = new GroupUserRefreshedCallback(MainForm.GroupUserRefreshedHandler);
                MainForm.Invoke(cb, new object[] { userList });
            }
        }
    
        private void OnFspRemoteUserEvent(String remoteUserId, RemoteUserEventTypeClr eventType)
        {
            if (MainForm != null)
            {
                RemoteUserEventCallback cb = new RemoteUserEventCallback(MainForm.RemoteUserEventHandler);
                MainForm.Invoke(cb, new object[] { remoteUserId, eventType });
            }
        }

        private void OnFspUserStateRefreshed(ErrCodeClr errCode, int requestId, List<UserInfoClr> userInfoList)
        {
            if (OnlineForm != null)
            {
                UserStateRefreshedCallback cb = new UserStateRefreshedCallback(OnlineForm.OnUserStateRefreshed);
                OnlineForm.Invoke(cb, new object[] { errCode, requestId, userInfoList });
            }
        }

        private void OnFspUserStateChange(UserInfoClr userInfo)
        {
            if (OnlineForm != null)
            {
                UserStateChangeCallback cb = new UserStateChangeCallback(OnlineForm.OnUserStateChange);
                OnlineForm.Invoke(cb, new object[] { userInfo });
            }
        }

        private void OnFspInviteCome(String inviterUserId, int inviteId, String groupId, String msg)
        {
            if (OnlineForm != null)
            {
                InviteComeCallback cb = new InviteComeCallback(OnlineForm.OnInviteCome);
                OnlineForm.BeginInvoke(cb, new object[] { inviterUserId, inviteId, groupId, msg });
            }
        }

        private void OnFspInviteAccepted(String remoteUserId, int inviteId)
        {
            MessageBox.Show(String.Format("OnFspInviteAccepted: {0} {1}", remoteUserId, inviteId));
        }

        private void OnFspInviteRejected(String remoteUserId, int inviteId)
        {
            MessageBox.Show(String.Format("OnFspInviteRejected: {0} {1}", remoteUserId, inviteId));
        }

        private void OnFspUserMsgCome(String senderUserId, int msgId, String msg)
        {
            if (MainForm != null)
            {
                UserMsgComeCallback cb = new UserMsgComeCallback(MainForm.UserMsgComeHandler);
                MainForm.Invoke(cb, new object[] { senderUserId, msgId, msg });
            }
        }

        private void OnFspGroupMsgCome(String senderUserId, int msgId, String msg)
        {
            if (MainForm != null)
            {
                GroupMsgComeCallback cb = new GroupMsgComeCallback(MainForm.GroupMsgComeHandler);
                MainForm.Invoke(cb, new object[] { senderUserId, msgId, msg });
            }
        }

        public bool Init(String appId, String appSecret, String serverAddr)
        {
            ErrCodeClr result = FspEngineClr.Instance.Init(appId, "./", serverAddr);
            if (result != ErrCodeClr.CLR_ERR_OK)
                return false;

            // Save app info
            this.appId = appId;
            this.appSecret = appSecret;

            // Callbacks
            FspEngineClr.Instance.commonEventHandler = OnFspCommonEvent;
            FspEngineClr.Instance.deviceEventHandler = OnFspDeviceEvent;
            FspEngineClr.Instance.remoteAudioEventHandler = OnFspRemoteAudioEvent;
            FspEngineClr.Instance.remoteVideoEventHandler = OnFspRemoteVideoEvent;
            FspEngineClr.Instance.remoteControlEventHandler = OnFspRemoteControlEvent;
            FspEngineClr.Instance.groupUsersRefreshedHandler = OnFspGroupUserRefreshed;
            FspEngineClr.Instance.remoteUserEventHandler = OnFspRemoteUserEvent;
            FspEngineClr.Instance.inviteComeHandler = OnFspInviteCome;
            FspEngineClr.Instance.inviteAcceptedHandler = OnFspInviteAccepted;
            FspEngineClr.Instance.inviteRejectedHandler = OnFspInviteRejected;
            FspEngineClr.Instance.userMsgComeHandler = OnFspUserMsgCome;
            FspEngineClr.Instance.groupMsgComeHandler = OnFspGroupMsgCome;
            FspEngineClr.Instance.userStateRefreshedHandler = OnFspUserStateRefreshed;
            FspEngineClr.Instance.userStateChangeHandler = OnFspUserStateChange;

            return true;
        }

        public void Destroy()
        {
            lock(syncLock)
            {
                FspEngineClr.Instance.Destory();
            }
        }

        public bool Login(String userId)
        {
            // 生成Token，考虑到账号安全性，建议在服务器生成Token!!!
            String token = TokenGenerator.GenerateToken(appId, appSecret, "", userId);
            
            return (ErrCodeClr.CLR_ERR_OK == FspEngineClr.Instance.Login(token, userId));
        }

        public void Logout()
        {
            FspEngineClr.Instance.Logout();
        }

        public ErrCodeClr JoinGroup(String groupId)
        {
            return FspEngineClr.Instance.JoinGroup(groupId);
        }

        public ErrCodeClr LeaveGroup()
        {
            return FspEngineClr.Instance.LeaveGroup();
        }

        public void GetOnlineUserList()
        {
            int requestId = 1;
            List<String> userList = new List<string>(); 
            
            FspEngineClr.Instance.UserStatusRefresh(userList, ref requestId);
        }

        public void StartPublishLocalCam(int cameraId, int renderWnd, RenderModeClr renderMode)
        {
            FspEngineClr.Instance.AddVideoPreview(cameraId, renderWnd, renderMode);
            FspEngineClr.Instance.StartPublishVideo(cameraId.ToString(), cameraId);
        }

        public void StopPublishLocalCam(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.RemoveVideoPreview(cameraId, renderWnd);
            FspEngineClr.Instance.StopPublishVideo(cameraId.ToString());
        }

        public void OpenRemoteVideo(String userId, String videoId, int renderWnd, RenderModeClr renderMode)
        {
            FspEngineClr.Instance.SetRemoteVideoRender(userId, videoId, renderWnd, renderMode);
        }

        public void CloseRemoteVideo(String userId, String videoId)
        {
            FspEngineClr.Instance.SetRemoteVideoRender(userId, videoId, 0, 0);
        }

        public void StartPublishLocalMic()
        {
            FspEngineClr.Instance.StartPublishAudio();
        }

        public void StopPublishLocalMic()
        {
            FspEngineClr.Instance.StopPublishAudio();
        }

        public void OpenRemoteAudio(String userId)
        {
            FspEngineClr.Instance.MuteRemoteAudio(userId, false);
        }

        public void CloseRemoteAudio(String userId)
        {
            FspEngineClr.Instance.MuteRemoteAudio(userId, true);
        }

        public int GetLocalMicEnergy()
        {
            return FspEngineClr.Instance.GetAudioParam(AudioParamKeyClr.CLR_AUDIOPARAM_MICROPHONE_ENERGY);
        }

        public int GetLocalSpkEnergy()
        {
            return FspEngineClr.Instance.GetAudioParam(AudioParamKeyClr.CLR_AUDIOPARAM_SPEAKER_ENERGY);
        }

        public int GetRemoteMicEnergy(String userId)
        {
            return FspEngineClr.Instance.GetRemoteAudioEnergy(userId);
        }

        public VideoStatsInfoClr GetVideoStats(String userId, String videoId)
        {
            VideoStatsInfoClr videoStats = new VideoStatsInfoClr();
            FspEngineClr.Instance.GetVideoStats(userId, videoId, videoStats);
            return videoStats;
        }

        public void SetVideoRenderMode(int renderWnd, RenderModeClr renderMode)
        {
            //return FspEngineClr.Instance.
        }

       public ErrCodeClr StartRecord(String filePath)
        {
            return FspEngineClr.Instance.StartRecord(filePath, true);
        }

        public void StopRecord()
        {
            FspEngineClr.Instance.StopRecord();
        }

        public ErrCodeClr StartShareDesktop(ScreenShareQualityBiasClr qosType)
        {
            return FspEngineClr.Instance.StartPublishScreenShare(0, 0, 0, 0, qosType);
        }

        public ErrCodeClr StartShareRegion(System.Drawing.Rectangle shareRect, ScreenShareQualityBiasClr qosType)
        {
            return FspEngineClr.Instance.StartPublishScreenShare(shareRect.Left, shareRect.Top, shareRect.Right, shareRect.Bottom, qosType);
        }

        public void StopScreenshare()
        {
            FspEngineClr.Instance.StopPublishScreenShare();
        }

        public List<VideoDeviceInfo> GetLocalCameraList()
        {
            List<VideoDeviceInfo> camList = new List<VideoDeviceInfo>();
            foreach (VideoDeviceInfoClr device in FspEngineClr.Instance.GetCameraDevices())
            {
                VideoDeviceInfo devInfo = new VideoDeviceInfo();
                devInfo.cameraId = device.cameraId;
                devInfo.devName = device.deviceName;

                camList.Add(devInfo);
            }

            return camList;
        }

        public List<AudioDeviceInfo> GetLocalMicrophoneList()
        {
            List<AudioDeviceInfo> micList = new List<AudioDeviceInfo>();

            foreach (AudioDeviceInfoClr device in FspEngineClr.Instance.GetMicrophoneDevices())
            {
                AudioDeviceInfo devInfo = new AudioDeviceInfo();
                devInfo.devId = device.deviceId;
                devInfo.devName = device.deviceName;

                micList.Add(devInfo);
            }

            return micList;
        }

        public List<AudioDeviceInfo> GetLocalSpeakerList()
        {
            List<AudioDeviceInfo> spkList = new List<AudioDeviceInfo>();

            foreach (AudioDeviceInfoClr device in FspEngineClr.Instance.GetSpeakerDevices())
            {
                AudioDeviceInfo devInfo = new AudioDeviceInfo();
                devInfo.devId = device.deviceId;
                devInfo.devName = device.deviceName;

                spkList.Add(devInfo);
            }

            return spkList;
        }

        public void SetCurrentMicrophone(int micId)
        {
            FspEngineClr.Instance.SetMicrophoneDevice(micId);
        }

        public void SetCurrentSpeaker(int spkId)
        {
            FspEngineClr.Instance.SetSpeakerDevice(spkId);
        }

        public void SetMicVolumn(int volumn)
        {
            FspEngineClr.Instance.SetAudioParam(AudioParamKeyClr.CLR_AUDIOPARAM_MICROPHONE_VOLUME, volumn);
        }

        public void SetSpkVolumn(int volumn)
        {
            FspEngineClr.Instance.SetAudioParam(AudioParamKeyClr.CLR_AUDIOPARAM_SPEAKER_VOLUME, volumn);
        }

        public void SetVideoProfile(String videoId, VideoProfileClr profile)
        {
            FspEngineClr.Instance.SetVideoProfile(videoId, profile);
        }

        public void AddVideoPreview(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.AddVideoPreview(cameraId, renderWnd, RenderModeClr.CLR_RENDERMODE_FIT_CENTER);
        }

        public void DelVideoPreview(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.RemoveVideoPreview(cameraId, renderWnd);
        }

        public void SendUserMsg(String toUserId, String msg, ref int msgId)
        {
            FspEngineClr.Instance.SendUserMsg(toUserId, msg, ref msgId);
        }

        public void SendGroupMsg(String msg, ref int msgId)
        {
            FspEngineClr.Instance.SendGroupMsg(msg, ref msgId);
        }

        public void SendGroupMsgWithWhiteList(List<String> whiteUserList, String msg, ref int msgId)
        {
            FspEngineClr.Instance.SendGroupMsgWithWhiteList(whiteUserList, msg, ref msgId);
        }

        public void SendGroupMsgWithBlackList(List<String> blackUserList, String msg, ref int msgId)
        {
            FspEngineClr.Instance.SendGroupMsgWithBlackList(blackUserList, msg, ref msgId);
        }

        public void Invite(List<String> userList, String groupId, String msg, ref int inviteId)
        {
            ErrCodeClr ec = FspEngineClr.Instance.Invite(userList, groupId, msg, ref inviteId);
        }

        public void AcceptInivte(String inviterUserId, int inviteId)
        {
            FspEngineClr.Instance.AcceptInvite(inviterUserId, inviteId);
        }

        public void RejectInivte(String inviterUserId, int inviteId)
        {
            FspEngineClr.Instance.RejectInvite(inviterUserId, inviteId);
        }

        public String RESERVED_VIDEOID_SCREENSHARE
        {
            get { return FspEngineClr.RESERVED_VIDEOID_SCREENSHARE; }
        }
    }
}

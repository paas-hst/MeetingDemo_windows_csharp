using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fspclr;

namespace MeetingDemo
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

    class SdkManager
    {
        // Default APP parameters
        private const String APP_ID = "925aa51ebf829d49fc98b2fca5d963bc";
        private const String APP_SECRET = "d52be60bb810d17e";

        // Thread syncrolization
        private Object syncLock = new Object();
        
        // Singleton
        private static SdkManager instance = new SdkManager();
        public static SdkManager Instance()
        {
            return instance;
        }

        // Callback delegate
        delegate void CommonEventCallback(CommonEventClr commonEvent, ErrCodeClr errCode);
        delegate void DeviceEventCallback(DeviceEventClr deviceEvent);
        delegate void RemoteAudioEventCallback(String userId, RemoteAudioEventClr remoteAudioEvent);
        delegate void RemoteVideoEventCallback(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent);

        // Property to access forms
        public LoginForm loginForm { get; set; }
        public MainForm mainForm { get; set; }

        // Transfer to UI thread
        private void onFspCommonEvent(CommonEventClr commonEvent, ErrCodeClr errCode)
        {
            lock(syncLock)
            {
                CommonEventCallback cb = new CommonEventCallback(loginForm.CommonEventHandler);
                loginForm.Invoke(cb, new object[] { commonEvent, errCode });
            }
        }

        private void onFspDeviceEvent(DeviceEventClr deviceEvent)
        {

        }

        private void onFspRemoteAudioEvent(String userId, RemoteAudioEventClr remoteAudioEvent)
        {
            lock(syncLock)
            {
                RemoteAudioEventCallback cb = new RemoteAudioEventCallback(mainForm.RemoteAudioEventHandler);
                mainForm.Invoke(cb, new object[] { userId, remoteAudioEvent });
            }
        }

        private void onFspRemoteVideoEvent(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent)
        {
            lock(syncLock)
            {
                RemoteVideoEventCallback cb = new RemoteVideoEventCallback(mainForm.RemoteVideoEventHandler);
                mainForm.Invoke(cb, new object[] { userId, videoId, remoteVideoEvent });
            }
        }

        public bool Init()
        {
            ErrCodeClr result = FspEngineClr.Instance.Init(APP_ID, "./", "");
            if (result != ErrCodeClr.CLR_ERR_OK)
                return false;

            // Callbacks
            FspEngineClr.Instance.commonEventHandler = onFspCommonEvent;
            FspEngineClr.Instance.deviceEventHandler = onFspDeviceEvent;
            FspEngineClr.Instance.remoteAudioEventHandler = onFspRemoteAudioEvent;
            FspEngineClr.Instance.remoteVideoEventHandler = onFspRemoteVideoEvent;

            return true;
        }

        public void Destroy()
        {
            lock(syncLock)
            {
                FspEngineClr.Instance.Destory();
            }
        }

        public ErrCodeClr JoinGroup(String groupId, String userId)
        {
            // 生成Token，考虑到账号安全性，建议在服务器生成Token!!!
            String token = TokenGenerator.GenerateToken(APP_ID, APP_SECRET, groupId, userId);

            return FspEngineClr.Instance.JoinGroup(token, groupId, userId);
        }

        public ErrCodeClr LeaveGroup()
        {
            return FspEngineClr.Instance.LeaveGroup();
        }

        public void StartPublishLocalCam(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.AddVideoPreview(cameraId, renderWnd);
            FspEngineClr.Instance.StartPublishVideo(cameraId.ToString(), cameraId);
        }

        public void StopPublishLocalCam(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.RemoveVideoPreview(cameraId, renderWnd);
            FspEngineClr.Instance.StopPublishVideo(cameraId.ToString());
        }

        public void OpenRemoteVideo(String userId, String videoId, int renderWnd)
        {
            FspEngineClr.Instance.HandleRemoteVideo(userId, videoId, fspclr.RemoteVideoOperateClr.CLR_REMOTE_VIDEO_OPEN);
            FspEngineClr.Instance.SetRemoteVideoRender(userId, videoId, renderWnd);
        }

        public void CloseRemoteVideo(String userId, String videoId)
        {
            FspEngineClr.Instance.HandleRemoteVideo(userId, videoId, fspclr.RemoteVideoOperateClr.CLR_REMOTE_VIDEO_CLOSE);
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
            FspEngineClr.Instance.SetRenderMode(renderWnd, renderMode);
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
            FspEngineClr.Instance.AddVideoPreview(cameraId, renderWnd);
        }

        public void DelVideoPreview(int cameraId, int renderWnd)
        {
            FspEngineClr.Instance.RemoveVideoPreview(cameraId, renderWnd);
        }
    }
}

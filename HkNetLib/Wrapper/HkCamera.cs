using HkNetLib.Common;
using HkNetLib.Hardware;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HkNetLib.Wrapper
{
    public class HkCamera : ICamera
    {
        private bool _disposedValue;
        private bool _sdkInit;
        private int _userId;
        private string _serailNumber;
        private CameraLoginInfo _loginInfo = new CameraLoginInfo();

        /// <summary>
        /// 初始化海康sdk
        /// 
        /// </summary>
        /// <exception cref="BadImageFormatException"></exception>
        public HkCamera()
        {
            _sdkInit = CHCNetSDK.NET_DVR_Init();            
        }

        static HkCamera()
        {
            //设置搜索路径，兼容x86 和 x64
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path,"Lib", IntPtr.Size == 8 ? "x64" : "x86");
            bool ok = SetDllDirectory(path);
            if (!ok) throw new System.ComponentModel.Win32Exception();

        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);
        public string GetLastError()
        {
            var error = CHCNetSDK.NET_DVR_GetLastError();
            if(error == 0)
            {
                return string.Empty;
            }

            if(Enum.TryParse(error.ToString(), out HKErrorCode result))
            {
                return result.GetDesc();
            }

            return $"错误码： {error}";

        }
        public string GetSerialNumber() { return _serailNumber; }
        public bool Login(CameraLoginInfo cameraLoginInfo)
        {
            try
            {
                
                if (_userId >= 0)
                {
                    Logout();
                }
                _loginInfo = cameraLoginInfo;
                var loginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();

                loginInfo.sDeviceAddress = cameraLoginInfo.IP;
                loginInfo.wPort = cameraLoginInfo.Port;
                loginInfo.sUserName = cameraLoginInfo.UserName;
                loginInfo.sPassword = cameraLoginInfo.Password;                
                //是否异步登录：0- 否，1- 是 
                loginInfo.bUseAsynLogin = false;

                var _deviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();
                _userId = CHCNetSDK.NET_DVR_Login_V40(ref loginInfo, ref _deviceInfo);
                _serailNumber =  _deviceInfo.struDeviceV30.sSerialNumber;
                return _userId >= 0;
               
            }
            catch 
            {
                return false;
            }
        }

        public bool IsOnline()
        {
            try
            {
                return CHCNetSDK.NET_DVR_RemoteControl(_userId, CHCNetSDK.NET_DVR_CHECK_USER_STATUS, IntPtr.Zero, 0);
            }
            catch { return false; }
        }
        public void Logout()
        {
            try
            {
                if (_userId >= 0)
                {
                    CHCNetSDK.NET_DVR_Logout(_userId);
                    _userId = -1;
                }
            }
            catch { }
        }

        private bool CheckLogin()
        {
            if (IsOnline()) return true;
            return Login(_loginInfo);
        }
        /// <summary>
        /// 控制云台，设备接收到控制命令后直接返回成功。不关心云台是否进行相应的动作
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="speed">取值范围[1,7] </param>
        /// <returns></returns>
        public bool StartPTZControl(PtzCommand cmd, Int32 speed = 4)
        {
            try
            {
                if (!CheckLogin()) return false;
                
                var result = CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(_userId,_loginInfo.ChannelNo, (uint)cmd, 0, (uint)speed);
                return result;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// 停止云台
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool StopPTZControl(PtzCommand cmd)
        {
            try
            {
                if (!CheckLogin()) return false;
                var result = CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(_userId, _loginInfo.ChannelNo, (uint)cmd, 1, 4);
                return result;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 抓图
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CapturePicture(string fileName)
        {
            if (!CheckLogin()) return false;

            try
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    File.Delete(fi.FullName);
                }
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }

                CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA
                {
                    wPicQuality = 0,
                    wPicSize = 0xff
                };

                return CHCNetSDK.NET_DVR_CaptureJPEGPicture(_userId, _loginInfo.ChannelNo, ref lpJpegPara, fileName);
               
            }
            catch 
            {
                return false;
            }
        }


        public  bool SetFocusMode(FocusModeType focusModeType)
        {            
                bool res = false;
                var destMode = focusModeType;
                CHCNetSDK.NET_DVR_FOCUSMODE_CFG focusmode_cfg = new CHCNetSDK.NET_DVR_FOCUSMODE_CFG();
                focusmode_cfg.byRes = new byte[48];
                focusmode_cfg.byRes1 = new byte[2];
                int nSize = Marshal.SizeOf(focusmode_cfg);
                focusmode_cfg.dwSize = (uint)nSize;
                IntPtr ptrDeviceCfg = Marshal.AllocHGlobal(nSize);

                try
                {
                    // 获取当前模式
                    Marshal.StructureToPtr(focusmode_cfg, ptrDeviceCfg, false);
                    uint rSize = (uint)nSize;
                    if (!CHCNetSDK.NET_DVR_GetDVRConfig(_userId, CHCNetSDK.NET_DVR_GET_FOCUSMODECFG, 1, ptrDeviceCfg, (uint)nSize, ref rSize))
                    {
                        var errorStr = CHCNetSDK.NET_DVR_GetLastError();
                        return res;
                    }

                    // 如果当前模式与请求模式相同，则直接返回true
                    CHCNetSDK.NET_DVR_FOCUSMODE_CFG getObj = (CHCNetSDK.NET_DVR_FOCUSMODE_CFG)Marshal.PtrToStructure(ptrDeviceCfg, typeof(CHCNetSDK.NET_DVR_FOCUSMODE_CFG));
                    var curMode = (FocusModeType)getObj.byFocusMode;
                    if (curMode == destMode)
                    {
                        res = true;
                        return res;
                    }

                    // 否则调用设置方法
                    getObj.fOpticalZoomLevel = 0;
                    getObj.byOpticalZoom = 32;
                    getObj.byFocusMode = (byte)destMode;
                    IntPtr ptrDeviceCfg1 = Marshal.AllocHGlobal((int)getObj.dwSize);
                    Marshal.StructureToPtr(getObj, ptrDeviceCfg1, false);
                    res = CHCNetSDK.NET_DVR_SetDVRConfig(_userId, CHCNetSDK.NET_DVR_SET_FOCUSMODECFG, 1, ptrDeviceCfg1, focusmode_cfg.dwSize);
                    if (!res)
                    {
                        var errorStr = CHCNetSDK.NET_DVR_GetLastError();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Marshal.FreeHGlobal(ptrDeviceCfg);
                }

                return res;           
        }

        /// <summary>
        /// 获取对焦距模式
        /// </summary>
        /// <returns></returns>
        public FocusModeType GetFocusMode()
        {
            FocusModeType retValue = FocusModeType.None;

            CHCNetSDK.NET_DVR_FOCUSMODE_CFG focusmode_cfg = new CHCNetSDK.NET_DVR_FOCUSMODE_CFG
            {
                byRes = new byte[48],
                byRes1 = new byte[2]
            };
            int nSize = Marshal.SizeOf(focusmode_cfg);
            focusmode_cfg.dwSize = (uint)nSize;
            IntPtr ptrDeviceCfg = Marshal.AllocHGlobal(nSize);

            try
            {
                Marshal.StructureToPtr(focusmode_cfg, ptrDeviceCfg, false);
                uint rSize = (uint)nSize;
                if (CHCNetSDK.NET_DVR_GetDVRConfig(this._userId, CHCNetSDK.NET_DVR_GET_FOCUSMODECFG, 1, ptrDeviceCfg, (uint)nSize, ref rSize))
                {
                    CHCNetSDK.NET_DVR_FOCUSMODE_CFG getObj = (CHCNetSDK.NET_DVR_FOCUSMODE_CFG)Marshal.PtrToStructure(ptrDeviceCfg, typeof(CHCNetSDK.NET_DVR_FOCUSMODE_CFG));
                    retValue = (FocusModeType)getObj.byFocusMode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrDeviceCfg);
            }

            return retValue;
        }

        public bool Shutdown()
        {
            try
            {
                if (!CheckLogin()) return false;                

                return CHCNetSDK.NET_DVR_ShutDownDVR(_userId);
               
            }
            catch 
            {
                return false;
            }
        }

        public bool Reboot()
        {
            try
            {
                if (!CheckLogin()) return false;

                return CHCNetSDK.NET_DVR_RebootDVR(_userId);                
            }
            catch 
            {
                return false;
            }
        }

        #region 释放接口
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }                

                if (_sdkInit)
                {
                    if (_userId >= 0)
                    {
                        Logout();
                    }
                    try
                    {
                        CHCNetSDK.NET_DVR_Cleanup();
                    }
                    catch { }
                }
               
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }


}

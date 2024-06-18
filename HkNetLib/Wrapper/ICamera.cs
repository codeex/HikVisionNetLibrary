using System;

namespace HkNetLib.Wrapper
{
    public interface ICamera: IDisposable
    {
        /// <summary>
        /// 获取最后的异常描述
        /// </summary>
        /// <returns></returns>
        string GetLastError();

        /// <summary>
        /// 获取序列号字符串， 需要先登录
        /// </summary>
        /// <returns></returns>
        string GetSerialNumber();

        /// <summary>
        /// 登入相机
        /// </summary>
        /// <param name="cameraLoginInfo"></param>
        /// <returns></returns>
        bool Login(CameraLoginInfo cameraLoginInfo);

        /// <summary>
        /// 是否在线
        /// </summary>
        /// <returns></returns>
        bool IsOnline();
        /// <summary>
        /// 登出
        /// </summary>
        void Logout();
       
        /// <summary>
        /// 控制云台开始
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        bool StartPTZControl(PtzCommand cmd, Int32 speed = 4);
        /// <summary>
        /// 控制云台结束
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        bool StopPTZControl(PtzCommand cmd);
        /// <summary>
        /// 抓取相机内的图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool CapturePicture(string fileName);

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        bool Shutdown();
        /// <summary>
        /// 重启相机
        /// </summary>
        /// <returns></returns>
        bool Reboot();


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HkNetLib.Wrapper
{
    /// <summary>
    /// 海康DVR登录信息
    /// </summary>
    public class CameraLoginInfo
    {
        /// <summary>
        /// 摄像头的IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 登录端口号
        /// </summary>
        public ushort Port { get; set; } = 8000;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 默认通道
        /// </summary>
        public int ChannelNo { get; set; } = 1;
    }
}

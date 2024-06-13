using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HkNetLib.Hardware
{
    /// <summary>
    /// 海康错误码定义
    /// </summary>
    public enum HKErrorCode
    {
        [Description("未知错误，枚举中未定义该类型")]
        UNKOWN = -1,
        [Description("没有错误")]
        NET_DVR_NOERROR = 0,
        [Description("用户名密码错误")]
        NET_DVR_PASSWORD_ERROR = 1,
        [Description("权限不足")]
        NET_DVR_NOENOUGHPRI = 2,
        [Description("没有初始化")]
        NET_DVR_NOINIT = 3,
        [Description("通道号错误")]
        NET_DVR_CHANNEL_ERROR = 4,
        [Description("连接到DVR的客户端个数超过最大")]
        NET_DVR_OVER_MAXLINK = 5,
        [Description("版本不匹配")]
        NET_DVR_VERSIONNOMATCH = 6,
        [Description("连接服务器失败")]
        NET_DVR_NETWORK_FAIL_CONNECT = 7,
        [Description("向服务器发送失败")]
        NET_DVR_NETWORK_SEND_ERROR = 8,
        [Description("从服务器接收数据失败")]
        NET_DVR_NETWORK_RECV_ERROR = 9,
        [Description("从服务器接收数据超时")]
        NET_DVR_NETWORK_RECV_TIMEOUT = 10,
        [Description("传送的数据有误")]
        NET_DVR_NETWORK_ERRORDATA = 11,
        [Description("调用次序错误")]
        NET_DVR_ORDER_ERROR = 12,
        [Description("无此权限")]
        NET_DVR_OPERNOPERMIT = 13,
        [Description("DVR命令执行超时")]
        NET_DVR_COMMANDTIMEOUT = 14,
        [Description("串口号错误")]
        NET_DVR_ERRORSERIALPORT = 15,
        [Description("报警端口错误")]
        NET_DVR_ERRORALARMPORT = 16,
        [Description("参数错误")]
        NET_DVR_PARAMETER_ERROR = 17,
        [Description("服务器通道处于错误状态")]
        NET_DVR_CHAN_EXCEPTION = 18,
        [Description("没有硬盘")]
        NET_DVR_NODISK = 19,
        [Description("硬盘号错误")]
        NET_DVR_ERRORDISKNUM = 20,
        [Description("服务器硬盘满")]
        NET_DVR_DISK_FULL = 21,
        [Description("服务器硬盘出错")]
        NET_DVR_DISK_ERROR = 22,
        [Description("服务器不支持")]
        NET_DVR_NOSUPPORT = 23,
        [Description("服务器忙")]
        NET_DVR_BUSY = 24,
        [Description("服务器修改不成功")]
        NET_DVR_MODIFY_FAIL = 25,
        [Description("密码输入格式不正确")]
        NET_DVR_PASSWORD_FORMAT_ERROR = 26,
        [Description("硬盘正在格式化，不能启动操作")]
        NET_DVR_DISK_FORMATING = 27,
        [Description("DVR资源不足")]
        NET_DVR_DVRNORESOURCE = 28,
        [Description("DVR操作失败")]
        NET_DVR_DVROPRATEFAILED = 29,
        [Description("打开PC声音失败")]
        NET_DVR_OPENHOSTSOUND_FAIL = 30,
        [Description("服务器语音对讲被占用")]
        NET_DVR_DVRVOICEOPENED = 31,
        [Description("时间输入不正确")]
        NET_DVR_TIMEINPUTERROR = 32,
        [Description("回放时服务器没有指定的文件")]
        NET_DVR_NOSPECFILE = 33,
        [Description("创建文件出错")]
        NET_DVR_CREATEFILE_ERROR = 34,
        [Description("打开文件出错")]
        NET_DVR_FILEOPENFAIL = 35,
        [Description("上次的操作还没有完成")]
        NET_DVR_OPERNOTFINISH = 36,
        [Description("获取当前播放的时间出错")]
        NET_DVR_GETPLAYTIMEFAIL = 37,
        [Description("播放出错")]
        NET_DVR_PLAYFAIL = 38,
        [Description("文件格式不正确")]
        NET_DVR_FILEFORMAT_ERROR = 39,
        [Description("路径错误")]
        NET_DVR_DIR_ERROR = 40,
        [Description("资源分配错误")]
        NET_DVR_ALLOC_RESOURCE_ERROR = 41,
        [Description("声卡模式错误")]
        NET_DVR_AUDIO_MODE_ERROR = 42,
        [Description("缓冲区太小")]
        NET_DVR_NOENOUGH_BUF = 43,
        [Description("创建SOCKET出错")]
        NET_DVR_CREATESOCKET_ERROR = 44,
        [Description("设置SOCKET出错")]
        NET_DVR_SETSOCKET_ERROR = 45,
        [Description("个数达到最大")]
        NET_DVR_MAX_NUM = 46,
        [Description("用户不存在")]
        NET_DVR_USERNOTEXIST = 47,
        [Description("写FLASH出错")]
        NET_DVR_WRITEFLASHERROR = 48,
        [Description("DVR升级失败")]
        NET_DVR_UPGRADEFAIL = 49,
        [Description("解码卡已经初始化过")]
        NET_DVR_CARDHAVEINIT = 50,
        [Description("调用播放库中某个函数失败")]
        NET_DVR_PLAYERFAILED = 51,
        [Description("设备端用户数达到最大")]
        NET_DVR_MAX_USERNUM = 52,
        [Description("获得客户端的IP地址或物理地址失败")]
        NET_DVR_GETLOCALIPANDMACFAIL = 53,
        [Description("该通道没有编码")]
        NET_DVR_NOENCODEING = 54,
        [Description("IP地址不匹配")]
        NET_DVR_IPMISMATCH = 55,
        [Description("MAC地址不匹配")]
        NET_DVR_MACMISMATCH = 56,
        [Description("升级文件语言不匹配")]
        NET_DVR_UPGRADELANGMISMATCH = 57,
        [Description("播放器路数达到最大")]
        NET_DVR_MAX_PLAYERPORT = 58,
        [Description("备份设备中没有足够空间进行备份")]
        NET_DVR_NOSPACEBACKUP = 59,
        [Description("没有找到指定的备份设备")]
        NET_DVR_NODEVICEBACKUP = 60,
        [Description("图像素位数不符，限24色")]
        NET_DVR_PICTURE_BITS_ERROR = 61,
        [Description("图片高*宽超限，限128*256")]
        NET_DVR_PICTURE_DIMENSION_ERROR = 62,
        [Description("图片大小超限，限100K")]
        NET_DVR_PICTURE_SIZ_ERROR = 63,
        [Description("载入当前目录下PlayerSdk出错")]
        NET_DVR_LOADPLAYERSDKFAILED = 64,
        [Description("找不到PlayerSdk中某个函数入口")]
        NET_DVR_LOADPLAYERSDKPROC_ERROR = 65,
        [Description("载入当前目录下DSsdk出错")]
        NET_DVR_LOADDSSDKFAILED = 66,
        [Description("找不到DsSdk中某个函数入口")]
        NET_DVR_LOADDSSDKPROC_ERROR = 67,
        [Description("调用硬解码库DsSdk中某个函数失败")]
        NET_DVR_DSSDK_ERROR = 68,
        [Description("声卡被独占")]
        NET_DVR_VOICEMONOPOLIZE = 69,
        [Description("加入多播组失败")]
        NET_DVR_JOINMULTICASTFAILED = 70,
        [Description("建立日志文件目录失败")]
        NET_DVR_CREATEDIR_ERROR = 71,
        [Description("绑定套接字失败")]
        NET_DVR_BINDSOCKET_ERROR = 72,
        [Description("socket连接中断，此错误通常是由于连接中断或目的地不可达")]
        NET_DVR_SOCKETCLOSE_ERROR = 73,
        [Description("注销时用户ID正在进行某操作")]
        NET_DVR_USERID_ISUSING = 74,
        [Description("监听失败")]
        NET_DVR_SOCKETLISTEN_ERROR = 75,
        [Description("程序异常")]
        NET_DVR_PROGRAM_EXCEPTION = 76,
        [Description("写文件失败")]
        NET_DVR_WRITEFILE_FAILED = 77,
        [Description("禁止格式化只读硬盘")]
        NET_DVR_FORMAT_READONLY = 78,
        [Description("用户配置结构中存在相同的用户名")]
        NET_DVR_WITHSAMEUSERNAME = 79,
        [Description("导入参数时设备型号不匹配")]
        NET_DVR_DEVICETYPE_ERROR = 80,
        [Description("导入参数时语言不匹配")]
        NET_DVR_LANGUAGE_ERROR = 81,
        [Description("导入参数时软件版本不匹配")]
        NET_DVR_PARAVERSION_ERROR = 82,
        [Description("预览时外接IP通道不在线")]
        NET_DVR_IPCHAN_NOTALIVE = 83,
        [Description("加载高清IPC通讯库StreamTransClient.dll失败")]
        NET_DVR_RTSP_SDK_ERROR = 84,
        [Description("加载转码库失败")]
        NET_DVR_CONVERT_SDK_ERROR = 85,
        [Description("超出最大的ip接入通道数")]
        NET_DVR_IPC_COUNT_OVERFLOW = 86,
        [Description("添加标签(一个文件片段64)等个数达到最大")]
        NET_DVR_MAX_ADD_NUM = 87,
        [Description("图像增强仪，参数模式错误（用于硬件设置时，客户端进行软件设置时错误值）")]
        NET_DVR_PARAMMODE_ERROR = 88,
        [Description("视频综合平台，码分器不在线")]
        NET_DVR_CODESPITTER_OFFLINE = 89,
        [Description("设备正在备份")]
        NET_DVR_BACKUP_COPYING = 90,
        [Description("通道不支持该操作")]
        NET_DVR_CHAN_NOTSUPPORT = 91,
        [Description("高度线位置太集中或长度线不够倾斜")]
        NET_DVR_CALLINEINVALID = 92,
        [Description("取消标定冲突，如果设置了规则及全局的实际大小尺寸过滤")]
        NET_DVR_CALCANCELCONFLICT = 93,
        [Description("标定点超出范围")]
        NET_DVR_CALPOINTOUTRANGE = 94,
        [Description("尺寸过滤器不符合要求")]
        NET_DVR_FILTERRECTINVALID = 95,
        [Description("设备没有注册到ddns上")]
        NET_DVR_DDNS_DEVOFFLINE = 96,
        [Description("DDNS服务器内部错误")]
        NET_DVR_DDNS_INTER_ERROR = 97,
        [Description("此功能不支持该操作系统")]
        NET_DVR_FUNCTION_NOT_SUPPORT_OS = 98,
        [Description("解码通道绑定显示输出次数受限")]
        NET_DVR_DEC_CHAN_REBIND = 99,
        [Description("加载当前目录下的语音对讲库失败")]
        NET_DVR_INTERCOM_SDK_ERROR = 100,
        [Description("没有正确的升级包")]
        NET_DVR_NO_CURRENT_UPDATEFILE = 101,
        [Description("用户还没登陆成功")]
        NET_DVR_USER_NOT_SUCC_LOGIN = 102,
        [Description("正在使用日志开关文件")]
        NET_DVR_USE_LOG_SWITCH_FILE = 103,
        [Description("端口池中用于绑定的端口已耗尽")]
        NET_DVR_POOL_PORT_EXHAUST = 104,
        [Description("码流封装格式错误")]
        NET_DVR_PACKET_TYPE_NOT_SUPPORT = 105,
        [Description("IP接入配置时IPID有误")]
        NET_DVR_IPPARA_IPID_ERROR = 106,
        [Description("预览组件加载失败")]
        NET_DVR_LOAD_HCPREVIEW_SDK_ERROR = 107,
        [Description("语音组件加载失败")]
        NET_DVR_LOAD_HCVOICETALK_SDK_ERROR = 108,
        [Description("报警组件加载失败")]
        NET_DVR_LOAD_HCALARM_SDK_ERROR = 109,
        [Description("回放组件加载失败")]
        NET_DVR_LOAD_HCPLAYBACK_SDK_ERROR = 110,
        [Description("显示组件加载失败")]
        NET_DVR_LOAD_HCDISPLAY_SDK_ERROR = 111,
        [Description("行业应用组件加载失败")]
        NET_DVR_LOAD_HCINDUSTRY_SDK_ERROR = 112,
        [Description("通用配置管理组件加载失败")]
        NET_DVR_LOAD_HCGENERALCFGMGR_SDK_ERROR = 113,
        [Description("设备配置核心组件加载失败")]
        NET_DVR_LOAD_HCCOREDEVCFG_SDK_ERROR = 114,
        [Description("HCNetUtils加载失败")]
        NET_DVR_LOAD_HCNETUTILS_SDK_ERROR = 115,
        [Description("单独加载组件时，组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH = 121,
        [Description("预览组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCPREVIEW = 122,
        [Description("语音组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCVOICETALK = 123,
        [Description("报警组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCALARM = 124,
        [Description("回放组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCPLAYBACK = 125,
        [Description("显示组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCDISPLAY = 126,
        [Description("行业应用组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCINDUSTRY = 127,
        [Description("通用配置管理组件与core版本不匹配")]
        NET_DVR_CORE_VER_MISMATCH_HCGENERALCFGMGR = 128,
        [Description("预览组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCPREVIEW = 136,
        [Description("语音组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCVOICETALK = 137,
        [Description("报警组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCALARM = 138,
        [Description("回放组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCPLAYBACK = 139,
        [Description("显示组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCDISPLAY = 140,
        [Description("行业应用组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCINDUSTRY = 141,
        [Description("通用配置管理组件与HCNetSDK版本不匹配")]
        NET_DVR_COM_VER_MISMATCH_HCGENERALCFGMGR = 142,
        [Description("配置文件导入失败")]
        NET_ERR_CONFIG_FILE_IMPORT_FAILED = 145,
        [Description("配置文件导出失败")]
        NET_ERR_CONFIG_FILE_EXPORT_FAILED = 146,
        [Description("证书错误")]
        NET_DVR_CERTIFICATE_FILE_ERROR = 147,
        [Description("加载SSL库失败（可能是版本不匹配，也可能是不存在）")]
        NET_DVR_LOAD_SSL_LIB_ERROR = 148,
        [Description("SSL库版本不匹配")]
        NET_DVR_SSL_VERSION_NOT_MATCH = 149,
        [Description("别名重复,通过别名或者序列号来访问设备的新版本ddns的配置")]
        NET_DVR_ALIAS_DUPLICATE = 150,
        [Description("无效通信")]
        NET_DVR_INVALID_COMMUNICATION = 151,
        [Description("用户名不存在（用户名不存在，IPC5.1.7中发布出去了，所以删不掉。后续的产品这个错误码用不上）")]
        NET_DVR_USERNAME_NOT_EXIST = 152,
        [Description("用户被锁定")]
        NET_DVR_USER_LOCKED = 153,
        [Description("无效用户ID")]
        NET_DVR_INVALID_USERID = 154,
        [Description("登录版本低")]
        NET_DVR_LOW_LOGIN_VERSION = 155,
        [Description("加载libeay32.dll库失败")]
        NET_DVR_LOAD_LIBEAY32_DLL_ERROR = 156,
        [Description("加载ssleay32.dll库失败")]
        NET_DVR_LOAD_SSLEAY32_DLL_ERROR = 157,
        [Description("加载libiconv库失败")]
        NET_ERR_LOAD_LIBICONV = 158,
        [Description("SSL连接失败")]
        NET_ERR_SSL_CONNECT_FAILED = 159,
        [Description("获取多播地址错误")]
        NET_ERR_MCAST_ADDRESS_ERROR = 160,
        [Description("加载zlib.dll库失败")]
        NET_ERR_LOAD_ZLIB = 161,
        [Description("Openssl库未初始化")]
        NET_ERR_OPENSSL_NO_INIT = 162,
        [Description("对应的服务器找不到,查找时输入的国家编号或者服务器类型错误")]
        NET_DVR_SERVER_NOT_EXIST = 164,
        [Description("连接测试服务器失败")]
        NET_DVR_TEST_SERVER_FAIL_CONNECT = 165,
        [Description("NAS服务器挂载目录失败，目录无效")]
        NET_DVR_NAS_SERVER_INVALID_DIR = 166,
        [Description("NAS服务器挂载目录失败，没有权限")]
        NET_DVR_NAS_SERVER_NOENOUGH_PRI = 167,
        [Description("服务器使用域名，但是没有配置DNS，可能造成域名无效。")]
        NET_DVR_EMAIL_SERVER_NOT_CONFIG_DNS = 168,
        [Description("没有配置网关，可能造成发送邮件失败。")]
        NET_DVR_EMAIL_SERVER_NOT_CONFIG_GATEWAY = 169,
        [Description("用户名密码不正确，测试服务器的用户名或密码错误")]
        NET_DVR_TEST_SERVER_PASSWORD_ERROR = 170,
        [Description("设备和smtp服务器交互异常")]
        NET_DVR_EMAIL_SERVER_CONNECT_EXCEPTION_WITH_SMTP = 171,
        [Description("FTP服务器创建目录失败")]
        NET_DVR_FTP_SERVER_FAIL_CREATE_DIR = 172,
        [Description("FTP服务器没有写入权限")]
        NET_DVR_FTP_SERVER_NO_WRITE_PIR = 173,
        [Description("IP冲突")]
        NET_DVR_IP_CONFLICT = 174,
        [Description("存储池空间已满")]
        NET_DVR_INSUFFICIENT_STORAGEPOOL_SPACE = 175,
        [Description("云服务器存储池无效,没有配置存储池或者存储池ID错误")]
        NET_DVR_STORAGEPOOL_INVALID = 176,
        [Description("生效需要重启")]
        NET_DVR_EFFECTIVENESS_REBOOT = 177,
        [Description("断网续传布防连接已经存在(该错误码是在私有布防连接建立的情况下，重复布防的断网续传功能时，返回。)")]
        NET_ERR_ANR_ARMING_EXIST = 178,
        [Description("断网续传上传连接已经存在(EHOME协议和SDK协议是不能同时支持断网续传的，当一个协议存在的时候，另外一个连接建立话，报错这个错误码。)")]
        NET_ERR_UPLOADLINK_EXIST = 179,
        [Description("导入文件格式不正确")]
        NET_ERR_INCORRECT_FILE_FORMAT = 180,
        [Description("导入文件内容不正确")]
        NET_ERR_INCORRECT_FILE_CONTENT = 181,
        [Description("HRUDP连接数超过设备限制")]
        NET_ERR_MAX_HRUDP_LINK = 182,
        [Description("接入秘钥或加密秘钥不正确")]
        NET_SDK_ERR_ACCESSKEY_SECRETKEY = 183,
        [Description("创建端口复用失败")]
        NET_SDK_ERR_CREATE_PORT_MULTIPLEX = 184,
        [Description("不支持无阻塞抓图")]
        NET_DVR_NONBLOCKING_CAPTURE_NOTSUPPORT = 185,
        [Description("已开启异步，该功能无效")]
        NET_SDK_ERR_FUNCTION_INVALID = 186,
        [Description("已达到端口复用最大数目")]
        NET_SDK_ERR_MAX_PORT_MULTIPLEX = 187,
        [Description("连接尚未建立或连接无效")]
        NET_DVR_INVALID_LINK = 188,
        [Description("接口不支持ISAPI协议")]
        NET_DVR_ISAPI_NOT_SUPPORT = 189,
        [Description("设备未激活")]
        NET_DVR_ERROR_DEVICE_NOT_ACTIVATED = 250,
        [Description("有风险的密码")]
        NET_DVR_ERROR_RISK_PASSWORD = 251,
        [Description("设备已激活")]
        NET_DVR_ERROR_DEVICE_HAS_ACTIVATED = 252
    }

    
}

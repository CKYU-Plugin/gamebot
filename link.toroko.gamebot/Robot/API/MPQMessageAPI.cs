using System;
using System.Runtime.InteropServices;

namespace Robot.API
{
    public class MPQMessageAPI
    {
        /// <summary>
        /// 根据提交的QQ号计算得到页面操作用参数Bkn或G_tk
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGtk_Bkn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGtk_Bkn(string qq);
        /// <summary>
        /// 根据提交的QQ号计算得到页面操作用参数长Bkn或长G_tk
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetBkn32", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetBkn32(string qq);
        /// <summary>
        /// 根据提交的QQ号计算得到页面操作用参数长Ldw
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetLdw", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetLdw(string qq);
        /// <summary>
        /// 取得框架所在目录.可能鸡肋了。
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetRunPath", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetRunPath();
        /// <summary>
        /// 取得当前框架内在线可用的QQ列表
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetOnlineQQlist", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetOnlineQQlist();
        /// <summary>
        /// 取得框架内所有QQ列表。包括未登录以及登录失败的QQ
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetQQlist", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetQQlist();
        /// <summary>
        /// 根据QQ取得对应的会话秘钥
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetSessionkey", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetSessionkey(string qq);
        /// <summary>
        /// 取得页面登录用的Clientkey
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetClientkey", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetClientkey(string qq);
        /// <summary>
        /// 取得页面登录用的长Clientkey
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetLongClientkey", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetLongClientkey(string qq);
        /// <summary>
        /// 取得页面操作用的Cookies
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetCookies", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetCookies(string qq);
        /// <summary>
        /// 取得框架内设置的信息发送前缀
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetPrefix", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetPrefix();
        /// <summary>
        /// 将群名片加入高速缓存当作.
        /// </summary>
        /// <param name="gid">群号</param>
        /// <param name="QQ">QQ</param>
        /// <param name="gnamecard">名片</param>
        [DllImport("Message.dll", EntryPoint = "Api_Cache_NameCard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_Cache_NameCard(string gid, string QQ, string gnamecard);
        /// <summary>
        /// 将指定QQ移出QQ黑名单
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_DBan", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_DBan(string qq, string QQ);
        /// <summary>
        /// 将指定QQ列入QQ黑名单
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_Ban", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_Ban(string qq, string QQ);
        /// <summary>
        /// 禁言群成员
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号 禁言对象所在群.</param>
        /// <param name="QQ">QQ 禁言对象.留空为全群禁言</param>
        /// <param name="time">时长  单位:秒 最大为1个月. 为零解除对象或全群禁言</param>
        [DllImport("Message.dll", EntryPoint = "Api_Shutup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_Shutup(string qq, string gid, string QQ, int time);
        /// <summary>
        /// 根据群号+QQ判断指定群员是否被禁言  获取失败的情况下亦会返回假
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">欲判断对象所在群.</param>
        /// <param name="QQ">欲判断对象</param>
        [DllImport("Message.dll", EntryPoint = "Api_IsShutup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_IsShutup(string qq, string gid, string QQ);
        /// <summary>
        /// 发群公告
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_SetNotice", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_SetNotice(string qq, string gid, string title, string content);
        /// <summary>
        /// 取群公告
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetNotice", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetNotice(string qq, string gid);
        /// <summary>
        /// 取群名片
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetNameCard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetNameCard(string qq, string gid, string QQ);
        /// <summary>
        /// 设置群名片
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        /// <param name="QQ">QQ</param>
        /// <param name="namecard">名片</param>
        [DllImport("Message.dll", EntryPoint = "Api_SetNameCard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_SetNameCard(string qq, string gid, string QQ, string namecard);
        /// <summary>
        /// 退出讨论组
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="did">讨论组ID</param>
        [DllImport("Message.dll", EntryPoint = "Api_QuitDG", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_QuitDG(string qq, string did);
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_DelFriend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_DelFriend(string qq, string QQ);
        /// <summary>
        /// 将对象移除群
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        /// <param name="tqq">对象</param>
        [DllImport("Message.dll", EntryPoint = "Api_Kick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_Kick(string qq, string gid, string tqq);
        /// <summary>
        /// 主动加群.为了避免广告、群发行为。出现验证码时将会直接失败不处理
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        /// <param name="remark">附加理由</param>
        [DllImport("Message.dll", EntryPoint = "Api_JoinGroup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_JoinGroup(string qq, string gid, string remark);
        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_QuitGroup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_QuitGroup(string qq, string gid);
        /// <summary>
        /// 返回值:成功返回图片GUID用于发送该图片.失败返回空.  图片尺寸应小于4MB
        /// </summary>
        /// <param name="qq">机器人QQ</param>
        /// <param name="uploadtype">1好友2群 注:好友图和群图的GUID并不相同并不通用 需要非别上传。群、讨论组用类型2 临时会话、好友信息需要类型1</param>
        /// <param name="QQ">上传该图片所属的群号或QQ</param>
        /// <param name="img">图片字节集数据或字节集数据指针()</param>
        [DllImport("Message.dll", EntryPoint = "Api_UploadPic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_UploadPic(string qq, int uploadtype, string QQ, byte[] img);
        /// <summary>
        /// 根据图片GUID取得图片下载连接 失败返回空
        /// </summary>
        /// <param name="guid">{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}.jpg这样的GUID</param>
        [DllImport("Message.dll", EntryPoint = "Api_GuidGetPicLink", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GuidGetPicLink(string guid);
        /// <summary>
        /// 向对象、目标发送信息 支持好友 群 讨论组 群临时会话 讨论组临时会话
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msgtype">1好友 2群 3讨论组 4群临时会话 5讨论组临时会话</param>
        /// <param name="subtype">无特殊说明情况下留空或填零</param>
        /// <param name="gdid">发送群信息、讨论组信息、群临时会话信息、讨论组临时会话信息时填写</param>
        /// <param name="QQ">最终接收这条信息的对象QQ</param>
        /// <param name="content">信息内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendMsg", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_SendMsg(string qq, int msgtype, int subtype, string gdid, string QQ, string content);
        /// <summary>
        /// 向服务器直接发送一个加密封装完成后的封包。成功返回服务器回传加密后的响应包体。失败或超时返回空
        /// </summary>
        /// <param name="package">封包内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_Send", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_Send(string package);
        /// <summary>
        /// 在框架记录页输出一行信息
        /// </summary>
        /// <param name="content">输出的内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_OutPut", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_OutPut(string content);
        /// <summary>
        /// 取得本插件启用状态
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_IsEnable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_IsEnable();
        /// <summary>
        /// 登录一个现存的QQ
        /// </summary>
        /// <param name="QQ">欲登录的Q</param>
        [DllImport("Message.dll", EntryPoint = "Api_Login", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_Login(string QQ);
        /// <summary>
        /// 让指定QQ下线
        /// </summary>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_Logout", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_Logout(string QQ);
        /// <summary>
        /// tean加密算法
        /// </summary>
        /// <param name="encodeString">加密内容</param>
        /// <param name="Key">Key</param>
        [DllImport("Message.dll", EntryPoint = "Api_Tea加密", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_Tea加密(string encodeString, string Key);
        /// <summary>
        /// tean解密算法
        /// </summary>
        /// <param name="decryptString">解密内容</param>
        /// <param name="Key">Key</param>
        [DllImport("Message.dll", EntryPoint = "Api_Tea解密", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_Tea解密(string decryptString, string Key);
        /// <summary>
        /// 取用户名
        /// </summary>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetNick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetNick(string QQ);
        /// <summary>
        /// 取QQ等级+QQ会员等级 返回json格式信息
        /// </summary>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetQQLevel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetQQLevel(string QQ);
        /// <summary>
        /// 群号转群ID
        /// </summary>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GNGetGid", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GNGetGid(string gid);
        /// <summary>
        /// 群ID转群号
        /// </summary>
        /// <param name="gid">群ID</param>
        [DllImport("Message.dll", EntryPoint = "Api_GidGetGN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GidGetGN(string gid);
        /// <summary>
        /// 取框架版本号(发布时间戳
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetVersion", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetVersion();
        /// <summary>
        /// 取框架版本名
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetVersionName", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetVersionName();
        /// <summary>
        /// 取当前框架内部时间戳_周期性与服务器时间同步
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetTimeStamp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetTimeStamp();
        /// <summary>
        /// 取得框架输出列表内所有信息
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetLog", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetLog();
        /// <summary>
        /// 判断是否处于被屏蔽群信息状态。
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_IfBlock", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_IfBlock(string qq);
        /// <summary>
        /// 取包括群主在内的群管列表
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetAdminList", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetAdminList(string qq, string gid);
        /// <summary>
        /// 发说说
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="content">内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_AddTaotao", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_AddTaotao(string qq, string content);
        /// <summary>
        /// 取个签
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">对象</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetSign", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetSign(string qq, string QQ);
        /// <summary>
        /// 设置个签
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="content">内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_SetSign", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_SetSign(string qq, string content);
        /// <summary>
        /// 通过qun.qzone.qq.com接口取得取群列表.成功返回转码后的JSON格式文本信息
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGroupListA", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGroupListA(string qq);
        /// <summary>
        /// 通过qun.qq.com接口取得取群列表.成功返回转码后的JSON格式文本信息
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGroupListB", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGroupListB(string qq);
        /// <summary>
        /// 通过qun.qq.com接口取得群成员列表 成功返回转码后的JSON格式文本
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGroupMemberA", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGroupMemberA(string qq, string gid);
        /// <summary>
        /// 通过qun.qzone.qq.com接口取得群成员列表 成功返回转码后的JSON格式文本
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGroupMemberB", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGroupMemberB(string qq, string gid);
        /// <summary>
        /// 通过qun.qq.com接口取得好友列表。成功返回转码后的JSON文本
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetFriendList", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetFriendList(string qq);
        /// <summary>
        /// 取Q龄 成功返回Q龄 失败返回-1
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetQQAge", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetQQAge(string qq, string QQ);
        /// <summary>
        /// 取年龄 成功返回年龄 失败返回-1
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetAge", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetAge(string qq, string QQ);
        /// <summary>
        /// 取个人说明
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">对象QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetPersonalProfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetPersonalProfile(string qq, string QQ);
        /// <summary>
        /// 取邮箱 成功返回邮箱 失败返回空
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetEmail", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetEmail(string qq, string QQ);
        /// <summary>
        /// 取对象性别 1男 2女  未或失败返回-1
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGender", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetGender(string qq, string QQ);
        /// <summary>
        /// 向好友发送‘正在输入’的状态信息.当好友收到信息之后 “正在输入”状态会立刻被打断
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendTyping", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_SendTyping(string qq, string QQ);
        /// <summary>
        /// 向好友发送窗口抖动信息
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendShake", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_SendShake(string qq, string QQ);
        /// <summary>
        /// 取得框架内随机一个在线且可以使用的QQ
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetRadomOnlineQQ", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetRadomOnlineQQ();
        /// <summary>
        /// 往帐号列表添加一个Q.当该Q已存在时则覆盖密码
        /// </summary>
        /// <param name="QQ">QQ</param>
        /// <param name="pwd">密码</param>
        /// <param name="autologon">运行框架时是否自动登录该Q.若添加后需要登录该Q则需要通过Api_Login操作</param>
        [DllImport("Message.dll", EntryPoint = "Api_AddQQ", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_AddQQ(string QQ, string pwd, bool autologon);
        /// <summary>
        /// 设置在线状态+附加信息
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="onlineStatus">在线状态 1~6 分别对应我在线上, Q我吧, 离开, 忙碌, 请勿打扰, 隐身</param>
        /// <param name="info">状态附加信息 最大255字节</param>
        [DllImport("Message.dll", EntryPoint = "Api_SetOLStatus", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_SetOLStatus(string qq, int onlineStatus, string info);
        /// <summary>
        /// 取得机器码
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetMC", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetMC();
        /// <summary>
        /// 邀请对象加入群 失败返回错误理由
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">好友QQ 多个好友用换行分割</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GroupInvitation", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GroupInvitation(string qq, string QQ, string gid);
        /// <summary>
        /// 创建一个讨论组 成功返回讨论组ID 失败返回空 注:每24小时只能创建100个讨论组 悠着点用
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_CreateDG", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_CreateDG(string qq);
        /// <summary>
        /// 将对象移除讨论组.成功返回空 失败返回理由
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="did">讨论组ID</param>
        /// <param name="QQ">成员</param>
        [DllImport("Message.dll", EntryPoint = "Api_KickDG", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_KickDG(string qq, string did, string QQ);
        /// <summary>
        /// 邀请对象加入讨论组 成功返回空 失败返回理由
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="did">讨论组ID</param>
        /// <param name="QQl">成员组 多个成员用换行符分割</param>
        [DllImport("Message.dll", EntryPoint = "Api_DGInvitation", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_DGInvitation(string qq, string 讨论组ID, string QQl);
        /// <summary>
        /// 成功返回以换行符分割的讨论组号列表.最大为100个讨论组  失败返回空
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetDGList", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetDGList(string qq);
        /// <summary>
        /// 向对象发送一条音乐信息（所谓的点歌）次数不限
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="msgtype">同Api_SendMsg  1好友 2群 3讨论组 4群临时会话 5讨论组临时会话</param>
        /// <param name="gdid">收信对象所属群_讨论组 发群内、临时会话必填 好友可不填</param>
        /// <param name="QQ">临时会话、好友必填 发至群内可不填</param>
        /// <param name="musicInfo">留空默认‘QQ音乐 的分享’</param>
        /// <param name="musicPageURL">任意直连或短链接均可 留空为空 无法点开</param>
        /// <param name="musicPicURL">任意直连或短链接均可 可空 例:http://url.cn/cDiJT4</param>
        /// <param name="musicURL">任意直连或短链接均可 不可空 例:http://url.cn/djwXjr</param>
        /// <param name="musicName">可空</param>
        /// <param name="musicSinger">可空</param>
        /// <param name="musicSource">可空 为空默认QQ音乐</param>
        /// <param name="musicIconURL">可空 为空默认QQ音乐 http://qzonestyle.gtimg.cn/ac/qzone/applogo/64/308/100497308_64.gif</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendMusic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_SendMusic(string qq, int msgtype, string gdid, string QQ, string musicInfo, string musicPageURL, string musicPicURL, string musicURL, string musicName, string musicSinger, string musicSource, string musicIconURL);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="msgtype">同Api_SendMsg  1好友 2群 3讨论组 4群临时会话 5讨论组临时会话</param>
        /// <param name="gdid">收信对象所属群_讨论组 发群内、临时会话必填 好友可不填</param>
        /// <param name="QQ">临时会话、好友必填 发至群内可不填</param>
        /// <param name="ObjectMsg"></param>
        /// <param name="musictype">00 基本 02 点歌 其他不明</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendObjectMsg", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_SendObjectMsg(string qq, int msgtype, string gdid, string QQ, string ObjectMsg, int subtype);
        /// <summary>
        /// 判断对象是否为好友（双向）
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="QQ">对象QQ</param>
        [DllImport("Message.dll", EntryPoint = "Api_IsFriend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_IsFriend(string qq, string QQ);
        /// <summary>
        /// 主动加好友 成功返回真 失败返回假 当对象设置需要正确回答问题或不允许任何人添加时无条件失败
        /// </summary>
        /// <param name="qq">机器人QQ</param>
        /// <param name="QQ">加谁</param>
        /// <param name="remark">加好友提交的理由</param>
        [DllImport("Message.dll", EntryPoint = "Api_AddFriend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_AddFriend(string qq, string QQ, string remark);
        /// <summary>
        /// 无参 用于插件自身请求禁用插件自身
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_SelfDisable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_SelfDisable();
        /// <summary>
        /// 取协议客户端类型常量 失败返回0
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetClientType", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetClientType();
        /// <summary>
        /// 取协议客户端版本号常量  失败返回0
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetClientVer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetClientVer();
        /// <summary>
        /// 取协议客户端公开版本号常量  失败返回0
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetPubNo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetPubNo();
        /// <summary>
        /// 取协议客户端主版本号常量  失败返回0
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetMainVer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetMainVer();
        /// <summary>
        /// 取协议客户端通信模块(TXSSO)版本号常量  失败返回0
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_GetTXSSOVer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_GetTXSSOVer();
        /// <summary>
        /// 上传音频文件 成功返回guid用于发送
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="uploadtype">1好友2群 注:好友图和群图的GUID并不相同并不通用 需要非别上传。群、讨论组用类型2 临时会话、好友信息需要类型1</param>
        /// <param name="QQ">上传该图片所属的群号或QQ</param>
        /// <param name="amrData">音频字节集数据</param>
        /// <returns></returns>
        [DllImport("Message.dll", EntryPoint = "Api_UploadVoice", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_UploadVoice(string qq ,int uploadtype, string QQ, byte[] amrData);
        /// <summary>
        /// 通过音频、语音guid取得下载连接
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="GUID">格式:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx}.amr</param>
        [DllImport("Message.dll", EntryPoint = "Api_GuidGetVoiceLink", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GuidGetVoiceLink(string qq, string GUID);
        /// <summary>
        /// 添加一个日志处理函数。每条新日志信息输出都会投递给该函数处理、重复添加将覆盖旧的、之前的接口
        /// </summary>
        /// <param name="pointer">回调子程序、函数指针(内存地址)。函数仅一个参数。参数1为 结构体LOGSTRUCT指针</param>
        [DllImport("Message.dll", EntryPoint = "Api_AddLogHandler", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_AddLogHandler(IntPtr pointer);
        /// <summary>
        /// 移除由Api_AddLogHandler添加、设置的日志处理函数
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_RemoveLogHandler", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_RemoveLogHandler();
        /// <summary>
        /// 获取群名
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="gid">群号</param>
        [DllImport("Message.dll", EntryPoint = "Api_GetGroupName", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_GetGroupName(string qq, string gid);
        /// <summary>
        /// 添加一个待发送处理函数。每条待发送信息都会投递给该函数处理、重复添加将覆盖旧的、之前的接口
        /// </summary>
        /// <param name="pointer">回调子程序、函数指针(内存地址)。</param>
        [DllImport("Message.dll", EntryPoint = "Api_SetMsgFilter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_SetMsgFilter(IntPtr pointer);
        /// <summary>
        /// 移除\取消由Api_SetMsgFilter所添加\设置的处理函数
        /// </summary>
        [DllImport("Message.dll", EntryPoint = "Api_RemoveMsgFilter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void Api_RemoveMsgFilter();
        /// <summary>
        /// 回复信息 请尽量避免使用该API
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="msgtype">1好友 2群 3讨论组 4群临时会话 5讨论组临时会话</param>
        /// <param name="QQ">接收这条信息的对象</param>
        /// <param name="content">信息内容</param>
        [DllImport("Message.dll", EntryPoint = "Api_Reply", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Api_Reply(string qq, int msgtype, string QQ, string content);
        /// <summary>
        /// 上传图片.成功返回图片GUID用于发送该图片.失败返回空.  图片尺寸应小于4MB
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="path">本地文件路径 选填</param>
        /// <param name="imgData">图片字节集数据 选填</param>
        [DllImport("Message.dll", EntryPoint = "Api_Upload", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string Api_Upload(string qq, string path, byte[] imgData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qq">响应的QQ</param>
        /// <param name="msgtype">同Api_SendMsg  1好友 2群 3讨论组 4群临时会话 5讨论组临时会话</param>
        /// <param name="gdid">发群内、临时会话必填 好友可不填</param>
        /// <param name="QQ">临时会话、好友必填 发至群内可不填</param>
        /// <param name="xmlData"></param>
        /// <param name="xmltype">00 基本 02 点歌 其他不明</param>
        [DllImport("Message.dll", EntryPoint = "Api_SendXml", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Api_SendXml(string qq, int msgtype, string gdid, string QQ, string xmlData, int xmltype);

    }
}

using me.kotone.gamebot;
using Robot.API;
using Robot.Property;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Robot
{
    public static class Main
    {
        private static object enablelocker = new object();

        public static void Run(string robotQQ, Int32 msgType, Int32 msgSubType, string msgSrc, string targetActive, string targetPassive, string msgContent, int messageid)
        {
            if (!RobotBase.isinit) { return; }
            if (!RobotBase.isenableplugin) { return; }
            Program.Main(robotQQ, msgType, msgSubType, msgSrc, targetActive, targetPassive, msgContent, messageid);
        }

        public static void Init()
        {
            CQAPI.AddLog(RobotBase.CQ_AuthCode, CQAPI.LogPriority.CQLOG_DEBUG, $"初始化", "开始加载");
            RobotBase.isenableplugin = true;
            Program.Init();
        }

        public static void Close()
        {
            lock (enablelocker)
            {
                try
                {
                    RobotBase.isenableplugin = false;
                    Program.close.Cancel();
                }
                catch { }
            }
        }

        public static void Disable()
        {
            CQAPI.AddLog(RobotBase.CQ_AuthCode, CQAPI.LogPriority.CQLOG_DEBUG, $"结束", "开始结束事件");
        }
    }
}

using Robot.API;
using Robot.Code;
using Robot.Extension;
using Robot.Property;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace link.toroko.gamebot
{
    public class Program
    {

        public static CancellationTokenSource close = new CancellationTokenSource();
        private static string[] elementaryArithmetic = new string[] { };
     //   private static ConcurrentDictionary<long, int> gametype = new ConcurrentDictionary<long, int>();
        private static ConcurrentDictionary<long, ConcurrentQueue<con>> games = new ConcurrentDictionary<long, ConcurrentQueue<con>>();
        private static ConcurrentDictionary<string, BigInteger> users = new ConcurrentDictionary<string, BigInteger>();
        private static Dictionary<string, IEnumerable<string>> dict = new Dictionary<string, IEnumerable<string>>();
        private static object filelocker = new object();
        private class con
        {
            public string qq { get; set; }
            public string answer { get; set; }
            public string at { get; set; }
        }

        public static void Init()
        {
            Task.Factory.StartNew(() =>
            {
                Setup();
                SetDict();
                RobotBase.isinit = true;
            });
        }

        public static void Main(string robotQQ, Int32 msgType, Int32 msgSubType, string msgSrc, string targetActive, string targetPassive, string msgContent, int messageid)
        {
            if (!RobotBase.isinit) { return; }
            if (msgType != 2) { return; }
            long gdid = 0;
            long.TryParse(targetActive, out gdid);
            if (gdid == 0) { return; }

            if (msgContent.StartsWith("仿製貓"))
            {
                if (msgContent.Contains("積分"))
                {
                    IniFile i = new IniFile(RobotBase.appfolder + RobotBase.iniconf);
                    BigInteger points = 0;
                    try
                    {
                        lock (filelocker)
                        {
                            BigInteger.TryParse(i.IniReadValue(msgSrc, "point"), out points);
                        }
                        if (!users.ContainsKey(msgSrc))
                        {
                            users[msgSrc] = points;
                        }
                    }
                    catch { }
                    if (users.ContainsKey(msgSrc))
                    {
                        _API.SendMessage(msgSrc, msgType, $"{_Code.Code_At(msgSrc)}Your credit: {users[msgSrc]}", targetActive, robotQQ, msgSubType);
                    }
                    else
                    {
                        _API.SendMessage(msgSrc, msgType, $"{_Code.Code_At(msgSrc)}Your credit: 0", targetActive, robotQQ, msgSubType);
                    }
                }
                if (msgContent.Contains("魔數"))
                {
                    if (!games.ContainsKey(gdid))
                    {
                        games.TryAdd(gdid, new ConcurrentQueue<con>());
                        Initgame(gdid, robotQQ, msgType, msgSubType, msgSrc, targetActive, targetPassive, msgContent, messageid);
                        return;
                    }
                    else
                    {
                        _API.SendMessage(msgSrc, msgType, $"{_Code.Code_At(msgSrc)}{Environment.NewLine}已經開始了", targetActive, robotQQ, msgSubType);
                        return;
                    }
                }
            }

            if (games.ContainsKey(gdid))
            {
                int tmp = 0;
                bool isint32 = int.TryParse(msgContent,out tmp);

                if (isint32)
                {
                    games[gdid].Enqueue(new con { qq = msgSrc, answer = tmp.ToString() });
                }
                return;
            }
        }

        public static void Initgame(long gdid,string robotQQ, Int32 msgType, Int32 msgSubType, string msgSrc, string targetActive, string targetPassive, string msgContent, int messageid)
        {
            Task.Factory.StartNew(() =>
            {
                DateTime startDateTime = DateTime.Now;
                long commbo = 0;
                string smath = string.Empty;
                string answer = string.Empty;
                con re = null;
                List<string> answers = new List<string>();
                ConcurrentQueue<con> tmp = new ConcurrentQueue<con>();
                try
                {
                    try
                    {
                        CreateQuestion(out smath, out answer);
                        answers.Add(answer);
                    }
                    catch (Exception ex)
                    {
                        _API.SendMessage(msgSrc, msgType, $"{ex.Message}", targetActive, robotQQ, msgSubType);
                        games.TryRemove(gdid, out tmp);
                        tmp = null;
                        return;
                    }

                    _API.SendMessage(msgSrc, msgType, $"{smath}", targetActive, robotQQ, msgSubType);

                    while (((DateTime.Now.Ticks - startDateTime.Ticks) / 10000000) < 2000)
                    {
                        SpinWait.SpinUntil(() => games[gdid].Count() != 0);
                        long timeRemaining = 2000 - ((DateTime.Now.Ticks - startDateTime.Ticks) / 10000000);
                        if (timeRemaining <= 0) { break; }

                        bool newJob = false;
                        newJob = games[gdid].TryDequeue(out re);
                        if (newJob)
                        {
                            if (re.answer == answer)
                            {
                                commbo += 1;
                                long points = 20;
                                long.TryParse(answer, out points);
                                UserPoint(re.qq, points);
                                CreateQuestion(out smath, out answer);
                                answers.Add(answer);
                                _API.SendMessage(re.qq, msgType, $"{_Code.Code_At(re.qq)}[{RandText(commbo.ToString())} COMBO]{Environment.NewLine}{smath}{Environment.NewLine}Time remaining: {timeRemaining}s", targetActive, robotQQ, msgSubType);
                            }
                            else
                            {
                                if (!answers.Skip(Math.Max(0, answers.Count() - 2)).Contains(re.answer))
                                {
                                    long ianswer = 0;
                                    long.TryParse(answer, out ianswer);
                                    long lpoint = 0;
                                    lpoint = (ianswer * commbo) < 0 ? (ianswer * commbo) * -1 : (ianswer * commbo);
                                    UserPoint(re.qq, lpoint * -1);
                                    _API.SendMessage(re.qq, msgType,
                                    $@"{_Code.Code_At(re.qq)}Whoops! {smath.Substring(0, smath.Length - 2)}{answer}, GAME OVER! {Environment.NewLine}Credit -{lpoint}",
                                    targetActive, robotQQ, msgSubType);
                                    games.TryRemove(gdid, out tmp);
                                    tmp = null;
                                    return;
                                }
                            }
                        }
                    }
                    _API.SendMessage(re.qq, msgType, $"Time out!", targetActive, robotQQ, msgSubType);
                    games.TryRemove(gdid, out tmp);
                    tmp = null;
                }
                catch
                {
                    games.TryRemove(gdid, out tmp);
                    tmp = null;
                    return;
                }
            }, TaskCreationOptions.LongRunning);
        }

        public static void UserPoint(string qq , long point)
        {
            if (users.ContainsKey(qq))
            {
                users[qq] += point;
            }
            else
            {
                users.TryAdd(qq, point);
            }
            lock (filelocker)
            {
                IniFile i = new IniFile(RobotBase.appfolder + RobotBase.iniconf);
                i.IniWriteValue(qq, "point", users[qq].ToString());
            }
        }

        public static string RandText(string math)
        {
            Random rnd = new Random();
            string smath = string.Empty;
            rnd = new Random(Guid.NewGuid().GetHashCode());

            foreach (var s in math)
            {
                if (dict.ContainsKey(s.ToString()))
                {
                    IEnumerable<string> tmp = null;
                    dict.TryGetValue(s.ToString(), out tmp);
                    if (tmp?.Count() > 0)
                    {
                        smath += tmp.ElementAt(rnd.Next(tmp.Count()));
                        continue;
                    }
                }
                smath += s.ToString();
            }
            return smath;
        }

        public static void CreateQuestion(out string _smath, out string _answer)
        {
            Random rnd = new Random();
            string math = string.Empty;
            string smath = string.Empty;
            string answer = string.Empty;

            rnd = new Random(Guid.NewGuid().GetHashCode());
            math = string.Empty;
            math += rnd.Next(99).ToString() + " ";
            math += elementaryArithmetic[rnd.Next(elementaryArithmetic.Length - 1)] + " ";
            math += rnd.Next(99).ToString() + " ";
            try
            {
                answer = new DataTable().Compute(math, null).ToString();
            }catch{answer = Int32.MaxValue.ToString();}
            math += "= ?";
            _smath = RandText(math);
            _answer = answer;
        }

        private static void SetDict()
        {
            elementaryArithmetic = new string[] { "+", "-", "*", "/" };

            dict.Add("0", new List<string>() { "0", "０", "O", "Ｏ" });
            dict.Add("1", new List<string>() { "1", "１", "I", "Ｉ", "i", "ｉ" });
            dict.Add("2", new List<string>() { "2", "２", "Z", "Ｚ", "z", "ｚ" });
            dict.Add("3", new List<string>() { "3", "３" });
            dict.Add("4", new List<string>() { "4", "４" });
            dict.Add("5", new List<string>() { "5", "５", "S", "Ｓ"});
            dict.Add("6", new List<string>() { "6", "６", "b", "ｂ" });
            dict.Add("7", new List<string>() { "7", "７" });
            dict.Add("8", new List<string>() { "8", "８", "B", "Ｂ" });
            dict.Add("9", new List<string>() { "9", "９", "⑨" });

            dict.Add("+", new List<string>() { "+", "＋", "加", "加上", "加入", "多了", "十" });
            dict.Add("-", new List<string>() { "-", "－", "減", "減去", "減少", "少了", "一" });
            dict.Add("*", new List<string>() { "*", "＊", "乘", "乘上", "乘以", "X", "Ｘ", "x", "ｘ" });
            dict.Add("/", new List<string>() { "/", "／", "除", "除去" });
            dict.Add(" ", new List<string>() { " ", "　", "_" });
            dict.Add("=", new List<string>() { "=", "＝", "等於", "是" });
            dict.Add("?", new List<string>() { "?", "？", "多少" });

            dict.Add("A", new List<string>() { "A", "Ａ", "a", "ａ" });
            dict.Add("B", new List<string>() { "B", "Ｂ", "b", "ｂ" });
            dict.Add("C", new List<string>() { "C", "Ｃ", "c", "ｃ" });
            dict.Add("D", new List<string>() { "D", "Ｄ", "d", "ｄ" });
            dict.Add("E", new List<string>() { "E", "Ｅ", "e", "ｅ" });
            dict.Add("F", new List<string>() { "F", "Ｆ", "f", "ｆ" });
            dict.Add("G", new List<string>() { "G", "Ｇ", "g", "ｇ", "9", "９" });
            dict.Add("H", new List<string>() { "H", "Ｈ", "h", "ｈ" });
            dict.Add("I", new List<string>() { "I", "Ｉ", "i", "ｉ", "1", "１" });
            dict.Add("J", new List<string>() { "J", "Ｊ", "j", "ｊ" });
            dict.Add("K", new List<string>() { "K", "Ｋ", "k", "ｋ" });
            dict.Add("L", new List<string>() { "L", "Ｌ", "l", "ｌ", "1", "１" });
            dict.Add("M", new List<string>() { "M", "Ｍ", "m", "ｍ" });
            dict.Add("N", new List<string>() { "N", "Ｎ", "n", "ｎ" });
            dict.Add("O", new List<string>() { "O", "Ｏ", "o", "ｏ", "0", "０" });
            dict.Add("P", new List<string>() { "P", "Ｐ", "p", "ｐ" });
            dict.Add("Q", new List<string>() { "Q", "Ｑ", "q", "ｑ" });
            dict.Add("R", new List<string>() { "R", "Ｒ", "r", "ｒ" });
            dict.Add("S", new List<string>() { "S", "Ｓ", "s", "ｓ", "5", "５" });
            dict.Add("T", new List<string>() { "T", "Ｔ", "t", "ｔ" });
            dict.Add("U", new List<string>() { "U", "Ｕ", "u", "ｕ" });
            dict.Add("V", new List<string>() { "V", "Ｖ", "v", "ｖ" });
            dict.Add("W", new List<string>() { "W", "Ｗ", "w", "ｗ" });
            dict.Add("X", new List<string>() { "X", "Ｘ", "x", "ｘ" });
            dict.Add("Y", new List<string>() { "Y", "Ｙ", "y", "ｙ" });
            dict.Add("Z", new List<string>() { "Z", "Ｚ", "z", "ｚ" });
        }


        private static void Setup()
        {
        //    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        //    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.AppendPrivatePath(@"bin\");
            Directory.CreateDirectory("bin");
            Directory.CreateDirectory(RobotBase.appfolder);
            Directory.CreateDirectory($"{RobotBase.appfolder}conf");

            try
            {
                IniFile i = new IniFile(RobotBase.appfolder + RobotBase.iniconf);
                long admin = 0;
                Int64.TryParse(i.IniReadValue(CQAPI.GetLoginQQ(RobotBase.CQ_AuthCode).ToString(), "AdminQQ"), out admin);
                if (admin > 0)
                {
                    RobotBase.AdminQQ = admin.ToString();
                }
            }
            catch { }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CQAPI.AddLog(RobotBase.CQ_AuthCode, CQAPI.LogPriority.CQLOG_ERROR, "ERROR", "UnhandledException");
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{args.Name.Split(',')[0]}.dll"))
            {
                if (stream == null)
                {
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (assemblies.Where(w => w.FullName == args.Name).Count() > 0)
                    {
                        return assemblies.First(f => f.FullName == args.Name);
                    }
                    else
                    {
                        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "/bin", $"{assembly.GetName().Name}.{args.Name.Split(',')[0]}.dll")))
                        {
                            return Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), "/bin", $"{assembly.GetName().Name}.{args.Name.Split(',')[0]}.dll"));
                        }
                        return assembly;
                    }
                }
                else
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Flush();
                    stream.Close();
                    return Assembly.Load(buffer);
                }
            }
        }

    }
}

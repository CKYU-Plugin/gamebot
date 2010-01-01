
namespace Robot.Code
{
    public class CQCode
    {
        /// <summary>
        /// 获取 @指定QQ 的操作代码
        /// </summary>
        /// <param name="qq">指定的QQ号码
        /// <para>当该参数为-1时，操作为 @全部成员</para>
        /// </param>
        /// <returns>CQ @操作代码</returns>
        public static string CQCode_At(long qq)
        {
            return "[CQ:at,qq=" + (qq == -1 ? "all" : qq.ToString()) + "]";
        }
    }
}

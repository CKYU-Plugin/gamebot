using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace System
{
    public static class ExtensionMethods
    {

    }

    public class IAwaiter : INotifyCompletion
    {
        public bool IsCompleted { get; }

        public void GetResult()
        {
        }

        public void OnCompleted(Action continuation)
        {
            continuation();
        }
    }

    public static class Awaiter
    {
        public static IAwaiter GetAwaiter(this int i)
        {
            return new IAwaiter();
        }
        public static IAwaiter GetAwaiter(this string s)
        {
            return new IAwaiter();
        }
    }

    public static class EnumExtension
    {
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}

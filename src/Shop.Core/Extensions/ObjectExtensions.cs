using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static T FailIfNull<T>(this T value, string exeptionMessage) where T : class
        {
            if(value == null)
            {
                throw new Exception(exeptionMessage);
            }
            return value;
        }
        public static void FailIfExist<T>(this T value, string exeptionMessage) where T: class
        {
            if(value != null)
            {
                throw new Exception(exeptionMessage);
            }
        }
    }
}

using System;

namespace Cr7Sund.FrameWork.Util
{
    public class AssertUtilEditor
    {
        public static void IsAssignableFrom<TEnum>(Type excepted, Type actual, TEnum errorCode) where TEnum : Enum
        {
            if (MacroDefine.IsEditor)
            {
                AssertUtil.IsAssignableFrom(excepted, actual, errorCode);
            }
        }

    }
}
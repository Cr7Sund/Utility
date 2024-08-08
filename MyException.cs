/*
 * we don't recommend the api provide message like below
 *
        public static void IsFalse(bool expected, string message)
        {
            if (expected)
            {
                throw new AssertionException(message);
            }
        }

 * since we want to utilize the assert message, the last but not the least to delay the string message to generate
 * and if you want to show your custom error message,
 * instead we recommend pass a new specific exception type to provide meaningful error messages.
 */
namespace Cr7Sund.Utility
{
    public class MyException : Exception
    {
        public Enum Type { get; private set; }


        public MyException(string message) : base(message)
        {

        }

#if UNITY_EDITOR
        public MyException(Enum type) : base($"ErrorCode: {type}")
        {
            Type = type;
        }

        public MyException(string message, Enum type) : base($"ErrorCode: {type} Info:  {message} ")
        {
            Type = type;
        }
#else
        public MyException(Enum type)
        {
            Type = type;
        }

        public MyException(string message, Enum type) : base(message)
        {
            Type = type;
        }
#endif

        public override string ToString()
        {
            // PLAN: support unity document log internal
            #if DEBUG
            return $"ErrorCode: {Type} \n {this.StackTrace}";
            #else
            return Type.ToString();
            #endif
        }
    }
}

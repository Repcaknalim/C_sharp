using Extensions;

namespace Extending
{
    class Program
    {
        static void Main()
        {
            string message = "Kot! Help!";
            Console.WriteLine(message.IsDistressCall());
        }
    }
}

namespace Extensions
{
    public static class Extensions
    {
        public static bool IsDistressCall(this string s)
        {
            return s.Contains("Help!");
        }
    }
}
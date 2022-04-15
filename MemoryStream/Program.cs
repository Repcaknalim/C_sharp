using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        using (var ms = new MemoryStream())
        {
            using (var sw = new StreamWriter(ms))
            {
                sw.WriteLine("Value: {0:00.0}.", 123.456789);
            }
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
}
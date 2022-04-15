
namespace Destructors
{
    class Program
    {
        public class Objectt
        {
            public static int ObjCount = 0;
            public int ObjID { get; } = ++ObjCount;
            public Objectt() => Console.WriteLine("Object nr.{0}.", ObjID);
            ~Objectt()
            {
                Console.WriteLine($"Object nr.{ObjID} has been destroyed");
            }
        }

        static void Main()
        {
            var Stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var objects = new List<Objectt>();
            while(true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'a':
                        objects.Add(new Objectt());
                        break;
                    case 'c':
                        Console.WriteLine("Empting the list... Time: {0}", Stopwatch.ElapsedMilliseconds);
                        objects.Clear();
                        break;
                    case 'g':
                        Console.WriteLine("Reclaiming memory... Time: {0}", Stopwatch.ElapsedMilliseconds);
                        GC.Collect();
                        break;
                };
            }
        }
    }
}
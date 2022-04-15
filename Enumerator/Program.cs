using System.Collections;

enum Sport { Futbol, Baseball, Basketball, Rugby, Fencing, Boxing}

namespace enume
{
    class Program
    {
        class ManualSportSequence : IEnumerable<Sport>
        {
            public IEnumerator<Sport> GetEnumerator()
            {
                return new ManualSportEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public Sport this[int index]
            {
                get => (Sport)index;
            }
        }

        class ManualSportEnumerator : IEnumerator<Sport>
        {
            int current = -1;
            public Sport Current { get { return (Sport)current; } }
            public void Dispose() { return; }
            object IEnumerator.Current { get { return Current; } }
            public bool MoveNext()
            {
                var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
                if ((int)current >= maxEnumValue - 1)
                {
                    return false;
                }
                current++;
                return true;
            }
            public void Reset() { current = 0; }
        }

        static IEnumerable<string> SimpleEnumerable()
        {
            yield return "Apples";
            yield return "Oranges";
            yield return "Bananas";
            yield return "Unicorns";
        }

        class BetterSportSequence : IEnumerable<Sport>
        {
            public IEnumerator<Sport> GetEnumerator()
            {
                int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
                for (int i = 0; i <= maxEnumValue; i++)
                {
                    yield return (Sport)i;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public Sport this[int index]
            {
                get => (Sport)index;
            }
        }

        static void Main()
        {
            var sports = new ManualSportSequence();
            foreach(var sport in sports)
            {
                Console.WriteLine(sport);
            }
            Console.WriteLine(sports[2]);

            foreach (var s in SimpleEnumerable()) Console.WriteLine(s);

            var BSports = new BetterSportSequence();
            foreach (var s in BSports)
                Console.WriteLine(s);
            Console.WriteLine(BSports[2]);
        }
    }
}


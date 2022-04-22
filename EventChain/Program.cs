using System;

namespace EventChain
{
    class Program
    {
        static int count;

        static void SaySomething(object sender, TalkEventArgs e)
            => Console.WriteLine($"Call #{count++}: I said something: {e.Message}");

        static void SaySomethingElse (object sender, TalkEventArgs e)
            => Console.WriteLine($"Call #{count++}: I said something else: {e.Message}");

        static void Main()
        {
            var MyEvent = new Talker();
            while(true)
            {
                Console.Write("1 to chain SaySomething, 2 to chain SaySomethingElse, or a message: ");
                var line = Console.ReadLine();
                switch(line)
                {
                    case "1":
                        Console.WriteLine("Adding SaySomething");
                        MyEvent.TalkToMe += SaySomething;
                        break;
                    case "2":
                        Console.WriteLine("Adding SaySomethingElse");
                        MyEvent.TalkToMe += SaySomethingElse;
                        break;
                    default:
                        count = 1;
                        Console.WriteLine("Raising the TalkToMe event");
                        MyEvent.OnTalkToMe(line);
                        break;
                }
            }
        }
    }

    class TalkEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public TalkEventArgs(string message) => Message = message;
    }

    class Talker
    {
        // Create the event
        public event EventHandler<TalkEventArgs> TalkToMe;

        // Invoke the event
        public void OnTalkToMe(string message) => TalkToMe?.Invoke(this, new TalkEventArgs(message));
    }
}
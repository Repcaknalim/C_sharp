using System;

namespace Events
{ 
    class Program
    {
        static readonly Ball ball = new Ball();
        static readonly Pitcher pitcher = new Pitcher(ball);
        static readonly Fan fan = new Fan(ball);

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter the number for the angle (NaN to quit): ");
                if (int.TryParse(Console.ReadLine(), out int angle))
                {
                    Console.WriteLine("Enter the number for the distace (NaN to quit): ");
                    if (int.TryParse(Console.ReadLine(), out int distance))
                    {
                        // Create event with arguments
                        BallEventArgs ballEventArgs = new BallEventArgs(angle, distance);

                        // Invoke the event via another object's event
                        var bat = ball.GetNewBat();
                        bat.HitTheBall(ballEventArgs);
                    }
                    else
                        return;
                }
                else
                    return;
            }
        }
    }

    // Event Arguments
    class BallEventArgs : EventArgs
    {
        public int Angle { get; private set; }
        public int Distance { get; private set; }

        public BallEventArgs(int angle, int distance)
        {
            Angle = angle;
            Distance = distance;
        }
    }

    // Object raising the event
    class Ball
    {
        // Event
        public event EventHandler<BallEventArgs> BallInPlay;

        // Link one class to another event
        public Bat GetNewBat() => new Bat(new BatCallback(OnBallInPlay));

        // Method for invoking the event
        protected void OnBallInPlay(BallEventArgs e) => BallInPlay?.Invoke(this, e);
    }

    // Object subbing to the event
    class Pitcher
    {
        private int pitchNumber = 0;

        // Subbing to the event in ctor
        public Pitcher(Ball ball) => ball.BallInPlay += Ball_BallInPlayEventHandler;

        // Event Handler
        private void Ball_BallInPlayEventHandler(object? sender, BallEventArgs e)
        {
            pitchNumber++;
            if ((e.Distance < 95) && (e.Angle < 60))
                Console.WriteLine($"Pitch #{pitchNumber}: I caught the ball");
            else
                Console.WriteLine($"Pitch #{pitchNumber}: I covered first base");
        }
    }

    // Another object listening to the event
    class Fan
    {
        private int fanNumber = 0;

        // Subbing to the event in ctor
        public Fan(Ball ball) => ball.BallInPlay += Ball_BallInPlayEventHandler;

        // Event Handler
        private void Ball_BallInPlayEventHandler(object? sender, EventArgs e)
        {
            fanNumber++;
            if (e is BallEventArgs ballEventArgs)   // Downcast the EventArgs
            {
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Angle > 30))
                    Console.WriteLine($"Fan #{fanNumber}: I caught the ball!");
                else
                    Console.WriteLine($"Fan #{fanNumber}: [screaming and yelling]");
            }
        }
    }
}
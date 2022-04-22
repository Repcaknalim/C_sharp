using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    delegate void BatCallback(BallEventArgs e);

    class Bat
    {
        private BatCallback hitBallCallback;

        public Bat(BatCallback callbackDelegate) => this.hitBallCallback = callbackDelegate;

        // Invoke event
        public void HitTheBall(BallEventArgs e) => hitBallCallback?.Invoke(e);
    }
}

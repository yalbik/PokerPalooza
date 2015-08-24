using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pokerpalooza.domain
{
    public class TimerExpiredException : Exception
    {
        public TimerExpiredException(string msg) : base(msg) { }
    }

    public class BlindTimer
    {
        public int Remaining { get; set; }
        public int StartingInterval { get; set; } // seconds
        public bool Paused { get; set; }
        public Thread TimerThread;

        public BlindTimer(int intervalInSeconds)
        {
            StartingInterval = intervalInSeconds;
            Remaining = StartingInterval;
            Paused = true;
        }

        public void Start()
        {
            Paused = false;
            TimerThread = new Thread(new ThreadStart(Run));
            TimerThread.Start();
        }

        public void Stop()
        {
            Paused = true;
            TimerThread.Abort();
        }

        public void End()
        {
            if (TimerThread != null)
                TimerThread.Abort();
        }

        public int SecondsRemaining()
        {
            return Remaining;
        }

        public TimeSpan TimeRemaining()
        {
            return new TimeSpan(0, 0, Remaining);
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Remaining--;
                if (Remaining == 0)
                    break;
            }
        }
    }
}

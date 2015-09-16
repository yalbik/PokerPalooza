using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace pokerpalooza.domain
{
    public interface IBlindController
    {
        void Start();
        void Pause();
        void End();
    }
    
    public class BlindController : IBlindController
    {
        public BlindTimer BlindTimer { get; set; }
        Blind Blind { get; set; }
        DateTime startTime, endTime;

        public BlindController(Blind blind)
        {
            BlindTimer = new BlindTimer((Blind.Interval * 60 * 1000));
        }
        
        public void Start()
        {
            if (startTime == null)
                startTime = DateTime.Now;
            BlindTimer.Start();
        }

        public void Pause()
        {
            BlindTimer.Stop();
        }

        public void End()
        {
            BlindTimer.Stop();
        }

        // returns seconds!
        public int TimeRemaining()
        {
            return BlindTimer.Remaining;
        }
    }
}

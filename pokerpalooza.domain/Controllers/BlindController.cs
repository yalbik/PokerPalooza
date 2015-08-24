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
        public Timer BlindTimer { get; set; }
        Blind Blind { get; set; }

        public BlindController(Blind blind)
        {
            BlindTimer = new Timer((double)(Blind.Interval * 60 * 1000));
        }
        
        public void Start()
        {
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
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class GameState
    {
        public int ID { get; set; }
        public Game Game { get; set; }
        public BlindSetup BlindSetup { get; set; }
        Timer Timer { get; set; }        
        public bool Paused { get; set; }
    }
}

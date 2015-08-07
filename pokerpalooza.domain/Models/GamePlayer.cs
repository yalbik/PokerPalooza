using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class GamePlayer
    {
        public int ID { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public int Rebuys { get; set; }
        public bool Playing { get; set; }
        public int Placement { get; set; }
    }
}

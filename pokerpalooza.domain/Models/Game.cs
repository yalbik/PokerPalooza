using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class Game
    {
        public int ID { get; set; }
        public DateTime GameTime { get; set; }
        public int Buyin { get; set; }
        public int Bounty { get; set; }
        public IEnumerable<GamePlayer> Players { get; set; }
    }
}

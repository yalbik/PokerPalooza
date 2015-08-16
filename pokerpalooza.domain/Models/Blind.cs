using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class Blind
    {
        public int ID { get; set; }
        public int BlindSetupID { get; set; }
        public int Interval { get; set; }
        public int BlindLevel { get; set; }
    }
}

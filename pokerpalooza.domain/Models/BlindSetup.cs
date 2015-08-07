using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class BlindSetup
    {
        public int ID { get; set; }
        public int Length { get; set; }
        public IEnumerable<Blind> BlindLevels { get; set; }
    }
}

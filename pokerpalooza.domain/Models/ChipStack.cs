using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.domain.Models
{
    public class ChipStack
    {
        public int ID { get; set; }
        public IEnumerable<Chip> Colors { get; set; }
    }
}

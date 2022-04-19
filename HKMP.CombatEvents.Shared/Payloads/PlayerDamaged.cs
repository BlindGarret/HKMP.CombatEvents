using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKMP.CombatEvents.Shared.Payloads
{
    public class PlayerDamaged
    {
        public ushort PlayerId { get; set; }
        
        public string PlayerName { get; set; }

        public int HazardType { get; set; }

        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace APBD_KOLPROB2.DTO
{
    public class ActionDTO
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }

        public IEnumerable<FireTruckDTO> Firetrucks { get; set; }
    }
}

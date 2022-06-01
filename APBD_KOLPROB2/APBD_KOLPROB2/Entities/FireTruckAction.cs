using System;

namespace APBD_KOLPROB2.Entities
{
    public class FireTruckAction
    {
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }
        public DateTime AssignmentDate { get; set; }

        public virtual FireTruck IdFireTruckNavigation { get; set; }
        public virtual Action IdActionNavigation { get; set; }
    }
}

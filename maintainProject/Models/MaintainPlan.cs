using System;
using System.Collections.Generic;

#nullable disable

namespace maintainProject.Models
{
    public partial class MaintainPlan
    {
        public int EquipmentId { get; set; }
        public int MaintainId { get; set; }
        public string RegularDatetime { get; set; }
        public int? Times { get; set; }
        public DateTime? SpecialDatetime { get; set; }
        public DateTime PlanStartDatetime { get; set; }
        public DateTime NextMaintainDatetime { get; set; }
        public string IsStop { get; set; }
        public string MaintainStatus { get; set; }
        public DateTime CrtDatetime { get; set; }
        public string CrtUserId { get; set; }
    }
}

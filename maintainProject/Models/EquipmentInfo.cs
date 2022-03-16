using System;
using System.Collections.Generic;

#nullable disable

namespace maintainProject.Models
{
    public partial class EquipmentInfo
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentStatus { get; set; }
        public ulong? IsStop { get; set; }
        public DateTime CrtDatetime { get; set; }
        public string CrtUserId { get; set; }
    }
}

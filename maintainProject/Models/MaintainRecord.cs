using System;
using System.Collections.Generic;

#nullable disable

namespace maintainProject.Models
{
    public partial class MaintainRecord
    {
        public int RecordId { get; set; }
        public int EquipmentId { get; set; }
        public int MaintainId { get; set; }
        public string MaintainUserId { get; set; }
        public string MaintainDesc { get; set; }
        public string PassUserId { get; set; }
        public string PassDesc { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public string Status { get; set; }
    }
}

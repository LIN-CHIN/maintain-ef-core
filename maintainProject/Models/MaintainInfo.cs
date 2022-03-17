﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace maintainProject.Models
{
    public partial class MaintainInfo
    {
        public int MaintainItemId { get; set; }

        public string MaintainItemName { get; set; }

        public string MaintainType { get; set; }

        public DateTime CrtDatetime { get; set; }

        public string CrtUserId { get; set; }
    }
}

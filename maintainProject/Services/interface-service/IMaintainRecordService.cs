using maintainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services.interface_service
{
    public interface IMaintainRecordService
    {
        public IList<MaintainRecord> GetMaintainRecordList();

        public MaintainRecord GetMaintainRecordByID(int record_id);

        public HttpResultModel InsertMaintainRecord(MaintainRecord maintainRecord);

        public HttpResultModel UpdateMaintainRecord(MaintainRecord maintainRecord);

        public HttpResultModel DeleteMaintainRecord(int record_id);


    }
}

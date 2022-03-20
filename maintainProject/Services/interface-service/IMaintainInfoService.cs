using maintainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services.interface_service
{
    public interface IMaintainInfoService
    {
        public IList<MaintainInfo> GetMaintainInfoList();
        public MaintainInfo GetMaintainInfoByID(int maintain_item_id);
        public HttpResultModel InsertMaintainInfoList(MaintainInfo maintainInfo);
        public HttpResultModel UpdateMaintainInfoList(MaintainInfo maintainInfo);
        public HttpResultModel DeleteMaintainInfoList(int maintain_item_id);



    }
}

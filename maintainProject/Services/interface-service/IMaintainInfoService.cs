using maintainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services.interface_service
{
    public interface IMaintainInfoService
    {
        public IList<MaintainInfo> getMaintainInfoList();
        public MaintainInfo getMaintainInfoByID(int maintain_item_id);
        public HttpResultModel insertMaintainInfoList(MaintainInfo maintainInfo);
        public HttpResultModel updateMaintainInfoList(MaintainInfo maintainInfo);
        public HttpResultModel deleteMaintainInfoList(int maintain_item_id);



    }
}

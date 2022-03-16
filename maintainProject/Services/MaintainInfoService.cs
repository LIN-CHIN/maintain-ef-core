using maintainProject.Models;
using maintainProject.Services.interface_service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services
{
    public class MaintainInfoService : IMaintainInfoService
    {
        private readonly MaintainContext _maintainContext;
        public MaintainInfoService(MaintainContext maintainContext) 
        {
            _maintainContext = maintainContext; 
        }

        public IList<MaintainInfo> getMaintainInfoList()
        {
            return _maintainContext.MaintainInfos.OrderBy(x => x.CrtDatetime)
                                                 .ToList();
        }

        public MaintainInfo getMaintainInfoByID(int maintain_item_id)
        {
            return _maintainContext.MaintainInfos.Where(x => x.MaintainItemId == maintain_item_id)
                                                 .FirstOrDefault();
        }

        public HttpResultModel insertMaintainInfoList(MaintainInfo maintainInfo)
        {
            throw new NotImplementedException();
        }

        public HttpResultModel updateMaintainInfoList(int maintain_item_id)
        {
            throw new NotImplementedException();
        }

        public HttpResultModel deleteMaintainInfoList(int maintain_item_id)
        {
            throw new NotImplementedException();
        }
    }
}

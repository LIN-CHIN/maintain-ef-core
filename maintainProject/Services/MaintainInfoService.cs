using maintainProject.Models;
using maintainProject.Services.interface_service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (!checkVaue(maintainInfo)) 
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "請檢查資料是否正確，必填欄位不可為空"
                };

            }

            try
            {
                _maintainContext.MaintainInfos.Add(maintainInfo);
                return new HttpResultModel
                {
                    _status_code = 200,
                    _message = "新增成功"
                };
            } 
            catch (Exception ex) 
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "新增異常"
                };
            }
        }

        public HttpResultModel updateMaintainInfoList(int maintain_item_id)
        {
            throw new NotImplementedException();
        }

        public HttpResultModel deleteMaintainInfoList(int maintain_item_id)
        {
            throw new NotImplementedException();
        }

        private bool checkVaue(MaintainInfo maintainInfo) 
        {
            bool result = true;

            if (maintainInfo.MaintainItemId <= 0 || string.IsNullOrWhiteSpace(maintainInfo.MaintainItemName) ||
                string.IsNullOrWhiteSpace(maintainInfo.MaintainType) || string.IsNullOrWhiteSpace(maintainInfo.CrtDatetime.ToString()) ||
                string.IsNullOrWhiteSpace(maintainInfo.CrtUserId)) 
            {
                result = false;
            }

            return result;
        }
    }
}

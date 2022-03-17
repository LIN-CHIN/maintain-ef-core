using maintainProject.Models;
using maintainProject.Services.interface_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (!checkValue(maintainInfo))
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
                _maintainContext.SaveChanges();
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

        public HttpResultModel updateMaintainInfoList(MaintainInfo maintainInfo)
        {
            try 
            {
                MaintainInfo model = _maintainContext.MaintainInfos
                                                     .Where(x => x.MaintainItemId == maintainInfo.MaintainItemId)
                                                     .FirstOrDefault();

                if (model == null)
                {
                    return new HttpResultModel
                    {
                        _status_code = 400,
                        _message = "查不到此筆資料"
                    };
                }

                model.MaintainItemName = maintainInfo.MaintainItemName;
                model.MaintainType = maintainInfo.MaintainType;
                _maintainContext.SaveChanges();

                return new HttpResultModel
                {
                    _status_code = 200,
                    _message = "修改成功"
                };
            }
            catch(Exception ex) 
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "修改異常"
                };
            }   
        }

        public HttpResultModel deleteMaintainInfoList(int maintain_item_id)
        {
            try 
            {
                MaintainInfo model = _maintainContext.MaintainInfos
                                                      .Where(x => x.MaintainItemId == maintain_item_id)
                                                      .FirstOrDefault();

                if (model == null)
                {
                    return new HttpResultModel
                    {
                        _status_code = 400,
                        _message = "查不到此筆資料"
                    };
                }

                _maintainContext.MaintainInfos.Remove(model);
                _maintainContext.SaveChanges();
                return new HttpResultModel
                {
                    _status_code = 200,
                    _message = "刪除成功"
                };

            }
            catch(Exception ex) 
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "刪除異常"
                };
            }
        }

        #region checkValue
        private bool checkValue(MaintainInfo maintainInfo) 
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(maintainInfo.MaintainItemName) ||
                string.IsNullOrWhiteSpace(maintainInfo.MaintainType) || string.IsNullOrWhiteSpace(maintainInfo.CrtDatetime.ToString()) ||
                string.IsNullOrWhiteSpace(maintainInfo.CrtUserId)) 
            {
                result = false;
            }

            return result;
        }
        #endregion
    }
}

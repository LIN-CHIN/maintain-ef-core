using maintainProject.Models;
using maintainProject.Services.interface_service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services
{
    public class MaintainPlanService : IMaintainPlanService
    {
        private readonly MaintainContext _maintainContext;
        public MaintainPlanService(MaintainContext maintainContext) 
        {
            _maintainContext = maintainContext;
        }

        public IList<MaintainPlan> GetMaintainPlanList()
        {
            return _maintainContext.MaintainPlans.OrderBy(x => x.CrtDatetime)
                                                 .ToList();
        }

        public MaintainPlan GetMaintainPlanByID(int equipment_id, int maintain_id)
        {
            return _maintainContext.MaintainPlans
                                   .Where(x => x.EquipmentId == equipment_id && x.MaintainId == maintain_id)
                                   .FirstOrDefault();
        }

        public HttpResultModel InsertMaintainPlan(MaintainPlan maintainPlan)
        {
            if (!checkValue(maintainPlan))
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "請檢查資料是否正確，必填欄位不可為空"
                };
            }

            try
            {
                _maintainContext.MaintainPlans.Add(maintainPlan);
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

        public HttpResultModel UpdateMaintainPlan(MaintainPlan maintainPlan)
        {
            try
            {
                MaintainPlan model = _maintainContext.MaintainPlans
                                                     .Where(x => x.EquipmentId == maintainPlan.EquipmentId && 
                                                                 x.MaintainId == maintainPlan.MaintainId)
                                                     .FirstOrDefault();
                if (model == null)
                {
                    return new HttpResultModel
                    {
                        _status_code = 400,
                        _message = "查不到此筆資料"
                    };
                }

                model.RegularDatetime = maintainPlan.RegularDatetime;
                model.Times = maintainPlan.Times;
                model.SpecialDatetime = maintainPlan.SpecialDatetime;
                model.PlanStartDatetime = maintainPlan.PlanStartDatetime;
                model.NextMaintainDatetime = maintainPlan.NextMaintainDatetime;
                model.IsStop = maintainPlan.IsStop;
                model.MaintainStatus = maintainPlan.MaintainStatus;
                _maintainContext.SaveChanges();

                return new HttpResultModel
                {
                    _status_code = 200,
                    _message = "修改成功"
                };
            }
            catch (Exception ex)
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "修改異常"
                };
            }
        }
        public HttpResultModel DeleteMaintainPlan(int equipment_id, int maintain_id)
        {
            try
            {
                MaintainPlan model = _maintainContext.MaintainPlans
                                                      .Where(x => x.EquipmentId == equipment_id &&
                                                                  x.MaintainId == maintain_id)
                                                      .FirstOrDefault();
                if (model == null)
                {
                    return new HttpResultModel
                    {
                        _status_code = 400,
                        _message = "查不到此筆資料"
                    };
                }

                _maintainContext.MaintainPlans.Remove(model);
                _maintainContext.SaveChanges();
                return new HttpResultModel
                {
                    _status_code = 200,
                    _message = "刪除成功"
                };

            }
            catch (Exception ex)
            {
                return new HttpResultModel
                {
                    _status_code = 400,
                    _message = "刪除異常"
                };
            }
        }

        #region checkValue
        private bool checkValue(MaintainPlan maintainPlan)
        {
            bool result = true;

            if (maintainPlan.EquipmentId <= 0 || maintainPlan.MaintainId <= 0 || 
                maintainPlan.PlanStartDatetime == null || maintainPlan.NextMaintainDatetime == null ||
                maintainPlan.CrtDatetime == null || string.IsNullOrWhiteSpace(maintainPlan.CrtUserId))
            {
                result = false;
            }

            return result;
        }
        #endregion
    }
}

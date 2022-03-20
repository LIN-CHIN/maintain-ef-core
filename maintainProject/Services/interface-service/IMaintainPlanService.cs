using maintainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Services.interface_service
{
    public interface IMaintainPlanService
    {
        public IList<MaintainPlan> GetMaintainPlanList();
        public MaintainPlan GetMaintainPlanByID(int equipment_id, int maintain_id);
        public HttpResultModel InsertMaintainPlan(MaintainPlan maintainPlan);
        public HttpResultModel UpdateMaintainPlan(MaintainPlan maintainPlan);
        public HttpResultModel DeleteMaintainPlan(int equipment_id, int maintain_id);
    }
}

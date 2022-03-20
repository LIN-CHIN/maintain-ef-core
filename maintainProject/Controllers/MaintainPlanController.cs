using maintainProject.Models;
using maintainProject.Services.interface_service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MaintainPlanController : Controller
    {
        private readonly IMaintainPlanService _maintainPlanService;
        public MaintainPlanController(IMaintainPlanService maintainPlanService)
        {
            _maintainPlanService = maintainPlanService;
        }
        [HttpGet]
        public IList<MaintainPlan> Get()
        {
            return _maintainPlanService.GetMaintainPlanList();
        }

        [HttpGet]
        [Route("{maintain_item_id}")]
        public MaintainPlan Get(int equipment_id, int maintain_id)
        {
            return _maintainPlanService.GetMaintainPlanByID(equipment_id, maintain_id);
        }

        [HttpPost]
        public HttpResultModel Post(MaintainPlan maintainPlan)
        {
            return _maintainPlanService.InsertMaintainPlan(maintainPlan);
        }

        [HttpPut]
        public HttpResultModel Update(MaintainPlan maintainPlan)
        {
            return _maintainPlanService.UpdateMaintainPlan(maintainPlan);
        }

        [HttpDelete]
        public HttpResultModel Delete(MaintainPlan maintainPlan)
        {
            return _maintainPlanService.DeleteMaintainPlan(maintainPlan.EquipmentId, maintainPlan.MaintainId);
        }
    }
}

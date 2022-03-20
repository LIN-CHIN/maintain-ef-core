using maintainProject.Models;
using maintainProject.Services;
using maintainProject.Services.interface_service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintainInfoController : Controller
    {
        private readonly IMaintainInfoService _maintainInfoService;
        public MaintainInfoController(IMaintainInfoService maintainInfoService) 
        {
            _maintainInfoService = maintainInfoService;
        }

        [HttpGet]
        public IList<MaintainInfo> Get()
        {
            return _maintainInfoService.GetMaintainInfoList();
        }

        [HttpGet]
        [Route("{maintain_item_id}")]
        public MaintainInfo Get(int maintain_item_id)
        {
            return _maintainInfoService.GetMaintainInfoByID(maintain_item_id);
        }

        [HttpPost]
        public HttpResultModel Post(MaintainInfo maintainInfo) 
        {
            return _maintainInfoService.InsertMaintainInfoList(maintainInfo);
        }

        [HttpPut]
        public HttpResultModel Update(MaintainInfo maintainInfo) 
        {
            return _maintainInfoService.UpdateMaintainInfoList(maintainInfo);
        }

        [HttpDelete]
        public HttpResultModel Delete(MaintainInfo maintainInfo)
        {
            return _maintainInfoService.DeleteMaintainInfoList(maintainInfo.MaintainItemId);
        }
    }
}

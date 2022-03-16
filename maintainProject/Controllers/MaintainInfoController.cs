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
            return _maintainInfoService.getMaintainInfoList();
        }

        [HttpGet]
        [Route("{maintain_item_id}")]
        public MaintainInfo Get(int maintain_item_id)
        {
            return _maintainInfoService.getMaintainInfoByID(maintain_item_id);
        }
    }
}

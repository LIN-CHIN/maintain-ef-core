using maintainProject.Models;
using maintainProject.Services.interface_service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Controllers
{
    public class MaintainRecordController : Controller
    {
        private readonly IMaintainRecordService _maintainRecordService;
        public MaintainRecordController(IMaintainRecordService maintainRecordService)
        {
            _maintainRecordService = maintainRecordService;
        }

        [HttpGet]
        public IList<MaintainRecord> Get()
        {
            return _maintainRecordService.GetMaintainRecordList();
        }

        [HttpGet]
        [Route("{record_id}")]
        public MaintainRecord Get(int record_id)
        {
            return _maintainRecordService.GetMaintainRecordByID(record_id);
        }

        [HttpPost]
        public HttpResultModel Post(MaintainRecord maintainRecord)
        {
            return _maintainRecordService.InsertMaintainRecord(maintainRecord);
        }

        [HttpPut]
        public HttpResultModel Update(MaintainRecord maintainRecord)
        {
            return _maintainRecordService.UpdateMaintainRecord(maintainRecord);
        }

        [HttpDelete]
        public HttpResultModel Delete(int record_id)
        {
            return _maintainRecordService.DeleteMaintainRecord(record_id);
        }
    }
}

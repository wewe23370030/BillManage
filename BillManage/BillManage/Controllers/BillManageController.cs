using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BillManage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillManageController : Controller
    {
        private BillManageService BillManageService;
        public BillManageController(BillManageService billManageService)
        {
            BillManageService = billManageService;
        }

        /// <summary>
        /// 取得指定Account各項產品的unblendedcost總合
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalUnblendedcost/{id}")]
        public IActionResult GetTotalUnblendedcost(long id)
        {
            return Ok(BillManageService.GetTotalUnblendedcost(id));
        }

        /// <summary>
        /// 取得指定Account各項產品每日的UsageAmount總和
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDailyLineItem_UsageAmount/{id}")]
        public IActionResult GetDailyLineItem_UsageAmount(long id)
        {
            return Ok(BillManageService.GetDailyLineItem_UsageAmount(id));
        }
    }
}

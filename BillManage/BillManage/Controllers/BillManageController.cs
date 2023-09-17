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
        /// 取得各項產品的unblendedcost總合
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetTotalUnblendedcost")]
        public IActionResult GetTotalUnblendedcost()
        {
            return Ok(BillManageService.GetTotalUnblendedcost());
        }

        /// <summary>
        /// 取得各項產品每日的UsageAmount總和
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetDailyLineItem_UsageAmount")]
        public IActionResult GetDailyLineItem_UsageAmount()
        {
            return Ok(BillManageService.GetDailyLineItem_UsageAmount());
        }
    }
}

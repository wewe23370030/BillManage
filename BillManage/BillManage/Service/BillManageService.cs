using System.Text.RegularExpressions;

namespace BillManage
{
    public class BillManageService
    {
        private IRepository<BillInformation> Repository { get; set; }
        public BillManageService(IRepository<BillInformation> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// 取得各項產品的unblendedcost總合
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> GetTotalUnblendedcost()
        {
            Dictionary<string, decimal> data = Repository.ReadData()
                .GroupBy(row => row.product_ProductName)
                .ToDictionary(group => group.Key, group => group.Sum(row => (decimal)row.lineItem_UnblendedCost));
            return data;
        }

        /// <summary>
        /// 取得各項產品每日的UsageAmount總和
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, decimal>> GetDailyLineItem_UsageAmount()
        {
            IEnumerable<BillInformation> data = Repository.ReadData();
            Dictionary<string, Dictionary<string, decimal>> result = new Dictionary<string, Dictionary<string, decimal>>();
            foreach (BillInformation row in data)
            {
                string productName = row.product_ProductName;
                if (!result.TryGetValue(productName, out Dictionary<string, decimal>? dailyStatistics))
                {
                    dailyStatistics = new Dictionary<string, decimal>();
                    result.Add(productName, dailyStatistics);
                }
                DateTime startDate = row.lineItem_UsageStartDate;
                //去除時間，當currentDate加到與endDate同日期時一定會執行
                DateTime currentDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);

                while (currentDate <= row.lineItem_UsageEndDate)
                {
                    string formatCurrentDate = currentDate.ToString("yyyy/MM/dd");
                    if (dailyStatistics.TryGetValue(formatCurrentDate, out decimal statisticsData))
                    {
                        dailyStatistics[formatCurrentDate] = statisticsData + (decimal)row.lineItem_UsageAmount;
                    }
                    else
                    {
                        dailyStatistics[formatCurrentDate] = (decimal)row.lineItem_UsageAmount;
                    }
                    currentDate = currentDate.AddDays(1);
                }
            }

            return result;
        }
    }
}

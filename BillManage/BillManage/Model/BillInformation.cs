using System;

namespace BillManage
{
    public class BillInformation
    {
        public double bill_PayerAccountId;
        public string? lineItem_UnblendedRate;
        public double lineItem_UnblendedCost;
        public double lineItem_UsageAccountId;
        public double lineItem_UsageAmount;
        public DateTime lineItem_UsageStartDate;
        public DateTime lineItem_UsageEndDate;
        public string product_ProductName;
    }
}

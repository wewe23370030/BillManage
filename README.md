# BillManage

## API
### GetTotalUnblendedcost
BillManage/GetTotalUnblendedcost

input: 
```
lineitem/usageaccountid
```
output:
```
    {
        "{product/productname_A}": "sum(lineitem/unblendedcost)",
        "{product/productname_B}": "sum(lineitem/unblendedcost)",
        ...
    }
```

### GetDailyLineItem_UsageAmount
BillManage/GetDailyLineItem_UsageAmount

input: 
```
lineitem/usageaccountid
```
output:
```
    {
        "{product/productname_A}": {
            "YYYY/MM/01": "sum(lineItem/UsageAmount)",
            "YYYY/MM/02": "sum(lineItem/UsageAmount)",
            "YYYY/MM/03": "sum(lineItem/UsageAmount)",
            ...
        },
        "{product/productname_B}": {
            "YYYY/MM/01": "sum(lineItem/UsageAmount)",
            "YYYY/MM/02": "sum(lineItem/UsageAmount)",
            "YYYY/MM/03": "sum(lineItem/UsageAmount)",
            ...
        },
    }
```

## DB schema 
```
[bill_PayerAccountId] [float] NOT NULL,
[lineItem_UnblendedRate] [nvarchar](50) NULL,
[lineItem_UnblendedCost] [float] NOT NULL,
[lineItem_UsageAccountId] [float] NOT NULL,
[lineItem_UsageAmount] [float] NOT NULL,
[lineItem_UsageStartDate] [datetime2](7) NOT NULL,
[lineItem_UsageEndDate] [datetime2](7) NOT NULL,
[product_ProductName] [nvarchar](100) NOT NULL
```

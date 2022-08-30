
# Get Payout Required Data for Bank

## Structure

`GetPayoutRequiredDataForBank`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Amount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `Payer` | [`Models.PayerTypeEnum?`](../../doc/models/payer-type-enum.md) | Optional | The type of Payer making the payment. This determines which identity details are used as the payer identity. |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |
| `UsersBankID` | [`Models.UsersBankID`](../../doc/models/users-bank-id.md) | Required | This group consists of a collection of both the user ID group and beneficiary bank ID group. The 'userID' is a collection of user identifier types. The 'benBankID' is a collection of account identifier types. Both the 'userID' and 'benBankID' fields are mandatory. |

## Example (as JSON)

```json
{
  "usersBankID": {
    "userID": {
      "epUserID": 3409890147363,
      "merchantUserID": "userID_1542991954199"
    },
    "benBankID": {
      "epBankID": 4036783,
      "merchantBankID": "bankID_1542991974172"
    }
  }
}
```



# User Deposit Transaction

A financial transaction representing money paid into a merchant's account by a user.

## Structure

`UserDepositTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `DepositDate` | `string` | Required | Valid ISO 8601 date format YYYY-MM-DD. |
| `DepositReference` | `string` | Optional | A Merchant User Deposit Reference. |
| `DepositCountry` | `string` | Required | Valid supported ISO 3166 2-character country code. |
| `AmountDepositedByUser` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `AmountDepositedToMerchant` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FxExecutedDetail` | [`Models.FXExecutedRate`](../../doc/models/fx-executed-rate.md) | Optional | Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types. |
| `UnappliedReason` | `string` | Optional | The reason the deposit was not applied to the merchant's virtual account. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474988435002
  },
  "timestamp": "2018-05-18T11:14:06.136+00:00",
  "transactionType": "User Deposit",
  "amount": {
    "amount": 500,
    "currency": "GBP"
  },
  "movementType": "Credit",
  "statementDetails": [
    {
      "key": "TransactionNarrative",
      "value": "Test User deposit in GBP"
    }
  ],
  "userID": {
    "epUserID": 3430090148263,
    "merchantUserID": "acTest_00175112daaad_na"
  },
  "depositDate": "2018-05-18Z",
  "depositCountry": "GB",
  "unappliedReason": "NULL",
  "amountDepositedByUser": {
    "amount": 500,
    "currency": "GBP"
  },
  "amountDepositedToMerchant": {
    "amount": 500,
    "currency": "GBP"
  }
}
```


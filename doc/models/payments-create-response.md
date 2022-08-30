
# Payments Create Response

Response object to the payout request APIs.

## Structure

`PaymentsCreateResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `BenBankID` | [`Models.BenBankID`](../../doc/models/ben-bank-id.md) | Required | This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `TransactionID` | [`Models.TransactionID`](../../doc/models/transaction-id.md) | Required | Transaction ID type which contains both the unique VPL transaction ID and the merchant supplied transaction ID. |
| `CorrespondentChargesExpected` | `bool?` | Optional | A flag to indicate if correspondent charges are expected during the processing of the payout request. |
| `LiquidityValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `SettlementValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FeeValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FxMethodExpected` | [`Models.FXMethodEnum?`](../../doc/models/fx-method-enum.md) | Optional | Method of FX that will be used to settle the payout request. |
| `FxRate` | [`Models.FXRate`](../../doc/models/fx-rate.md) | Optional | Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `AcceptedDate` | `string` | Required | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This is the timestamp when the payout instruction was accepted by the system. |
| `ExpectedSettlementDate` | `string` | Required | Valid ISO 8601 date format YYYY-MM-DD. This is an Indicative date when the payout instruction is expected to be settled to the bank. This is calculated taking into account such things as acceptedDate, the settlement agreement cut-off time and period, etc. It currently does not take into account individual countries' banking calendars. |

## Example (as JSON)

```json
{
  "userID": {
    "epUserID": 3409890147399,
    "merchantUserID": "userID_1543060156380"
  },
  "benBankID": {
    "epBankID": 4036790,
    "merchantBankID": "bankID_1543060156380"
  },
  "transactionID": {
    "epTransactionID": 281474984546286,
    "merchantTransactionID": "txID_1543060156380"
  },
  "liquidityValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "settlementValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "acceptedDate": "2018-11-24T11:49:24.313+00:00",
  "expectedSettlementDate": "2018-11-26Z"
}
```


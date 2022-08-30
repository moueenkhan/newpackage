
# Payments Registered Beneficiary Create Response

Response object to Create Payment Registered Beneficiary

## Structure

`PaymentsRegisteredBeneficiaryCreateResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TransactionID` | [`Models.TransactionID`](../../doc/models/transaction-id.md) | Required | Transaction ID type which contains both the unique VPL transaction ID and the merchant supplied transaction ID. |
| `CorrespondentChargesExpected` | `bool` | Required | A flag to indicate if correspondent charges are expected during the processing of the payout request. |
| `LiquidityValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `SettlementValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FeeValue` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FxMethodExpected` | [`Models.FXMethodEnum?`](../../doc/models/fx-method-enum.md) | Optional | Method of FX that will be used to settle the payout request. |
| `FxRate` | [`Models.FXRate`](../../doc/models/fx-rate.md) | Optional | Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `AcceptedDate` | `string` | Required | Timestamp when the payout instruction was accepted by the system. (This is known as - and is the same as - the debit value date in the Payout Transaction Detail Type). |
| `ExpectedSettlementDate` | `string` | Required | Indicative date when the payout instruction is expected to be settled to the bank. This is calculated taking into account such things as acceptedDate, the settlement agreement cut-off time and period, etc. It currently does not take into account individual countries' banking calendars. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474984546300,
    "merchantTransactionID": "txID_1543152891155"
  },
  "correspondentChargesExpected": false,
  "liquidityValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "settlementValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "acceptedDate": "2018-11-25T13:34:51.647+00:00",
  "expectedSettlementDate": "2018-11-26Z"
}
```


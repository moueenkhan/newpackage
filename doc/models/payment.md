
# Payment

This request is used to request a payout to a given beneficiary bank account. This message is used by VPL merchants who are requesting payouts on behalf of a customer.

## Structure

`Payment`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TransactionID` | [`Models.TransactionIDMerchant`](../../doc/models/transaction-id-merchant.md) | Required | This group consists of merchant transaction reference only. |
| `PayoutRequestAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `BeneficiaryAmountInformation` | [`Models.BeneficiaryAmountInformation`](../../doc/models/beneficiary-amount-information.md) | Optional | Used to specify the beneficiary amount and the payout currency. |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |
| `BeneficiaryStatementNarrative` | `string` | Optional | Narrative text to be displayed on the beneficiary bank accounts statement, where the banking network supports this.<br>**Constraints**: *Minimum Length*: `0`, *Maximum Length*: `255` |
| `FxTicketID` | `int?` | Optional | Optional FxTicket Id to be used. This is a unique reference sent back to the Merchant as a response to getFXQuote as UID. If specified, the system will honour the rate specified in the FX Ticket for the Payment. The VPL System will validate the specified FX Ticket including TTL on the Ticket. If the TTL has expired, the VPL system will throw an error.<br>**Constraints**: `>= 0`, `<= 9999999999999` |
| `RequestedFX` | [`Models.RequestedFXEnum?`](../../doc/models/requested-fx-enum.md) | Optional | Method of FX that is requested by the merchant and for which EPS2 will attempt to use in order to settle the payout request. |
| `PayerType` | [`Models.PayerTypeEnum?`](../../doc/models/payer-type-enum.md) | Optional | The type of Payer making the payment. This determines which identity details are used as the payer identity. |
| `PayoutType` | `string` | Optional | Reserved for future use. Will be used to state the Payout type.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `100` |
| `PayoutDetails` | [`List<Models.PayoutDetails>`](../../doc/models/payout-details.md) | Optional | Additional information related to the payment such as Purpose of Payment |
| `TransactionHold` | [`Models.TransactionHold`](../../doc/models/transaction-hold.md) | Optional | Parameter to prevent transactions from being processed until the desired time has been reached. Note releaseDateTime must be in UTC format. |

## Example (as JSON)

```json
{
  "transactionID": {
    "merchantTransactionID": "txID_123456"
  },
  "payoutRequestAmount": {
    "amount": 35.18,
    "currency": "GBP"
  },
  "beneficiaryAmountInformation": {
    "beneficiaryAmount": {
      "amount": 105.4,
      "currency": "GBP"
    },
    "payoutCurrency": "GBP"
  },
  "serviceLevel": "standard",
  "beneficiaryStatementNarrative": "Expenses payment"
}
```



# Quotes Indicative Request

This request is used to retrieve an indicative FX rate between the required sell currency and buy currency.

## Structure

`QuotesIndicativeRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SellAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `BuyCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code. Buy Currency is the currency the merchant wishes to buy or convert the sell currency into. For a Payment Request this must be one of the currencies registered for a Beneficiary Bank Account, otherwise the VPL system will throw a validation error.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BuyAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `SellCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code. Sell Currency is the currency the merchant wishes to be debited in, in order to buy the Buy Amount.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |

## Example (as JSON)

```json
{
  "sellAmount": {
    "currency": "EUR",
    "amount": 1000
  },
  "buyCurrency": "GBP",
  "serviceLevel": "standard"
}
```


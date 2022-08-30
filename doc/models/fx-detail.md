
# FX Detail

Represents the details of an FX transaction, encapsulating the sellAmount, buyAmount and fxRate into a single type.

## Structure

`FXDetail`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BuyAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `FxRate` | [`Models.FXRate`](../../doc/models/fx-rate.md) | Required | Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `SellAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |

## Example (as JSON)

```json
{
  "buyAmount": {
    "amount": 100,
    "currency": "GBP"
  },
  "fxRate": {
    "buyCurrency": "GBP",
    "rate": null,
    "sellCurrency": "GBP"
  },
  "sellAmount": {
    "amount": 100,
    "currency": "GBP"
  }
}
```


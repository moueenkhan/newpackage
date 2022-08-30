
# Quotes Indicative Response

This represents and indicative FX rate. No ticket is created in earthport payments system for such indicative quotes.

## Structure

`QuotesIndicativeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FxDetail` | [`Models.FXDetail`](../../doc/models/fx-detail.md) | Required | Represents the details of an FX transaction, encapsulating the sellAmount, buyAmount and fxRate into a single type. |

## Example (as JSON)

```json
{
  "fxDetail": {
    "sellAmount": {
      "currency": "EUR",
      "amount": 1000
    },
    "buyAmount": {
      "currency": "GBP",
      "amount": 822.47
    },
    "fxRate": {
      "sellCurrency": "EUR",
      "buyCurrency": "GBP",
      "rate": 1.21585
    }
  }
}
```


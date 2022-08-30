
# FX Rate

Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.

## Structure

`FXRate`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BuyCurrency` | `string` | Required | Valid supported ISO 4217 3-character currency code.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `Rate` | `double` | Required | It is the exchange rate at which the buy currency is exchanged into the sell currency. In other words it is the buyCurrency:SellCurrency conversation ratio. |
| `SellCurrency` | `string` | Required | Valid supported ISO 4217 3-character currency code.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |

## Example (as JSON)

```json
{
  "buyCurrency": "GBP",
  "rate": null,
  "sellCurrency": "GBP"
}
```


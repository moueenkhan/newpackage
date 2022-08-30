
# Monetary Value

Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.

## Structure

`MonetaryValue`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Amount` | `double` | Required | Decimal amount value. The number of decimal places is defined by the currency. |
| `Currency` | `string` | Required | Valid supported ISO 4217 3-character currency code.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |

## Example (as JSON)

```json
{
  "amount": 100,
  "currency": "GBP"
}
```


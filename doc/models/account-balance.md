
# Account Balance

This element represents the balance of a merchant account or a managed merchant account in a currency registered with the merchant's central virtual account.

## Structure

`AccountBalance`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Balance` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `BalanceTimestamp` | `string` | Optional | The timestamp of when this balance was current at (This is most likely to be within milliseconds of the request time). This is a valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. |
| `LastMovementTimestamp` | `string` | Optional | The timestamp of the last money movement on the customer’s account.This is a valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. |

## Example (as JSON)

```json
{
  "balance": {
    "currency": "GBP",
    "amount": -9643
  },
  "balanceTimestamp": "2018-11-23T14:56:29.788+00:00",
  "lastMovementTimestamp": "2018-11-23T07:55:32.049+00:00"
}
```


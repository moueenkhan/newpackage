
# Refund Payout ID

Used within Payout Transaction (Returned) only when the payout is refunded.

## Structure

`RefundPayoutID`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PaymentID` | `long?` | Optional | VPL transaction ID for the returned transaction. |

## Example (as JSON)

```json
{
  "paymentID": null
}
```


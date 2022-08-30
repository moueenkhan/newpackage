
# Transactions Cancel Response

This represents the response of a cancellation request for a transaction (payout instruction).

## Structure

`TransactionsCancelResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Status` | `string` | Optional | Specifies the status of the associated transaction for the cancellation request. |
| `StatusDescription` | `string` | Optional | Description associated with the cancellation status. |
| `Timestamp` | `string` | Optional | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This represents the cancellation request timestamp. |

## Example (as JSON)

```json
{
  "status": null,
  "statusDescription": null,
  "timestamp": null
}
```



# Transaction Hold

Parameter to prevent transactions from being processed until the desired time has been reached. Note releaseDateTime must be in UTC format.

## Structure

`TransactionHold`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `OffsetMinutes` | `int?` | Optional | This is the time in minutes to hold the transaction until.<br>**Constraints**: `>= 0` |
| `ReleaseDateTime` | `string` | Optional | This is used when you want to provide a specific timestamp to hold the transaction until. A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. |

## Example (as JSON)

```json
{
  "offsetMinutes": null,
  "releaseDateTime": null
}
```


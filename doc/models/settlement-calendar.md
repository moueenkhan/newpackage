
# Settlement Calendar

Represents the cut-off time for a specific settlement date.

## Structure

`SettlementCalendar`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SubmitBy` | `string` | Required | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. Represents settlement cut-off time. |
| `ForValueOn` | `string` | Required | Valid ISO 8601 date format YYYY-MM-DD. Represents settlement date. |

## Example (as JSON)

```json
{
  "submitBy": "5/15/2018 2:28:21 PM",
  "forValueOn": "2001-01-01"
}
```



# Settlement Calendars Get Response

This represents a Settlement Calendar, with a range of settlement dates and the corresponding cut-off time.

## Structure

`SettlementCalendarsGetResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ResponseTimeStamp` | `string` | Required | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. Represents the timestamp when the Settlement Calendar was generated. |
| `SettlementCalendar` | [`List<Models.SettlementCalendar>`](../../doc/models/settlement-calendar.md) | Required | Represents a calander of settlement dates and the cut-off time for these settlement dates. |

## Example (as JSON)

```json
{
  "responseTimeStamp": "5/15/2018 2:28:21 PM",
  "settlementCalendar": [
    {
      "submitBy": "5/15/2018 2:28:21 PM",
      "forValueOn": "2001-01-01"
    }
  ]
}
```


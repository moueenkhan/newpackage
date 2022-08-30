
# Reason

Reason for the refund as specified by the Business Banking Operations Department.

## Structure

`Reason`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `int` | Required | Used to identify the refund, usually industry recognized codes as well as proprietary codes. |
| `Description` | `string` | Required | Description for the refund. |

## Example (as JSON)

```json
{
  "code": 111,
  "description": "Account Address invalid . BE04"
}
```


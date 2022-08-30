
# Additional Field With Validator

Indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory. Also includes the validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied.

## Structure

`AdditionalFieldWithValidator`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Key for list option. |
| `Label` | `string` | Required | Label for list option. |
| `Mandatory` | `bool` | Required | Indicates whether this additional payout details is mandatory. |
| `Validation` | `string` | Required | The validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied. |

## Example (as JSON)

```json
{
  "key": "key0",
  "label": "label0",
  "mandatory": false,
  "validation": "validation8"
}
```


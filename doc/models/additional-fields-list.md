
# Additional Fields List

This optionally contains a list of additional data that may be required if the associated purpose of payment is selected. This section will list a selection of 'additionalFieldWithValues' and/or 'additionalFieldWithValidator':   'additionalFieldWithValues' indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory. 'additionalFieldWithValues' will also be followed by a series of 'fieldValues' that list the valid codes and descriptions that can be submitted as the value of the payoutDetail entry in the payout request. 'additionalFieldWithValidator' indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory 'additionalFieldWithValidator' also includes the validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied.

## Structure

`AdditionalFieldsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AdditionalFieldWithValidator` | [`List<Models.AdditionalFieldWithValidator>`](../../doc/models/additional-field-with-validator.md) | Optional | Indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory. |
| `AdditionalFieldWithValues` | [`List<Models.AdditionalFieldWithValues>`](../../doc/models/additional-field-with-values.md) | Optional | Indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory. |

## Example (as JSON)

```json
{
  "additionalFieldWithValidator": null,
  "additionalFieldWithValues": null
}
```


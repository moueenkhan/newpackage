
# Additional Field With Values

Indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory. This will also be followed by a series of 'fieldValues' that list the valid codes and descriptions that can be submitted as the value of the payoutDetail entry in the payout request.

## Structure

`AdditionalFieldWithValues`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Key for the 'additionalFieldWithValues' data field. |
| `Label` | `string` | Required | Label for the 'additionalFieldWithValues' data field. |
| `Mandatory` | `bool` | Required | Is the 'additionalFieldWithValues' data field? |
| `FieldValue` | [`List<Models.FieldValue>`](../../doc/models/field-value.md) | Required | Value for the 'additionalFieldWithValues' data field.<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "key": "key0",
  "label": "label0",
  "mandatory": false,
  "fieldValue": [
    {
      "label": null,
      "option": null
    },
    {
      "label": null,
      "option": null
    },
    {
      "label": null,
      "option": null
    }
  ]
}
```


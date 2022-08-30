
# Beneficiary Identity List Items

The beneficiaryIdentityField contains optional listItem sub-elements. The listItem sub-elements would normally be present where the inputType attribute is 'list'.

## Structure

`BeneficiaryIdentityListItems`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryIdentityField` | [`List<Models.BeneficiaryIdentityListItem>`](../../doc/models/beneficiary-identity-list-item.md) | Required | List of beneficiary identity listItem sub-elements.<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "beneficiaryIdentityField": [
    {
      "label": "Passport",
      "value": "Passport"
    },
    {
      "label": "National ID Card",
      "value": "National ID Card"
    },
    {
      "label": "Driving License",
      "value": "Driving License"
    }
  ]
}
```


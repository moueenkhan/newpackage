
# Beneficiary Identity Group

This type defines a beneficiary identity data group. Each group is normally represented as a section of fields on the UI. 'groupLabel' is the UI test to display as a name for this section. 'mandatory' indicates whether all section is mandatory. 'elementName' is the name of the element in the addBeneficiaryBankAccount request document for the corresponding section.

## Structure

`BeneficiaryIdentityGroup`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ElementName` | `string` | Required | The name of the VPL element/enum in the addBeneficiaryBankAccount. |
| `GroupLabel` | `string` | Required | Displays a label for this group of identity fields. |
| `Mandatory` | `bool` | Required | Indicates that all the fields within the group are mandatory. |
| `BeneficiaryIdentityFieldsList` | [`Models.BeneficiaryIdentityFieldsList`](../../doc/models/beneficiary-identity-fields-list.md) | Required | This type defines a list of beneficiary identity fields. |

## Example (as JSON)

```json
{
  "elementName": "name",
  "groupLabel": "Enter name",
  "mandatory": true,
  "beneficiaryIdentityFieldsList": {
    "beneficiaryIdentityField": [
      {
        "description": "Enter the first name of the beneficiary",
        "displaySize": 35,
        "elementName": "givenNames",
        "inputType": "text",
        "locale": "en",
        "mandatory": true,
        "maxSize": 1024,
        "subTitle": "The first name of the beneficiary",
        "tabOrder": 1
      },
      {
        "description": "Enter the family name of the beneficiary",
        "displaySize": 35,
        "elementName": "familyName",
        "inputType": "text",
        "locale": "en",
        "mandatory": true,
        "maxSize": 1024,
        "subTitle": "The family name of the beneficiary",
        "tabOrder": 2
      }
    ]
  }
}
```


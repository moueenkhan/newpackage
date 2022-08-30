
# Beneficiary Identity Fields List

This type defines a list of beneficiary identity fields.

## Structure

`BeneficiaryIdentityFieldsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryIdentityField` | [`List<Models.BeneficiaryIdentityField>`](../../doc/models/beneficiary-identity-field.md) | Optional | List of beneficiary identity fields. |

## Example (as JSON)

```json
{
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
```


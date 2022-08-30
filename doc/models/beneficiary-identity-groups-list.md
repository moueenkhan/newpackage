
# Beneficiary Identity Groups List

This type defines a list of identity data groups. Each group is normally represented as a section of fields on the UI.

## Structure

`BeneficiaryIdentityGroupsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `GroupLabel` | `string` | Required | Label for the beneficiary identity fields. |
| `BeneficiaryIdentityFieldGroup` | [`List<Models.BeneficiaryIdentityGroup>`](../../doc/models/beneficiary-identity-group.md) | Optional | List of field groupings to define the beneficiary identity. |
| `BeneficiaryIdentityFieldGroupChoice` | [`List<Models.BeneficiaryIdentityFieldGroupChoice>`](../../doc/models/beneficiary-identity-field-group-choice.md) | Optional | Conditional sets of field groupings to define the beneficiary identity. i.e. this could present a list of beneficiary identity fields for an individual and also the list of beneficiary identity fields for a legal entity. |

## Example (as JSON)

```json
{
  "groupLabel": "Individual Identity",
  "beneficiaryIdentityFieldGroup": [
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
    },
    {
      "elementName": "address",
      "groupLabel": "Enter address details",
      "mandatory": false,
      "beneficiaryIdentityFieldsList": {
        "beneficiaryIdentityField": [
          {
            "description": "Enter the first line of address of beneficiary",
            "displaySize": 35,
            "elementName": "addressLine1",
            "inputType": "text",
            "locale": "en",
            "mandatory": true,
            "maxSize": 254,
            "subTitle": "First line of address of beneficiary",
            "tabOrder": 3
          },
          {
            "description": "Enter the second line of address of beneficiary",
            "displaySize": 35,
            "elementName": "addressLine2",
            "inputType": "text",
            "locale": "en",
            "mandatory": false,
            "maxSize": 254,
            "subTitle": "Second line of address of beneficiary",
            "tabOrder": 4
          },
          {
            "description": "Enter the third line of address of beneficiary",
            "displaySize": 35,
            "elementName": "addressLine3",
            "inputType": "text",
            "locale": "en",
            "mandatory": false,
            "maxSize": 254,
            "subTitle": "Third line of address of beneficiary",
            "tabOrder": 5
          },
          {
            "description": "Enter the city of residency of beneficiary",
            "displaySize": 35,
            "elementName": "city",
            "inputType": "text",
            "locale": "en",
            "mandatory": true,
            "maxSize": 254,
            "subTitle": "City of residency of beneficiary",
            "tabOrder": 6
          },
          {
            "description": "Enter the province of residency of beneficiary",
            "displaySize": 35,
            "elementName": "province",
            "inputType": "text",
            "locale": "en",
            "mandatory": false,
            "maxSize": 254,
            "subTitle": "Province of residency of beneficiary",
            "tabOrder": 7
          },
          {
            "description": "Enter the postcode of residency of beneficiary",
            "displaySize": 10,
            "elementName": "postcode",
            "inputType": "text",
            "locale": "en",
            "mandatory": false,
            "maxSize": 10,
            "subTitle": "Postcode of residency of beneficiary",
            "tabOrder": 8
          },
          {
            "description": "Enter the ISO county code of residency of beneficiary",
            "displaySize": 2,
            "elementName": "country",
            "inputType": "text",
            "locale": "en",
            "mandatory": true,
            "maxSize": 2,
            "subTitle": "ISO county of residency of beneficiary",
            "tabOrder": 9
          }
        ]
      }
    }
  ]
}
```


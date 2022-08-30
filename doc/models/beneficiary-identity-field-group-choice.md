
# Beneficiary Identity Field Group Choice

This type defines that in common case at least one of the nested groups should be included into addBeneficiaryBankAccount request document. On UI it can be presented with drop-down list containing nested groups labels. 'minElementNum' minimum this number of the nested groups should be specified (1 by default). 'maxElementNum' maximum this number of the nested groups can be specified (1 by default).

## Structure

`BeneficiaryIdentityFieldGroupChoice`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MaxGroupsListNum` | `int` | Required | The maximum number of selections which need to be made from the choices. |
| `MinGroupsListNum` | `int` | Required | The minimum number of selections which need to be made from the choices. |
| `BeneficiaryIdentityFieldGroupsList` | [`List<Models.BeneficiaryIdentityGroupsList>`](../../doc/models/beneficiary-identity-groups-list.md) | Required | List of beneficiary identity field groups. |

## Example (as JSON)

```json
{
  "maxGroupsListNum": 1,
  "minGroupsListNum": 1,
  "beneficiaryIdentityFieldGroupsList": {
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
}
```


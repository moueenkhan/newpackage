
# Beneficiary Identity Field

Each BeneficiaryIdentityField would normally be displayed in the UI from left to right based on the tabOrder attribute. The BeneficiaryIdentityField element contains the attributes described below:-

## Structure

`BeneficiaryIdentityField`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Description` | `string` | Required | Suggested roll-over or help text description to assist users. |
| `DisplaySize` | `long` | Required | A suggested field size to display. |
| `ElementName` | `string` | Required | The name of the element in the addBeneficiaryBankAccount request document for the corresponding field. |
| `InputType` | [`Models.BeneficiaryIdentityFieldInputEnum`](../../doc/models/beneficiary-identity-field-input-enum.md) | Required | Supported input types for a beneficiary identity UI. |
| `Locale` | `string` | Required | The localisation setting of this particular record. |
| `Mandatory` | `bool` | Required | Indicates whether the field is mandatory. |
| `MaxSize` | `long` | Required | Suggested client side syntactic validation rule. |
| `ParameterName` | `string` | Optional | The name of the corresponding VPL parameter to use when calling addBeneficiaryBankAcount. |
| `Separator` | `string` | Optional | The separator to display following (to the right hand side) this field, usually '-' or '/'. |
| `SubTitle` | `string` | Required | If present contains a sub-label to be displayed with the field. |
| `TabOrder` | `long` | Required | Indicates the ordering of this field in the UI. |
| `ValueRegexp` | `string` | Optional | The regexp for the value of this field. |
| `ListItems` | [`Models.BeneficiaryIdentityListItems`](../../doc/models/beneficiary-identity-list-items.md) | Optional | The beneficiaryIdentityField contains optional listItem sub-elements. The listItem sub-elements would normally be present where the inputType attribute is 'list'. |

## Example (as JSON)

```json
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
}
```


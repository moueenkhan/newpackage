
# Beneficiary Bank Account Field

Each beneficiaryBankAccountField would normally be displayed in the UI from left to right based on the tabOrder attribute. The beneficiaryBankAccountField element contains the attributes described below:-

## Structure

`BeneficiaryBankAccountField`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Description` | `string` | Required | Suggested roll-over or help text description to assist users. |
| `DisplaySize` | `int` | Required | A suggested field size to display. |
| `InputType` | [`Models.BeneficiaryBankAccountFieldInputEnum`](../../doc/models/beneficiary-bank-account-field-input-enum.md) | Required | Supported input types for a bank registration UI. |
| `Locale` | `string` | Required | The localisation setting of this particular record. |
| `MaxSize` | `int` | Required | Suggested client side syntactic validation rule. |
| `ParameterName` | `string` | Required | The name of the corresponding VPL parameter to use when calling addBeneficiaryBankAcount. |
| `Separator` | `string` | Required | The separator to display following (to the right hand side) this field, usually '-' or '/'. |
| `SubTitle` | `string` | Required | If present contains a sub-label to be displayed with the field. |
| `TabOrder` | `int` | Required | Indicates the ordering of this field in the UI. |
| `MValue` | `string` | Optional | The current value of this field, populated by the getBeneficiaryBankAccount service. |
| `ListItems` | [`Models.BeneficiaryBankAccountListItems`](../../doc/models/beneficiary-bank-account-list-items.md) | Optional | The beneficiaryBankAccountField contains optional listItem sub-elements. The listItem sub-elements would normally be present where the inputType attribute is 'list'. |

## Example (as JSON)

```json
{
  "description": "Enter the Account Number",
  "displaySize": 8,
  "inputType": "text",
  "locale": "en",
  "maxSize": 8,
  "parameterName": "accountNumber",
  "separator": " ",
  "subTitle": "Account",
  "tabOrder": 3
}
```


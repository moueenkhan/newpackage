
# Beneficiary Bank Account Group

This type defines a bank account data group. Each group is normally represented as a row on the UI.

## Structure

`BeneficiaryBankAccountGroup`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `GroupLabel` | `string` | Required | The UI text to display as a name for this row. |
| `Mandatory` | `bool` | Required | Indicates whether values must be supplied in the fields of this group. |
| `BeneficiaryBankAccountFieldsList` | [`Models.BeneficiaryBankAccountFieldsList`](../../doc/models/beneficiary-bank-account-fields-list.md) | Required | This type defines a bank account field. |

## Example (as JSON)

```json
{
  "groupLabel": "Account Number",
  "mandatory": true,
  "beneficiaryBankAccountFieldsList": {
    "beneficiaryBankAccountField": [
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
    ]
  }
}
```


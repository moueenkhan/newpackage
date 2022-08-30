
# Beneficiary Bank Account Groups List

This type defines a list of bank account data groups. Each group is normally represented as a row on the UI.

## Structure

`BeneficiaryBankAccountGroupsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryBankAccountFieldGroup` | [`List<Models.BeneficiaryBankAccountGroup>`](../../doc/models/beneficiary-bank-account-group.md) | Required | List of beneficiary bank account groups. |

## Example (as JSON)

```json
{
  "beneficiaryBankAccountFieldGroup": [
    {
      "groupLabel": "Account Number updated",
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
  ]
}
```


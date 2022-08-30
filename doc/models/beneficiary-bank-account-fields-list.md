
# Beneficiary Bank Account Fields List

This type defines a bank account field.

## Structure

`BeneficiaryBankAccountFieldsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryBankAccountField` | [`List<Models.BeneficiaryBankAccountField>`](../../doc/models/beneficiary-bank-account-field.md) | Optional | List of beneficiary bank account fields. |

## Example (as JSON)

```json
{
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
```


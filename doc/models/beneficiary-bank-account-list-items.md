
# Beneficiary Bank Account List Items

The beneficiaryBankAccountField contains optional listItem sub-elements. The listItem sub-elements would normally be present where the inputType attribute is 'list'.

## Structure

`BeneficiaryBankAccountListItems`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryBankAccountField` | [`List<Models.BeneficiaryBankAccountListItem>`](../../doc/models/beneficiary-bank-account-list-item.md) | Required | List of beneficiary Bank Account Field values<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "beneficiaryBankAccountField": [
    {
      "label": "Checking",
      "value": "1"
    },
    {
      "label": "Savings",
      "value": "2"
    }
  ]
}
```


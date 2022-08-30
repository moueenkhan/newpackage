
# Bank Account Details

This group holds all possible account identifier types - listed below in alphabetical order. The data which should be supplied in this group differs depending on the bank account territory. Please refer to the integration guide for territory specific details of what should be supplied. The following set of parameter names are valid keys:- abaRoutingNumber, accountName, accountNumber, accountNumberPrefix, accountNumberSuffix, accountType, bankCode, bankName, branchCode, bic, holdingBranchName, iban, miscField1, miscField2, miscField3, sortCode, swiftBic.

## Structure

`BankAccountDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Type which defines the allowable data which may be passed to the "key" element of the BankAccountDetails.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `MValue` | `string` | Required | Type which defines the allowable data which may be passed to the "value" element of the BankAccountDetails.<br>**Constraints**: *Minimum Length*: `1` |

## Example (as JSON)

```json
{
  "key": "accountNumber",
  "value": "06970093"
}
```


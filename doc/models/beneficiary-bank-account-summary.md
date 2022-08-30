
# Beneficiary Bank Account Summary

Represents a summary of a bank account. This type masks sensitive account information such as Account Numbers and IBANs.

## Structure

`BeneficiaryBankAccountSummary`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BenBankID` | [`Models.BenBankID`](../../doc/models/ben-bank-id.md) | Optional | This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `Description` | `string` | Optional | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component of the BeneficiaryBankAccount complex type.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Optional | Valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Optional | The bank account details such as accountName, bankName, accountNumber etc...The list of bank account fields vary by country.<br>**Constraints**: *Minimum Items*: `1` |
| `Status` | `string` | Optional | Status of the bank account. |

## Example (as JSON)

```json
{
  "benBankID": {
    "epBankID": 4034215,
    "merchantBankID": "bankID_1540304037951"
  },
  "description": "Bank Account Description",
  "countryCode": "GB",
  "bankAccountDetails": [
    {
      "key": "bankName",
      "value": "Test Bank"
    },
    {
      "key": "accountName",
      "value": "account name"
    },
    {
      "key": "currencyCode",
      "value": "GBP"
    },
    {
      "key": "accountNumber",
      "value": "****0093"
    }
  ],
  "status": "ACTIVE"
}
```


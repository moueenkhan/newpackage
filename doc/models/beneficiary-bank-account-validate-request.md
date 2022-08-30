
# Beneficiary Bank Account Validate Request

The beneficiary bank account Object that needs to be validated.

## Structure

`BeneficiaryBankAccountValidateRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `Description` | `string` | Required | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Required | The territory in which this bank account is domiciled is mandatory and must be supplied in the 'countryCode' field as a valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Optional | The currency held in this bank account may optionally be supplied in the 'currencyCode' field as a valid supported ISO 4217 3-character currency code. If not supplied it will assume the default currency of the 'countryCode' parameter.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Required | This is a group of sub-elements which collectively identify both the bank and the account within the bank.<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "beneficiaryIdentity": {
    "individualIdentity": {
      "name": {
        "familyName": "Smith",
        "givenNames": "John"
      }
    }
  },
  "description": "Bank Account Description",
  "countryCode": "GB",
  "currencyCode": "GBP",
  "bankAccountDetails": [
    {
      "key": "accountNumber",
      "value": "06970093"
    },
    {
      "key": "accountName",
      "value": "account name"
    },
    {
      "key": "bankName",
      "value": "Test Bank"
    },
    {
      "key": "sortCode",
      "value": "800554"
    }
  ]
}
```


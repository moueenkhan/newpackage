
# Bank Account

The beneficiary bank account Object. This type provides all the possible information required to identify a beneficiary bank account.

## Structure

`BankAccount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BenBankID` | [`Models.BenBankIDMerchant`](../../doc/models/ben-bank-id-merchant.md) | Optional | This group consists of merchant beneficiary bank identifier only. |
| `BeneficiaryIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `Description` | `string` | Required | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Required | The territory in which this bank account is domiciled. This is a valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Required | Valid supported ISO 4217 3-character currency code. The currency held in this bank account may optionally be supplied. If not supplied it will assume the default currency of the 'countryCode' parameter.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Required | This group holds the key-value pair of all possible account identifiers.<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "benBankID": {
    "merchantBankID": "bankID_12345678"
  },
  "beneficiaryIdentity": {
    "individualIdentity": {
      "name": {
        "familyName": "Smith",
        "givenNames": "John"
      },
      "address": {
        "addressLine1": "ABC",
        "addressLine2": "ABC",
        "addressLine3": "ABC",
        "city": "ABC",
        "country": "GB",
        "postcode": "EC1A 4HY",
        "province": "ABC"
      }
    }
  },
  "description": "J Smith current account",
  "countryCode": "GB",
  "currencyCode": "GBP",
  "bankAccountDetails": [
    {
      "key": "accountNumber",
      "value": "06970093"
    },
    {
      "key": "accountName",
      "value": "Mr. John Smith"
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



# Beneficiary Bank Account Create Request

This request is used by customers to register a beneficiary bank account within the system. The beneficiary bank account is validated before creating it. If the  beneficiary bank account is a duplicate of one previously registered against the supplied UserID, the call simply returns the beneficiary bank account ID. Otherwise, a new beneficiary bank account is registered and the beneficiary bank account ID returned in the response.

## Structure

`BeneficiaryBankAccountCreateRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BenBankID` | [`Models.BenBankIDMerchant`](../../doc/models/ben-bank-id-merchant.md) | Optional | This group consists of merchant beneficiary bank identifier only. |
| `BeneficiaryIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `Description` | `string` | Required | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component of the BeneficiaryBankAccount complex type. For this field, you can provide information that is relevant to the bank account being created, i.e. the account holders name or bank account name.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Required | Valid supported ISO 3166 2-character country code. This represents the territory in which this bank account is domiciled<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Optional | Valid supported ISO 4217 3-character currency code. The currency held in this bank account may optionally be supplied in this field. If not supplied it will assume the default currency of the 'countryCode' parameter.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Required | It is a is a group of sub-elements which collectively identify both the bank and the account within the bank.<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "benBankID": {
    "merchantBankID": "bnk_12345678"
  },
  "beneficiaryIdentity": {
    "individualIdentity": {
      "name": {
        "familyName": "Smith",
        "givenNames": "John"
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
      "value": "Mr. J Smith"
    },
    {
      "key": "bankName",
      "value": "Barclays Bank"
    },
    {
      "key": "sortCode",
      "value": "800554"
    }
  ]
}
```


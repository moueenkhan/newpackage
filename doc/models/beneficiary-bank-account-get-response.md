
# Beneficiary Bank Account Get Response

This type provides all the possible information required to identify a beneficiary bank account.

## Structure

`BeneficiaryBankAccountGetResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `BenBankID` | [`Models.BenBankID`](../../doc/models/ben-bank-id.md) | Required | This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `BeneficiaryIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `Description` | `string` | Required | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component of the BeneficiaryBankAccount.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Required | Valid supported ISO 3166 2-character country code. It is the territory in which this bank account is domiciled.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Required | Valid supported ISO 4217 3-character currency code. The currency held in this bank account may optionally be supplied in this field.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `IsActive` | `bool` | Required | Return true if the bank account is active |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Required | This is a group of sub-elements which collectively identify both the bank and the account within the bank<br>**Constraints**: *Minimum Items*: `1` |

## Example (as JSON)

```json
{
  "userID": {
    "epUserID": 3409890146942,
    "merchantUserID": "userID_1540303323210"
  },
  "benBankID": {
    "epBankID": 4034215,
    "merchantBankID": "bankID_1540304037951"
  },
  "beneficiaryIdentity": null,
  "description": "Mr J Smith",
  "countryCode": "GB",
  "currencyCode": "GBP",
  "isActive": true,
  "bankAccountDetails": [
    {
      "key": "bankName",
      "value": "Test Bank"
    },
    {
      "key": "accountName",
      "value": "Mr J. Smith"
    },
    {
      "key": "accountNumber",
      "value": "06970093"
    },
    {
      "key": "sortCode",
      "value": "800554"
    },
    {
      "key": "bic",
      "value": "BOFSGB21377"
    }
  ]
}
```



# Bank Account Expected Settlement Request

This request can be used to determine whether a beneficiary bank account is deemed valid, and to obtain an expected settlement date for any	payout to this bank.

## Structure

`BankAccountExpectedSettlementRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `Description` | `string` | Required | Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryCode` | `string` | Required | The territory in which this bank account is domiciled is mandatory and must be supplied in the 'countryCode' field as a valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Optional | The currency held in this bank account may optionally be supplied in the 'currencyCode' field as a valid supported ISO 4217 3-character currency code. If not supplied it will assume the default currency of the 'countryCode' parameter.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BankAccountDetails` | [`List<Models.BankAccountDetails>`](../../doc/models/bank-account-details.md) | Required | This is a group of sub-elements which collectively identify both the bank and the account within the bank.<br>**Constraints**: *Minimum Items*: `1` |
| `PayoutRequestCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code of the payout request. Will default to the beneficiary bank currency if not supplied.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `AnticipatedPayoutRequestTime` | `string` | Required | A valid ISO 8601 timestamp(YYYY-MM-DDThh:mm:ss.sss±hh:mm). This represents the timestamp when the payout is anticipated to be requested. This cannot be a time in the past. Recommendation is to supply the dateTime in UTC timezone or +0000 offset. Non zero offset times will be converted to UTC by the service. In this case, the client should ensure the supplied time is that intended for the supplied timezone or offset, and be aware this dateTime will be converted to UTC prior to expected settlement date calculation. |
| `PayerIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |
| `PayerType` | [`Models.PayerTypeEnum?`](../../doc/models/payer-type-enum.md) | Optional | The type of Payer making the payment. This determines which identity details are used as the payer identity. |
| `PayoutDetails` | [`List<Models.PayoutDetails>`](../../doc/models/payout-details.md) | Optional | PayoutDetails are used for key-value pairs of details supported by payouts. Refer to client guides for detailed list of valid keys. |
| `TransactionHold` | [`Models.TransactionHold`](../../doc/models/transaction-hold.md) | Optional | Parameter to prevent transactions from being processed until the desired time has been reached. Note releaseDateTime must be in UTC format. |

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
  "description": "test",
  "countryCode": "GB",
  "bankAccountDetails": [
    {
      "key": "accountName",
      "value": "Mr J Doe"
    },
    {
      "key": "accountNumber",
      "value": "70872490"
    },
    {
      "key": "bankName",
      "value": "Natwest"
    },
    {
      "key": "sortCode",
      "value": "404784"
    }
  ],
  "anticipatedPayoutRequestTime": "2018-12-14T23:00:00.000Z",
  "payoutRequestCurrency": "GBP",
  "serviceLevel": "standard",
  "payerType": "user",
  "payerIdentity": {
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
  }
}
```


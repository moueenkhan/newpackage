
# Payout Transaction

A financial transaction representing a payout from an account held in the VPL system.

## Structure

`PayoutTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UsersBankID` | [`Models.UsersBankID`](../../doc/models/users-bank-id.md) | Required | This group consists of a collection of both the user ID group and beneficiary bank ID group. The 'userID' is a collection of user identifier types. The 'benBankID' is a collection of account identifier types. Both the 'userID' and 'benBankID' fields are mandatory. |
| `PayoutRequestAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `SettlementInstructionAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `BeneficiaryStatementNarrative` | `string` | Required | Narrative text to be displayed on the beneficiary bank accounts statement, where the banking network supports this. |
| `PayoutDetails` | [`List<Models.PayoutDetails>`](../../doc/models/payout-details.md) | Optional | Allows additional data to be supplied with a payout. Refer to documentation for valid keys. |
| `ExpectedSettlementDate` | `string` | Required | Indicative date when the payout instruction is expected to be settled to the bank. This is calculated taking into account such things as acceptedDate, the settlement agreement cut-off time and period, etc. It currently does not take into account individual countries' banking calendars. |
| `BeneficiaryBankCountry` | `string` | Required | Country of the target beneficiary bank. |
| `BeneficiaryBankCurrency` | `string` | Required | Currency of the target beneficiary bank account. |
| `DebitValueDate` | `string` | Required | Timestamp when the payout instruction was accepted by the Earthport payment system. |
| `PayerIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `PayerCreatedDate` | `string` | Required | Date payer was created. |
| `FxExecutedDetail` | [`Models.FXExecutedRate`](../../doc/models/fx-executed-rate.md) | Optional | Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types. |
| `RefundPayoutID` | [`Models.RefundPayoutID`](../../doc/models/refund-payout-id.md) | Optional | Used within Payout Transaction (Returned) only when the payout is refunded. |
| `DateSentToBank` | `string` | Optional | Valid ISO 8601 date format YYYY-MM-DD. Date of when the payment was actually sent to the bank. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474988440111,
    "merchantTransactionID": "txID_1532520105368"
  },
  "timestamp": "2018-07-25T12:01:46.254+00:00",
  "transactionType": "Payout",
  "transactionStatus": {
    "code": 100,
    "description": "Pending Processing"
  },
  "amount": {
    "amount": 11,
    "currency": "GBP"
  },
  "movementType": "Debit",
  "usersBankID": {
    "userID": {
      "epUserID": 3430090151306,
      "merchantUserID": "userID_1532520072742"
    },
    "benBankID": {
      "epBankID": 7430956,
      "merchantBankID": "bankID_1532520087364"
    }
  },
  "payoutRequestAmount": {
    "amount": 11,
    "currency": "GBP"
  },
  "settlementInstructionAmount": {
    "amount": 11,
    "currency": "GBP"
  },
  "beneficiaryStatementNarrative": "Free Text Description",
  "expectedSettlementDate": "2018-11-30Z",
  "beneficiaryBankCountry": "GB",
  "beneficiaryBankCurrency": "GBP",
  "debitValueDate": "2018-07-25T12:01:46.254+00:00",
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
      },
      "birthInformation": {
        "cityOfBirth": "ABC",
        "countryOfBirth": "GB",
        "dateOfBirth": "2001-01-01Z"
      },
      "identification": [
        {
          "idType": "Passport",
          "identificationCountry": "GB",
          "identificationNumber": "ABC123",
          "validFromDate": "2001-01-01Z",
          "validToDate": "2001-01-01Z"
        }
      ]
    }
  },
  "payerCreatedDate": "2018-07-25Z"
}
```


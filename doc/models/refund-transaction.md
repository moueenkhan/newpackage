
# Refund Transaction

## Structure

`RefundTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `FxExecutedDetail` | [`Models.FXExecutedRate`](../../doc/models/fx-executed-rate.md) | Optional | Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types. |
| `AmountRefundedByBank` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `AmountRefundedToCustomer` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `Reason` | [`Models.Reason`](../../doc/models/reason.md) | Required | Reason for the refund as specified by the Business Banking Operations Department. |
| `OriginalPayoutTransaction` | [`Models.PayoutTransaction`](../../doc/models/payout-transaction.md) | Required | A financial transaction representing a payout from an account held in the VPL system. |

## Example (as JSON)

```json
{
  "transactionID": null,
  "timestamp": null,
  "amount": {
    "amount": 100,
    "currency": "GBP"
  },
  "movementType": null,
  "userID": {
    "epUserID": 3409890146942,
    "merchantUserID": "userID_1540303323210"
  },
  "amountRefundedByBank": {
    "amount": 100,
    "currency": "GBP"
  },
  "amountRefundedToCustomer": {
    "amount": 100,
    "currency": "GBP"
  },
  "reason": {
    "code": 111,
    "description": "Account Address invalid . BE04"
  },
  "originalPayoutTransaction": {
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
}
```


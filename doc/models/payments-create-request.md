
# Payments Create Request

This is a composite request. It is used when you have to create a payment request to a beneficiary bank account which is not previously registered on the VPL payment system. This request is also extended to create a payment request on behalf of a user that is not previously registered on the VPL system.

## Structure

`PaymentsCreateRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `User` | [`Models.User`](../../doc/models/user.md) | Required | A user Object. |
| `BankAccount` | [`Models.BankAccount`](../../doc/models/bank-account.md) | Required | The beneficiary bank account Object. This type provides all the possible information required to identify a beneficiary bank account. |
| `Payment` | [`Models.Payment`](../../doc/models/payment.md) | Required | This request is used to request a payout to a given beneficiary bank account. This message is used by VPL merchants who are requesting payouts on behalf of a customer. |

## Example (as JSON)

```json
{
  "user": {
    "userID": {
      "merchantUserID": "userID_12345"
    },
    "accountCurrency": "GBP"
  },
  "bankAccount": {
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
  },
  "payment": {
    "transactionID": {
      "merchantTransactionID": "txID_123456"
    },
    "payoutRequestAmount": {
      "amount": 35.18,
      "currency": "GBP"
    },
    "beneficiaryAmountInformation": {
      "beneficiaryAmount": {
        "amount": 105.4,
        "currency": "GBP"
      },
      "payoutCurrency": "GBP"
    },
    "serviceLevel": "standard",
    "beneficiaryStatementNarrative": "Expenses payment"
  }
}
```


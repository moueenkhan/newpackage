
# Beneficiary Bank Account List Response

This type gives a summary of all the Beneficiary Bank Accounts. This is used by customers to list all of the active beneficiary bank accounts within the system for the specified UserID (epUserID or merchantUserID). Note that summary bank account details mask sensitive account information such as account numbers and IBANs.

## Structure

`BeneficiaryBankAccountListResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryBankAccountSummary` | [`List<Models.BeneficiaryBankAccountSummary>`](../../doc/models/beneficiary-bank-account-summary.md) | Required | Bank account summary returned in the list beneficiary bank accounts service. The summary version of a bank account does not include the beneficiary identity details. It also masks or obfuscates sensitive data such as account numbers. |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `PaginationResult` | [`Models.PaginationResult`](../../doc/models/pagination-result.md) | Required | This returns a paged set of results rather than the full result set. |

## Example (as JSON)

```json
{
  "beneficiaryBankAccountSummary": [
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
    },
    {
      "benBankID": {
        "epBankID": 4034220,
        "merchantBankID": "bankID_1540313198252"
      },
      "description": "Bank Account Description",
      "countryCode": "FR",
      "bankAccountDetails": [
        {
          "key": "bankName",
          "value": "Test Bank"
        },
        {
          "key": "accountName",
          "value": "sdsd"
        },
        {
          "key": "currencyCode",
          "value": "EUR"
        },
        {
          "key": "iban",
          "value": "***********************8822"
        }
      ],
      "status": "ACTIVE"
    },
    {
      "benBankID": {
        "epBankID": 4034221,
        "merchantBankID": "bankID_1540313268420"
      },
      "description": "Bank Account Description",
      "countryCode": "US",
      "bankAccountDetails": [
        {
          "key": "bankName",
          "value": "Test Bank"
        },
        {
          "key": "accountName",
          "value": "sdsd"
        },
        {
          "key": "currencyCode",
          "value": "USD"
        },
        {
          "key": "accountNumber",
          "value": "******0893"
        }
      ],
      "status": "ACTIVE"
    }
  ],
  "userID": {
    "epUserID": 3409890146942,
    "merchantUserID": "userID_1540303323210"
  },
  "paginationResult": {
    "offset": 0,
    "pageSize": 25,
    "totalNumberOfRecords": 3
  }
}
```


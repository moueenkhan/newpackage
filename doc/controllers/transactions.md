# Transactions

```csharp
ITransactionsController transactionsController = client.TransactionsController;
```

## Class Name

`TransactionsController`

## Methods

* [Cancel Transaction](../../doc/controllers/transactions.md#cancel-transaction)
* [Get Transaction](../../doc/controllers/transactions.md#get-transaction)
* [Search Transactions](../../doc/controllers/transactions.md#search-transactions)


# Cancel Transaction

Cancels a Transaction (payout instruction) which is in a cancellable state in Visa Payments Limited Payments Service.

### Payout Status Table

| Payout External Status| Cancellable|  
| ----------|----------- |  
INSUFFICIENT_MERCHANT_LIQUIDITY|YES|
PENDING_PROCESSING|YES |
IN_PROCESS|NO |
PAYMENT_SENT|NO|
WITH_PARTNER_BANK|NO|
REJECTED_PAYOUT|NO|
PAYMENT_SENT|NO|
RETURNED_PAYOUT|NO|

### Responses

1. **"Pending Cancellation"** Response

This is returned when the payout to be cancelled status is "Held in Compliance"
The payout will be set to a pending cancellation status, which will changed to rejected later on. Either by a compliance rejection or by the automatic cancellation rejection. (Example shown in the 'Example Response' section)

2. **"Cancelled"** : Successful Cancellation Response

This is returned when the transaction is in a cancellable status.

3. **"Validation error"** Response

There are 2 types of validation error responses:

*"Payout not cancellable"* : This is the equivalent to an unsuccessful Cancellation Response and it is returned when the payout was not in a cancellable status ( VPL Error code = 11031)

*"Payout not found"*: This occurs when the system can not locate the payment to be cancelled or the transaction Ids not matching original transaction

```csharp
CancelTransactionAsync(
    string transactionID,
    Models.IdTypeEnum? idType = null,
    string merchantCancellationReqID = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionID` | `string` | Template, Required | A unique transaction ID. You can use Visa Payments Limited transaction id or merchant transaction reference. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |
| `merchantCancellationReqID` | `string` | Query, Optional | The ID provided by the merchant that will uniquely identify this cancellation request. |

## Response Type

[`Task<Models.TransactionsCancelResponse>`](../../doc/models/transactions-cancel-response.md)

## Example Usage

```csharp
string transactionID = "281474988434819";
string merchantCancellationReqID = "12345";

try
{
    TransactionsCancelResponse result = await transactionsController.CancelTransactionAsync(transactionID, null, merchantCancellationReqID);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "status": "PendingCancellation",
  "statusDescription": "Cancellation Request received for a transaction that cannot be cancelled immediately. A refund notification will be issued if and when this transaction is successfully cancelled",
  "timestamp": "2018-11-24T14:08:52.985+00:00"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


# Get Transaction

Retrieves a single Transaction based on TransactionID.

```csharp
GetTransactionAsync(
    string transactionID,
    Models.IdTypeEnum? idType = null,
    string managedMerchantName = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transactionID` | `string` | Template, Required | A unique transaction ID. You can use either Visa Payments Limited transaction ID or merchant transaction ID. Note when using the merchant transaction ID you must set the query parameter idType as merchant. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | This allows you to specify either your own unique identifier (UID) or Visa Payments Limited generated unique identifier (UID). Visa Payments Limited generated UID will be used by default. |
| `managedMerchantName` | `string` | Query, Optional | The name of the managed merchant who created or owns the transaction. Do not supply if you either do not have any managed merchants configured or the managed merchant did not create this transaction. If this is not supplied and the managed merchant did create this transaction then you will receive a "Validation failure: Financial Transaction not found" error, even though the transaction does exist. |

## Response Type

[`Task<Models.FinancialTransaction>`](../../doc/models/financial-transaction.md)

## Example Usage

```csharp
string transactionID = "281474984525097";

try
{
    FinancialTransaction result = await transactionsController.GetTransactionAsync(transactionID, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "transactionID": {
    "epTransactionID": 281474984525097,
    "merchantTransactionID": "txID_1538474668029"
  },
  "timestamp": "2018-10-02T10:04:29.338+00:00",
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
      "epUserID": 3409890146710,
      "merchantUserID": "userID_1538473974001"
    },
    "benBankID": {
      "epBankID": 4024363,
      "merchantBankID": "bankID_1538474577593"
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
  "payoutDetails": [
    {
      "Key": "K1",
      "Value": "V1"
    },
    {
      "Key": "K2",
      "Value": "V2"
    }
  ],
  "expectedSettlementDate": "2018-11-26Z",
  "beneficiaryBankCountry": "GB",
  "beneficiaryBankCurrency": "GBP",
  "debitValueDate": "2018-10-02T10:04:29.338+00:00",
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
    },
    "additionalData": [
      {
        "Key": "NATIONAL_ID_CARD",
        "Value": "TT6789CC"
      }
    ]
  },
  "payerCreatedDate": "2018-10-02Z"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


# Search Transactions

This allows you to search for payments where you don't know the UID (paymentID) and also allows you to search for other financial transaction types on your account such as refunds, deposits (See Transaction Type).

This API supports sorting by "Timestamp" or "Amount" in a particular sort order (ASC or DESC) as well as paging across multiple pages of results.

```csharp
SearchTransactionsAsync(
    string startDateTime,
    string endDateTime,
    Models.SortOrderEnum sortOrder,
    List<string> sortFields,
    string managedMerchantName = null,
    string currency = null,
    double? amountFrom = null,
    double? amountTo = null,
    string merchantTransactionID = null,
    Models.TransactionTypeEnum? transactionType = null,
    int? transactionStatusCode = null,
    int? offset = null,
    int? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `startDateTime` | `string` | Query, Required | Start Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction. |
| `endDateTime` | `string` | Query, Required | End Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction. |
| `sortOrder` | [`Models.SortOrderEnum`](../../doc/models/sort-order-enum.md) | Query, Required | Sort in either ascending or descending order. |
| `sortFields` | `List<string>` | Query, Required | Sort Fields. It can be either Timestamp or Amount or a combination of both. If you want to sort the results based on both the sort fields please provide a comma seperated list of sort fields, i.e. Timestamp,Amount |
| `managedMerchantName` | `string` | Query, Optional | Managed merchant whose transactions will be returned  when being called by the contracting merchant. |
| `currency` | `string` | Query, Optional | Transaction currency (valid supported ISO 4217 3-character currency code). |
| `amountFrom` | `double?` | Query, Optional | Decimal amount value. The number of decimal places is defined by the currency.This is the lower limit of transaction value (inclusive). |
| `amountTo` | `double?` | Query, Optional | Decimal amount value. The number of decimal places is defined by the currency.This is the upper limit of transaction value (inclusive). |
| `merchantTransactionID` | `string` | Query, Optional | Merchant assigned transaction ID (transaction reference). |
| `transactionType` | [`Models.TransactionTypeEnum?`](../../doc/models/transaction-type-enum.md) | Query, Optional | Type of financial transactions. Please provide one of the following transaction types (if none specified all types are searched): Payout, Refund, User Deposit, Merchant Liquidity Deposit, Journal, Merchant Liquidity Movement, Visa Payments Limited Merchant Liquidity Transfer |
| `transactionStatusCode` | `int?` | Query, Optional | Status Code of the Transactions. |
| `offset` | `int?` | Query, Optional | This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset. |
| `pageSize` | `int?` | Query, Optional | This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned. |

## Response Type

[`Task<Models.TransactionsSearchResponse>`](../../doc/models/transactions-search-response.md)

## Example Usage

```csharp
string startDateTime = "01/01/2018 07:36:28";
string endDateTime = "endDateTime0";
SortOrderEnum sortOrder = SortOrderEnum.DESC;
var sortFields = new List<string>();
sortFields.Add("sortFields9");
sortFields.Add("sortFields0");
sortFields.Add("sortFields1");
string currency = "GBP";
double? amountFrom = 69.36;
double? amountTo = 22.46;
int? offset = 0;
int? pageSize = 5;

try
{
    TransactionsSearchResponse result = await transactionsController.SearchTransactionsAsync(startDateTime, endDateTime, sortOrder, sortFields, null, currency, amountFrom, amountTo, null, null, null, offset, pageSize);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "transactions": [
    {
      "transactionID": {
        "epTransactionID": 281474984546286,
        "merchantTransactionID": "txID_1543060156380"
      },
      "timestamp": "2018-11-24T11:49:24.313+00:00",
      "transactionType": "Payout",
      "transactionStatus": {
        "code": 100,
        "description": "Pending Processing"
      },
      "amount": {
        "currency": "GBP",
        "amount": 11
      },
      "movementType": "Debit",
      "usersBankID": {
        "userID": {
          "epUserID": 3409890147399,
          "merchantUserID": "userID_1543060156380"
        },
        "benBankID": {
          "epBankID": 4036790,
          "merchantBankID": "bankID_1543060156380"
        }
      }
    },
    {
      "transactionID": {
        "epTransactionID": 281474984546285,
        "merchantTransactionID": "txID_1543060145826"
      },
      "timestamp": "2018-11-24T11:49:06.923+00:00",
      "transactionType": "Payout",
      "transactionStatus": {
        "code": 100,
        "description": "Pending Processing"
      },
      "amount": {
        "currency": "GBP",
        "amount": 11
      },
      "movementType": "Debit",
      "usersBankID": {
        "userID": {
          "epUserID": 3409890147387,
          "merchantUserID": "userID_1543060145826"
        },
        "benBankID": {
          "epBankID": 4036789,
          "merchantBankID": "bankID_1543060145826"
        }
      }
    },
    {
      "transactionID": {
        "epTransactionID": 281474984546284,
        "merchantTransactionID": "txID_1543060127008"
      },
      "timestamp": "2018-11-24T11:48:49.644+00:00",
      "transactionType": "Payout",
      "transactionStatus": {
        "code": 100,
        "description": "Pending Processing"
      },
      "amount": {
        "currency": "GBP",
        "amount": 11
      },
      "movementType": "Debit",
      "usersBankID": {
        "userID": {
          "epUserID": 3409890147375,
          "merchantUserID": "userID_1543060127008"
        },
        "benBankID": {
          "epBankID": 4036788,
          "merchantBankID": "bankID_1543060127008"
        }
      }
    },
    {
      "transactionID": {
        "epTransactionID": 281474984546283,
        "merchantTransactionID": "txID_1543059648037"
      },
      "timestamp": "2018-11-24T11:40:55.853+00:00",
      "transactionType": "Payout",
      "transactionStatus": {
        "code": 100,
        "description": "Pending Processing"
      },
      "amount": {
        "currency": "GBP",
        "amount": 11
      },
      "movementType": "Debit",
      "usersBankID": {
        "userID": {
          "epUserID": 3409890146942,
          "merchantUserID": "userID_1540303323210"
        },
        "benBankID": {
          "epBankID": 4034215,
          "merchantBankID": "bankID_1540304037951"
        }
      }
    },
    {
      "transactionID": {
        "epTransactionID": 281474984546282,
        "merchantTransactionID": "txID_1543059637509"
      },
      "timestamp": "2018-11-24T11:40:38.674+00:00",
      "transactionType": "Payout",
      "transactionStatus": {
        "code": 100,
        "description": "Pending Processing"
      },
      "amount": {
        "currency": "GBP",
        "amount": 11
      },
      "movementType": "Debit",
      "usersBankID": {
        "userID": {
          "epUserID": 3409890146942,
          "merchantUserID": "userID_1540303323210"
        },
        "benBankID": {
          "epBankID": 4034215,
          "merchantBankID": "bankID_1540304037951"
        }
      }
    }
  ],
  "paginationResult": {
    "offset": 0,
    "pageSize": 5,
    "totalNumberOfRecords": 48
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


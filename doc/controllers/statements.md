# Statements

```csharp
IStatementsController statementsController = client.StatementsController;
```

## Class Name

`StatementsController`


# Get Statement

Retrieves a list of financial transactions and balances for a specified time period for an account administered in the Visa Payments Limited payment system. To retrieve a particular statement the startDate, endDateTime and currency of the account must be specified. The statement returned will contain transactions that occurred since the start of the startDate up to and including endDateTime. If the account (in the requested currency) does not contain any transactions for the period an empty statement is returned. Every transaction, together with the money movement it represents (debit or credit) and its resulting account balance are represented as a statement line item. There will be a number of statement line items (up to the maximum page size) per page with an opening and closing balance for that page. Currently the following transaction types may show up on a statement:

Payout transaction,
Refund transaction,
User deposit,
Liquidity deposit,
Journal transaction,
Merchant liquidity movement,
Visa Payments Limited Merchant Liquidity Transfer

The operation supports sorting (by date) by specifying a sort order (ASC or DESC) and paging across multiple pages of results.

```csharp
GetStatementAsync(
    string currency,
    string startDateTime,
    string endDateTime,
    Models.SortOrderEnum sortOrder,
    string managedMerchantName = null,
    int? offset = null,
    int? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `currency` | `string` | Query, Required | Valid supported ISO 4217 3-character currency code. The currency code representing currency of the user or merchant account. |
| `startDateTime` | `string` | Query, Required | Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The start day of the statement period. All transactions from the start of the day are included. |
| `endDateTime` | `string` | Query, Required | Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The end day timestamp of the statement period. If this is now or null the statement will include all transactions up to the current point in time. |
| `sortOrder` | [`Models.SortOrderEnum`](../../doc/models/sort-order-enum.md) | Query, Required | Sort by transaction date in either Ascending or Descending order. |
| `managedMerchantName` | `string` | Query, Optional | Managed merchant whose transactions will be returned  when being called by the contracting merchant. |
| `offset` | `int?` | Query, Optional | This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset. |
| `pageSize` | `int?` | Query, Optional | This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned. |

## Response Type

[`Task<Models.Statement>`](../../doc/models/statement.md)

## Example Usage

```csharp
string currency = "GBP";
string startDateTime = "01/07/2022 15:50:01";
string endDateTime = "03/07/2022 15:50:01";
SortOrderEnum sortOrder = SortOrderEnum.DESC;
int? offset = 2;
int? pageSize = 3;

try
{
    Statement result = await statementsController.GetStatementAsync(currency, startDateTime, endDateTime, sortOrder, null, offset, pageSize);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "statementLineItems": [
    {
      "transaction": {
        "transactionID": {
          "epTransactionID": 281474984525095
        },
        "timestamp": "2018-10-02T08:58:23.661+00:00",
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
            "epUserID": 3409890146681,
            "merchantUserID": "userID_1538470668310"
          },
          "benBankID": {
            "epBankID": 4024349
          }
        }
      },
      "balance": -38
    },
    {
      "transaction": {
        "transactionID": {
          "epTransactionID": 281474984525097
        },
        "timestamp": "2018-10-02T10:04:29.338+00:00",
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
            "epUserID": 3409890146710,
            "merchantUserID": "userID_1538473974001"
          },
          "benBankID": {
            "epBankID": 4024363,
            "merchantBankID": "bankID_1538474577593"
          }
        }
      },
      "balance": -49
    },
    {
      "transaction": {
        "transactionID": {
          "epTransactionID": 281474984542620
        },
        "timestamp": "2018-10-17T15:20:28.580+00:00",
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
            "epUserID": 3409890146813,
            "merchantUserID": "userID_1539789626198"
          },
          "benBankID": {
            "epBankID": 4033915,
            "merchantBankID": "bankID_1539789626198"
          }
        }
      },
      "balance": -60
    }
  ],
  "paginationResult": {
    "offset": 2,
    "pageSize": 3,
    "totalNumberOfRecords": 64
  },
  "openingBalance": {
    "balance": {
      "amount": -27,
      "currency": "GBP"
    },
    "balanceTimestamp": "2018-11-24T14:04:12.207+00:00"
  },
  "closingBalance": {
    "balance": {
      "amount": -60,
      "currency": "GBP"
    },
    "balanceTimestamp": "2018-11-24T14:04:12.207+00:00"
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
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


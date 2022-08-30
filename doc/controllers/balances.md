# Balances

```csharp
IBalancesController balancesController = client.BalancesController;
```

## Class Name

`BalancesController`


# Get Balance

Retrieves the balance of a merchant account.

This API can be used to retrieve a set of balances represented by a monetary amount for each currency registered with the merchant's central virtual account.

You can filter the AccountBalance resource by currency if you require a balance for a specific currency.
You can also filter the AccountBalance on managedMerchantName. If no managedMerchantName is specified, then the caller will be used to identify which balance to return. If a managedMerchantName is specified, then an authorisation check will occur to ensure that the caller has the right to view the balance information for that managed merchant.

```csharp
GetBalanceAsync(
    string managedMerchantName = null,
    string currency = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `managedMerchantName` | `string` | Query, Optional | The name of a managed merchant registered on Visa Payments Limited. |
| `currency` | `string` | Query, Optional | Valid supported ISO 4217 3-character currency code. |

## Response Type

[`Task<List<Models.AccountBalance>>`](../../doc/models/account-balance.md)

## Example Usage

```csharp
try
{
    List<AccountBalance> result = await balancesController.GetBalanceAsync(null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
[
  {
    "balance": {
      "currency": "EUR",
      "amount": -299
    },
    "balanceTimestamp": "2018-11-24T15:13:20.034+00:00",
    "lastMovementTimestamp": "2018-11-16T10:28:14.179+00:00"
  },
  {
    "balance": {
      "currency": "GBP",
      "amount": -9720
    },
    "balanceTimestamp": "2018-11-24T15:13:20.035+00:00",
    "lastMovementTimestamp": "2018-11-24T11:49:24.313+00:00"
  },
  {
    "balance": {
      "currency": "USD",
      "amount": -55
    },
    "balanceTimestamp": "2018-11-24T15:13:20.035+00:00",
    "lastMovementTimestamp": "2018-10-23T17:13:22.155+00:00"
  }
]
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


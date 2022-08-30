# Quotes

```csharp
IQuotesController quotesController = client.QuotesController;
```

## Class Name

`QuotesController`

## Methods

* [Create Bulk FX Quote](../../doc/controllers/quotes.md#create-bulk-fx-quote)
* [Create FX Quote](../../doc/controllers/quotes.md#create-fx-quote)
* [Get Indicative FX Quote](../../doc/controllers/quotes.md#get-indicative-fx-quote)


# Create Bulk FX Quote

Requests a bulk FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time.

```csharp
CreateBulkFXQuoteAsync(
    List<Models.QuotesBulkRequest> body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`List<Models.QuotesBulkRequest>`](../../doc/models/quotes-bulk-request.md) | Body, Required | Bulk FX Quote Request. |

## Response Type

[`Task<Models.QuotesBulkResponse>`](../../doc/models/quotes-bulk-response.md)

## Example Usage

```csharp
var body = new List<QuotesBulkRequest>();

var body0 = new QuotesBulkRequest();
body0.SellCurrency = "EUR";
body0.BuyCurrency = "GBP";
body0.BuyCountry = "GB";
body0.ServiceLevel = ServiceLevelEnum.Standard;
body.Add(body0);

var body1 = new QuotesBulkRequest();
body1.SellCurrency = "USD";
body1.BuyCurrency = "GBP";
body1.BuyCountry = "GB";
body1.ServiceLevel = ServiceLevelEnum.Standard;
body.Add(body1);

var body2 = new QuotesBulkRequest();
body2.SellCurrency = "AUD";
body2.BuyCurrency = "GBP";
body2.BuyCountry = "GB";
body2.ServiceLevel = ServiceLevelEnum.Standard;
body.Add(body2);


try
{
    QuotesBulkResponse result = await quotesController.CreateBulkFXQuoteAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "fxTicketID": 647228,
  "expiryTimestamp": "2018-11-24T14:46:02.492+00:00",
  "bulkFXDetail": [
    {
      "sellCurrency": "EUR",
      "buyCountry": "GB",
      "buyCurrency": "GBP",
      "serviceLevel": "standard",
      "buyFxRate": 0.82247,
      "sellFxRate": 1.21585
    },
    {
      "sellCurrency": "USD",
      "buyCountry": "GB",
      "buyCurrency": "GBP",
      "serviceLevel": "standard",
      "buyFxRate": 0.741831,
      "sellFxRate": 1.348016
    },
    {
      "sellCurrency": "AUD",
      "buyCountry": "GB",
      "buyCurrency": "GBP",
      "serviceLevel": "standard",
      "buyFxRate": 0.565164,
      "sellFxRate": 1.769399
    }
  ]
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


# Create FX Quote

Requests an FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time. There are two exclusive scenarios when requesting a rate between two currencies:

1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.

2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.

```csharp
CreateFXQuoteAsync(
    string userID,
    string bankID,
    Models.QuotesRequest body,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `bankID` | `string` | Template, Required | Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id. |
| `body` | [`Models.QuotesRequest`](../../doc/models/quotes-request.md) | Body, Required | The request details to get an FX quote and receive a unique Ticket ID with a time to live. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

[`Task<Models.QuotesResponse>`](../../doc/models/quotes-response.md)

## Example Usage

```csharp
string userID = "3409890146942";
string bankID = "4034215";
var body = new QuotesRequest();
body.SellAmount = new MonetaryValue();
body.SellAmount.Amount = 87.64;
body.SellAmount.Currency = "EUR";
body.BuyCurrency = "GBP";
body.ServiceLevel = ServiceLevelEnum.Standard;

try
{
    QuotesResponse result = await quotesController.CreateFXQuoteAsync(userID, bankID, body, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "fxTicketID": 647229,
  "fxDetail": {
    "sellAmount": {
      "currency": "EUR",
      "amount": 1000
    },
    "buyAmount": {
      "currency": "GBP",
      "amount": 822.47
    },
    "fxRate": {
      "sellCurrency": "EUR",
      "buyCurrency": "GBP",
      "rate": 0.82247
    }
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


# Get Indicative FX Quote

Requests an  indicative quote. There are two exclusive scenarios when requesting a rate between two currencies:

1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.

2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.

```csharp
GetIndicativeFXQuoteAsync(
    Models.QuotesIndicativeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.QuotesIndicativeRequest`](../../doc/models/quotes-indicative-request.md) | Body, Required | The request details to get an indicative FX quote. You must either supply the sellAmount and buyCurrency. Or you must supply the buyAmount and sellCurrency. |

## Response Type

[`Task<Models.QuotesIndicativeResponse>`](../../doc/models/quotes-indicative-response.md)

## Example Usage

```csharp
var body = new QuotesIndicativeRequest();
body.SellAmount = new MonetaryValue();
body.SellAmount.Amount = 87.64;
body.SellAmount.Currency = "EUR";
body.BuyCurrency = "GBP";
body.ServiceLevel = ServiceLevelEnum.Standard;

try
{
    QuotesIndicativeResponse result = await quotesController.GetIndicativeFXQuoteAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "fxDetail": {
    "sellAmount": {
      "currency": "EUR",
      "amount": 1000
    },
    "buyAmount": {
      "currency": "GBP",
      "amount": 822.47
    },
    "fxRate": {
      "sellCurrency": "EUR",
      "buyCurrency": "GBP",
      "rate": 1.21585
    }
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


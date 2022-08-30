# Settlement Calendars

```csharp
ISettlementCalendarsController settlementCalendarsController = client.SettlementCalendarsController;
```

## Class Name

`SettlementCalendarsController`


# Get Settlement Calendar

Retrieves the Settlement Calendar for payout.

```csharp
GetSettlementCalendarAsync(
    string beneficiaryCountry,
    string serviceLevel = null,
    string beneficiaryCurrency = null,
    string payoutRequestCurrency = null,
    int? numberOfCalendarDays = 7)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `beneficiaryCountry` | `string` | Query, Required | Valid supported ISO 3166 2-character country code. Represents beneficiary country for the request |
| `serviceLevel` | `string` | Query, Optional | Service Level. Allowed values are standard and express. |
| `beneficiaryCurrency` | `string` | Query, Optional | valid supported ISO 4217 3-character currency code. Represents beneficiary currency for the request. |
| `payoutRequestCurrency` | `string` | Query, Optional | valid supported ISO 4217 3-character currency code. Represents payout currency for the request. |
| `numberOfCalendarDays` | `int?` | Query, Optional | Represents number of days to be returned in the response. Default is 7.<br>**Default**: `7` |

## Response Type

[`Task<Models.SettlementCalendarsGetResponse>`](../../doc/models/settlement-calendars-get-response.md)

## Example Usage

```csharp
string beneficiaryCountry = "FR";
string serviceLevel = "standard";
string beneficiaryCurrency = "EUR";
string payoutRequestCurrency = "GBP";
int? numberOfCalendarDays = 7;

try
{
    SettlementCalendarsGetResponse result = await settlementCalendarsController.GetSettlementCalendarAsync(beneficiaryCountry, serviceLevel, beneficiaryCurrency, payoutRequestCurrency, numberOfCalendarDays);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "responseTimeStamp": "2018-11-24T13:53:56.577+00:00",
  "settlementCalendar": [
    {
      "submitBy": "2018-11-26T14:00:00.000+00:00",
      "forValueOn": "2018-11-26Z"
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


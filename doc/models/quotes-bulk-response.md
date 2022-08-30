
# Quotes Bulk Response

This response is used to represent cross rates between the required sell currencies and buy currencies. A ticket is created on VPL payment system for such quotes.

## Structure

`QuotesBulkResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FxTicketID` | `int?` | Optional | FxTicketID is the unique number within the VPL System representing the list of the FX Quotes presented to the Merchant. This is represented as an FX Ticket ID in Payment Request. Payout Request's specified with the optional FX Ticket Id will be validated against TTL (ExpiryTimestamp). The VPL system will throw a validation error if TTL is expired.<br>**Constraints**: `>= 0`, `<= 9999999999999` |
| `ExpiryTimestamp` | `string` | Optional | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. ExpiryTimestamp represents the datetime value till what the specified FxTicketID is valid. This means that all	rates in the ticket will be valid till this datetime. |
| `BulkFXDetail` | [`List<Models.BulkFXDetail>`](../../doc/models/bulk-fx-detail.md) | Optional | Represents the list of fxRates and their details. |

## Example (as JSON)

```json
{
  "fxTicketID": 647160,
  "expiryTimestamp": "2018-11-23T19:08:37.239+00:00",
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


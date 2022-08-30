
# Quotes Bulk Request

This request is used to retrieve cross rates between the required sell currencies and buy currencies.

## Structure

`QuotesBulkRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SellCurrency` | `string` | Required | Valid supported ISO 4217 3-character currency code. Sell Currency is the currency the merchant wishes to be debited in.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BuyCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code. Buy Currency is the currency the merchant wishes to buy or convert the sell currency into. For a Payment Request this must be one of the currencies registered for a Beneficiary Bank Account, otherwise the VPL system will throw a validation error.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BuyCountry` | `string` | Optional | Valid supported ISO 3166 2-character country code. Represents Buy Country for which FxRate was found.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |

## Example (as JSON)

```json
{
  "sellCurrency": "EUR",
  "buyCountry": "GB",
  "buyCurrency": "GBP",
  "serviceLevel": "standard"
}
```


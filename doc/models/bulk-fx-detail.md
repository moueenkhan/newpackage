
# Bulk FX Detail

represents the list of fxRates and their details.

## Structure

`BulkFXDetail`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SellCurrency` | `string` | Required | Valid supported ISO 4217 3-character currency code. Represents Sell Currency for which FxRate was found.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BuyCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code. Represents Buy Currency for which FxRate was found.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `BuyCountry` | `string` | Optional | Valid supported ISO 3166 2-character country code. Buy Country is the country of the Beneficiary Bank where the merchant wishes to buy or convert the sell currency.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |
| `BuyFxRate` | `double?` | Optional | Represents the FX rate between two currencies that will be applied during a buy direction trade – buying x amount of beneficiary currency (buyCurrency). The rate is restricted to 6 decimal places. |
| `SellFxRate` | `double?` | Optional | Represents the FX rate between two currencies that will be effective during a sell direction trade – selling x amount of payout instruction currency (sellCurrency). The rate is restricted to 6 decimal places. |

## Example (as JSON)

```json
{
  "sellCurrency": "GBP"
}
```



# Get Payout Required Data for Country Currency

## Structure

`GetPayoutRequiredDataForCountryCurrency`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryIdentityEntity` | [`Models.IdentityEntityEnum?`](../../doc/models/identity-entity-enum.md) | Optional | Supported identity entity types. |
| `CountryCode` | `string` | Required | Valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `CurrencyCode` | `string` | Required | Valid supported ISO 4217 3-character currency code.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `Locale` | `string` | Optional | Supports a comma separated list of locales. for example en_GB, en_US in order of preferred locale.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `50` |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |

## Example (as JSON)

```json
{
  "countryCode": "GB",
  "currencyCode": "GBP"
}
```


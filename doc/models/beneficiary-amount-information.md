
# Beneficiary Amount Information

Used to specify the beneficiary amount and the payout currency.

## Structure

`BeneficiaryAmountInformation`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryAmount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Optional | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `PayoutCurrency` | `string` | Optional | Valid supported ISO 4217 3-character currency code.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |

## Example (as JSON)

```json
{
  "beneficiaryAmount": null,
  "payoutCurrency": null
}
```


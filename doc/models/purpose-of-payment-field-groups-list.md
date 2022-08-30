
# Purpose of Payment Field Groups List

This group contains all configuration information for Purpose of Payment options. The 'mandatory' attribute indicates whether provision of Purpose of Payment data is required for the Payout to be accepted.

## Structure

`PurposeOfPaymentFieldGroupsList`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Mandatory` | `bool` | Required | Whether the purpose of payment is mandatory. |
| `PurposeOfPaymentCode` | [`List<Models.PurposeOfPaymentCode>`](../../doc/models/purpose-of-payment-code.md) | Optional | List of valid purpose of payment codes. |

## Example (as JSON)

```json
{
  "mandatory": true
}
```


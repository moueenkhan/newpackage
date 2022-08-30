
# Purpose of Payment Code

This contains a specific Purpose of Payment option, consisting of a code and a human readable description.

## Structure

`PurposeOfPaymentCode`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `string` | Required | VPL purpose of payment code. |
| `Description` | `string` | Required | Description of purpose of payment code. |
| `PurposeOfPaymentUsageRestrictions` | [`Models.PurposeOfPaymentUsageRestrictions`](../../doc/models/purpose-of-payment-usage-restrictions.md) | Required | Usage restrictions apply where a specified code is only acceptable for a given type of payer or beneficiary. This attribute indicates whether the code can be used for Individuals and/or Legal Entities, for both payer and beneficiary parties. Additional field specifications identify further data that is required, given the chosen Purpose of Payment. |

## Example (as JSON)

```json
{
  "code": "SAL",
  "description": "Salary/payroll",
  "purposeOfPaymentUsageRestrictions": null
}
```


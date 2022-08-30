
# Purpose of Payment Usage Restrictions

Usage restrictions apply where a specified code is only acceptable for a given type of payer or beneficiary. This attribute indicates whether the code can be used for Individuals and/or Legal Entities, for both payer and beneficiary parties. Additional field specifications identify further data that is required, given the chosen Purpose of Payment.

## Structure

`PurposeOfPaymentUsageRestrictions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AdditionalFieldsList` | [`Models.AdditionalFieldsList`](../../doc/models/additional-fields-list.md) | Optional | This optionally contains a list of additional data that may be required if the associated purpose of payment is selected. This section will list a selection of 'additionalFieldWithValues' and/or 'additionalFieldWithValidator':   'additionalFieldWithValues' indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory. 'additionalFieldWithValues' will also be followed by a series of 'fieldValues' that list the valid codes and descriptions that can be submitted as the value of the payoutDetail entry in the payout request. 'additionalFieldWithValidator' indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory 'additionalFieldWithValidator' also includes the validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied. |
| `BeneficiaryType` | [`Models.IdentityRestriction`](../../doc/models/identity-restriction.md) | Required | Indicates whether a purpose of payment code is valid if the beneficiary is an individual or legal entity. |
| `OriginatorType` | [`Models.IdentityRestriction`](../../doc/models/identity-restriction.md) | Required | Indicates whether a purpose of payment code is valid if the beneficiary is an individual or legal entity. |

## Example (as JSON)

```json
{
  "additionalFieldsList": null,
  "beneficiaryType": {
    "individual": false,
    "legalEntity": false
  },
  "originatorType": {
    "individual": false,
    "legalEntity": false
  }
}
```


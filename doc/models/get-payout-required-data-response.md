
# Get Payout Required Data Response

All the data required to settle a payment with a given currency into a given country.

## Structure

`GetPayoutRequiredDataResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BeneficiaryBankAccountFieldGroupsList` | [`Models.BeneficiaryBankAccountGroupsList`](../../doc/models/beneficiary-bank-account-groups-list.md) | Optional | This type defines a list of bank account data groups. Each group is normally represented as a row on the UI. |
| `BeneficiaryIdentityFieldGroupsList` | [`Models.BeneficiaryIdentityGroupsList`](../../doc/models/beneficiary-identity-groups-list.md) | Optional | This type defines a list of identity data groups. Each group is normally represented as a section of fields on the UI. |
| `PurposeOfPaymentFieldGroupsList` | [`Models.PurposeOfPaymentFieldGroupsList`](../../doc/models/purpose-of-payment-field-groups-list.md) | Required | This group contains all configuration information for Purpose of Payment options. The 'mandatory' attribute indicates whether provision of Purpose of Payment data is required for the Payout to be accepted. |

## Example (as JSON)

```json
{
  "purposeOfPaymentFieldGroupsList": {
    "mandatory": true
  }
}
```


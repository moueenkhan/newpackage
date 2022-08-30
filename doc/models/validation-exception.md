
# Validation Exception

VPL custom validation exception to handle validation errors. This will be the structure of the payload for various HTTP 4xx errors.

## Structure

`ValidationException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TimeOfFailure` | `string` | Required | Timestamp of the failure. |
| `FailureType` | `string` | Required | Type of failure - will always be validation. |
| `ShortMsg` | `string` | Required | Short descriptive message of the error. |
| `LongMsg` | `string` | Required | More descriptive message of the error. |
| `Code` | `long` | Required | An VPL specific error code. |
| `UniqueErrorID` | `string` | Required | A VPL generated unique error ID. |
| `Failures` | [`List<Models.Failure>`](../../doc/models/failure.md) | Required | An array of validation failures. For instance, if this error is during the creation or validation of a bank account, then each failure could relate to each individual bank account field validation error. |

## Example (as JSON)

```json
{
  "timeOfFailure": "2018-07-19T10:22:15.529+00:00",
  "failureType": "validation",
  "shortMsg": "Beneficiary Bank Account failed validation process",
  "longMsg": "BeneficiaryBankAccount has failed validation",
  "code": 12000,
  "uniqueErrorID": "1TWZLQGL9ZQUQ",
  "failures": [
    {
      "key": "bankAccountDetails.bankName",
      "code": 12041,
      "value": "Beneficiary Bank Name not supplied"
    },
    {
      "key": "bankAccountDetails.sortCode",
      "code": 12201,
      "value": "Beneficiary Bank Account Sort Code supplied is too long"
    }
  ]
}
```



# Failure

An individual failure/error description. This is used by the ValidationException model.

## Structure

`Failure`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Key identifies the specific field which is in error. |
| `Code` | `long` | Required | VPL specific validation error code. |
| `MValue` | `string` | Required | Descriptive explanation of the error. |

## Example (as JSON)

```json
{
  "key": "bankAccountDetails.bankName",
  "code": 12041,
  "value": "Beneficiary Bank Name not supplied"
}
```



# Ben Bank ID

This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.

## Structure

`BenBankID`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EpBankID` | `int?` | Optional | The unique ID of a beneficiary bank account.<br>**Constraints**: `>= 0`, `<= 9999999999999` |
| `MerchantBankID` | `string` | Optional | The merchant specified ID for a beneficiary bank account.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "epBankID": 4034215,
  "merchantBankID": "bankID_1540304037951"
}
```


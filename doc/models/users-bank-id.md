
# Users Bank ID

This group consists of a collection of both the user ID group and beneficiary bank ID group. The 'userID' is a collection of user identifier types. The 'benBankID' is a collection of account identifier types. Both the 'userID' and 'benBankID' fields are mandatory.

## Structure

`UsersBankID`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `BenBankID` | [`Models.BenBankID`](../../doc/models/ben-bank-id.md) | Required | This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |

## Example (as JSON)

```json
{
  "userID": {
    "epUserID": 3409890147363,
    "merchantUserID": "userID_1542991954199"
  },
  "benBankID": {
    "epBankID": 4036783,
    "merchantBankID": "bankID_1542991974172"
  }
}
```


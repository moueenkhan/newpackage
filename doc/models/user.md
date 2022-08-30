
# User

A user Object.

## Structure

`User`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserIDMerchant`](../../doc/models/user-id-merchant.md) | Required | This group consists of merchant user identifier only. |
| `ManagedMerchantName` | `string` | Optional | Refers to the descriptive name used to identify a given merchant. It is unique across VPL merchants.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `30` |
| `AccountCurrency` | `string` | Required | Valid supported ISO 4217 3-character currency code. This is used to set a default account currency.<br>**Constraints**: *Minimum Length*: `3`, *Maximum Length*: `3` |
| `PayerIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Optional | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |

## Example (as JSON)

```json
{
  "userID": {
    "merchantUserID": "userID_12345"
  },
  "accountCurrency": "GBP"
}
```


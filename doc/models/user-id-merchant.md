
# User ID Merchant

This group consists of merchant user identifier only.

## Structure

`UserIDMerchant`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MerchantUserID` | `string` | Required | A unique reference for the merchant that identifies the person or company on behalf of which this account was set up. This needs to be used to reference KYC data held by the merchant (amongst other things). This is often a unique username or reference allocated by the merchant at user registration time.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "merchantUserID": "userID_12345"
}
```


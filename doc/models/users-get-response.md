
# Users Get Response

This response contains the PayerIdentity data including address, birth data, identification and additional elements as appropriate depending on if it is a company or an individuals identity.

## Structure

`UsersGetResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `UserID` | [`Models.UserID`](../../doc/models/user-id.md) | Required | This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated. |
| `PayerIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |
| `CreatedDate` | `DateTime` | Required | The Date the User was created. |

## Example (as JSON)

```json
{
  "userID": {
    "epUserID": 3409890146942,
    "merchantUserID": "userID_1540303323210"
  },
  "payerIdentity": {
    "individualIdentity": {
      "name": {
        "familyName": "Smith",
        "givenNames": "John"
      },
      "address": {
        "addressLine1": "1 Main Street",
        "addressLine2": "Address2",
        "addressLine3": "Address3",
        "city": "London",
        "country": "GB",
        "postcode": "EC1A 4HY"
      }
    }
  },
  "createdDate": "2018-10-23"
}
```


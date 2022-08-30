
# Users Update Request

This request is used to update the identity associated with a payer/user.

## Structure

`UsersUpdateRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PayerIdentity` | [`Models.Identity`](../../doc/models/identity.md) | Required | Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity. |

## Example (as JSON)

```json
{
  "payerIdentity": {
    "individualIdentity": null,
    "legalEntityIdentity": null,
    "unstructuredIdentity": null,
    "additionalData": null
  }
}
```


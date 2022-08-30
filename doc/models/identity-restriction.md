
# Identity Restriction

Indicates whether a purpose of payment code is valid if the beneficiary is an individual or legal entity.

## Structure

`IdentityRestriction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Individual` | `bool` | Required | Is the purpose of payment code valid if the beneficiary is an individual. |
| `LegalEntity` | `bool` | Required | Is the purpose of payment code is valid if the beneficiary is a legal entity. |

## Example (as JSON)

```json
{
  "individual": false,
  "legalEntity": false
}
```


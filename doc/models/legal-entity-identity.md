
# Legal Entity Identity

The identity of a legal entity. The 'legalEntityName' is mandatory. You must supply one of 'legalEntityRegistration' or 'address'.

## Structure

`LegalEntityIdentity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LegalEntityName` | `string` | Required | The name component of the legal entity. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1024` |
| `LegalEntityRegistration` | [`Models.LegalEntityRegistration`](../../doc/models/legal-entity-registration.md) | Optional | This group consists of a legal entity registration number type and the country that the legal entity is registered in. Legal Entity Registration Number is mandatory, Legal Entity Registration Country is mandatory and Legal Entity Registration Province is optional. |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents an address. Mandatory attributes are 'addressLine1', 'city' and 'country'. All other attributes are optional. |

## Example (as JSON)

```json
{
  "legalEntityName": "XYZ Corp"
}
```



# Legal Entity Registration

This group consists of a legal entity registration number type and the country that the legal entity is registered in. Legal Entity Registration Number is mandatory, Legal Entity Registration Country is mandatory and Legal Entity Registration Province is optional.

## Structure

`LegalEntityRegistration`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LegalEntityRegistrationCountry` | `string` | Required | Valid supported ISO 3166 2-character country code. This represents Registration Country of the Legal Entity.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `LegalEntityRegistrationNumber` | `string` | Required | The registration number component of the legal entity. The length of this field is limited to 254 bytes. 254 bytes can hold 254 normal English characters. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `LegalEntityRegistrationProvince` | `string` | Optional | Optional province of the legal entity's address. |

## Example (as JSON)

```json
{
  "legalEntityRegistrationCountry": "GB",
  "legalEntityRegistrationNumber": "QWERTY54321"
}
```



# Address

Represents an address. Mandatory attributes are 'addressLine1', 'city' and 'country'. All other attributes are optional.

## Structure

`Address`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddressLine1` | `string` | Required | A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `AddressLine2` | `string` | Optional | A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `AddressLine3` | `string` | Optional | A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `City` | `string` | Required | A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `Country` | `string` | Required | Valid supported ISO 3166 2-character country code.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `Postcode` | `string` | Optional | A line of address information. The length of this field is limited to 10 bytes. 10 bytes can hold 10 normal English characters. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `10` |
| `Province` | `string` | Optional | A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |

## Example (as JSON)

```json
{
  "addressLine1": "20 Aldersgate St",
  "city": "London",
  "country": "GB"
}
```


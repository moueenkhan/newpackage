
# Identification

This group consists of an individual identification type unique number and the country of origin of the identification. The idType will be a String value saying what the identification number relates to. This might be Passport. national ID card, driving licence or any other value. The idType will be validated against an enumeration to ensure it is of a valid type. Please refer to the VPL "API Solution Guide" for further details. The identification number will normally be the equivalent of a passport number, but other types of identification can be used. The identification country will be the country that issued the identification number, so in the example that a passport number is provided as the identification number, the identification country will be the passport country origin.

## Structure

`Identification`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdType` | `string` | Required | Enumeration of ID Types such as 'Passport', 'Driving License', 'National ID Card'. Please refer to the VPL "API Solution Guide". |
| `IdentificationCountry` | `string` | Required | Valid supported ISO 3166 2-character country code. This represents the country of origin of the identification.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `IdentificationNumber` | `string` | Required | An identification number for an individual. For example, a passport number can be an identification number type. The length of this field is limited to 50 bytes. 50 bytes can hold 50 normal English characters. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `ValidFromDate` | `string` | Optional | Valid ISO 8601 date format YYYY-MM-DD. This represents the valid-from date of the identification document. |
| `ValidToDate` | `string` | Optional | Valid ISO 8601 date format YYYY-MM-DD. This represents the valid-to date of the identification document. |

## Example (as JSON)

```json
{
  "idType": "Passport",
  "identificationCountry": "GB",
  "identificationNumber": "ABC123"
}
```


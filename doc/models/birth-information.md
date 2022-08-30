
# Birth Information

The group consists of elements that define birth information for an individual.

## Structure

`BirthInformation`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CityOfBirth` | `string` | Optional | This represents the city of birth. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `254` |
| `CountryOfBirth` | `string` | Required | Valid supported ISO 3166 2-character country code. This represents the country of birth.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `DateOfBirth` | `string` | Required | Valid ISO 8601 date format YYYY-MM-DD. This represents the date of birth. |

## Example (as JSON)

```json
{
  "countryOfBirth": "GB",
  "dateOfBirth": "2001-01-01"
}
```



# Beneficiary Additional Data

Represents a set of name value pairs that can be supplied with the Identity information. The keys will be validated on the server side against a list of valid types that are accepted. Both the key and the value are required if adding additional data.

## Structure

`BeneficiaryAdditionalData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AdditionalDataKey` | `string` | Required | The length of the additionalDataKey field is currently restricted to 50 bytes. |
| `AdditionalDataValue` | `string` | Required | The length of the additionalDataValue field is currently restricted to 1024. |

## Example (as JSON)

```json
{
  "additionalDataKey": "additionalDataKey8",
  "additionalDataValue": "additionalDataValue8"
}
```


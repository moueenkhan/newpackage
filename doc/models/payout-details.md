
# Payout Details

Allows additional data to be supplied with a payout. Please refer to the VPL Payments Guide for a possible list of Keys (see EP Parameter under the different routes).

## Structure

`PayoutDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | Type which defines the allowable data which may be passed to the "key" element of the PayoutDetails.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `50` |
| `MValue` | `string` | Required | Type which defines the allowable data which may be passed to the "value" element of the PayoutDetails.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "key": "K1",
  "value": "V1"
}
```


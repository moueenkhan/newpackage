
# Additional Data

Represents a set of name value pairs that can be supplied with the Identity information. The keys will be validated on the server side against a list of valid types that are accepted. See the "API Solution Guide" for further details. Both the key and the value are required if adding additional data field. The following set of parameter names are valid keys:- CNPJ, CPF, CUIL, CUIT, DIPLOMAT_ID, FOREIGN_ID, HOME_PHONE_NUMBER, INTERNATIONAL_PHONE_NUMBER, KID, KPP, MOBILE_PHONE_NUMBER, NATIONAL_ID_CARD, PATRONYMIC_MIDDLE_NAME, RESIDENT, RUC, RUT, WORK_PHONE_NUMBER. **(Some of these keys only apply to specific country routes. Please refer to the VPL Payments Guide to check which keys are mandatory for which country routes).**

## Structure

`AdditionalData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | This represents the 'key' of the additional data. The length of this field is currently restricted to 50 bytes, and will be truncated if the value is too long. |
| `MValue` | `string` | Required | This represents the 'value' of the additional data. The length of this field is currently restricted to 254 bytes, when used for Payer Identity, and 1024 bytes when used for Beneficiary Identity.The field value will be truncated if the value is too long. |

## Example (as JSON)

```json
{
  "key": "NATIONAL_ID_CARD",
  "value": "TT6789CC"
}
```


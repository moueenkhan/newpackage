
# Unstructured Identity

Represents a set of name value pairs that can be supplied as the Identity information. The keys will be validated on the server side against a list of valid types that are accepted. Both the key and the value are required. To see the detailed **JSON** example for both Unstructured Identity **'Payer'** and **'Beneficiary'**, please refer to the following guide - [Unstructured Identity Examples](#/http/guides/unstructured-identity-examples)

## Structure

`UnstructuredIdentity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | [`Models.UnstructuredKeyNamesEnum`](../../doc/models/unstructured-key-names-enum.md) | Required | List of all of the Key Name Fields used within Unstructured Identity. *Key Fields below are the **minimum** requirements, but additional route-specific requirements may apply - please refer to the VPL Payment Guide for more information.* |
| `MValue` | `string` | Required | Unstructured Identity Value |

## Example (as JSON)

```json
{
  "key": null,
  "value": "John Smith"
}
```



# Identity

Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.

## Structure

`Identity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IndividualIdentity` | [`Models.IndividualIdentity`](../../doc/models/individual-identity.md) | Optional | The identity of an individual. The 'name' attribute is mandatory for an individual. You must supply at least identification entry or one birth information entry or one address entry. |
| `LegalEntityIdentity` | [`Models.LegalEntityIdentity`](../../doc/models/legal-entity-identity.md) | Optional | The identity of a legal entity. The 'legalEntityName' is mandatory. You must supply one of 'legalEntityRegistration' or 'address'. |
| `UnstructuredIdentity` | [`List<Models.UnstructuredIdentity>`](../../doc/models/unstructured-identity.md) | Optional | Represents a set of name value pairs that can be supplied as the Identity information. The keys will be validated on the server side against a list of valid types that are accepted. |
| `AdditionalData` | [`List<Models.AdditionalData>`](../../doc/models/additional-data.md) | Optional | Represents a set of name value pairs that can be supplied with the Identity information. |

## Example (as JSON)

```json
{
  "individualIdentity": null,
  "legalEntityIdentity": null,
  "unstructuredIdentity": null,
  "additionalData": null
}
```


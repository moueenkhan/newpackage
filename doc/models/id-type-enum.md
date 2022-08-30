
# Id Type Enum

Type of resource ID (UID) to be used for the API call.

## Enumeration

`IdTypeEnum`

## Fields

| Name | Description |
|  --- | --- |
| `Earthport` | {default} Uses VPL generated unique identifier (UID). |
| `Merchant` | Uses your own unique identifier (UID), however you must specify you are using your own UID by setting idType to merchant. Example: " /transactions/{transactionID}`?idType=merchant` " |


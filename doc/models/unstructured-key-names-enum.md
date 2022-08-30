
# Unstructured Key Names Enum

List of all of the Key Name Fields used within Unstructured Identity. *Key Fields below are the **minimum** requirements, but additional route-specific requirements may apply - please refer to the VPL Payment Guide for more information.*

## Enumeration

`UnstructuredKeyNamesEnum`

## Fields

| Name | Description |
|  --- | --- |
| `IdentityType` | I (Individual) or C (Legal Entity) - (OPTIONAL for both Payer and Beneficiary) |
| `Name` | Full name including First Name, Middle Name and Surname. (MANDATORY for both Payer and Beneficiary) |
| `AddressLine1` | Address Line 1 (MANDATORY for Payer - [IF ADDRESS INFORMATION BLOCK PROVIDED], OPTIONAL for Beneficiary) |
| `Country` | ISO Country Code (2 digits) - Address Line 1 (MANDATORY for Payer - [IF ADDRESS INFORMATION BLOCK PROVIDED], OPTIONAL for Beneficiary) |


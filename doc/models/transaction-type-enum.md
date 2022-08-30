
# Transaction Type Enum

Type of financial transaction

## Enumeration

`TransactionTypeEnum`

## Fields

| Name | Description |
|  --- | --- |
| `Payout` | A financial transaction representing a payout from an account held in the EPS system. |
| `Refund` | A financial transaction representing a refund (by a bank or other third-party) to the merchant's account. |
| `EnumUserDeposit` | A financial transaction representing money paid into a merchant's account by a user. |
| `EnumMerchantLiquidityDeposit` | Financial transaction representing a deposit of liquidity (money) into a merchant account. |
| `EnumEarthportToMerchantLiquidityTransfer` | Financial transaction representing the transfer of liquidity from a VPL account to a Merchants Central account. |
| `EnumMerchantLiquidityMovement` | A financial transaction representing movement of funds between a merchant's accounts held in the EPS system. |
| `Journal` | Financial transaction representing a journal entry against an account. |
| `EnumGenericTransaction` | A generic financial transaction used to represent different types of transactions in the EPS system that do not have their own specific mappings in the schema. |


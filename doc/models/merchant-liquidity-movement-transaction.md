
# Merchant Liquidity Movement Transaction

A financial transaction representing movement of funds between a merchant's accounts held in the EPS system.

## Structure

`MerchantLiquidityMovementTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FxExecutedDetail` | [`Models.FXExecutedRate`](../../doc/models/fx-executed-rate.md) | Optional | Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types. |
| `Description` | `string` | Optional | A reason or description or narrative as entered against the journal entry. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474988436283
  },
  "timestamp": "2018-06-06T09:29:46.329+00:00",
  "transactionType": "Merchant Liquidity Movement",
  "amount": {
    "amount": 20,
    "currency": "GBP"
  },
  "movementType": "Debit",
  "fxExecutedDetail": {
    "fxRate": {
      "buyCurrency": "EUR",
      "rate": 1.25,
      "sellCurrency": "GBP"
    }
  },
  "description": "FX VPLPaymentTest GBP vs. EUR Test fx transfer txn for REST API"
}
```


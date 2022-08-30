
# Journal Transaction

Financial transaction representing a journal entry against an account.

## Structure

`JournalTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Description` | `string` | Optional | A reason or description or narrative as entered against the journal entry. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474988435022
  },
  "timestamp": "2018-05-18T16:03:09.719+00:00",
  "transactionType": "Journal",
  "amount": {
    "amount": 100,
    "currency": "GBP"
  },
  "movementType": "Credit",
  "description": "test"
}
```


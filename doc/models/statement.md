
# Statement

The statement of transactions for a merchant account. This lists all debits and credits against this account. The results are paginated so may only be showing a subset of the total number of transactions. The statement also returns the opening and closing balances so can be used for reconciliation.

## Structure

`Statement`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StatementLineItems` | [`List<Models.StatementLineItem>`](../../doc/models/statement-line-item.md) | Required | List of 0 or more statement line item objects matching the request parameters. Each statement line item represents a financial transaction and an account balance resulting from the transaction. |
| `OpeningBalance` | [`Models.AccountBalance`](../../doc/models/account-balance.md) | Required | This element represents the balance of a merchant account or a managed merchant account in a currency registered with the merchant's central virtual account. |
| `ClosingBalance` | [`Models.AccountBalance`](../../doc/models/account-balance.md) | Required | This element represents the balance of a merchant account or a managed merchant account in a currency registered with the merchant's central virtual account. |
| `PaginationResult` | [`Models.PaginationResult`](../../doc/models/pagination-result.md) | Required | This returns a paged set of results rather than the full result set. |

## Example (as JSON)

```json
{
  "statementLineItems": {
    "transaction": {
      "transactionID": null,
      "timestamp": null,
      "amount": {
        "amount": 100,
        "currency": "GBP"
      },
      "movementType": null
    },
    "balance": 100
  },
  "openingBalance": {
    "balance": {
      "currency": "GBP",
      "amount": -9643
    },
    "balanceTimestamp": "2018-11-23T14:56:29.788+00:00",
    "lastMovementTimestamp": "2018-11-23T07:55:32.049+00:00"
  },
  "closingBalance": {
    "balance": {
      "currency": "GBP",
      "amount": -9643
    },
    "balanceTimestamp": "2018-11-23T14:56:29.788+00:00",
    "lastMovementTimestamp": "2018-11-23T07:55:32.049+00:00"
  },
  "paginationResult": null
}
```


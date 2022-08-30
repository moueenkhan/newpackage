
# Transactions Search Response

This represents the response of Transactions Search. It contains a number of transactions which match the search criteria and details of pagination on resultset.

## Structure

`TransactionsSearchResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Transactions` | [`List<Models.FinancialTransaction>`](../../doc/models/financial-transaction.md) | Optional | Represents a transaction. This can any type of transaction among Payout transaction, Refund transaction, User deposit, Liquidity deposit, Journal transaction, Merchant liquidity movement and VPL Merchant Liquidity Transfer. |
| `PaginationResult` | [`Models.PaginationResult`](../../doc/models/pagination-result.md) | Optional | This returns a paged set of results rather than the full result set. |

## Example (as JSON)

```json
{
  "transactions": null,
  "paginationResult": null
}
```


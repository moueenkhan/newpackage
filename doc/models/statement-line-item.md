
# Statement Line Item

A statement line item is a financial transaction that affects the balance of an account.

## Structure

`StatementLineItem`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Transaction` | [`Models.FinancialTransaction`](../../doc/models/financial-transaction.md) | Required | Minimum set of data that constitutes a financial transaction. Here are the list of all the Transaction Types; [Payout](#/http/models/structures/payout-transaction), [Refund](#/http/models/structures/refund-transaction), [User Deposit](#/http/models/structures/user-deposit-transaction), [Merchant Liquidity Deposit](#/http/models/structures/liquidity-deposit-transaction), [Journal](#/http/models/structures/journal-transaction), [Merchant Liquidity Movement](#/http/models/structures/merchant-liquidity-movement-transaction), [Earthport Merchant Liquidity Transfer](#/http/models/structures/earthport-merchant-liquidity-transfer), [Transaction](#/http/models/structures/transaction-id). |
| `Balance` | `double` | Required | Decimal amount value. The number of decimal places is defined by the currency. |

## Example (as JSON)

```json
{
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
}
```


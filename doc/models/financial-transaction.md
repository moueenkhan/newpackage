
# Financial Transaction

Minimum set of data that constitutes a financial transaction. Here are the list of all the Transaction Types; [Payout](#/http/models/structures/payout-transaction), [Refund](#/http/models/structures/refund-transaction), [User Deposit](#/http/models/structures/user-deposit-transaction), [Merchant Liquidity Deposit](#/http/models/structures/liquidity-deposit-transaction), [Journal](#/http/models/structures/journal-transaction), [Merchant Liquidity Movement](#/http/models/structures/merchant-liquidity-movement-transaction), [Earthport Merchant Liquidity Transfer](#/http/models/structures/earthport-merchant-liquidity-transfer), [Transaction](#/http/models/structures/transaction-id).

## Structure

`FinancialTransaction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TransactionID` | [`Models.TransactionID`](../../doc/models/transaction-id.md) | Required | Transaction ID type which contains both the unique VPL transaction ID and the merchant supplied transaction ID. |
| `Timestamp` | `string` | Required | A timestamp of the transaction. A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. |
| `TransactionStatus` | [`Models.FinancialTransactionStatus`](../../doc/models/financial-transaction-status.md) | Optional | Additional important status information for specific transaction types.\| code  \| description  \| Meaning \|\| ----  \| -----------  \| ------- \|\| 100   \| Pending Processing \| This is the initial state when VPL receives your payment instruction. \|\| 200   \| In Process         \| This means the payment is being processed by VPL's payment platform. \|\| 300   \| With Partner Bank  \| VPL has sent the payment onto our partner bank and we are awaiting an ACK. \|\| 400   \| Payment Sent       \| VPL has sent the payment to the partner bank and has received an ACK.\|\| 500   \| Rejected Payout    \| A payment can be rejected when uploading to the partner bank's system or by VPL's compliance team. \|\| 600   \| Returned Payout    \| A returned payment is when VPL processes the payment, sends on to our partner bank to be settled in the destination ACH but the beneficiary bank returns the payment. This could be because the bank account is closed.\|\| 700   \| Insufficient Merchant liquidity \| If you (VPL's client) is holding insufficient liquidity funding with VPL, then payments will appear in this state. VPL will not reject or fail the payments and will wait for you to provide funding before they can be processed. \|\| 800   \| Pending Cancellation            \| A payment can be in this state, if you call the cancel payment API. \| |
| `Amount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `MovementType` | [`Models.MoneyMovementTypeEnum`](../../doc/models/money-movement-type-enum.md) | Required | Specifies whether a money movement is a debit or credit. |
| `StatementDetails` | [`List<Models.StatementDetail>`](../../doc/models/statement-detail.md) | Optional | Set of key value pairs that provide additional details about a money movement. |
| `TransactionType` | `string` | Optional | - |

## Example (as JSON)

```json
{
  "transactionID": null,
  "timestamp": null,
  "amount": {
    "amount": 100,
    "currency": "GBP"
  },
  "movementType": null
}
```


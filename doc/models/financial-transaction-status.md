
# Financial Transaction Status

Additional important status information for specific transaction types.| code  | description  | Meaning || ----  | -----------  | ------- || 100   | Pending Processing | This is the initial state when VPL receives your payment instruction. || 200   | In Process         | This means the payment is being processed by VPL's payment platform. || 300   | With Partner Bank  | VPL has sent the payment onto our partner bank and we are awaiting an ACK. || 400   | Payment Sent       | VPL has sent the payment to the partner bank and has received an ACK.|| 500   | Rejected Payout    | A payment can be rejected when uploading to the partner bank's system or by VPL's compliance team. || 600   | Returned Payout    | A returned payment is when VPL processes the payment, sends on to our partner bank to be settled in the destination ACH but the beneficiary bank returns the payment. This could be because the bank account is closed.|| 700   | Insufficient Merchant liquidity | If you (VPL's client) is holding insufficient liquidity funding with VPL, then payments will appear in this state. VPL will not reject or fail the payments and will wait for you to provide funding before they can be processed. || 800   | Pending Cancellation            | A payment can be in this state, if you call the cancel payment API. |

## Structure

`FinancialTransactionStatus`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `int` | Required | Numerical code of financial transaction status.<br>**Constraints**: `>= -2147483648`, `<= 2147483647` |
| `Description` | `string` | Required | Description of the financial transaction status |

## Example (as JSON)

```json
{
  "code": 200,
  "description": "In Process"
}
```


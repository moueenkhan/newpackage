
# Liquidity Deposit Transaction

Financial transaction representing a deposit of liquidity (money) into a merchant account.

## Structure

`LiquidityDepositTransaction`

## Inherits From

[`FinancialTransaction`](../../doc/models/financial-transaction.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AmountCreditedToMerchantAccount` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `AmountReceivedAtBank` | [`Models.MonetaryValue`](../../doc/models/monetary-value.md) | Required | Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds. |
| `DepositCountry` | `string` | Required | Valid supported ISO 3166 2-character country code. This represents the Country of liquidity deposit.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `2` |
| `DepositDate` | `string` | Required | Valid ISO 8601 date format YYYY-MM-DD. This represents the date of liquidity deposit. |
| `DepositReference` | `string` | Optional | A Merchant User Deposit Reference.<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `12` |
| `FxExecutedDetail` | [`Models.FXExecutedRate`](../../doc/models/fx-executed-rate.md) | Optional | Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types. |
| `UnappliedReason` | `string` | Optional | The reason the deposit was not applied to the merchant's virtual account. |

## Example (as JSON)

```json
{
  "transactionID": {
    "epTransactionID": 281474988435000
  },
  "timestamp": "2018-05-18T11:14:05.169+00:00",
  "transactionType": "Merchant Liquidity Deposit",
  "amount": {
    "amount": 20000,
    "currency": "GBP"
  },
  "movementType": "Credit",
  "statementDetails": [
    {
      "key": "TransactionNarrative",
      "value": "Test liquidity deposit in GBP"
    }
  ],
  "depositDate": "2018-05-18Z",
  "depositCountry": "GB",
  "amountCreditedToMerchantAccount": {
    "amount": 20000,
    "currency": "GBP"
  },
  "amountReceivedAtBank": {
    "amount": 20000,
    "currency": "GBP"
  }
}
```


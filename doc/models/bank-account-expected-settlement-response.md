
# Bank Account Expected Settlement Response

This is the response to the Validate Beneficiary Bank Account API. The response will contain the element 'isBankAccountValid' which is a boolean representing if the specified beneficiary bank account is	valid. It will also return the expected settlement date of a payout based on supplied payout attributes in the request and the least cost route that can be used to settle against the beneficiary bank.

## Structure

`BankAccountExpectedSettlementResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IsBankAccountValid` | `bool` | Required | Returns true if bank details have passed validation checks. In this case, the other response attributes of anticipatedPayoutRequestTime, serviceLevel and expectedSettlementDate are returned. |
| `AnticipatedPayoutRequestTime` | `string` | Optional | A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This is the timestamp when the payout is anticipated to be sent to Earthport. This matches the supplied anticipatedPayoutRequestTime request attribute but the value returned will be in UTC (zero offset) dateTime. Therefore, a value supplied as 2013-01-20T12:30:00-05:00 will be returned as the UTC equivalent of 2013-01-20T17:30:00+00:00. |
| `ServiceLevel` | [`Models.ServiceLevelEnum?`](../../doc/models/service-level-enum.md) | Optional | Supported service levels for a payout request (standard or express). |
| `ExpectedSettlementDate` | `string` | Optional | Valid ISO 8601 date format YYYY-MM-DD. This is an indicative date when the payout instruction is expected to be settled to the bank. |

## Example (as JSON)

```json
{
  "isBankAccountValid": true,
  "anticipatedPayoutRequestTime": "2018-12-14T23:00:00+00:00",
  "serviceLevel": "standard",
  "expectedSettlementDate": "2018-12-17Z"
}
```


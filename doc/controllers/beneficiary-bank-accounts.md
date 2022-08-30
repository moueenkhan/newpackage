# Beneficiary Bank Accounts

```csharp
IBeneficiaryBankAccountsController beneficiaryBankAccountsController = client.BeneficiaryBankAccountsController;
```

## Class Name

`BeneficiaryBankAccountsController`

## Methods

* [Create Beneficiary Bank Account](../../doc/controllers/beneficiary-bank-accounts.md#create-beneficiary-bank-account)
* [Deactivate Beneficiary Bank Account](../../doc/controllers/beneficiary-bank-accounts.md#deactivate-beneficiary-bank-account)
* [Get Beneficiary Bank Account](../../doc/controllers/beneficiary-bank-accounts.md#get-beneficiary-bank-account)
* [Get Expected Settlement Date](../../doc/controllers/beneficiary-bank-accounts.md#get-expected-settlement-date)
* [List Bank Accounts](../../doc/controllers/beneficiary-bank-accounts.md#list-bank-accounts)
* [Validate Beneficiary Bank Account](../../doc/controllers/beneficiary-bank-accounts.md#validate-beneficiary-bank-account)


# Create Beneficiary Bank Account

Registers a new beneficiary bank account against this User.

```csharp
CreateBeneficiaryBankAccountAsync(
    string userID,
    Models.BeneficiaryBankAccountCreateRequest body,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `body` | [`Models.BeneficiaryBankAccountCreateRequest`](../../doc/models/beneficiary-bank-account-create-request.md) | Body, Required | The beneficiary bank account. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

[`Task<Models.UsersBankID>`](../../doc/models/users-bank-id.md)

## Example Usage

```csharp
string userID = "3430090151617";
var body = new BeneficiaryBankAccountCreateRequest();
body.BeneficiaryIdentity = new Identity();
body.BeneficiaryIdentity.IndividualIdentity = new IndividualIdentity();
body.BeneficiaryIdentity.IndividualIdentity.Name = new IndividualName();
body.BeneficiaryIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.BeneficiaryIdentity.IndividualIdentity.Name.GivenNames = "John";
body.Description = "J Smith current account";
body.CountryCode = "GB";
body.BankAccountDetails = new List<BankAccountDetails>();

var bodyBankAccountDetails0 = new BankAccountDetails();
bodyBankAccountDetails0.Key = "accountNumber";
bodyBankAccountDetails0.MValue = "06970093";
body.BankAccountDetails.Add(bodyBankAccountDetails0);

var bodyBankAccountDetails1 = new BankAccountDetails();
bodyBankAccountDetails1.Key = "accountName";
bodyBankAccountDetails1.MValue = "Mr. J Smith";
body.BankAccountDetails.Add(bodyBankAccountDetails1);

var bodyBankAccountDetails2 = new BankAccountDetails();
bodyBankAccountDetails2.Key = "bankName";
bodyBankAccountDetails2.MValue = "Barclays Bank";
body.BankAccountDetails.Add(bodyBankAccountDetails2);

var bodyBankAccountDetails3 = new BankAccountDetails();
bodyBankAccountDetails3.Key = "sortCode";
bodyBankAccountDetails3.MValue = "800554";
body.BankAccountDetails.Add(bodyBankAccountDetails3);

body.BenBankID = new BenBankIDMerchant();
body.BenBankID.MerchantBankID = "bnk_12345678";
body.CurrencyCode = "GBP";

try
{
    UsersBankID result = await beneficiaryBankAccountsController.CreateBeneficiaryBankAccountAsync(userID, body, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "userID": {
    "epUserID": 3430090151617,
    "merchantUserID": "userID_1542991954199"
  },
  "benBankID": {
    "epBankID": 4036783,
    "merchantBankID": "bnk_12345678"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


# Deactivate Beneficiary Bank Account

Deactivates a Beneficiary Bank Account. You will not be able to send a payment to a deactivated bank account.

```csharp
DeactivateBeneficiaryBankAccountAsync(
    string userID,
    string bankID,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `bankID` | `string` | Template, Required | Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

`Task`

## Example Usage

```csharp
string userID = "3430090151590";
string bankID = "7431798";

try
{
    await beneficiaryBankAccountsController.DeactivateBeneficiaryBankAccountAsync(userID, bankID, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


# Get Beneficiary Bank Account

Gets a Beneficiary Bank Account.

```csharp
GetBeneficiaryBankAccountAsync(
    string userID,
    string bankID,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `bankID` | `string` | Template, Required | Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

[`Task<Models.BeneficiaryBankAccountGetResponse>`](../../doc/models/beneficiary-bank-account-get-response.md)

## Example Usage

```csharp
string userID = "3409890146942";
string bankID = "4034215";

try
{
    BeneficiaryBankAccountGetResponse result = await beneficiaryBankAccountsController.GetBeneficiaryBankAccountAsync(userID, bankID, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "userID": {
    "epUserID": 3409890146942,
    "merchantUserID": "userID_1540303323210"
  },
  "benBankID": {
    "epBankID": 4034215,
    "merchantBankID": "bankID_1540304037951"
  },
  "beneficiaryIdentity": {
    "individualIdentity": {
      "name": {
        "familyName": "Smith",
        "givenNames": "John"
      },
      "address": {
        "addressLine1": "ABC",
        "addressLine2": "ABC",
        "addressLine3": "ABC",
        "city": "ABC",
        "country": "GB",
        "postcode": "EC1A 4HY",
        "province": "ABC"
      }
    }
  },
  "description": "Mr J Smith current account",
  "countryCode": "GB",
  "currencyCode": "GBP",
  "isActive": true,
  "bankAccountDetails": [
    {
      "key": "bankName",
      "value": "Test Bank"
    },
    {
      "key": "accountName",
      "value": "Mr J. Smith"
    },
    {
      "key": "accountNumber",
      "value": "06970093"
    },
    {
      "key": "sortCode",
      "value": "800554"
    },
    {
      "key": "bic",
      "value": "BOFSGB21377"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


# Get Expected Settlement Date

Validates a new beneficiary bank account and gets the expected settlement date.

```csharp
GetExpectedSettlementDateAsync(
    Models.BankAccountExpectedSettlementRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BankAccountExpectedSettlementRequest`](../../doc/models/bank-account-expected-settlement-request.md) | Body, Required | The beneficiary bank account. |

## Response Type

[`Task<Models.BankAccountExpectedSettlementResponse>`](../../doc/models/bank-account-expected-settlement-response.md)

## Example Usage

```csharp
var body = new BankAccountExpectedSettlementRequest();
body.BeneficiaryIdentity = new Identity();
body.BeneficiaryIdentity.IndividualIdentity = new IndividualIdentity();
body.BeneficiaryIdentity.IndividualIdentity.Name = new IndividualName();
body.BeneficiaryIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.BeneficiaryIdentity.IndividualIdentity.Name.GivenNames = "John";
body.Description = "test";
body.CountryCode = "GB";
body.BankAccountDetails = new List<BankAccountDetails>();

var bodyBankAccountDetails0 = new BankAccountDetails();
bodyBankAccountDetails0.Key = "accountName";
bodyBankAccountDetails0.MValue = "Mr J Doe";
body.BankAccountDetails.Add(bodyBankAccountDetails0);

var bodyBankAccountDetails1 = new BankAccountDetails();
bodyBankAccountDetails1.Key = "accountNumber";
bodyBankAccountDetails1.MValue = "70872490";
body.BankAccountDetails.Add(bodyBankAccountDetails1);

var bodyBankAccountDetails2 = new BankAccountDetails();
bodyBankAccountDetails2.Key = "bankName";
bodyBankAccountDetails2.MValue = "Natwest";
body.BankAccountDetails.Add(bodyBankAccountDetails2);

var bodyBankAccountDetails3 = new BankAccountDetails();
bodyBankAccountDetails3.Key = "sortCode";
bodyBankAccountDetails3.MValue = "404784";
body.BankAccountDetails.Add(bodyBankAccountDetails3);

body.AnticipatedPayoutRequestTime = "2018-12-14T23:00:00Z";
body.PayerIdentity = new Identity();
body.PayerIdentity.IndividualIdentity = new IndividualIdentity();
body.PayerIdentity.IndividualIdentity.Name = new IndividualName();
body.PayerIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.PayerIdentity.IndividualIdentity.Name.GivenNames = "John";
body.PayerIdentity.IndividualIdentity.Address = new Address();
body.PayerIdentity.IndividualIdentity.Address.AddressLine1 = "ABC";
body.PayerIdentity.IndividualIdentity.Address.City = "ABC";
body.PayerIdentity.IndividualIdentity.Address.Country = "GB";
body.PayerIdentity.IndividualIdentity.Address.AddressLine2 = "ABC";
body.PayerIdentity.IndividualIdentity.Address.AddressLine3 = "ABC";
body.PayerIdentity.IndividualIdentity.Address.Postcode = "EC1A 4HY";
body.PayerIdentity.IndividualIdentity.Address.Province = "ABC";
body.PayoutRequestCurrency = "GBP";
body.ServiceLevel = ServiceLevelEnum.Standard;
body.PayerType = PayerTypeEnum.User;

try
{
    BankAccountExpectedSettlementResponse result = await beneficiaryBankAccountsController.GetExpectedSettlementDateAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "isBankAccountValid": true,
  "anticipatedPayoutRequestTime": "2018-12-14T23:00:00+00:00",
  "serviceLevel": "standard",
  "expectedSettlementDate": "2018-12-17Z"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


# List Bank Accounts

Gets all Beneficiary Bank Accounts registered by this User.

```csharp
ListBankAccountsAsync(
    string userID,
    Models.IdTypeEnum? idType = null,
    int? offset = null,
    int? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |
| `offset` | `int?` | Query, Optional | This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset. |
| `pageSize` | `int?` | Query, Optional | This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned. |

## Response Type

[`Task<Models.BeneficiaryBankAccountListResponse>`](../../doc/models/beneficiary-bank-account-list-response.md)

## Example Usage

```csharp
string userID = "3409890147363";

try
{
    BeneficiaryBankAccountListResponse result = await beneficiaryBankAccountsController.ListBankAccountsAsync(userID, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "beneficiaryBankAccountSummary": [
    {
      "benBankID": {
        "epBankID": 4036783,
        "merchantBankID": "bankID_1542991974172"
      },
      "description": "Bank Account Description",
      "countryCode": "GB",
      "bankAccountDetails": [
        {
          "key": "bankName",
          "value": "Test Bank"
        },
        {
          "key": "accountName",
          "value": "account name"
        },
        {
          "key": "currencyCode",
          "value": "GBP"
        },
        {
          "key": "accountNumber",
          "value": "****0093"
        }
      ],
      "status": "ACTIVE"
    }
  ],
  "userID": {
    "epUserID": 3409890147363,
    "merchantUserID": "userID_1542991954199"
  },
  "paginationResult": {
    "offset": 0,
    "pageSize": 25,
    "totalNumberOfRecords": 1
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


# Validate Beneficiary Bank Account

Validates a new beneficiary bank account against a User.

```csharp
ValidateBeneficiaryBankAccountAsync(
    Models.BeneficiaryBankAccountValidateRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BeneficiaryBankAccountValidateRequest`](../../doc/models/beneficiary-bank-account-validate-request.md) | Body, Required | The beneficiary bank account. |

## Response Type

[`Task<Models.BeneficiaryBankAccountValidateResponse>`](../../doc/models/beneficiary-bank-account-validate-response.md)

## Example Usage

```csharp
var body = new BeneficiaryBankAccountValidateRequest();
body.BeneficiaryIdentity = new Identity();
body.BeneficiaryIdentity.IndividualIdentity = new IndividualIdentity();
body.BeneficiaryIdentity.IndividualIdentity.Name = new IndividualName();
body.BeneficiaryIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.BeneficiaryIdentity.IndividualIdentity.Name.GivenNames = "John";
body.Description = "Bank Account Description";
body.CountryCode = "GB";
body.BankAccountDetails = new List<BankAccountDetails>();

var bodyBankAccountDetails0 = new BankAccountDetails();
bodyBankAccountDetails0.Key = "accountNumber";
bodyBankAccountDetails0.MValue = "06970093";
body.BankAccountDetails.Add(bodyBankAccountDetails0);

var bodyBankAccountDetails1 = new BankAccountDetails();
bodyBankAccountDetails1.Key = "accountName";
bodyBankAccountDetails1.MValue = "account name";
body.BankAccountDetails.Add(bodyBankAccountDetails1);

var bodyBankAccountDetails2 = new BankAccountDetails();
bodyBankAccountDetails2.Key = "bankName";
bodyBankAccountDetails2.MValue = "Test Bank";
body.BankAccountDetails.Add(bodyBankAccountDetails2);

var bodyBankAccountDetails3 = new BankAccountDetails();
bodyBankAccountDetails3.Key = "sortCode";
bodyBankAccountDetails3.MValue = "800554";
body.BankAccountDetails.Add(bodyBankAccountDetails3);

body.CurrencyCode = "GBP";

try
{
    BeneficiaryBankAccountValidateResponse result = await beneficiaryBankAccountsController.ValidateBeneficiaryBankAccountAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "isBankAccountValid": true
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | [`ValidationException`](../../doc/models/validation-exception.md) |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


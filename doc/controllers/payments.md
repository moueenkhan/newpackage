# Payments

```csharp
IPaymentsController paymentsController = client.PaymentsController;
```

## Class Name

`PaymentsController`

## Methods

* [Create Payment](../../doc/controllers/payments.md#create-payment)
* [Create Payment Registered Beneficiary](../../doc/controllers/payments.md#create-payment-registered-beneficiary)
* [Get Metadatafor Payment Request](../../doc/controllers/payments.md#get-metadatafor-payment-request)
* [Get Purposeof Payment Metadata](../../doc/controllers/payments.md#get-purposeof-payment-metadata)


# Create Payment

This service creates a payment without the need to pre-register either the User or Beneficiary Bank Account.

Creates a User (or updates an existing User), adds a Beneficiary Bank Account to this user and creates a new payment.

```csharp
CreatePaymentAsync(
    Models.PaymentsCreateRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.PaymentsCreateRequest`](../../doc/models/payments-create-request.md) | Body, Required | The payment request. |

## Response Type

[`Task<Models.PaymentsCreateResponse>`](../../doc/models/payments-create-response.md)

## Example Usage

```csharp
var body = new PaymentsCreateRequest();
body.User = new User();
body.User.UserID = new UserIDMerchant();
body.User.UserID.MerchantUserID = "userID_12345";
body.User.AccountCurrency = "any";
body.User.PayerIdentity = new Identity();
body.User.PayerIdentity.IndividualIdentity = new IndividualIdentity();
body.User.PayerIdentity.IndividualIdentity.Name = new IndividualName();
body.User.PayerIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.User.PayerIdentity.IndividualIdentity.Name.GivenNames = "John";
body.User.PayerIdentity.IndividualIdentity.Address = new Address();
body.User.PayerIdentity.IndividualIdentity.Address.AddressLine1 = "ABC";
body.User.PayerIdentity.IndividualIdentity.Address.City = "ABC";
body.User.PayerIdentity.IndividualIdentity.Address.Country = "GB";
body.User.PayerIdentity.IndividualIdentity.Address.AddressLine2 = "ABC";
body.User.PayerIdentity.IndividualIdentity.Address.AddressLine3 = "ABC";
body.User.PayerIdentity.IndividualIdentity.Address.Postcode = "EC1A 4HY";
body.User.PayerIdentity.IndividualIdentity.Address.Province = "ABC";
body.BankAccount = new BankAccount();
body.BankAccount.BeneficiaryIdentity = new Identity();
body.BankAccount.BeneficiaryIdentity.IndividualIdentity = new IndividualIdentity();
body.BankAccount.BeneficiaryIdentity.IndividualIdentity.Name = new IndividualName();
body.BankAccount.BeneficiaryIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.BankAccount.BeneficiaryIdentity.IndividualIdentity.Name.GivenNames = "John";
body.BankAccount.Description = "Mr J Smith current account";
body.BankAccount.CountryCode = "GB";
body.BankAccount.CurrencyCode = "GBP";
body.BankAccount.BankAccountDetails = new List<BankAccountDetails>();

var bodyBankAccountBankAccountDetails0 = new BankAccountDetails();
bodyBankAccountBankAccountDetails0.Key = "accountNumber";
bodyBankAccountBankAccountDetails0.MValue = "06970093";
body.BankAccount.BankAccountDetails.Add(bodyBankAccountBankAccountDetails0);

var bodyBankAccountBankAccountDetails1 = new BankAccountDetails();
bodyBankAccountBankAccountDetails1.Key = "accountName";
bodyBankAccountBankAccountDetails1.MValue = "account name";
body.BankAccount.BankAccountDetails.Add(bodyBankAccountBankAccountDetails1);

var bodyBankAccountBankAccountDetails2 = new BankAccountDetails();
bodyBankAccountBankAccountDetails2.Key = "bankName";
bodyBankAccountBankAccountDetails2.MValue = "Test Bank";
body.BankAccount.BankAccountDetails.Add(bodyBankAccountBankAccountDetails2);

var bodyBankAccountBankAccountDetails3 = new BankAccountDetails();
bodyBankAccountBankAccountDetails3.Key = "sortCode";
bodyBankAccountBankAccountDetails3.MValue = "800554";
body.BankAccount.BankAccountDetails.Add(bodyBankAccountBankAccountDetails3);

body.BankAccount.BenBankID = new BenBankIDMerchant();
body.BankAccount.BenBankID.MerchantBankID = "bankID_9876";
body.Payment = new Payment();
body.Payment.TransactionID = new TransactionIDMerchant();
body.Payment.TransactionID.MerchantTransactionID = "txID_123456";
body.Payment.PayoutRequestAmount = new MonetaryValue();
body.Payment.PayoutRequestAmount.Amount = 35.18;
body.Payment.PayoutRequestAmount.Currency = "GBP";
body.Payment.BeneficiaryAmountInformation = new BeneficiaryAmountInformation();
body.Payment.BeneficiaryAmountInformation.BeneficiaryAmount = new MonetaryValue();
body.Payment.BeneficiaryAmountInformation.BeneficiaryAmount.Amount = 105.4;
body.Payment.BeneficiaryAmountInformation.BeneficiaryAmount.Currency = "GBP";
body.Payment.BeneficiaryAmountInformation.PayoutCurrency = "GBP";
body.Payment.ServiceLevel = ServiceLevelEnum.Standard;
body.Payment.BeneficiaryStatementNarrative = "Expenses payment";
body.Payment.PayerType = PayerTypeEnum.User;

try
{
    PaymentsCreateResponse result = await paymentsController.CreatePaymentAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "userID": {
    "epUserID": 3409890147399,
    "merchantUserID": "userID_1543060156380"
  },
  "benBankID": {
    "epBankID": 4036790,
    "merchantBankID": "bankID_1543060156380"
  },
  "transactionID": {
    "epTransactionID": 281474984546286,
    "merchantTransactionID": "txID_1543060156380"
  },
  "liquidityValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "settlementValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "acceptedDate": "2018-11-24T11:49:24.313+00:00",
  "expectedSettlementDate": "2018-11-26Z"
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


# Create Payment Registered Beneficiary

Creates a new payment for a previously registered beneficiary bank account (and user).

```csharp
CreatePaymentRegisteredBeneficiaryAsync(
    string userID,
    string bankID,
    Models.Payment body,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `bankID` | `string` | Template, Required | Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id. |
| `body` | [`Models.Payment`](../../doc/models/payment.md) | Body, Required | Payment details |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

[`Task<Models.PaymentsRegisteredBeneficiaryCreateResponse>`](../../doc/models/payments-registered-beneficiary-create-response.md)

## Example Usage

```csharp
string userID = "3409890146942";
string bankID = "4034215";
var body = new Payment();
body.TransactionID = new TransactionIDMerchant();
body.TransactionID.MerchantTransactionID = "txID_123456";
body.PayoutRequestAmount = new MonetaryValue();
body.PayoutRequestAmount.Amount = 35.18;
body.PayoutRequestAmount.Currency = "GBP";
body.BeneficiaryAmountInformation = new BeneficiaryAmountInformation();
body.BeneficiaryAmountInformation.BeneficiaryAmount = new MonetaryValue();
body.BeneficiaryAmountInformation.BeneficiaryAmount.Amount = 105.4;
body.BeneficiaryAmountInformation.BeneficiaryAmount.Currency = "GBP";
body.BeneficiaryAmountInformation.PayoutCurrency = "GBP";
body.ServiceLevel = ServiceLevelEnum.Standard;
body.BeneficiaryStatementNarrative = "Expenses payment";

try
{
    PaymentsRegisteredBeneficiaryCreateResponse result = await paymentsController.CreatePaymentRegisteredBeneficiaryAsync(userID, bankID, body, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "transactionID": {
    "epTransactionID": 281474984546300,
    "merchantTransactionID": "txID_1543152891155"
  },
  "correspondentChargesExpected": false,
  "liquidityValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "settlementValue": {
    "amount": 11,
    "currency": "GBP"
  },
  "acceptedDate": "2018-11-25T13:34:51.647+00:00",
  "expectedSettlementDate": "2018-11-26Z"
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


# Get Metadatafor Payment Request

Returns the required fields for creating the payment request.

```csharp
GetMetadataforPaymentRequestAsync(
    string countryCode,
    string currencyCode,
    Models.IdentityEntityEnum? beneficiaryIdentityEntityType = null,
    string locale = null,
    string serviceLevel = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `countryCode` | `string` | Query, Required | Valid supported ISO 3166 2-character country code. |
| `currencyCode` | `string` | Query, Required | Valid supported ISO 4217 3-character currency code. |
| `beneficiaryIdentityEntityType` | [`Models.IdentityEntityEnum?`](../../doc/models/identity-entity-enum.md) | Query, Optional | Type of beneficiary identity. |
| `locale` | `string` | Query, Optional | Localization String e.g. en_GB, en_US. |
| `serviceLevel` | `string` | Query, Optional | Service Level. Allowed values are standard and express. |

## Response Type

[`Task<Models.GetPayoutRequiredDataResponse>`](../../doc/models/get-payout-required-data-response.md)

## Example Usage

```csharp
string countryCode = "GB";
string currencyCode = "GBP";
string serviceLevel = "standard";

try
{
    GetPayoutRequiredDataResponse result = await paymentsController.GetMetadataforPaymentRequestAsync(countryCode, currencyCode, null, null, serviceLevel);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "beneficiaryIdentityFieldGroupsList": {
    "groupLabel": "Individual Identity",
    "beneficiaryIdentityFieldGroup": [
      {
        "elementName": "name",
        "groupLabel": "Enter name",
        "mandatory": true,
        "beneficiaryIdentityFieldsList": {
          "beneficiaryIdentityField": [
            {
              "description": "Enter the first name of the beneficiary",
              "displaySize": 35,
              "elementName": "givenNames",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 1024,
              "subTitle": "The first name of the beneficiary",
              "tabOrder": 1
            },
            {
              "description": "Enter the family name of the beneficiary",
              "displaySize": 35,
              "elementName": "familyName",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 1024,
              "subTitle": "The family name of the beneficiary",
              "tabOrder": 2
            }
          ]
        }
      },
      {
        "elementName": "address",
        "groupLabel": "Enter address details",
        "mandatory": false,
        "beneficiaryIdentityFieldsList": {
          "beneficiaryIdentityField": [
            {
              "description": "Enter the first line of address of beneficiary",
              "displaySize": 35,
              "elementName": "addressLine1",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 254,
              "subTitle": "First line of address of beneficiary",
              "tabOrder": 3
            },
            {
              "description": "Enter the second line of address of beneficiary",
              "displaySize": 35,
              "elementName": "addressLine2",
              "inputType": "text",
              "locale": "en",
              "mandatory": false,
              "maxSize": 254,
              "subTitle": "Second line of address of beneficiary",
              "tabOrder": 4
            },
            {
              "description": "Enter the third line of address of beneficiary",
              "displaySize": 35,
              "elementName": "addressLine3",
              "inputType": "text",
              "locale": "en",
              "mandatory": false,
              "maxSize": 254,
              "subTitle": "Third line of address of beneficiary",
              "tabOrder": 5
            },
            {
              "description": "Enter the city of residency of beneficiary",
              "displaySize": 35,
              "elementName": "city",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 254,
              "subTitle": "City of residency of beneficiary",
              "tabOrder": 6
            },
            {
              "description": "Enter the province of residency of beneficiary",
              "displaySize": 35,
              "elementName": "province",
              "inputType": "text",
              "locale": "en",
              "mandatory": false,
              "maxSize": 254,
              "subTitle": "Province of residency of beneficiary",
              "tabOrder": 7
            },
            {
              "description": "Enter the postcode of residency of beneficiary",
              "displaySize": 10,
              "elementName": "postcode",
              "inputType": "text",
              "locale": "en",
              "mandatory": false,
              "maxSize": 10,
              "subTitle": "Postcode of residency of beneficiary",
              "tabOrder": 8
            },
            {
              "description": "Enter the ISO county code of residency of beneficiary",
              "displaySize": 2,
              "elementName": "country",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 2,
              "subTitle": "ISO county of residency of beneficiary",
              "tabOrder": 9
            }
          ]
        }
      },
      {
        "elementName": "identificationList",
        "groupLabel": "Enter identification details",
        "mandatory": false,
        "beneficiaryIdentityFieldsList": {
          "beneficiaryIdentityField": [
            {
              "description": "Enter one of the identification information of beneficiary",
              "displaySize": 25,
              "elementName": "idType",
              "inputType": "list",
              "locale": "en",
              "mandatory": true,
              "maxSize": 25,
              "subTitle": "Identification information of beneficiary",
              "tabOrder": 10,
              "listItems": {
                "beneficiaryIdentityField": [
                  {
                    "label": "Passport",
                    "value": "Passport"
                  },
                  {
                    "label": "National ID Card",
                    "value": "National ID Card"
                  },
                  {
                    "label": "Driving License",
                    "value": "Driving License"
                  }
                ]
              }
            },
            {
              "description": "Enter the identifier value of the beneficiary document",
              "displaySize": 10,
              "elementName": "identificationNumber",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 50,
              "subTitle": "Identifier value of the document",
              "tabOrder": 11
            },
            {
              "description": "Enter the ISO country code of issue of the beneficiary identification document",
              "displaySize": 2,
              "elementName": "identificationCountry",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 2,
              "subTitle": "ISO country of issue of the identification document",
              "tabOrder": 12
            },
            {
              "description": "Enter the date of issue of beneficiary identification document",
              "displaySize": 10,
              "elementName": "validFromDate",
              "inputType": "date",
              "locale": "en",
              "mandatory": false,
              "maxSize": 10,
              "subTitle": "Date of issue of identification document",
              "tabOrder": 13
            },
            {
              "description": "Enter the date of expiry of beneficiary identification document",
              "displaySize": 10,
              "elementName": "validToDate",
              "inputType": "date",
              "locale": "en",
              "mandatory": false,
              "maxSize": 10,
              "subTitle": "Date of expiry of identification document",
              "tabOrder": 14
            }
          ]
        }
      },
      {
        "elementName": "birthInformation",
        "groupLabel": "Enter birth information",
        "mandatory": false,
        "beneficiaryIdentityFieldsList": {
          "beneficiaryIdentityField": [
            {
              "description": "Enter the city of birth of the beneficiary",
              "displaySize": 35,
              "elementName": "cityOfBirth",
              "inputType": "text",
              "locale": "en",
              "mandatory": false,
              "maxSize": 254,
              "subTitle": "The city of birth of the beneficiary",
              "tabOrder": 15
            },
            {
              "description": "Enter the ISO country code of birth of the beneficiary",
              "displaySize": 2,
              "elementName": "countryOfBirth",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 2,
              "subTitle": "The ISO country of birth of the beneficiary",
              "tabOrder": 16
            },
            {
              "description": "Enter the date of birth of the beneficiary",
              "displaySize": 10,
              "elementName": "dateOfBirth",
              "inputType": "date",
              "locale": "en",
              "mandatory": true,
              "maxSize": 10,
              "subTitle": "The date of birth of the beneficiary",
              "tabOrder": 17
            }
          ]
        }
      },
      {
        "elementName": "additionalData",
        "groupLabel": "Enter any additional data",
        "mandatory": false,
        "beneficiaryIdentityFieldsList": {
          "beneficiaryIdentityField": [
            {
              "description": "Enter parameter name for the additional data",
              "displaySize": 25,
              "elementName": "additionalDataKey",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 25,
              "subTitle": "Additional data parameter name",
              "tabOrder": 18
            },
            {
              "description": "Enter value for the additional data",
              "displaySize": 25,
              "elementName": "additionalDataValue",
              "inputType": "text",
              "locale": "en",
              "mandatory": true,
              "maxSize": 25,
              "subTitle": "Additional data parameter value",
              "tabOrder": 19
            }
          ]
        }
      }
    ]
  },
  "beneficiaryBankAccountFieldGroupsList": {
    "beneficiaryBankAccountFieldGroup": [
      {
        "groupLabel": "Bank Name",
        "mandatory": true,
        "beneficiaryBankAccountFieldsList": {
          "beneficiaryBankAccountField": [
            {
              "description": "Enter the Bank Name",
              "displaySize": 30,
              "inputType": "text",
              "locale": "en",
              "maxSize": 50,
              "parameterName": "bankName",
              "separator": " ",
              "subTitle": "Bank Name",
              "tabOrder": 1
            }
          ]
        }
      },
      {
        "groupLabel": "Account Holder",
        "mandatory": true,
        "beneficiaryBankAccountFieldsList": {
          "beneficiaryBankAccountField": [
            {
              "description": "Account Holders Name",
              "displaySize": 35,
              "inputType": "text",
              "locale": "en",
              "maxSize": 35,
              "parameterName": "accountName",
              "separator": " ",
              "subTitle": "Account Holder",
              "tabOrder": 2
            }
          ]
        }
      },
      {
        "groupLabel": "Account Number",
        "mandatory": true,
        "beneficiaryBankAccountFieldsList": {
          "beneficiaryBankAccountField": [
            {
              "description": "Enter the Account Number",
              "displaySize": 8,
              "inputType": "text",
              "locale": "en",
              "maxSize": 8,
              "parameterName": "accountNumber",
              "separator": " ",
              "subTitle": "Account",
              "tabOrder": 3
            }
          ]
        }
      },
      {
        "groupLabel": "Sort Code",
        "mandatory": true,
        "beneficiaryBankAccountFieldsList": {
          "beneficiaryBankAccountField": [
            {
              "description": "Enter the Sort Code",
              "displaySize": 6,
              "inputType": "text",
              "locale": "en",
              "maxSize": 6,
              "parameterName": "sortCode",
              "separator": " ",
              "subTitle": "Sort Code",
              "tabOrder": 4
            }
          ]
        }
      }
    ]
  },
  "purposeOfPaymentFieldGroupsList": {
    "mandatory": false
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
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


# Get Purposeof Payment Metadata

Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered.

```csharp
GetPurposeofPaymentMetadataAsync(
    string userID,
    string bankID,
    Models.IdTypeEnum? idType = null,
    int? amount = null,
    string currency = null,
    string payerType = null,
    string serviceLevel = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `bankID` | `string` | Template, Required | Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |
| `amount` | `int?` | Query, Optional | Decimal amount value. The number of decimal places is defined by the currency. |
| `currency` | `string` | Query, Optional | Valid supported ISO 4217 3-character currency code. |
| `payerType` | `string` | Query, Optional | The type of Payer. Allowed values are authenticatedCaller, managedMerchant and user. |
| `serviceLevel` | `string` | Query, Optional | Service Level. Allowed values are standard and express. |

## Response Type

[`Task<Models.GetPayoutRequiredDataResponse>`](../../doc/models/get-payout-required-data-response.md)

## Example Usage

```csharp
string userID = "3409890146942";
string bankID = "4034221";
int? amount = 500;
string currency = "USD";
string payerType = "user";
string serviceLevel = "standard";

try
{
    GetPayoutRequiredDataResponse result = await paymentsController.GetPurposeofPaymentMetadataAsync(userID, bankID, null, amount, currency, payerType, serviceLevel);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "purposeOfPaymentFieldGroupsList": {
    "mandatory": true,
    "purposeOfPaymentCode": [
      {
        "code": "MOR",
        "description": "Mortgage",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "TAX",
        "description": "Tax",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "MIS",
        "description": "Miscellaneous",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "SAL",
        "description": "Salary/payroll",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "LOA",
        "description": "Loan",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "RLS",
        "description": "Rent or Lease",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "BUS",
        "description": "Business/commercial payment",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "DEP",
        "description": "Deposit",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "REM",
        "description": "Remittance",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "ANN",
        "description": "Annuity",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      },
      {
        "code": "PEN",
        "description": "Pension",
        "purposeOfPaymentUsageRestrictions": {
          "originatorType": {
            "individual": true,
            "legalEntity": true
          },
          "beneficiaryType": {
            "individual": true,
            "legalEntity": true
          }
        }
      }
    ]
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
| 500 | An internal error has occurred in the Earthport payment platform. | `ApiException` |


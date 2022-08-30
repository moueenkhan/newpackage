# Users

```csharp
IUsersController usersController = client.UsersController;
```

## Class Name

`UsersController`

## Methods

* [Disable User](../../doc/controllers/users.md#disable-user)
* [Get User](../../doc/controllers/users.md#get-user)
* [Update User](../../doc/controllers/users.md#update-user)
* [Validate User](../../doc/controllers/users.md#validate-user)


# Disable User

Disables a User - you cannot register new bank accounts against a disabled User or create payments for a disabled User.

```csharp
DisableUserAsync(
    string userID,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

`Task`

## Example Usage

```csharp
string userID = "3409890146978";

try
{
    await usersController.DisableUserAsync(userID, null);
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


# Get User

Get a User/Payer. This API only returns the identity details of a User/Payer.

```csharp
GetUserAsync(
    string userID,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

[`Task<Models.UsersGetResponse>`](../../doc/models/users-get-response.md)

## Example Usage

```csharp
string userID = "3409890146942";

try
{
    UsersGetResponse result = await usersController.GetUserAsync(userID, null);
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


# Update User

Updates a User/Payer. This API only supports updating the identity details of a User/Payer.

```csharp
UpdateUserAsync(
    string userID,
    Models.UsersUpdateRequest body,
    Models.IdTypeEnum? idType = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userID` | `string` | Template, Required | The payer's unique id. It can be either VAN or merchant id. |
| `body` | [`Models.UsersUpdateRequest`](../../doc/models/users-update-request.md) | Body, Required | The user details to be updated. |
| `idType` | [`Models.IdTypeEnum?`](../../doc/models/id-type-enum.md) | Query, Optional | idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default. |

## Response Type

`Task`

## Example Usage

```csharp
string userID = "3409890146942";
var body = new UsersUpdateRequest();
body.PayerIdentity = new Identity();

try
{
    await usersController.UpdateUserAsync(userID, body, null);
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
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


# Validate User

Use this API to validate the payer identity details of the User.

```csharp
ValidateUserAsync(
    Models.Action1Enum action,
    string beneficiaryCountryCode,
    Models.UsersCreateorValidateRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `action` | [`Models.Action1Enum`](../../doc/models/action-1-enum.md) | Query, Required | This determines that the supplied User should be validated only and not persisted. |
| `beneficiaryCountryCode` | `string` | Query, Required | Valid supported ISO 3166 2-character country code for the payer being validated. This is the country, which the payer needs to send a payment to. |
| `body` | [`Models.UsersCreateorValidateRequest`](../../doc/models/users-createor-validate-request.md) | Body, Required | The user details to be validated. |

## Response Type

`Task`

## Example Usage

```csharp
Action1Enum action = Action1Enum.Validate;
string beneficiaryCountryCode = "GB";
var body = new UsersCreateorValidateRequest();
body.UserID = new UserIDMerchant();
body.UserID.MerchantUserID = "abcd1234567";
body.AccountCurrency = "any";
body.PayerIdentity = new Identity();
body.PayerIdentity.IndividualIdentity = new IndividualIdentity();
body.PayerIdentity.IndividualIdentity.Name = new IndividualName();
body.PayerIdentity.IndividualIdentity.Name.FamilyName = "Smith";
body.PayerIdentity.IndividualIdentity.Name.GivenNames = "John";
body.PayerIdentity.IndividualIdentity.Address = new Address();
body.PayerIdentity.IndividualIdentity.Address.AddressLine1 = "1 Main Street";
body.PayerIdentity.IndividualIdentity.Address.City = "London";
body.PayerIdentity.IndividualIdentity.Address.Country = "GB";

try
{
    await usersController.ValidateUserAsync(action, beneficiaryCountryCode, body);
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


# Authentication

```csharp
IAuthenticationController authenticationController = client.AuthenticationController;
```

## Class Name

`AuthenticationController`


# Get Access Token

Verify client credentials and returns a bearer token.

:information_source: **Note** This endpoint does not require authentication.

```csharp
GetAccessTokenAsync(
    Models.GrantTypeEnum grantType,
    string clientId,
    string clientSecret)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `grantType` | [`Models.GrantTypeEnum`](../../doc/models/grant-type-enum.md) | Query, Required | The grant type for OAuth2.0. |
| `clientId` | `string` | Form, Required | Client ID. |
| `clientSecret` | `string` | Form, Required | Client Secret. |

## Response Type

[`Task<Models.AccessTokenResponse>`](../../doc/models/access-token-response.md)

## Example Usage

```csharp
GrantTypeEnum grantType = GrantTypeEnum.ClientCredentials;
string clientId = "YOUR_CLIENT_ID";
string clientSecret = "YOUR_SECRET";

try
{
    AccessTokenResponse result = await authenticationController.GetAccessTokenAsync(grantType, clientId, clientSecret);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "token_type": "BearerToken",
  "issued_at": "1543070211759",
  "access_token": "8mYaXTpV3kNz0TXypU4rEkVdZqMH",
  "expires_in": "2999",
  "status": "approved"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | The requested operation could not be performed. Input Request is invalid or incorrect. | `ApiException` |
| 401 | Unauthorized - Invalid API Key and Token. | `ApiException` |
| 403 | Forbidden. Access to requested data is forbidden. | `ApiException` |
| 404 | Not Found. Requested resource does not exist. | `ApiException` |
| 408 | Timeout. Operation timed out. | `ApiException` |
| 413 | Request Entity Too Large. Earthport limits the request payload size to 100KB. | `ApiException` |
| 415 | Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON. | `ApiException` |
| 429 | Too many requests hit the API too quickly. We recommend an exponential backoff of your requests. | `ApiException` |
| 500 | An internal error has occurred in the VPL payment platform. | `ApiException` |


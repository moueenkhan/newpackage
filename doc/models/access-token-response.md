
# Access Token Response

The OAuth 2.0 access token to be used in each subsequent API call.

## Structure

`AccessTokenResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TokenType` | `string` | Optional | Type of token. |
| `IssuedAt` | `string` | Optional | Time the token was issued. This is milliseconds since epoch. |
| `AccessToken` | `string` | Required | The actual token which needs to be used to authorize each subsequent API request. |
| `ExpiresIn` | `string` | Optional | When this token expires in seconds. |
| `Status` | `string` | Optional | The status of the token. |

## Example (as JSON)

```json
{
  "token_type": "BearerToken",
  "issued_at": "1543070211759",
  "access_token": "8mYaXTpV3kNz0TXypU4rEkVdZqMH",
  "expires_in": "2999",
  "status": "approved"
}
```


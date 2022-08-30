
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Sandbox`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `AccessToken` | `string` | The OAuth 2.0 Access Token to use for API requests. |

The API client can be initialized as follows:

```csharp
RestApiClient.Standard.RestApiClientClient client = new RestApiClient.Standard.RestApiClientClient.Builder()
    .AccessToken("AccessToken")
    .Environment(RestApiClient.Standard.Environment.Sandbox)
    .HttpClientConfig(config => config.NumberOfRetries(0))
    .Build();
```

## Visa Payments Limited APIClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| UsersController | Gets UsersController controller. |
| PaymentsController | Gets PaymentsController controller. |
| AuthenticationController | Gets AuthenticationController controller. |
| BeneficiaryBankAccountsController | Gets BeneficiaryBankAccountsController controller. |
| QuotesController | Gets QuotesController controller. |
| TransactionsController | Gets TransactionsController controller. |
| SettlementCalendarsController | Gets SettlementCalendarsController controller. |
| BalancesController | Gets BalancesController controller. |
| StatementsController | Gets StatementsController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |
| AccessTokenCredentials | Gets the access token to use with OAuth 2 authentication. | `IAccessTokenCredentials` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Visa Payments Limited APIClient using the values provided for the builder. | `Builder` |

## Visa Payments Limited APIClient Builder Class

Class to build instances of Visa Payments Limited APIClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `AccessTokenCredentials(IAccessTokenCredentials accessTokenCredentials)` | Gets the access token to use with OAuth 2 authentication. | `Builder` |


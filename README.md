
# Getting Started with Visa Payments Limited API

## Introduction

This API supports all services required to make cross border payments using our Visa Payments Limited network.

## Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (RestApiClient.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8, Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

## Installation

The following section explains how to use the RestApiClient.Standard library in a new project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=createProject)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=setStartup)

### 3. Add reference of the library project

In order to use the Tester library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `Tester.Tests` and click `OK`. By doing this, we have added a reference of the `Tester.Tests` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=createReference)

### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=RestApiClient-CSharp&workspaceName=RestApiClient&projectName=RestApiClient.Standard&rootNamespace=RestApiClient.Standard&step=addCode)

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](doc/client.md)

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

## Environments

The SDK can be configured to use a different environment for making API calls. Available environments are:

### Fields

| Name | Description |
|  --- | --- |
| production | Production server. |
| sandbox | **Default** Sandbox is used for both sandbox testing and customer UAT. |
| customer integration | Customer integration is used by existing clients who need to test new functionality before it is released onto sandbox and production. |

## Authorization

This API uses `OAuth 2 Bearer token`.

## List of APIs

* [Authentication](doc/controllers/authentication.md)
* [Balances](doc/controllers/balances.md)
* [Beneficiary Bank Accounts](doc/controllers/beneficiary-bank-accounts.md)
* [Payments](doc/controllers/payments.md)
* [Quotes](doc/controllers/quotes.md)
* [Settlement Calendars](doc/controllers/settlement-calendars.md)
* [Statements](doc/controllers/statements.md)
* [Transactions](doc/controllers/transactions.md)
* [Users](doc/controllers/users.md)

## Classes Documentation

* [Utility Classes](doc/utility-classes.md)
* [HttpRequest](doc/http-request.md)
* [HttpResponse](doc/http-response.md)
* [HttpStringResponse](doc/http-string-response.md)
* [HttpContext](doc/http-context.md)
* [HttpClientConfiguration](doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](doc/http-client-configuration-builder.md)
* [IAuthManager](doc/i-auth-manager.md)
* [ApiException](doc/api-exception.md)


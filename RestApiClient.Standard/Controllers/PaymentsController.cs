// <copyright file="PaymentsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Authentication;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Request;
    using RestApiClient.Standard.Http.Request.Configuration;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// PaymentsController.
    /// </summary>
    internal class PaymentsController : BaseController, IPaymentsController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal PaymentsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Returns the required fields for creating the payment request.
        /// </summary>
        /// <param name="countryCode">Required parameter: Valid supported ISO 3166 2-character country code..</param>
        /// <param name="currencyCode">Required parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="beneficiaryIdentityEntityType">Optional parameter: Type of beneficiary identity..</param>
        /// <param name="locale">Optional parameter: Localization String e.g. en_GB, en_US..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        public Models.GetPayoutRequiredDataResponse GetMetadataforPaymentRequest(
                string countryCode,
                string currencyCode,
                Models.IdentityEntityEnum? beneficiaryIdentityEntityType = null,
                string locale = null,
                string serviceLevel = null)
        {
            Task<Models.GetPayoutRequiredDataResponse> t = this.GetMetadataforPaymentRequestAsync(countryCode, currencyCode, beneficiaryIdentityEntityType, locale, serviceLevel);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the required fields for creating the payment request.
        /// </summary>
        /// <param name="countryCode">Required parameter: Valid supported ISO 3166 2-character country code..</param>
        /// <param name="currencyCode">Required parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="beneficiaryIdentityEntityType">Optional parameter: Type of beneficiary identity..</param>
        /// <param name="locale">Optional parameter: Localization String e.g. en_GB, en_US..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        public async Task<Models.GetPayoutRequiredDataResponse> GetMetadataforPaymentRequestAsync(
                string countryCode,
                string currencyCode,
                Models.IdentityEntityEnum? beneficiaryIdentityEntityType = null,
                string locale = null,
                string serviceLevel = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/payments/meta");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "countryCode", countryCode },
                { "currencyCode", currencyCode },
                { "beneficiaryIdentityEntityType", (beneficiaryIdentityEntityType.HasValue) ? ApiHelper.JsonSerialize(beneficiaryIdentityEntityType.Value).Trim('\"') : null },
                { "locale", locale },
                { "serviceLevel", serviceLevel },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the Earthport payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetPayoutRequiredDataResponse>(response.Body);
        }

        /// <summary>
        /// Creates a new payment for a previously registered beneficiary bank account (and user).
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: Payment details.</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.PaymentsRegisteredBeneficiaryCreateResponse response from the API call.</returns>
        public Models.PaymentsRegisteredBeneficiaryCreateResponse CreatePaymentRegisteredBeneficiary(
                string userID,
                string bankID,
                Models.Payment body,
                Models.IdTypeEnum? idType = null)
        {
            Task<Models.PaymentsRegisteredBeneficiaryCreateResponse> t = this.CreatePaymentRegisteredBeneficiaryAsync(userID, bankID, body, idType);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new payment for a previously registered beneficiary bank account (and user).
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: Payment details.</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PaymentsRegisteredBeneficiaryCreateResponse response from the API call.</returns>
        public async Task<Models.PaymentsRegisteredBeneficiaryCreateResponse> CreatePaymentRegisteredBeneficiaryAsync(
                string userID,
                string bankID,
                Models.Payment body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}/bank-accounts/{bankID}/payments");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "userID", userID },
                { "bankID", bankID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.PaymentsRegisteredBeneficiaryCreateResponse>(response.Body);
        }

        /// <summary>
        /// This service creates a payment without the need to pre-register either the User or Beneficiary Bank Account.
        /// Creates a User (or updates an existing User), adds a Beneficiary Bank Account to this user and creates a new payment.
        /// </summary>
        /// <param name="body">Required parameter: The payment request..</param>
        /// <returns>Returns the Models.PaymentsCreateResponse response from the API call.</returns>
        public Models.PaymentsCreateResponse CreatePayment(
                Models.PaymentsCreateRequest body)
        {
            Task<Models.PaymentsCreateResponse> t = this.CreatePaymentAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This service creates a payment without the need to pre-register either the User or Beneficiary Bank Account.
        /// Creates a User (or updates an existing User), adds a Beneficiary Bank Account to this user and creates a new payment.
        /// </summary>
        /// <param name="body">Required parameter: The payment request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PaymentsCreateResponse response from the API call.</returns>
        public async Task<Models.PaymentsCreateResponse> CreatePaymentAsync(
                Models.PaymentsCreateRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/payments");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.PaymentsCreateResponse>(response.Body);
        }

        /// <summary>
        /// Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="amount">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="payerType">Optional parameter: The type of Payer. Allowed values are authenticatedCaller, managedMerchant and user..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        public Models.GetPayoutRequiredDataResponse GetPurposeofPaymentMetadata(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                int? amount = null,
                string currency = null,
                string payerType = null,
                string serviceLevel = null)
        {
            Task<Models.GetPayoutRequiredDataResponse> t = this.GetPurposeofPaymentMetadataAsync(userID, bankID, idType, amount, currency, payerType, serviceLevel);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="amount">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="payerType">Optional parameter: The type of Payer. Allowed values are authenticatedCaller, managedMerchant and user..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        public async Task<Models.GetPayoutRequiredDataResponse> GetPurposeofPaymentMetadataAsync(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                int? amount = null,
                string currency = null,
                string payerType = null,
                string serviceLevel = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}/bank-accounts/{bankID}/payments/meta");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "userID", userID },
                { "bankID", bankID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
                { "amount", amount },
                { "currency", currency },
                { "payerType", payerType },
                { "serviceLevel", serviceLevel },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the Earthport payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetPayoutRequiredDataResponse>(response.Body);
        }
    }
}
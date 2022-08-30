// <copyright file="BalancesController.cs" company="APIMatic">
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
    /// BalancesController.
    /// </summary>
    internal class BalancesController : BaseController, IBalancesController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalancesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal BalancesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves the balance of a merchant account. .
        /// This API can be used to retrieve a set of balances represented by a monetary amount for each currency registered with the merchant's central virtual account. .
        /// You can filter the AccountBalance resource by currency if you require a balance for a specific currency. .
        /// You can also filter the AccountBalance on managedMerchantName. If no managedMerchantName is specified, then the caller will be used to identify which balance to return. If a managedMerchantName is specified, then an authorisation check will occur to ensure that the caller has the right to view the balance information for that managed merchant.
        /// </summary>
        /// <param name="managedMerchantName">Optional parameter: The name of a managed merchant registered on Visa Payments Limited..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <returns>Returns the List of Models.AccountBalance response from the API call.</returns>
        public List<Models.AccountBalance> GetBalance(
                string managedMerchantName = null,
                string currency = null)
        {
            Task<List<Models.AccountBalance>> t = this.GetBalanceAsync(managedMerchantName, currency);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the balance of a merchant account. .
        /// This API can be used to retrieve a set of balances represented by a monetary amount for each currency registered with the merchant's central virtual account. .
        /// You can filter the AccountBalance resource by currency if you require a balance for a specific currency. .
        /// You can also filter the AccountBalance on managedMerchantName. If no managedMerchantName is specified, then the caller will be used to identify which balance to return. If a managedMerchantName is specified, then an authorisation check will occur to ensure that the caller has the right to view the balance information for that managed merchant.
        /// </summary>
        /// <param name="managedMerchantName">Optional parameter: The name of a managed merchant registered on Visa Payments Limited..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.AccountBalance response from the API call.</returns>
        public async Task<List<Models.AccountBalance>> GetBalanceAsync(
                string managedMerchantName = null,
                string currency = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/balances");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "managedMerchantName", managedMerchantName },
                { "currency", currency },
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
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.AccountBalance>>(response.Body);
        }
    }
}
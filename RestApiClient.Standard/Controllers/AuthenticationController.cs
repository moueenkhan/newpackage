// <copyright file="AuthenticationController.cs" company="APIMatic">
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
    /// AuthenticationController.
    /// </summary>
    internal class AuthenticationController : BaseController, IAuthenticationController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal AuthenticationController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Verify client credentials and returns a bearer token.
        /// </summary>
        /// <param name="grantType">Required parameter: The grant type for OAuth2.0..</param>
        /// <param name="clientId">Required parameter: Client ID..</param>
        /// <param name="clientSecret">Required parameter: Client Secret..</param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public Models.AccessTokenResponse GetAccessToken(
                Models.GrantTypeEnum grantType,
                string clientId,
                string clientSecret)
        {
            Task<Models.AccessTokenResponse> t = this.GetAccessTokenAsync(grantType, clientId, clientSecret);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Verify client credentials and returns a bearer token.
        /// </summary>
        /// <param name="grantType">Required parameter: The grant type for OAuth2.0..</param>
        /// <param name="clientId">Required parameter: Client ID..</param>
        /// <param name="clientSecret">Required parameter: Client Secret..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public async Task<Models.AccessTokenResponse> GetAccessTokenAsync(
                Models.GrantTypeEnum grantType,
                string clientId,
                string clientSecret,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Auth);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/oauth/token");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "grant_type", ApiHelper.JsonSerialize(grantType).Trim('\"') },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/x-www-form-urlencoded" },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("client_id", clientId),
                new KeyValuePair<string, object>("client_secret", clientSecret),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ApiException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
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

            return ApiHelper.JsonDeserialize<Models.AccessTokenResponse>(response.Body);
        }
    }
}
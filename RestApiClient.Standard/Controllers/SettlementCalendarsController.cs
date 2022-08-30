// <copyright file="SettlementCalendarsController.cs" company="APIMatic">
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
    /// SettlementCalendarsController.
    /// </summary>
    internal class SettlementCalendarsController : BaseController, ISettlementCalendarsController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettlementCalendarsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal SettlementCalendarsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves the Settlement Calendar for payout.
        /// </summary>
        /// <param name="beneficiaryCountry">Required parameter: Valid supported ISO 3166 2-character country code. Represents beneficiary country for the request.</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="beneficiaryCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents beneficiary currency for the request..</param>
        /// <param name="payoutRequestCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents payout currency for the request..</param>
        /// <param name="numberOfCalendarDays">Optional parameter: Represents number of days to be returned in the response. Default is 7..</param>
        /// <returns>Returns the Models.SettlementCalendarsGetResponse response from the API call.</returns>
        public Models.SettlementCalendarsGetResponse GetSettlementCalendar(
                string beneficiaryCountry,
                string serviceLevel = null,
                string beneficiaryCurrency = null,
                string payoutRequestCurrency = null,
                int? numberOfCalendarDays = 7)
        {
            Task<Models.SettlementCalendarsGetResponse> t = this.GetSettlementCalendarAsync(beneficiaryCountry, serviceLevel, beneficiaryCurrency, payoutRequestCurrency, numberOfCalendarDays);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the Settlement Calendar for payout.
        /// </summary>
        /// <param name="beneficiaryCountry">Required parameter: Valid supported ISO 3166 2-character country code. Represents beneficiary country for the request.</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="beneficiaryCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents beneficiary currency for the request..</param>
        /// <param name="payoutRequestCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents payout currency for the request..</param>
        /// <param name="numberOfCalendarDays">Optional parameter: Represents number of days to be returned in the response. Default is 7..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SettlementCalendarsGetResponse response from the API call.</returns>
        public async Task<Models.SettlementCalendarsGetResponse> GetSettlementCalendarAsync(
                string beneficiaryCountry,
                string serviceLevel = null,
                string beneficiaryCurrency = null,
                string payoutRequestCurrency = null,
                int? numberOfCalendarDays = 7,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/settlement-calendars");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "beneficiaryCountry", beneficiaryCountry },
                { "serviceLevel", serviceLevel },
                { "beneficiaryCurrency", beneficiaryCurrency },
                { "payoutRequestCurrency", payoutRequestCurrency },
                { "numberOfCalendarDays", (numberOfCalendarDays != null) ? numberOfCalendarDays : 7 },
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

            return ApiHelper.JsonDeserialize<Models.SettlementCalendarsGetResponse>(response.Body);
        }
    }
}
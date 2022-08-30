// <copyright file="StatementsController.cs" company="APIMatic">
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
    /// StatementsController.
    /// </summary>
    internal class StatementsController : BaseController, IStatementsController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatementsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal StatementsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieves a list of financial transactions and balances for a specified time period for an account administered in the Visa Payments Limited payment system. To retrieve a particular statement the startDate, endDateTime and currency of the account must be specified. The statement returned will contain transactions that occurred since the start of the startDate up to and including endDateTime. If the account (in the requested currency) does not contain any transactions for the period an empty statement is returned. Every transaction, together with the money movement it represents (debit or credit) and its resulting account balance are represented as a statement line item. There will be a number of statement line items (up to the maximum page size) per page with an opening and closing balance for that page. Currently the following transaction types may show up on a statement:.
        ///  Payout transaction,.
        ///  Refund transaction,.
        ///  User deposit,.
        ///  Liquidity deposit,.
        ///  Journal transaction,.
        ///  Merchant liquidity movement,.
        ///  Visa Payments Limited Merchant Liquidity Transfer.
        /// The operation supports sorting (by date) by specifying a sort order (ASC or DESC) and paging across multiple pages of results.
        /// </summary>
        /// <param name="currency">Required parameter: Valid supported ISO 4217 3-character currency code. The currency code representing currency of the user or merchant account..</param>
        /// <param name="startDateTime">Required parameter: Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The start day of the statement period. All transactions from the start of the day are included..</param>
        /// <param name="endDateTime">Required parameter: Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The end day timestamp of the statement period. If this is now or null the statement will include all transactions up to the current point in time..</param>
        /// <param name="sortOrder">Required parameter: Sort by transaction date in either Ascending or Descending order..</param>
        /// <param name="managedMerchantName">Optional parameter: Managed merchant whose transactions will be returned  when being called by the contracting merchant..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <returns>Returns the Models.Statement response from the API call.</returns>
        public Models.Statement GetStatement(
                string currency,
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                string managedMerchantName = null,
                int? offset = null,
                int? pageSize = null)
        {
            Task<Models.Statement> t = this.GetStatementAsync(currency, startDateTime, endDateTime, sortOrder, managedMerchantName, offset, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of financial transactions and balances for a specified time period for an account administered in the Visa Payments Limited payment system. To retrieve a particular statement the startDate, endDateTime and currency of the account must be specified. The statement returned will contain transactions that occurred since the start of the startDate up to and including endDateTime. If the account (in the requested currency) does not contain any transactions for the period an empty statement is returned. Every transaction, together with the money movement it represents (debit or credit) and its resulting account balance are represented as a statement line item. There will be a number of statement line items (up to the maximum page size) per page with an opening and closing balance for that page. Currently the following transaction types may show up on a statement:.
        ///  Payout transaction,.
        ///  Refund transaction,.
        ///  User deposit,.
        ///  Liquidity deposit,.
        ///  Journal transaction,.
        ///  Merchant liquidity movement,.
        ///  Visa Payments Limited Merchant Liquidity Transfer.
        /// The operation supports sorting (by date) by specifying a sort order (ASC or DESC) and paging across multiple pages of results.
        /// </summary>
        /// <param name="currency">Required parameter: Valid supported ISO 4217 3-character currency code. The currency code representing currency of the user or merchant account..</param>
        /// <param name="startDateTime">Required parameter: Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The start day of the statement period. All transactions from the start of the day are included..</param>
        /// <param name="endDateTime">Required parameter: Valid ISO 8601 timestamp, i.e. yyyy-MM-ddTHH:mm:ssZ. The end day timestamp of the statement period. If this is now or null the statement will include all transactions up to the current point in time..</param>
        /// <param name="sortOrder">Required parameter: Sort by transaction date in either Ascending or Descending order..</param>
        /// <param name="managedMerchantName">Optional parameter: Managed merchant whose transactions will be returned  when being called by the contracting merchant..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Statement response from the API call.</returns>
        public async Task<Models.Statement> GetStatementAsync(
                string currency,
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                string managedMerchantName = null,
                int? offset = null,
                int? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/statements");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "currency", currency },
                { "startDateTime", startDateTime },
                { "endDateTime", endDateTime },
                { "sortOrder", ApiHelper.JsonSerialize(sortOrder).Trim('\"') },
                { "managedMerchantName", managedMerchantName },
                { "offset", offset },
                { "pageSize", pageSize },
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

            return ApiHelper.JsonDeserialize<Models.Statement>(response.Body);
        }
    }
}
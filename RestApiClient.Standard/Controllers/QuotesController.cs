// <copyright file="QuotesController.cs" company="APIMatic">
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
    /// QuotesController.
    /// </summary>
    internal class QuotesController : BaseController, IQuotesController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal QuotesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Requests an  indicative quote. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="body">Required parameter: The request details to get an indicative FX quote. You must either supply the sellAmount and buyCurrency. Or you must supply the buyAmount and sellCurrency..</param>
        /// <returns>Returns the Models.QuotesIndicativeResponse response from the API call.</returns>
        public Models.QuotesIndicativeResponse GetIndicativeFXQuote(
                Models.QuotesIndicativeRequest body)
        {
            Task<Models.QuotesIndicativeResponse> t = this.GetIndicativeFXQuoteAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Requests an  indicative quote. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="body">Required parameter: The request details to get an indicative FX quote. You must either supply the sellAmount and buyCurrency. Or you must supply the buyAmount and sellCurrency..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.QuotesIndicativeResponse response from the API call.</returns>
        public async Task<Models.QuotesIndicativeResponse> GetIndicativeFXQuoteAsync(
                Models.QuotesIndicativeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/quotes/indicative");

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

            return ApiHelper.JsonDeserialize<Models.QuotesIndicativeResponse>(response.Body);
        }

        /// <summary>
        /// Requests a bulk FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time.
        /// </summary>
        /// <param name="body">Required parameter: Bulk FX Quote Request..</param>
        /// <returns>Returns the Models.QuotesBulkResponse response from the API call.</returns>
        public Models.QuotesBulkResponse CreateBulkFXQuote(
                List<Models.QuotesBulkRequest> body)
        {
            Task<Models.QuotesBulkResponse> t = this.CreateBulkFXQuoteAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Requests a bulk FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time.
        /// </summary>
        /// <param name="body">Required parameter: Bulk FX Quote Request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.QuotesBulkResponse response from the API call.</returns>
        public async Task<Models.QuotesBulkResponse> CreateBulkFXQuoteAsync(
                List<Models.QuotesBulkRequest> body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/quotes/bulk");

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

            return ApiHelper.JsonDeserialize<Models.QuotesBulkResponse>(response.Body);
        }

        /// <summary>
        /// Requests an FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: The request details to get an FX quote and receive a unique Ticket ID with a time to live..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.QuotesResponse response from the API call.</returns>
        public Models.QuotesResponse CreateFXQuote(
                string userID,
                string bankID,
                Models.QuotesRequest body,
                Models.IdTypeEnum? idType = null)
        {
            Task<Models.QuotesResponse> t = this.CreateFXQuoteAsync(userID, bankID, body, idType);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Requests an FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: The request details to get an FX quote and receive a unique Ticket ID with a time to live..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.QuotesResponse response from the API call.</returns>
        public async Task<Models.QuotesResponse> CreateFXQuoteAsync(
                string userID,
                string bankID,
                Models.QuotesRequest body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}/bank-accounts/{bankID}/quotes");

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

            return ApiHelper.JsonDeserialize<Models.QuotesResponse>(response.Body);
        }
    }
}
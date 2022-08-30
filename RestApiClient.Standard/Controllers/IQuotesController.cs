// <copyright file="IQuotesController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Request;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// IQuotesController.
    /// </summary>
    public interface IQuotesController
    {
        /// <summary>
        /// Requests an  indicative quote. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="body">Required parameter: The request details to get an indicative FX quote. You must either supply the sellAmount and buyCurrency. Or you must supply the buyAmount and sellCurrency..</param>
        /// <returns>Returns the Models.QuotesIndicativeResponse response from the API call.</returns>
        Models.QuotesIndicativeResponse GetIndicativeFXQuote(
                Models.QuotesIndicativeRequest body);

        /// <summary>
        /// Requests an  indicative quote. There are two exclusive scenarios when requesting a rate between two currencies:.
        /// 1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        /// 2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters.
        /// </summary>
        /// <param name="body">Required parameter: The request details to get an indicative FX quote. You must either supply the sellAmount and buyCurrency. Or you must supply the buyAmount and sellCurrency..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.QuotesIndicativeResponse response from the API call.</returns>
        Task<Models.QuotesIndicativeResponse> GetIndicativeFXQuoteAsync(
                Models.QuotesIndicativeRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests a bulk FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time.
        /// </summary>
        /// <param name="body">Required parameter: Bulk FX Quote Request..</param>
        /// <returns>Returns the Models.QuotesBulkResponse response from the API call.</returns>
        Models.QuotesBulkResponse CreateBulkFXQuote(
                List<Models.QuotesBulkRequest> body);

        /// <summary>
        /// Requests a bulk FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time.
        /// </summary>
        /// <param name="body">Required parameter: Bulk FX Quote Request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.QuotesBulkResponse response from the API call.</returns>
        Task<Models.QuotesBulkResponse> CreateBulkFXQuoteAsync(
                List<Models.QuotesBulkRequest> body,
                CancellationToken cancellationToken = default);

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
        Models.QuotesResponse CreateFXQuote(
                string userID,
                string bankID,
                Models.QuotesRequest body,
                Models.IdTypeEnum? idType = null);

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
        Task<Models.QuotesResponse> CreateFXQuoteAsync(
                string userID,
                string bankID,
                Models.QuotesRequest body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);
    }
}
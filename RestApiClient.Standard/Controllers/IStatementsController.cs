// <copyright file="IStatementsController.cs" company="APIMatic">
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
    /// IStatementsController.
    /// </summary>
    public interface IStatementsController
    {
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
        Models.Statement GetStatement(
                string currency,
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                string managedMerchantName = null,
                int? offset = null,
                int? pageSize = null);

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
        Task<Models.Statement> GetStatementAsync(
                string currency,
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                string managedMerchantName = null,
                int? offset = null,
                int? pageSize = null,
                CancellationToken cancellationToken = default);
    }
}
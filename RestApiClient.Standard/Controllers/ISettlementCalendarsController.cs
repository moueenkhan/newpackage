// <copyright file="ISettlementCalendarsController.cs" company="APIMatic">
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
    /// ISettlementCalendarsController.
    /// </summary>
    public interface ISettlementCalendarsController
    {
        /// <summary>
        /// Retrieves the Settlement Calendar for payout.
        /// </summary>
        /// <param name="beneficiaryCountry">Required parameter: Valid supported ISO 3166 2-character country code. Represents beneficiary country for the request.</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="beneficiaryCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents beneficiary currency for the request..</param>
        /// <param name="payoutRequestCurrency">Optional parameter: valid supported ISO 4217 3-character currency code. Represents payout currency for the request..</param>
        /// <param name="numberOfCalendarDays">Optional parameter: Represents number of days to be returned in the response. Default is 7..</param>
        /// <returns>Returns the Models.SettlementCalendarsGetResponse response from the API call.</returns>
        Models.SettlementCalendarsGetResponse GetSettlementCalendar(
                string beneficiaryCountry,
                string serviceLevel = null,
                string beneficiaryCurrency = null,
                string payoutRequestCurrency = null,
                int? numberOfCalendarDays = 7);

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
        Task<Models.SettlementCalendarsGetResponse> GetSettlementCalendarAsync(
                string beneficiaryCountry,
                string serviceLevel = null,
                string beneficiaryCurrency = null,
                string payoutRequestCurrency = null,
                int? numberOfCalendarDays = 7,
                CancellationToken cancellationToken = default);
    }
}
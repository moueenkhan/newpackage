// <copyright file="QuotesControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Controllers;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;
    using RestApiClient.Tests.Helpers;

    /// <summary>
    /// QuotesControllerTest.
    /// </summary>
    [TestFixture]
    public class QuotesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IQuotesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.QuotesController;
        }

        /// <summary>
        /// Requests an FX quote and creates a ticket for the quote. This ticket is honoured for a specified duration which is limited by Rate Expiry Date/Time. There are two exclusive scenarios when requesting a rate between two currencies:
        ///
        ///1. The caller provides a sell amount and is given the corresponding buy amount. In this case, the caller needs to populate the sellAmount and buyCurrency input parameters.
        ///
        ///2. The caller provides a buy amount and is given the corresponding sell amount. In this case, the caller needs to populate the buyAmount and sellCurrency input parameters..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateFXQuote()
        {
            // Parameters for the API call
            string userID = "3409890146942";
            string bankID = "4034215";
            Standard.Models.QuotesRequest body = ApiHelper.JsonDeserialize<Standard.Models.QuotesRequest>("{\"sellAmount\":{\"currency\":\"EUR\",\"amount\":1000},\"buyCurrency\":\"GBP\",\"serviceLevel\":\"standard\"}");
            Standard.Models.IdTypeEnum? idType = null;

            // Perform API call
            Standard.Models.QuotesResponse result = null;
            try
            {
                result = await this.controller.CreateFXQuoteAsync(userID, bankID, body, idType);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"fxTicketID\":647229,\"fxDetail\":{\"sellAmount\":{\"currency\":\"EUR\",\"amount\":1000},\"buyAmount\":{\"currency\":\"GBP\",\"amount\":822.47},\"fxRate\":{\"sellCurrency\":\"EUR\",\"buyCurrency\":\"GBP\",\"rate\":0.82247}}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}
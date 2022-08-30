// <copyright file="PaymentsControllerTest.cs" company="APIMatic">
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
    /// PaymentsControllerTest.
    /// </summary>
    [TestFixture]
    public class PaymentsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IPaymentsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PaymentsController;
        }

        /// <summary>
        /// Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetPurposeofPaymentMetadata()
        {
            // Parameters for the API call
            string userID = "3409890146942";
            string bankID = "4034221";
            Standard.Models.IdTypeEnum? idType = null;
            int? amount = 500;
            string currency = "USD";
            string payerType = "user";
            string serviceLevel = "standard";

            // Perform API call
            Standard.Models.GetPayoutRequiredDataResponse result = null;
            try
            {
                result = await this.controller.GetPurposeofPaymentMetadataAsync(userID, bankID, idType, amount, currency, payerType, serviceLevel);
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
                    "{\"purposeOfPaymentFieldGroupsList\":{\"mandatory\":true,\"purposeOfPaymentCode\":[{\"code\":\"MOR\",\"description\":\"Mortgage\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"TAX\",\"description\":\"Tax\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"MIS\",\"description\":\"Miscellaneous\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"SAL\",\"description\":\"Salary/payroll\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"LOA\",\"description\":\"Loan\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"RLS\",\"description\":\"Rent or Lease\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"BUS\",\"description\":\"Business/commercial payment\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"DEP\",\"description\":\"Deposit\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"REM\",\"description\":\"Remittance\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"ANN\",\"description\":\"Annuity\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}},{\"code\":\"PEN\",\"description\":\"Pension\",\"purposeOfPaymentUsageRestrictions\":{\"originatorType\":{\"individual\":true,\"legalEntity\":true},\"beneficiaryType\":{\"individual\":true,\"legalEntity\":true}}}]}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}
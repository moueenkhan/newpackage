// <copyright file="BeneficiaryBankAccountsControllerTest.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountsControllerTest.
    /// </summary>
    [TestFixture]
    public class BeneficiaryBankAccountsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private IBeneficiaryBankAccountsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.BeneficiaryBankAccountsController;
        }

        /// <summary>
        /// Validates a new beneficiary bank account against a User..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestValidateBeneficiaryBankAccount()
        {
            // Parameters for the API call
            Standard.Models.BeneficiaryBankAccountValidateRequest body = ApiHelper.JsonDeserialize<Standard.Models.BeneficiaryBankAccountValidateRequest>("{\"beneficiaryIdentity\":{\"individualIdentity\":{\"name\":{\"familyName\":\"Smith\",\"givenNames\":\"John\"}}},\"description\":\"Bank Account Description\",\"countryCode\":\"GB\",\"currencyCode\":\"GBP\",\"bankAccountDetails\":[{\"key\":\"accountNumber\",\"value\":\"06970093\"},{\"key\":\"accountName\",\"value\":\"account name\"},{\"key\":\"bankName\",\"value\":\"Test Bank\"},{\"key\":\"sortCode\",\"value\":\"800554\"}]}");

            // Perform API call
            Standard.Models.BeneficiaryBankAccountValidateResponse result = null;
            try
            {
                result = await this.controller.ValidateBeneficiaryBankAccountAsync(body);
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
                    "{\"isBankAccountValid\":true}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Deactivates a Beneficiary Bank Account. You will not be able to send a payment to a deactivated bank account..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeactivateBeneficiaryBankAccount()
        {
            // Parameters for the API call
            string userID = "3430090151590";
            string bankID = "7431798";
            Standard.Models.IdTypeEnum? idType = null;

            // Perform API call
            try
            {
                await this.controller.DeactivateBeneficiaryBankAccountAsync(userID, bankID, idType);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, this.HttpCallBackHandler.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Gets a Beneficiary Bank Account..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetBeneficiaryBankAccount()
        {
            // Parameters for the API call
            string userID = "3409890146942";
            string bankID = "4034215";
            Standard.Models.IdTypeEnum? idType = null;

            // Perform API call
            Standard.Models.BeneficiaryBankAccountGetResponse result = null;
            try
            {
                result = await this.controller.GetBeneficiaryBankAccountAsync(userID, bankID, idType);
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
                    "{\"userID\":{\"epUserID\":3409890146942,\"merchantUserID\":\"userID_1540303323210\"},\"benBankID\":{\"epBankID\":4034215,\"merchantBankID\":\"bankID_1540304037951\"},\"beneficiaryIdentity\":{\"individualIdentity\":{\"name\":{\"familyName\":\"Smith\",\"givenNames\":\"John\"},\"address\":{\"addressLine1\":\"ABC\",\"addressLine2\":\"ABC\",\"addressLine3\":\"ABC\",\"city\":\"ABC\",\"country\":\"GB\",\"postcode\":\"EC1A 4HY\",\"province\":\"ABC\"}}},\"description\":\"Mr J Smith current account\",\"countryCode\":\"GB\",\"currencyCode\":\"GBP\",\"isActive\":true,\"bankAccountDetails\":[{\"key\":\"bankName\",\"value\":\"Test Bank\"},{\"key\":\"accountName\",\"value\":\"Mr J. Smith\"},{\"key\":\"accountNumber\",\"value\":\"06970093\"},{\"key\":\"sortCode\",\"value\":\"800554\"},{\"key\":\"bic\",\"value\":\"BOFSGB21377\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Gets all Beneficiary Bank Accounts registered by this User..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListBankAccounts()
        {
            // Parameters for the API call
            string userID = "3409890147363";
            Standard.Models.IdTypeEnum? idType = null;
            int? offset = null;
            int? pageSize = null;

            // Perform API call
            Standard.Models.BeneficiaryBankAccountListResponse result = null;
            try
            {
                result = await this.controller.ListBankAccountsAsync(userID, idType, offset, pageSize);
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
                    "{\"beneficiaryBankAccountSummary\":[{\"benBankID\":{\"epBankID\":4036783,\"merchantBankID\":\"bankID_1542991974172\"},\"description\":\"Bank Account Description\",\"countryCode\":\"GB\",\"bankAccountDetails\":[{\"key\":\"bankName\",\"value\":\"Test Bank\"},{\"key\":\"accountName\",\"value\":\"account name\"},{\"key\":\"currencyCode\",\"value\":\"GBP\"},{\"key\":\"accountNumber\",\"value\":\"****0093\"}],\"status\":\"ACTIVE\"}],\"userID\":{\"epUserID\":3409890147363,\"merchantUserID\":\"userID_1542991954199\"},\"paginationResult\":{\"offset\":0,\"pageSize\":25,\"totalNumberOfRecords\":1}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}
// <copyright file="PaymentsCreateResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JsonSubTypes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// PaymentsCreateResponse.
    /// </summary>
    public class PaymentsCreateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsCreateResponse"/> class.
        /// </summary>
        public PaymentsCreateResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsCreateResponse"/> class.
        /// </summary>
        /// <param name="userID">userID.</param>
        /// <param name="benBankID">benBankID.</param>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="liquidityValue">liquidityValue.</param>
        /// <param name="settlementValue">settlementValue.</param>
        /// <param name="acceptedDate">acceptedDate.</param>
        /// <param name="expectedSettlementDate">expectedSettlementDate.</param>
        /// <param name="correspondentChargesExpected">correspondentChargesExpected.</param>
        /// <param name="feeValue">feeValue.</param>
        /// <param name="fxMethodExpected">fxMethodExpected.</param>
        /// <param name="fxRate">fxRate.</param>
        public PaymentsCreateResponse(
            Models.UserID userID,
            Models.BenBankID benBankID,
            Models.TransactionID transactionID,
            Models.MonetaryValue liquidityValue,
            Models.MonetaryValue settlementValue,
            string acceptedDate,
            string expectedSettlementDate,
            bool? correspondentChargesExpected = null,
            Models.MonetaryValue feeValue = null,
            Models.FXMethodEnum? fxMethodExpected = null,
            Models.FXRate fxRate = null)
        {
            this.UserID = userID;
            this.BenBankID = benBankID;
            this.TransactionID = transactionID;
            this.CorrespondentChargesExpected = correspondentChargesExpected;
            this.LiquidityValue = liquidityValue;
            this.SettlementValue = settlementValue;
            this.FeeValue = feeValue;
            this.FxMethodExpected = fxMethodExpected;
            this.FxRate = fxRate;
            this.AcceptedDate = acceptedDate;
            this.ExpectedSettlementDate = expectedSettlementDate;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("benBankID")]
        public Models.BenBankID BenBankID { get; set; }

        /// <summary>
        /// Transaction ID type which contains both the unique VPL transaction ID and the merchant supplied transaction ID.
        /// </summary>
        [JsonProperty("transactionID")]
        public Models.TransactionID TransactionID { get; set; }

        /// <summary>
        /// A flag to indicate if correspondent charges are expected during the processing of the payout request.
        /// </summary>
        [JsonProperty("correspondentChargesExpected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CorrespondentChargesExpected { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("liquidityValue")]
        public Models.MonetaryValue LiquidityValue { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("settlementValue")]
        public Models.MonetaryValue SettlementValue { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("feeValue", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue FeeValue { get; set; }

        /// <summary>
        /// Method of FX that will be used to settle the payout request.
        /// </summary>
        [JsonProperty("fxMethodExpected", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXMethodEnum? FxMethodExpected { get; set; }

        /// <summary>
        /// Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("fxRate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXRate FxRate { get; set; }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This is the timestamp when the payout instruction was accepted by the system.
        /// </summary>
        [JsonProperty("acceptedDate")]
        public string AcceptedDate { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This is an Indicative date when the payout instruction is expected to be settled to the bank. This is calculated taking into account such things as acceptedDate, the settlement agreement cut-off time and period, etc. It currently does not take into account individual countries' banking calendars.
        /// </summary>
        [JsonProperty("expectedSettlementDate")]
        public string ExpectedSettlementDate { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentsCreateResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is PaymentsCreateResponse other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.BenBankID == null && other.BenBankID == null) || (this.BenBankID?.Equals(other.BenBankID) == true)) &&
                ((this.TransactionID == null && other.TransactionID == null) || (this.TransactionID?.Equals(other.TransactionID) == true)) &&
                ((this.CorrespondentChargesExpected == null && other.CorrespondentChargesExpected == null) || (this.CorrespondentChargesExpected?.Equals(other.CorrespondentChargesExpected) == true)) &&
                ((this.LiquidityValue == null && other.LiquidityValue == null) || (this.LiquidityValue?.Equals(other.LiquidityValue) == true)) &&
                ((this.SettlementValue == null && other.SettlementValue == null) || (this.SettlementValue?.Equals(other.SettlementValue) == true)) &&
                ((this.FeeValue == null && other.FeeValue == null) || (this.FeeValue?.Equals(other.FeeValue) == true)) &&
                ((this.FxMethodExpected == null && other.FxMethodExpected == null) || (this.FxMethodExpected?.Equals(other.FxMethodExpected) == true)) &&
                ((this.FxRate == null && other.FxRate == null) || (this.FxRate?.Equals(other.FxRate) == true)) &&
                ((this.AcceptedDate == null && other.AcceptedDate == null) || (this.AcceptedDate?.Equals(other.AcceptedDate) == true)) &&
                ((this.ExpectedSettlementDate == null && other.ExpectedSettlementDate == null) || (this.ExpectedSettlementDate?.Equals(other.ExpectedSettlementDate) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.BenBankID = {(this.BenBankID == null ? "null" : this.BenBankID.ToString())}");
            toStringOutput.Add($"this.TransactionID = {(this.TransactionID == null ? "null" : this.TransactionID.ToString())}");
            toStringOutput.Add($"this.CorrespondentChargesExpected = {(this.CorrespondentChargesExpected == null ? "null" : this.CorrespondentChargesExpected.ToString())}");
            toStringOutput.Add($"this.LiquidityValue = {(this.LiquidityValue == null ? "null" : this.LiquidityValue.ToString())}");
            toStringOutput.Add($"this.SettlementValue = {(this.SettlementValue == null ? "null" : this.SettlementValue.ToString())}");
            toStringOutput.Add($"this.FeeValue = {(this.FeeValue == null ? "null" : this.FeeValue.ToString())}");
            toStringOutput.Add($"this.FxMethodExpected = {(this.FxMethodExpected == null ? "null" : this.FxMethodExpected.ToString())}");
            toStringOutput.Add($"this.FxRate = {(this.FxRate == null ? "null" : this.FxRate.ToString())}");
            toStringOutput.Add($"this.AcceptedDate = {(this.AcceptedDate == null ? "null" : this.AcceptedDate == string.Empty ? "" : this.AcceptedDate)}");
            toStringOutput.Add($"this.ExpectedSettlementDate = {(this.ExpectedSettlementDate == null ? "null" : this.ExpectedSettlementDate == string.Empty ? "" : this.ExpectedSettlementDate)}");
        }
    }
}
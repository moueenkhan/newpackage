// <copyright file="FinancialTransactionStatus.cs" company="APIMatic">
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
    /// FinancialTransactionStatus.
    /// </summary>
    public class FinancialTransactionStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialTransactionStatus"/> class.
        /// </summary>
        public FinancialTransactionStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialTransactionStatus"/> class.
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="description">description.</param>
        public FinancialTransactionStatus(
            int code,
            string description)
        {
            this.Code = code;
            this.Description = description;
        }

        /// <summary>
        /// Numerical code of financial transaction status.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Description of the financial transaction status
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FinancialTransactionStatus : ({string.Join(", ", toStringOutput)})";
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

            return obj is FinancialTransactionStatus other &&
                this.Code.Equals(other.Code) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Code = {this.Code}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
        }
    }
}
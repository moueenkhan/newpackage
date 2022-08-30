// <copyright file="QuotesIndicativeResponse.cs" company="APIMatic">
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
    /// QuotesIndicativeResponse.
    /// </summary>
    public class QuotesIndicativeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesIndicativeResponse"/> class.
        /// </summary>
        public QuotesIndicativeResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesIndicativeResponse"/> class.
        /// </summary>
        /// <param name="fxDetail">fxDetail.</param>
        public QuotesIndicativeResponse(
            Models.FXDetail fxDetail)
        {
            this.FxDetail = fxDetail;
        }

        /// <summary>
        /// Represents the details of an FX transaction, encapsulating the sellAmount, buyAmount and fxRate into a single type.
        /// </summary>
        [JsonProperty("fxDetail")]
        public Models.FXDetail FxDetail { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuotesIndicativeResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuotesIndicativeResponse other &&
                ((this.FxDetail == null && other.FxDetail == null) || (this.FxDetail?.Equals(other.FxDetail) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FxDetail = {(this.FxDetail == null ? "null" : this.FxDetail.ToString())}");
        }
    }
}
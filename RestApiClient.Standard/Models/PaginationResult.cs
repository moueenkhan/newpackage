// <copyright file="PaginationResult.cs" company="APIMatic">
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
    /// PaginationResult.
    /// </summary>
    public class PaginationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResult"/> class.
        /// </summary>
        public PaginationResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResult"/> class.
        /// </summary>
        /// <param name="offset">offset.</param>
        /// <param name="totalNumberOfRecords">totalNumberOfRecords.</param>
        /// <param name="pageSize">pageSize.</param>
        public PaginationResult(
            int offset,
            int totalNumberOfRecords,
            int? pageSize = null)
        {
            this.Offset = offset;
            this.PageSize = pageSize;
            this.TotalNumberOfRecords = totalNumberOfRecords;
        }

        /// <summary>
        /// 0-based starting offset of the page with respect to the entire resultset.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of items per page to return. If empty the maximum allowable (25) number of records will be returned.
        /// </summary>
        [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        /// <summary>
        /// Total number of records in full result set.
        /// </summary>
        [JsonProperty("totalNumberOfRecords")]
        public int TotalNumberOfRecords { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaginationResult : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaginationResult other &&
                this.Offset.Equals(other.Offset) &&
                ((this.PageSize == null && other.PageSize == null) || (this.PageSize?.Equals(other.PageSize) == true)) &&
                this.TotalNumberOfRecords.Equals(other.TotalNumberOfRecords);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Offset = {this.Offset}");
            toStringOutput.Add($"this.PageSize = {(this.PageSize == null ? "null" : this.PageSize.ToString())}");
            toStringOutput.Add($"this.TotalNumberOfRecords = {this.TotalNumberOfRecords}");
        }
    }
}
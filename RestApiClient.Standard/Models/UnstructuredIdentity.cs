// <copyright file="UnstructuredIdentity.cs" company="APIMatic">
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
    /// UnstructuredIdentity.
    /// </summary>
    public class UnstructuredIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnstructuredIdentity"/> class.
        /// </summary>
        public UnstructuredIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnstructuredIdentity"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="mValue">value.</param>
        public UnstructuredIdentity(
            Models.UnstructuredKeyNamesEnum key,
            string mValue)
        {
            this.Key = key;
            this.MValue = mValue;
        }

        /// <summary>
        /// List of all of the Key Name Fields used within Unstructured Identity. *Key Fields below are the **minimum** requirements, but additional route-specific requirements may apply - please refer to the VPL Payment Guide for more information.*
        /// </summary>
        [JsonProperty("key", ItemConverterType = typeof(StringEnumConverter))]
        public Models.UnstructuredKeyNamesEnum Key { get; set; }

        /// <summary>
        /// Unstructured Identity Value
        /// </summary>
        [JsonProperty("value")]
        public string MValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UnstructuredIdentity : ({string.Join(", ", toStringOutput)})";
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

            return obj is UnstructuredIdentity other &&
                this.Key.Equals(other.Key) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {this.Key}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue == string.Empty ? "" : this.MValue)}");
        }
    }
}
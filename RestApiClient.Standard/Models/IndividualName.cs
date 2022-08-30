// <copyright file="IndividualName.cs" company="APIMatic">
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
    /// IndividualName.
    /// </summary>
    public class IndividualName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualName"/> class.
        /// </summary>
        public IndividualName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualName"/> class.
        /// </summary>
        /// <param name="familyName">familyName.</param>
        /// <param name="givenNames">givenNames.</param>
        public IndividualName(
            string familyName,
            string givenNames)
        {
            this.FamilyName = familyName;
            this.GivenNames = givenNames;
        }

        /// <summary>
        /// The family name component of an individual's identity. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        /// <summary>
        /// The given names component of an individual's identity. For detailed examples see documentation for type IndividualName. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.
        /// </summary>
        [JsonProperty("givenNames")]
        public string GivenNames { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IndividualName : ({string.Join(", ", toStringOutput)})";
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

            return obj is IndividualName other &&
                ((this.FamilyName == null && other.FamilyName == null) || (this.FamilyName?.Equals(other.FamilyName) == true)) &&
                ((this.GivenNames == null && other.GivenNames == null) || (this.GivenNames?.Equals(other.GivenNames) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName == string.Empty ? "" : this.FamilyName)}");
            toStringOutput.Add($"this.GivenNames = {(this.GivenNames == null ? "null" : this.GivenNames == string.Empty ? "" : this.GivenNames)}");
        }
    }
}
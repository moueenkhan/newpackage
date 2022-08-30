// <copyright file="IdentityRestriction.cs" company="APIMatic">
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
    /// IdentityRestriction.
    /// </summary>
    public class IdentityRestriction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityRestriction"/> class.
        /// </summary>
        public IdentityRestriction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityRestriction"/> class.
        /// </summary>
        /// <param name="individual">individual.</param>
        /// <param name="legalEntity">legalEntity.</param>
        public IdentityRestriction(
            bool individual,
            bool legalEntity)
        {
            this.Individual = individual;
            this.LegalEntity = legalEntity;
        }

        /// <summary>
        /// Is the purpose of payment code valid if the beneficiary is an individual.
        /// </summary>
        [JsonProperty("individual")]
        public bool Individual { get; set; }

        /// <summary>
        /// Is the purpose of payment code is valid if the beneficiary is a legal entity.
        /// </summary>
        [JsonProperty("legalEntity")]
        public bool LegalEntity { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IdentityRestriction : ({string.Join(", ", toStringOutput)})";
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

            return obj is IdentityRestriction other &&
                this.Individual.Equals(other.Individual) &&
                this.LegalEntity.Equals(other.LegalEntity);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Individual = {this.Individual}");
            toStringOutput.Add($"this.LegalEntity = {this.LegalEntity}");
        }
    }
}
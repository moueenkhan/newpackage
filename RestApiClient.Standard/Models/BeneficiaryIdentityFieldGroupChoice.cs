// <copyright file="BeneficiaryIdentityFieldGroupChoice.cs" company="APIMatic">
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
    /// BeneficiaryIdentityFieldGroupChoice.
    /// </summary>
    public class BeneficiaryIdentityFieldGroupChoice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityFieldGroupChoice"/> class.
        /// </summary>
        public BeneficiaryIdentityFieldGroupChoice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityFieldGroupChoice"/> class.
        /// </summary>
        /// <param name="maxGroupsListNum">maxGroupsListNum.</param>
        /// <param name="minGroupsListNum">minGroupsListNum.</param>
        /// <param name="beneficiaryIdentityFieldGroupsList">beneficiaryIdentityFieldGroupsList.</param>
        public BeneficiaryIdentityFieldGroupChoice(
            int maxGroupsListNum,
            int minGroupsListNum,
            List<Models.BeneficiaryIdentityGroupsList> beneficiaryIdentityFieldGroupsList)
        {
            this.MaxGroupsListNum = maxGroupsListNum;
            this.MinGroupsListNum = minGroupsListNum;
            this.BeneficiaryIdentityFieldGroupsList = beneficiaryIdentityFieldGroupsList;
        }

        /// <summary>
        /// The maximum number of selections which need to be made from the choices.
        /// </summary>
        [JsonProperty("maxGroupsListNum")]
        public int MaxGroupsListNum { get; set; }

        /// <summary>
        /// The minimum number of selections which need to be made from the choices.
        /// </summary>
        [JsonProperty("minGroupsListNum")]
        public int MinGroupsListNum { get; set; }

        /// <summary>
        /// List of beneficiary identity field groups.
        /// </summary>
        [JsonProperty("beneficiaryIdentityFieldGroupsList")]
        public List<Models.BeneficiaryIdentityGroupsList> BeneficiaryIdentityFieldGroupsList { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityFieldGroupChoice : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityFieldGroupChoice other &&
                this.MaxGroupsListNum.Equals(other.MaxGroupsListNum) &&
                this.MinGroupsListNum.Equals(other.MinGroupsListNum) &&
                ((this.BeneficiaryIdentityFieldGroupsList == null && other.BeneficiaryIdentityFieldGroupsList == null) || (this.BeneficiaryIdentityFieldGroupsList?.Equals(other.BeneficiaryIdentityFieldGroupsList) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MaxGroupsListNum = {this.MaxGroupsListNum}");
            toStringOutput.Add($"this.MinGroupsListNum = {this.MinGroupsListNum}");
            toStringOutput.Add($"this.BeneficiaryIdentityFieldGroupsList = {(this.BeneficiaryIdentityFieldGroupsList == null ? "null" : $"[{string.Join(", ", this.BeneficiaryIdentityFieldGroupsList)} ]")}");
        }
    }
}
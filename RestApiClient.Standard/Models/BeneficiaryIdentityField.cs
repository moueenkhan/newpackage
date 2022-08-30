// <copyright file="BeneficiaryIdentityField.cs" company="APIMatic">
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
    /// BeneficiaryIdentityField.
    /// </summary>
    public class BeneficiaryIdentityField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityField"/> class.
        /// </summary>
        public BeneficiaryIdentityField()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityField"/> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="displaySize">displaySize.</param>
        /// <param name="elementName">elementName.</param>
        /// <param name="inputType">inputType.</param>
        /// <param name="locale">locale.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="maxSize">maxSize.</param>
        /// <param name="subTitle">subTitle.</param>
        /// <param name="tabOrder">tabOrder.</param>
        /// <param name="parameterName">parameterName.</param>
        /// <param name="separator">separator.</param>
        /// <param name="valueRegexp">valueRegexp.</param>
        /// <param name="listItems">listItems.</param>
        public BeneficiaryIdentityField(
            string description,
            long displaySize,
            string elementName,
            Models.BeneficiaryIdentityFieldInputEnum inputType,
            string locale,
            bool mandatory,
            long maxSize,
            string subTitle,
            long tabOrder,
            string parameterName = null,
            string separator = null,
            string valueRegexp = null,
            Models.BeneficiaryIdentityListItems listItems = null)
        {
            this.Description = description;
            this.DisplaySize = displaySize;
            this.ElementName = elementName;
            this.InputType = inputType;
            this.Locale = locale;
            this.Mandatory = mandatory;
            this.MaxSize = maxSize;
            this.ParameterName = parameterName;
            this.Separator = separator;
            this.SubTitle = subTitle;
            this.TabOrder = tabOrder;
            this.ValueRegexp = valueRegexp;
            this.ListItems = listItems;
        }

        /// <summary>
        /// Suggested roll-over or help text description to assist users.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A suggested field size to display.
        /// </summary>
        [JsonProperty("displaySize")]
        public long DisplaySize { get; set; }

        /// <summary>
        /// The name of the element in the addBeneficiaryBankAccount request document for the corresponding field.
        /// </summary>
        [JsonProperty("elementName")]
        public string ElementName { get; set; }

        /// <summary>
        /// Supported input types for a beneficiary identity UI.
        /// </summary>
        [JsonProperty("inputType", ItemConverterType = typeof(StringEnumConverter))]
        public Models.BeneficiaryIdentityFieldInputEnum InputType { get; set; }

        /// <summary>
        /// The localisation setting of this particular record.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Indicates whether the field is mandatory.
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// Suggested client side syntactic validation rule.
        /// </summary>
        [JsonProperty("maxSize")]
        public long MaxSize { get; set; }

        /// <summary>
        /// The name of the corresponding VPL parameter to use when calling addBeneficiaryBankAcount.
        /// </summary>
        [JsonProperty("parameterName", NullValueHandling = NullValueHandling.Ignore)]
        public string ParameterName { get; set; }

        /// <summary>
        /// The separator to display following (to the right hand side) this field, usually '-' or '/'.
        /// </summary>
        [JsonProperty("separator", NullValueHandling = NullValueHandling.Ignore)]
        public string Separator { get; set; }

        /// <summary>
        /// If present contains a sub-label to be displayed with the field.
        /// </summary>
        [JsonProperty("subTitle")]
        public string SubTitle { get; set; }

        /// <summary>
        /// Indicates the ordering of this field in the UI.
        /// </summary>
        [JsonProperty("tabOrder")]
        public long TabOrder { get; set; }

        /// <summary>
        /// The regexp for the value of this field.
        /// </summary>
        [JsonProperty("valueRegexp", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueRegexp { get; set; }

        /// <summary>
        /// The beneficiaryIdentityField contains optional listItem sub-elements. The listItem sub-elements would normally be present where the inputType attribute is 'list'.
        /// </summary>
        [JsonProperty("listItems", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BeneficiaryIdentityListItems ListItems { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityField : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityField other &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                this.DisplaySize.Equals(other.DisplaySize) &&
                ((this.ElementName == null && other.ElementName == null) || (this.ElementName?.Equals(other.ElementName) == true)) &&
                this.InputType.Equals(other.InputType) &&
                ((this.Locale == null && other.Locale == null) || (this.Locale?.Equals(other.Locale) == true)) &&
                this.Mandatory.Equals(other.Mandatory) &&
                this.MaxSize.Equals(other.MaxSize) &&
                ((this.ParameterName == null && other.ParameterName == null) || (this.ParameterName?.Equals(other.ParameterName) == true)) &&
                ((this.Separator == null && other.Separator == null) || (this.Separator?.Equals(other.Separator) == true)) &&
                ((this.SubTitle == null && other.SubTitle == null) || (this.SubTitle?.Equals(other.SubTitle) == true)) &&
                this.TabOrder.Equals(other.TabOrder) &&
                ((this.ValueRegexp == null && other.ValueRegexp == null) || (this.ValueRegexp?.Equals(other.ValueRegexp) == true)) &&
                ((this.ListItems == null && other.ListItems == null) || (this.ListItems?.Equals(other.ListItems) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.DisplaySize = {this.DisplaySize}");
            toStringOutput.Add($"this.ElementName = {(this.ElementName == null ? "null" : this.ElementName == string.Empty ? "" : this.ElementName)}");
            toStringOutput.Add($"this.InputType = {this.InputType}");
            toStringOutput.Add($"this.Locale = {(this.Locale == null ? "null" : this.Locale == string.Empty ? "" : this.Locale)}");
            toStringOutput.Add($"this.Mandatory = {this.Mandatory}");
            toStringOutput.Add($"this.MaxSize = {this.MaxSize}");
            toStringOutput.Add($"this.ParameterName = {(this.ParameterName == null ? "null" : this.ParameterName == string.Empty ? "" : this.ParameterName)}");
            toStringOutput.Add($"this.Separator = {(this.Separator == null ? "null" : this.Separator == string.Empty ? "" : this.Separator)}");
            toStringOutput.Add($"this.SubTitle = {(this.SubTitle == null ? "null" : this.SubTitle == string.Empty ? "" : this.SubTitle)}");
            toStringOutput.Add($"this.TabOrder = {this.TabOrder}");
            toStringOutput.Add($"this.ValueRegexp = {(this.ValueRegexp == null ? "null" : this.ValueRegexp == string.Empty ? "" : this.ValueRegexp)}");
            toStringOutput.Add($"this.ListItems = {(this.ListItems == null ? "null" : this.ListItems.ToString())}");
        }
    }
}
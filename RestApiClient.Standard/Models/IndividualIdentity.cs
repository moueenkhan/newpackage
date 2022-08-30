// <copyright file="IndividualIdentity.cs" company="APIMatic">
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
    /// IndividualIdentity.
    /// </summary>
    public class IndividualIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualIdentity"/> class.
        /// </summary>
        public IndividualIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualIdentity"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="address">address.</param>
        /// <param name="birthInformation">birthInformation.</param>
        /// <param name="identification">identification.</param>
        public IndividualIdentity(
            Models.IndividualName name,
            Models.Address address = null,
            Models.BirthInformation birthInformation = null,
            List<Models.Identification> identification = null)
        {
            this.Name = name;
            this.Address = address;
            this.BirthInformation = birthInformation;
            this.Identification = identification;
        }

        /// <summary>
        /// The 'givenNames' attribute is mandatory. This is a space separated list of names (not including the family name).
        /// You should supply names and not initials (wherever possible). See examples below.
        /// The 'familyName' attribute is mandatory. This contains the single family name. See examples below.
        /// *Example1 - a western citizen from a country which uses the common western naming convention(such as US, GB, FR, CA, DE etc...)*
        ///     Name = "John Michael Smith",
        ///     givenNames="John Michael" and familyName="Smith"
        /// *Example2 - a citizen from a country which uses the eastern name order where the family name comes first, followed by their given names (such as Hungary, China, Japan, Korea, Singapore, Taiwan, Vietnam etc...)*
        ///     Name = "Máo Zédÿng",
        ///     givenNames="Zédÿng" and familyName="Máo"
        ///     Name = "Hidetoshi Nakata",
        ///     givenNames="Nakata" and familyName="Hidetoshi"
        ///     Name = "Ferenc Puskás",
        ///     givenNames="Puskás" and familyName="Ferenc"
        /// *Example3 - middle east names*
        ///     Name= "Mohammed bin Rashid bin Saeed Al-Maktoum",
        ///     givenNames="Mohammed bin Rashid bin Saeed" and familyName="Al-Maktoum"
        /// *Example4 - single names, such as in Indonesia*
        ///     Name="Suharto",
        ///     givenNames="Suharto" and familyName="Suharto".
        /// </summary>
        [JsonProperty("name")]
        public Models.IndividualName Name { get; set; }

        /// <summary>
        /// Represents an address. Mandatory attributes are 'addressLine1', 'city' and 'country'. All other attributes are optional.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; set; }

        /// <summary>
        /// The group consists of elements that define birth information for an individual.
        /// </summary>
        [JsonProperty("birthInformation", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BirthInformation BirthInformation { get; set; }

        /// <summary>
        /// This group consists of an individual identification unique number and the country of origin of the identification.
        /// </summary>
        [JsonProperty("identification", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Identification> Identification { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"IndividualIdentity : ({string.Join(", ", toStringOutput)})";
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

            return obj is IndividualIdentity other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.BirthInformation == null && other.BirthInformation == null) || (this.BirthInformation?.Equals(other.BirthInformation) == true)) &&
                ((this.Identification == null && other.Identification == null) || (this.Identification?.Equals(other.Identification) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name.ToString())}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.BirthInformation = {(this.BirthInformation == null ? "null" : this.BirthInformation.ToString())}");
            toStringOutput.Add($"this.Identification = {(this.Identification == null ? "null" : $"[{string.Join(", ", this.Identification)} ]")}");
        }
    }
}
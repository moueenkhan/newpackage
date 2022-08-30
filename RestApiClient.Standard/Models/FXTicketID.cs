// <copyright file="FXTicketID.cs" company="APIMatic">
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
    /// FXTicketID.
    /// </summary>
    public class FXTicketID
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FXTicketID"/> class.
        /// </summary>
        public FXTicketID()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FXTicketID"/> class.
        /// </summary>
        /// <param name="ticketID">ticketID.</param>
        public FXTicketID(
            int ticketID)
        {
            this.TicketID = ticketID;
        }

        /// <summary>
        /// The ticket ID of an FX Quote.
        /// </summary>
        [JsonProperty("ticketID")]
        public int TicketID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FXTicketID : ({string.Join(", ", toStringOutput)})";
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

            return obj is FXTicketID other &&
                this.TicketID.Equals(other.TicketID);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TicketID = {this.TicketID}");
        }
    }
}
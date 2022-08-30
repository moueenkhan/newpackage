// <copyright file="UnstructuredKeyNamesEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// UnstructuredKeyNamesEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnstructuredKeyNamesEnum
    {
        /// <summary>
        ///I (Individual) or C (Legal Entity) - (OPTIONAL for both Payer and Beneficiary)
        /// IdentityType.
        /// </summary>
        [EnumMember(Value = "IdentityType")]
        IdentityType,

        /// <summary>
        ///Full name including First Name, Middle Name and Surname. (MANDATORY for both Payer and Beneficiary)
        /// Name.
        /// </summary>
        [EnumMember(Value = "Name")]
        Name,

        /// <summary>
        ///Address Line 1 (MANDATORY for Payer - [IF ADDRESS INFORMATION BLOCK PROVIDED], OPTIONAL for Beneficiary)
        /// AddressLine1.
        /// </summary>
        [EnumMember(Value = "AddressLine1")]
        AddressLine1,

        /// <summary>
        ///ISO Country Code (2 digits) - Address Line 1 (MANDATORY for Payer - [IF ADDRESS INFORMATION BLOCK PROVIDED], OPTIONAL for Beneficiary)
        /// Country.
        /// </summary>
        [EnumMember(Value = "Country")]
        Country
    }
}
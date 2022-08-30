// <copyright file="TransactionTypeEnum.cs" company="APIMatic">
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
    /// TransactionTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionTypeEnum
    {
        /// <summary>
        ///A financial transaction representing a payout from an account held in the EPS system.
        /// Payout.
        /// </summary>
        [EnumMember(Value = "Payout")]
        Payout,

        /// <summary>
        ///A financial transaction representing a refund (by a bank or other third-party) to the merchant's account.
        /// Refund.
        /// </summary>
        [EnumMember(Value = "Refund")]
        Refund,

        /// <summary>
        ///A financial transaction representing money paid into a merchant's account by a user.
        /// EnumUserDeposit.
        /// </summary>
        [EnumMember(Value = "User Deposit")]
        EnumUserDeposit,

        /// <summary>
        ///Financial transaction representing a deposit of liquidity (money) into a merchant account.
        /// EnumMerchantLiquidityDeposit.
        /// </summary>
        [EnumMember(Value = "Merchant Liquidity Deposit")]
        EnumMerchantLiquidityDeposit,

        /// <summary>
        ///Financial transaction representing the transfer of liquidity from a VPL account to a Merchants Central account.
        /// EnumEarthportToMerchantLiquidityTransfer.
        /// </summary>
        [EnumMember(Value = "Earthport to Merchant Liquidity Transfer")]
        EnumEarthportToMerchantLiquidityTransfer,

        /// <summary>
        ///A financial transaction representing movement of funds between a merchant's accounts held in the EPS system.
        /// EnumMerchantLiquidityMovement.
        /// </summary>
        [EnumMember(Value = "Merchant Liquidity Movement")]
        EnumMerchantLiquidityMovement,

        /// <summary>
        ///Financial transaction representing a journal entry against an account.
        /// Journal.
        /// </summary>
        [EnumMember(Value = "Journal")]
        Journal,

        /// <summary>
        ///A generic financial transaction used to represent different types of transactions in the EPS system that do not have their own specific mappings in the schema.
        /// EnumGenericTransaction.
        /// </summary>
        [EnumMember(Value = "Generic Transaction")]
        EnumGenericTransaction
    }
}
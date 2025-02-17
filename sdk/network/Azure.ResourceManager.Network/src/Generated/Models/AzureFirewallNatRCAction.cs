// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> AzureFirewall NAT Rule Collection Action. </summary>
    internal partial class AzureFirewallNatRCAction
    {
        /// <summary> Initializes a new instance of AzureFirewallNatRCAction. </summary>
        public AzureFirewallNatRCAction()
        {
        }

        /// <summary> Initializes a new instance of AzureFirewallNatRCAction. </summary>
        /// <param name="type"> The type of action. </param>
        internal AzureFirewallNatRCAction(AzureFirewallNatRCActionType? type)
        {
            Type = type;
        }

        /// <summary> The type of action. </summary>
        public AzureFirewallNatRCActionType? Type { get; set; }
    }
}

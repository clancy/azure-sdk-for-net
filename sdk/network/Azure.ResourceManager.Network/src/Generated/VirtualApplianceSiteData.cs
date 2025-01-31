// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing the VirtualApplianceSite data model. </summary>
    public partial class VirtualApplianceSiteData : SubResource
    {
        /// <summary> Initializes a new instance of VirtualApplianceSiteData. </summary>
        public VirtualApplianceSiteData()
        {
        }

        /// <summary> Initializes a new instance of VirtualApplianceSiteData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the virtual appliance site. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Site type. </param>
        /// <param name="addressPrefix"> Address Prefix. </param>
        /// <param name="o365Policy"> Office 365 Policy. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        internal VirtualApplianceSiteData(string id, string name, string etag, string type, string addressPrefix, Office365PolicyProperties o365Policy, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            AddressPrefix = addressPrefix;
            O365Policy = o365Policy;
            ProvisioningState = provisioningState;
        }

        /// <summary> Name of the virtual appliance site. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Site type. </summary>
        public string Type { get; }
        /// <summary> Address Prefix. </summary>
        public string AddressPrefix { get; set; }
        /// <summary> Office 365 Policy. </summary>
        internal Office365PolicyProperties O365Policy { get; set; }
        /// <summary> Office 365 breakout categories. </summary>
        public BreakOutCategoryPolicies O365BreakOutCategories
        {
            get => O365Policy is null ? default : O365Policy.BreakOutCategories;
            set
            {
                if (O365Policy is null)
                    O365Policy = new Office365PolicyProperties();
                O365Policy.BreakOutCategories = value;
            }
        }

        /// <summary> The provisioning state of the resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}

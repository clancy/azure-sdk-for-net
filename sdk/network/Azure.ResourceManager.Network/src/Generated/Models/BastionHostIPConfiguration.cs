// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> IP configuration of an Bastion Host. </summary>
    public partial class BastionHostIPConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of BastionHostIPConfiguration. </summary>
        public BastionHostIPConfiguration()
        {
        }

        /// <summary> Initializes a new instance of BastionHostIPConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Ip configuration type. </param>
        /// <param name="subnet"> Reference of the subnet resource. </param>
        /// <param name="publicIPAddress"> Reference of the PublicIP resource. </param>
        /// <param name="provisioningState"> The provisioning state of the bastion host IP configuration resource. </param>
        /// <param name="privateIPAllocationMethod"> Private IP allocation method. </param>
        internal BastionHostIPConfiguration(string id, string name, string etag, string type, WritableSubResource subnet, WritableSubResource publicIPAddress, ProvisioningState? provisioningState, IPAllocationMethod? privateIPAllocationMethod) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            Subnet = subnet;
            PublicIPAddress = publicIPAddress;
            ProvisioningState = provisioningState;
            PrivateIPAllocationMethod = privateIPAllocationMethod;
        }

        /// <summary> Name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Ip configuration type. </summary>
        public string Type { get; }
        /// <summary> Reference of the subnet resource. </summary>
        internal WritableSubResource Subnet { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet is null ? default : Subnet.Id;
            set
            {
                if (Subnet is null)
                    Subnet = new WritableSubResource();
                Subnet.Id = value;
            }
        }

        /// <summary> Reference of the PublicIP resource. </summary>
        internal WritableSubResource PublicIPAddress { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier PublicIPAddressId
        {
            get => PublicIPAddress is null ? default : PublicIPAddress.Id;
            set
            {
                if (PublicIPAddress is null)
                    PublicIPAddress = new WritableSubResource();
                PublicIPAddress.Id = value;
            }
        }

        /// <summary> The provisioning state of the bastion host IP configuration resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> Private IP allocation method. </summary>
        public IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Response for the ListServiceTags API service call. </summary>
    public partial class ServiceTagsListResult : ResourceData
    {
        /// <summary> Initializes a new instance of ServiceTagsListResult. </summary>
        internal ServiceTagsListResult()
        {
            Values = new ChangeTrackingList<ServiceTagInformation>();
        }

        /// <summary> Initializes a new instance of ServiceTagsListResult. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="changeNumber"> The iteration number. </param>
        /// <param name="cloud"> The name of the cloud. </param>
        /// <param name="values"> The list of service tag information resources. </param>
        /// <param name="nextLink"> The URL to get next page of service tag information resources. </param>
        internal ServiceTagsListResult(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, string changeNumber, string cloud, IReadOnlyList<ServiceTagInformation> values, string nextLink) : base(id, name, type, systemData)
        {
            ChangeNumber = changeNumber;
            Cloud = cloud;
            Values = values;
            NextLink = nextLink;
        }

        /// <summary> The iteration number. </summary>
        public string ChangeNumber { get; }
        /// <summary> The name of the cloud. </summary>
        public string Cloud { get; }
        /// <summary> The list of service tag information resources. </summary>
        public IReadOnlyList<ServiceTagInformation> Values { get; }
        /// <summary> The URL to get next page of service tag information resources. </summary>
        public string NextLink { get; }
    }
}

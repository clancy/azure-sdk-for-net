// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.DeviceUpdate.Models
{
    /// <summary> Request payload used to update an existing resource&apos;s tags. </summary>
    public partial class DeviceUpdateInstanceUpdateOptions
    {
        /// <summary> Initializes a new instance of DeviceUpdateInstanceUpdateOptions. </summary>
        public DeviceUpdateInstanceUpdateOptions()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> List of key value pairs that describe the resource. This will overwrite the existing tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Management.Models
{
    /// <summary> The ID of the parent management group. </summary>
    internal partial class DescendantParentGroupInfo
    {
        /// <summary> Initializes a new instance of DescendantParentGroupInfo. </summary>
        internal DescendantParentGroupInfo()
        {
        }

        /// <summary> Initializes a new instance of DescendantParentGroupInfo. </summary>
        /// <param name="id"> The fully qualified ID for the parent management group.  For example, /providers/Microsoft.Management/managementGroups/0000000-0000-0000-0000-000000000000. </param>
        internal DescendantParentGroupInfo(string id)
        {
            Id = id;
        }

        /// <summary> The fully qualified ID for the parent management group.  For example, /providers/Microsoft.Management/managementGroups/0000000-0000-0000-0000-000000000000. </summary>
        public string Id { get; }
    }
}

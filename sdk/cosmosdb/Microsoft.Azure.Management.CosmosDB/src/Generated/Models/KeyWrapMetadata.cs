// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents key wrap metadata that a key wrapping provider can use to
    /// wrap/unwrap a client encryption key.
    /// </summary>
    public partial class KeyWrapMetadata
    {
        /// <summary>
        /// Initializes a new instance of the KeyWrapMetadata class.
        /// </summary>
        public KeyWrapMetadata()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KeyWrapMetadata class.
        /// </summary>
        /// <param name="name">The name of associated KeyEncryptionKey (aka
        /// CustomerManagedKey).</param>
        /// <param name="type">ProviderName of KeyStoreProvider.</param>
        /// <param name="value">Reference / link to the
        /// KeyEncryptionKey.</param>
        public KeyWrapMetadata(string name = default(string), string type = default(string), string value = default(string))
        {
            Name = name;
            Type = type;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of associated KeyEncryptionKey (aka
        /// CustomerManagedKey).
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets providerName of KeyStoreProvider.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets reference / link to the KeyEncryptionKey.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}

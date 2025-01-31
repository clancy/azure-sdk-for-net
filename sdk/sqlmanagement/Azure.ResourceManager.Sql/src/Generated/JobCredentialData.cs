// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing the JobCredential data model. </summary>
    public partial class JobCredentialData : ResourceData
    {
        /// <summary> Initializes a new instance of JobCredentialData. </summary>
        public JobCredentialData()
        {
        }

        /// <summary> Initializes a new instance of JobCredentialData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="username"> The credential user name. </param>
        /// <param name="password"> The credential password. </param>
        internal JobCredentialData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, string username, string password) : base(id, name, type, systemData)
        {
            Username = username;
            Password = password;
        }

        /// <summary> The credential user name. </summary>
        public string Username { get; set; }
        /// <summary> The credential password. </summary>
        public string Password { get; set; }
    }
}

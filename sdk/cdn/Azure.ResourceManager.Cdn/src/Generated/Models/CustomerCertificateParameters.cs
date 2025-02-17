// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> Customer Certificate used for https. </summary>
    public partial class CustomerCertificateParameters : SecretParameters
    {
        /// <summary> Initializes a new instance of CustomerCertificateParameters. </summary>
        /// <param name="secretSource"> Resource reference to the KV secret. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secretSource"/> is null. </exception>
        public CustomerCertificateParameters(WritableSubResource secretSource)
        {
            if (secretSource == null)
            {
                throw new ArgumentNullException(nameof(secretSource));
            }

            SecretSource = secretSource;
            SubjectAlternativeNames = new ChangeTrackingList<string>();
            Type = SecretType.CustomerCertificate;
        }

        /// <summary> Initializes a new instance of CustomerCertificateParameters. </summary>
        /// <param name="type"> The type of the Secret to create. </param>
        /// <param name="secretSource"> Resource reference to the KV secret. </param>
        /// <param name="secretVersion"> Version of the secret to be used. </param>
        /// <param name="certificateAuthority"> Certificate issuing authority. </param>
        /// <param name="useLatestVersion"> Whether to use the latest version for the certificate. </param>
        /// <param name="subjectAlternativeNames"> The list of SANs. </param>
        internal CustomerCertificateParameters(SecretType type, WritableSubResource secretSource, string secretVersion, string certificateAuthority, bool? useLatestVersion, IList<string> subjectAlternativeNames) : base(type)
        {
            SecretSource = secretSource;
            SecretVersion = secretVersion;
            CertificateAuthority = certificateAuthority;
            UseLatestVersion = useLatestVersion;
            SubjectAlternativeNames = subjectAlternativeNames;
            Type = type;
        }

        /// <summary> Resource reference to the KV secret. </summary>
        internal WritableSubResource SecretSource { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SecretSourceId
        {
            get => SecretSource is null ? default : SecretSource.Id;
            set
            {
                if (SecretSource is null)
                    SecretSource = new WritableSubResource();
                SecretSource.Id = value;
            }
        }

        /// <summary> Version of the secret to be used. </summary>
        public string SecretVersion { get; set; }
        /// <summary> Certificate issuing authority. </summary>
        public string CertificateAuthority { get; set; }
        /// <summary> Whether to use the latest version for the certificate. </summary>
        public bool? UseLatestVersion { get; set; }
        /// <summary> The list of SANs. </summary>
        public IList<string> SubjectAlternativeNames { get; }
    }
}

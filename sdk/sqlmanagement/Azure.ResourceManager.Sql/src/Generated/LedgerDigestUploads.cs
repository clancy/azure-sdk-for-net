// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a LedgerDigestUploads along with the instance operations that can be performed on it. </summary>
    public partial class LedgerDigestUploads : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="LedgerDigestUploads"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string ledgerDigestUploads)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics;
        private readonly LedgerDigestUploadsRestOperations _ledgerDigestUploadsLedgerDigestUploadsRestClient;
        private readonly LedgerDigestUploadsData _data;

        /// <summary> Initializes a new instance of the <see cref="LedgerDigestUploads"/> class for mocking. </summary>
        protected LedgerDigestUploads()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "LedgerDigestUploads"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal LedgerDigestUploads(ArmClient client, LedgerDigestUploadsData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="LedgerDigestUploads"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal LedgerDigestUploads(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string ledgerDigestUploadsLedgerDigestUploadsApiVersion);
            _ledgerDigestUploadsLedgerDigestUploadsRestClient = new LedgerDigestUploadsRestOperations(_ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, ledgerDigestUploadsLedgerDigestUploadsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/databases/ledgerDigestUploads";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual LedgerDigestUploadsData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the current ledger digest upload configuration for a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<LedgerDigestUploads>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploads.Get");
            scope.Start();
            try
            {
                var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the current ledger digest upload configuration for a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LedgerDigestUploads> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploads.Get");
            scope.Start();
            try
            {
                var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Disables uploading ledger digests to an Azure Storage account or an Azure Confidential Ledger instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}/disable
        /// Operation Id: LedgerDigestUploads_Disable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<LedgerDigestUploads>> DisableAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploads.Disable");
            scope.Start();
            try
            {
                var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.DisableAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<LedgerDigestUploads>(new LedgerDigestUploadsOperationSource(Client), _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics, Pipeline, _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateDisableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Disables uploading ledger digests to an Azure Storage account or an Azure Confidential Ledger instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}/disable
        /// Operation Id: LedgerDigestUploads_Disable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LedgerDigestUploads> Disable(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploads.Disable");
            scope.Start();
            try
            {
                var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.Disable(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation<LedgerDigestUploads>(new LedgerDigestUploadsOperationSource(Client), _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics, Pipeline, _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateDisableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

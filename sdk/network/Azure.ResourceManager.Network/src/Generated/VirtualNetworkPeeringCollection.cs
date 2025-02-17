// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of VirtualNetworkPeering and their operations over its parent. </summary>
    public partial class VirtualNetworkPeeringCollection : ArmCollection, IEnumerable<VirtualNetworkPeering>, IAsyncEnumerable<VirtualNetworkPeering>
    {
        private readonly ClientDiagnostics _virtualNetworkPeeringClientDiagnostics;
        private readonly VirtualNetworkPeeringsRestOperations _virtualNetworkPeeringRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkPeeringCollection"/> class for mocking. </summary>
        protected VirtualNetworkPeeringCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkPeeringCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualNetworkPeeringCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualNetworkPeeringClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VirtualNetworkPeering.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualNetworkPeering.ResourceType, out string virtualNetworkPeeringApiVersion);
            _virtualNetworkPeeringRestClient = new VirtualNetworkPeeringsRestOperations(_virtualNetworkPeeringClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualNetworkPeeringApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualNetwork.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualNetwork.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a peering in the specified virtual network.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkPeeringName"> The name of the peering. </param>
        /// <param name="virtualNetworkPeeringParameters"> Parameters supplied to the create or update virtual network peering operation. </param>
        /// <param name="syncRemoteAddressSpace"> Parameter indicates the intention to sync the peering with the current address space on the remote vNet after it&apos;s updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> or <paramref name="virtualNetworkPeeringParameters"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualNetworkPeering>> CreateOrUpdateAsync(bool waitForCompletion, string virtualNetworkPeeringName, VirtualNetworkPeeringData virtualNetworkPeeringParameters, SyncRemoteAddressSpace? syncRemoteAddressSpace = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));
            Argument.AssertNotNull(virtualNetworkPeeringParameters, nameof(virtualNetworkPeeringParameters));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualNetworkPeeringRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, virtualNetworkPeeringParameters, syncRemoteAddressSpace, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<VirtualNetworkPeering>(new VirtualNetworkPeeringOperationSource(Client), _virtualNetworkPeeringClientDiagnostics, Pipeline, _virtualNetworkPeeringRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, virtualNetworkPeeringParameters, syncRemoteAddressSpace).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a peering in the specified virtual network.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkPeeringName"> The name of the peering. </param>
        /// <param name="virtualNetworkPeeringParameters"> Parameters supplied to the create or update virtual network peering operation. </param>
        /// <param name="syncRemoteAddressSpace"> Parameter indicates the intention to sync the peering with the current address space on the remote vNet after it&apos;s updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> or <paramref name="virtualNetworkPeeringParameters"/> is null. </exception>
        public virtual ArmOperation<VirtualNetworkPeering> CreateOrUpdate(bool waitForCompletion, string virtualNetworkPeeringName, VirtualNetworkPeeringData virtualNetworkPeeringParameters, SyncRemoteAddressSpace? syncRemoteAddressSpace = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));
            Argument.AssertNotNull(virtualNetworkPeeringParameters, nameof(virtualNetworkPeeringParameters));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualNetworkPeeringRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, virtualNetworkPeeringParameters, syncRemoteAddressSpace, cancellationToken);
                var operation = new NetworkArmOperation<VirtualNetworkPeering>(new VirtualNetworkPeeringOperationSource(Client), _virtualNetworkPeeringClientDiagnostics, Pipeline, _virtualNetworkPeeringRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, virtualNetworkPeeringParameters, syncRemoteAddressSpace).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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

        /// <summary>
        /// Gets the specified virtual network peering.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkPeering>> GetAsync(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualNetworkPeeringRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualNetworkPeeringClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetworkPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified virtual network peering.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public virtual Response<VirtualNetworkPeering> Get(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualNetworkPeeringRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, cancellationToken);
                if (response.Value == null)
                    throw _virtualNetworkPeeringClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all virtual network peerings in a virtual network.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings
        /// Operation Id: VirtualNetworkPeerings_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualNetworkPeering" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualNetworkPeering> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualNetworkPeering>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkPeeringRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualNetworkPeering>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkPeeringRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all virtual network peerings in a virtual network.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings
        /// Operation Id: VirtualNetworkPeerings_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualNetworkPeering" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualNetworkPeering> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualNetworkPeering> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkPeeringRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualNetworkPeering> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkPeeringRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualNetworkPeeringName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualNetworkPeeringName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkPeering>> GetIfExistsAsync(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualNetworkPeeringRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkPeering>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/virtualNetworkPeerings/{virtualNetworkPeeringName}
        /// Operation Id: VirtualNetworkPeerings_Get
        /// </summary>
        /// <param name="virtualNetworkPeeringName"> The name of the virtual network peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkPeeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkPeeringName"/> is null. </exception>
        public virtual Response<VirtualNetworkPeering> GetIfExists(string virtualNetworkPeeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkPeeringName, nameof(virtualNetworkPeeringName));

            using var scope = _virtualNetworkPeeringClientDiagnostics.CreateScope("VirtualNetworkPeeringCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualNetworkPeeringRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, virtualNetworkPeeringName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkPeering>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualNetworkPeering> IEnumerable<VirtualNetworkPeering>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualNetworkPeering> IAsyncEnumerable<VirtualNetworkPeering>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}

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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of VirtualNetworkGateway and their operations over its parent. </summary>
    public partial class VirtualNetworkGatewayCollection : ArmCollection, IEnumerable<VirtualNetworkGateway>, IAsyncEnumerable<VirtualNetworkGateway>
    {
        private readonly ClientDiagnostics _virtualNetworkGatewayClientDiagnostics;
        private readonly VirtualNetworkGatewaysRestOperations _virtualNetworkGatewayRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkGatewayCollection"/> class for mocking. </summary>
        protected VirtualNetworkGatewayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkGatewayCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualNetworkGatewayCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualNetworkGatewayClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VirtualNetworkGateway.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualNetworkGateway.ResourceType, out string virtualNetworkGatewayApiVersion);
            _virtualNetworkGatewayRestClient = new VirtualNetworkGatewaysRestOperations(_virtualNetworkGatewayClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualNetworkGatewayApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a virtual network gateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="parameters"> Parameters supplied to create or update virtual network gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualNetworkGateway>> CreateOrUpdateAsync(bool waitForCompletion, string virtualNetworkGatewayName, VirtualNetworkGatewayData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<VirtualNetworkGateway>(new VirtualNetworkGatewayOperationSource(Client), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a virtual network gateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="parameters"> Parameters supplied to create or update virtual network gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<VirtualNetworkGateway> CreateOrUpdate(bool waitForCompletion, string virtualNetworkGatewayName, VirtualNetworkGatewayData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<VirtualNetworkGateway>(new VirtualNetworkGatewayOperationSource(Client), _virtualNetworkGatewayClientDiagnostics, Pipeline, _virtualNetworkGatewayRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets the specified virtual network gateway by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkGateway>> GetAsync(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualNetworkGatewayClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetworkGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified virtual network gateway by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public virtual Response<VirtualNetworkGateway> Get(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, cancellationToken);
                if (response.Value == null)
                    throw _virtualNetworkGatewayClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all virtual network gateways by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways
        /// Operation Id: VirtualNetworkGateways_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualNetworkGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualNetworkGateway> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualNetworkGateway>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkGatewayRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGateway(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualNetworkGateway>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkGatewayRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGateway(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all virtual network gateways by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways
        /// Operation Id: VirtualNetworkGateways_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualNetworkGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualNetworkGateway> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualNetworkGateway> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkGatewayRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGateway(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualNetworkGateway> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkGatewayRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGateway(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualNetworkGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualNetworkGatewayName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkGateway>> GetIfExistsAsync(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkGateway>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}
        /// Operation Id: VirtualNetworkGateways_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayName"> The name of the virtual network gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayName"/> is null. </exception>
        public virtual Response<VirtualNetworkGateway> GetIfExists(string virtualNetworkGatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayName, nameof(virtualNetworkGatewayName));

            using var scope = _virtualNetworkGatewayClientDiagnostics.CreateScope("VirtualNetworkGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkGateway>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualNetworkGateway> IEnumerable<VirtualNetworkGateway>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualNetworkGateway> IAsyncEnumerable<VirtualNetworkGateway>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}

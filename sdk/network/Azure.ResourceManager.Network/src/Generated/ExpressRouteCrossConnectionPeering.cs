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
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a ExpressRouteCrossConnectionPeering along with the instance operations that can be performed on it. </summary>
    public partial class ExpressRouteCrossConnectionPeering : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ExpressRouteCrossConnectionPeering"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string crossConnectionName, string peeringName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _expressRouteCrossConnectionPeeringClientDiagnostics;
        private readonly ExpressRouteCrossConnectionPeeringsRestOperations _expressRouteCrossConnectionPeeringRestClient;
        private readonly ClientDiagnostics _expressRouteCrossConnectionClientDiagnostics;
        private readonly ExpressRouteCrossConnectionsRestOperations _expressRouteCrossConnectionRestClient;
        private readonly ExpressRouteCrossConnectionPeeringData _data;

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteCrossConnectionPeering"/> class for mocking. </summary>
        protected ExpressRouteCrossConnectionPeering()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ExpressRouteCrossConnectionPeering"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ExpressRouteCrossConnectionPeering(ArmClient client, ExpressRouteCrossConnectionPeeringData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteCrossConnectionPeering"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ExpressRouteCrossConnectionPeering(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _expressRouteCrossConnectionPeeringClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string expressRouteCrossConnectionPeeringApiVersion);
            _expressRouteCrossConnectionPeeringRestClient = new ExpressRouteCrossConnectionPeeringsRestOperations(_expressRouteCrossConnectionPeeringClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, expressRouteCrossConnectionPeeringApiVersion);
            _expressRouteCrossConnectionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ExpressRouteCrossConnection.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ExpressRouteCrossConnection.ResourceType, out string expressRouteCrossConnectionApiVersion);
            _expressRouteCrossConnectionRestClient = new ExpressRouteCrossConnectionsRestOperations(_expressRouteCrossConnectionClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, expressRouteCrossConnectionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/expressRouteCrossConnections/peerings";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ExpressRouteCrossConnectionPeeringData Data
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
        /// Gets the specified peering for the ExpressRouteCrossConnection.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCrossConnectionPeerings_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ExpressRouteCrossConnectionPeering>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _expressRouteCrossConnectionPeeringClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.Get");
            scope.Start();
            try
            {
                var response = await _expressRouteCrossConnectionPeeringRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _expressRouteCrossConnectionPeeringClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExpressRouteCrossConnectionPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified peering for the ExpressRouteCrossConnection.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCrossConnectionPeerings_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExpressRouteCrossConnectionPeering> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _expressRouteCrossConnectionPeeringClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.Get");
            scope.Start();
            try
            {
                var response = _expressRouteCrossConnectionPeeringRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _expressRouteCrossConnectionPeeringClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCrossConnectionPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified peering from the ExpressRouteCrossConnection.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCrossConnectionPeerings_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _expressRouteCrossConnectionPeeringClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.Delete");
            scope.Start();
            try
            {
                var response = await _expressRouteCrossConnectionPeeringRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_expressRouteCrossConnectionPeeringClientDiagnostics, Pipeline, _expressRouteCrossConnectionPeeringRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified peering from the ExpressRouteCrossConnection.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCrossConnectionPeerings_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _expressRouteCrossConnectionPeeringClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.Delete");
            scope.Start();
            try
            {
                var response = _expressRouteCrossConnectionPeeringRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation(_expressRouteCrossConnectionPeeringClientDiagnostics, Pipeline, _expressRouteCrossConnectionPeeringRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the currently advertised ARP table associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/arpTables/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListArpTable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public async virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCrossConnectionAsync(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetArpTableExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = await _expressRouteCrossConnectionRestClient.ListArpTableAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<ExpressRouteCircuitsArpTableListResult>(new ExpressRouteCircuitsArpTableListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListArpTableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the currently advertised ARP table associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/arpTables/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListArpTable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCrossConnection(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetArpTableExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = _expressRouteCrossConnectionRestClient.ListArpTable(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken);
                var operation = new NetworkArmOperation<ExpressRouteCircuitsArpTableListResult>(new ExpressRouteCircuitsArpTableListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListArpTableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the route table summary associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/routeTablesSummary/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListRoutesTableSummary
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public async virtual Task<ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCrossConnectionAsync(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetRoutesTableSummaryExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = await _expressRouteCrossConnectionRestClient.ListRoutesTableSummaryAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult>(new ExpressRouteCrossConnectionsRoutesTableSummaryListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListRoutesTableSummaryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the route table summary associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/routeTablesSummary/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListRoutesTableSummary
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public virtual ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCrossConnection(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetRoutesTableSummaryExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = _expressRouteCrossConnectionRestClient.ListRoutesTableSummary(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken);
                var operation = new NetworkArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult>(new ExpressRouteCrossConnectionsRoutesTableSummaryListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListRoutesTableSummaryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the currently advertised routes table associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/routeTables/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListRoutesTable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public async virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCrossConnectionAsync(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetRoutesTableExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = await _expressRouteCrossConnectionRestClient.ListRoutesTableAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<ExpressRouteCircuitsRoutesTableListResult>(new ExpressRouteCircuitsRoutesTableListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListRoutesTableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the currently advertised routes table associated with the express route cross connection in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{crossConnectionName}/peerings/{peeringName}/routeTables/{devicePath}
        /// Operation Id: ExpressRouteCrossConnections_ListRoutesTable
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="devicePath"> The path of the device. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="devicePath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="devicePath"/> is null. </exception>
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCrossConnection(bool waitForCompletion, string devicePath, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(devicePath, nameof(devicePath));

            using var scope = _expressRouteCrossConnectionClientDiagnostics.CreateScope("ExpressRouteCrossConnectionPeering.GetRoutesTableExpressRouteCrossConnection");
            scope.Start();
            try
            {
                var response = _expressRouteCrossConnectionRestClient.ListRoutesTable(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath, cancellationToken);
                var operation = new NetworkArmOperation<ExpressRouteCircuitsRoutesTableListResult>(new ExpressRouteCircuitsRoutesTableListResultOperationSource(), _expressRouteCrossConnectionClientDiagnostics, Pipeline, _expressRouteCrossConnectionRestClient.CreateListRoutesTableRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, devicePath).Request, response, OperationFinalStateVia.Location);
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

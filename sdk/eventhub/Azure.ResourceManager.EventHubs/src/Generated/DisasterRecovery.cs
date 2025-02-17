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

namespace Azure.ResourceManager.EventHubs
{
    /// <summary> A Class representing a DisasterRecovery along with the instance operations that can be performed on it. </summary>
    public partial class DisasterRecovery : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DisasterRecovery"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics;
        private readonly DisasterRecoveryConfigsRestOperations _disasterRecoveryDisasterRecoveryConfigsRestClient;
        private readonly ClientDiagnostics _disasterRecoveryClientDiagnostics;
        private readonly DisasterRecoveriesRestOperations _disasterRecoveryRestClient;
        private readonly DisasterRecoveryData _data;

        /// <summary> Initializes a new instance of the <see cref="DisasterRecovery"/> class for mocking. </summary>
        protected DisasterRecovery()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DisasterRecovery"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DisasterRecovery(ArmClient client, DisasterRecoveryData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DisasterRecovery"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DisasterRecovery(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string disasterRecoveryDisasterRecoveryConfigsApiVersion);
            _disasterRecoveryDisasterRecoveryConfigsRestClient = new DisasterRecoveryConfigsRestOperations(_disasterRecoveryDisasterRecoveryConfigsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, disasterRecoveryDisasterRecoveryConfigsApiVersion);
            _disasterRecoveryClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string disasterRecoveryApiVersion);
            _disasterRecoveryRestClient = new DisasterRecoveriesRestOperations(_disasterRecoveryClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, disasterRecoveryApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.EventHub/namespaces/disasterRecoveryConfigs";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DisasterRecoveryData Data
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

        /// <summary> Gets a collection of DisasterRecoveryAuthorizationRules in the DisasterRecoveryAuthorizationRule. </summary>
        /// <returns> An object representing collection of DisasterRecoveryAuthorizationRules and their operations over a DisasterRecoveryAuthorizationRule. </returns>
        public virtual DisasterRecoveryAuthorizationRuleCollection GetDisasterRecoveryAuthorizationRules()
        {
            return new DisasterRecoveryAuthorizationRuleCollection(Client, Id);
        }

        /// <summary>
        /// Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}
        /// Operation Id: DisasterRecoveryConfigs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DisasterRecovery>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.Get");
            scope.Start();
            try
            {
                var response = await _disasterRecoveryDisasterRecoveryConfigsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DisasterRecovery(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}
        /// Operation Id: DisasterRecoveryConfigs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DisasterRecovery> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.Get");
            scope.Start();
            try
            {
                var response = _disasterRecoveryDisasterRecoveryConfigsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DisasterRecovery(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an Alias(Disaster Recovery configuration)
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}
        /// Operation Id: DisasterRecoveries_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryClientDiagnostics.CreateScope("DisasterRecovery.Delete");
            scope.Start();
            try
            {
                var response = await _disasterRecoveryRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new EventHubsArmOperation(response);
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
        /// Deletes an Alias(Disaster Recovery configuration)
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}
        /// Operation Id: DisasterRecoveries_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryClientDiagnostics.CreateScope("DisasterRecovery.Delete");
            scope.Start();
            try
            {
                var response = _disasterRecoveryRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new EventHubsArmOperation(response);
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
        /// This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/breakPairing
        /// Operation Id: DisasterRecoveryConfigs_BreakPairing
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> BreakPairingAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.BreakPairing");
            scope.Start();
            try
            {
                var response = await _disasterRecoveryDisasterRecoveryConfigsRestClient.BreakPairingAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/breakPairing
        /// Operation Id: DisasterRecoveryConfigs_BreakPairing
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response BreakPairing(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.BreakPairing");
            scope.Start();
            try
            {
                var response = _disasterRecoveryDisasterRecoveryConfigsRestClient.BreakPairing(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/failover
        /// Operation Id: DisasterRecoveryConfigs_FailOver
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> FailOverAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.FailOver");
            scope.Start();
            try
            {
                var response = await _disasterRecoveryDisasterRecoveryConfigsRestClient.FailOverAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/failover
        /// Operation Id: DisasterRecoveryConfigs_FailOver
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response FailOver(CancellationToken cancellationToken = default)
        {
            using var scope = _disasterRecoveryDisasterRecoveryConfigsClientDiagnostics.CreateScope("DisasterRecovery.FailOver");
            scope.Start();
            try
            {
                var response = _disasterRecoveryDisasterRecoveryConfigsRestClient.FailOver(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
